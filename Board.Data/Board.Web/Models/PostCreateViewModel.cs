using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Board.Data.Models;

namespace Board.Web.Models
{
    public class PostCreateViewModel
    {
        [Required]
        [MaxLength(30)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("description")]
        public string Content { get; set; }

        [Column("channel")]
        public int Channel { get; set; }
    }
}