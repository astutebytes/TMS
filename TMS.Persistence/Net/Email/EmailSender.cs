using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using TMS.Application.Common.Constants;
using TMS.Application.Net.Email;

namespace TMS.Persistence.Net.Email
{
    public class EmailSender(IEmailConfiguration emailConfiguration) : IEmailSender
    {
        public async Task AccountConfirmationEmailAsync(string to, string clientUrl, bool isHtml = false)
        {
            var message = new MimeKit.MimeMessage();
            message.To.Add(new MailboxAddress(to));
            message.From.Add(new MailboxAddress("TicketMgmtSystem", emailConfiguration.FromEmail));

            message.Subject = AppConstant.ACCOUNT_CONFIMATION_SUBJECT;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = "Please confirm your account by clicking <a href=\"" + clientUrl + "\">here</a>"
            };

            await SendEmailAsync(message);
            await Task.CompletedTask;
        }

        public Task PasswordResetEmailAsync(string to, string clientUrl, bool isHtml = false)
        {
            throw new NotImplementedException();
        }

        private async Task SendEmailAsync(MimeMessage message)
        {
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(emailConfiguration.SmtpServer, emailConfiguration.SmtpPort, false);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                await emailClient.AuthenticateAsync(emailConfiguration.SmtpUsername, emailConfiguration.SmtpPassword);

                await emailClient.SendAsync(message);
                await emailClient.DisconnectAsync(quit: true);
            }
        }
    }
}
