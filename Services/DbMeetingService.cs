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
        // метод добавления 
        public void AddMeetings()
        {
            context.AddRange(new Meeting()
            {

            });
        }
    }
}
