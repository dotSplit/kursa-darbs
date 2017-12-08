using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Authentication.ExtendedProtection;

namespace Board.Data.Models
{
    public class Post
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("content")]
        public string Content { get; set; }

        [Required]
        [Column("user")]
        public User User { get; set; }

        [Required]
        [Column("channel")]
        public Channel Channel { get; set; }
    }
}
