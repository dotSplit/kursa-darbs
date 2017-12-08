using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Data.Models
{
    public class Administrator
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("user")]
        public User User { get; set; }
    }
}
