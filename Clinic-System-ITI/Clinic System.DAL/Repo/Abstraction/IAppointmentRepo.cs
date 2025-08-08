using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Repo.Abstraction
{
    public interface IAppointmentRepo
    {
        List<Appointment> GetAll();
        Appointment GetbyId(int id);
        bool Edit(Appointment appointment);
        bool Create(Appointment appointment);
        bool Delete(Appointment appointment);
        bool BookAppointment(Appointment appointment, int patientID);
        IEnumerable<Appointment> GetAppointmentsByDoctor(int doctorId);

    }
}
