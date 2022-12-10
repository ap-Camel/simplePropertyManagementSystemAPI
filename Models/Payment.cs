namespace simplePropertyManagementSystemAPI.Models {
    public record Payment {
        public int ID {get; init;}
        public string paymentName {get; init;}
        public decimal paymentAmount {get; init;}
        public DateTime dateToBePayed {get; init;}
        public DateTime datePayed {get; init;}
        public string paymentType {get; init;}
        public string paymentDescription {get; init;}
        public DateTime dateAdded {get; init;}
        public DateTime dateUpdated {get; init;}
        public int tenantID {get; init;}
        public int propertyID {get; init;}
        public int systemUserID {get; init;}
    }
}


// --	ID int identity(1,1) primary key,
// --	paymentName varchar(64) not null,
// --	paymentAmount decimal not null default 0,
// --	dateToBePayed dateTime not null,
// --	datePayed dateTime null,
// --	paymentType varchar(64) null,
// --	paymentDescription text null,
// --	dateAdded dateTime not null default getDate(),
// --	dateUpdated dateTime null default getDate(), 
// --	tenantID int foreign key references tenant(ID),
// --	propertyID int null foreign key references property(ID),
// --	systemUserID int foreign key references systemUser(ID)