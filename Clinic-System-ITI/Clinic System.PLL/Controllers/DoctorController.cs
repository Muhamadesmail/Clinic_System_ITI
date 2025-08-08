using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.BLL.Service.Implementation;
using Clinic_System.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace Clinic_System.PLL.Controllers
{
   
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IDepartmentService _departmentService;

        public DoctorController(IDoctorService doctorService, IDepartmentService departmentService)
        {
            _doctorService = doctorService;
            _departmentService = departmentService;
        }
        [Authorize(Roles = "Admin")]
        [Authorize]
        public IActionResult Index()
        {
            var doctors = _doctorService.GetAllDoctors();
            return View("GetAllDoctors", doctors);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateDoctor()
        {
            var departments = _departmentService.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "ID", "Name");
            return View(new CreateDoctorVM());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateDoctor(CreateDoctorVM doctorVM)
        {
            var departments = _departmentService.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "ID", "Name");

            if (ModelState.IsValid)
            {
                var isCreated = _doctorService.Create(doctorVM);
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to create doctor");
            }
            return View(doctorVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditDoctor(int id)
        {
            var departments = _departmentService.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "ID", "Name");
            var doctorVM = _doctorService.GetDoctorById(id); 
            if (doctorVM is null)
            {
                return RedirectToAction("Index");
            }
            var updateDoctorVM = _doctorService.ConvertToUpdateDoctorVM(doctorVM);
            return View(updateDoctorVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditDoctor(UpdateDoctorVM doctorVM)
        {
            var departments = _departmentService.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "ID", "Name");
            if (ModelState.IsValid)
            {
                var isUpdated = _doctorService.Edit(doctorVM);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to update doctor");
            }
            return View(doctorVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteDoctor(DeleteDoctorVM deleteDoctorVM)
        {
            var result = _doctorService.Delete(deleteDoctorVM); 
            return Json(new { success = result });
        }
    }
}
