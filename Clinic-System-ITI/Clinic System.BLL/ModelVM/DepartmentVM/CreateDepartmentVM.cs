using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.DepartmentVM
{
    public class CreateDepartmentVM
    {
        [Required(ErrorMessage = "First name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
