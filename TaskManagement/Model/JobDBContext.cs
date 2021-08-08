using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;

namespace UserManagement.Model
{
  public class JobDBContext : DbContext
  {
    public JobDBContext(DbContextOptions<JobDBContext> options) : base(options) { }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobUserMapping> JobUserIdMapping { get; set; }
    //public DbSet<JobUserMapping> JobUserMapping { get; set; }
  }
}
