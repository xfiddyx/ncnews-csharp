using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Models
{
    public class Comments
    {

        [Key]
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


        { get; set; } = DateTime.Now.ToString("dddd, dd MMMM yyyy");

        [Required]
        public int votes { get; set; } = 0;

    }
}
