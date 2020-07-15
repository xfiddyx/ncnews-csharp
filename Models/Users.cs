using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string avatar_url { get; set; }

    }
}
