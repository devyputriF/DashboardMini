namespace Dashboardmini.Models
{
    public class Employee
    {
        internal object department;

        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        public string EmployeeEmail { get; set; } = string.Empty;
        public int? ManagerId { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Employee? Manager { get; set; }
        public Department Department { get; set; } = null!;
        public User User { get; set; } = null!;
        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}
