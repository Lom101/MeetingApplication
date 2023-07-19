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
    public class MeetingController : Controller
    {
        private readonly IMeetingService meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            this.meetingService = meetingService;
        }

        // получить список совещаний
        [HttpGet("GetMeetings")]
        public IList<MeetingDTO> GetMeetings()
        {
            return meetingService.GetMeetings();
        }

        // получить список совещаний
        [HttpGet("GetMeetingsUnited")]
        public IList<MeetingDTO> GetMeetingsUnited()
        {
            return meetingService.GetMeetingsUnited();
        }
    }
}