using Clinic_System.DAL.Database;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Repo.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _db;
        public PatientRepo(ApplicationDbContext applicationDb)
        {
            _db = applicationDb;   
        }
        public bool Create(Patient patient)
        {
            try
            {
                _db.Patients.Add(patient);
                _db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Patient patient)
        {
            try
            {
                var data = _db.Patients.Include(p => p.User)
                                                      .FirstOrDefault(p => p.PatientID == patient.PatientID);
                if (data is not null)
                {
                    data.User.IsDeleted = !data.User.IsDeleted;
                    _db.SaveChanges();
                    return true; 
                }
                return false;
            }
            catch
            {
                return false;

            }
        }

        public bool Edit(Patient patient)
        {
            try
            {
                var existingPatient = _db.Patients.Include(p => p.User)
                                                      .FirstOrDefault(p => p.PatientID == patient.PatientID);

                if (existingPatient is not null)
                {
                    existingPatient.Address = patient.Address;
                    existingPatient.User.FirstName = patient.User.FirstName;
                    existingPatient.User.LastName = patient.User.LastName;
                    existingPatient.User.Age = patient.User.Age;
                    existingPatient.User.Gender = patient.User.Gender;
                    existingPatient.User.PhoneNumber = patient.User.PhoneNumber;
                    existingPatient.User.Email = patient.User.Email;
                    _db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<Patient> GetAll()
        {
            return _db.Patients.Include(p => p.User).ToList();
        }

        public Patient GetById(int id)
        {
            return _db.Patients.Include(p => p.User).FirstOrDefault(p => p.PatientID == id);
        }

        public Patient GetById(string id)
        {
            return _db.Patients.Include(p => p.User).FirstOrDefault(p => p.User.Id == id);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
