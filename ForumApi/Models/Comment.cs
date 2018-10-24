using ForumApi.Models.DTO.BaseDTOs;
using ForumApi.Models.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }

        public static List<BaseCommentDTO> CommentToDTO(ICollection<Comment> comments)
        {
            var res = from c in comments
                      select CommentToDTO(c);
                      //new Post_CommentDTO()
                      //{
                      //    PostID = c.Post.PostId,
                      //    CommentId = c.CommentId,
                      //    PostDate = c.PostDate,
                      //    Content = c.Content,
                      //    User = User.UserToDTO(c.User)
                      //};
            return new List<BaseCommentDTO>(res);
        }

        public static Post_CommentDTO CommentToDTO(Comment comment)
        {
            return new Post_CommentDTO()
            {
                PostID = comment.Post.PostId,
                CommentId = comment.CommentId,
                PostDate = comment.PostDate,
                Content = comment.Content,
                User = User.UserToDTO(comment.User)
            };
        }
    }
}

