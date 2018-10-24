using ForumApi.Models.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name{ get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public static Post_UserDTO UserToDTO(User user)
        {
            return new Post_UserDTO
            {
                UserId = user.UserId,
                CreationDate = user.CreationDate,
                Name = user.Name
            };
        }
    }
}
