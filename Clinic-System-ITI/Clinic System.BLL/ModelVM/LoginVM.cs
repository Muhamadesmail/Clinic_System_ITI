using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM
{
    public class LoginVM
    {
        [Required(ErrorMessage ="*")]
        public string UseName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me!!")]
        public bool RememberMe { get; set; }

        //third party login providers
        

    }
}
