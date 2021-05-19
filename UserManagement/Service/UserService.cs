using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Model;
using UserManagement.Repository;

namespace UserManagement.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUserDetailsAsync();
        Task<int> SaveUserDetailsAsync(User user);
        Task<int> UpdateUserDetailsAsync(User user);
        Task<int> DeleteUserDetailsAsync(int userId);
        Task<IEnumerable<User>> GetUserDetailsByIdAsync(IEnumerable<int> userId);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUserDetailsAsync()
        {
            return await _userRepository.GetUserDetailsAsync();
        }

        public async Task<int> SaveUserDetailsAsync(User user)
        {
            return await _userRepository.SaveUserDetailsAsync(user);
        }

        public async Task<int> UpdateUserDetailsAsync(User user)
        {
            return await _userRepository.UpdateUserDetailsAsync(user);
        }
        public async Task<int> DeleteUserDetailsAsync(int userId)
        {
            return await _userRepository.DeleteUserDetailsAsync(userId);
        }
        public async Task<IEnumerable<User>> GetUserDetailsByIdAsync(IEnumerable<int> userId)
        {
            return await _userRepository.GetUserDetailsByIdAsync(userId);
        }
    }
}
