using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Model
{
  public class JobUserMapping
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int JobUserId { get; set; }
    public int JobId { get; set; }
    public string JobName { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedDate { get; set; }
  }
}
