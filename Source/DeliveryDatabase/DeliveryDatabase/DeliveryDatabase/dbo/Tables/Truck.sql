CREATE TABLE [dbo].[Truck] (
    [TruckId]         INT          IDENTITY (1, 1) NOT NULL,
    [Brand]           VARCHAR (20) NULL,
    [Number]          VARCHAR (10) NOT NULL,
    [Year]            INT          NULL,
    [Payload]         INT          NOT NULL,
    [FuelConsumption] INT          NOT NULL,
    [Volume]          INT          NOT NULL,
    CONSTRAINT [pk_Truck] PRIMARY KEY CLUSTERED ([TruckId] ASC)
);

