CREATE TABLE [Website]
(
	WebsiteId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserId INT NOT NULL,
	SessionCode INT NOT NULL,
	WebsiteURL VARCHAR(255) NOT NULL,
	TimeSpent VARCHAR(50),
	NoOfVisits INT,
	ResponseData VARCHAR(MAX),
	FOREIGN KEY (UserId) REFERENCES [User](UserId),
	FOREIGN KEY (SessionCode) REFERENCES [Session](SessionCode)
);







