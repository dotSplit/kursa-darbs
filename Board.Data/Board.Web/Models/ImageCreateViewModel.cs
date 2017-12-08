using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Board.Web.Models
{
    public class ImageCreateViewModel
    {
        [Required]
        [MaxLength(30)]
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [AllowHtml]
        [Required]
        [Column("image")]
        public HttpPostedFileBase Image { get; set; }

    }
}