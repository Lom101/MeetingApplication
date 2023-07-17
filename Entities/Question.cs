namespace MeetingApplication.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public List<MeetingQuestion>? MeetingQuestion { get; set; }
    }
}
