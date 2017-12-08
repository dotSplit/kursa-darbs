using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Board.Data.Models;

namespace Board.Web.Models
{
    public class UserIndexViewModel
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
        [MaxLength(30)]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [Column("birth_date")]
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }

        [Column("is_group_admin")]
        [Display(Name = "Group Admin")]
        public bool IsGroupAdmin { get; set; }

        [Column("posts")]
        [Display(Name = "Post Count")]
        public int PostCount { get; set; }

        [Column("images")]
        [Display(Name = "Image Count")]
        public int ImageCount { get; set; }
    }
}