using Clinic_System.DAL.Database;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Repo.Implementation
{
    public class PaymentRepo:IPaymentRepo
    {
        private readonly ApplicationDbContext _db;
        public PaymentRepo(ApplicationDbContext applicationDb)
        {
            _db = applicationDb;
        }
        public bool Create(Payment payment)
        {
            try
            {
                _db.Payments.Add(payment);
                _db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Payment payment)
        {
            try
            {
                var data = _db.Payments.Where(a => a.ID == payment.ID).FirstOrDefault();
                if (data is not null)
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

        public bool Edit(Payment payment)
        {
            try
            {
                var existingPayment = _db.Payments.Where(a => a.ID == payment.ID).FirstOrDefault();

                if (existingPayment is not null)
                {
                    existingPayment.Amount = payment.Amount;
                    existingPayment.Date = payment.Date;
                    existingPayment.IsDeleted = payment.IsDeleted;
                    

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

        public List<Payment> GetAll()
        {
            return _db.Payments.ToList();
        }

        public Payment GetbyId(int id)
        {
            return _db.Payments.Where(a => a.ID == id).FirstOrDefault();
        }
    }
}
