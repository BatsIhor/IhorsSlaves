using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IhorsSlaves.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int CommentId { get; set; }

        public int PostId { get; set; }

        public string User { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }
    }
}