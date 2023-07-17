using MeetingApplication.DTO;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;

namespace MeetingApplication.Services
{
    public class FakeMeetingService : IMeetingService
    {
        public IList<MeetingDTO> GetMeetings()
        {
            return new List<MeetingDTO> { new MeetingDTO { Id = 1, Name = "Name1"} };
        }
    }
}
