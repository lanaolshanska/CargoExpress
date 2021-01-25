
CREATE PROCEDURE spGetWarehouseById 
	@WarehouseId int
AS
BEGIN
    SELECT * FROM Warehouse
	WHERE WarehouseId = @WarehouseId
END;
