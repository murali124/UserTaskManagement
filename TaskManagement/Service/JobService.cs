using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Model;
using TaskManagement.Repository;

namespace TaskManagement.Service
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetJobDetailsAsync();
        Task<int> SaveJobDetailsAsync(Job job);
        Task<int> UpdateJobDetailsAsync(Job job);
        Task<int> DeleteJobDetailsAsync(int jobId);
        Task UserJobMappingAsync(List<JobUserMapping> jobUserMapping);
    }

    public class JobService: IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<Job>> GetJobDetailsAsync()
        {
            return await _jobRepository.GetJobDetailsAsync();
        }

        public async Task<int> SaveJobDetailsAsync(Job job)
        {
            return await _jobRepository.SaveJobDetailsAsync(job);
        }

        public async Task<int> UpdateJobDetailsAsync(Job job)
        {
            return await _jobRepository.UpdateJobDetailsAsync(job);
        }
        public async Task<int> DeleteJobDetailsAsync(int jobId)
        {
            return await _jobRepository.DeleteJobDetailsAsync(jobId);
        }

        public async Task UserJobMappingAsync(List<JobUserMapping> jobUserMappings)
        {
            await Task.Run(() => jobUserMappings.Select(jobUserMapping => _jobRepository.UserJobMappingAsync(jobUserMapping)));

            //foreach (var jobUserMapping in jobUserMappings)
            //{
            //    await _jobRepository.UserJobMappingAsync(jobUserMapping);
            //}
        }
    }
}
