CREATE TABLE [dbo].[QuizQuestions] (
    [QuizQuestionId] INT            IDENTITY (1, 1) NOT NULL,
    [Text]           NVARCHAR (MAX) NULL,
    [QuizId]         INT            NOT NULL,
    CONSTRAINT [PK_dbo.QuizQuestions] PRIMARY KEY CLUSTERED ([QuizQuestionId] ASC),
    CONSTRAINT [FK_dbo.QuizQuestions_dbo.Quizs_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [dbo].[Quizs] ([QuizId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_QuizId]
    ON [dbo].[QuizQuestions]([QuizId] ASC);

