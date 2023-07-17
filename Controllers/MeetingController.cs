using MeetingApplication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using MeetingApplication.DTO;

namespace MeetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingsController : Controller
    {
        private readonly IMeetingService meetingService;

        public MeetingsController(IMeetingService meetingService)
        {
            this.meetingService = meetingService;
        }

        public IList<MeetingDTO> Meeting()
        {
            return meetingService.GetMeetings();
        }

    }
}