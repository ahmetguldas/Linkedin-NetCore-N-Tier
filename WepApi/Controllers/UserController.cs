using Business.IServices;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                var users = userService.GetAllUser();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                userService.AddUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public class UploadData
        {
            public IFormFile image { get; set; }
            public int id { get; set; }
        }

        [HttpPost("ImageUpload")]
        public IActionResult ImageUpload([FromForm] UploadData data)
        {
            var file = data.image;
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                userService.UpdateUserImage(dbPath, data.id);
                return Ok(new { dbPath });
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
