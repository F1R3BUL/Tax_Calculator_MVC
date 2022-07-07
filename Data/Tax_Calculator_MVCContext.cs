using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tax_Calculator_MVC.Models;

namespace Tax_Calculator_MVC.Data
{
    public class Tax_Calculator_MVCContext : DbContext
    {
        public Tax_Calculator_MVCContext (DbContextOptions<Tax_Calculator_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Tax_Calculator_MVC.Models.Employee>? Employee { get; set; }
    }
}
