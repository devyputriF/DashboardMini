namespace Dashboardmini.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }

        public int CountEmployees { get; set; } = 0;

    }
}
