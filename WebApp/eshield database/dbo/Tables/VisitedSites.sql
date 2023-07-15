CREATE TABLE [dbo].[VisitedSites]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] INT NOT NULL,
    [MACAddress] VARCHAR(50) NOT NULL, 
    [ExamId] INT NOT NULL, 
    [Website] VARCHAR(50) NOT NULL, 
    [CreateTime] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_VisitedSites_Student] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id]), 
    CONSTRAINT [FK_VisitedSites_Exam] FOREIGN KEY ([ExamId]) REFERENCES [Exam]([Id]) 
)
