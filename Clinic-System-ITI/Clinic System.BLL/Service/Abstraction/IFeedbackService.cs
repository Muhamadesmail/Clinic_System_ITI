using Clinic_System.BLL.ModelVM.FeedBackVM;
using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Abstraction
{
    public interface IFeedbackService
    {
        Feedback AddFeedback(AddFeedbackVM feedback);
        List<GetAllFeedbacksVM> GetAllFeedbacks();
    }
}
