using JourneyJoy.DTO.MailRequestDtos;
using JourneyJoy.DTO.ServiceResponseDtos;

namespace JourneyJoy.BLL.Abstract
{
    public interface IEmailService
    {
        Task<ApiResponseDto<string>> SendEmailAsync(MailRequest mailRequest);
    }
}
