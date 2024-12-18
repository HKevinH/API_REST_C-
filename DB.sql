
-- create database practica;
DROP DATABASE IF EXISTS practica;
CREATE DATABASE practica;
USE practica;

CREATE TABLE Deportista (
    `Id` INT PRIMARY KEY,
    `Name` NVARCHAR(100) NOT NULL,
    `Country` NVARCHAR(100) NOT NULL
);

CREATE TABLE Resultados (
    `Id` INT PRIMARY KEY,
    `DeportistaId` INT NOT NULL,
    `Modalid` NVARCHAR(100) NOT NULL,
    `Peso` INT NOT NULL,
    FOREIGN KEY (`DeportistaId`) REFERENCES Deportista(`Id`)
);

INSERT INTO Deportista (`Id`, `Name`, `Country`) VALUES 
(1, 'Carlos Alviz', 'AUS'),
(2, 'Andres Sabogal', 'CHN'),
(3, 'Jorge Ortega', 'FRA'),
(4, 'Pablo Velasco', 'ALE');


INSERT INTO Resultados (`Id`, `DeportistaId`, `Modalid`, `Peso`) VALUES
(1, 1, 'Arranque', 134),
(2, 1, 'Envión', 177),
(3, 2, 'Arranque', 130),
(4, 2, 'Envión', 180),
(5, 3, 'Arranque', 125),
(6, 3, 'Envión', 184),
(7, 4, 'Arranque', 0),
(8, 4, 'Envión', 150);
