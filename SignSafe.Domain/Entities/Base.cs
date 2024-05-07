using System.Text.Json.Serialization;

namespace SignSafe.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        [JsonIgnore]
        public DateTime? DeletedAt { get; protected set; }
        [JsonIgnore]
        public bool Deleted { get; protected set; }

        public void SetCreatedAt()
        {
            CreatedAt = DateTime.Now;
        }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }

        public void SetDeletedAt()
        {
            DeletedAt = DateTime.Now;
            Deleted = true;
        }
    }
}
