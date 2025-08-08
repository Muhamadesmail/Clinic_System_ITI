using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Enum;
using System;

namespace Clinic_System.BLL.ModelVM.DoctorVM
{
    public class GetAllDoctorsVM
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Shift Shift { get; set; }
        public decimal SessionPrice { get; set; }
        public bool? IsDeleted { get; set; }
        public GetAllDoctorsVM(Doctor doctor)
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
            IsDeleted = doctor.User.IsDeleted;
        }
    }
}
