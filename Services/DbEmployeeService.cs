using MeetingApplication.DTO;
using MeetingApplication.Interfaces;

namespace MeetingApplication.Services
{
    public class DbEmployeeService : IEmployeeService
    {
        private readonly MeetingApplicationContext context;
        public DbEmployeeService(MeetingApplicationContext context)
        {
            this.context = context;
        }
        //метод возврата таблицы Employee в виде списка
        public IList<EmployeeDTO> GetEmployees()
        {
            return context.Employees.Select(x => new EmployeeDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

    }
}
