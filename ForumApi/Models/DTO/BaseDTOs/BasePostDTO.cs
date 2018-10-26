using ForumApi.Models.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Models.DTO.BaseDTOs
{
    public class BasePostDTO
    {
        public int PostId { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }
        public BaseUserDTO User { get; set; }
        public string Title { get; set; }
    }
}
