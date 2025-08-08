using Clinic_System.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.PatientVM
{
    public class EditPatientVM
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public int Age { get; set; } = 0;
        public Gender Gender { get; set; } = Gender.Male;
        public string? Image { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public string Address { get; set; }
    }
}
