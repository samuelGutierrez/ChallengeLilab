-- Insertar roles
INSERT INTO Roles (Nombre) VALUES ('Administrador');
INSERT INTO Roles (Nombre) VALUES ('PersonalAutorizado');

-- Insertar usuarios
INSERT INTO Usuarios (NombreCompleto, Usuario, Contrasena, RolId)
VALUES
  ('Admin General', 'admin', 'admin1234', 1),
  ('Empleado Autorizado', 'empleado1', 'empleado1234', 2);

-- Insertar clientes
INSERT INTO Clientes (NombreCompleto, Email, Telefono, TipoCliente)
VALUES
  ('Carlos Pérez', 'carlos.perez@example.com', '1234567890', 'Visitante'),
  ('Laura García', 'laura.garcia@example.com', '0987654321', 'Miembro'),
  ('Sofía Martínez', 'sofia.martinez@example.com', '1122334455', 'Miembro');

-- Insertar ubicaciones de estacionamiento
INSERT INTO UbicacionesEstacionamiento (CodigoUbicacion)
VALUES
  ('A1'),
  ('B2'),
  ('C3');

-- Insertar valet parking
INSERT INTO ValetParking (NombreCompleto)
VALUES
  ('Pedro Valet'),
  ('Juan Valet'),
  ('Miguel Valet');

-- Insertar accesos
INSERT INTO Accesos (ClienteId, FechaEntrada, FechaSalida)
VALUES
  (1, '2025-02-23 08:00:00', '2025-02-23 12:00:00'),
  (2, '2025-02-23 09:30:00', NULL),
  (3, '2025-02-23 10:00:00', NULL);

-- Insertar vehículos
INSERT INTO Vehiculos (Marca, Modelo, Placa, AccesoId, ValetParkingId, UbicacionEstacionamientoId, FechaEntrada, FechaSalida)
VALUES
  ('Toyota', 'Corolla', 'ABC123', 1, 1, 1, '2025-02-23 08:05:00', '2025-02-23 12:05:00'),
  ('Honda', 'Civic', 'XYZ789', 2, 2, 2, '2025-02-23 09:35:00', NULL),
  ('Ford', 'Focus', 'LMN456', 3, 3, 3, '2025-02-23 10:10:00', NULL);
