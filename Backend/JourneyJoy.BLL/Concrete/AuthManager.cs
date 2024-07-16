using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.AuthDtos;
using JourneyJoy.DTO.ServiceResponseDtos;
using JourneyJoy.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static JourneyJoy.DTO.ServiceResponseDtos.LoginResponseDto;

namespace JourneyJoy.BLL.Concrete
{
    public class AuthManager(IAuthDAL authDAL, IMapper mapper, IConfiguration config) : IAuthService
    {
        public async Task<ApiResponseDto<string>> CreateAccount(RegisterDto registerDto)
        {
            if (registerDto is null) return new ApiResponseDto<string>("Registration", false, 401, "Model is empty");
            var newUser = mapper.Map<AppUser>(registerDto);

            // Creating 
            var createUser = await authDAL.CreateUserAsync(newUser!, registerDto.Password);
            if (!createUser) return new ApiResponseDto<string>("Registration", false, 404, "Error occured.. please try again");

            //Assign Default Role : Admin to first registrar; rest is user
            var checkAdmin = await authDAL.GetRoleNameAsync("Admin");
            if (checkAdmin)
            {
                await authDAL.CreateRoleNameAsync("Admin");
                await authDAL.AddUserToRoleAsync(newUser, "Admin");
                return new ApiResponseDto<string>("Admin Registration", true, 201, "Account Created");
            }

            else
            {
                var checkUser = await authDAL.GetRoleNameAsync("Member");
                if (checkUser)
                    await authDAL.CreateRoleNameAsync("Member");
                await authDAL.AddUserToRoleAsync(newUser, "Member");
                return new ApiResponseDto<string>("Member Registration", true, 201, "Account Created");
            }
        }

        public async Task<ApiResponseDto<string>> EditAccount(UserInfoDto editAuthDto, int userId)
        {
            if (editAuthDto == null)
                return new ApiResponseDto<string>("Edit Profile", false, 401, "Model is empty");

            // Get the current user from the database
            var currentUser = await authDAL.GetUserByIdAsync(userId);
            if (currentUser == null)
                return new ApiResponseDto<string>("Edit Profile", false, 404, "User not found");

            // Map the DTO to the current user entity
            mapper.Map(editAuthDto, currentUser);

            var updateUser = await authDAL.EditProfile(currentUser);
            if (!updateUser)
                return new ApiResponseDto<string>("Edit Profile", false, 500, "Error occurred.. please try again");

            return new ApiResponseDto<string>("Edit Profile", true, 200, "Profile updated successfully.");
        }

        public async Task<ApiResponseDto<LoginResponse>> LoginAsync(LoginDto loginDto)
        {
            if (loginDto == null)
                return new ApiResponseDto<LoginResponse>(null, false, 400, "Login container is empty", new Dictionary<string, List<string>>
        {
            { "Login", new List<string> { "Login container is empty" } }
        });

            var getUser = await authDAL.GetUserByUserNameAsync(loginDto.UserName);
            if (getUser is null)
                return new ApiResponseDto<LoginResponse>(null, false, 404, "User not found", new Dictionary<string, List<string>>
        {
            { "Login", new List<string> { "User not found" } }
        });

            var result = await authDAL.SignInAsync(loginDto.UserName, loginDto.Password, true, false);
            if (!result.Succeeded)
                return new ApiResponseDto<LoginResponse>(null, false, 400, "Invalid username/password", new Dictionary<string, List<string>>
        {
            { "Login", new List<string> { "Invalid username/password" } }
        });

            var getUserRole = await authDAL.GetUserRolesAsync(getUser);
            var userSession = new UserSessionDto(getUser.Id.ToString(), getUser.UserName, getUser.Email, getUserRole.First());
            string token = GenerateToken(userSession);
            var userInfo = mapper.Map<UserInfoDto>(getUser);
            userInfo.Roles = await authDAL.GetUserRolesAsync(getUser);
            var loginResponse = new LoginResponse(token, userInfo);
            return new ApiResponseDto<LoginResponse>(loginResponse, true, 200, "Login completed");
        }

        public async Task<ApiResponseDto<string>> TDeleteUserAsync(int id) // at the and that will change for status , or when Admin delete some user , that infos still keep in another database..
        {
            var member = await authDAL.GetUserByIdAsync(id);
            if (member is null)
                return new ApiResponseDto<string>("Delete Member", false, 404, "Member not found!");
            if (member.Roles.Contains("Member") && !member.Roles.Contains("Admin"))
            {
                var response = await authDAL.DeleteUser(member);
                if (response)
                    return new ApiResponseDto<string>("Delete Member", true, 200, "Member deleted successfully");
                return new ApiResponseDto<string>("Delete Member", false, 500, "Internal Server Error!");
            }
            return new ApiResponseDto<string>("Delete Member", false, 403, "You have no authorize to do that operation!");

        }

        // To Find All Members (Users actually but difference from Admin role)
        public async Task<ApiResponseDto<IEnumerable<UserInfoDto>>> TGetAllMembersAsync()
        {
            var users = await authDAL.GetAllUsersAsync();
            if (users is null)
                return new ApiResponseDto<IEnumerable<UserInfoDto>>(default, false, 404, "No users found");
            var members = new List<UserInfoDto>();
            foreach(var user in users) 
            {
                var roles = await authDAL.GetUserRolesAsync(user);
                if (roles.Contains("Member") && roles != null)
                {
                    var userInfoDto = mapper.Map<UserInfoDto>(user);
                    userInfoDto.Roles = roles;
                    members.Add(userInfoDto);
                }
            }

            if (members.Count == 0)
                return new ApiResponseDto<IEnumerable<UserInfoDto>>(default, false, 404, "No members found");
            return new ApiResponseDto<IEnumerable<UserInfoDto>>(members, true, 200, "Members fetched successfully");
        }


        public async Task<ApiResponseDto<UserInfoDto>> TGetUserByEmail(string email)
        {
            var user = await authDAL.GetUserByEmailAsync(email);
            if (user is null)
                return new ApiResponseDto<UserInfoDto>(default, true, 403, "User not found by email");

            var userInfos = mapper.Map<UserInfoDto>(user);
            return new ApiResponseDto<UserInfoDto>(userInfos, true, 200, "User fetched successfully by email");
        }

        public async Task<ApiResponseDto<UserInfoDto>> TGetUserById(int id)
        {
            var user = await authDAL.GetUserByIdAsync(id);
            if (user is null)
                return new ApiResponseDto<UserInfoDto>(default, true, 403, "User not found by id");

            var userInfos = mapper.Map<UserInfoDto>(user);
            var roles = await authDAL.GetUserRolesAsync(user);
            userInfos.Roles = roles; // Adding roles..
            return new ApiResponseDto<UserInfoDto>(userInfos, true, 200, "User fetched successfully by id");
        }

        public async Task<ApiResponseDto<int>> TGetUserCountAsync()
        {
            var response = await authDAL.GetUsersCount();
            if (response == 0)
                return new ApiResponseDto<int>(0, false, 403, "Users not found");
            return new ApiResponseDto<int>(response, true, 200, "Users count fetched successfully");
        }

        private string GenerateToken(UserSessionDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }        
    }
}
