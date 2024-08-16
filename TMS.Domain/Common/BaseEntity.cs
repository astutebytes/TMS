namespace TMS.Domain.Common
{
    public class BaseEntity<T>
    {
        public required T Id { get; set; }
        public DateTime DateCreated { get; set; } = default;
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
    }
}
