using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly ConcurrentDictionary<string, User> users = new ConcurrentDictionary<string, User>();

        // GET: Retrieve a list of users or a specific user by ID
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

        // POST: Add a new user
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (users.ContainsKey(user.Id))
            {
                return BadRequest(new { error = "User already exists" });
            }
            users[user.Id] = user;
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, new { message = "User added successfully" });
        }

        // PUT: Update an existing user's details
        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!users.ContainsKey(id))
            {
                return NotFound(new { error = "User not found" });
            }
            users[id] = updatedUser;
            return Ok(new { message = "User updated successfully" });
        }

        // DELETE: Remove a user by ID
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
