using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TaskManagement.Model;

namespace TaskManagement.Repository
{
    public class JobRepository : IJobRepository
    {
        const string dbConnection = "Host=localhost;Username=postgres;Password=Post@123;Database=testdb";

        public async Task<IEnumerable<Job>> GetJobDetailsAsync()
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                return await connection.QueryAsync<Job>("SELECT * FROM Job");
            }
        }

        public async Task<int> SaveJobDetailsAsync(Job job)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                string insertQuery = @"INSERT INTO Job(Title, Description, Status) VALUES (@Title, @Description, @Status)";

                var result = await connection.ExecuteAsync(insertQuery, new
                {
                    job.Title,
                    job.Description,
                    job.Status
                });

                return result;
            }
        }

        public async Task<int> UpdateJobDetailsAsync(Job job)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                string updateQuery = @"UPDATE Job SET Title=@Title, Description=@Description, Status=@Status WHERE Id = @Id";

                var result = await connection.ExecuteAsync(updateQuery, new
                {
                    job.Title,
                    job.Description,
                    job.Status
                });

                return result;
            }
        }

        public async Task<int> DeleteJobDetailsAsync(int JobId)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                string updateQuery = @"UPDATE Job SET IsActive=@IsActive WHERE Id = @JobId";

                var result = await connection.ExecuteAsync(updateQuery, new
                {
                    IsActive = 0,
                    JobId
                });

                return result;
            }
        }

        public async Task<int> UserJobMappingAsync(JobUserIdMapping jobUserMapping)
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                string insertQuery = @"INSERT INTO TaskUserMapping(TaskId, UserId) VALUES (@JobId, @UserId)";

                var result = await connection.ExecuteAsync(insertQuery, new
                {
                    jobUserMapping.JobId,
                    jobUserMapping.UserId
                });

                return result;
            }
        }

        public async Task<IEnumerable<JobUserMapping>> GetUserJobMappingAsync()
        {
            using (var connection = new NpgsqlConnection(dbConnection))
            {
                return await connection.QueryAsync<JobUserMapping>("SELECT TaskId, UserId FROM TaskUserMapping where isactive = 1");
            }
        }
    }
}
