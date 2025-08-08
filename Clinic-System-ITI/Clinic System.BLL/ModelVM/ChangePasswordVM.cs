using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM
{
    public class ChangePasswordVM
    {

        [Required(ErrorMessage = "*"),  DataType(DataType.Password), Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "*"), DataType(DataType.Password), Display(Name = "New Password")]
        public string NewPassword { get; set; }


        [Required (ErrorMessage ="Password Not Same"), Compare("NewPassword"),DataType(DataType.Password),Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
