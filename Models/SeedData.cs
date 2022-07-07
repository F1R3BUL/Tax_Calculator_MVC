using Microsoft.EntityFrameworkCore;
using Tax_Calculator_MVC.Data;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Tax_Calculator_MVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Tax_Calculator_MVCContext(serviceProvider.GetRequiredService<
                DbContextOptions<Tax_Calculator_MVCContext>>()))
            {
                if (context.Employee.Any())
                {
                    return;
                }
                context.AddRange(
                    new Employee
                    {
                        Name = "Jordan",
                        Salary = 1000,
                    },
                    new Employee
                    {
                        Name = "Emo",
                        Salary = 2000,
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
