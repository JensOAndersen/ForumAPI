﻿using System;

namespace ForumApi.Models.DTO.BaseDTOs
{
    public class BaseUserDTO
    {
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public int PostCount { get; set; }
        public int CommentCount { get; set; }
    }
}