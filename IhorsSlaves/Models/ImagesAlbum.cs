using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IhorsSlaves.Models
{
    [Table("ImagesAlbums")]
    public class ImagesAlbum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}