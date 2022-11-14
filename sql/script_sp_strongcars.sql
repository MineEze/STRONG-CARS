USE [StrongCars]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCantidadDeIntentosLogIn]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------------------------------------------------
CREATE PROC [dbo].[ActualizarCantidadDeIntentosLogIn]

@CantidadIntentosLogInParam int,
@IdUsuarioParam int

AS
BEGIN

UPDATE Usuario
SET CantidadIntentosLogIn = @CantidadIntentosLogInParam
WHERE Id = @IdUsuarioParam;

END



GO
/****** Object:  StoredProcedure [dbo].[ActualizarKilometraje]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ActualizarKilometraje]

@Id int,
@Kilometraje int

AS BEGIN

UPDATE Vehiculo 
SET Kilometraje = @Kilometraje
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaAlquiler]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaAlquiler]

@Id int,
@IdSucursalOrigen int,
@IdSucursalDestino int,
@IdCliente int

AS BEGIN

INSERT INTO Alquiler (Id, IdSucursalOrigen, IdSucursalDestino, IdCliente)
VALUES (@Id, @IdSucursalOrigen, @IdSucursalDestino, @IdCliente);

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaAlquilerConChofer]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaAlquilerConChofer]

@Id int,
@IdChofer int

AS BEGIN

INSERT INTO AlquilerConChofer (Id, IdChofer)
VALUES (@Id, @IdChofer);

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaChofer]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaChofer]

@Id int,
@IdTelefono int

AS 
BEGIN

INSERT INTO Chofer (Id, IdTelefono)
VALUES (@Id, @IdTelefono);

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaCliente]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaCliente]

@Id int,
@IdTelefono int,
@Licencia varchar(20)

AS 
BEGIN

INSERT INTO Cliente (Id, IdTelefono, Licencia)
VALUES (@Id, @IdTelefono, @Licencia);

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaClienteConEmpresa]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaClienteConEmpresa]

@Id int,
@IdTelefono int,
@IdEmpresa int,
@Licencia varchar(20)

AS 
BEGIN

INSERT INTO Cliente (Id, IdTelefono, IdEmpresa, Licencia)
VALUES (@Id, @IdTelefono, @IdEmpresa, @Licencia);

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaDireccion]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaDireccion]

@Calle varchar(50),
@Altura int,
@Unidad varchar(10),
@CodigoPostal varchar(10)

AS 
BEGIN

INSERT INTO Direccion (Calle, Altura, Unidad, CodigoPostal)
VALUES (@Calle, @Altura, @Unidad, @CodigoPostal)
SELECT SCOPE_IDENTITY();

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaEmpresa]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaEmpresa]

@Nombre varchar(50)

AS BEGIN

INSERT INTO Empresa (Nombre) 
VALUES (@Nombre)
SELECT SCOPE_IDENTITY();

END
------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[AltaGrupoPermiso]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaGrupoPermiso]

@IdGrupo int,
@IdHijo int

AS BEGIN

INSERT INTO GrupoPermiso (IdGrupo, IdHijo) 
VALUES (@IdGrupo, @IdHijo);

END
GO
/****** Object:  StoredProcedure [dbo].[AltaPermiso]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaPermiso]

@Id int,
@Nombre varchar(50)

AS BEGIN

INSERT INTO Permiso (Id, Nombre) 
VALUES (@Id, @Nombre);

END
GO
/****** Object:  StoredProcedure [dbo].[AltaPersona]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaPersona]

@IdDireccion int,
@Nombre varchar(50),
@Apellido varchar(50),
@DNI varchar(12),
@Email varchar(50),
@UltimaModificacion datetime2


AS 
BEGIN

INSERT INTO Persona (IdDireccion, Nombre, Apellido, DNI, Email, UltimaModificacion)
VALUES (@IdDireccion, @Nombre, @Apellido, @DNI, @Email, @UltimaModificacion)
SELECT SCOPE_IDENTITY();

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaRecargoSucursal]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaRecargoSucursal]

@IdSucursalOrigen int,
@IdSucursalDestino int,
@Recargo decimal

AS 
BEGIN

INSERT INTO RecargoSucursal (IdSucursalOrigen, IdSucursalDestino, Recargo)
VALUES (@IdSucursalOrigen, @IdSucursalDestino, @Recargo);

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaReporte]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaReporte]

@IdVehiculo int,
@Descripcion varchar(200),
@Fecha datetime2

AS BEGIN

INSERT INTO Reporte (IdVehiculo, Descripcion, Fecha)
VALUES (@IdVehiculo, @Descripcion, @Fecha);

END
GO
/****** Object:  StoredProcedure [dbo].[AltaReserva]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaReserva]

@IdVehiculo int,
@FechaDeInicio datetime2,
@FechaDeFin datetime2,
@CostoVehiculo decimal,
@CostoChofer decimal,
@RecargoSucursal decimal,
@Total decimal,
@UltimaModificacion datetime2

AS BEGIN

INSERT INTO Reserva (IdVehiculo, FechaDeInicio, FechaDeFin, CostoVehiculo, CostoChofer, RecargoSucursal, Total, UltimaModificacion)
VALUES (@IdVehiculo, @FechaDeInicio, @FechaDeFin, @CostoVehiculo, @CostoChofer, @RecargoSucursal, @Total, @UltimaModificacion)
SELECT SCOPE_IDENTITY();

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaSucursal]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaSucursal]

@IdDireccion int,
@IdGerente int,
@UltimaModificacion datetime2

AS
BEGIN

INSERT INTO Sucursal (IdDireccion, IdGerente, UltimaModificacion)
VALUES (@IdDireccion, @IdGerente, @UltimaModificacion);
SELECT SCOPE_IDENTITY();

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaTelefonoConSucursal]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaTelefonoConSucursal]

@IdSucursal int,
@Caracteristica varchar(10),
@Numero varchar(20)

AS
BEGIN

INSERT INTO Telefono (IdSucursal, Caracteristica, Numero)
VALUES (@IdSucursal, @Caracteristica, @Numero);
SELECT SCOPE_IDENTITY();

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaTelefonoSinSucursal]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaTelefonoSinSucursal]

@Caracteristica varchar(10),
@Numero varchar(20)

AS
BEGIN

INSERT INTO Telefono (Caracteristica, Numero)
VALUES (@Caracteristica, @Numero);
SELECT SCOPE_IDENTITY();

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaUsuario]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaUsuario]

@Id int,
@NombreDeUsuario varchar(50),
@Password varchar(50)

AS
BEGIN

INSERT INTO Usuario (Id, NombreDeUsuario, Password)
VALUES (@Id, @NombreDeUsuario, @Password);

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AltaUsuarioPermiso]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaUsuarioPermiso]

@IdUsuario int,
@IdPermiso int

AS
BEGIN

INSERT INTO UsuarioPermiso (IdUsuario, IdPermiso)
VALUES (@IdUsuario, @IdPermiso);

END
GO
/****** Object:  StoredProcedure [dbo].[AltaVehiculo]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AltaVehiculo]

@IdModelo int,
@IdSucursal int,
@Patente varchar(10),
@Kilometraje int,
@PrecioDiarioBase int,
@FechaDeInicio datetime2,
@NivelBlindaje int,
@UltimaModificacion datetime2

AS BEGIN

INSERT INTO Vehiculo (Patente, IdModelo, NivelBlindaje, Kilometraje, PrecioDiarioBase, IdSucursal, FechaDeInicio, UltimaModificacion)
VALUES (@Patente, @IdModelo, @NivelBlindaje, @Kilometraje, @PrecioDiarioBase, @IdSucursal, @FechaDeInicio, @UltimaModificacion);

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[BajaAlquiler]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaAlquiler]

@Id int

AS BEGIN

DELETE FROM Alquiler
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[BajaAlquilerConChofer]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaAlquilerConChofer]

@Id int

AS BEGIN

DELETE FROM AlquilerConChofer
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[BajaChofer]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaChofer]

@Id int

AS 
BEGIN

UPDATE Chofer
SET Borrado = 1
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[BajaCliente]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaCliente]

@Id int

AS 
BEGIN

UPDATE Cliente
SET Borrado = 1
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[BajaRecargoSucursal]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaRecargoSucursal]

@IdSucursal int

AS 
BEGIN

DELETE FROM RecargoSucursal
WHERE IdSucursalOrigen = @IdSucursal;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[BajaReserva]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaReserva]

@Id int

AS BEGIN

DELETE FROM Reserva
WHERE Id = @Id;

END
GO
/****** Object:  StoredProcedure [dbo].[BajaSucursal]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaSucursal]

@Id int

AS
BEGIN

UPDATE Sucursal 
SET Borrado = 1
WHERE Id = @Id;

END



GO
/****** Object:  StoredProcedure [dbo].[BajaTelefonoSucursal]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaTelefonoSucursal]

@IdSucursal int

AS 
BEGIN

DELETE FROM Telefono
WHERE IdSucursal = @IdSucursal;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[BajaUsuario]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaUsuario]

@IdUsuario int

AS
BEGIN

UPDATE Usuario
SET Borrado = 1
WHERE Id = @IdUsuario;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[BajaUsuarioPermiso]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaUsuarioPermiso]

@IdUsuario int

AS
BEGIN

DELETE FROM UsuarioPermiso
WHERE IdUsuario = @IdUsuario;

END
GO
/****** Object:  StoredProcedure [dbo].[BajaVehiculo]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BajaVehiculo]

@Id int

AS BEGIN

UPDATE Vehiculo
SET Borrado = 1
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[BloquearUsuario]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------------------------------------------------
CREATE PROC [dbo].[BloquearUsuario]

@IdUsuarioParam int

AS
BEGIN

UPDATE Usuario
SET Bloqueado = 1
WHERE Id = @IdUsuarioParam;

END



GO
/****** Object:  StoredProcedure [dbo].[DesbloquearUsuario]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DesbloquearUsuario]

@Id int

AS BEGIN

UPDATE Usuario
SET CantidadIntentosLogIn = 0, Bloqueado = 0
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ListarAlquilerConChofer]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarAlquilerConChofer]

AS 
BEGIN

SELECT Reserva.Id, IdVehiculo, FechaDeInicio, FechaDeFin, Reserva.CostoVehiculo, Reserva.CostoChofer, Reserva.RecargoSucursal, Reserva.Total, UltimaModificacion, IdChofer
FROM Reserva
INNER JOIN AlquilerConChofer ON Reserva.Id = AlquilerConChofer.Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ListarAlquileres]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarAlquileres]

AS 
BEGIN

SELECT Reserva.Id, IdVehiculo, FechaDeInicio, FechaDeFin, Reserva.CostoVehiculo, Reserva.CostoChofer, Reserva.RecargoSucursal, Reserva.Total, Reserva.UltimaModificacion, IdSucursalOrigen, IdSucursalDestino, Retornado, Nombre, Apellido
FROM Reserva
INNER JOIN Alquiler ON Reserva.Id = Alquiler.Id
INNER JOIN Persona ON Persona.Id = Alquiler.IdCliente;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ListarBitacora]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarBitacora]

AS 
BEGIN

SELECT IdUsuario, Mensaje, FechaYHora, NombreDeUsuario
FROM Bitacora
INNER JOIN Usuario ON IdUsuario = Usuario.Id
ORDER BY FechaYHora DESC;

END
GO
/****** Object:  StoredProcedure [dbo].[ListarChoferes]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarChoferes]

AS
BEGIN

SELECT Chofer.Id, IdTelefono, Persona.Nombre AS PersonaNombre, Apellido, Calle, Altura,
Unidad, CodigoPostal, Email, DNI, Persona.IdDireccion, Numero, Caracteristica
FROM Chofer
INNER JOIN Persona
ON Persona.Id = Chofer.Id
INNER JOIN Direccion
ON Persona.IdDireccion = Direccion.Id
INNER JOIN Telefono
ON Chofer.IdTelefono = Telefono.Id
WHERE Borrado = 0;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ListarClientes]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarClientes]

AS
BEGIN

SELECT Cliente.Id, IdTelefono, Persona.Nombre AS PersonaNombre, Apellido, Calle, Altura,
Unidad, CodigoPostal, Email, DNI, Persona.IdDireccion, Numero, Caracteristica, Licencia, Empresa.Nombre AS EmpresaNombre
FROM Cliente
INNER JOIN Persona
ON Persona.Id = Cliente.Id
INNER JOIN Direccion
ON Persona.IdDireccion = Direccion.Id
INNER JOIN Telefono
ON Cliente.IdTelefono = Telefono.Id
LEFT JOIN Empresa
ON Cliente.IdEmpresa = Empresa.Id
WHERE Borrado = 0;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ListarEmpresas]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarEmpresas]

AS BEGIN

SELECT Id, Nombre
FROM Empresa;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ListarGrupoPermiso]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarGrupoPermiso]

AS
BEGIN

SELECT IdGrupo, IdHijo 
FROM GrupoPermiso;

END
GO
/****** Object:  StoredProcedure [dbo].[ListarMarcas]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarMarcas]

AS BEGIN

SELECT Id, Nombre
FROM Marca;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ListarModelos]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarModelos]

AS BEGIN

SELECT Id, IdMarca, Nombre
FROM Modelo;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ListarPermiso]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarPermiso]

AS
BEGIN

SELECT Id, Nombre
FROM Permiso;

END
GO
/****** Object:  StoredProcedure [dbo].[ListarRecargosSucursales]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarRecargosSucursales]

AS
BEGIN

SELECT IdSucursalOrigen, IdSucursalDestino, Recargo
FROM RecargoSucursal;

END



GO
/****** Object:  StoredProcedure [dbo].[ListarReportes]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarReportes]

AS BEGIN

SELECT Id, IdVehiculo, Descripcion, Fecha
FROM Reporte;

END
GO
/****** Object:  StoredProcedure [dbo].[ListarReservas]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarReservas]

AS 
BEGIN

SELECT Id, IdVehiculo, FechaDeInicio, FechaDeFin, CostoVehiculo, CostoChofer, RecargoSucursal, Total, UltimaModificacion
FROM Reserva;

END
GO
/****** Object:  StoredProcedure [dbo].[ListarSucursales]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarSucursales]

AS
BEGIN

SELECT Id, IdDireccion, IdGerente
FROM Sucursal
WHERE Borrado = 0;

END



GO
/****** Object:  StoredProcedure [dbo].[ListarTelefonos]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarTelefonos]

@IdSucursal int

AS
BEGIN

SELECT Id, Caracteristica, Numero
FROM Telefono
WHERE IdSucursal = @IdSucursal;

END



GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarioPermiso]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarUsuarioPermiso]

@IdUsuarioParam int AS

BEGIN

SELECT IdPermiso
FROM UsuarioPermiso
WHERE IdUsuario= @IdUsuarioParam;

END

GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarios]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------------------------------------------------
CREATE PROC [dbo].[ListarUsuarios]

AS
BEGIN

SELECT NombreDeUsuario, Usuario.Id, Password, CantidadIntentosLogIn, Bloqueado, Borrado, Persona.Nombre AS PersonaNombre, 
Apellido, Calle, Altura, Unidad, CodigoPostal, Email, DNI, Persona.IdDireccion
FROM Usuario
INNER JOIN Persona
ON Persona.Id = Usuario.Id
INNER JOIN Direccion
ON Persona.IdDireccion = Direccion.Id
WHERE Borrado = 0;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ListarVehiculos]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarVehiculos]

AS
BEGIN

SELECT Vehiculo.Id, IdModelo, IdSucursal, Patente, Kilometraje, PrecioDiarioBase,
FechaDeInicio, NivelBlindaje, UltimaModificacion, Borrado, Modelo.Nombre AS ModeloNombre, Marca.Nombre AS MarcaNombre, Marca.Id AS MarcaId
FROM Vehiculo
INNER JOIN Modelo ON IdModelo = Modelo.Id
INNER JOIN Marca ON IdMarca = Marca.Id
WHERE Borrado = 0;

END



GO
/****** Object:  StoredProcedure [dbo].[ModificarCliente]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ModificarCliente]

@Id int,
@Licencia varchar(20)

AS 
BEGIN

UPDATE Cliente
SET Licencia = @Licencia
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ModificarDireccion]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ModificarDireccion]

@Id int,
@Calle varchar(50),
@Altura int,
@Unidad varchar(10),
@CodigoPostal varchar(10)

AS
BEGIN

UPDATE Direccion
SET Calle = @Calle, Altura = @Altura, Unidad = @Unidad, CodigoPostal = @CodigoPostal
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ModificarPersona]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ModificarPersona]

@Id int,
@Nombre varchar(50),
@Apellido varchar(50),
@DNI varchar(12),
@Email varchar(50),
@UltimaModificacion datetime2

AS
BEGIN

UPDATE Persona 
SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Email = @Email, UltimaModificacion = @UltimaModificacion
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ModificarSucursal]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ModificarSucursal]

@Id int,
@IdGerente int,
@UltimaModificacion datetime2

AS
BEGIN

UPDATE Sucursal 
SET IdGerente = @IdGerente, UltimaModificacion = @UltimaModificacion
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ModificarTelefono]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ModificarTelefono]

@Id int,
@Caracteristica varchar(10),
@Numero varchar(20)

AS
BEGIN

UPDATE Telefono 
SET Caracteristica = @Caracteristica, Numero = @Numero
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ModificarUsuario]

@Id int,
@NombreDeUsuario varchar(50)

AS
BEGIN

UPDATE Usuario
SET NombreDeUsuario = @NombreDeUsuario
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[ModificarVehiculo]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ModificarVehiculo]

@Id int,
@IdModelo int,
@IdSucursal int,
@Patente varchar(10),
@Kilometraje int,
@PrecioDiarioBase int,
@NivelBlindaje int,
@UltimaModificacion datetime2,
@FechaDeInicio datetime2

AS
BEGIN

UPDATE Vehiculo
SET
IdModelo = @IdModelo,
IdSucursal = @IdSucursal,
Patente = @Patente,
Kilometraje = @Kilometraje,
PrecioDiarioBase = @PrecioDiarioBase,
NivelBlindaje = @NivelBlindaje,
FechaDeInicio = @FechaDeInicio,
UltimaModificacion = @UltimaModificacion
WHERE Id = @Id;

END



GO
/****** Object:  StoredProcedure [dbo].[ObtenerDireccion]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ObtenerDireccion]

@Id int

AS
BEGIN

SELECT Calle, Altura, Unidad, CodigoPostal
FROM Direccion
WHERE Id = @Id;

END



GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------------------------------------------------
CREATE PROC [dbo].[ObtenerUsuario]

@NombreDeUsuarioParam varchar(50) 

AS
BEGIN

SELECT Usuario.Id, Password, CantidadIntentosLogIn, Bloqueado, Borrado, Persona.Nombre, Apellido
FROM Usuario
INNER JOIN Persona
ON Persona.Id = Usuario.Id
WHERE NombreDeUsuario = @NombreDeUsuarioParam;

END



GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarioPorId]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------------------------------------------------
CREATE PROC [dbo].[ObtenerUsuarioPorId]

@IdUsuario int

AS
BEGIN

SELECT Usuario.Id, Password, CantidadIntentosLogIn, Bloqueado, Borrado, Nombre, Apellido, NombreDeUsuario
FROM Usuario
INNER JOIN Persona
ON Persona.Id = Usuario.Id
WHERE Usuario.Id = @IdUsuario;

END



GO
/****** Object:  StoredProcedure [dbo].[RegistrarMensajeBitacora]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RegistrarMensajeBitacora]

@MensajeParam varchar(500),
@IdUsuarioParam int,
@FechaYHoraParam datetime2(7)

AS
BEGIN

INSERT INTO Bitacora (Mensaje, IdUsuario, FechaYHora) 
VALUES (@MensajeParam, @IdUsuarioParam, @FechaYHoraParam);

END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarMensajeBitacoraSinUsuario]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RegistrarMensajeBitacoraSinUsuario]

@MensajeParam varchar(500),
@FechaYHoraParam datetime2(7)

AS
BEGIN

INSERT INTO Bitacora (Mensaje, FechaYHora) 
VALUES (@MensajeParam, @FechaYHoraParam);

END

GO
/****** Object:  StoredProcedure [dbo].[RetornarVehiculo]    Script Date: 01/11/2022 0:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RetornarVehiculo]

@Id int

AS BEGIN

UPDATE Alquiler
SET Retornado = 1
WHERE Id = @Id;

END
------------------------------------------------------------------------------------------------------------------------



GO
