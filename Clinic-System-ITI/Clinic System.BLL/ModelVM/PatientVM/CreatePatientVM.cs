using Clinic_System.DAL.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.PatientVM
{
    public class CreatePatientVM
    {

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email {  get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; } = 0;

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; } = Gender.Male;
        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool? IsDeleted { get; set; } = false;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

    }
}
