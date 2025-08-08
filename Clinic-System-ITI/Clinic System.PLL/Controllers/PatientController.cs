using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.BLL.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic_System.PLL.Controllers
{

    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public PatientController(IPatientService patientService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _appointmentService = appointmentService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var patients = _patientService.GetAllPatients();
            return View("GetAllPatients",patients);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeletePatient(int id)
        {
            var PatientVM = _patientService.GetPatientById(id);
            if (PatientVM is null)
            {
                return RedirectToAction("Index");
            }
            var deletePatientVM = _patientService.ConvertToDeletePatientVM(PatientVM);
            return View(deletePatientVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeletePatient(DeletePatientVM deletePatientVM)
        {
            var result = _patientService.Delete(deletePatientVM);
            return Json(new { success = result });
        }

        public string GetLoggedInUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        //after log in redirect here .... not direct access
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var id = GetLoggedInUserId();
            var patientVM = _patientService.GetPatientById(id);
            ViewData["PatientAppointments"] = _appointmentService.GetAppointmentsByPatientId(patientVM.PatientID);
            return View(patientVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmail(EditPatientEmailVM model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var error in ViewData.ModelState.Values.SelectMany(v => v.Errors))
                {
                    errors.Add(error.ErrorMessage);
                }
                TempData["ErrorMessage"] = errors;
                return RedirectToAction("Profile");
            }

            var result = _patientService.EditPatientEmail(model);

            if (result)
            {
                TempData["SuccessMessage"] = "Email updated successfully";
            }
            else
            {
                TempData["ErrorMessage"] = new List<string> { "Failed to update email" };
            }

            return RedirectToAction("Profile");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePatientProfile(DeletePatientProfileVM model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var error in ViewData.ModelState.Values.SelectMany(v => v.Errors))
                {
                    errors.Add(error.ErrorMessage);
                }
                TempData["ErrorMessage"] = errors;
                return RedirectToAction("Profile");
            }
            var patientVM = _patientService.GetPatientById(model.PatientID);
            var deletePatientVM = _patientService.ConvertToDeletePatientVM(patientVM);
            var result = _patientService.DeletePatientById(deletePatientVM);

            if (result)
            {
                TempData["SuccessMessage"] = "Account deleted successfully";
                return RedirectToAction("Logout", "Account");
            }
            else
            {
                TempData["ErrorMessage"] = new List<string> { "Failed to delete account" };
                return RedirectToAction("Profile");
            }
        }
        //[HttpGet]
        //public IActionResult GetPatientId()
        //{
        //    var id = GetLoggedInUserId();
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return Json(new { success = false, message = "User not logged in." });
        //    }

        //    var patientVM = _patientService.GetPatientById(id);
        //    if (patientVM == null)
        //    {
        //        return Json(new { success = false, message = "Patient not found." });
        //    }

        //    return Json(new { success = true, patient = patientVM }); 
        //}

    }
}
