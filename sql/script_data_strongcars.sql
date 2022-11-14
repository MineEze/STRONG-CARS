USE [StrongCars]
GO
SET IDENTITY_INSERT [dbo].[Empresa] ON 

GO
INSERT [dbo].[Empresa] ([Id], [Nombre]) VALUES (1, N'Santander')
GO
INSERT [dbo].[Empresa] ([Id], [Nombre]) VALUES (2, N'UAI')
GO
SET IDENTITY_INSERT [dbo].[Empresa] OFF
GO
SET IDENTITY_INSERT [dbo].[Direccion] ON 

GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (1, N'Hidalgo', 1064, N'4B', N'1405')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (2, N'Larrazabal', 4040, N'0', N'1439')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (3, N'Av. Avellaneda', 1863, N'2ªH', N'C1406FYD')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (4, N'Av. Cabildo', 350, N'', N'C1426AAQ')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (5, N'Av. Cabildo', 3653, N'', N'C1429AAH')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (6, N'Av. del Libertador', 1801, N'', N'B1638BGE')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (7, N'Av. Bartolomé Mitre', 202, N'', N'B1603CQP')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (8, N'Aguilar', 2584, N'7°A', N'C1426DSL')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (9, N'Unanue', 828, N'5°C', N'B1772DMP')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (10, N'Dolores', 221, N'', N'C1407KGG')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (11, N'Bogotá', 1773, N'', N'C1406GBE')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (12, N'Calle 58', 6351, N'', N'B1885AQI')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (13, N'Larrea', 2857, N'', N'B1878')
GO
INSERT [dbo].[Direccion] ([Id], [Calle], [Altura], [Unidad], [CodigoPostal]) VALUES (14, N'Gral. las Heras', 933, N'', N'B1638')
GO
SET IDENTITY_INSERT [dbo].[Direccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (1, 1, N'Ezequiel', N'Minetti', N'35969091', N'ezeminetti@gmail.com', CAST(N'2022-10-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (2, 2, N'Gustavo', N'Schmutz', N'35907826', N'gusschmutz@gmail.com', CAST(N'2022-10-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (3, 3, N'Eliana', N'Minetti', N'36946593', N'elianahoy@gmail.com', CAST(N'2022-11-14 07:55:29.6770000' AS DateTime2))
GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (4, 8, N'Pablo', N'Minetti', N'17360169', N'pablo.minetti@gmail.com', CAST(N'2022-11-14 08:33:26.1500000' AS DateTime2))
GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (5, 9, N'Mónica', N'Taglioli', N'17547256', N'tagliolim@hotmail.com', CAST(N'2022-11-14 08:35:17.4800000' AS DateTime2))
GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (6, 10, N'Juan Cruz', N'Dalvicia', N'40734789', N'juancruzd@gmail.com', CAST(N'2022-11-14 09:00:17.9670000' AS DateTime2))
GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (7, 11, N'Alan Pablo', N'Perez', N'37026185', N'alan.perez@hotmail.com', CAST(N'2022-11-14 10:48:33.9300000' AS DateTime2))
GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (8, 12, N'Vanesa', N'Canepa', N'33762982', N'vcanepa@gmail.com', CAST(N'2022-11-14 10:26:19.2700000' AS DateTime2))
GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (9, 13, N'Pablo Alejandro', N'Centurión', N'32546038', N'pcenturion@gmail.com', CAST(N'2022-11-14 10:42:51.0830000' AS DateTime2))
GO
INSERT [dbo].[Persona] ([Id], [IdDireccion], [Nombre], [Apellido], [DNI], [Email], [UltimaModificacion]) VALUES (10, 14, N'Leandro', N'Gauna', N'32546038', N'lgauna@gmail.com', CAST(N'2022-11-14 10:42:23.7330000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
INSERT [dbo].[Usuario] ([Id], [NombreDeUsuario], [Password], [CantidadIntentosLogIn], [Bloqueado], [Borrado]) VALUES (1, N'ezequiel', N'D7216DEC976C1BEB88A5B60E749ABF07', 0, 0, 0)
GO
INSERT [dbo].[Usuario] ([Id], [NombreDeUsuario], [Password], [CantidadIntentosLogIn], [Bloqueado], [Borrado]) VALUES (2, N'gus1', N'DB5E1E5EBAB96BF1CB6936992DF9DBDA', 0, 0, 0)
GO
INSERT [dbo].[Usuario] ([Id], [NombreDeUsuario], [Password], [CantidadIntentosLogIn], [Bloqueado], [Borrado]) VALUES (3, N'eliana22', N'2DCEACF071D091FB0CE9E43E92493B29', 0, 0, 0)
GO
INSERT [dbo].[Usuario] ([Id], [NombreDeUsuario], [Password], [CantidadIntentosLogIn], [Bloqueado], [Borrado]) VALUES (6, N'juandalvicia', N'0C9C864E5B5C6E5446360CE4DC2ACC7C', 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Sucursal] ON 

GO
INSERT [dbo].[Sucursal] ([Id], [IdDireccion], [IdGerente], [Borrado], [UltimaModificacion]) VALUES (1, 4, 1, 0, CAST(N'2022-11-14 08:22:25.1770000' AS DateTime2))
GO
INSERT [dbo].[Sucursal] ([Id], [IdDireccion], [IdGerente], [Borrado], [UltimaModificacion]) VALUES (2, 5, 1, 0, CAST(N'2022-11-14 08:23:20.5730000' AS DateTime2))
GO
INSERT [dbo].[Sucursal] ([Id], [IdDireccion], [IdGerente], [Borrado], [UltimaModificacion]) VALUES (3, 6, 1, 0, CAST(N'2022-11-14 08:23:35.2970000' AS DateTime2))
GO
INSERT [dbo].[Sucursal] ([Id], [IdDireccion], [IdGerente], [Borrado], [UltimaModificacion]) VALUES (4, 7, 1, 0, CAST(N'2022-11-14 08:26:03.1670000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Sucursal] OFF
GO
SET IDENTITY_INSERT [dbo].[Telefono] ON 

GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (12, 1, N'11', N'40110800')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (13, 1, N'11', N'21545824')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (14, 2, N'11', N'40110000')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (15, 2, N'11', N'60308084')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (16, 3, N'11', N'40168800')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (17, 4, N'11', N'47967000')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (18, NULL, N'11', N'54117792')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (19, NULL, N'11', N'33067598')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (20, NULL, N'11', N'33765926')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (21, NULL, N'11', N'76285572')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (22, NULL, N'11', N'68791126')
GO
INSERT [dbo].[Telefono] ([Id], [IdSucursal], [Caracteristica], [Numero]) VALUES (23, NULL, N'11', N'61500960')
GO
SET IDENTITY_INSERT [dbo].[Telefono] OFF
GO
INSERT [dbo].[Cliente] ([Id], [IdTelefono], [IdEmpresa], [Licencia], [Borrado]) VALUES (7, 20, 1, N'37026185', 0)
GO
INSERT [dbo].[Cliente] ([Id], [IdTelefono], [IdEmpresa], [Licencia], [Borrado]) VALUES (8, 21, 1, N'33762982', 0)
GO
INSERT [dbo].[Cliente] ([Id], [IdTelefono], [IdEmpresa], [Licencia], [Borrado]) VALUES (9, 22, NULL, N'32546038', 0)
GO
INSERT [dbo].[Cliente] ([Id], [IdTelefono], [IdEmpresa], [Licencia], [Borrado]) VALUES (10, 23, 2, N'32546038', 0)
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (1, N'Ford')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (2, N'Volkswagen')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (3, N'BMW')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (4, N'Mercedes Benz')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (5, N'Audi')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (6, N'Chevrolet')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (7, N'Suzuki')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (8, N'Fiat')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (9, N'Citroen')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (10, N'Peugeot')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (11, N'Renault')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (12, N'Honda')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (13, N'Kia')
GO
INSERT [dbo].[Marca] ([Id], [Nombre]) VALUES (14, N'Toyota')
GO
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Modelo] ON 

GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (1, 1, N'Fiesta')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (2, 1, N'Mondeo')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (3, 2, N'Passat')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (4, 2, N'Vento')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (5, 3, N'320')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (6, 3, N'330')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (7, 3, N'430')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (8, 3, N'X5')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (9, 4, N'Clase A')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (10, 4, N'Clase C')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (11, 4, N'Clase E')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (12, 5, N'A4')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (13, 5, N'A5')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (14, 5, N'A6')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (15, 5, N'A8')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (16, 5, N'Q7')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (17, 6, N'Onix')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (18, 6, N'Cruze')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (19, 7, N'Vitara')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (20, 7, N'Swift')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (21, 8, N'Cronos')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (22, 8, N'Argo')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (23, 8, N'Uno Way')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (24, 9, N'C3')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (25, 9, N'C4')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (26, 9, N'C5')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (27, 10, N'208')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (28, 10, N'308')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (29, 10, N'408')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (30, 11, N'Sandero')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (31, 11, N'Stepway')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (32, 11, N'Logan')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (33, 11, N'Duster')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (34, 12, N'City')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (35, 12, N'Civic')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (36, 12, N'Accord')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (37, 13, N'Cerato')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (38, 13, N'Aurora')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (39, 13, N'Sportage')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (40, 14, N'Yaris')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (41, 14, N'Corolla')
GO
INSERT [dbo].[Modelo] ([Id], [IdMarca], [Nombre]) VALUES (42, 14, N'Innova')
GO
SET IDENTITY_INSERT [dbo].[Modelo] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 

GO
INSERT [dbo].[Vehiculo] ([Id], [IdModelo], [IdSucursal], [Patente], [Kilometraje], [PrecioDiarioBase], [FechaDeInicio], [NivelBlindaje], [UltimaModificacion], [Borrado]) VALUES (1, 3, 1, N'FUX466', 30000, 40000, CAST(N'2022-08-01 00:00:00.0000000' AS DateTime2), 1, CAST(N'2022-11-14 08:44:16.4200000' AS DateTime2), 0)
GO
INSERT [dbo].[Vehiculo] ([Id], [IdModelo], [IdSucursal], [Patente], [Kilometraje], [PrecioDiarioBase], [FechaDeInicio], [NivelBlindaje], [UltimaModificacion], [Borrado]) VALUES (2, 41, 2, N'MRP906', 20000, 50000, CAST(N'2022-11-14 00:00:00.0000000' AS DateTime2), 2, CAST(N'2022-11-14 08:45:40.0100000' AS DateTime2), 0)
GO
INSERT [dbo].[Vehiculo] ([Id], [IdModelo], [IdSucursal], [Patente], [Kilometraje], [PrecioDiarioBase], [FechaDeInicio], [NivelBlindaje], [UltimaModificacion], [Borrado]) VALUES (3, 18, 4, N'KZT476', 55000, 45000, CAST(N'2022-03-01 00:00:00.0000000' AS DateTime2), 2, CAST(N'2022-11-14 08:46:48.4070000' AS DateTime2), 0)
GO
INSERT [dbo].[Vehiculo] ([Id], [IdModelo], [IdSucursal], [Patente], [Kilometraje], [PrecioDiarioBase], [FechaDeInicio], [NivelBlindaje], [UltimaModificacion], [Borrado]) VALUES (4, 42, 3, N'AF992AA', 5000, 80000, CAST(N'2022-05-30 00:00:00.0000000' AS DateTime2), 3, CAST(N'2022-11-14 08:53:23.7970000' AS DateTime2), 0)
GO
INSERT [dbo].[Vehiculo] ([Id], [IdModelo], [IdSucursal], [Patente], [Kilometraje], [PrecioDiarioBase], [FechaDeInicio], [NivelBlindaje], [UltimaModificacion], [Borrado]) VALUES (5, 24, 1, N'AE658AA', 7280, 65000, CAST(N'2022-01-03 00:00:00.0000000' AS DateTime2), 1, CAST(N'2022-11-14 08:56:08.3530000' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 

GO
INSERT [dbo].[Reserva] ([Id], [IdVehiculo], [FechaDeInicio], [FechaDeFin], [UltimaModificacion]) VALUES (1, 1, CAST(N'2022-11-09 00:00:00.0000000' AS DateTime2), CAST(N'2022-11-15 23:59:59.0000000' AS DateTime2), CAST(N'2022-11-14 11:29:14.0400000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
INSERT [dbo].[Alquiler] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [IdCliente], [Retornado]) VALUES (1, 1, 2, 7, 0)
GO
INSERT [dbo].[Chofer] ([Id], [IdTelefono], [Borrado]) VALUES (4, 18, 0)
GO
INSERT [dbo].[Chofer] ([Id], [IdTelefono], [Borrado]) VALUES (5, 19, 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (1, N'Administracion')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (2, N'AdministracionUsuario')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (3, N'AdministracionSucursal')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (4, N'AdministracionBitacora')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (5, N'AdministracionChofer')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (6, N'AdministracionPermiso')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (7, N'AdministracionVehiculo')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (8, N'Ventas')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (9, N'VentasCliente')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (10, N'VentasAlquiler')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (11, N'Inspeccion')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (12, N'InspeccionRetorno')
GO
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (13, N'InspeccionReporte')
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (1, 2)
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (1, 3)
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (1, 4)
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (1, 5)
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (1, 6)
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (1, 7)
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (8, 9)
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (8, 10)
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (11, 12)
GO
INSERT [dbo].[GrupoPermiso] ([IdGrupo], [IdHijo]) VALUES (11, 13)
GO
INSERT [dbo].[UsuarioPermiso] ([IdUsuario], [IdPermiso]) VALUES (1, 1)
GO
INSERT [dbo].[UsuarioPermiso] ([IdUsuario], [IdPermiso]) VALUES (3, 8)
GO
INSERT [dbo].[UsuarioPermiso] ([IdUsuario], [IdPermiso]) VALUES (3, 11)
GO
INSERT [dbo].[UsuarioPermiso] ([IdUsuario], [IdPermiso]) VALUES (6, 8)
GO
SET IDENTITY_INSERT [dbo].[RecargoSucursal] ON 

GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (14, 1, 2, CAST(0 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (15, 1, 3, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (16, 1, 4, CAST(2500 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (17, 2, 1, CAST(0 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (18, 2, 3, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (19, 2, 4, CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (20, 3, 1, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (21, 3, 2, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (22, 3, 4, CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (23, 4, 1, CAST(2500 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (24, 4, 2, CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[RecargoSucursal] ([Id], [IdSucursalOrigen], [IdSucursalDestino], [Recargo]) VALUES (25, 4, 3, CAST(1000 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[RecargoSucursal] OFF
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (1, 1, N'Log in exitoso.', CAST(N'2022-11-14 07:53:45.9000000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (2, 1, N'Usuario creado: eliana22', CAST(N'2022-11-14 07:55:29.6830000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (3, 1, N'Sucursal creada: Av. Cabildo 350', CAST(N'2022-11-14 07:57:48.0970000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (4, 1, N'Log in exitoso.', CAST(N'2022-11-14 08:07:47.9970000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (5, 1, N'Sucursal creada: Av. Cabildo 3653', CAST(N'2022-11-14 08:10:41.8330000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (6, 1, N'Sucursal creada: Av. del Libertador 1801', CAST(N'2022-11-14 08:13:14.8130000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (7, 1, N'Sucursal modificada: Av. Cabildo 350', CAST(N'2022-11-14 08:13:48.5170000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (8, 1, N'Sucursal modificada: Av. Cabildo 3653', CAST(N'2022-11-14 08:14:10.4200000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (9, 1, N'Sucursal creada: Av. Mitre 202', CAST(N'2022-11-14 08:19:13.3670000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (10, 1, N'Sucursal modificada: Av. Mitre 202', CAST(N'2022-11-14 08:21:45.1730000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (11, 1, N'Sucursal modificada: Av. Cabildo 350', CAST(N'2022-11-14 08:22:25.1800000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (12, 1, N'Sucursal modificada: Av. Cabildo 3653', CAST(N'2022-11-14 08:23:20.5770000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (13, 1, N'Sucursal modificada: Av. del Libertador 1801', CAST(N'2022-11-14 08:23:35.3000000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (14, 1, N'Sucursal modificada: Av. Bartolomé Mitre 202', CAST(N'2022-11-14 08:26:03.1700000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (15, 1, N'Alta chofer: Pablo Minetti.', CAST(N'2022-11-14 08:33:26.1670000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (16, 1, N'Alta chofer: Mónica Taglioli.', CAST(N'2022-11-14 08:35:17.4870000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (17, 1, N'Log out.', CAST(N'2022-11-14 08:41:17.6870000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (18, 1, N'Log in exitoso.', CAST(N'2022-11-14 08:41:40.5470000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (19, 1, N'Vehiculo agregado: Volkswagen Passat FUX466', CAST(N'2022-11-14 08:44:16.4370000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (20, 1, N'Vehiculo agregado: Toyota Corolla MRP906', CAST(N'2022-11-14 08:44:54.2070000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (21, 1, N'Vehiculo modificado: Toyota Corolla MRP906', CAST(N'2022-11-14 08:45:40.0170000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (22, 1, N'Vehiculo agregado: Chevrolet Cruze KZT476', CAST(N'2022-11-14 08:46:48.4070000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (23, 1, N'Vehiculo agregado: Toyota Innova AF992AA', CAST(N'2022-11-14 08:53:23.9030000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (24, 1, N'Vehiculo agregado: Citroen C3 AE658AA', CAST(N'2022-11-14 08:56:08.3600000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (25, 1, N'Usuario creado: juandalvicia', CAST(N'2022-11-14 09:00:17.9770000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (26, 1, N'Log out.', CAST(N'2022-11-14 09:00:28.0730000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (27, 6, N'Log in exitoso.', CAST(N'2022-11-14 09:00:33.8370000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (28, 6, N'Log out.', CAST(N'2022-11-14 09:00:37.0630000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (29, 3, N'Log in exitoso.', CAST(N'2022-11-14 09:00:42.0800000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (30, 3, N'Log out.', CAST(N'2022-11-14 09:01:23.3070000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (31, 6, N'Log in exitoso.', CAST(N'2022-11-14 09:01:28.9770000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (32, 6, N'Log out.', CAST(N'2022-11-14 09:01:31.7730000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (33, 6, N'Log in exitoso.', CAST(N'2022-11-14 09:26:25.6730000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (34, 6, N'Log in exitoso.', CAST(N'2022-11-14 09:36:35.3400000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (35, 6, N'Log out.', CAST(N'2022-11-14 09:37:21.5830000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (36, 3, N'Log in exitoso.', CAST(N'2022-11-14 09:37:27.3830000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (37, 3, N'Log out.', CAST(N'2022-11-14 09:37:39.2900000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (38, 1, N'Log in exitoso.', CAST(N'2022-11-14 09:37:47.5200000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (39, 1, N'Log out.', CAST(N'2022-11-14 09:39:08.3900000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (40, 1, N'Log in exitoso.', CAST(N'2022-11-14 09:39:55.2770000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (41, 1, N'Log out.', CAST(N'2022-11-14 09:40:27.6370000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (42, 1, N'Log in exitoso.', CAST(N'2022-11-14 09:45:11.1470000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (43, 1, N'Log out.', CAST(N'2022-11-14 09:46:12.7470000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (44, 3, N'Log in exitoso.', CAST(N'2022-11-14 09:46:44.8100000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (45, 1, N'Log in exitoso.', CAST(N'2022-11-14 09:59:48.7400000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (46, 1, N'Log out.', CAST(N'2022-11-14 09:59:55.6870000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (47, 3, N'Log in exitoso.', CAST(N'2022-11-14 10:00:10.8200000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (48, 3, N'Alta cliente: Alan Perez.', CAST(N'2022-11-14 10:01:35.2600000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (49, 3, N'Alta cliente: Vanesa Canepa.', CAST(N'2022-11-14 10:26:19.4930000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (50, 3, N'Alta cliente: Pablo Alejandro Centurión.', CAST(N'2022-11-14 10:36:05.1670000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (51, 3, N'Modificación cliente: Pablo Alejandro Centurión.', CAST(N'2022-11-14 10:38:35.6370000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (52, 3, N'Alta cliente: Leandro Gauna.', CAST(N'2022-11-14 10:42:23.7700000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (53, 3, N'Modificación cliente: Pablo Alejandro Centurión.', CAST(N'2022-11-14 10:42:51.0930000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (54, 3, N'Modificación cliente: Alan Pablo Perez.', CAST(N'2022-11-14 10:48:33.9430000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (55, 1, N'Log in exitoso.', CAST(N'2022-11-14 11:04:58.7900000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (56, 1, N'Log out.', CAST(N'2022-11-14 11:04:59.9500000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (57, 6, N'Log in exitoso.', CAST(N'2022-11-14 11:05:08.5000000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (58, 2, N'Log in exitoso.', CAST(N'2022-11-14 11:27:52.2730000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (59, 2, N'Log out.', CAST(N'2022-11-14 11:27:55.3900000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (60, 6, N'Log in exitoso.', CAST(N'2022-11-14 11:28:02.4000000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (61, 6, N'Alta alquiler: Volkswagen Passat FUX466.', CAST(N'2022-11-14 11:29:14.1000000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (62, 6, N'Log out.', CAST(N'2022-11-14 11:30:13.0800000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (63, 1, N'Log in exitoso.', CAST(N'2022-11-14 11:32:34.2330000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (64, 1, N'Log out.', CAST(N'2022-11-14 11:32:43.5030000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (65, 6, N'Log in exitoso.', CAST(N'2022-11-14 11:32:49.7170000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (66, 6, N'Log out.', CAST(N'2022-11-14 11:33:10.7500000' AS DateTime2))
GO
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [Mensaje], [FechaYHora]) VALUES (67, 3, N'Log in exitoso.', CAST(N'2022-11-14 11:33:15.4070000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
