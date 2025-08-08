using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM
{
    public class RoleVM
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
