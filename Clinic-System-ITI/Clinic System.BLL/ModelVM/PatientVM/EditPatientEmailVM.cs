using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.PatientVM
{
    public class EditPatientEmailVM
    {
        public int PatientID { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string NewEmail { get; set; }
    }
}
