using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Assignment_iVally.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string? FirstName { get; set; }
        [StringLength(100)]
        public string? LastName { get; set; }
        [StringLength(100)]
        public string? City { get; set; }
        [StringLength(10)]
        public string? Zip { get; set; }
        public DateTime AddedOn { get; set; }

        public List<Salary>? SalaryDetails { get; set; }

        public static implicit operator Employee(ValueTask<Employee?> v)
        {
            throw new NotImplementedException();
        }
    }

    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public DateTime SalaryDate { get; set; }
        public DateTime AddedOn { get; set; }
        public virtual Employee? EmployeeDetails { get; set; }
    }
       
}
