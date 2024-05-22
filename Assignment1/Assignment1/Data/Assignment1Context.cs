using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Data
{
    public class Assignment1Context : DbContext
    {
        public Assignment1Context (DbContextOptions<Assignment1Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Assignment1.Models.Game> Game { get; set; } = default!;
    }
}
