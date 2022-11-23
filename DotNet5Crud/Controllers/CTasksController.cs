using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using DotNet5Crud.Models;
using DotNet5Crud.ViewModels;

namespace DotNet5Crud.Controllers
{
    public class CTasksController : Controller
    {

        private readonly CompanyDBContext dbContext;

        public CTasksController(CompanyDBContext context)
        {
            dbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var lTasks = await dbContext.CTasks
            .Include(emp => emp.Employee).ToListAsync();
            return View(lTasks);
        }


        [HttpGet] //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? CTaskId)
        {
            ViewBag.PageName = CTaskId == null ? "Utwórz Task" : "Edycja Task";
            ViewBag.IsEdit = CTaskId == null ? false : true;
            if (CTaskId == null)
            {
                var cTaskVM = await PrepareCTaskVM(DateTime.Now, "#032 Rysunek do projektu", "NEW");

                return View(cTaskVM);
            }
            else
            {
                var cTask = await dbContext.CTasks.FindAsync(CTaskId);

                if (cTask == null)
                {
                    return NotFound();
                }

                var cTaskVM = await PrepareCTaskVM(cTask.DataW, cTask.Nazwa, 
                    cTask.Status, cTask.EmployeeId);
                return View(cTaskVM);
            }
        }

        private async Task<CTaskCreateVM> PrepareCTaskVM(DateTime xdt, string xNazwa, 
            string xStatus, int xEmployeeId = 0)
        {
            var cTaskVM = new CTaskCreateVM();
            cTaskVM.Pracownicy = await dbContext.Pracownicy.ToListAsync();
            foreach (var item in cTaskVM.Pracownicy)
                item.Nazwisko = $"{item.Imie} {item.Nazwisko} [{item.Stanowisko}]";
            cTaskVM.DataW = xdt;
            cTaskVM.Nazwa = xNazwa; //"Wykonać";
            cTaskVM.Status = xStatus; //"In progress";
            cTaskVM.SelectedEmployeeId = xEmployeeId; //"In progress";
            return (cTaskVM);
        }

        [HttpPost] //AddOrEdit Post Method
        public async Task<IActionResult> AddOrEdit(int CTaskId, [FromForm] CTaskCreateVM vm)
        {   //if Create then (CTaskId == 0)

            bool IsCtaskExist = false;

            CTask cTask = await dbContext.CTasks.FindAsync(CTaskId);

            if (cTask != null)
                IsCtaskExist = true;
            else
                cTask = new CTask();

            if (ModelState.IsValid)
            {
                try
                {
                    cTask.Nazwa = vm.Nazwa;
                    cTask.DataW = vm.DataW;
                    cTask.Status = vm.Status;
                    cTask.EmployeeId = vm.SelectedEmployeeId;

                    if (IsCtaskExist)
                        dbContext.Update(cTask);
                    else
                        dbContext.Add(cTask);

                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }


        // GET: Employees/Delete/1
        public async Task<IActionResult> Delete(int? CTaskId, int? xDel)
        {
            ViewBag.PageName = xDel == 1 ? "Usuwanie Task" : "Szczegóły Task";
            ViewBag.IsEdit = xDel == 1 ? true: false;

            if (CTaskId == null)
            {
                return NotFound();
            }
            var cTask = await dbContext.CTasks.FirstOrDefaultAsync(m => m.CTaskId == CTaskId);

            if (cTask == null)
            {
                return NotFound();
            }

            return View(cTask);
        }

        [HttpPost] // POST: Employees/Delete/1
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int CTaskId)
        {
            var cTask = await dbContext.CTasks.FindAsync(CTaskId);
            dbContext.CTasks.Remove(cTask);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Test()
        {
            var cTask = await dbContext.CTasks.ToListAsync();
            return View();
        }

        //[HttpPost]
        public async Task<string> ChangeStatus(int xId, string xStatus)
        {
            string sEnd = "null";
            CTask cTask = await dbContext.CTasks.FindAsync(xId);
            //CTask cTask = new CTask();

            if (cTask == null)
                return(sEnd); // (false);

            if (ModelState.IsValid)
            {
                try
                {
                    cTask.Status = xStatus; //"REOPEN";

                    //dbContext.Add(cTask);
                    dbContext.Update(cTask);

                    await dbContext.SaveChangesAsync();
                    sEnd = $"OK: {xStatus}";
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return (sEnd);
        }


        //[HttpGet] //AddOrEdit Get Method Task<IActionResult>
        public async Task<IActionResult> _PartialTasks(int xId)
        {
            var cTask = await dbContext.CTasks.Where(x => x.EmployeeId == xId).ToListAsync(); 
            if (cTask == null)
            {
                return NotFound();
            }
            return (View(cTask));
        }

        [HttpPost] // POST: Employees/Delete/1
        public string jChangeStatus(int xId, string xStatus)
        {
            if ((xId != null) && (xStatus != null))
            {
                var ggg = ChangeStatus(xId, xStatus);
                return ($"From Controller: Id:{xId}, StatusNew:{xStatus}");
            }
            else
                return ("Error");
        }

        public void jDodaj(int xId, string xStatus)
        {
            int a = 0;
            if ((xId != null) && (xStatus != null))
                a = xId;
            else
                a = 0;
        }

    }
}
