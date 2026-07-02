using Dashboardmini.Enums;

namespace Dashboardmini.ViewModels
{
    public class LeaveRequestViewModel
    {
        public int LeaveRequestId { get; set; }
        public string EmployeeFullName { get; set; }
        public string LeaveType { get; set; }
        public LeaveStatus LeaveStatus { get; set; }

        public int TotalDays { get; set; }

        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
