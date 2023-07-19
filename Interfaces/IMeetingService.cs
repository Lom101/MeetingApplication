using MeetingApplication;
using MeetingApplication.DTO;
using MeetingApplication.Entities;

namespace MeetingApplication.Interfaces
{
    public interface IMeetingService
    {
        public IList<MeetingDTO> GetMeetings();
        public IList<MeetingDTO> GetMeetingsUnited();
    }
}
