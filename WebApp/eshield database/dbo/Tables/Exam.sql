CREATE TABLE [dbo].[Exam]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CreatedBy] INT NOT NULL, 
    [CourseId] INT NOT NULL, 
    [ExamDate] DATE NOT NULL, 
    [StartTime] TIME NOT NULL, 
    [EndTime] TIME NOT NULL
    CONSTRAINT FK_Exam_Professor FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Professor]([Id]),
    CONSTRAINT FK_Exam_Course FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course]([Id])
)
