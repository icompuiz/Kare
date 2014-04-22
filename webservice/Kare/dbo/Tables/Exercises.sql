CREATE TABLE [dbo].[Exercises] (
    [ExerciseId] INT            IDENTITY (1, 1) NOT NULL,
    [QuizId]     INT            NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Exercises] PRIMARY KEY CLUSTERED ([ExerciseId] ASC),
    CONSTRAINT [FK_dbo.Exercises_dbo.Quizs_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [dbo].[Quizs] ([QuizId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_QuizId]
    ON [dbo].[Exercises]([QuizId] ASC);

