using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingApplication.Entities
{
    public class Meeting
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? EndDate { get; set; }

        public List<MeetingEmployee>? MeetingEmployee { get; set; }
        public List<MeetingQuestion>? MeetingQuestion { get; set; }

        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
