using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.Appointment
{
    public class SearchVM
    {
        public int? DepartmentId { get; set; }
        public string DoctorName { get; set; }
        public User User { get; set; }  // إضافة المستخدم للـ ViewModel

        public List<Department> Departments { get; set; } 
        public List<DoctorVM> Doctors { get; set; }
    }
}
