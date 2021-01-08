CREATE TABLE [Result] (
  [id] int UNIQUE,
  [raceid] int,
  [driverId] int NOT NULL,
  [teamId] char(3) NOT NULL,
  [driverTime] varchar(255) DEFAULT (null),
  [driverPosition] int DEFAULT (0),
  [driverLaps] int DEFAULT (0),
  [driverFastestLap] int DEFAULT (0),
  PRIMARY KEY ([raceid], [driverId], [driverPosition])
);

INSERT INTO [Result] VALUES(1,1,77,'MER','1:30:55.739',1,71,68);
INSERT INTO [Result] VALUES(2,1,11,'RPT','1:30:58.439',2,71,64);
INSERT INTO [Result] VALUES(3,1,99,'REN','1:30:61.230',3,71,71);
INSERT INTO [Result] VALUES(4,1,44,'MER','1:30:61.428',4,71,67);
INSERT INTO [Result] VALUES(5,1,55,'MCL','1:30:64.642',5,71,63);
INSERT INTO [Result] VALUES(6,1,5,'FER','1:30:70.831',6,71,63);
INSERT INTO [Result] VALUES(7,1,4,'MCL','1:30:72.421',7,71,64);
INSERT INTO [Result] VALUES(8,1,3,'RBR','1:30:73.195',8,71,64);
INSERT INTO [Result] VALUES(9,1,7,'ARR','1:30:76.885',9,71,70);
INSERT INTO [Result] VALUES(10,1,10,'ATR','1:30:80.245',10,71,71);
INSERT INTO [Result] VALUES(11,1,6,'WLR','1:30:87.389',11,71,63);
INSERT INTO [Result] VALUES(12,1,31,'REN',null,12,69,50);
INSERT INTO [Result] VALUES(13,1,23,'RBR',null,13,67,50);
INSERT INTO [Result] VALUES(14,1,26,'ATR',null,0,53,48);
INSERT INTO [Result] VALUES(15,1,20,'HAS',null,0,49,49);
INSERT INTO [Result] VALUES(16,1,8,'HAS',null,0,49,46);
INSERT INTO [Result] VALUES(17,1,63,'WLR',null,0,24,23);
INSERT INTO [Result] VALUES(18,1,18,'RPT',null,0,20,4);
INSERT INTO [Result] VALUES(19,1,16,'FER',null,0,17,8);
INSERT INTO [Result] VALUES(20,1,33,'RBR',null,0,11,5);