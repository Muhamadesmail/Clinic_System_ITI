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
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepo(ApplicationDbContext applicationDb)
        {
            _db = applicationDb;
        }
        public bool Create (Department department) 
        {
            try
            {
                _db.Departments.Add(department);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Department department)
        {
            try 
            {
                var exsitingDept = _db.Departments.FirstOrDefault(d => d.ID == department.ID);
                if (department!=null)
                {
                    exsitingDept.Name = department.Name;
                    exsitingDept.PhoneNumber = department.PhoneNumber;
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

        public bool Delete(Department department)
        {
            try
            {
                var data = _db.Departments.FirstOrDefault(d => d.ID == department.ID);
                if (data != null)
                {
                    data.IsDeleted = !data.IsDeleted;
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
        public List<Department> GetAll()
        {
            return _db.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return _db.Departments.FirstOrDefault(d => d.ID == id);
        }

    }
}
