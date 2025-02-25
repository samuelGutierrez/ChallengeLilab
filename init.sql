CREATE DATABASE ClubRecreativo;

USE ClubRecreativo;

-- Tabla de Roles
CREATE TABLE Roles (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE
);

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreCompleto VARCHAR(100) NOT NULL,
    Usuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(255) NOT NULL,
    RolId INT NOT NULL,
    FOREIGN KEY (RolId) REFERENCES Roles(Id)
);

-- Tabla de Clientes
CREATE TABLE Clientes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreCompleto VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Telefono VARCHAR(20),
    TipoCliente ENUM('Visitante', 'Miembro') NOT NULL
);

-- Tabla de Accesos
CREATE TABLE Accesos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ClienteId INT NOT NULL,
    FechaEntrada DATETIME NOT NULL,
    FechaSalida DATETIME,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

-- Tabla de Valet Parking
CREATE TABLE ValetParking (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreCompleto VARCHAR(100) NOT NULL
);

-- Tabla de Ubicaciones de Estacionamiento
CREATE TABLE UbicacionesEstacionamiento (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CodigoUbicacion VARCHAR(20) NOT NULL UNIQUE
);

-- Tabla de Vehículos
CREATE TABLE Vehiculos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    AccesoId INT NOT NULL,
    Marca VARCHAR(50),
    Modelo VARCHAR(50),
    Placa VARCHAR(20),
    ValetParkingId INT,
    UbicacionEstacionamientoId INT,
    FechaEntrada DATETIME NOT NULL,
    FechaSalida DATETIME,
    FOREIGN KEY (AccesoId) REFERENCES Accesos(Id),
    FOREIGN KEY (ValetParkingId) REFERENCES ValetParking(Id),
    FOREIGN KEY (UbicacionEstacionamientoId) REFERENCES UbicacionesEstacionamiento(Id)
);
