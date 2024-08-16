using TMS.Domain.Common;

namespace TMS.Domain.Entities
{
    public class TMSEvent : BaseEntity<int>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateOnly ScheduledDate { get; set; }
        public required TimeOnly ScheduledTimeFrom { get; set; }
        public required TimeOnly ScheduledTimeTo { get; set; }
        public required string Latitude { get; set; }
        public required string Longitude { get; set; }
        public required string Address { get; set; }
        public required int AppUserId { get; set; }
        public required AppUser AppUser { get; set; }
        public required int CategoryId { get; set; }
        public required TMSCategory Category { get; set; }
    }
}
