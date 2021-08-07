using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Model;

namespace TaskManagement.Repository
{
  public interface IJobRepository
  {
    Task<IEnumerable<Job>> GetJobDetailsAsync();
    Task<int> SaveJobDetailsAsync(Job job);
    Task<int> UpdateJobDetailsAsync(Job job);
    Task<int> DeleteJobDetailsAsync(int JobId);
    Task<int> UserJobMappingAsync(JobUserIdMapping jobUserMapping);
    Task<IEnumerable<JobUserMapping>> GetUserJobMappingAsync();
  }
}
