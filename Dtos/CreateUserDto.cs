using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string avatar_url { get; set; }

    }
}
