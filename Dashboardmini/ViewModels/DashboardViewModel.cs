namespace Dashboardmini.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalEmployees { get; set; }
        public int TotalLeaveRequests { get; set; }
        public int ApprovedLeaveRequests { get; set; }
        public int PendingLeaveRequests { get; set; }
        public int RejectedLeaveRequests { get; set; }
        public ICollection<LeaveRequestViewModel> LeaveRequests { get; set; } = new List<LeaveRequestViewModel>();

    }
}
