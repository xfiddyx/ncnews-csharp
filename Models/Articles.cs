using System;
using System.ComponentModel.DataAnnotations;

namespace NcNews.Models
{
 public class Articles
 {
  [Key]

  public int id { get; set; }

  [Required]
  public string topic { get; set; }

  [Required]
  public string title { get; set; }


  [Required]
  public string author { get; set; }

  [Required]
  [MaxLength(2000)]
  public string body { get; set; }

  [Required]
  public string created_at

  { get; set; } = DateTime.Now.ToString("dddd, dd MMMM yyyy");

  public int votes { get; set; } = 0;
 }
}
