using MeetingApplication.DTO;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;

namespace MeetingApplication.Services
{
    public class DbOrganizerService : IOrganizerService
    {
        private readonly MeetingApplicationContext context;

        public DbOrganizerService(MeetingApplicationContext context)
        {
            this.context = context;
        }
        // метод возврата таблицы Meeting в виде списка
        public EmployeeDTO GetOrganizer(int meetingId, int roleId)
        { 
            EmployeeDTO employeeDTO = new EmployeeDTO();
            int tempId = 0;
            foreach (var i in context.MeetingEmployees)
            {
                if(i.MeetingId == meetingId && i.RoleId == roleId)
                {
                    tempId = i.EmployeeId;
                }
            }
            foreach(var i in context.Employees)
            {
                if(i.Id == tempId)
                {
                    return new EmployeeDTO()
                    {
                        Id = i.Id,
                        Name = i.Name,
                    };
                }
            }
            return new EmployeeDTO()
            {
                Id = 0,
                Name = "Организатора нет",
            }; ;
        }
    }
}
//return new EmployeeDTO()
//{
//    Id = i.EmployeeId,
//    Name = context.Employees.FirstOrDefault(x => x.Id == i.EmployeeId).Name,
//};