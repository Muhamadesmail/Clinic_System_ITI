using AutoMapper;
using Clinic_System.BLL.ModelVM.AppointmentVM;
using Clinic_System.BLL.ModelVM.DepartmentVM;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using Clinic_System.DAL.Repo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
    private readonly IDepartmentRepo _departmentRepo;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepo departmentRepo, IMapper mapper)
    {
        _departmentRepo = departmentRepo;
        _mapper = mapper;
    }
         public List<Department> GetDepartments()
        {
            return _departmentRepo.GetAll().ToList();
        }

        public List<GetAllDepartmentsVM> GetAllDepartments()
        {
            var Result = _departmentRepo.GetAll().ToList();
            var NewData = _mapper.Map<List<GetAllDepartmentsVM>>(Result);
            return NewData;
        }
        public bool Create(CreateDepartmentVM departmentVM)
        {
            var Result = _mapper.Map<Department>(departmentVM);
            return _departmentRepo.Create(Result);
        }
        public bool Edit(EditDepartmentVM departmentVM)
        {
            var department = _mapper.Map<Department>(departmentVM);
            return _departmentRepo.Edit(department);
        }
        public bool Delete(DeleteDepartmentVM deleteDepartmentVM)
        {
            if (deleteDepartmentVM is not null)
            {
                var department = _mapper.Map<Department>(deleteDepartmentVM);
                return _departmentRepo.Delete(department);
            }
            return false;
        }

        public GetDepartmentByIdVM GetById(int id)
        {
            var department = _departmentRepo.GetById(id);
            return _mapper.Map<GetDepartmentByIdVM>(department);
        }
        public EditDepartmentVM ConvertToUpdateDepartmentVM(GetDepartmentByIdVM getDepartmentById)
        {
            return _mapper.Map<EditDepartmentVM>(getDepartmentById);
        }
    }
}
