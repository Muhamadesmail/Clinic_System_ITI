using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Repo.Abstraction
{
    public interface IFeedBackRepository
    {
        //IEnumerable<FeedBack> GetAllFeedbacks();
        //FeedBack GetFeedbackById(int id);
        //void AddFeedback(FeedBack feedback);
        //void Save();

        Feedback Add(Feedback feedback);
        List<Feedback> GetAll();
        Feedback GetById(int id);
        bool Delete(Feedback feedback);
    }

}

