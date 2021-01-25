USE Delivery;
GO

CREATE VIEW ShipmentView AS
SELECT Shipment.ShipmentId, w1.City AS OriginCity, w2.City AS DestinationCity, Truck.Brand, Shipment.SentDate, Shipment.ReceivedDate, Cargo.Weight, Cargo.Volume, 
(Route.Distance * Truck.FuelConsumption / 100) AS FuelSpent 
FROM Shipment, Route, Truck, Cargo, Warehouse AS w1, Warehouse AS w2
WHERE Shipment.RouteId = Route.RouteId 
AND Route.OriginWarehouseId = w1.WarehouseId 
AND Route.DestinationWarehouseId = w2.WarehouseId 
AND Shipment.TruckId = Truck.TruckId 
AND Shipment.CargoId = Cargo.CargoId;
