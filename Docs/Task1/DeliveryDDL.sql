CREATE DATABASE Delivery;
GO

CREATE TABLE Delivery.dbo.Warehouse(
WarehouseId int IDENTITY(1,1) NOT NULL,
City char(50) NOT NULL,
State char(50) NOT NULL,
CONSTRAINT pk_Warehouse PRIMARY KEY CLUSTERED (WarehouseId)
);

CREATE TABLE Delivery.dbo.Route(
RouteId int IDENTITY(1,1) NOT NULL,
OriginWarehouseId int NOT NULL,
DestinationWarehouseId int NOT NULL,
Distance float NOT NULL DEFAULT 100,
CONSTRAINT pk_Route PRIMARY KEY CLUSTERED (RouteID),
CONSTRAINT fk_Route_Warehouse_Orig FOREIGN KEY (OriginWarehouseId) REFERENCES Warehouse(WarehouseId),
CONSTRAINT fk_Route_Warehouse_Dest FOREIGN KEY (DestinationWarehouseId) REFERENCES Warehouse(WarehouseId)
);

CREATE TABLE Delivery.dbo.Contact(
ContactId int IDENTITY(1,1) NOT NULL,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
CellPhone varchar(50), 
CONSTRAINT pk_Contact PRIMARY KEY CLUSTERED (ContactId)
);

CREATE TABLE Delivery.dbo.Cargo(
CargoId int IDENTITY(1,1) NOT NULL,
RouteId int NOT NULL,
Weight float NOT NULL,
Volume float NOT NULL,
SenderContactId int NOT NULL,
RecipientContactId int NOT NULL,
CONSTRAINT pk_Cargo PRIMARY KEY CLUSTERED (CargoId),
CONSTRAINT fk_Cargo_Route FOREIGN KEY (RouteId) REFERENCES Route(RouteId),
CONSTRAINT fk_Cargo_Contact_Sender FOREIGN KEY (SenderContactId) REFERENCES Contact(ContactId),
CONSTRAINT fk_Cargo_Contact_Recipient FOREIGN KEY (RecipientContactId) REFERENCES Contact(ContactId)
);

CREATE TABLE Delivery.dbo.Truck(
TruckId int IDENTITY(1,1) NOT NULL,
Brand varchar(20),
Number varchar(10) NOT NULL,
Year int,
Payload int NOT NULL,
FuelConsumption int NOT NULL,
Volume int NOT NULL,
CONSTRAINT pk_Truck PRIMARY KEY CLUSTERED (TruckId)
);

CREATE TABLE Delivery.dbo.Driver(
DriverId int IDENTITY(1,1) NOT NULL,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
Birthdate date, 
CONSTRAINT pk_Driver PRIMARY KEY CLUSTERED(DriverId)
);

CREATE TABLE Delivery.dbo.TrucksDriversAssignment(
DriverId int NOT NULL,
TruckId int NOT NULL,
CONSTRAINT pk_TrucksDriversAssignment PRIMARY KEY CLUSTERED(DriverId, TruckId),
CONSTRAINT fk_Assignment_Driver FOREIGN KEY (DriverId) REFERENCES Driver(DriverId),
CONSTRAINT fk_Assignment_Truck FOREIGN KEY (TruckId) REFERENCES Truck(TruckId),
);

CREATE TABLE Delivery.dbo.Shipment(
ShipmentId int IDENTITY(1,1) NOT NULL,
DriverId int NOT NULL,
TruckId int NOT NULL,
CargoId int NOT NULL, 
RouteId int NOT NULL, 
CONSTRAINT pk_Shipment PRIMARY KEY CLUSTERED(ShipmentId),
CONSTRAINT fk_Shipment_Assignment FOREIGN KEY (DriverId, TruckId) REFERENCES TrucksDriversAssignment(DriverId, TruckId),
CONSTRAINT fk_Shipment_Cargo FOREIGN KEY (CargoId) REFERENCES Cargo(CargoId),
CONSTRAINT fk_Shipment_Route FOREIGN KEY (RouteId) REFERENCES Route(RouteId),
);