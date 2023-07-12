CREATE TABLE [dbo].[ExamStudents]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StudentId] INT NOT NULL, 
    [ExamId] INT NOT NULL, 
    CONSTRAINT [FK_ExamStudents_Student] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id]), 
    CONSTRAINT [FK_ExamStudents_Exam] FOREIGN KEY ([ExamId]) REFERENCES [Exam]([Id])
)
