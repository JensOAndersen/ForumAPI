using ForumApi.Models.DTO.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Models.PostDTOs
{
    public class Post_PostDTO : BasePostDTO
    {
        public List<BaseCommentDTO> Comments { get; set; }
    }
}
