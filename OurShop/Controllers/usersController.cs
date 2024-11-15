using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        IUserService _userService;

        public usersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<usersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<usersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User checkUser = _userService.getUserById(id);
            if(checkUser != null)
                return Ok(checkUser);
            else
                return NotFound();
        }

        // POST api/<usersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                _userService.addUser(user);
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
            catch(Exception e)
            {
                return BadRequest();
            }

        }

        [HttpPost("login")]
        public ActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            User checkUser = _userService.login(email, password);
            if (checkUser != null)
                return Ok(checkUser);
            else
                return NotFound();

        }

        [HttpPost("passwordStrength")]
        public ActionResult<int> CheckPasswordStrength([FromQuery] string password)
        {
            int passwordStrength = _userService.checkPasswordStrength(password);
            return Ok(passwordStrength);

        }

        // PUT api/<usersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userToUpdate)
        {
            User checkUser = _userService.updateUser(id, userToUpdate);
            if (checkUser != null)
                return Ok(userToUpdate);
            else
            return BadRequest();

        }

        // DELETE api/<usersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
