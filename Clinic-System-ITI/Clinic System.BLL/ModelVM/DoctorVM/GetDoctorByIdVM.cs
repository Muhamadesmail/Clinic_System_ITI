using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.DoctorVM
{
    public class GetDoctorByIdVM
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //[Required(ErrorMessage = "Department is required")]
        //public int Department { get; set; }
        public Shift Shift { get; set; }
        public String? Image { get; set; }
        public int DepartmentID { get; set; }   
        public decimal SessionPrice { get; set; }
        public string Description { get; set; }
        public GetDoctorByIdVM(Doctor doctor)
        {
            DoctorID = doctor.DoctorID;
            FirstName = doctor.User.FirstName;
            LastName = doctor.User.LastName;
            Age = doctor.User.Age;
            Gender = doctor.User.Gender;
            PhoneNumber = doctor.User.PhoneNumber;
            Email = doctor.User.Email;
            Shift = doctor.Shift;
            SessionPrice = doctor.SessionPrice;
            Description = doctor.Description;
            DepartmentID = doctor.DeptID;
        }
    }
}
