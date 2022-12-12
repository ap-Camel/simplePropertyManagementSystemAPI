using System.ComponentModel.DataAnnotations;

namespace simplePropertyManagementSystemAPI.Dtos.PropertyDtos {
    public record PropertyUpdateDto {

        [Required(ErrorMessage = "property ID is required")]
        public int ID {get; init;}

        [Required(ErrorMessage = "property name is required")]
        [MinLength(3, ErrorMessage = "property name minimum length must be longer than 3 characters")]
        public string propertyName {get; init;}
        public string propertyAddress {get; init;}
        public string propertyStatus {get; init;}
        public int area {get; init;}
        public int numberOfRooms {get; init;}
        public decimal price {get; init;}
        public string propertyType {get; init;}
        public string propertyDescription {get; init;}
    }
}