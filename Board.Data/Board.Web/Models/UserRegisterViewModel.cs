using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using Board.Data.Models;
using Board.Data.Repos;

namespace Board.Web.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "{0} can't be longer than {1} characters")]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} can't be longer than {1} characters")]
        [Column("surname")]
        public string Surname { get; set; }

        [Required]
        [Column("email")]
        [DataType(DataType.EmailAddress)]
        [Remote("EmailAlreadyRegistered","User",HttpMethod = "POST", ErrorMessage = "This E-Mail has already been registered")]
        public string EMail { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} can't be longer than {1} characters")]
        [Remote("UsernameAlreadyRegistered", "User", HttpMethod = "POST", ErrorMessage = "This Username has already been registered")]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("screenname")]
        [Remote("ScreennameAlreadyRegistered", "User", HttpMethod = "POST", ErrorMessage = "This Screenname has already been registered")]
        public string Screenname { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} can't be longer than {1} characters")]
        [Column("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match")]
        [Column("cnfrm_password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Column("birth_date")]
        [Display(Name = "Birth Date")]
        [Over18]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("gender")]
        public string Gender { get; set; }
    }
}