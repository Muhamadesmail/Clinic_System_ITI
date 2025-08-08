using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.DepartmentVM
{
    public class DeleteDepartmentVM
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
