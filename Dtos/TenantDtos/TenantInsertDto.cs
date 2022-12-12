using System.ComponentModel.DataAnnotations;

namespace simplePropertyManagementSystemAPI.Dtos.TenantDtos {
    public record TenantInsertDto {

        [Required(ErrorMessage = "tenant first name is required")]
        [MinLength(3, ErrorMessage = "tenant name minimum length must be longer than 3 characters")]
        public string firstName {get; init;}

        [Required(ErrorMessage = "tenant last name is required")]
        [MinLength(3, ErrorMessage = "tenant name minimum length must be longer than 3 characters")]
        public string lastName {get; init;}
        public string contactNumber {get; init;}
        public string email {get; init;}
        public string IdNumber {get; init;}
        public string nationality {get; init;}
        public string tenantDescription {get; init;}
        public bool tenantStatus {get; init;}
        public int propertyID {get; init;}
        public int systemUserID {get; init;}
    }
}