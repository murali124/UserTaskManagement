using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TaskManagement.Controllers;
using TaskManagement.Model;
using TaskManagement.Repository;
using TaskManagement.Service;
using Xunit;

namespace TaskManagement.Test
{
    public class TaskManagement
    {
        private readonly JobController _jobController;
        public TaskManagement()
        {
            var services = new ServiceCollection();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IJobRepository, JobRepository>();

            var serviceProvider = services.BuildServiceProvider();

            var _jobService = serviceProvider.GetService<IJobService>();
            _jobController = new JobController(_jobService);
        }

        [Fact]
        public async Task ShouldNotReturnNullAsync()
        {
            var _statusCode = await _jobController.GetTaskDetailsAsync();
            Assert.NotNull(_statusCode.Value);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfNullFromSaveRequestAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _jobController.SaveJobDetailsAsync(null));
        }

        [Fact]
        public async Task ShouldStoreUserObjectAndReturnSuccessAsync()
        {
            var _job = new Job { Title = "JobTitle", Description="JobDescription", Status="JobStatus" };

            var result = await _jobController.SaveJobDetailsAsync(_job);

            var success = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;

            Assert.Equal("Success", success);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfNullFromUpdateRequestAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _jobController.UpdateJobDetailsAsync(null));
        }

        [Fact]
        public async Task ShouldUpdateUserObjectAndReturnSuccessAsync()
        {
            var _job = new Job { Title = "JobTitle1", Description = "JobDescription1", Status = "JobStatus1" };

            var result = await _jobController.UpdateJobDetailsAsync(_job);

            var success = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;

            Assert.Equal("Success", success);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfLessThanOneFromUpdateRequestAsync()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _jobController.DeleteJobDetailsAsync(0));
        }

        [Fact]
        public async Task ShouldDeActivateUserObjectAndReturnSuccessAsync()
        {
            var result = await _jobController.DeleteJobDetailsAsync(10);

            var success = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;

            Assert.Equal("Success", success);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfNullFromUserJobMappingRequestAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _jobController.UserJobMappingAsync(null));
        }



    }
}
