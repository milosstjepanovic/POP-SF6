CREATE TABLE TipNamestaja (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv varchar(80),
	Obrisan BIT
)
GO

CREATE TABLE Namestaj (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	TipNamestajaId INT,
	Naziv varchar(100),
	Kolicina INT,
	Cena NUMERIC(9, 2),
	Obrisan BIT
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id)
)
GO