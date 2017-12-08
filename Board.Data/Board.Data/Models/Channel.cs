using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Data.Models
{
    public class Channel
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("rules")]
        public string Rules { get; set; }
    }
}
