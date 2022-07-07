using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tax_Calculator_MVC.Models
{
    public class Employee
    {
       public int Id { get; set; }
        [StringLength(30, MinimumLength = 1)]
        [Required]
       public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Required]
       public int Salary { get; set; }
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string? Position {get; set; }
        
        public double netoSalary { get; set; }
    }
}
