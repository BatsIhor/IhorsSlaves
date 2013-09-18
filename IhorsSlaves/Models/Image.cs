using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IhorsSlaves.Models
{
    [Table("Images")]
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int ImageId { get; set; }

        public string Tag { get; set; }

        public string ImageURL { get; set; }

        public string User { get; set; }

        public DateTime UploadDate { get; set; }
    }
}