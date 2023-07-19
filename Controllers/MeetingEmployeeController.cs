using MeetingApplication.DTO;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using MeetingApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingEmployeeController : Controller
    {
        private readonly IMeetingEmployeeService meetingEmployeeService;

        public MeetingEmployeeController(IMeetingEmployeeService meetingEmployeeService)
        {
            this.meetingEmployeeService = meetingEmployeeService;
        }

        // получить список MeetingEmployee
        [HttpGet("GetMeetingEmployee")]
        public IList<MeetingEmployeeDTO> GetMeetingEmployee()
        {
            return meetingEmployeeService.GetMeetingEmployee();
        }

        // добавить новую запись в MeetingEmployee
        [HttpPost("AddMeetingEmployee")]
        public void AddMeetingEmployee()
        {
            var data = new MeetingEmployeeDTO
            {
                MeetingId = 3,
                EmployeeId = 4,
                RoleId = 3,
            };
            meetingEmployeeService.AddMeetingEmployee(data.MeetingId, data.EmployeeId, data.RoleId);
        }

        // проверка можно ли добавить организатора в совещание
        [HttpGet("PossibleToAddOrganizer")]
        public bool PossibleToAddOrganizer()
        {
            var data = new MeetingEmployeeDTO
            {
                MeetingId = 1
            };
            return meetingEmployeeService.PossibleToAddOrganizer(data.MeetingId);
        }

        // проверка находится ли сотрудник в данный момент на другом совещании
        [HttpGet("EmployeeInAnotherMeetingCheck")]
        public bool EmployeeInAnotherMeetingCheck()
        {
            var data = new MeetingEmployeeDTO
            {
                EmployeeId = 1,
            };
            return meetingEmployeeService.EmployeeInAnotherMeetingCheck(data.EmployeeId);
        }

        // получить организатора совещания
        [HttpGet("GetOrganizer")]
        public EmployeeDTO? GetOrganizer(int meetingId)
        {
            return meetingEmployeeService.GetOrganizer(meetingId);
        }
    }
}
