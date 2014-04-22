CREATE TABLE [dbo].[Table] (
    [QuizQuestionId] INT         NOT NULL,
    [QuizId]         INT         NOT NULL,
    [Text]           NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([QuizQuestionId] ASC)
);

