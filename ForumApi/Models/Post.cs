using ForumApi.Models.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }


        public static Post_PostDTO PostToDTO(Post post)
        {
            return new Post_PostDTO
            {
                Content = post.Content,
                PostDate = post.PostDate,
                PostId = post.PostId,
                User = Models.User.UserToDTO(post.User),
                Comments = Comment.CommentToDTO(post.Comments)
            };
        }

        public static ICollection<Post_PostDTO> PostsToDTO(ICollection<Post> posts)
        {
            var res = from post in posts
                      select PostToDTO(post);

            return res.ToList();
        }
    }
}
