CREATE TABLE [dbo].[Warehouse] (
    [WarehouseId] INT           IDENTITY (1, 1) NOT NULL,
    [State]       VARCHAR (255) NOT NULL,
    [City]        VARCHAR (255) NOT NULL,
    [Postcode]    VARCHAR (255) NULL,
    [Phone]       VARCHAR (255) NULL,
    CONSTRAINT [pk_Warehouse] PRIMARY KEY CLUSTERED ([WarehouseId] ASC)
);

