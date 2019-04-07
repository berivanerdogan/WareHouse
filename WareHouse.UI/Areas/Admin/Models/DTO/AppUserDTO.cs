using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WareHouse.Model.Enum;

namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class AppUserDTO:BaseDTO
    {
        [Required(ErrorMessage ="Please Add Your FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Add Your LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Add Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Add Your UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Add Your Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Choose a Gender")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Please Choose a Role")]
        public Role Role { get; set; }
    }
}