
CREATE FUNCTION fn_IsFixedLength (@string varchar(max), @length int)
RETURNS bit
AS 
BEGIN
DECLARE @res bit
	IF @length = LEN(@string) SET @res = 0
	ELSE SET @res = 1
RETURN @res;
END
