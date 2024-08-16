using System.Threading;
using TMS.Domain.Common;

namespace TMS.Domain.Entities
{
    public class TMSCategory : BaseEntity<int>
    {
        public required string Name { get; set; }
        public ICollection<TMSEvent> TMSEvents { get; set; }

        public TMSCategory()
        {
            TMSEvents = [];
        }
    }
}
