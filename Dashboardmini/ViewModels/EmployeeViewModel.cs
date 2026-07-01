namespace Dashboardmini.ViewModels
{
    public class EmployeeViewModel
    {
        public int Employeid { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string EmployeeEmail { get; set; } = string.Empty;

        public int Departmentid { get; set; }
        public string Role { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
