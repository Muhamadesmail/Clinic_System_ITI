using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.PatientVM
{
    public class DeletePatientProfileVM
    {
        public int PatientID { get; set; }
        [Required(ErrorMessage = "Delete confirmation is required.")]
        [RegularExpression(@"^delete$", ErrorMessage = "Delete confirmation must be \"delete\" (case-insensitive).")]
        public string DeleteConfirmation { get; set; }
    }
}
