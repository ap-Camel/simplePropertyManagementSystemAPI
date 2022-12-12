namespace simplePropertyManagementSystemAPI.Dtos.TenantDtos {
    public record TenantEssentialsDto {
        public int ID {get; init;}
        public string firstName {get; init;}
        public string lastName {get; init;}
        public string contactNumber {get; init;}
        public string email {get; init;}
        public string IdNumber {get; init;}
        public string nationality {get; init;}
        public string tenantDescription {get; init;}
        public bool tenantStatus {get; init;}
        public DateTime dateAdded {get; init;}
        public DateTime dateUpdated {get; init;}
        public int propertyID {get; init;}
    }
}