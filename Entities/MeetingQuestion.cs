namespace MeetingApplication.Entities
{
    // промежуточная таблица для связи между классами Meeting и Question
    public class MeetingQuestion
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }
        public Meeting? Meeting { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
