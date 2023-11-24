using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CaseAlp.Services;
using CaseAlp.Models;

namespace CaseAlp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeetings()
        {
            try
            {
                var meetings = await _meetingService.GetAllMeetingsAsync();

                if (meetings == null || !meetings.Any())
                {
                    return Ok(); 
                }

                return Ok(meetings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeeting(int id)
        {
            try
            {
                var meeting = await _meetingService.GetMeetingByIdAsync(id);

                if (meeting == null)
                {
                    return NotFound(new { Message = "Meeting not found" });
                }

                return Ok(meeting);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeeting([FromBody] MeetingViewModel model)
        {
            try
            {
                var createdMeeting = await _meetingService.CreateMeetingAsync(model);

                return CreatedAtAction(nameof(GetMeeting), new { MeetingName = "" }, createdMeeting);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeeting(int id, [FromBody] MeetingViewModel model)
        {
            try
            {
                var updatedMeeting = await _meetingService.UpdateMeetingAsync(id, model);

                if (updatedMeeting == null)
                {
                    return NotFound(new { Message = "Meeting not found" });
                }

                return Ok(updatedMeeting);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(int id)
        {
            try
            {
                var deletedMeeting = await _meetingService.DeleteMeetingAsync(id);

                if (deletedMeeting == null)
                {
                    return NotFound(new { Message = "Meeting not found" });
                }

                return Ok(deletedMeeting);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Error = ex.Message });
            }
        }
    }
}
