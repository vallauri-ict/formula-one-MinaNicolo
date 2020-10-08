CREATE TABLE [dbo].[Driver] (
[driverNumber] int NOT NULL ,
[driverName] varchar(35) NOT NULL default '',
[driverSurname] varchar(70) NOT NULL default '',
[teamCode] char(3) NOT NULL default '',
[countryCode] char(2) NOT NULL default '',
[img] varchar(512) NOT NULL,
PRIMARY KEY ([driverNumber])
);

INSERT INTO [Driver] VALUES (44,'Lewis','Hamilton','MER','GB','https://www.formula1.com/content/fom-website/en/drivers/lewis-hamilton/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (77,'Valtteri','Bottas','MER','FI','https://www.formula1.com/content/fom-website/en/drivers/valtteri-bottas/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (33,'Max','Verstappen','RBR','NL','https://www.formula1.com/content/fom-website/en/drivers/max-verstappen/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (16,'Charles','Leclerc','FER','MC','https://www.formula1.com/content/fom-website/en/drivers/charles-leclerc/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (11,'Sergio','Perez','RPT','MX','https://www.formula1.com/content/fom-website/en/drivers/sergio-perez/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (5,'Sebastian','Vettel','FER','DE','https://www.formula1.com/content/fom-website/en/drivers/sebastian-vettel/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (99,'Antonio','Giovinazzi','ARR','IT','https://www.formula1.com/content/fom-website/en/drivers/antonio-giovinazzi/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (55,'Carlos','Sainz','MCL','ES','https://www.formula1.com/content/fom-website/en/drivers/carlos-sainz/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (23,'Alexander','Albon','RBR','TH','https://www.formula1.com/content/fom-website/en/drivers/alexander-albon/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (4,'Lando','Norris','MCL','GB','https://www.formula1.com/content/fom-website/en/drivers/lando-norris/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (18,'Lance','Stroll','RPT','CA','https://www.formula1.com/content/fom-website/en/drivers/lance-stroll/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (3,'Daniel','Ricciardo','REN','AT','https://www.formula1.com/content/fom-website/en/drivers/daniel-ricciardo/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (31,'Esteban','Ocon','REN','FR','https://www.formula1.com/content/fom-website/en/drivers/esteban-ocon/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (10,'Pierre','Gasly','ATR','FR','https://www.formula1.com/content/fom-website/en/drivers/pirre-gasly/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (26,'Daniil','Kvyat','ATR','RU','https://www.formula1.com/content/fom-website/en/drivers/daniil-kvyat/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (7,'Kimi','Räikkönen','ARR','FI','https://www.formula1.com/content/fom-website/en/drivers/kimi-raikkonen/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (63,'George','Russell','WLR','GB','https://www.formula1.com/content/fom-website/en/drivers/george-russell/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (6,'Nicholas','Latifi','WLR','CA','https://www.formula1.com/content/fom-website/en/drivers/nicholas-latifi/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (20,'Kevin','Magnussen','HAS','DK','https://www.formula1.com/content/fom-website/en/drivers/kevin-magnussen/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');
INSERT INTO [Driver] VALUES (8,'Romain','Grosjean','HAS','FR','https://www.formula1.com/content/fom-website/en/drivers/romain-grosjean/_jcr_content/image.img.1024.medium.jpg/1584013371803.jpg');


