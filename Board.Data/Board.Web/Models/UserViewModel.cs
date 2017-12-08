using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Board.Web.Models
{
    public class UserViewModel
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
        [Column("screenname")]
        public string Screenname { get; set; }
    }
}