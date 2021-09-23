using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcCore;
using Microsoft.EntityFrameworkCore;
using MvcCore.Models;
namespace MvcCore.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext _db; 
        public EmpController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.Employeetable.ToList();
            return View(displaydata);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>create(NewEmpClass nec)
        {
            if(ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nec);
        }

        public async Task<IActionResult> Edit(int? id   )
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            var getemployeedetails = await _db.Employeetable.FindAsync(id);
            return View(getemployeedetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(NewEmpClass nc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nc);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getemployeedetails = await _db.Employeetable.FindAsync(id);
            return View(getemployeedetails);
        }

       //[HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getemployeedetails = await _db.Employeetable.FindAsync(id);
            return View(getemployeedetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var getemployeedetails = await _db.Employeetable.FindAsync(id);
            _db.Employeetable.Remove(getemployeedetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
