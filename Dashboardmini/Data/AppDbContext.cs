using Dashboardmini.Models;
using Microsoft.EntityFrameworkCore;
namespace Dashboardmini.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<User> Users { get; set; }



}


