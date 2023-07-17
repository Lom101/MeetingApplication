using MeetingApplication.DTO;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingApplication.Controllers
{
    [ApiController]
    public class MeetingEmployeesController : Controller
    {
        private readonly IMeetingEmployeeService meetingEmployeeService;
        private readonly MeetingApplicationContext context; //

        public MeetingEmployeesController(IMeetingEmployeeService meetingEmployeeService,/**/ MeetingApplicationContext context/**/)
        {
            this.meetingEmployeeService = meetingEmployeeService;
            this.context = context; //
        }
        [Route("MeetingEmployees/GetMeetingEmployee")]
        public IList<MeetingEmployeeDTO> GetMeetingEmployee()
        {
            return meetingEmployeeService.GetMeetingEmployee();
        }

        [HttpGet]
        [Route("MeetingEmployees/AddMeetingEmployee")]
        public void AddMeetingEmployee(int meetingId, int employeeId, int roleId)
        {
            //if (roleId == 1)
            //{
            //    if (EmployeeInAnotherMeetingCheck(meetingId, employeeId) && PossibleToAdd(meetingId, roleId))
            //    {
            //        meetingEmployeeService.AddMeetingEmployee(meetingId, employeeId, roleId);
            //        Console.WriteLine("Запись в таблицу MeetingEmployee завершилась удачно");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Неудачная попытка записи в таблицу MeetingEmloyee");
            //    }
            //}
            //else
            //{
            //    if (EmployeeInAnotherMeetingCheck(meetingId, employeeId))
            //    {
            //        meetingEmployeeService.AddMeetingEmployee(meetingId, employeeId, roleId);
            //        Console.WriteLine("Запись в таблицу MeetingEmployee завершилась удачно");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Неудачная попытка записи в таблицу MeetingEmloyee");
            //    }
            //}
        }

        //// проверка находится ли сотрудник в данный момент на другом совещании
        //private bool EmployeeInAnotherMeetingCheck(int employeeId)
        //{
        //    //MeetingEmployeeDTO meetingEmployeeDTO = new MeetingEmployeeDTO() { };
        //    List<MeetingEmployee> meetingEmployees = new List<MeetingEmployee> { };
        //    List<Meeting> meetings = new List<Meeting> { };
        //    foreach (var i in context.MeetingEmployees)
        //    {
        //        if(i.EmployeeId == employeeId)
        //        {
        //            meetingEmployees.Add(i);
        //        }
        //    }
        //    foreach(var i in context.Meetings)
        //    {
                
        //    }
            
        //}
        //// проверка можно ли добавить сотрудника с определенным id в совещание
        //private bool PossibleToAdd(int meetingId, int roleId)
        //{
        //    List<MeetingEmployeeDTO> meetingEmployee = context.MeetingEmployees.Select(x => new MeetingEmployeeDTO
        //    {
        //        Id = x.Id,
        //        MeetingId = x.MeetingId,
        //        EmployeeId = x.EmployeeId,
        //        RoleId = x.RoleId,
        //    }).ToList();

        //    int count = 0;
        //    foreach (MeetingEmployeeDTO employee in meetingEmployee)
        //    {
        //        if (employee.MeetingId == meetingId && employee.RoleId == roleId)
        //        {
        //            count += 1;
        //        }
        //    }
        //    if (count >= 1)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}
