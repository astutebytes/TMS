using TMS.Application.DTOs;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Persistence.Data;

namespace TMS.Persistence.Repositories
{
    public class EventRepository(DataContext context) : IEventRepository
    {
        public void AddEvent(TMSEvent model)
        {
            context.Events.Add(model);
        }
    }
}
