namespace JourneyJoy.UI.Core.Dtos.MailDtos
{
    public class MailRequestDto
    {
        public string Name { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
