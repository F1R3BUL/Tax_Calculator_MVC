using Tax_Calculator_MVC.Interfaces;

namespace Tax_Calculator_MVC.ViewModel
{
    public class EmployeeVM:IEmployee
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public int Salary { get; set; }


        public string Position { get; set; }


        public double netoSalary { get; set; }
    }
}
