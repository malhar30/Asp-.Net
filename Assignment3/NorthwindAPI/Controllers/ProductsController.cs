using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly northwindContext _context;

    public ProductsController(northwindContext context)
    {
        _context = context;
    }

    // GET: api/Products
    [HttpGet("ByCategory/{id}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts( int id )
    {
      if (_context.Products == null)
      {
          return NotFound();
      }

        var products = from p in _context.Products              
                       select p;
        products = products.Where(m => m.Discontinued==false && m.CategoryId== id);

        return await products.AsNoTracking().ToListAsync();
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      if (_context.Products == null)
      {
          return NotFound();
      }
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

}
