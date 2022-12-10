namespace simplePropertyManagementSystemAPI.Models {
    public record Property {
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
        public int systemUserID {get; init;}
    }
}


// --	ID int identity(1,1) primary key,
// --	propertyName varchar(64) not null,
// --	propertyAddress varchar(128) null,
// --	propertyStatus bit null,
// --	area int null,
// --	numberOfRooms int null,
// --	price decimal null,
// --	propertyType varchar(64) null,
// --	propertyDescription text null,
// --	dateAdded dateTime not null default getDate(),
// --	dateUpdated dateTime null default getDate(),
// --	systemUserID int foreign key references systemUser(ID)