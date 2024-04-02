namespace SignSafe.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime LastUpdated { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }
        public bool Deleted { get; protected set; }

        public void SetCreatedAt()
        {
            CreatedAt = DateTime.Now;
        }

        public void SetLastUpdated()
        {
            LastUpdated = DateTime.Now;
        }

        public void SetDeletedAt()
        {
            DeletedAt = DateTime.Now;
            Deleted = true;
        }
    }

}
