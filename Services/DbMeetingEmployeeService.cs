using MeetingApplication.DTO;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

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
            // если роль участника совещания - организатор
            if (roleId == 1 && (EmployeeInAnotherMeetingCheck(employeeId) == false) && (PossibleToAddOrganizerCheck(meetingId) == true))
            {
                MeetingEmployee meetingEmployee = new MeetingEmployee()
                {
                    Id = context.MeetingEmployees.OrderBy(x => x.Id).Last().Id + 1,
                    MeetingId = meetingId,
                    EmployeeId = employeeId,
                    RoleId = roleId
                };
                context.MeetingEmployees.AddRange(meetingEmployee);
                context.SaveChanges();
            }
            // если роль учаснтика совещания - не организатор
            else if (roleId != 1 && EmployeeInAnotherMeetingCheck(employeeId) == false)
            {
                MeetingEmployee meetingEmployee = new MeetingEmployee()
                {
                    Id = context.MeetingEmployees.OrderBy(x => x.Id).Last().Id + 1,
                    MeetingId = meetingId,
                    EmployeeId = employeeId,
                    RoleId = roleId
                };
                context.MeetingEmployees.AddRange(meetingEmployee);
                context.SaveChanges();
            }
        }

        //метод удаления записи в MeetingEmployee
        public void DeleteMeetingEmployee(int id)
        {
            MeetingEmployee meetingEmployee = context.MeetingEmployees.First(x => x.Id == id);
            context.MeetingEmployees.Remove(meetingEmployee);
            context.SaveChanges();
        }

        // узнать есть ли возможность добавить организатора в совещание
        public bool PossibleToAddOrganizerCheck(int meetingId)
        {
            // если совещания с id равным meetingId не существует
            if(context.MeetingEmployees.Any(x => x.MeetingId == meetingId) == false)
            {
                throw new Exception($"Совещания с id = {meetingId} не существует");
            }
            if(context.MeetingEmployees.Any(x => x.MeetingId == meetingId && x.RoleId == 1))
            {
                Console.WriteLine($"В совещании с id = {meetingId} уже есть организатор");
                return false;
            }
            else
            {
                return true;
            }
        }

        // проверка находится ли сотрудник в данный момент на другом совещании
        public bool EmployeeInAnotherMeetingCheck(int employeeId)
        {
            // если сотрудника с id равным employeeId не существует
            if (context.Employees.Any(x => x.Id == employeeId) == false)
            {
                throw new Exception($"Сотрудника с id = {employeeId} не существует");
            }
            if (context.MeetingEmployees.Any(x => (x.EmployeeId == employeeId && context.Meetings
            .Any(i => (i.Id == x.MeetingId && i.StartDate < DateTime.Now && i.EndDate > DateTime.Now)))))
            {
                Console.WriteLine($"Сотрудник с id = {employeeId} в данный момент находится на другом совещании");
                return true;
            }
            else
            {
                return false;
            }
        }

        // получить организатора совещания
        public EmployeeDTO GetOrganizer(int meetingId)
        {
            if (!context.Employees.Any(x => x.Id == (context.MeetingEmployees.First(x => x.MeetingId == meetingId && x.RoleId == 1).Id)))
            {
                throw new Exception($"На совещании с id = {meetingId} нет организатора");
            }
            else
            {
                Employee organizer = context.Employees.First(x => x.Id == (context.MeetingEmployees.First(x => x.MeetingId == meetingId && x.RoleId == 1).Id));
                return new EmployeeDTO()
                {
                    Id = organizer.Id,
                    Name = organizer.Name,
                };
            }
            
        }
    }
}
