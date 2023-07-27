namespace MeetingApplication.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Question>? Question { get; set; }
        public List<Meeting>?  Meeting { get; set; }
    }
}
