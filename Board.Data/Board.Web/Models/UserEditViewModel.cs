using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Board.Data.Models;
using Board.Data.Repos;

namespace Board.Web.Models
{
    public class UserEditViewModel
    {
        public User OriginalUser { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} can't be longer than {1} characters")]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} can't be longer than {1} characters")]
        [Column("surname")]
        public string Surname { get; set; }

        [Required]
        [Column("original-screenname")]
        public string OriginalScreenname { get; set; }

        [Required]
        [Column("screenname")]
        [Remote("ScreennameAlreadyRegistered", "User", AdditionalFields = "OriginalScreenname", HttpMethod = "POST", ErrorMessage = "This Screenname has already been registered")]
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
        [Column("gender")]
        public string Gender { get; set; }
    }
}