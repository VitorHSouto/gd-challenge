using System.ComponentModel.DataAnnotations.Schema;

namespace gd_api.Domain.Entities
{
    public class FileEntity : EntityBase
    {

        [Column("extension")]
        public string Extension { get; set; }

        [Column("mimetype")]
        public string Mimetype { get; set; }

        [Column("publicurl")]
        public string publicUrl { get; set; }
    }
}
