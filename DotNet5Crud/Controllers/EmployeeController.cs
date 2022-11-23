using DotNet5Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5Crud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDBContext dbContext;

        public EmployeeController(CompanyDBContext context)
        {
            dbContext = context;
        }


        public async Task<IActionResult> Index()
        {
            var employees = await dbContext.Pracownicy.    
                Include(emp => emp.CTasks).ToListAsync();
            return View(employees);
        }



        [HttpGet] //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? employeeId)
        {
            ViewBag.PageName = employeeId == null ? "Create Pracownik" : "Edycja Pracownika";
            ViewBag.IsEdit = employeeId == null ? false : true;
            if (employeeId == null)
            {
                return View();
            }
            else
            {
                var employee = await dbContext.Pracownicy.FindAsync(employeeId);

                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }        
        }
        [HttpPost] //AddOrEdit Post Method
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int employeeId, [Bind("EmployeeId,Imie,Nazwisko,Adres,Email,Stanowisko")]
        Employee employeeData)
        {
            bool IsEmployeeExist = false;

            Employee employee = await dbContext.Pracownicy.FindAsync(employeeId);

            if (employee != null)
            {
                IsEmployeeExist = true;
            }
            else
            {
                employee = new Employee();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employee.Imie = employeeData.Imie;
                    employee.Nazwisko = employeeData.Nazwisko;
                    employee.Adres = employeeData.Adres;
                    employee.Email = employeeData.Email;
                    employee.Stanowisko = employeeData.Stanowisko;

                   if(IsEmployeeExist)
                    {
                        dbContext.Update(employee);
                    }
                    else
                    {
                        dbContext.Add(employee);
                    }                   
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeData);
        }



        // GET: Employees/Delete/1
        public async Task<IActionResult> Delete(int? employeeId)
        {
            if (employeeId == null)
            {
                return NotFound();
            }
            var employee = await dbContext.Pracownicy.FirstOrDefaultAsync(m => m.EmployeeId == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [HttpPost] // POST: Employees/Delete/1
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int employeeId)
        {
            var employee = await dbContext.Pracownicy.FindAsync(employeeId);
            dbContext.Pracownicy.Remove(employee);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




        // Employee Details
        public async Task<IActionResult> Details(int? employeeId)
        {
            if (employeeId == null)
            {
                return NotFound();
            }
            var employee = await dbContext.Pracownicy.FirstOrDefaultAsync(m => m.EmployeeId == employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }




        public async Task<IActionResult> Page2()
        {
            var employees = await dbContext.Pracownicy.ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Page3(int? employeeId)
        {
            ViewBag.PageName = employeeId == null ? "Create Employee" : "Edit Employee";
            ViewBag.IsEdit = employeeId == null ? false : true;
            if (employeeId == null)
            {
                return View();
            }
            else
            {
                var employee = await dbContext.Pracownicy.FindAsync(employeeId);

                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
        }

    }
}
