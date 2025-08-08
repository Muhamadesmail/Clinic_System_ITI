using Clinic_System.BLL.ModelVM.FeedBackVM;
using Clinic_System.BLL.Service.Abstraction;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Clinic_System.DAL.Entities;
using Clinic_System.BLL.ModelVM.Appointment;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFeedbackService _feedbackService;
    private readonly IEmailSender emailSender;
    private readonly IDoctorService _doctorService; 
    private readonly IDepartmentService _departmentService;
    private readonly IAppointmentService _appointmentService;
    private readonly IMapper _mapper;



    public HomeController(ILogger<HomeController> logger, IFeedbackService feedbackService,IEmailSender emailSender, IAppointmentService appointmentService, IDoctorService doctorService, IDepartmentService departmentService , IMapper mapper)
    {
        _logger = logger;
        _feedbackService = feedbackService;
        this.emailSender = emailSender;
        _doctorService = doctorService; 
        _departmentService = departmentService;
        _appointmentService = appointmentService;
        _mapper = mapper;

    }

    public IActionResult Index()
    {
        var departments = _departmentService.GetDepartments(); 
        ViewBag.Departments = new SelectList(departments, "ID", "Name"); 
        return View();
    }

    [HttpGet]
    public IActionResult Search()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Search(SearchVM model)
    {
        var departments = _departmentService.GetDepartments();
        ViewBag.Departments = new SelectList(departments, "ID", "Name");

        List<DoctorVM> doctors;

        if (model.DepartmentId.HasValue && !string.IsNullOrEmpty(model.DoctorName))
        {
            doctors = _doctorService.SearchDoctorsByName(model.DoctorName);
        }
        else if (model.DepartmentId.HasValue)
        {
            doctors = _doctorService.GetDoctorsByDepartment(model.DepartmentId.Value);
        }
        else if (!string.IsNullOrEmpty(model.DoctorName))
        {
            doctors = _doctorService.SearchDoctorsByName(model.DoctorName);
        }
        else
        {
            doctors = _doctorService.GetDoctors().ToList();
        }

        foreach (var doctor in doctors)
        {
            var appointments = _appointmentService.GetAppointmentsByDoctor(doctor.DoctorID);
            doctor.Appointments = appointments.ToList();  
        }

        model.Doctors = doctors;

        return View(model);
    }


    [HttpGet]
    public IActionResult FeedBack()
    {
        return View();
    }
   /// [Authorize]
    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> Feedback(string Name, string Email, string Content)
    {
        var feedback = new AddFeedbackVM
        {
            Name = Name,
            Email = Email,
            Content = Content
        };

        var addedFeedback = _feedbackService.AddFeedback(feedback);

        if (addedFeedback != null)
        {
            string adminEmail = "eldeeba124@gmail.com"; // Replace with your admin email
            string subject = $"New Feedback from {feedback.Email}";
            string message = $"Feedback message: {feedback.Content}";

            await emailSender.SendEmailAsync(adminEmail, subject, message);

            // Return a JSON success response
            return Json(new { success = true, message = "Feedback sent successfully!" });
        }
        else
        {
            return Json(new { success = false, message = "An error occurred while submitting feedback." });
        }
    }


    [HttpPost]
    public IActionResult BookAppointment(int appointmentId, int patientId)
    {
        var result = _appointmentService.BookAppointment(appointmentId, patientId);
        if (result)
        {
            return Ok(new { success = true });
        }
        return BadRequest(new { success = false, message = "Failed to book appointment." });
    }

}