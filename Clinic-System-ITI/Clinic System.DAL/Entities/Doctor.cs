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
    public class Doctor 
    {
        public int DoctorID { get; set; }
        public Shift Shift { get; set; }
        //why has image 
        public string? Image {  get; set; }
        public int SessionPrice { get; set; }
        public string Description { get; set; }

        [ForeignKey("Department")]
        public int DeptID { get; set; }
        public Department? Department { get; set; }
        public List<Appointment> Appointments { get; set; }
        public User User { get; set; }
        

    }
}
