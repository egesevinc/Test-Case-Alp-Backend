using CaseAlp.Models;

namespace CaseAlp.Services
{
    public interface IMeetingService
    {
        Task<IEnumerable<MeetingViewModel>> GetAllMeetingsAsync();
        Task<MeetingViewModel> GetMeetingByIdAsync(int id);
        Task<bool> CreateMeetingAsync(MeetingViewModel model);
        Task<bool> UpdateMeetingAsync(int id, MeetingViewModel model);
        Task<bool> DeleteMeetingAsync(int id);
       
    }

}
