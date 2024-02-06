using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Dtos.File
{
    public class FileDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string Extension { get; set; }
        public string Mimetype { get; set; }
        public string publicUrl { get; set; }
    }
}
