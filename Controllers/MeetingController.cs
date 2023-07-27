using MeetingApplication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using MeetingApplication.DTO;
using MeetingApplication.Services;

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
        [HttpGet]
        public IList<MeetingDTO> GetMeetings()
        {
            return meetingService.GetMeetings();
        }

        // получить список совещаний без пауз между совещаниями
        [HttpGet("United")]
        public IList<MeetingDTO> GetMeetingsUnited()
        {
            return meetingService.GetMeetingsUnited();
        }
    }
}
