using AutoMapper;
using Clinic_System.BLL.ModelVM.Appointment;
using Clinic_System.BLL.ModelVM.AppointmentVM;
using Clinic_System.BLL.ModelVM.DepartmentVM;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.ModelVM.FeedBackVM;
using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.BLL.ModelVM.PaymentVM;
using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {

            //From Entity To VM(Retreive)

            CreateMap<Doctor, DoctorVM>();
            CreateMap<Appointment, AppointmentVM>();
            CreateMap<Patient, GetAllPatientVM>().ConstructUsing(patient => new GetAllPatientVM(patient));
            CreateMap<Patient, GetPatientByIdVM>().ConstructUsing(patient => new GetPatientByIdVM(patient));
            CreateMap<Department, GetAllDepartmentsVM>().ReverseMap();
            CreateMap<Department, GetDepartmentByIdVM>().ReverseMap();
            CreateMap<CreateDepartmentVM, Department>().ReverseMap();
            CreateMap<EditDepartmentVM, Department>().ReverseMap();
            CreateMap<DeleteDepartmentVM, Department>().ReverseMap();
            CreateMap<Feedback, GetAllFeedbacksVM>().ReverseMap();
            CreateMap<AddFeedbackVM, Feedback>().ReverseMap();
            CreateMap<Doctor, GetAllDoctorsVM>().ConstructUsing(doctor => new GetAllDoctorsVM(doctor));
            CreateMap<Doctor, GetDoctorByIdVM>().ConstructUsing(doctor => new GetDoctorByIdVM(doctor));
            CreateMap<GetDoctorByIdVM, UpdateDoctorVM>();
            CreateMap<GetDepartmentByIdVM, Department>().ReverseMap();
            CreateMap<GetDepartmentByIdVM, EditDepartmentVM>().ReverseMap();
            CreateMap<GetPatientByIdVM, DeletePatientVM>();
            CreateMap<Appointment, CreateAppointmentVM>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentVM>().ReverseMap();
            CreateMap<DeleteAppointmentVM, Appointment>().ReverseMap();
            CreateMap<DeleteDepartmentVM, Department>();
            CreateMap<Patient, DeletePatientVM>();

            CreateMap<DeletePatientVM, Patient>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Age = src.Age,
                    Gender = src.Gender,
                    Email = src.Email,
                    Image = src.Image,
                    IsDeleted=src.IsDeleted
                }));

            CreateMap<DeleteDoctorVM, Doctor>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Age = src.Age,
                    Gender = src.Gender,
                    Email = src.Email,
                    Image = src.Image,
                    IsDeleted = src.IsDeleted
                }));

            CreateMap<CreateDoctorVM, Doctor>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Age = src.Age,
                    Gender = src.Gender,
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email,
                    Image = src.Image
                })).ForMember(dest => dest.DeptID, opt => opt.MapFrom(src => src.DepartmentID));


            CreateMap<UpdateDoctorVM, Doctor>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Age = src.Age,
                    Gender = src.Gender,
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email,
                    Image = src.Image
                })).ForMember(dest => dest.DeptID, opt => opt.MapFrom(src => src.DepartmentID));

            CreateMap<Appointment, GetAllAppointmentsVM>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.User.FirstName + " " + src.Doctor.User.LastName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Doctor.SessionPrice))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Doctor.Department.Name));

            CreateMap<Appointment, GetAppointmentByIdVM>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.User.FirstName + " " + src.Doctor.User.LastName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Doctor.SessionPrice))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Doctor.Department.Name));
            CreateMap<GetAppointmentByIdVM, UpdateAppointmentVM>();
            CreateMap<Payment, PatientAppointmentPaymentVM>();
            CreateMap<Appointment, GetAppointmentsByPatientIdVM>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.User.FirstName + " " + src.Doctor.User.LastName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Doctor.SessionPrice))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Doctor.Department.Name))
                .ForMember(dest => dest.PaidAmount, opt => opt.MapFrom(src => src.payments.FirstOrDefault().Amount));
        }
    }
}
