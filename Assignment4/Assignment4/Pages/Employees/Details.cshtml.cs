using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly Assignment4.Data.northwindContext _context;

        public DetailsModel(Assignment4.Data.northwindContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string reportName { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            //var employeeint = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
            var employee = from emp in _context.Employees
                           where emp.EmployeeId == id 
                           select emp;

            var report = from o in _context.Employees
                                        where o.EmployeeId == employee.FirstOrDefault().ReportsTo
                                        select o;

            ViewData["ReportsToName"] = report.FirstOrDefault()?.FirstName +" "+ report.FirstOrDefault()?.LastName;



            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                
                Employee = await employee.FirstOrDefaultAsync();
            }
            return Page();
        }
    }
}
