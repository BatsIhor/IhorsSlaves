using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IhorsSlaves.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int PostId { get; set; }

        [Required(ErrorMessage = "Поле повинно бути заповнене")]
        [StringLength(80, ErrorMessage="Максимальна довжина 80 символів")]
        public string PostName { get; set; }

        [UIHint("tinymce_jquery_full")]
        [StringLength(2429993, ErrorMessage="Максимальне число симолів 2429993")]
        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public string PostUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        //public List<Comment> Comments { get; set; }
    }
}