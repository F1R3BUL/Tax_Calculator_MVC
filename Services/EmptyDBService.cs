using Tax_Calculator_MVC.Data;
using Tax_Calculator_MVC.Interfaces;

namespace Tax_Calculator_MVC.Services
{
    public class EmptyDBService : IEmptyDB
    {
        private readonly IEmployee _employee;
        private readonly Tax_Calculator_MVCContext _context;
        public EmptyDBService(IEmployee employee, Tax_Calculator_MVCContext tax_Calculator_MVCContext)
        {
            _context = tax_Calculator_MVCContext;
            _employee = employee;
        }
        public void EmptyDatabase()
        {
            foreach (var row in _context.Employee)
            {
                _context.Remove(row);
            }
            _context.SaveChanges();
        }
    }
}
