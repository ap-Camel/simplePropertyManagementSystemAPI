using simplePropertyManagementSystemAPI.Dtos.SystemUserDtos;
using simplePropertyManagementSystemAPI.Models;

namespace simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces {
    public interface ISystemUserData
    {
        Task<bool> deleteSystemUserAsync(int id);
        Task<SystemUser> getSystemUserByIdAsync(int id);
        Task<int> insertUserAsync(SystemUserSignupDto user, string pass);
        Task<bool> updateSystemUserAsync(SystemUserUpdateDto updateUser, int id);
        Task<SystemUser> verifyEmailAsync(string email);
        Task<SystemUser> verifyUserAsync(string email, string password);
    }
}