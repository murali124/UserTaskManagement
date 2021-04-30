using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Model;

namespace UserManagement.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUserDetailsAsync();
        Task<int> SaveUserDetailsAsync(User user);
        Task<int> UpdateUserDetailsAsync(User user);
        Task<int> DeleteUserDetailsAsync(int userId);

    }

    public class UserRepository : IUserRepository
    {
        const string dbConnection = "Server=localhost;Port=3306;Database=userdb;User=root;Password=Mysql@12345";
        //const string dbConnection = Configuration.GetConnectionString("UserDbConnection");

        public async Task<IEnumerable<User>> GetUserDetailsAsync()
        {
            using (var connection = new MySqlConnection(dbConnection))
            {
                return await connection.QueryAsync<User>("SELECT * FROM users");
            }
        }

        public async Task<int> SaveUserDetailsAsync(User user)
        {
            using (var connection = new MySqlConnection(dbConnection))
            {
                string insertQuery = @"INSERT INTO Users(Code, Name, Address, PhoneNumber) VALUES (@Code, @Name, @Address, @PhoneNumber)";

                var result = await connection.ExecuteAsync(insertQuery, new
                {
                    user.Code,
                    user.Name,
                    user.Address,
                    user.PhoneNumber
                });

                return result;
            }
        }

        public async Task<int> UpdateUserDetailsAsync(User user)
        {
            using (var connection = new MySqlConnection(dbConnection))
            {
                string updateQuery = @"UPDATE Users SET Name=@Name, Address=@Address, PhoneNumber=@PhoneNumber WHERE Id = @Id";

                var result = await connection.ExecuteAsync(updateQuery, new
                {
                    user.Name,
                    user.Address,
                    user.PhoneNumber,
                    user.Id
                });

                return result;
            }
        }
        public async Task<int> DeleteUserDetailsAsync(int userId)
        {
            using (var connection = new MySqlConnection(dbConnection))
            {
                string updateQuery = @"UPDATE Users SET IsActive=@IsActive WHERE Id = @userId";

                var result = await connection.ExecuteAsync(updateQuery, new
                {
                    IsActive = 0,
                    userId
                });

                return result;
            }
        }
    }
}

