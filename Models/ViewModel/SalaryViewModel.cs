using Microsoft.EntityFrameworkCore;

namespace Assignment_iVally.Models.ViewModel
{
    public class SalaryViewModel
    {       
        public decimal Amount { get; set; }
        public DateTime SalaryDate { get; set; }        
        public int EmployeeId { get; set; }
    }
}
