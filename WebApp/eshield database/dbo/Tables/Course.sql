CREATE TABLE [dbo].[Course]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CourseName] VARCHAR(50) NOT NULL, 
    [ProfessorId] INT NOT NULL
)
