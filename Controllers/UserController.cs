using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleUserAPI.Data;
using SimpleUserAPI.Models;

namespace SimpleUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext dbContext;

        public UserController(UserContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            var allUsers = dbContext.Users.ToList();
                return Ok(allUsers);
        }

        // GET: api/User/1
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var userEntity = new User()
            {
                Name = addUserDto.Name,
                Email = addUserDto.Email

            };
            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();
            return Ok(userEntity);
        }

        // PUT: api/User/1
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var updatedUser = dbContext.Users.Find(id);
            if (updatedUser == null)
            {
                return NotFound();
            }
            updatedUser.Name = updateUserDto.Name;
            updatedUser.Email = updateUserDto.Email;

            //dbContext.Entry(updateUserDto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return Ok(updatedUser);
        }

        // DELETE: api/User/1
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}

