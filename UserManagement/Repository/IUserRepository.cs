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
    Task<IEnumerable<User>> GetUserDetailsByIdAsync(IEnumerable<int> userId);
  }
}