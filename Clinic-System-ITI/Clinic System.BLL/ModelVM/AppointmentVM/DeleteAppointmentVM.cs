using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.AppointmentVM
{
    public class DeleteAppointmentVM
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
