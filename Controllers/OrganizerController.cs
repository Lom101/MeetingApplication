using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using MeetingApplication.DTO;

namespace MeetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizersController : Controller
    {
        private readonly IOrganizerService organizerService;

        public OrganizersController(IOrganizerService organizerService)
        {
            this.organizerService = organizerService;
        }
        [HttpGet]
        public EmployeeDTO Organizer(int meetingId, int roleId)
        {
            return organizerService.GetOrganizer(meetingId, roleId);
        }
    }
}
