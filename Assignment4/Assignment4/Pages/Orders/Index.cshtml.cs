using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment4.Models;

namespace Assignment4.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Assignment4.Data.northwindContext _context;

        public IndexModel(Assignment4.Data.northwindContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;
        public SelectList SalesRep { get; set; }
        [BindProperty(SupportsGet = true)]
        public string EmployeeId { get; set; }

        public async Task OnGetAsync()
        {
            var empQuery = from m in _context.Orders
                             select new { LastName = m.Employee.LastName,Name= m.Employee.FirstName+" "+ m.Employee.LastName, m.EmployeeId,m.Employee };
            
            SalesRep = new SelectList(empQuery.Distinct().OrderBy(m=>m.LastName), "EmployeeId","Name");
            if (_context.Orders != null)
            {
                var order = from o in _context.Orders
                    .Where(o => o.Freight >= 250)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                select o;

                if (!string.IsNullOrEmpty(EmployeeId))
                {
                     order = order.Where(o => o.EmployeeId == Int32.Parse(EmployeeId));
                    
                }
                Order = await order.AsNoTracking().ToListAsync();
            }
            
        }
    }
}
