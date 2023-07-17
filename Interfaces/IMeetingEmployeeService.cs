using MeetingApplication.DTO;

namespace MeetingApplication.Interfaces
{
    public interface IMeetingEmployeeService
    {
        public IList<MeetingEmployeeDTO> GetMeetingEmployee();
        public void AddMeetingEmployee(int meetingId, int employeeId, int roleId);
        //public void RemoveMeetingEmployee();
        //public void UpdateMeetingEmployee();
    }
}
