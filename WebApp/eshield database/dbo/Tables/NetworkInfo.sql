﻿CREATE TABLE [dbo].[NetworkInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] VARCHAR(50) NOT NULL,
    [ExamId] INT NOT NULL,
    [IPAddress] VARCHAR(50) NOT NULL, 
    [MACAddress] VARCHAR(50) NOT NULL
)
