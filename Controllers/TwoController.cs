using MeetingApplication.DTO;
using MeetingApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwoController : Controller
    {
        private readonly ITwoService twoService;

        public TwoController(ITwoService twoService)
        {
            this.twoService = twoService;
        }

        public IList<MeetingDTO> TwoMeeting()
        {
            return twoService.GetTwo();
        }
    }
}
