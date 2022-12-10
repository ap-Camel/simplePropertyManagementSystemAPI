using System.ComponentModel.DataAnnotations;

namespace simplePropertyManagementSystemAPI.Dtos.SystemUserDtos {
    public record SystemUserLoginDto {
        [Required]
        public string email {get; init;}
        [Required]
        public string password {get; init;}
    }
}