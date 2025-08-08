using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.AppointmentVM
{
    public class BookAppointmentVM
    {
        public int AppointmentId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentTime { get; set; }
        public decimal SessionPrice { get; set; }
    }
}
