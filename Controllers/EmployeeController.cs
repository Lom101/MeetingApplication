using MeetingApplication.DTO;
using MeetingApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("GetEmployees")]
        // получить список сотрудников
        public IList<EmployeeDTO> GetEmployees()
        {
            return employeeService.GetEmployees();
        }
    }
}
