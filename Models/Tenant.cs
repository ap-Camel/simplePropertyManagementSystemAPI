namespace simplePropertyManagementSystemAPI.Models {
    public record Tenant {
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
        public int systemUserID {get; init;}
    }
}


// --	ID int identity(1,1) primary key,
// --	firstName varchar(64) not null,
// --	lastName varchar(64) not null,
// --	contactNumber varchar(64) null,
// --	email varchar(64) null,
// --	IdNumber varchar(64) null,
// --	nationality varchar(64) null,
// --	tenantDescription text null,
// --	tenantStatus bit null,
// --	dateAdded dateTime not null default getDate(),
// --	dateUpdated dateTime null default getDate(),
// --	propertyID int null foreign key references property(ID),
// --	systemUserID int foreign key references systemUser(ID)b