using Tax_Calculator_MVC.ViewModel;

namespace Tax_Calculator_MVC.Interfaces
{
    public interface ITaxCalculatorService
    {
        EmployeeVM Calculator(EmployeeVM employee);
    }
}
