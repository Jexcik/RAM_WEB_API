namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Guid { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
