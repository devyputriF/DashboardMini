using Dashboardmini.Data;
using Dashboardmini.Models;
using Dashboardmini.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Dashboardmini.Enums;
namespace Dashboardmini.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments = _context.Employees.Include(d => d.Department).ToList();
            return View(departments);

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Roles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().Select(r => new SelectListItem
            {
                Text = r.ToString(),
                Value = r.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee
                {
                    FullName = employee.FullName,
                    EmployeeEmail = employee.Email,
                    DepartmentId = employee.Departmentid,
                    Role = (UserRole)Enum.Parse(typeof(UserRole), employee.Role),
                    IsActive = employee.IsActive,
                    CreatedDate = DateTime.Now
                };
                _context.Employees.Add(newEmployee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _context.Departments.ToList();
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Roles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().Select(r => new SelectListItem
            {
                Text = r.ToString(),
                Value = r.ToString()
            });
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee
                {

                    FullName = employee.FullName,
                    EmployeeEmail = employee.EmployeeEmail,
                    DepartmentId = employee.DepartmentId,
                    Role = employee.Role,
                    IsActive = employee.IsActive,
                    UpdatedDate = DateTime.Now
                };
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
