CREATE TABLE [dbo].[Driver] (
    [DriverId]           INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]          VARCHAR (50)  NOT NULL,
    [LastName]           VARCHAR (50)  NOT NULL,
    [Birthdate]          DATE          NULL,
    [CellPhone]          VARCHAR (50)  NULL,
    [Address]            VARCHAR (255) NULL,
    [TripsTotal]         INT           CONSTRAINT [df_TripsTotal] DEFAULT ((0)) NULL,
    [HasCriminalRecord]  BIT           DEFAULT ((0)) NULL,
    [UserId]             INT           NULL,
    [Status]             INT           NULL,
    [StartedDrivingYear] INT           NULL,
    CONSTRAINT [pk_Driver] PRIMARY KEY CLUSTERED ([DriverId] ASC),
    CONSTRAINT [fk_Driver_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

