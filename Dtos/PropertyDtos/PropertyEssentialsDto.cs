namespace simplePropertyManagementSystemAPI.Dtos.PropertyDtos {
    public record PropertyEssentialsDto {
        public int ID {get; init;}
        public string propertyName {get; init;}
        public string propertyAddress {get; init;}
        public string propertyStatus {get; init;}
        public int area {get; init;}
        public int numberOfRooms {get; init;}
        public decimal price {get; init;}
        public string propertyType {get; init;}
        public string propertyDescription {get; init;}
        public DateTime dateAdded {get; init;}
        public DateTime dateUpdated {get; init;}
    }
}