using CaseAlp.Data;
using CaseAlp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseAlp.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly ApplicationDbContext _dbContext; 

        public MeetingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MeetingViewModel>> GetAllMeetingsAsync()
        {
            var meetings = await _dbContext.Meetings.ToListAsync();
            return meetings.Select(MapToViewModel);
        }

        public async Task<MeetingViewModel> GetMeetingByIdAsync(int id)
        {
            var meeting = await _dbContext.Meetings.FindAsync(id);
            return MapToViewModel(meeting);
        }

        public async Task<bool> CreateMeetingAsync(MeetingViewModel model)
        {
            var entity = MapToEntity(model);
            _dbContext.Meetings.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMeetingAsync(int id, MeetingViewModel model)
        {
            var existingMeeting = await _dbContext.Meetings.FindAsync(id);
            if (existingMeeting == null)
            {
                return false; 
            }

            MapToEntity(model, existingMeeting);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMeetingAsync(int id)
        {
            var meeting = await _dbContext.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return false; 
            }

            _dbContext.Meetings.Remove(meeting);
            await _dbContext.SaveChangesAsync();
            return true;
        }

       
        private MeetingViewModel MapToViewModel(Meeting entity)
        {
            
            return new MeetingViewModel
            {
                Title = entity.Title,
                StartTime = entity.StartTime,
             
            };
        }

        private Meeting MapToEntity(MeetingViewModel model)
        {
           
            return new Meeting
            {
                Title = model.Title,
                StartTime = model.StartTime,
                
            };
        }

        private void MapToEntity(MeetingViewModel model, Meeting entity)
        {
            
            entity.Title = model.Title;
            entity.StartTime = model.StartTime;
          
        }
    }
}
