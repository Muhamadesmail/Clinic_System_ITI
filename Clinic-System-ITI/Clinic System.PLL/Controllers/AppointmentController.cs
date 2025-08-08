using Clinic_System.BLL.ModelVM.AppointmentVM;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.BLL.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Clinic_System.PLL.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            var appointments = _appointmentService.GetAllAppointments();
            var doctors = _doctorService.GetAllDoctors();

            ViewBag.Appointments = appointments;
            ViewBag.Doctors = doctors;
            return View(new CreateAppointmentVM());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateAppointment(CreateAppointmentVM appointmentVM)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _appointmentService.Create(appointmentVM);
                if (isCreated)
                {
                    
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to create appointment");
            }
            ViewBag.Doctors = _doctorService.GetAllDoctors();
            ViewBag.Appointments = _appointmentService.GetAllAppointments();

            return View("Index", appointmentVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditAppointment(int id)
        {
            var appointmentVM = _appointmentService.GetAppointmentById(id);
            if (appointmentVM is null)
            {
                return RedirectToAction("Index");
            }
            var updateAppointmentVM = _appointmentService.ConvertToUpdateAppointmentVM(appointmentVM);
            ViewBag.Doctors = _doctorService.GetAllDoctors();
            return View(updateAppointmentVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditAppointment(UpdateAppointmentVM appointmentVM)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = _appointmentService.Edit(appointmentVM);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to update appointment");
            }
            ViewBag.Doctors = _doctorService.GetAllDoctors();
            return View(appointmentVM);
        }
        public string GetLoggedInUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        [Authorize]
        [HttpGet]
        public IActionResult BookAppointment(int appointmentId)
        {
            var appointment = _appointmentService.GetAppointmentById(appointmentId);
            if (appointment is null)
            {
                return RedirectToAction("Index", "Home");
            }

            var bookAppointmentVM = new BookAppointmentVM
            {
                AppointmentId = appointmentId,
                DoctorName = $"{appointment.DoctorName}",
                AppointmentTime = appointment.AppointmentDate,
                SessionPrice = appointment.Price,
            };

            return View(bookAppointmentVM);
        }
        [Authorize]
        [HttpPost]
        public IActionResult BookAppointment(BookAppointmentVM bookAppointmentVM)
        {
            var id = GetLoggedInUserId();
            var patientVM = _patientService.GetPatientById(id);
            var isBooked = _appointmentService.BookAppointment(bookAppointmentVM.AppointmentId, patientVM.PatientID);

            if (isBooked)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Profile", "Patient") });
            }
            else
            {
                return Json(new { success = false, message = "Failed to book appointment" });
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteAppointment(DeleteAppointmentVM deleteAppointmentVM)
        {
            var result = _appointmentService.Delete(deleteAppointmentVM);
            return Json(new { success = result });
        }
    }
}
