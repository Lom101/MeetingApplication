using MeetingApplication.DTO;

namespace MeetingApplication.Interfaces
{
    public interface IOrganizerService
    {
        public EmployeeDTO GetOrganizer(int meetingId, int roleId);
    }
}
