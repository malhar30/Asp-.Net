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
    public class IndexModel : PageModel
    {
        private readonly Assignment4.Data.northwindContext _context;

        public IndexModel(Assignment4.Data.northwindContext context)
        {
            _context = context;
           
        }

        public IList<Employee> Employee { get;set; } = default!;
        public string image { get;set; }

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                var employee = from m in _context.Employees
                               select m;
                Employee = await employee.AsNoTracking().ToListAsync();
                
                
            }
        }
    }
}
