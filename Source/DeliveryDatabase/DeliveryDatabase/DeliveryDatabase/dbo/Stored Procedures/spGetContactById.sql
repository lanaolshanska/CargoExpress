
CREATE PROCEDURE spGetContactById
	@ContactId int
AS
BEGIN
	SELECT * FROM Contact
	WHERE ContactId = @ContactId
END;
