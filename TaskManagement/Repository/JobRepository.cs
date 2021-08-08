//using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Model;
using UserManagement.Model;

namespace TaskManagement.Repository
{
  public class JobRepository : IJobRepository
  {
    JobDBContext _jobDBContext;

    public JobRepository(JobDBContext userDBContext)
    {
      _jobDBContext = userDBContext;
    }

    public async Task<IEnumerable<Job>> GetJobDetailsAsync() => await _jobDBContext.Jobs.ToListAsync();

    public async Task<int> SaveJobDetailsAsync(Job job)
    {
      _jobDBContext.Jobs.Add(job);
      return await _jobDBContext.SaveChangesAsync();
    }

    public async Task<int> UpdateJobDetailsAsync(Job job)
    {
      _jobDBContext.Jobs.Update(job);
      return await _jobDBContext.SaveChangesAsync();
    }

    public async Task<int> DeleteJobDetailsAsync(int JobId)
    {
      var job = new Job() { JobId = JobId };

      _jobDBContext.Jobs.Remove(job);
      return await _jobDBContext.SaveChangesAsync();
    }

    public async Task<int> UserJobMappingAsync(JobUserMapping jobUserMapping)
    {
      _jobDBContext.JobUserIdMapping.Add(jobUserMapping);
      return await _jobDBContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<JobUserMapping>> GetUserJobMappingAsync() => await _jobDBContext.JobUserIdMapping.ToListAsync();
  }
}
