CREATE TABLE [Session]
(
	Session_code VARCHAR NOT NULL PRIMARY KEY,
	User_id INT NOT NULL,
	Date_Of_Session Date,
	Start_Time Timestamp,
	End_Time Timestamp
)
