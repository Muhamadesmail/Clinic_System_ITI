using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.PatientVM
{
    public class GetAllPatientVM
    {

        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int Age { get; set; } = 0;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
        public string? Image { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public string Address { get; set; }

        public GetAllPatientVM(Patient patient)
        {
            PatientID =patient.PatientID;
            FirstName = patient.User.FirstName;
            LastName = patient.User.LastName;
            Age = patient.User.Age;
            Gender= patient.User.Gender;
            PhoneNumber = patient.User.PhoneNumber;
            Email = patient.User.Email;
            Address = patient.Address;
        }
    }
}
