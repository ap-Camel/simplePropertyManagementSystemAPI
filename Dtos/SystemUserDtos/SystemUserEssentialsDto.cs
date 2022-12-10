namespace simplePropertyManagementSystemAPI.Dtos.SystemUserDtos {
    public record SystemUserEssentialsDto {
        public string firstName {get; init;}
        public string lastName {get; init;}
        public string email {get; init;}
    }
}