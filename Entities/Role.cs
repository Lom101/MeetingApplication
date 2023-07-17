﻿namespace MeetingApplication.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<MeetingEmployee>? MeetingEmployee { get; set; }
    }
}
