USE Delivery;
GO

ALTER TABLE Shipment
	ADD SentDate smalldatetime DEFAULT CAST(GETDATE() AS smalldatetime),
		ReceivedDate smalldatetime;
GO

UPDATE Delivery.dbo.Shipment 
SET SentDate = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2009-01-01');
GO
	
UPDATE Delivery.dbo.Shipment 	
SET	ReceivedDate = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 30), SentDate);
GO