namespace simplePropertyManagementSystemAPI.Models {
    public record Amnesty {
        public int ID {get; init;}
        public string amnestyName {get; init;}
        public int amnestyCount {get; init;}
        public bool amnestyContains {get; init;}
        public string notes {get; init;}
        public DateTime dateAdded {get; init;}
        public DateTime dateUpdated {get; init;}
        public int propertyID {get; init;}
        public int systemUserID {get; init;}
    }
}



// --	ID int identity(1,1) primary key,
// --	amnestyName varchar(64) not null,
// --	amnestyCount int null,
// --	amnestyContains bit null,
// --	notes text null,
// --	dateAdded dateTime not null default getDate(),
// --	dateUpdated dateTime null default getDate(),
// --	propertyID int null foreign key references property(ID),
// --	systemUserID int foreign key references systemUser(ID)
// --);