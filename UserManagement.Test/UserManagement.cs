using System;
using System.Threading.Tasks;
using UserManagement.Controllers;
using UserManagement.Model;
using UserManagement.Repository;
using UserManagement.Service;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace UserManagement.Test
{
    public class UserManagement
    {
        private readonly UserController _userController;

        public UserManagement()
        {
            var services = new ServiceCollection();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            var serviceProvider = services.BuildServiceProvider();

            var _userService = serviceProvider.GetService<IUserService>();
            _userController = new UserController(_userService);
        }

        [Fact]
        public async Task ShouldNotReturnNullAsync()
        {
            var _statusCode = await _userController.GetUserDetailsAsync();
            Assert.NotNull(_statusCode.Value);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfNullFromSaveRequestAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _userController.SaveUserDetailsAsync(null));
        }

        [Fact]
        public async Task ShouldStoreUserObjectAndReturnSuccessAsync()
        {
            var _user = new User { Name = "UserName", Code = "UserCode", Address = "UserAddress", PhoneNumber = "+919867" };

            var result = await _userController.SaveUserDetailsAsync(_user);

            var success = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;

            Assert.Equal("Success", success);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfNullFromUpdateRequestAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _userController.UpdateUserDetailsAsync(null));
        }

        [Fact]
        public async Task ShouldUpdateUserObjectAndReturnSuccessAsync()
        {
            var _user = new User { Id = 3, Name = "UserName3", Code = "UserCode3", Address = "UserAddress", PhoneNumber = "+919867" };

            var result = await _userController.UpdateUserDetailsAsync(_user);

            var success = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;

            Assert.Equal("Success", success);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfLessThanOneFromUpdateRequestAsync()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _userController.DeleteUserDetailsAsync(0));
        }

        [Fact]
        public async Task ShouldDeActivateUserObjectAndReturnSuccessAsync()
        {
            var result = await _userController.DeleteUserDetailsAsync(10);

            var success = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;

            Assert.Equal("Success", success);
        }
    }
}
