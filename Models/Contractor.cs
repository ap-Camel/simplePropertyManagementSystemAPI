namespace simplePropertyManagementSystemAPI.Models {
    public record Contractor {
        public int ID {get; init;}
        public string firstName {get; init;}
        public string lastName {get; init;}
        public string contactNumber {get; init;}
        public string email {get; init;}
        public string contractorDescription {get; init;}
        public DateTime dateAdded {get; init;}
        public DateTime dateUpdated {get; init;}
        public int systemUserID {get; init;}
    }
}


// --	ID int identity(1,1) primary key,
// --	firstName varchar(64) not null,
// --	lastName varchar(64) not null,
// --	contactNumber varchar(64) not null,
// --	email varchar(64) null,
// --	contractorDescription text null,
// --	dateAdded dateTime not null default getDate(),
// --	dateUpdated dateTime null default getDate(),
// --	systemUserID int foreign key references systemUser(ID)