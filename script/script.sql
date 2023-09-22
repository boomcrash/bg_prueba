CREATE DATABASE banco;
GO

USE banco;
GO

CREATE TABLE Usuario (
    id INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(255) NOT NULL unique,
    [password] VARCHAR(255) NOT NULL,
    nombre VARCHAR(255) NULL,
    [plan] INT NULL,
    telefono VARCHAR(20) NULL
);

-- Insertar un usuario sin especificar el ID
INSERT INTO Usuario (email, [password], nombre, [plan], telefono)
VALUES ('usuario1@example.com', 'contrasena123', 'Usuario 1', 1, '1234567890');

-- Insertar otro usuario sin especificar el ID
INSERT INTO Usuario (email, [password], nombre, [plan], telefono)
VALUES ('usuario2@example.com', 'password456', 'Usuario 2', NULL, '9876543210');


GO

CREATE TABLE Producto (
    id INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(255) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    estado BIT NOT NULL,
    detalle TEXT,
    imagen VARCHAR(255)
);
GO




CREATE PROCEDURE sp_crud_login
    @opcion INT,
    @usuario_id INT = NULL,
    @email VARCHAR(255) = NULL,
    @password VARCHAR(255) = NULL
AS
BEGIN
    -- Consultar un usuario por ID
    IF @opcion = 1
    BEGIN
        IF @email IS NOT NULL
            SELECT * FROM Usuario WHERE email = @email;
        ELSE
            SELECT * FROM Usuario;
    END
    -- Verificar que un usuario y contraseña existen
    ELSE IF @opcion = 2
    BEGIN
        IF EXISTS (SELECT 1 FROM Usuario WHERE email = @email AND [password] = @password)
            SELECT 'Usuario y contraseña válidos' AS mensaje;
        ELSE
            SELECT 'Usuario y contraseña no válidos' AS mensaje;
    END
END;

GO




CREATE PROCEDURE sp_crud_producto
    @opcion INT,
    @producto_id INT = NULL,
    @descripcion VARCHAR(255) = NULL,
    @precio DECIMAL(10, 2) = NULL,
    @estado BIT = NULL,
    @detalle TEXT = NULL,
    @imagen VARCHAR(255) = NULL
AS
BEGIN
    IF @opcion = 1
    BEGIN
        INSERT INTO Producto (descripcion, precio, estado, detalle, imagen)
        VALUES (@descripcion, @precio, @estado, @detalle, @imagen);
    END
    ELSE IF @opcion = 2
    BEGIN
        IF @producto_id IS NOT NULL
            SELECT * FROM Producto WHERE id = @producto_id;
        ELSE
            SELECT * FROM Producto;
    END
    ELSE IF @opcion = 3
    BEGIN
        UPDATE Producto
        SET descripcion = @descripcion, precio = @precio, estado = @estado, detalle = @detalle, imagen = @imagen
        WHERE id = @producto_id;
    END
    ELSE IF @opcion = 4
    BEGIN
        DELETE FROM Producto WHERE id = @producto_id;
    END
END;
GO
