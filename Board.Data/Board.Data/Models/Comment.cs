using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Data.Models
{
    public class Comment
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("content")]
        public string Content { get; set; }

        [Required]
        [Column("user")]
        public User User { get; set; }

        [Required]
        [Column("post")]
        public Post Post { get; set; }
    }
}
