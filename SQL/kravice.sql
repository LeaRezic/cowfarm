-- /// CREATE DB
--USE master
--GO
--DROP DATABASE FarmaKrava
--CREATE DATABASE FarmaKrava
--GO
--USE FarmaKrava
--GO

-- /// CREATE TABLES
CREATE TABLE Breed (
	IDBreed INT IDENTITY
	,Name NVARCHAR(255) NOT NULL
	,CONSTRAINT PK_Breed PRIMARY KEY (IDBreed)
	,CONSTRAINT UQ_Name UNIQUE (Name)
)

CREATE TABLE Cow (
	IDCow INT IDENTITY
	,Name NVARCHAR(255) NOT NULL
	,BreedID INT NOT NULL
	,DateOfBirth DATE NOT NULL
	,VeterinaryID NVARCHAR(25) NOT NULL
	,DateOfArrival DATE NOT NULL
	,CalfCount INT NOT NULL
	,PicturePath NVARCHAR(255)
	,CONSTRAINT PK_Cow PRIMARY KEY (IDCow)
	,CONSTRAINT FK_Cow_Breed FOREIGN KEY (BreedID) REFERENCES Breed (IDBreed)
	,CONSTRAINT CH_VeterinaryID CHECK (VeterinaryID LIKE 'HR%')
	,CONSTRAINT UQ_VeterinaryID UNIQUE (VeterinaryID)
)

CREATE TABLE DailyMilkProduction (
	IDDailyMilkProduction INT IDENTITY
	,EntryDate DATE
	,CowID INT
	,MilkInLiters DECIMAL
	,AverageFat DECIMAL
	,AverageMicroorganisms DECIMAL
	,CONSTRAINT PK_DailyMilkProduction PRIMARY KEY (IDDailyMilkProduction)
	,CONSTRAINT FK_DailyMilkProduction_Cow FOREIGN KEY (CowID) REFERENCES Cow (IDCow)
)
GO

-- // INSERT
CREATE PROCEDURE initialData
AS
	INSERT INTO Breed(Name)
	VALUES('Holstein')
	,('Simental')
	,('Regular Cow')

	INSERT INTO Cow(Name, BreedID, DateOfBirth, VeterinaryID, DateOfArrival, CalfCount, PicturePath)
	VALUES('Zdenka', 1, '2018-11-10', 'HR123456789', '2019-03-20', 3, 'cow1.jpg')
	,('Milka', 1, '2017-12-25', 'HR223456789', '2018-05-12', 9, 'cow2.jpg')
	,('Kata', 2, '2018-05-05', 'HR323456789', '2018-10-20', 7, 'cow3.jpg')
	,('Tonka', 3, '2019-02-02', 'HR423456789', '2019-05-30', 6, 'cow4.jpg')
	,('Slavica', 3, '2019-03-03', 'HR523456789', '2019-06-30', 6, 'cow5.jpg')

	INSERT INTO DailyMilkProduction(EntryDate, CowID, MilkInLiters, AverageFat, AverageMicroorganisms)
	VALUES('2019-10-25', 1, 25, 33.6, 78.4)
	,('2019-10-25', 2, 26, 30.4, 68.1)
	,('2019-10-25', 3, 22, 31.5, 98.7)
	,('2019-10-25', 4, 28, 39.7, 71.3)
	,('2019-10-25', 5, 21, 35.6, 75.9)
	,('2019-10-26', 1, 30, 34, 65.1)
	,('2019-10-26', 2, 27, 35.1, 78.3)
	,('2019-10-26', 3, 25, 38.3, 71.5)
	,('2019-10-26', 4, 27, 41.7, 88.9)
	,('2019-10-26', 5, 26, 29.6, 63.8)
GO

-- // RESET DB
CREATE PROCEDURE resetDatabase
AS
IF EXISTS (SELECT * FROM DailyMilkProduction)
	BEGIN
		DELETE FROM DailyMilkProduction
		DBCC CHECKIDENT ('DailyMilkProduction', RESEED, 0);
	END
IF EXISTS (SELECT * FROM Cow)
	BEGIN
		DELETE FROM Cow
		DBCC CHECKIDENT ('Cow', RESEED, 0);
	END
IF EXISTS (SELECT * FROM Breed)
	BEGIN
		DELETE FROM Breed
		DBCC CHECKIDENT ('Breed', RESEED, 0);
	END
GO


SELECT * FROM Breed
SELECT * FROM Cow
SELECT * FROM DailyMilkProduction
EXEC resetDatabase
SELECT * FROM Breed
SELECT * FROM Cow
SELECT * FROM DailyMilkProduction
EXEC initialData
SELECT * FROM Breed
SELECT * FROM Cow
SELECT * FROM DailyMilkProduction