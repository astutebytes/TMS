namespace TMS.Application.Interfaces
{
    public interface IJobService
    {
        void EnqueueJob(string to);
    }
}
