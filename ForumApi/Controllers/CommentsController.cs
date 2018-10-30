using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumApi.Models;
using ForumApi.Models.DTO.CommentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ForumContext context;
        public CommentsController(ForumContext context)
        {
            this.context = context;
            if (context.Comments.Count() == 0)
            {
                context.Comments.Add(new Comment()
                {
                    Post = context.Posts.Find(1),
                    User = context.Users.Find(2),
                    Content = "Nice!"
                });
                context.Comments.Add(new Comment()
                {
                    Post = context.Posts.Find(1),
                    User = context.Users.Find(3),
                    Content = "Super fedt!, her er lige en kommentar mere :))"
                });
                context.Comments.Add(new Comment()
                {
                    Post = context.Posts.Find(1),
                    User = context.Users.Find(2),
                    Content = "Og aftenens sidste kommentar"
                });

                context.SaveChanges();
            }
        }
        // GET: api/Comments
        [HttpGet]
        public IActionResult Get()
        {
            var res = context.Comments
                                .Include(p => p.Post)
                                .Include(u => u.User);

            return Ok(Comment.CommentToDTO(res.ToList()));
        }

        // GET: api/Comments/5
        [HttpGet("{id}", Name = "GetComments")]
        public IActionResult Get(int id)
        {
            var res = context.Comments
                                .Where(c => c.CommentId == id)
                                .Include(u => u.User)
                                .Include(p => p.Post).FirstOrDefault();

            if (res != null)
            {
                return Ok(Comment.CommentToDTO(res));
            }

            return BadRequest("Couldnt find your comment");
        }

        // POST: api/Comments
        [HttpPost]
        public IActionResult Post([FromBody] Comment_CommentDTO value)
        {
            var user = context.Users.Find(value.User.UserId);
            var post = context.Posts.Find(value.PostID);
            if (user == null || post == null)
            {
                return BadRequest("A comment needs a post and a user");
            }

            try
            {
                var newComment = new Comment()
                {
                    Post = post,
                    User = user,
                    Content = value.Content,
                    PostDate = DateTime.Now
                };
                context.Comments.Add(newComment);

                context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comment_CommentDTO value)
        {
            var commentToUpdate = context.Comments.Find(value.CommentId);

            if (commentToUpdate == null)
            {
                return BadRequest("The comment doesnt exists, cant update");
            }

            try
            {
                commentToUpdate.Content = value.Content;

                context.Comments.Update(commentToUpdate);

                context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comment = context.Comments.Find(id);

            if (comment == null)
            {
                BadRequest("The post doesnt exist");
            }

            context.Comments.Remove(comment);
            context.SaveChanges();
            return NoContent();
        }


    }
}
