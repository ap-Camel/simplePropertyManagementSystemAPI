namespace simplePropertyManagementSystemAPI.Dtos.SystemUserDtos {
    public record SystemUserSignupDto {
        public string firstName {get; init;}
        public string lastName {get; init;}
        public string email {get; init;}
        public string userPassword {get; init;}
    }
}