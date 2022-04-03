using Business.IServices;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService experienceService;
        public ExperienceController(IExperienceService _experienceService)
        {
            experienceService = _experienceService;
        }

        [HttpGet]
        public IActionResult GetAllExperience()
        {
            try
            {
                var experiences = experienceService.GetAllExperience();
                return Ok(experiences);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetExperienceById(int id)
        {
            try
            {
                var experience = experienceService.GetExperienceById(id);
                return Ok(experience);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] Experience experience)
        {
            try
            {
                experienceService.AddExperience(experience);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateExperience([FromBody] Experience experience)
        {
            try
            {
                experienceService.UpdateExperience(experience);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExperience(int id)
        {
            try
            {
                experienceService.DeleteExperience(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
