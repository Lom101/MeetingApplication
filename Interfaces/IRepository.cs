using MeetingApplication.DTO;

namespace MeetingApplication.Interfaces
{
    public interface IRepository
    {
        public IList<MeetingDTO> GetAll();
    }
}
