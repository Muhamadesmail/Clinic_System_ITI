using AutoMapper;
using Clinic_System.BLL.ModelVM.Appointment;
using Clinic_System.BLL.ModelVM.AppointmentVM;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using Clinic_System.DAL.Repo.Implementation;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Implementation
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IDoctorRepo _doctorRepo; 
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepo appointmentRepo, IDoctorRepo doctorRepo, IMapper mapper)
        {
            _appointmentRepo = appointmentRepo;
            _doctorRepo = doctorRepo;
            _mapper = mapper;
        }
        
        public IEnumerable<AppointmentVM> GetAppointmentsByDoctor(int doctorId)
        {
            var appointments = _appointmentRepo.GetAppointmentsByDoctor(doctorId);
            return _mapper.Map<IEnumerable<AppointmentVM>>(appointments);
         }

        public bool Create(CreateAppointmentVM appointmentVM)
        {
            if (appointmentVM is not null)
            {
                var appointmentEntity = _mapper.Map<Appointment>(appointmentVM);
                var doctor = _doctorRepo.GetById(appointmentVM.DoctorID);
                if (doctor is not null)
                {
                    appointmentEntity.DepartmentID = doctor.DeptID;
                }
                return _appointmentRepo.Create(appointmentEntity);
            }
            return false;
        }

        public bool Edit(UpdateAppointmentVM appointmentVM)
        {
            if (appointmentVM is not null)
            {
                var appointmentEntity = _mapper.Map<Appointment>(appointmentVM);
                return _appointmentRepo.Edit(appointmentEntity);
            }
            return false;
        }

        public bool BookAppointment(int appointmentId, int patientId)
        {
            var appointment = _appointmentRepo.GetbyId(appointmentId);
            if (appointment is not null)
            {
                appointment.Isbooked = true;
                appointment.PatientID = patientId;
                return _appointmentRepo.BookAppointment(appointment, patientId);
            }
            return false;
        }

        public List<GetAllAppointmentsVM> GetAllAppointments()
        {
            var appointments = _appointmentRepo.GetAll();
            return _mapper.Map<List<GetAllAppointmentsVM>>(appointments);
        }

        public GetAppointmentByIdVM GetAppointmentById(int id)
        {
            var appointment = _appointmentRepo.GetbyId(id);
            return _mapper.Map<GetAppointmentByIdVM>(appointment);
        }

        public UpdateAppointmentVM ConvertToUpdateAppointmentVM(GetAppointmentByIdVM appointmentByIdVM)
        {
            return _mapper.Map<UpdateAppointmentVM>(appointmentByIdVM);
        }
        public bool Delete(DeleteAppointmentVM deleteAppointmentVM)
        {
            if (deleteAppointmentVM is not null)
            {
                var appointment = _mapper.Map<Appointment>(deleteAppointmentVM);
                return _appointmentRepo.Delete(appointment);
            }
            return false;
        }

        public IEnumerable<GetAppointmentsByPatientIdVM> GetAppointmentsByPatientId(int id)
        {
            var appointments = _appointmentRepo.GetAll().Where(a => a.PatientID == id);
            var appointmentsVM = _mapper.Map<IEnumerable<GetAppointmentsByPatientIdVM>>(appointments);
            return appointmentsVM;
        }
    }
}
