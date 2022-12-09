namespace simplePropertyManagementSystemAPI.Models {
    public record systemUser {
        public int ID {get; init;}
        public string firstName {get; init;}
        public string lastName {get; init;}
        public string email {get; init;}
        public string userPassword {get; init;}
        public DateTime dateCreated {get; init;}
    }
}


// --   ID int identity(1,1) primary key,
// --	firstName varchar(64) not null,
// --	lastName varchar(64) not null,
// --	email varchar(2048) not null,
// --	userPassword varchar(512) not null,
// --	dateCreated dateTime not null default getDate(),