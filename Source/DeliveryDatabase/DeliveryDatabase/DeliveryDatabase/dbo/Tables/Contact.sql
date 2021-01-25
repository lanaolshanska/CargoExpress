CREATE TABLE [dbo].[Contact] (
    [ContactId] INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50)  NULL,
    [LastName]  VARCHAR (50)  NULL,
    [CellPhone] VARCHAR (50)  NULL,
    [Address]   VARCHAR (255) NULL,
    [Email]     VARCHAR (255) NULL,
    [UserId]    INT           NULL,
    CONSTRAINT [pk_Contact] PRIMARY KEY CLUSTERED ([ContactId] ASC)
);

