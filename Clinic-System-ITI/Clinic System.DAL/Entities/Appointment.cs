
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Entities
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        [Required]
        public bool Isbooked { get; set; }
        public bool IsDeleted { get; set; } = false;

        //Navigation Property
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Patient")]
        public int? PatientID { get; set; }
        public Patient Patient { get; set; }
        public List<Payment> payments { get; set; }

    }
}
