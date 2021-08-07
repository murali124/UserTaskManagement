using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Model;

namespace TaskManagement.Service
{
  public interface IJobService
  {
    Task<IEnumerable<Job>> GetJobDetailsAsync();
    Task<int> SaveJobDetailsAsync(Job job);
    Task<int> UpdateJobDetailsAsync(Job job);
    Task<int> DeleteJobDetailsAsync(int jobId);
    Task UserJobMappingAsync(List<JobUserIdMapping> jobUserMapping);
    Task<IEnumerable<object>> GetUserJobMappingAsync();
  }
}