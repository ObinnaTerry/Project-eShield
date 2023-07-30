CREATE TABLE [dbo].[NetworkInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] INT NOT NULL,
    [ExamId] INT NOT NULL,
    [IPAddress] VARCHAR(50) NOT NULL, 
    [MACAddress] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_NetworkInfo_Student] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id]), 
    CONSTRAINT [FK_NetworkInfo_Exam] FOREIGN KEY ([ExamId]) REFERENCES [Exam]([Id])
)
