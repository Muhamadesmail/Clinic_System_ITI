using Clinic_System.BLL.ModelVM.Appointment;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.DAL.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Abstraction
{
    public interface IDoctorService
    {
        
        // conflict
        List<DoctorVM> GetDoctors();
        List<GetAllDoctorsVM> GetAllDoctors();
      
         List<DoctorVM> GetDoctorsByDepartment(int departmentId);
        List<DoctorVM> SearchDoctorsByName(string doctorName);
        bool Create(CreateDoctorVM doctor);
        bool Edit(UpdateDoctorVM doctor);
        GetDoctorByIdVM GetDoctorById(int id);
        UpdateDoctorVM ConvertToUpdateDoctorVM(GetDoctorByIdVM doctorByIdVM);
        bool Delete(DeleteDoctorVM doctorVM);
    }
}
