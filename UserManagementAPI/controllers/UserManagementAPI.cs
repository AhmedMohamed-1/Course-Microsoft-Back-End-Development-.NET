using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly ConcurrentDictionary<string, User> users = new ConcurrentDictionary<string, User>();

        [HttpGet]
        public IActionResult GetUsers([FromQuery] string? id)
        {
            if (id != null)
            {
                if (users.TryGetValue(id, out var user))
                {
                    return Ok(user);
                }
                return NotFound(new { error = "User not found" });
            }
            return Ok(users.Values);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (users.ContainsKey(user.Id))
            {
                return BadRequest(new { error = "User already exists" });
            }
            users[user.Id] = user;
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, new { message = "User added successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, User updatedUser)
        {
            if (!users.ContainsKey(id))
            {
                return NotFound(new { error = "User not found" });
            }
            users[id] = updatedUser;
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            if (!users.TryRemove(id, out var _))
            {
                return NotFound(new { error = "User not found" });
            }
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
