using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Model;

namespace UserManagement.Repository
{
  public class UserRepository : IUserRepository
  {

    UserDBContext _userDBContext;

    public UserRepository(UserDBContext userDBContext)
    {
      _userDBContext = userDBContext;
    }
    public async Task<IEnumerable<User>> GetUserDetailsAsync() => await _userDBContext.Users.ToListAsync();

    public async Task<int> SaveUserDetailsAsync(User user)
    {
      _userDBContext.Users.Add(user);
      return await _userDBContext.SaveChangesAsync();
    }

    public async Task<int> UpdateUserDetailsAsync(User user)
    {
      _userDBContext.Users.Update(user);
      return await _userDBContext.SaveChangesAsync();
    }

    public async Task<int> DeleteUserDetailsAsync(int userId)
    {
      var usr = new User() { UserId = userId };

      _userDBContext.Users.Remove(usr);
      return await _userDBContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetUserDetailsByIdAsync(IEnumerable<int> userId) =>
      await _userDBContext.Users.Where(e => userId.Contains(e.UserId)).ToListAsync();
  }
}