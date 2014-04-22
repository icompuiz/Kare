CREATE TABLE [dbo].[Quizs] (
    [QuizId] INT         IDENTITY (1, 1) NOT NULL,
    [Name]   NCHAR (255) NULL,
    CONSTRAINT [PK_dbo.Quizs] PRIMARY KEY CLUSTERED ([QuizId] ASC)
);

