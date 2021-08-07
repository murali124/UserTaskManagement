using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Model;
using UserManagement.Repository;

namespace UserManagement.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUserDetailsAsync() =>
            await _userRepository.GetUserDetailsAsync();
        

        public async Task<int> SaveUserDetailsAsync(User user) =>        
            await _userRepository.SaveUserDetailsAsync(user);
        
        public async Task<int> UpdateUserDetailsAsync(User user) =>        
            await _userRepository.UpdateUserDetailsAsync(user);
        
        public async Task<int> DeleteUserDetailsAsync(int userId) =>        
            await _userRepository.DeleteUserDetailsAsync(userId);
        
        public async Task<IEnumerable<User>> GetUserDetailsByIdAsync(IEnumerable<int> userId) =>
            await _userRepository.GetUserDetailsByIdAsync(userId);
        
    }
}
