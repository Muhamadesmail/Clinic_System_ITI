using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.AppointmentVM
{
    public class GetAppointmentByIdVM
    {
        public int ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public bool Isbooked { get; set; }
        public bool IsDeleted { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public int DeptID { get; set; }
        public int? PatientID { get; set; }
        public decimal Price { get; set; }
    }
}
