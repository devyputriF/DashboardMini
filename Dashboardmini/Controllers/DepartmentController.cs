using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dashboardmini.Data;
using Dashboardmini.ViewModels;
using Dashboardmini.Models;

namespace Dashboardmini.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments = _context.Departments.Select(d => new DepartmentViewModel
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                Status = d.IsActive ? "Active" : "Inactive",
                CountEmployees = _context.Employees.Count(e => e.DepartmentId == d.DepartmentId)
            }).ToList();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(new Models.Department
                {
                    DepartmentName = model.DepartmentName,
                    IsActive = bool.Parse(model.IsActive.ToString()),
                    CreatedDate = DateTime.Now

                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(int id, Department model)
        {
            if (id != model.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var department = _context.Departments.Find(id);
                if (department == null)
                {
                    return NotFound();
                }

                department.DepartmentName = model.DepartmentName;
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
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
