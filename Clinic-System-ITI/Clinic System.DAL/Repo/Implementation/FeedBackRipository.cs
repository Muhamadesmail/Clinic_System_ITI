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
    public class FeedBackRipository : IFeedBackRepository
    {
        private readonly ApplicationDbContext _db;

        public FeedBackRipository(ApplicationDbContext applicationDb)
        {
            _db = applicationDb;
        }


        public Feedback Add(Feedback feedback)
        {
            _db.Feedbacks.Add(feedback);
            _db.SaveChanges();
            return feedback; // رجع الـ feedback اللي اتسجل
        }
        public List<Feedback> GetAll()
        {
            return _db.Feedbacks.ToList();
        }
        public Feedback GetById(int id)
        {
            return _db.Feedbacks.FirstOrDefault(f => f.ID == id);
        }
        

        public bool Delete(Feedback feedback)
        {
            try
            {
                var data = _db.Feedbacks.FirstOrDefault(f => f.ID == feedback.ID);
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



        //public IEnumerable<FeedBack> GetAllFeedbacks()
        //{
        //    return _context.FeedBacks.ToList();
        //}

        //public FeedBack GetFeedbackById(int id)
        //{
        //    return _context.FeedBacks.Find(id);
        //}

        //public void AddFeedback(FeedBack feedback)
        //{
        //    try
        //    {
        //        _context.FeedBacks.Add(feedback);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        // هنا يمكنك طباعة الرسالة للتأكد من المشكلة
        //        throw new Exception("Error saving feedback: " + ex.Message);
        //    }
        //}


        //public void Save()
        //{
        //    _context.SaveChanges();
        //}
    }

}

