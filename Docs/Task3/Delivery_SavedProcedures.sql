USE Delivery;
GO

CREATE PROCEDURE dbo.spGetAllWarehouses 
AS
BEGIN
    SELECT * FROM Warehouse
END;
GO

CREATE PROCEDURE spGetWarehouseById 
	@WarehouseId int
AS
BEGIN
    SELECT * FROM Warehouse
	WHERE WarehouseId = @WarehouseId
END;
GO

CREATE PROCEDURE spGetAllShipments
AS
BEGIN
    SELECT * FROM Shipment
END;
GO

CREATE PROCEDURE spGetShipmentById 
	@ShipmentId int
AS
BEGIN
    SELECT * FROM Shipment
	WHERE ShipmentId = @ShipmentId
END;
GO

CREATE PROCEDURE spGetAllCargos 
AS
BEGIN
    SELECT * FROM Cargo
END;
GO

CREATE PROCEDURE spGetCargoById
	@CargoId int 
AS
BEGIN
    SELECT * FROM Cargo
	WHERE CargoId = @CargoId 
END;
GO

CREATE PROCEDURE spGetAllContacts
AS
BEGIN
	SELECT * FROM Contact
END;
GO

CREATE PROCEDURE spGetContactById
	@ContactId int
AS
BEGIN
	SELECT * FROM Contact
	WHERE ContactId = @ContactId
END;
GO

CREATE PROCEDURE spGetAllRoutes
AS
BEGIN
	SELECT * FROM Route
END;
GO

CREATE PROCEDURE spGetRouteById
	@RouteId int
AS
BEGIN
	SELECT * FROM Route
	WHERE RouteId = @RouteId
END;
GO