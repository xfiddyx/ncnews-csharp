using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Dtos
{
    public class UpdateUserDto
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string avatar_url { get; set; }

        [Required]
        public string name { get; set; }


    }
}
