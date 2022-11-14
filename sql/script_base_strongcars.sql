CREATE DATABASE [StrongCars];
GO

USE [StrongCars]
GO
/****** Object:  Table [dbo].[Alquiler]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquiler](
	[Id] [int] NOT NULL,
	[IdSucursalOrigen] [int] NOT NULL,
	[IdSucursalDestino] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Retornado] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlquilerConChofer]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlquilerConChofer](
	[Id] [int] NOT NULL,
	[IdChofer] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Mensaje] [varchar](500) NOT NULL,
	[FechaYHora] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Chofer]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chofer](
	[Id] [int] NOT NULL,
	[IdTelefono] [int] NOT NULL,
	[Borrado] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] NOT NULL,
	[IdTelefono] [int] NOT NULL,
	[IdEmpresa] [int] NULL,
	[Licencia] [varchar](20) NULL,
	[Borrado] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Direccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Calle] [varchar](50) NOT NULL,
	[Altura] [int] NOT NULL,
	[Unidad] [varchar](10) NULL,
	[CodigoPostal] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GrupoPermiso]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoPermiso](
	[IdGrupo] [int] NOT NULL,
	[IdHijo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC,
	[IdHijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Marca]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modelo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDireccion] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[DNI] [varchar](12) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[UltimaModificacion] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecargoSucursal]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecargoSucursal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSucursalOrigen] [int] NOT NULL,
	[IdSucursalDestino] [int] NOT NULL,
	[Recargo] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reporte]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reporte](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdVehiculo] [int] NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdVehiculo] [int] NOT NULL,
	[FechaDeInicio] [datetime2](7) NOT NULL,
	[FechaDeFin] [datetime2](7) NOT NULL,
	[CostoVehiculo] [decimal](18, 0) NOT NULL,
	[CostoChofer] [decimal](18, 0) NOT NULL,
	[RecargoSucursal] [decimal](18, 0) NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[UltimaModificacion] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDireccion] [int] NOT NULL,
	[IdGerente] [int] NOT NULL,
	[Borrado] [bit] NOT NULL DEFAULT ((0)),
	[UltimaModificacion] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Telefono](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSucursal] [int] NULL,
	[Caracteristica] [varchar](10) NOT NULL,
	[Numero] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] NOT NULL,
	[NombreDeUsuario] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CantidadIntentosLogIn] [int] NOT NULL DEFAULT ((0)),
	[Bloqueado] [bit] NOT NULL DEFAULT ((0)),
	[Borrado] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioPermiso]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPermiso](
	[IdUsuario] [int] NOT NULL,
	[IdPermiso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 30/10/2022 10:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdModelo] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[Patente] [varchar](10) NOT NULL,
	[Kilometraje] [int] NOT NULL,
	[PrecioDiarioBase] [int] NOT NULL,
	[FechaDeInicio] [datetime2](7) NOT NULL,
	[NivelBlindaje] [int] NOT NULL,
	[UltimaModificacion] [datetime2](7) NOT NULL,
	[Borrado] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[Reserva] ([Id])
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD FOREIGN KEY([IdSucursalOrigen])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD FOREIGN KEY([IdSucursalDestino])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[AlquilerConChofer]  WITH CHECK ADD FOREIGN KEY([IdChofer])
REFERENCES [dbo].[Chofer] ([Id])
GO
ALTER TABLE [dbo].[AlquilerConChofer]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[Alquiler] ([Id])
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Chofer]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Chofer]  WITH CHECK ADD FOREIGN KEY([IdTelefono])
REFERENCES [dbo].[Telefono] ([Id])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([IdTelefono])
REFERENCES [dbo].[Telefono] ([Id])
GO
ALTER TABLE [dbo].[GrupoPermiso]  WITH CHECK ADD FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Permiso] ([Id])
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marca] ([Id])
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[Direccion] ([Id])
GO
ALTER TABLE [dbo].[RecargoSucursal]  WITH CHECK ADD FOREIGN KEY([IdSucursalOrigen])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[RecargoSucursal]  WITH CHECK ADD FOREIGN KEY([IdSucursalDestino])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[Reporte]  WITH CHECK ADD FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculo] ([Id])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculo] ([Id])
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[Direccion] ([Id])
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD FOREIGN KEY([IdGerente])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permiso] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD FOREIGN KEY([IdModelo])
REFERENCES [dbo].[Modelo] ([Id])
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([Id])
GO