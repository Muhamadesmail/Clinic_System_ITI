using Clinic_System.BLL.ModelVM.DashBoardVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Repo.Abstraction;
using Clinic_System.DAL.Repo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Implementation
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IDashboardRepo _dashboardRepo;

        public DashBoardService(IDashboardRepo dashboardRepository)
        {
            _dashboardRepo = dashboardRepository;
        }
    public DashboardVM GetDashboardData()
    {
        var dashboardVM = new DashboardVM
        {
            PatientCount = _dashboardRepo.GetPatientCount(),
            AppointmentCount = _dashboardRepo.GetAppointmentCount(),
            TotalEarnings = _dashboardRepo.GetTotalEarnings(),
            DepartmentCount = _dashboardRepo.GetDepartmentCount(),
            AppointmentsByDepartment = _dashboardRepo.GetAppointmentsByDepartment()
                .Select(d => new DepartmentAppointmentsVM 
                {
                    DepartmentName = d.DepartmentName,
                    AppointmentCount = d.AppointmentCount
                })
                .ToList()
        };

        return dashboardVM;
    }
    }

}
