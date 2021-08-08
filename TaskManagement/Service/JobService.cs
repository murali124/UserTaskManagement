using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Core;
using TaskManagement.Model;
using TaskManagement.Repository;

namespace TaskManagement.Service
{
    public class JobService : IJobService
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
        }

        public async Task<IEnumerable<object>> GetUserJobMappingAsync()
        {
            var userJobMapping = await _jobRepository.GetUserJobMappingAsync();
            var job = await _jobRepository.GetJobDetailsAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(await GetUserDetailsAsync(userJobMapping.Select(e => e.UserId)));
            var userTaskmapping = from m in userJobMapping
                          join j in job on m.JobId equals j.JobId
                          select new { j.JobId, j.Title, j.Description, m.UserId } into jb
                          join u in users on jb.UserId equals u.Id
                          select new { JobId = jb.JobId, JobTitle = jb.Title, JobDescription = jb.Description, UserId = u.Id, UserCode = u.Code, UserName = u.Name };

            return userTaskmapping;
        }
        public async Task<string> GetUserDetailsAsync(IEnumerable<int> userId)
        {
            //to-do - url shuld be in config file
            var result = await HttpService.GetAsync("https://localhost:44312/api/getUserDetailsById", new Dictionary<string, string>(), JsonConvert.SerializeObject(userId));
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}