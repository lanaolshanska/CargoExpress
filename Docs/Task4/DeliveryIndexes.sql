USE Delivery;
GO

CREATE INDEX ix_Shipment_RouteId ON Shipment (RouteId);
  
CREATE INDEX ix_Shipment_TruckId ON Shipment (TruckId); 
 
CREATE INDEX ix_Shipment_CargoId ON Shipment (CargoId); 

CREATE INDEX ix_Route_OrigWarehouseId ON Route (OriginWarehouseId);  
 
CREATE INDEX ix_Route_DestWarehouseId ON Route (DestinationWarehouseId);