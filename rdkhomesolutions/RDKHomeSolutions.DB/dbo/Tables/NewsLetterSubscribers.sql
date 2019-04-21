CREATE TABLE [dbo].[NewsLetterSubscribers] (
    [Id]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [Email] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_NewsLetterSubscribers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [IX_NewsLetterSubscribers_Email] UNIQUE NONCLUSTERED ([Id] ASC)
);

