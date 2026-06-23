namespace Dashboardmini.ViewModels
{
    public class LeaveRequestViewModel
    {
        public int LeaveRequestId { get; set; }
        public string EmployeeFullName { get; set; }
        public string LeaveType { get; set; }
        public string LeaveStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
