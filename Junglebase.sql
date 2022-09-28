IF NOT EXISTS (
	SELECT *
	FROM sys.databases
	WHERE name = 'JungleBase'
)
BEGIN
    CREATE DATABASE [JungleBase]
END
GO
USE [JungleBase]
GO
/****** Object:  Table [dbo].[Cita]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cita](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoraInicio] [time](7) NOT NULL,
	[HoraFIn] [time](7) NULL,
	[Fecha] [date] NOT NULL,
	[Sede] [varchar](50) NULL,
	[IdUsuarioAgenda] [int] NULL,
	[IdUsuarioAtiende] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK__citas__5E31E370D60AAB1A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCita]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCita](
	[id] [int] NOT NULL,
	[IdServicios] [int] NULL,
	[IdProductos] [int] NULL,
	[IdCita] [int] NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_DetalleCita] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimientoInventario]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientoInventario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdProductos] [int] NOT NULL,
	[IdInventario] [int] NOT NULL,
	[IdTipoMovimientoInventario] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_MovimientoInventario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Telefono] [varchar](18) NULL,
	[IdTipoDocumento] [int] NULL,
	[Correo] [varchar](80) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[NumeroDocumento] [varchar](50) NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Valor_unitario] [varchar](30) NOT NULL,
	[Referecia_marca] [varchar](30) NOT NULL,
	[IdTipoProducto] [int] NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK__Producto__1D8EFF0128F0CAB0] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NULL,
	[Valor] [decimal](18, 0) NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK__Servicio__5B1345F0184124E4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NULL,
	[Descripcion] [varbinary](100) NULL,
 CONSTRAINT [PK_Tip_de_documento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMovimientoInventario]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovimientoInventario](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Salida] [varchar](50) NULL,
 CONSTRAINT [PK_TipoMovimientoInventario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](20) NULL,
	[Contraseña] [varchar](30) NULL,
	[IdPersona] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioXRol]    Script Date: 26/09/2022 9:49:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioXRol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioXRol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Estado] ON 

INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Agendado', N'')
INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (2, N'En Curso', N'')
INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Terminado', N'')
INSERT [dbo].[Estado] ([Id], [Nombre], [Descripcion]) VALUES (4, N'Cancelado', N'')
SET IDENTITY_INSERT [dbo].[Estado] OFF
SET IDENTITY_INSERT [dbo].[Inventario] ON 

INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (1, N'Tinte Barba', CAST(N'2022-08-29T15:18:23.890' AS DateTime))
INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (2, N'tintes cabello', CAST(N'2022-08-23T01:18:23.290' AS DateTime))
INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (1002, N'crema cara', CAST(N'2022-08-22T20:59:16.370' AS DateTime))
INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (1003, N'ceras', CAST(N'2022-08-02T13:52:26.733' AS DateTime))
INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (1004, N'crema para pies', CAST(N'2022-08-22T20:59:27.257' AS DateTime))
INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (1005, N'tonico barba super macho', CAST(N'2022-08-22T20:59:41.710' AS DateTime))
INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (1006, N'superceras', CAST(N'2022-08-03T17:17:53.873' AS DateTime))
INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (1007, N'tonicos', CAST(N'2022-08-03T18:14:05.590' AS DateTime))
INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (1008, N'Geles', CAST(N'2022-08-22T21:06:10.370' AS DateTime))
INSERT [dbo].[Inventario] ([Id], [Nombre], [FechaCreacion]) VALUES (1009, N'ceras', CAST(N'2022-08-23T19:20:05.033' AS DateTime))
SET IDENTITY_INSERT [dbo].[Inventario] OFF
SET IDENTITY_INSERT [dbo].[MovimientoInventario] ON 

INSERT [dbo].[MovimientoInventario] ([Id], [Cantidad], [IdProductos], [IdInventario], [IdTipoMovimientoInventario], [FechaCreacion]) VALUES (2, 5, 1, 1005, 1, CAST(N'2022-08-16T07:43:21.610' AS DateTime))
INSERT [dbo].[MovimientoInventario] ([Id], [Cantidad], [IdProductos], [IdInventario], [IdTipoMovimientoInventario], [FechaCreacion]) VALUES (3, 3, 9, 1005, 1, CAST(N'2022-08-16T07:43:33.950' AS DateTime))
INSERT [dbo].[MovimientoInventario] ([Id], [Cantidad], [IdProductos], [IdInventario], [IdTipoMovimientoInventario], [FechaCreacion]) VALUES (4, 5, 8, 1, 1, CAST(N'2022-08-17T16:03:35.863' AS DateTime))
INSERT [dbo].[MovimientoInventario] ([Id], [Cantidad], [IdProductos], [IdInventario], [IdTipoMovimientoInventario], [FechaCreacion]) VALUES (5, 2, 1, 1, 2, CAST(N'2022-08-17T16:04:50.023' AS DateTime))
INSERT [dbo].[MovimientoInventario] ([Id], [Cantidad], [IdProductos], [IdInventario], [IdTipoMovimientoInventario], [FechaCreacion]) VALUES (6, 5, 8, 1, 1, CAST(N'2022-08-20T13:03:48.867' AS DateTime))
INSERT [dbo].[MovimientoInventario] ([Id], [Cantidad], [IdProductos], [IdInventario], [IdTipoMovimientoInventario], [FechaCreacion]) VALUES (1002, 15, 8, 1, 1, CAST(N'2022-08-22T23:48:54.103' AS DateTime))
INSERT [dbo].[MovimientoInventario] ([Id], [Cantidad], [IdProductos], [IdInventario], [IdTipoMovimientoInventario], [FechaCreacion]) VALUES (2002, 4, 1, 1, 1, CAST(N'2022-08-29T22:21:22.873' AS DateTime))
INSERT [dbo].[MovimientoInventario] ([Id], [Cantidad], [IdProductos], [IdInventario], [IdTipoMovimientoInventario], [FechaCreacion]) VALUES (2003, 4, 9, 1, 1, CAST(N'2022-08-29T22:21:40.330' AS DateTime))
INSERT [dbo].[MovimientoInventario] ([Id], [Cantidad], [IdProductos], [IdInventario], [IdTipoMovimientoInventario], [FechaCreacion]) VALUES (3002, 4, 8, 1, 1, CAST(N'2022-09-05T23:08:46.103' AS DateTime))
SET IDENTITY_INSERT [dbo].[MovimientoInventario] OFF
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (1, N'Juan', N'Perez  suarez', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-09-05' AS Date), N'1569874556')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2, N'Geidy', N'Fernandez', N'Tv 43 usr # 22 a 22', N'3044396554', 1, N'jairgrneine@gmail.com', CAST(N'2022-09-05' AS Date), N'52130589')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3, N'Pedro luis', N'Bustos Bustos', N'cra 45 # 52 89', N'3125897485', 1, N'peluis@homtail.com', CAST(N'2022-09-05' AS Date), N'15454545')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (28, N'tayron', N'torres', N'diagonal', N'43328238', 1, N'ednfuidgfiudsgf@gmail.com', CAST(N'2022-09-06' AS Date), N'123456')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (29, N'luis', N'cardona', N'dg 45 sur ', N'32154898', 2, N'vrejbvbvkjsf', CAST(N'2022-08-23' AS Date), N'256464')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (32, N'jair', N'lopez', N'dg34', N'4654313', 1, N'jairfernande@gmail.com', CAST(N'1991-12-30' AS Date), N'1031256')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (33, N'juan', N'vanegas', N'dg 562 ', N'26434136', 2, N'juanvargas', CAST(N'2018-01-01' AS Date), N'10311256')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (1019, N'raul', N'pedraza', N'dg 34 23 sur', N'312548956', 1, N'raulp@gmail.com', CAST(N'1997-05-12' AS Date), N'312589625')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (1020, N'pedro', N'pedro', N'dg 34 sur', N'315526', 1, N'pedro@gmail.com', CAST(N'1989-05-12' AS Date), N'4546878')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (1021, N'bombillo', N'bombillo', N'bombillo123', N'1242345', 2, N'bombillo@gmail.com', CAST(N'2005-09-30' AS Date), N'123214432')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (1022, N'123', NULL, N'123', NULL, 1, N'123', CAST(N'2022-08-10' AS Date), N'123')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (1023, N'cosa', N'cosa', N'cosa', N'12868', 1, N'cosa@gmail.com', CAST(N'1991-12-12' AS Date), N'123')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2023, N'laura', N'tobon', N'dg 87 sur 45', N'3157895645', 1, N'luau@gmail.com', CAST(N'1996-02-12' AS Date), N'10313958')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2024, N'vob eboi', N'wlknvfjbvw', N'fwnbifebjkv', N'43464', 2, N'dlnvjwenjn@fkrnvk', CAST(N'1898-05-14' AS Date), N'54654654')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2025, N'Juan', N'Perez', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-08-23' AS Date), N'1019103981')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2026, N'Juan carlos', N'Perez', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-08-23' AS Date), N'1019103981')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2027, N'Juan carlos', N'Perez saenz', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-08-23' AS Date), N'1019103981')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2028, N'Juan diego', N'Perez', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-08-23' AS Date), N'1019103981')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2029, N'Juan', N'Perez perez perez', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-08-23' AS Date), N'1019103981')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2030, N'Juan', N'Perez obando', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-08-23' AS Date), N'1019103981')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2031, N'ovied', N'Perez', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-08-23' AS Date), N'1019103981')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2032, N'Juan psa', N'Perez', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-08-23' AS Date), N'1019103981')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (2033, N'Juan', N'Perez', N'Dg 43 s # 24-56', N'3214568574', 1, N'juanp@gmail.com', CAST(N'2022-08-23' AS Date), N'1019103981')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3023, N'dcsdhvds', N'lvbsdlbvoisd', N'dfubfoiegoe', N'43543543', 1, N'jairnfi@gmail.com', CAST(N'1991-12-02' AS Date), N'4356468436')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3024, N'jair ', N'fernandez', N'dg 47 a sur # 23', N'3044965825', 1, N'jairfernandez@gmail.com', CAST(N'1991-12-30' AS Date), N'1023135598')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3025, N'jair ', N'fernandez', N'dg 47 a sur # 23', N'3044965825', 1, N'jairfernandez@gmail.com', CAST(N'1991-12-30' AS Date), N'1023135598')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3026, N'jair ', N'fernandez', N'dg 47 a sur # 23', N'3044965825', 1, N'jairfernandez@gmail.com', CAST(N'1991-12-30' AS Date), N'1023135598')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3027, N'jair ', N'fernandez', N'dg 47 a sur # 23', N'3044965825', 1, N'jairfernandez@gmail.com', CAST(N'1991-12-30' AS Date), N'1023135598')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3028, N'jair ', N'fernandez', N'dg 47 a sur # 23', N'3044965825', 1, N'jairfernandez@gmail.com', CAST(N'1991-12-30' AS Date), N'1023135598')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3029, N'jair ', N'fernandez', N'dg 47 a sur # 23', N'3044965825', 1, N'jairfernandez@gmail.com', CAST(N'1991-12-30' AS Date), N'1023135598')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3030, N'jair', N'fernandezx', N'dg 47 sur # 23 24', N'315645314', 1, N'jairfernandex@gmail.com', CAST(N'1991-12-30' AS Date), N'1031225456')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3031, N'jair', N'fernandezx', N'dg 47 sur # 23 24', N'315645314', 1, N'jairfernandex@gmail.com', CAST(N'1991-12-30' AS Date), N'1031225456')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3032, N'jair', N'fernandezx', N'dg 47 sur # 23 24', N'315645314', 1, N'jairfernandex@gmail.com', CAST(N'1991-12-30' AS Date), N'1031225456')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3033, N'jair', N'lopz', N'dfh 43 sur ', N'241534534', 1, N'dihidhfsdio@gmail.com', CAST(N'1991-03-12' AS Date), N'1235555')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3034, N'jair ', N'fernandez', N'dg 47 asyur', N'231234564', 1, N'jairfenande@gmal.com', CAST(N'1991-03-12' AS Date), N'1031395987')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3035, N'juannnnnn', N'nnnnnnnn', N'sdihvduygviuwg', N'67643578', 1, N'spdojhcdyicu@gmai.com', CAST(N'1989-03-12' AS Date), N'3573438738438')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3036, N'sebas', N'torres', N'dg 53 # 25 23', N'312589855', 1, N'sebas@gmail.com', CAST(N'1991-03-20' AS Date), N'310256598')
INSERT [dbo].[Persona] ([Id], [Nombre], [Apellido], [Direccion], [Telefono], [IdTipoDocumento], [Correo], [FechaNacimiento], [NumeroDocumento]) VALUES (3037, N'jairo', N'roldan', N'dg 23 45 22º', N'3125598746', 1, N'jairo@gmail.com', CAST(N'1989-02-12' AS Date), N'3225325')
SET IDENTITY_INSERT [dbo].[Persona] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (1, N'ceras', N'2000000', N'BarberShop', 2, NULL)
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (8, N'Ceras', N'15.000', N'BarberShop', 5, NULL)
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (9, N'Tayron producto', N'2500000', N'Tayron Barberia', 3, NULL)
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (10, N'jampierrr produto', N'300000', N'tonicos', 2, NULL)
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (11, N'pestanilla', N'2000', N'SUPER HOMBRES', 1, NULL)
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (12, N'Gel', N'20000', N'rolda', 2, NULL)
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (1029, N'cera', N'20.500', N'barber SHop', 3, CAST(N'2022-07-27T16:23:51.410' AS DateTime))
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (1030, N'cual', N'2000', N'rolda', 1, CAST(N'2022-07-27T16:47:39.643' AS DateTime))
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (1031, N'ceras', N'15.000', N'barber shop', 3, CAST(N'2022-07-27T20:53:00.150' AS DateTime))
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (1032, N'ceras', N'20000', N'rolda', 3, CAST(N'2022-07-29T09:21:59.520' AS DateTime))
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (2009, N'shampoo', N'30.000', N'barber', 2, CAST(N'2022-08-02T00:33:36.070' AS DateTime))
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (2010, N'kkkkkkkkk', N'222222', N'lllllll', 1, CAST(N'2022-08-02T00:36:45.377' AS DateTime))
INSERT [dbo].[Productos] ([Id], [Nombre], [Valor_unitario], [Referecia_marca], [IdTipoProducto], [FechaCreacion]) VALUES (2012, N'dfneiub', N'121512', N'fknvkds kj', 1, CAST(N'2022-08-04T18:56:46.277' AS DateTime))
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Administrador', N'Control')
INSERT [dbo].[Roles] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Barbero', N'Barbero')
INSERT [dbo].[Roles] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Cliente', NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Servicios] ON 

INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (1, N'Corte barba ', CAST(40000 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (2, N'cejas mujer', CAST(2000 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (3, N'tinte', CAST(50000 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (4, N'cortes', CAST(25000 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (5, N'barbas', CAST(20000 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (6, N'figura', CAST(250000 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (7, N'cejas', CAST(20000 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (8, N'cejas', CAST(12000 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (9, N'corte basico', CAST(12000 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (10, N'sdqfegtrynjrnhtrewº', CAST(8754489654 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (11, N'dwafegr', CAST(12555 AS Decimal(18, 0)), CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (12, N'cejas', CAST(15000 AS Decimal(18, 0)), CAST(N'2022-07-29T09:23:11.490' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (1009, N'corte', CAST(20000 AS Decimal(18, 0)), CAST(N'2022-08-02T00:32:55.200' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (1010, NULL, NULL, CAST(N'2022-08-04T18:55:42.783' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (1011, NULL, CAST(1222 AS Decimal(18, 0)), CAST(N'2022-08-04T18:58:34.633' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (1012, N'cejas', CAST(15000 AS Decimal(18, 0)), CAST(N'2022-08-09T16:02:26.497' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (1013, N'cevw', CAST(451468 AS Decimal(18, 0)), CAST(N'2022-08-15T17:56:18.947' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (1014, N'cvdin', CAST(555 AS Decimal(18, 0)), CAST(N'2022-08-17T21:50:24.320' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (2013, N'corte', CAST(30000 AS Decimal(18, 0)), CAST(N'2022-08-23T00:53:07.007' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (3013, N'barbas', CAST(200000 AS Decimal(18, 0)), CAST(N'2022-08-29T00:10:03.490' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (3014, NULL, NULL, CAST(N'2022-08-29T07:41:58.063' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (3015, NULL, NULL, CAST(N'2022-08-29T08:01:52.907' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (3016, N'combo', CAST(2000 AS Decimal(18, 0)), CAST(N'2022-08-29T08:49:12.603' AS DateTime))
INSERT [dbo].[Servicios] ([Id], [Nombre], [Valor], [FechaCreacion]) VALUES (3017, N'cejas', CAST(20 AS Decimal(18, 0)), CAST(N'2022-08-29T09:21:34.453' AS DateTime))
SET IDENTITY_INSERT [dbo].[Servicios] OFF
SET IDENTITY_INSERT [dbo].[TipoDocumento] ON 

INSERT [dbo].[TipoDocumento] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Cedula', NULL)
INSERT [dbo].[TipoDocumento] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Tarjeta de identidad', NULL)
INSERT [dbo].[TipoDocumento] ([Id], [Nombre], [Descripcion]) VALUES (3, N'CedulaExtranjeria', NULL)
INSERT [dbo].[TipoDocumento] ([Id], [Nombre], [Descripcion]) VALUES (4, N'N/A', NULL)
SET IDENTITY_INSERT [dbo].[TipoDocumento] OFF
INSERT [dbo].[TipoMovimientoInventario] ([Id], [Nombre], [Salida]) VALUES (1, N'Entrada', N'1')
INSERT [dbo].[TipoMovimientoInventario] ([Id], [Nombre], [Salida]) VALUES (2, N'Salida', N'2')
INSERT [dbo].[TipoProducto] ([Id], [Nombre]) VALUES (1, N'pepepepe')
INSERT [dbo].[TipoProducto] ([Id], [Nombre]) VALUES (2, N'geles')
INSERT [dbo].[TipoProducto] ([Id], [Nombre]) VALUES (3, N'ceras')
INSERT [dbo].[TipoProducto] ([Id], [Nombre]) VALUES (5, N'tintes')
INSERT [dbo].[TipoProducto] ([Id], [Nombre]) VALUES (6, N'mascarillas')
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (1, N'Administrador', N'Administrador', 1)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (2, N'Barbero', N'Barbero', 2)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (3, N'Cliente', N'1234', 3)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (9, N'123456', N'123456', 28)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (10, N'1031256', N'1031256', 32)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (11, N'10311256', N'10311256', 33)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (1004, N'312589625', N'312589625', 1019)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (1005, N'4546878', N'4546878', 1020)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (1006, N'123214432', N'123214432', 1021)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (1007, N'123', N'123', 1022)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (2008, N'10313958', N'10313958', 2023)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (2009, N'54654654', N'54654654', 2024)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (2010, N'1019103981', N'1019103981', 2031)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (3008, N'jairnfi@gmail.com', N'4356468436', 3023)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (3019, N'jairfenande@gmal.com', N'1031395987', 3034)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (3021, N'sebas@gmail.com', N'310256598', 3036)
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña], [IdPersona]) VALUES (3022, N'jairo@gmail.com', N'3225325', 3037)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
SET IDENTITY_INSERT [dbo].[UsuarioXRol] ON 

INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (1, 2, 2)
INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (2, 3, 3)
INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (3, 3, 3)
INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (4, 1, 1)
INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (5, 1, 1)
INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (11, 3, 2)
INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (12, 1, 3008)
INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (13, 1, 3019)
INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (14, 3, 3021)
INSERT [dbo].[UsuarioXRol] ([Id], [IdRol], [IdUsuario]) VALUES (15, 3, 3022)
SET IDENTITY_INSERT [dbo].[UsuarioXRol] OFF
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD  CONSTRAINT [FK_Cita_Usuarios] FOREIGN KEY([IdUsuarioAgenda])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Cita] CHECK CONSTRAINT [FK_Cita_Usuarios]
GO
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD  CONSTRAINT [FK_Cita_Usuarios1] FOREIGN KEY([IdUsuarioAtiende])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Cita] CHECK CONSTRAINT [FK_Cita_Usuarios1]
GO
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD  CONSTRAINT [FK_citas_Estados] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[Cita] CHECK CONSTRAINT [FK_citas_Estados]
GO
ALTER TABLE [dbo].[DetalleCita]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCita_Productos] FOREIGN KEY([IdProductos])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[DetalleCita] CHECK CONSTRAINT [FK_DetalleCita_Productos]
GO
ALTER TABLE [dbo].[DetalleCita]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCita_Servicios] FOREIGN KEY([IdServicios])
REFERENCES [dbo].[Servicios] ([Id])
GO
ALTER TABLE [dbo].[DetalleCita] CHECK CONSTRAINT [FK_DetalleCita_Servicios]
GO
ALTER TABLE [dbo].[MovimientoInventario]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoInventario_Inventario] FOREIGN KEY([IdInventario])
REFERENCES [dbo].[Inventario] ([Id])
GO
ALTER TABLE [dbo].[MovimientoInventario] CHECK CONSTRAINT [FK_MovimientoInventario_Inventario]
GO
ALTER TABLE [dbo].[MovimientoInventario]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoInventario_Productos] FOREIGN KEY([IdProductos])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[MovimientoInventario] CHECK CONSTRAINT [FK_MovimientoInventario_Productos]
GO
ALTER TABLE [dbo].[MovimientoInventario]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoInventario_TipoMovimientoInventario] FOREIGN KEY([IdTipoMovimientoInventario])
REFERENCES [dbo].[TipoMovimientoInventario] ([Id])
GO
ALTER TABLE [dbo].[MovimientoInventario] CHECK CONSTRAINT [FK_MovimientoInventario_TipoMovimientoInventario]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Tip_de_documento] FOREIGN KEY([IdTipoDocumento])
REFERENCES [dbo].[TipoDocumento] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Personas_Tip_de_documento]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_TipoProducto] FOREIGN KEY([IdTipoProducto])
REFERENCES [dbo].[TipoProducto] ([Id])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_TipoProducto]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Persona]
GO
ALTER TABLE [dbo].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_por_Rol_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UsuarioXRol] CHECK CONSTRAINT [FK_Usuario_por_Rol_Roles]
GO
ALTER TABLE [dbo].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_por_Rol_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[UsuarioXRol] CHECK CONSTRAINT [FK_Usuario_por_Rol_Usuarios]
GO
