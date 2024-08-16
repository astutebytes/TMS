using Hangfire;
using TMS.Application.Interfaces;
using TMS.Application.Net.Email;

namespace TMS.Persistence.Services
{
    public class HangfireJobService(IBackgroundJobClient backgroundJob, IEmailSender emailSender) : IJobService
    {
        public void EnqueueJob(string to)
        {
            backgroundJob.Enqueue(() => emailSender.AccountConfirmationEmailAsync(to, "http://localhost", false));
        }
    }
}
