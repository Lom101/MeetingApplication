using MeetingApplication.DTO;
using MeetingApplication.Interfaces;
using System;
using System.Collections.Generic;

namespace MeetingApplication.Services
{
    public class DbTwoService : ITwoService
    {
        private readonly MeetingApplicationContext context;

        public DbTwoService(MeetingApplicationContext context)
        {
            this.context = context;
        }
        public IList<MeetingDTO> GetTwo()
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
