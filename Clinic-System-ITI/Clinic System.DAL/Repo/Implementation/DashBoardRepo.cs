using Clinic_System.DAL.Database;
using Clinic_System.DAL.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Clinic_System.DAL.Repo.Implementation
{
    public class DashboardRepo : IDashboardRepo
    {

        private readonly ApplicationDbContext _db;

        public DashboardRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public int GetPatientCount()
        {
            return _db.Patients.Count();
        }

        public int GetAppointmentCount()
        {
            return _db.Appointments.Count();
        }

        public decimal GetTotalEarnings()
        {
            return _db.Appointments.Include(a => a.Doctor).Where(a => a.Isbooked).Sum( a => a.Doctor.SessionPrice); 
        }

        public int GetDepartmentCount()
        {
            return _db.Departments.Count();
        }
        public List<(string DepartmentName, int AppointmentCount)> GetAppointmentsByDepartment()
        {
            return _db.Departments
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    AppointmentCount = d.Appointments.Count()
                })
                .AsEnumerable()
                .Select(x => (x.DepartmentName, x.AppointmentCount))
                .ToList();
        }

        //public List<DepartmentAppointmentsVM> GetAppointmentsByDepartment()
        //{
        //    return _db.Departments
        //        .Select(d => new DepartmentAppointmentsVM
        //        {
        //            DepartmentName = d.Name,
        //            AppointmentCount = d.Appointments.Count()
        //        }).ToList();
        //}
    }

}
