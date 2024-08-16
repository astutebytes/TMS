using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Application.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateOnly ScheduledDate { get; set; }
        public required TimeOnly ScheduledTimeFrom { get; set; }
        public required TimeOnly ScheduledTimeTo { get; set; }
        public required string Latitude { get; set; }
        public required string Longitude { get; set; }
        public required string Address { get; set; }
        public required int AppUserId { get; set; }
        public required int CategoryId { get; set; }
    }
}
