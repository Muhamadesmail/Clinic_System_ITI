using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.DashBoardVM
{
    public class DashboardVM
    {
        public int PatientCount { get; set; }
        public int AppointmentCount { get; set; }
        public decimal TotalEarnings { get; set; }
        public int DepartmentCount { get; set; }
        public List<DepartmentAppointmentsVM> AppointmentsByDepartment { get; set; }
    }
}