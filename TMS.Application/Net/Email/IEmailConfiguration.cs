namespace TMS.Application.Net.Email
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }
        string FromEmail { get; set; }
        string NoReplyEmail { get; }
    }
}
