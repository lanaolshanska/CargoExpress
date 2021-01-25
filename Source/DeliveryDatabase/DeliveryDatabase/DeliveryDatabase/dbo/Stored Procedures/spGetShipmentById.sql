
CREATE PROCEDURE spGetShipmentById 
	@ShipmentId int
AS
BEGIN
    SELECT * FROM Shipment
	WHERE ShipmentId = @ShipmentId
END;
