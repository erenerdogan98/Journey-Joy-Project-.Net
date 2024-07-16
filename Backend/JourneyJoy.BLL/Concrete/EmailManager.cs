using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.MailRequestDtos;
using JourneyJoy.DTO.ServiceResponseDtos;
using MimeKit;
using MailKit.Net.Smtp;

namespace JourneyJoy.BLL.Concrete
{
    public class EmailManager : IEmailService
    {
        public async Task<ApiResponseDto<string>> SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(mailRequest.Name, mailRequest.SenderMail));
                email.To.Add(new MailboxAddress(mailRequest.ReceiverName, mailRequest.ReceiverMail));
                email.Subject = mailRequest.Subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = mailRequest.Body };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("traversalcore2@gmail.com", "123456Aa-");
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return new ApiResponseDto<string>("Email sent successfully.", true, 200, "Success");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<string>(null, false, 500, $"Error occurred: {ex.Message}");
            }
        }
    }
}
