using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Tax_Calculator_MVC.ViewModel;
using Tax_Calculator_MVC.Interfaces;

namespace Tax_Calculator_MVC.Data
{
    public class SeedData
    {
        private readonly ITaxCalculatorService _taxCalculatorService;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Tax_Calculator_MVCContext(serviceProvider.GetRequiredService<
                DbContextOptions<Tax_Calculator_MVCContext>>()))
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var name = new char[10];
                var random = new Random();
                if (context.Employee.Any())
                {
                    return;
                }
                int randomnum = new Random().Next(1, 20);
                for (int j = 0; j <= randomnum; j++)
                {
                    for (int i = 0; i < name.Length; i++)
                    {
                        name[i] = chars[random.Next(chars.Length)];
                    }
                    string RandomName = new string(name);
                    int randomSalary = new Random().Next(0, 100000);
                    context.AddRange(
                        new EmployeeVM
                        {
                            Name = @"" + RandomName + "",
                            Salary = randomSalary,
                            Position = @"" + RandomName + "",
                        });
                }
                context.SaveChanges();
            }
        }
    }
}
