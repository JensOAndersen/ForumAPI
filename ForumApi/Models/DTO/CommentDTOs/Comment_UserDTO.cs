using ForumApi.Models.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Models.DTO.CommentDTOs
{
    public class Comment_UserDTO : BaseDTOs.BaseUserDTO
    {
        public int CommentId { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }
        public Post_UserDTO User { get; set; }
    }
}
