CREATE TABLE [Website]
(
	Website_Id INT NOT NULL PRIMARY KEY,
	User_Id INT NOT NULL,
	Session_code VARCHAR NOT NULL,
	Website_URL VARCHAR NOT NULL,
	Time_Spent VARCHAR,
	No_Of_Visits INT,
	Response_Data VARCHAR
)
