CREATE TABLE [dbo].[Cargo] (
    [CargoId]            INT        IDENTITY (1, 1) NOT NULL,
    [RouteId]            INT        NOT NULL,
    [Weight]             FLOAT (53) NOT NULL,
    [Volume]             FLOAT (53) NOT NULL,
    [SenderContactId]    INT        NOT NULL,
    [RecipientContactId] INT        NOT NULL,
    [UserId]             INT        NULL,
    [Status]             INT        NULL,
    [DriverId]           INT        NULL,
    CONSTRAINT [pk_Cargo] PRIMARY KEY CLUSTERED ([CargoId] ASC),
    CONSTRAINT [fk_Cargo_Contact_Recipient] FOREIGN KEY ([RecipientContactId]) REFERENCES [dbo].[Contact] ([ContactId]),
    CONSTRAINT [fk_Cargo_Contact_Sender] FOREIGN KEY ([SenderContactId]) REFERENCES [dbo].[Contact] ([ContactId]),
    CONSTRAINT [fk_Cargo_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Driver] ([DriverId]),
    CONSTRAINT [fk_Cargo_Route] FOREIGN KEY ([RouteId]) REFERENCES [dbo].[Route] ([RouteId]),
    CONSTRAINT [fk_Cargo_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

