using MeetingApplication.DTO;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;

namespace MeetingApplication.Services
{
    public class DbMeetingEmployeeService : IMeetingEmployeeService
    {
        private readonly MeetingApplicationContext context;
        public DbMeetingEmployeeService(MeetingApplicationContext context)
        {
            this.context = context;
        }
        //метод возврата MeetingEmployee в виде списка
        public IList<MeetingEmployeeDTO> GetMeetingEmployee()
        {
            return context.MeetingEmployees.Select(x => new MeetingEmployeeDTO
            {
                Id = x.Id,
                MeetingId = x.MeetingId,
                EmployeeId = x.EmployeeId,
                RoleId = x.RoleId,
                Meeting = context.Meetings.First(i => i.Id == x.MeetingId).Name,
                Employee = context.Employees.First(i => i.Id == x.EmployeeId).Name,
                Role = context.Roles.First(i => i.Id == x.RoleId).Name,
            }).ToList();
        }
        //метод добавления записи в MeetingEmployee
        public void AddMeetingEmployee(int meetingId, int employeeId, int roleId)
        {
            context.MeetingEmployees.AddRange(new MeetingEmployee()
            {
                MeetingId=meetingId,
                EmployeeId=employeeId,
                RoleId=roleId
            });
            context.SaveChanges();
        }
    }
}
