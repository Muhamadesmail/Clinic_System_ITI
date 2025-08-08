using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM
{
    public class ForgetPasswordMV
    {
        [Required ,EmailAddress,Display(Name ="Registered Email Address")]
        
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
