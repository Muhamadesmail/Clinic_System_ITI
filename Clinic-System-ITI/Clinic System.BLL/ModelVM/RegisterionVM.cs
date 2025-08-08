using Clinic_System.DAL.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM
{
    public class RegisterionVM
    {
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Age is required")]
        public int Age { get; set; }


        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

     

        [Compare("Password", ErrorMessage ="The Password Not The Same") ]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string? Address { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
