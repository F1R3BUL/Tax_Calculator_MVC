using Tax_Calculator_MVC.Data;
using Tax_Calculator_MVC.Interfaces;
using Tax_Calculator_MVC.ViewModel;

namespace Tax_Calculator_MVC.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        public EmployeeVM Calculator(EmployeeVM employee) 
        {
            int preCalculatedSalary = employee.Salary;
            double finalsalary = employee.Salary;
            if (preCalculatedSalary > 1000)
            {
                double IncomeTax = (preCalculatedSalary - 1000) * 0.1;
                double InsuranceTax = Math.Abs(preCalculatedSalary - 1000) * 0.15;
                if (preCalculatedSalary > 3000)
                {
                    InsuranceTax = 300;
                }
                finalsalary = finalsalary - (IncomeTax + InsuranceTax);
            }
            return new EmployeeVM() { Id = employee.Id, Name = employee.Name, Salary = employee.Salary, Position = employee.Position, netoSalary = finalsalary};
        }
    }
}
