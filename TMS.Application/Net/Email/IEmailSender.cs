namespace TMS.Application.Net.Email
{
    public interface IEmailSender
    {
        Task AccountConfirmationEmailAsync(string to, string clientUrl, bool isHtml = false);
        Task PasswordResetEmailAsync(string to, string clientUrl, bool isHtml = false);
    }
}
