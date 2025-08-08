using AutoMapper;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.ModelVM.FeedBackVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using Clinic_System.DAL.Repo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Implementation
{
    public class FeedbackService:IFeedbackService
    {
        private readonly IFeedBackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedBackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }
       


        public Feedback AddFeedback(AddFeedbackVM feedbackVM)
        {
            var feedback =_mapper.Map<Feedback>(feedbackVM);
            return _feedbackRepository.Add(feedback);
        }

        public List<GetAllFeedbacksVM> GetAllFeedbacks()
        { 
            var feedbacks=_feedbackRepository.GetAll();
            var feedbackVMs=_mapper.Map<List<GetAllFeedbacksVM>>(feedbacks);
            return feedbackVMs;
        }
       


    }
}
