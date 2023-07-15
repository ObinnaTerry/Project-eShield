CREATE TABLE [dbo].[Exam]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CreatedBy] INT NOT NULL, 
    [CourseId] INT NOT NULL, 
    [ExamDate] DATE NOT NULL, 
    [StartTime] TIME NOT NULL, 
    [EndTime] TIME NOT NULL
)
