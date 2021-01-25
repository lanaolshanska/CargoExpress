INSERT INTO Delivery.dbo.Warehouse(City, State) VALUES
('New York','New York'),
('Long Beach','California'),
('Kansas City','Missouri'),
('Mesa','Arizona'),
('Virginia Beach','Virginia'),
('Atlanta','Georgia'),
('Colorado Springs','Colorado'),
('Omaha','Nebraska'),
('Raleigh','North Carolina'),
('Miami','Florida'),
('Oakland','California'),
('Minneapolis','Minnesota'),
('Tulsa','Oklahoma'),
('Cleveland','Ohio'),
('Wichita','Kansas'),
('Arlington','Texas'),
('Los Angeles','California'),
('Chicago','Illinois'),
('Houston','Texas'),
('Philadelphia','Pennsylvania'),
('Phoenix','Arizona'),
('San Antonio','Texas'),
('San Diego','California'),
('Dallas','Texas'),
('San Jose','California'),
('Austin','Texas'),
('Indianapolis','Indiana'),
('Jacksonville','Florida'),
('San Francisco','California'),
('Columbus','Ohio'),
('Charlotte','North Carolina'),
('Fort Worth','Texas'),
('Detroit','Michigan'),
('El Paso','Texas'),
('Memphis','Tennessee'),
('Seattle','Washington'),
('Denver','Colorado'),
('Washington','District of Columbia'),
('Boston','Massachusetts'),
('Nashville','Tennessee'),
('Baltimore','Maryland'),
('Oklahoma City','Oklahoma'),
('Louisville','Kentucky'),
('Portland','Oregon'),
('Las Vegas','Nevada'),
('Milwaukee','Wisconsin'),
('Albuquerque','New Mexico'),
('Tucson','Arizona'),
('Fresno','California'),
('New Orleans','Louisiana'),
('Bakersfield','California'),
('Tampa','Florida'),
('Honolulu','Hawai'),
('Aurora','Colorado'),
('Anaheim','California'),
('Santa Ana','California'),
('St. Louis','Missouri'),
('Riverside','California'),
('Corpus Christi','Texas'),
('Lexington','Kentucky'),
('Pittsburgh','Pennsylvania'),
('Anchorage','Alaska'),
('Stockton','California'),
('Cincinnati','Ohio'),
('Saint Paul','Minnesota'),
('Toledo','Ohio'),
('Greensboro','North Carolina'),
('Newark','New Jersey'),
('Plano','Texas'),
('Henderson','Nevada'),
('Lincoln','Nebraska'),
('Buffalo','New York'),
('Jersey City','New Jersey'),
('Chula Vista','California'),
('Fort Wayne','Indiana'),
('Orlando','Florida'),
('St. Petersburg','Florida'),
('Chandler','Arizona'),
('Laredo','Texas'),
('Norfolk','Virginia'),
('Durham','North Carolina'),
('Madison','Wisconsin'),
('Lubbock','Texas'),
('Irvine','California'),
('Winston–Salem','North Carolina'),
('Glendale','Arizona'),
('Garland','Texas'),
('Hialeah','Florida'),
('Reno','Nevada'),
('Chesapeake','Virginia'),
('Gilbert','Arizona'),
('Baton Rouge','Louisiana'),
('Irving','Texas'),
('Scottsdale','Arizona'),
('North Las Vegas','Nevada'),
('Fremont','California'),
('Boise','Idaho'),
('Richmond','Virginia'),
('San Bernardino','California'),
('Sacramento','California');
GO

INSERT INTO Delivery.dbo.Truck(Brand, Number, Year, Payload, FuelConsumption, Volume) VALUES
('MAN','1ABC234','2010','18500','22', '100'),
('DAF','1ABC235','2009','15000','20','90'),
('MERCEDES BENZ','1ABC236','2013','15000','18','100'),
('Foton','1ABC237','2011','9000','18','30'),
('DAF','1ABC238', '2009', '26000','20','70'),
('DAF','1ABC239','2011','12000','20','70'),
('DAF','1ABC240','2014','12000','20','70'),
('DAF','1ABC241','2011','9000','18','50'),
('DAF','1ABC242','2011','9000','18','50'),
('Ford','1ABC243','2011','9000','18','50'),
('MAN','1ABC244','2013','9000','18','50'),
('MAN','1ABC245','2012','5000','18','50'),
('MAN','1ABC246','2011','18500','20','50'),
('MAN','1ABC247','2011','26000','18','50'),
('MAN','1ABC248','2011','20000','18','50');
GO

INSERT INTO Delivery.dbo.Driver(FirstName, LastName, Birthdate) VALUES
('John','Doe','01/23/67'),
('Adam','Petr','05/23/75'),
('Jin','Partida','03/15/80'),
('Scott','Lucas','04/01/85'),
('Alta','Olson','06/14/75'),
('Arthur','Sullivan','04/26/82'),
('Robert','Suarez','04/11/75'),
('Timothy','Johns','10/07/85'),
('Olive','Tucker','12/25/86'),
('Lela','Coleman','04/20/77'),
('Maurice','Elam','04/02/81'),
('Charles ','Delacruz','01/18/75'),
('Branden ','Webster','07/03/64'),
('Bennie ','Morley','12/25/86'),
('Jacob','Sanders','04/20/36'),
('Perry ','Haley','04/26/82'),
('Emma ','White','04/03/55'),
('Bryan ','Baldridge','04/16/52'),
('Tom','Stennis','01/27/85'),
('Mike','O''Connor','12/20/77');
GO

INSERT INTO Delivery.DBO.TrucksDriversAssignment(TruckId, DriverId) VALUES
('1','1'),
('1','2'),
('2','3'),
('3','1'),
('4','4'),
('5','6'),
('6','5'),
('7','7'),
('7','20'),
('8','8'),
('9','9'),
('9','8'),
('10','10'),
('11','10'),
('12','11'),
('13','12'),
('13','13'),
('13','14'),
('14','15'),
('14','16'),
('15','17'),
('15','18'),
('15','19');
GO



INSERT INTO Delivery.dbo.Contact (FirstName,LastName,CellPhone) VALUES
 ('Steven','King','515.123.4567'),
 ('Neena','Kochhar','515.123.4568'),
 ('Lex','De Haan','515.123.4569'),
 ('Alexander','Hunold','590.423.4567'),
 ('Bruce','Ernst','590.423.4568'),
 ('David','Austin','590.423.4569'),
 ('Valli','Pataballa','590.423.4560'),
 ('Diana','Lorentz','590.423.5567'),
 ('Nancy','Greenberg','515.124.4569'),
 ('Daniel','Faviet','515.124.4169'),
 ('John','Chen','515.124.4269'),
 ('Ismael','Sciarra','515.124.4369'),
 ('Jose Manuel','Urman','515.124.4469'),
 ('Luis','Popp','515.124.4567'),
 ('Den','Raphaely','515.127.4561'),
 ('Alexander','Khoo','515.127.4562'),
 ('Shelli','Baida','515.127.4563'),
 ('Sigal','Tobias','515.127.4564'),
 ('Guy','Himuro','515.127.4565'),
 ('Karen','Colmenares','515.127.4566'),
 ('Matthew','Weiss','650.123.1234'),
 ('Adam','Fripp','650.123.2234'),
 ('Payam','Kaufling','650.123.3234'),
 ('Shanta','Vollman','650.123.4234'),
 ('Kevin','Mourgos','650.123.5234'),
 ('Julia','Nayer','650.124.1214'),
 ('Irene','Mikkilineni','650.124.1224'),
 ('James','Landry','650.124.1334'),
 ('Steven','Markle','650.124.1434'),
 ('Laura','Bissot','650.124.5234'),
 ('Mozhe','Atkinson','650.124.6234'),
 ('James','Marlow','650.124.7234'),
 ('TJ','Olson','650.124.8234'),
 ('Jason','Mallin','650.127.1934'),
 ('Michael','Rogers','650.127.1834'),
 ('Ki','Gee','650.127.1734'),
 ('Hazel','Philtanker','650.127.1634'),
 ('Renske','Ladwig','650.121.1234'),
 ('Stephen','Stiles','650.121.2034'),
 ('John','Seo','650.121.2019'),
 ('Joshua','Patel','650.121.1834'),
 ('Trenna','Rajs','650.121.8009'),
 ('Curtis','Davies','650.121.2994'),
 ('Randall','Matos','650.121.2874'),
 ('Peter','Vargas','650.121.2004'),
 ('John','Russell','011.44.1344.429268'),
 ('Karen','Partners','011.44.1344.467268'),
 ('Alberto','Errazuriz','011.44.1344.429278'),
 ('Gerald','Cambrault','011.44.1344.619268'),
 ('Eleni','Zlotkey','011.44.1344.429018'),
 ('Peter','Tucker','011.44.1344.129268'),
 ('David','Bernstein','011.44.1344.345268'),
 ('Peter','Hall','011.44.1344.478968'),
 ('Christopher','Olsen','011.44.1344.498718'),
 ('Nanette','Cambrault','011.44.1344.987668'),
 ('Oliver','Tuvault','011.44.1344.486508'),
 ('Janette','King','011.44.1345.429268'),
 ('Patrick','Sully','011.44.1345.929268'),
 ('Allan','McEwen','011.44.1345.829268'),
 ('Lindsey','Smith','011.44.1345.729268'),
 ('Louise','Doran','011.44.1345.629268'),
 ('Sarath','Sewall','011.44.1345.529268'),
 ('Clara','Vishney','011.44.1346.129268'),
 ('Danielle','Greene','011.44.1346.229268'),
 ('Mattea','Marvins','011.44.1346.329268'),
 ('David','Lee','011.44.1346.529268'),
 ('Sundar','Ande','011.44.1346.629268'),
 ('Amit','Banda','011.44.1346.729268'),
 ('Lisa','Ozer','011.44.1343.929268'),
 ('Harrison','Bloom','011.44.1343.829268'),
 ('Tayler','Fox','011.44.1343.729268'),
 ('William','Smith','011.44.1343.629268'),
 ('Elizabeth','Bates','011.44.1343.529268'),
 ('Sundita','Kumar','011.44.1343.329268'),
 ('Ellen','Abel','011.44.1644.429267'),
 ('Alyssa','Hutton','011.44.1644.429266'),
 ('Jonathon','Taylor','011.44.1644.429265'),
 ('Jack','Livingston','011.44.1644.429264'),
 ('Kimberely','Grant','011.44.1644.429263'),
 ('Charles','Johnson','011.44.1644.429262'),
 ('Winston','Taylor','650.507.9876'),
 ('Jean','Fleaur','650.507.9877'),
 ('Martha','Sullivan','650.507.9878'),
 ('Girard','Geoni','650.507.9879'),
 ('Nandita','Sarchand','650.509.1876'),
 ('Alexis','Bull','650.509.2876'),
 ('Julia','Dellinger','650.509.3876'),
 ('Anthony','Cabrio','650.509.4876'),
 ('Kelly','Chung','650.505.1876'),
 ('Jennifer','Dilly','650.505.2876'),
 ('Timothy','Gates','650.505.3876'),
 ('Randall','Perkins','650.505.4876'),
 ('Sarah','Bell','650.501.1876'),
 ('Britney','Everett','650.501.2876'),
 ('Samuel','McCain','650.501.3876'),
 ('Vance','Jones','650.501.4876'),
 ('Alana','Walsh','650.507.9811'),
 ('Kevin','Feeney','650.507.9822'),
 ('Donald','OConnell','650.507.9833'),
 ('Douglas','Grant','650.507.9844'),
 ('Jennifer','Whalen','515.123.4444'),
 ('Michael','Hartstein','515.123.5555'),
 ('Pat','Fay','603.123.6666'),
 ('Susan','Mavris','515.123.7777'),
 ('Hermann','Baer','515.123.8888'),
 ('Shelley','Higgins','515.123.8080'),
 ('William','Gietz','515.123.8181');
 GO

INSERT INTO Delivery.dbo.Route(OriginWarehouseId, DestinationWarehouseId, Distance)
SELECT WarehouseOrigin.WarehouseId, WarehouseDest.WarehouseId, ABS(CHECKSUM(NEWID()) % 3000) + 100
FROM Delivery.dbo.Warehouse WarehouseOrigin
RIGHT JOIN Delivery.dbo.Warehouse WarehouseDest 
ON WarehouseOrigin.WarehouseId != WarehouseDest.WarehouseId;
GO

DECLARE @i int
DECLARE @senderId int
DECLARE @recipientId int
DECLARE @routeId int

SET @i = 1

WHILE (@i <= 10000)
BEGIN
SET @i = @i + 1
SET @senderId = (SELECT TOP 1 ContactId FROM Delivery.dbo.Contact ORDER BY NEWID())
SET @recipientId = (SELECT TOP 1 ContactId FROM Delivery.dbo.Contact ORDER BY NEWID())
SET @routeId = (SELECT TOP 1 RouteId FROM Delivery.dbo.Route ORDER BY NEWID())

WHILE(@senderId = @recipientId)
BEGIN
SET @recipientId = (SELECT TOP 1 ContactId FROM Delivery.dbo.Contact ORDER BY NEWID())
END

INSERT INTO Delivery.dbo.Cargo(RouteId, Weight, Volume, SenderContactId, RecipientContactId) VALUES(
@routeId,
FLOOR(RAND()*(1000 - 5 + 1) + 5),
FLOOR(RAND()*(100 - 10 + 1) + 10),
@senderId,
@recipientId);

END
GO

DECLARE @cargoId int
DECLARE @volume float
DECLARE @weight float
DECLARE @routeId int
DECLARE @driverId int
DECLARE @truckId int

DECLARE @cursor CURSOR

SET @cursor  = CURSOR SCROLL
FOR
 SELECT TOP 1000 CargoId, RouteId, Volume, Weight FROM Delivery.dbo.Cargo ORDER BY NEWID()
OPEN @cursor

FETCH NEXT FROM @cursor INTO @cargoId, @routeId, @volume, @weight
WHILE @@FETCH_STATUS = 0
BEGIN
  SELECT TOP 1 @driverId = tda.DriverId, @truckId = tda.TruckId
   FROM Delivery.dbo.TrucksDriversAssignment as tda
   JOIN Delivery.dbo.Truck as t ON t.TruckId = tda.TruckId
   WHERE t.Volume >= @volume AND t.Payload >= @weight
   ORDER BY NEWID()

        INSERT INTO Delivery.dbo.Shipment (CargoId, RouteId, DriverId, TruckId) VALUES (@cargoId, @routeId, @driverId, @truckId)

FETCH NEXT FROM @cursor INTO @cargoId, @routeId, @volume, @weight
END
CLOSE @cursor