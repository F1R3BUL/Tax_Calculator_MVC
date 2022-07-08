using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tax_Calculator_MVC.Data;
using Tax_Calculator_MVC.Interfaces;
using Tax_Calculator_MVC.Models;
using Tax_Calculator_MVC.Services;


namespace Tax_Calculator_MVC.Services
{
    public class EmployeeService : Controller, IEmployee
    {
        internal Tax_Calculator_MVCContext _context;

        public EmployeeService(Tax_Calculator_MVCContext context)
        {
            _context = context;
        }
        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> CreateAsync()
        {
            return View();
        }
        public async Task<IActionResult> DeleteAsync()
        {
            return View();
        }
        public async Task<IActionResult> EditAsync()
        {
            return View();
        }
        public async Task<IActionResult> DetailsAsync()
        {
            return View();
        }
        public async Task<IActionResult> CalculateAsync()
        {
            return View();
        }
    }
        
}
