using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IhorsSlaves.Models;

namespace IhorsSlaves.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int CommentId { get; set; }

        public string Content { get; set; }

        [ScaffoldColumn(false)]
        public int? PostIdPostId { get; set; }
        public Post Post { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }
    }
}