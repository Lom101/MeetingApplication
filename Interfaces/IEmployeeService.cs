using MeetingApplication.DTO;

namespace MeetingApplication.Interfaces
{
    public interface IEmployeeService
    {
        public IList<EmployeeDTO> GetEmployees();
    }
}
