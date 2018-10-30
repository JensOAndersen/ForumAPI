using ForumApi.Models.DTO.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Models.DTO.LoginDTOs
{
    public class Login_UserDTO : BaseUserDTO
    {
        string Password { get; set; }
    }
}
