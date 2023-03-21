# Proyecto-EquipoDeFutbol-Dapper

## Descripción del proyecto
El proyecto consiste en una Web API desarrollada en .NET que utiliza Dapper como ORM y SQLServer como base de datos. La API permite realizar operaciones CRUD sobre una base de datos que contiene información acerca de equipos de fútbol, jugadores y entrenadores.

## Entidad Relación
Puedes encontrar el diagrama entidad-relación del proyecto en el siguiente enlace:

https://lucid.app/lucidchart/2994039e-a15d-4c87-871b-1fe3edb4fe6f/edit?viewport_loc=-146%2C-300%2C2220%2C982%2C0_0&invitationId=inv_5667abc4-0ea5-459d-9799-efc0404d2983

## Base de datos
La base de datos se crea a partir del siguiente script SQL

```SQL
-- Crear la base de datos
CREATE DATABASE EquipoFutbolDB;
GO

-- Seleccionar la base de datos
USE EquipoFutbolDB;
GO

-- Crear la tabla Equipo
CREATE TABLE Equipo (
    ID INT PRIMARY KEY,
    NombreEquipo VARCHAR(50) NOT NULL,
    Ciudad VARCHAR(50) NOT NULL
);
GO

-- Crear la tabla Jugador
CREATE TABLE Jugador (
    ID INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Edad INT NOT NULL,
    Posicion VARCHAR(50) NOT NULL,
    NumeroCamiseta INT NOT NULL,
    EquipoID INT NOT NULL,
    CONSTRAINT FK_Jugador_Equipo FOREIGN KEY (EquipoID) REFERENCES Equipo(ID)
);
GO

-- Crear la tabla Entrenador
CREATE TABLE Entrenador (
    ID INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Edad INT NOT NULL,
    Pais VARCHAR(50) NOT NULL,
    EquipoID INT NOT NULL,
    CONSTRAINT FK_Entrenador_Equipo FOREIGN KEY (EquipoID) REFERENCES Equipo(ID)
);
GO
