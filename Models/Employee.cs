using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tax_Calculator_MVC.Models
{
    public class Employee
    {
       public int Id { get; set; }
        [Display(Name = "Name:")]
       public string Name { get; set; }
        [DataType(DataType.Currency)]
       public int Salary { get; set; }
    }
}
