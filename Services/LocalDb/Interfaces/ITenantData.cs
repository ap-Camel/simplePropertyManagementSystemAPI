using simplePropertyManagementSystemAPI.Dtos;
using simplePropertyManagementSystemAPI.Dtos.TenantDtos;
using simplePropertyManagementSystemAPI.Models;

namespace simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces {
    public interface ITenantData
    {
        Task<bool> deleteTenantAsync(int tenantID, int userID);
        Task<Tenant> getTenantAsync(int tenantID, int userID);
        Task<List<Tenant>> getTenantsAsync(int userID);
        Task<int> insertTenantAsync(TenantInsertDto tenant, int userID);
        Task<bool> updateTenantAsync(TenantUpdateDto tenant, int userID);
    }
}