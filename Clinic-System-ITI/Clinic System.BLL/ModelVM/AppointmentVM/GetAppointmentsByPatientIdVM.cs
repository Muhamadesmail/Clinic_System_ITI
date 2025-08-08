using Clinic_System.BLL.ModelVM.PaymentVM;
using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.AppointmentVM
{
    public class GetAppointmentsByPatientIdVM
    {
        public int ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public decimal Price { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
