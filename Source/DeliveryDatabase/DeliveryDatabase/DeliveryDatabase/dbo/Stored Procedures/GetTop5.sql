CREATE PROCEDURE [dbo].[GetTop5]
AS
	SELECT TOP 5
      [FirstName]
      ,[LastName]
      ,[Birthdate]
      ,[CellPhone]
      ,[Address]
      ,[TripsTotal]
  FROM [Delivery].[dbo].[Driver]

  Order by TripsTotal desc
