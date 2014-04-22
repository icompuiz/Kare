CREATE TABLE [dbo].[Instructions] (
    [InstructionId] INT            IDENTITY (1, 1) NOT NULL,
    [Text]          NVARCHAR (MAX) NULL,
    [ExerciseId]    INT            NOT NULL,
    CONSTRAINT [PK_dbo.Instructions] PRIMARY KEY CLUSTERED ([InstructionId] ASC),
    CONSTRAINT [FK_dbo.Instructions_dbo.Exercises_ExerciseId] FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercises] ([ExerciseId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ExerciseId]
    ON [dbo].[Instructions]([ExerciseId] ASC);

