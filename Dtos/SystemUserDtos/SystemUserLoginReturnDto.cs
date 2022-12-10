namespace simplePropertyManagementSystemAPI.Dtos.SystemUserDtos {
    public record SystemUserLoginReturnDto {
        public SystemUserEssentialsDto systemUser {get; init;}
        public string JWT {get; init;}
    }
}