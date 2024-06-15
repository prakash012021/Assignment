using Assignment_iVally.DBContext;
using Assignment_iVally.Models;
using Assignment_iVally.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_iVally.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public SalaryController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult GetSalaries(int employeeId)
        {
            var salaries = dbContext.Salary.Select(x => x.EmployeeDetails.Id == employeeId).ToList();

            return View(salaries);
        }

        public async Task<IActionResult> AddSalary(SalaryViewModel salaryViewModel)
        {
            var employee = dbContext.Employee.FindAsync(salaryViewModel.EmployeeId);
            var salary = new Salary()
            {
                Amount = salaryViewModel.Amount,
                EmployeeDetails = employee,
                SalaryDate = salaryViewModel.SalaryDate,
                AddedOn = DateTime.Now
            };
            await dbContext.Salary.AddAsync(salary);
            await dbContext.SaveChangesAsync();
            return View();
        }
    }
}
