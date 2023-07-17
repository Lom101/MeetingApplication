using MeetingApplication.DTO;
using MeetingApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IList<EmployeeDTO> Employee()
        {
            return employeeService.GetEmployees();
        }
    }
}
