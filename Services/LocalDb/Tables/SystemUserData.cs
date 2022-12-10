using simplePropertyManagementSystemAPI.Dtos.SystemUserDtos;
using simplePropertyManagementSystemAPI.Helpers;
using simplePropertyManagementSystemAPI.Models;
using simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces;

namespace simplePropertyManagementSystemAPI.Services.LocalDb.Tables {

    public class SystemUserData : ISystemUserData
    {

        private readonly ISqlDataAccess _db;

        public SystemUserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<SystemUser> verifyUserAsync(string email, string password)
        {

            string hashedPass = await Hashing.hash(password);

            string sql = $"select top 1 * from systemUser where email = '{email}' and userPassword = '{hashedPass}'";

            return await _db.LoadSingle<SystemUser>(sql);
        }

        public async Task<SystemUser> verifyEmailAsync(string email)
        {

            string sql = $"select top 1 * from systemUser where email = '{email}'";

            return await _db.LoadSingle<SystemUser>(sql);
        }

        public async Task<int> insertUserAsync(SystemUserSignupDto user, string pass)
        {

            string sql = $"insert into systemUser output inserted.id values ('{user.firstName}', '{user.lastName}', '{user.email}', '{pass}', default)";

            return await _db.insertDataWithReturn(sql);
        }

        public async Task<SystemUser> getSystemUserByIdAsync(int id)
        {

            string sql = $"select top 1 * from systemUser where ID = {id}";

            return await _db.LoadSingle<SystemUser>(sql);
        }

        public async Task<bool> updateSystemUserAsync(SystemUserUpdateDto updateUser, int id)
        {

            string sql = $"update systemUser set firstName = '{updateUser.firstName}', lastName = '{updateUser.lastName}'";

            return await _db.insertData(sql);
        }

        public async Task<bool> deleteSystemUserAsync(int id)
        {

            string sql = $"delete from systemUser where ID = {id}";

            return await _db.insertData(sql);
        }
    }
}