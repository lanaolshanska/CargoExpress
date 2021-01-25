USE Delivery;
GO

CREATE FUNCTION fn_IsFixedLength (@string varchar(max), @length int)
RETURNS bit
AS 
BEGIN
DECLARE @res bit
	IF @length = LEN(@string) SET @res = 0
	ELSE SET @res = 1
RETURN @res;
END
GO

CREATE FUNCTION fn_ClearNonNumericSymbols(@inputString varchar(max))  
RETURNS varchar(max) 
AS

BEGIN
 DECLARE @resultString varchar(max);
 DECLARE @NonNumericPattern AS varchar(50);
 DECLARE @position AS int;
 SET @resultString = @inputString;
 SET @NonNumericPattern = '%[^0-9]%'
 SET @position = PatIndex(@NonNumericPattern, @resultString);
    WHILE @position > 0
  BEGIN
   SET @resultString = Stuff(@resultString, @position, 1, '');
   SET @position = PatIndex(@NonNumericPattern, @resultString);
  END
    RETURN @resultString;
END
GO