using AutoMapper;
using JourneyJoy.DTO.AboutDtos;
using JourneyJoy.DTO.AccountDtos;
using JourneyJoy.DTO.AnnouncementDtos;
using JourneyJoy.DTO.AuthDtos;
using JourneyJoy.DTO.CommentDtos;
using JourneyJoy.DTO.ContactDtos;
using JourneyJoy.DTO.DestinationDtos;
using JourneyJoy.DTO.FeatureDtos;
using JourneyJoy.DTO.GetContactDtos;
using JourneyJoy.DTO.GuideDtos;
using JourneyJoy.DTO.NewsLetterDtos;
using JourneyJoy.DTO.ReservationDtos;
using JourneyJoy.DTO.SubAboutDtos;
using JourneyJoy.DTO.TestimonialDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Helper
{
    // To for using dtos .. 
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();

            CreateMap<Account, CreateAccountDto>().ReverseMap();
            CreateMap<Account, UpdateAccountDto>().ReverseMap();
            CreateMap<Account, ResultAccountDto>().ReverseMap();

            CreateMap<Announcement, CreateAnnouncementDto>().ReverseMap();
            CreateMap<Announcement, UpdateAnnouncementDto>().ReverseMap();
            CreateMap<Announcement, ResultAnnouncementDto>().ReverseMap();

            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, ResultCommentDto>().ReverseMap();

            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();

            CreateMap<Destination, CreateDestinationDto>().ReverseMap();
            CreateMap<Destination, UpdateDestinationDto>().ReverseMap();
            CreateMap<Destination, ResultDestinationDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();

            CreateMap<GetContact, CreateGetContactDto>().ReverseMap();
            CreateMap<GetContact, UpdateGetContactDto>().ReverseMap();
            CreateMap<GetContact, ResultGetContactDto>().ReverseMap();

            CreateMap<Guide, CreateGuideDto>().ReverseMap();
            CreateMap<Guide, UpdateGuideDto>().ReverseMap();
            CreateMap<Guide, ResultGuideDto>().ReverseMap();

            CreateMap<NewsLetter, CreateNewsLetterDto>().ReverseMap();
            CreateMap<NewsLetter, UpdateNewsLetterDto>().ReverseMap();
            CreateMap<NewsLetter, ResultNewsLetterDto>().ReverseMap();

            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
            CreateMap<Reservation, ResultReservationDto>().ReverseMap();

            CreateMap<SubAbout, CreateSubAboutDto>().ReverseMap();
            CreateMap<SubAbout, UpdateSubAboutDto>().ReverseMap();
            CreateMap<SubAbout, ResultSubAboutDto>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();

            // App User - Register Dto
            CreateMap<RegisterDto, AppUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Mail))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

            // App User to Edit 
            CreateMap<EditAuthDto, AppUser>()
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            CreateMap<UserInfoDto, AppUser>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore())  // Ignore Roles in initial mapping
    .AfterMap((src, dest) =>
    {
        dest.Roles = src.Roles.ToList();
    })
    .ReverseMap()
    .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles));
        }


    }

}
