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
            // если роль участника совещания - организатор
            if (roleId == 1)
            {
                // то дополнительно проверяем нет ли еще организаторов в совещании
                if ((EmployeeInAnotherMeetingCheck(employeeId) == false) && (PossibleToAddOrganizer(meetingId) == true))
                {
                    context.MeetingEmployees.AddRange(new MeetingEmployee()
                    {
                        MeetingId = meetingId,
                        EmployeeId = employeeId,
                        RoleId = roleId
                    });
                    context.SaveChanges();
                    Console.WriteLine("Запись в таблицу MeetingEmployee завершилась удачно");
                }
            }
            // если роль учаснтика совещания - не организатор
            else
            {
                // проверяем не находится ли он на другом совещании в данный момент
                if (EmployeeInAnotherMeetingCheck(employeeId) == false)
                {
                    context.MeetingEmployees.AddRange(new MeetingEmployee()
                    {
                        MeetingId = meetingId,
                        EmployeeId = employeeId,
                        RoleId = roleId
                    });
                    context.SaveChanges();
                    Console.WriteLine("Запись в таблицу MeetingEmployee завершилась удачно");
                }
            }
        }

        // узнать есть ли возможность добавить организатора в совещание
        public bool PossibleToAddOrganizer(int meetingId)
        {
            // если значения не переданы
            if (meetingId == 0)
            {
                return false;
            }
            List<MeetingEmployeeDTO> meetingEmployee = context.MeetingEmployees.Select(x => new MeetingEmployeeDTO
            {
                Id = x.Id,
                MeetingId = x.MeetingId,
                EmployeeId = x.EmployeeId,
                RoleId = x.RoleId,
            }).ToList();

            foreach (MeetingEmployeeDTO employee in meetingEmployee)
            {
                // если совещание нужное нам и роль сотрудника - организатор
                if (employee.MeetingId == meetingId && employee.RoleId == 1)
                {
                    // значит организатор уже есть
                    return false;
                }
            }
            return true;
        }

        // проверка находится ли сотрудник в данный момент на другом совещании
        public bool EmployeeInAnotherMeetingCheck(int employeeId)
        {
            List<MeetingEmployee> meetingEmployee = context.MeetingEmployees.Select(x => new MeetingEmployee
            {
                Id = x.Id,
                MeetingId = x.MeetingId,
                EmployeeId = x.EmployeeId,
                RoleId = x.RoleId,
            }).ToList();

            foreach (MeetingEmployee i in meetingEmployee)
            {
                // находим нужного сотрудника
                if (i.EmployeeId == employeeId)
                {
                    // совещание на котором присутствовал/присутствует сотрудник
                    Meeting meeting = context.Meetings.First(x => x.Id == i.MeetingId);
                    // если совещание еще идет
                    if (meeting.StartDate < DateTime.Now && meeting.EndDate > DateTime.Now)
                    {
                        return true;    
                    }
                        
                }
            }
            return false;
        }

        // получить организатора совещания
        public EmployeeDTO? GetOrganizer(int meetingId)
        {
            int tempId = 0;
            foreach (var i in context.MeetingEmployees)
            {
                if (i.MeetingId == meetingId && i.RoleId == 1)
                {
                    tempId = i.EmployeeId;
                }
            }
            foreach (var i in context.Employees)
            {
                if (i.Id == tempId)
                {
                    return new EmployeeDTO()
                    {
                        Id = i.Id,
                        Name = i.Name,
                    };
                }
            }
            return null;
        }
    }
}
