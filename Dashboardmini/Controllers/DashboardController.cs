using Microsoft.AspNetCore.Mvc;
using Dashboardmini.ViewModels;
namespace Dashboardmini.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalEmployees = 100,
                TotalLeaveRequests = 50,
                ApprovedLeaveRequests = 30,
                PendingLeaveRequests = 15,
                RejectedLeaveRequests = 5,
                LeaveRequests = new List<LeaveRequestViewModel>
                {
                    new LeaveRequestViewModel { LeaveRequestId = 1, EmployeeFullName = "John Doe", LeaveType = "Vacation", LeaveStatus = "Approved", CreatedDate = DateTime.Now.AddDays(-5) },
                    new LeaveRequestViewModel { LeaveRequestId = 2, EmployeeFullName = "Jane Smith", LeaveType = "Sick Leave", LeaveStatus = "Pending", CreatedDate = DateTime.Now.AddDays(-3) },
                    new LeaveRequestViewModel { LeaveRequestId = 3, EmployeeFullName = "Bob Johnson", LeaveType = "Personal Day", LeaveStatus = "Rejected", CreatedDate = DateTime.Now.AddDays(-7) }
                }

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Index(DashboardViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the form submission and update the model as needed
                // For example, you can save the data to a database or perform other actions
                // Redirect to a success page or return a success message
                return RedirectToAction("Success");
            }
            // If the model is not valid, return the view with validation errors
            return View(model);
        }


    }
}
