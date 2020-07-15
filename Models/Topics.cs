using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Models
{
    public class Topics
    {

        [Key]
        public int id { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string slug { get; set; }

    }
}
