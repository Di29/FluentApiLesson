using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FluentApiLesson
{
    [Table("sports_players")]
    public class Player
    {
        [Column("ID")]
        [Required]
        [Key]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Длина меньше 3 символов")]
        public string FullName { get; set; }
        [Display(Name = "Номер игрока на футболке")]
        public int Number { get; set; }

        //[NotMapped]
        public virtual Team Team { get; set;  }
        [Column("ref_team")]
        [ForeignKey("Team")]
        public int TeamId { get; set; }
    }
}
