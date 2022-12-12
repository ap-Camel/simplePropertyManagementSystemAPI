using simplePropertyManagementSystemAPI.Dtos;
using simplePropertyManagementSystemAPI.Dtos.TenantDtos;
using simplePropertyManagementSystemAPI.Models;
using simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces;

namespace simplePropertyManagementSystemAPI.Services.LocalDb.Tables {

    public class TenantData : ITenantData
    {

        private readonly ISqlDataAccess _db;

        public TenantData(ISqlDataAccess db)
        {
            _db = db;
        }


        public async Task<List<Tenant>> getTenantsAsync(int userID)
        {

            string sql = $"select * from tenant where systemUserID = {userID}";

            return await _db.LoadMany<Tenant>(sql);
        }


        public async Task<Tenant> getTenantAsync(int tenantID, int userID)
        {
            string sql = $"select top 1 * from tenant where systemUserID = {userID} and ID = {tenantID}";

            return await _db.LoadSingle<Tenant>(sql);
        }


        public async Task<int> insertTenantAsync(TenantInsertDto tenant, int userID)
        {

            string sql = $"insert into tenant output inserted.id values ('{tenant.firstName}', '{tenant.lastName}', '{tenant.contactNumber}', '{tenant.email}', '{tenant.IdNumber}', '{tenant.nationality}', '{tenant.tenantDescription}',  {Convert.ToInt16(tenant.tenantStatus)}, default, default, {tenant.propertyID}, {userID});";

            return await _db.insertDataWithReturn(sql);
        }

        public async Task<bool> updateTenantAsync(TenantUpdateDto tenant, int userID)
        {

            string sql = $"update tenant set  firstName = '{tenant.firstName}', lastName = '{tenant.lastName}', contactNumber = '{tenant.contactNumber}', email = '{tenant.email}', IdNumber = '{tenant.IdNumber}', nationality = '{tenant.nationality}', tenantDescription = '{tenant.tenantDescription}', tenantStatus = {Convert.ToInt16(tenant.tenantStatus)}, dateUpdated = getDate() where propertyID = {tenant.ID} and systemUserID = {userID};";

            return await _db.insertData(sql);
        }

        public async Task<bool> deleteTenantAsync(int tenantID, int userID)
        {

            string sql = $"delete from tenant where ID = {tenantID} and systemUserID = {userID}";

            return await _db.insertData(sql);
        }
    }
}