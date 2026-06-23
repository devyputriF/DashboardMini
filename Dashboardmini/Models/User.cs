using Dashboardmini.Enums;
namespace Dashboardmini.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string UserName { get; set; }= string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
