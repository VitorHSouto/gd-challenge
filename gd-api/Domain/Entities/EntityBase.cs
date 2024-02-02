using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = new Guid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Active = true;
        }

        [Column("id")]
        public Guid Id { get; set; }

        [Column("createdat")]
        public DateTime CreatedAt { get; set; }

        [Column("updatedat")]
        public DateTime UpdatedAt { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}
