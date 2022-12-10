namespace simplePropertyManagementSystemAPI.Models {
    public record Report {
        public int ID {get; init;}
        public string catagory {get; init;}
        public DateTime dateReported {get; init;}
        public DateTime dateFixed {get; init;}
        public DateTime dateUpdated {get; init;}
        public string reportStatus {get; init;}
        public decimal cost {get; init;}
        public string reportDescription {get; init;}
        public int contractorID {get; init;}
        public int tenantID {get; init;}
        public int propertyID {get; init;}
        public int systemUserID {get; init;}
    }
}



// --	ID int identity(1,1) primary key,
// --	catagory varchar(64) not null,
// --	dateReported dateTime not null default getDate(),
// --	dateFixed dateTime null,
// --	dateUpdated dateTime null default getDate(), 
// --	reportStatus varchar(64) null,
// --	cost decimal null,
// --	reportDescription text null,
// --	contractorID int foreign key references contractor(ID),
// --	tenantID int foreign key references tenant(ID),
// --	propertyID int null foreign key references property(ID),
// --	systemUserID int foreign key references systemUser(ID)