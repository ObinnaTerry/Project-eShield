﻿CREATE TABLE [dbo].[ExamCode]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ExamId] INT NOT NULL, 
    [StudentId] INT NOT NULL, 
    [Code] VARCHAR(50) NOT NULL
)
