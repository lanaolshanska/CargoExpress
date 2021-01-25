
CREATE PROCEDURE spGetCargoById
	@CargoId int 
AS
BEGIN
    SELECT * FROM Cargo
	WHERE CargoId = @CargoId 
END;
