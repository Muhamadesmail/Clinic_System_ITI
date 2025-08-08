using Clinic_System.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.DoctorVM
{
    public class DeleteDoctorVM
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int Age { get; set; } = 0;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
        public string? Image { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public Shift Shift { get; set; }
        public int SessionPrice { get; set; }
        public string Description { get; set; }
        public int DeptID { get; set; }
    }
}
