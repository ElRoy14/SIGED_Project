using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.Application.DashBoard.Interface;

namespace Siged.API.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly IDashBoardService _dashBoardService;

        public DashBoardController(IDashBoardService dashBoardService)
        {
            _dashBoardService = dashBoardService;
        }

        public IActionResult Index()
        {

            #region Actividades
                ViewBag.TotalTasks = _dashBoardService.GetTotalTasksAsync().Result;

                ViewBag.PendingTasks = _dashBoardService.GetPendingTasksAsync().Result;

                ViewBag.DoneTasks = _dashBoardService.GetDoneTasksAsync().Result;
            #endregion

            #region Usuarios
            ViewBag.TotalUsers = _dashBoardService.GetTotalUsersAsync().Result;

            ViewBag.EmployeeUsers = _dashBoardService.GetEmployeeUsersAsync().Result;

            ViewBag.ManagerUsers = _dashBoardService.GetManagerUsersAsync().Result;

            ViewBag.SupervisorUsers = _dashBoardService.GetSupervisorUsersAsync().Result;

            ViewBag.RRHHUsers = _dashBoardService.GetRRHHUsersAsync().Result;

            ViewBag.SuperAdminUsers = _dashBoardService.GetSuperAdminUsersAsync().Result;

            #endregion

            #region Clientes
            ViewBag.TotalCustomers = _dashBoardService.GetTotalCustomersAsync().Result;
            #endregion

            #region Suplidores
            ViewBag.TotalSuppliers = _dashBoardService.GetTotalSuppliersAsync().Result;
            #endregion

            #region Facturas

            #endregion

            return View();
        }
    }
}
