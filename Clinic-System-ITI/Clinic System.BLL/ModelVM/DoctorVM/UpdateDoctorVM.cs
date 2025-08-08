using Clinic_System.DAL.Enum;
using global::Clinic_System.DAL.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.DoctorVM
{
    public class UpdateDoctorVM
    {
        public int DoctorID { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(25, 80, ErrorMessage = "Age must be between 25 and 80")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int? DepartmentID { get; set; }

        [Required(ErrorMessage = "Shift is required")]
        public Shift Shift { get; set; }
        public String? Image { get; set; }
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Session price is required")]
        [Range(80, double.MaxValue, ErrorMessage = "Session price must be at least 80")]
        public decimal SessionPrice { get; set; }

        public string Description { get; set; }
    }

}