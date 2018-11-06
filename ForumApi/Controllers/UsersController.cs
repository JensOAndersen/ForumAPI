using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumApi.Models;
using ForumApi.Models.DTO.BaseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ForumContext context;
        public UsersController(ForumContext context)
        {
            this.context = context;

            if (context.Users.Count() == 0)
            {
                context.Users.Add(new User() {
                    CreationDate = DateTime.Now,
                    Name = "Jens-Ole"
                });
                context.Users.Add(new User()
                {
                    CreationDate = DateTime.Now.AddDays(-5),
                    Name = "Hans Kristian"
                });
                context.Users.Add(new User()
                {
                    CreationDate = DateTime.Now.AddDays(-2),
                    Name = "Karl Børge"
                });

                context.SaveChanges();
            }
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            var res = from u in context.Users
                      select new BaseUserDTO
                      {
                          CreationDate = u.CreationDate,
                          Name = u.Name,
                          UserId = u.UserId,
                          CommentCount = context.Comments.Where(c => c.User.UserId == u.UserId).Count(),
                          PostCount = context.Posts.Where(p => p.User.UserId == u.UserId).Count()
                      };


            return Ok(res);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id)
        {


            var item = context.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(new BaseUserDTO()
            {
                CreationDate = item.CreationDate,
                Name = item.Name,
                UserId = item.UserId,
                CommentCount = context.Comments.Where(c => c.User.UserId == item.UserId).Count(),
                PostCount = context.Posts.Where(p => p.User.UserId == item.UserId).Count()

            });
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
