CREATE TABLE [dbo].[Professor]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [Email] VARCHAR(50) NOT NULL,
    [CourseId] INT NOT NULL,
    CONSTRAINT FK_Professor_Course FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course]([Id])
)
