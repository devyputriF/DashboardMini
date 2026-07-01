using Dashboardmini.Data;
using Dashboardmini.Enums;
using Dashboardmini.Models;
using Dashboardmini.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

using Microsoft.AspNetCore.Identity;
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
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Roles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().Select(r => new SelectListItem
            {
                Text = r.ToString(),
                Value = r.ToString()
            });

            return View();
        }

        [HttpGet]
        public IActionResult Detail( int id)
        {
            var employee = _context.Employees.Include(e => e.Department)
       .FirstOrDefault(e => e.EmployeeId == id);
            //ViewBag.Roles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().Select(e => e.UserRole.id = employee.Role);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }



        [HttpPost]
        public IActionResult Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee
                {
                    FullName = employee.FullName,
                    EmployeeEmail = employee.EmployeeEmail,
                    DepartmentId = employee.Departmentid,
                    Role = (UserRole)Enum.Parse(typeof(UserRole), employee.Role),
                    IsActive = employee.IsActive,
                    CreatedDate = DateTime.Now
                };

                _context.Employees.Add(newEmployee);
                _context.SaveChanges(); 

                var newAccount = new User
                {
                    EmployeeId = newEmployee.EmployeeId, 
                    UserName = $"EMP{newEmployee.EmployeeId.ToString("D5")}",
                    UserRole = (UserRole)Enum.Parse(typeof(UserRole), employee.Role),
                    IsActive = employee.IsActive,
                    CreatedDate = DateTime.Now,
                    PasswordHash = Services.VerifyAccount.CreatePasswordHash("User1234!")
                };



                _context.Users.Add(newAccount);
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
        public IActionResult Edit(int id, EmployeeViewModel model)
        {

            if (ModelState.IsValid)
            {
                var department = _context.Employees.Find(id);
                if (department == null)
                {
                    return NotFound();
                }
                department.FullName = model.FullName;
                department.EmployeeEmail = model.EmployeeEmail;
                department.DepartmentId = model.Departmentid;
                department.Role = (UserRole)Enum.Parse(typeof(UserRole), model.Role);
                department.IsActive = bool.Parse(model.IsActive.ToString());
                department.UpdatedDate = DateTime.Now;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(model);
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
