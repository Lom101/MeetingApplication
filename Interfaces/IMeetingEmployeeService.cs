using MeetingApplication.DTO;

namespace MeetingApplication.Interfaces
{
    public interface IMeetingEmployeeService
    {
        public IList<MeetingEmployeeDTO> GetMeetingEmployee();
        public void AddMeetingEmployee(int meetingId, int employeeId, int roleId);
        public void DeleteMeetingEmployee(int id);

        public bool PossibleToAddOrganizerCheck(int meetingId);
        public bool EmployeeInAnotherMeetingCheck(int employeeId);
        public EmployeeDTO GetOrganizer(int meetingId);
        
    }
}
