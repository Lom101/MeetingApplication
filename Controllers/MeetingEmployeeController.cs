using MeetingApplication.DTO;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using MeetingApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// экшн фильтр с эксэпшн фильтр
// asp.net core middleware
// манадо резалт
//  композиция (способы ассоциации) агрегация. разница
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
        [HttpGet]
        public IList<MeetingEmployeeDTO> GetMeetingEmployee()
        {
            return meetingEmployeeService.GetMeetingEmployee();
        }

        // добавить новую запись в MeetingEmployee
        [HttpPost]
        public void AddMeetingEmployee([FromBody] MeetingEmployee meetingEmployee)
        {
            meetingEmployeeService.AddMeetingEmployee(meetingEmployee.MeetingId, meetingEmployee.EmployeeId, meetingEmployee.RoleId);
        }

        // удалить запись в MeetingEmployee
        [HttpDelete("{id}")]
        public void DeleteMeetingEmployee(int id)
        {
            meetingEmployeeService.DeleteMeetingEmployee(id);
        }

        // проверка можно ли добавить организатора в совещание
        [HttpGet("PossibleToAddOrganizerCheck/{id}")]
        public bool PossibleToAddOrganizerCheck(int id)
        {
            return meetingEmployeeService.PossibleToAddOrganizerCheck(id);
        }

        // проверка находится ли сотрудник в данный момент на другом совещании
        [HttpGet("EmployeeInAnotherMeetingCheck/{id}")]
        public bool EmployeeInAnotherMeetingCheck(int id)
        {
            return meetingEmployeeService.EmployeeInAnotherMeetingCheck(id);
        }

        // получить организатора совещания
        [HttpGet("GetOrganizer/{id}")]
        public EmployeeDTO GetOrganizer(int id)
        {
            return meetingEmployeeService.GetOrganizer(id);
        }
    }
}
