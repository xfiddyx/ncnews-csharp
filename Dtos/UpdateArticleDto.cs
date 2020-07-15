using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Dtos
{
    public class UpdateArticleDto
    {

        [Required]
        public string topic { get; set; }

        [Required]
        public string title { get; set; }


        [Required]
        public string author { get; set; }

        [Required]
        [MaxLength(2000)]
        public string body { get; set; }

    }
}
