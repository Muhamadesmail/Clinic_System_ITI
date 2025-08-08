using Clinic_System.BLL.Service.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_System.PLL.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;


        
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;

                
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var feedbacks=_feedbackService.GetAllFeedbacks();
            return View("GetAllFeedbacks",feedbacks);
        }
        
       
    }
}
