using simplePropertyManagementSystemAPI.Dtos.PropertyDtos;
using simplePropertyManagementSystemAPI.Models;

namespace simplePropertyManagementSystemAPI.Helpers {
    public class Converting {
        public static PropertyEssentialsDto toPropertyEssentials(Property property) {
            return new PropertyEssentialsDto{
                ID = property.ID,
                propertyName = property.propertyName,
                propertyAddress = property.propertyAddress,
                area = property.area,
                price = property.price,
                propertyType = property.propertyType,
                propertyDescription = property.propertyDescription,
                dateAdded = property.dateAdded,
                dateUpdated = property.dateUpdated
            };
        }
    }
}