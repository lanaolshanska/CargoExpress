CREATE PROCEDURE spGetRouteById
	@RouteId int
AS
BEGIN
	SELECT * FROM Route
	WHERE RouteId = @RouteId
END;
