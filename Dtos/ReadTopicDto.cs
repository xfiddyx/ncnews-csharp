using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Dtos
{
    public class ReadTopicDto
    {
        [Required]
        public string slug { get; set; }

        [Required]
        public string description { get; set; }

    }
}
