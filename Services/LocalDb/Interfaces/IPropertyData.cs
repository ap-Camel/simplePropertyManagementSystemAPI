using simplePropertyManagementSystemAPI.Dtos.PropertyDtos;
using simplePropertyManagementSystemAPI.Models;

namespace simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces {
    public interface IPropertyData
    {
        Task<bool> deletePropertyAsync(int propertyID, int userID);
        Task<List<Property>> getPropertiesAsync(int userID);
        Task<Property> getPropertyByPropertyIdAsync(int propertyID, int userID);
        Task<int> insertPropertyAsync(PropertyInsertDto property, int userID);
        Task<bool> updatePropertyAsync(PropertyUpdateDto property, int userID);
    }
}