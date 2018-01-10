INSERT INTO KORISNIK
	VALUES ('Milos', 'Milosevic', 'miki', 'miki123', 0, 0),
		   ('Janko', 'Jankovic', 'janko', '123', 0, 0),
		   ('Nikola', 'Nikolic', 'nikola', '123', 1, 0),
		   ('Ilija', 'Ilic', 'ilija', '123', 1, 0)
GO
		   


INSERT INTO TIP_NAMESTAJA 
	VALUES ('Kauc', 0),
		   ('Sofa', 0),
		   ('Stolica', 0),
		   ('Krevet', 0)
GO


INSERT INTO AKCIJA 
	VALUES ('Novogodisnja 30%', CONVERT(DATE, '25.12.2017', 104), CONVERT(DATE, '05.01.2018', 104), 30, 0),
		   ('Bozicna 20%', CONVERT(DATE, '06.01.2018', 104), CONVERT(DATE, '08.01.2018', 104), 20, 0),
		   ('Januarska 15%', CONVERT(DATE, '25.12.2017', 104), CONVERT(DATE, '05.01.2018', 104), 15, 0)
GO


INSERT INTO NAMESTAJ 
	VALUES ('Veliki kauc', 10, 22000, 1, 1, 0),
		   ('Kauc bez makaza', 20, 12500, 1, 1, 0),
		   ('Sofa radojka', 31, 8400, 2, 1, 0),
		   ('Bela sofa', 18, 8000, 2, 2, 0),
		   ('Trpezarijska stolica', 9, 3600, 3, 2, 0),
		   ('Bastenska stolica', 14, 5100, 3, 3, 0),
		   ('Bracni krevet', 7, 46000, 4, 3, 0),
		   ('Krevet rade', 12, 35500, 4, 3, 0)
GO



INSERT INTO DODATNE_USLUGE 
	VALUES ('Prevoz', 2500, 0),
		   ('Montaza', 4200, 0)
GO



INSERT INTO PRODAJA
	VALUES ('R1/2018', CONVERT(DATE, '06.01.2018', 104), 'Milos', 22000, 1, 0)
GO


INSERT INTO PRODAJA_STAVKE
	VALUES (1, 1, 2, 0),
		   (1, 2, 4, 0)
GO



/*
INSERT INTO AKCIJA_STAVKE 
	VALUES (1, 1, 0),
		   (1, 2, 0),
		   (2, 3, 0),
		   (3, 5, 0),
		   (3, 7, 0),
		   (3, 8, 0)
GO
*/



