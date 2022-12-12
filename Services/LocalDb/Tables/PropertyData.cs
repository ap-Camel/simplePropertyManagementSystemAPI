using simplePropertyManagementSystemAPI.Dtos.PropertyDtos;
using simplePropertyManagementSystemAPI.Models;
using simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces;

namespace simplePropertyManagementSystemAPI.Services.LocalDb.Tables {

    public class PropertyData : IPropertyData
    {

        private readonly ISqlDataAccess _db;

        public PropertyData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<Property>> getPropertiesAsync(int userID)
        {
            string sql = $"select * from property where systemUserID = {userID}";

            return await _db.LoadMany<Property>(sql);
        }

        public async Task<Property> getPropertyByPropertyIdAsync(int propertyID, int userID)
        {
            string sql = $"select top 1 * from property where systemUserID = {userID} and ID = {propertyID}";

            return await _db.LoadSingle<Property>(sql);
        }

        public async Task<int> insertPropertyAsync(PropertyInsertDto property, int userID)
        {
            string sql = $"insert into property output inserted.id values ('{property.propertyName}', '{property.propertyAddress}', {0}, {property.area}, {property.numberOfRooms}, {property.price}, '{property.propertyType}', '{property.propertyDescription}', default, default, 1);";

            return await _db.insertDataWithReturn(sql);
        }

        public async Task<bool> updatePropertyAsync(PropertyUpdateDto property, int userID)
        {
            string sql = $"update property set propertyName = '{property.propertyName}', propertyAddress = '{property.propertyAddress}', propertyStatus = {Convert.ToInt16(property.propertyStatus)}, area = {property.area}, numberOfRooms = {property.numberOfRooms}, price = {property.price}, propertyType = '{property.propertyType}', propertyDescription = '{property.propertyDescription}', dateUpdated = getDate() where ID = {property.ID} and systemUserID = {userID};";

            return await _db.insertData(sql);
        }

        public async Task<bool> deletePropertyAsync(int propertyID, int userID)
        {
            string sql = $"delete from property where ID = {propertyID} and systemUserID = {userID}";

            return await _db.insertData(sql);
        }

    }
}