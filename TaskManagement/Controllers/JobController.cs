using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Model;
using TaskManagement.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Controllers
{
    [Authorize]
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        [Route("getTaskDetails")]
        public async Task<JsonResult> GetTaskDetailsAsync()
        {
            var result = await _jobService.GetJobDetailsAsync();
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("saveJobDetails")]
        public async Task<ActionResult> SaveJobDetailsAsync(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            var result = await _jobService.SaveJobDetailsAsync(job);
            return result == 1 ? Ok("Success") : BadRequest("Not Success");
        }

        [HttpPut]
        [Route("updateJobDetails")]
        public async Task<ActionResult> UpdateJobDetailsAsync(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            var result = await _jobService.UpdateJobDetailsAsync(job);
            return result == 1 ? Ok("Success") : BadRequest("Not Success");
        }

        [HttpPut]
        [Route("deleteJobDetails/{jobId:Int}")]
        public async Task<ActionResult> DeleteJobDetailsAsync(int jobId)
        {
            if (jobId < 1)
            {
                throw new ArgumentException(nameof(jobId));
            }

            var result = await _jobService.DeleteJobDetailsAsync(jobId);
            return result == 1 ? Ok("Success") : BadRequest("Not Success");
        }

        [HttpPost]
        [Route("userTaskMapping")]
        public async Task UserJobMappingAsync(List<JobUserMapping> jobUserMapping)
        {
            if (jobUserMapping == null)
            {
                throw new ArgumentNullException(nameof(jobUserMapping));
            }

            await _jobService.UserJobMappingAsync(jobUserMapping);
        }

        [HttpPost]
        [Route("getUserTaskMapping")]
        public async Task<IEnumerable<object>> GetUserJobMappingAsync()
        {
           return await _jobService.GetUserJobMappingAsync();
        }
    }
}
