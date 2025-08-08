using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Clinic_System.BLL.Service.Implementation;

namespace Clinic_System.PLL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IDashBoardService _dashboardService;

        private readonly IDoctorService _doctorService;

        public AdminController(IDashBoardService dashboardService, IDoctorService doctorService)
        {
            _dashboardService = dashboardService;
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            var dashboardData = _dashboardService.GetDashboardData();
            return View(dashboardData);
        }

            public IActionResult ManageDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            return View("ManageDoctors", doctors);
        }
    }
    }

