using Clinic_System.BLL.ModelVM.DepartmentVM;
using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Abstraction
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        List<GetAllDepartmentsVM> GetAllDepartments();
        bool Create(CreateDepartmentVM departmentVM);
        bool Edit(EditDepartmentVM departmentVM);
        bool Delete(DeleteDepartmentVM departmentVM);
        public GetDepartmentByIdVM GetById(int id);
        EditDepartmentVM ConvertToUpdateDepartmentVM(GetDepartmentByIdVM getDepartmentById);
    }
}
