using MeetingApplication.DTO;
using MeetingApplication.Entities;
using MeetingApplication.Interfaces;
using System.Text;

namespace MeetingApplication.Services
{
    public class DbMeetingService : IMeetingService
    {
        private readonly MeetingApplicationContext context;

        public DbMeetingService(MeetingApplicationContext context)
        {
            this.context = context;
        }

        // метод возврата таблицы Meeting в виде списка
        public IList<MeetingDTO> GetMeetings()
        {
            return context.Meetings.Select(x => new MeetingDTO 
            { 
                Id = x.Id, 
                Name = x.Name, 
                Time = Math.Floor(((TimeSpan)(x.EndDate - x.StartDate)).TotalMinutes) 
            }).ToList();
        }

        // метод возврата таблицы Meeting в виде списка без пауз
        public IList<MeetingDTO> GetMeetingsUnited()
        {
            List<MeetingDTO> meetings = context.Meetings.Select(x => new MeetingDTO
            {
                Id = x.Id,
                Name = x.Name,
                Time = Math.Floor(((TimeSpan)(x.EndDate - x.StartDate)).TotalMinutes)
            }).ToList();
            List<MeetingDTO> outputList = new List<MeetingDTO> { };
            foreach (MeetingDTO meeting in meetings)
            {
                bool flag = true;
                if (outputList.Select(x => x.Name).Contains(meeting.Name))
                {
                    flag = false;
                }
                if (flag == true)
                {
                    outputList.Add(new MeetingDTO
                    {
                        Name = meeting.Name,
                        Time = 0,
                    });
                }
            }
            foreach (MeetingDTO output in outputList)
            {
                foreach (MeetingDTO i in meetings)
                {
                    if (i.Name == output.Name)
                    {
                        output.Time += i.Time;
                    }
                }
            }
            return outputList.ToList();
        }

    }
}
