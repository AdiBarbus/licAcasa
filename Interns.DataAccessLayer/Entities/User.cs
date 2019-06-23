using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Interns.DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is Required")]
        //[Remote("IsUserExists", "Register", ErrorMessage = "User Name already in use")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(150, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string PasswordSalt { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? CreateDate { get; set; }
        public string Phone { get; set; }
        public string University { get; set; }
        public virtual Address Address { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<Advertise> Advertises { get; set; }
    }
}
