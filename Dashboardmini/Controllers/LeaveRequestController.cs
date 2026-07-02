using Dashboardmini.Data;
using Dashboardmini.Enums;
using Dashboardmini.Models;
using Dashboardmini.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dashboardmini.Controllers
{
    public class LeaveRequestController : Controller
    {
        private readonly AppDbContext _context;

        public LeaveRequestController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.LeaveRequests.Select(x => new LeaveRequestViewModel
            {
                LeaveRequestId = x.LeaveRequestId,
                LeaveType = x.Reason,
                LeaveStatus = x.LeaveStatus,
                CreatedDate = x.CreatedDate,
                EndDate = x.EndDate,
                TotalDays = x.StartDate != null && x.EndDate != null ? (x.EndDate - x.StartDate).Days : 0,
            })
        .ToList();

            return View(data);
        }
    }
}
