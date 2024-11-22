using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repositories.Entities;
using Services;

namespace MentorBookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private MentorService _service;

        public MentorController(MentorService service)
        {
            _service = service;
        }
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(this._service.GetAll());
        }
        [HttpPost]
        public IActionResult Create([FromBody] MentorRequest mentorRequest)
        {
            if (mentorRequest != null)
            {
                this._service.CreateMentor(this.ConvertObject(mentorRequest));
                return Ok("Create success full");
            }

            return BadRequest("Create fail");
        }
        [HttpPut]
        public IActionResult Update([FromBody] MentorRequest mentorRequest, string id)
        {
            if (mentorRequest != null)
            {
                this._service.UpdateMentor(this.ConvertObject(mentorRequest));
                return Ok("Update successfull");
            }

            return BadRequest("Update fail");
        }
        [HttpDelete("{id}")]
       
        public IActionResult Delete(int id)
        {
            var mentor = new Mentor();
            mentor.MentorId = id;
            if (mentor != null)
            {
                this._service.DeleteMentor(mentor);
                return Ok("Delete successfull");
            }

            return BadRequest("Delete fail");
        }
        private Mentor ConvertObject(MentorRequest request)
        {
            Mentor result = new Mentor()
            {
                MentorId = request.MentorId,
                MentorName = request.MentorName,
                Skill = request.Skill,
                Expertise = request.Expertise,
                ScheduleId = request.ScheduleId,
                BookingLimited = request.BookingLimited
            };

            return result;
        }

    }
}
