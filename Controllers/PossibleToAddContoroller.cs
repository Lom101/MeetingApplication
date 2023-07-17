using MeetingApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PossibleToAddController : Controller
    {
        private readonly IPossibleToAddService possibleToAdd;

        public PossibleToAddController(IPossibleToAddService possibleToAdd)
        {
            this.possibleToAdd = possibleToAdd;
        }
        [HttpGet]
        public bool PossibleToAdd(int meetingId, int roleId)
        {
            return possibleToAdd.PossibleToAdd(meetingId, roleId);
        }

    }
}
