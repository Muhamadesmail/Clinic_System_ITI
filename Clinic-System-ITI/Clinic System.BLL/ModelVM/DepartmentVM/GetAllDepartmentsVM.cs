using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.DepartmentVM
{
    public class GetAllDepartmentsVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string PhoneNumber { get; set; }
    }
}
