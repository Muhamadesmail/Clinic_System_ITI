using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.AppointmentVM
{
    public class CreateAppointmentVM
    {
        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        [Required(ErrorMessage = "Time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; }
        public bool Isbooked { get; set; } = false;
        [Required(ErrorMessage = "Doctor ID is required.")]
        public int DoctorID { get; set; }
    }
}
