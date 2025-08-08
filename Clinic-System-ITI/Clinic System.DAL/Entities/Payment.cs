using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Entities
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public double Amount { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }

        [ForeignKey("Appointment")]
        public int? AppointmentID { get; set; }
    }
}
