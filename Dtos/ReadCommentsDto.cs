using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Dtos
{
    public class ReadCommentsDto
    {
        public int id { get; set; }

        [Required]
        public string articles_id { get; set; }

        [Required]
        [MaxLength(1500)]
        public string body { get; set; }

        [Required]
        public string belongs_to { get; set; }

        [Required]
        public string created_at

        { get; set; }

        [Required]
        public int votes { get; set; } = 0;

    }
}
