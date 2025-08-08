using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.Appointment
{
    public class AppointmentVM
    {
        public int ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public bool IsBooked { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
