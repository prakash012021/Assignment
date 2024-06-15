using Assignment_iVally.Models;
using Microsoft.AspNetCore.Mvc;
using Assignment_iVally.DBContext;
using Assignment_iVally.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Assignment_iVally.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public EmployeeController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index()
        {
            //var employees = new Employees();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeDetails(int Id)
        {
            var employeeViewModel = new EmployeeViewModel();
            if (Id > 0)
            {
                var employee =await dbContext.Employee.FindAsync(Id);
                if (employee != null)
                {
                    employeeViewModel.FirstName = employee.FirstName;
                    employeeViewModel.LastName = employee.LastName;
                    employeeViewModel.Zip=employee.Zip;
                    employeeViewModel.City = employee.City;
                    employeeViewModel.Id = Id;
                }
            }

            return View(employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee (EmployeeViewModel employeeViewModel)
        {
            var employee=new Employee() { FirstName=employeeViewModel.FirstName,
                LastName=employeeViewModel.LastName,
                City=employeeViewModel.City,
                Zip=employeeViewModel.Zip,
                AddedOn=DateTime.Now
            };            
            await dbContext.Employee.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            var employee = await dbContext.Employee.FindAsync(employeeViewModel.Id);
            if(employee != null) {
                employee.FirstName = employeeViewModel.FirstName;
                employee.LastName = employeeViewModel.LastName;
                employee.City = employeeViewModel.City;
                employee.Zip = employeeViewModel.Zip;
                employee.AddedOn = DateTime.Now;
                await dbContext.SaveChangesAsync();
            };
            return View();
        }
    
    
    }
}
