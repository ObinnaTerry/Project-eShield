CREATE TABLE [dbo].[VisitedSites]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StudentId] INT NOT NULL, 
    [ExamId] INT NOT NULL, 
    [Website] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_VisitedSites_Student] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id]), 
    CONSTRAINT [FK_VisitedSites_Exam] FOREIGN KEY ([ExamId]) REFERENCES [Exam]([Id]) 
)
