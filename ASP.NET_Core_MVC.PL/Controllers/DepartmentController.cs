using ASP.NET_Core_MVC.BLL.Interfaces;
using ASP.NET_Core_MVC.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP.NET_Core_MVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentsRepo;

        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentRepository departmentsRepo, IWebHostEnvironment env)
        {
            _departmentsRepo = departmentsRepo;
            _env = env;
        }
        public IActionResult Index()
        {
            var departments = _departmentsRepo.GetAll();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var count = _departmentsRepo.Add(department);
                if (count > 0)
                    return RedirectToAction(nameof(Index));

            }
            return View(department);

        }


        //Department//Details/10
        //Department//Details
        [HttpGet]
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();

            var department = _departmentsRepo.Get(id.Value);

            if (department is null)
                return NotFound();


            return View(ViewName, department);
        }

        //Department//Edit/10
        //Department//Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");

            /*if (!id.HasValue)
                return BadRequest();

            var department = _departmentsRepo.Get(id.Value);

            if (department is null)
                return NotFound();


            return View(department);*/

        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (!ModelState.IsValid)
                return View(department);

            try
            {
                _departmentsRepo.Update(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                //log Exception
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Erorr has Occurred during update Department ");


            }
        }

    }
}
