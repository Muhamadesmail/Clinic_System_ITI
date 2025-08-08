using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Abstraction
{
    public interface IPatientService
    {
        List<GetAllPatientVM> GetAllPatients();
        GetPatientByIdVM GetPatientById(int id);
        bool Edit(EditPatientVM patientVM);
        bool Create(CreatePatientVM patientVM);
        bool Delete(DeletePatientVM patientVM);
        bool DeletePatientById(DeletePatientVM deletePatientVM);
        DeletePatientVM ConvertToDeletePatientVM(GetPatientByIdVM patientByIdVM);
        bool EditPatientEmail(EditPatientEmailVM editPatientEmailVM);
        GetPatientByIdVM GetPatientById(string id);
    }
}
