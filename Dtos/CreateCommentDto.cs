using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Dtos
{
    public class CreateCommentDto
    {

        [Required]
        public string articles_id { get; set; }

        [Required]
        public string belongs_to { get; set; }

        [Required]

        [MaxLength(1500)]
        public string body { get; set; }

        public string created_at

        { get; set; } = DateTime.Now.ToString("dddd, dd MMMM yyyy");

        public int votes { get; set; } = 0;
    }
}
