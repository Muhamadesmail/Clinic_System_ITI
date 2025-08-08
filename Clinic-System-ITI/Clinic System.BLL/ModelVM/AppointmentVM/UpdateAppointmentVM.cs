using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.AppointmentVM
{
    public class UpdateAppointmentVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        [Required(ErrorMessage = "Time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; }
        public bool Isbooked { get; set; }
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "Doctor ID is required.")]
        public int DoctorID { get; set; }
        [Required(ErrorMessage = "Department ID is required.")]
        public int DeptID { get; set; }
        public int? PatientID { get; set; }
    }
}
