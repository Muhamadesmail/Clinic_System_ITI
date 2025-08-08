using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.Appointment
{
    public class DoctorVM
    {
        public int DoctorID { get; set; }
        public string Shift { get; set; }
        public string? Image { get; set; }
        public int SessionPrice { get; set; }
        public string Description { get; set; }
        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
        public User User { get; set; }
        public IEnumerable<AppointmentVM> Appointments { get; set; }

    }
}
