using MeetingApplication.DTO;
using MeetingApplication.Interfaces;

namespace MeetingApplication.Services
{
    public class DbPossibleToAddService : IPossibleToAddService
    {
        private readonly MeetingApplicationContext context;

        public DbPossibleToAddService(MeetingApplicationContext context)
        {
           this.context = context;
        }
        public bool PossibleToAdd(int meetingId, int roleId)
        {
            // если значения не переданы
            if(meetingId == 0 || roleId == 0)
            {
                return false;
            }
            List<MeetingEmployeeDTO> meetingEmployee = context.MeetingEmployees.Select(x => new MeetingEmployeeDTO
            {
                Id = x.Id,
                MeetingId = x.MeetingId,
                EmployeeId = x.EmployeeId,
                RoleId = x.RoleId,
            }).ToList();

            int count = 0;
            foreach (MeetingEmployeeDTO employee in meetingEmployee)
            {
                if(employee.MeetingId == meetingId && employee.RoleId == roleId)
                {
                    count += 1;
                }
            }
            if(count >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
