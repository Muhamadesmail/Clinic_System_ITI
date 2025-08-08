using Clinic_System.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Entities
{
    public class Patient 
    {
        [Key]   
        public int PatientID { get; set; }
        public string Address { get; set; }
        public List<Appointment> Appointments { get; set; }
        [ForeignKey("ApplicationUser")]
        public User User { get; set; }
    }
}
