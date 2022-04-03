using Business.IServices;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService educationService;
        public EducationController(IEducationService _educationService)
        {
            educationService = _educationService;
        }

        [HttpGet]
        public IActionResult GetAllEducation()
        {
            try
            {
                var educations = educationService.GetAllEducation();
                return Ok(educations);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetEducationById(int id)
        {
            try
            {
                var education = educationService.GetEducationById(id);
                return Ok(education);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddEducation([FromBody] Education education)
        {
            try
            {
                educationService.AddEducation(education);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateEducation([FromBody] Education education)
        {
            try
            {
                educationService.UpdateEducation(education);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEducation(int id)
        {
            try
            {
                educationService.DeleteEducation(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
