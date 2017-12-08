using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Board.Data.Models
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("surname")]
        public string Surname { get; set; }

        [Required]
        [Column("email")]
        public string EMail { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("screenname")]
        public string Screenname { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [Column("birth_date")]
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }

        [Column("posts")]
        public List<Post> Posts { get; set; }

        [Required]
        [Column("gender")]
        public string Gender { get; set; }

        [Column("comments")]
        public List<Comment> Comments { get; set; }

        [Column("reputation")]
        public int Reputation { get; set; }
    }
}
