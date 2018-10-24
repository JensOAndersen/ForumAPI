using System;

namespace ForumApi.Models.DTO.BaseDTOs
{
    public class BaseCommentDTO
    {
        public int PostID { get; set; }
        public int CommentId { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }
        public BaseUserDTO User { get; set; }
    }
}