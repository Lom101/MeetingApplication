namespace MeetingApplication.DTO
{
    public class MeetingEmployeeDTO
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }
        public string? Meeting { get; set; }
        public int EmployeeId { get; set; }
        public string? Employee { get; set; }
        public int RoleId { get; set; }
        public string? Role { get; set; }

    }
}
