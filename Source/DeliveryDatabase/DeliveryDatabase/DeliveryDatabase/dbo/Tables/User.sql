CREATE TABLE [dbo].[User] (
    [UserId]   INT           IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (50)  NOT NULL,
    [Password] VARCHAR (MAX) NOT NULL,
    [Email]    VARCHAR (255) NOT NULL,
    [Role]     INT           DEFAULT ((1)) NOT NULL,
    CONSTRAINT [pk_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

