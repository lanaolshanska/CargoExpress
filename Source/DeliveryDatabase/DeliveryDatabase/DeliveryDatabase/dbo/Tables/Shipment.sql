CREATE TABLE [dbo].[Shipment] (
    [ShipmentId]   INT           IDENTITY (1, 1) NOT NULL,
    [DriverId]     INT           NOT NULL,
    [TruckId]      INT           NOT NULL,
    [CargoId]      INT           NOT NULL,
    [RouteId]      INT           NOT NULL,
    [SentDate]     SMALLDATETIME DEFAULT (CONVERT([smalldatetime],getdate())) NULL,
    [ReceivedDate] SMALLDATETIME NULL,
    CONSTRAINT [pk_Shipment] PRIMARY KEY CLUSTERED ([ShipmentId] ASC),
    CONSTRAINT [fk_Shipment_Cargo] FOREIGN KEY ([CargoId]) REFERENCES [dbo].[Cargo] ([CargoId]),
    CONSTRAINT [fk_Shipment_Route] FOREIGN KEY ([RouteId]) REFERENCES [dbo].[Route] ([RouteId])
);


GO
CREATE NONCLUSTERED INDEX [ix_Shipment_RouteId]
    ON [dbo].[Shipment]([RouteId] ASC);


GO
CREATE NONCLUSTERED INDEX [ix_Shipment_TruckId]
    ON [dbo].[Shipment]([TruckId] ASC);


GO
CREATE NONCLUSTERED INDEX [ix_Shipment_CargoId]
    ON [dbo].[Shipment]([CargoId] ASC);

