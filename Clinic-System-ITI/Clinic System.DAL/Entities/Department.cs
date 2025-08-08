using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Entities
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? PhoneNumber { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List <Appointment> Appointments { get; set; }
    }
}
