CREATE TABLE [dbo].[Team] (
[teamCode] char(3) NOT NULL default '',
[teamFullName] varchar(130) NOT NULL default '',
[teamChief] varchar(100) NOT NULL default '',
[teamPowerUnit] varchar(100) NOT NULL default '',
[teamBase] varchar(70) NOT NULL default '',
[nationCode] char(2) NOT NULL default '',
[logo] varchar(512) NOT NULL ,
[img] varchar(512) NOT NULL ,
PRIMARY KEY ([teamCode])
);

INSERT INTO [Team] VALUES ('MER','Mercedes-AMG Petronas F1 Team','Toto Wolff','Mercedes','Brackley','GB','https://www.formula1.com/content/fom-website/en/teams/Mercedes/_jcr_content/logo.img.jpg/1582650443223.jpg','https://www.formula1.com/content/dam/fom-website/teams/2020/mercedes.png.transform/2col/image.png');
INSERT INTO [Team] VALUES ('HAS','Haas F1 Team','Guenther Steiner','Ferrari','Kannapolis','US','https://www.formula1.com/content/fom-website/en/teams/Haas-F1-Team/_jcr_content/logo.img.png/1568040720597.png','https://www.formula1.com/content/dam/fom-website/teams/2020/haas-f1-team.png.transform/2col/image.png');
INSERT INTO [Team] VALUES ('FER','Scuderia Ferrari Mission Winnow','Mattia Binotto','Ferrari','Maranello','IT','https://www.formula1.com/content/fom-website/en/teams/Ferrari/_jcr_content/logo.img.jpg/1582650443223.jpg','https://www.formula1.com/content/dam/fom-website/teams/2020/ferrari.png.transform/2col/image.png');
INSERT INTO [Team] VALUES ('ATR','Scuderia Alpha Tauri','Franz Tost','Honda','Faenza','IT','https://www.formula1.com/content/fom-website/en/teams/AlphaTauri/_jcr_content/logo.img.jpg/1582650443223.jpg','https://www.formula1.com/content/dam/fom-website/teams/2020/alphatauri.png.transform/2col/image.png');
INSERT INTO [Team] VALUES ('RPT','BWT Racing Point F1 Team','Otmar Szafnauer','Mercedes','Silverstone','GB','https://www.formula1.com/content/fom-website/en/teams/Racing-Point/_jcr_content/logo.img.jpg/1582650443223.jpg','https://www.formula1.com/content/dam/fom-website/teams/2020/racing-point.png.transform/2col/image.png');
INSERT INTO [Team] VALUES ('REN','Renault DP World F1 Team','Cyril Abiteboul','Renault','Enstone','GB','https://www.formula1.com/content/fom-website/en/teams/Renault/_jcr_content/logo.img.jpg/1582650443223.jpg','https://www.formula1.com/content/dam/fom-website/teams/2020/renault.png.transform/2col/image.png');
INSERT INTO [Team] VALUES ('RBR','Aston Martin Red Bull Racing','Christian Horner','Honda','Milton Keynes','GB','https://www.formula1.com/content/fom-website/en/teams/Red-Bull-Racing/_jcr_content/logo.img.jpg/1582650443223.jpg','https://www.formula1.com/content/dam/fom-website/teams/2020/red-bull-racing.png.transform/2col/image.png');
INSERT INTO [Team] VALUES ('ARR','Alfa Romeo Racing ORLEAN','Frédéroc Vasseur','Ferrari','Hinwil','CH','https://www.formula1.com/content/fom-website/en/teams/Alfa-Romeo-Racing/_jcr_content/logo.img.jpg/1582650443223.jpg','https://www.formula1.com/content/dam/fom-website/teams/2020/alfa-romeo-racing.png.transform/2col/image.png');
INSERT INTO [Team] VALUES ('MCL','McLaren F1 Team','Andreas Seidl','Renault','Woking','GB','https://www.formula1.com/content/fom-website/en/teams/Alfa-Romeo-Racing/_jcr_content/logo.img.jpg/1582650443223.jpg','https://www.formula1.com/content/dam/fom-website/teams/2020/alfa-romeo-racing.png.transform/2col/image.png');
INSERT INTO [Team] VALUES ('WLR','Williams Racing','Simon Roberts','Mercedes','Grove','GB','https://www.formula1.com/content/fom-website/en/teams/Williams/_jcr_content/logo.img.jpg/1582650443223.jpg','https://www.formula1.com/content/dam/fom-website/teams/2020/williams.png.transform/2col/image.png');







