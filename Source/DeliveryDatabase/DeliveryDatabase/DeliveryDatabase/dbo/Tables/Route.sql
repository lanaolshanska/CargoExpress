CREATE TABLE [dbo].[Route] (
    [RouteId]                INT        IDENTITY (1, 1) NOT NULL,
    [OriginWarehouseId]      INT        NOT NULL,
    [DestinationWarehouseId] INT        NOT NULL,
    [Distance]               FLOAT (53) DEFAULT ((100)) NOT NULL,
    CONSTRAINT [pk_Route] PRIMARY KEY CLUSTERED ([RouteId] ASC),
    CONSTRAINT [fk_Route_Warehouse_Dest] FOREIGN KEY ([DestinationWarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId]),
    CONSTRAINT [fk_Route_Warehouse_Orig] FOREIGN KEY ([OriginWarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId])
);


GO
CREATE NONCLUSTERED INDEX [ix_Route_OrigWarehouseId]
    ON [dbo].[Route]([OriginWarehouseId] ASC);


GO
CREATE NONCLUSTERED INDEX [ix_Route_DestWarehouseId]
    ON [dbo].[Route]([DestinationWarehouseId] ASC);

