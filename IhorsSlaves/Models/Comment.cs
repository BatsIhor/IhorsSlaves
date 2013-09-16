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

        [Required(ErrorMessage = "Введіть своє ім’я")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Невірна кількість символів")]
        public string User { get; set; }

        [Required(ErrorMessage = "Введіть свій Email адрес")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Невірний Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [StringLength(800, MinimumLength = 1, ErrorMessage = "Невірна кількість символів")]
        public string Content { get; set; }
        
        public DateTime Date { get; set; }
    }
}