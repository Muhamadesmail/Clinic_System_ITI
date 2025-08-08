using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Repo.Abstraction
{
    public interface IDashboardRepo
    {
        int GetPatientCount();
        int GetAppointmentCount();
        decimal GetTotalEarnings();
        int GetDepartmentCount();
        List<(string DepartmentName, int AppointmentCount)> GetAppointmentsByDepartment();
    }

}
