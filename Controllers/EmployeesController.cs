﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tax_Calculator_MVC.Data;
using Tax_Calculator_MVC.Models;

namespace Tax_Calculator_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly Tax_Calculator_MVCContext _context;

        public EmployeesController(Tax_Calculator_MVCContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string SearchString)
        {
            var employees = from e in _context.Employee select e;
            if(!String.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(e => e.Name!.Contains(SearchString));
            }
            return View(await employees.ToListAsync());                  
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Salary,Position")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Salary,Position")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'Tax_Calculator_MVCContext.Employee'  is null.");
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        //GET: Employees/Calculate/

        public async Task<IActionResult> Calculate(int? id)
        {
            if (_context.Employee == null || id == 0)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.Id == id);
            return View(employee);
        }
        //POST: Employees/Calculated
        [HttpPost, ActionName("Calculate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculated(int id)
        {
           if (_context.Employee == null)
           {
               return NotFound();
           }
           var employee = await _context.Employee.FindAsync(id);
           int preCalculatedSalary = employee.Salary;
           double finalsalary = employee.Salary;
           if (preCalculatedSalary > 1000)
           {
               double IncomeTax = (preCalculatedSalary - 1000) * 0.1;
               double InsuranceTax = (preCalculatedSalary - 1000) * 0.15;
               finalsalary = finalsalary - (IncomeTax+InsuranceTax);
               employee.netoSalary = finalsalary;
               _context.Update(employee);
                await _context.SaveChangesAsync();
                return View(employee);
           }
            employee.netoSalary = finalsalary;
            _context.Update(employee);
            await _context.SaveChangesAsync();
            return View(employee);
           
        }
    }
}
