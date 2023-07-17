namespace MeetingApplication.Entities
{
    // промежуточная таблица для связи между классами Meeting и Employee
    public class MeetingEmployee
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }
        public Meeting? Meeting { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
