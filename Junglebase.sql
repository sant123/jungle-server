USE [master]
GO
/****** Object:  Database [JungleBase]    Script Date: 26/09/2022 9:49:16 p. m. ******/
CREATE DATABASE [JungleBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Jungle_Barber', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Jungle_Barber.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Jungle_Barber_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Jungle_Barber_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [JungleBase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JungleBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JungleBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JungleBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JungleBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JungleBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JungleBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [JungleBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JungleBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JungleBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JungleBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JungleBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JungleBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JungleBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JungleBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JungleBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JungleBase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [JungleBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JungleBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JungleBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JungleBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JungleBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JungleBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JungleBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JungleBase] SET RECOVERY FULL 
GO
ALTER DATABASE [JungleBase] SET  MULTI_USER 
GO
ALTER DATABASE [JungleBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JungleBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JungleBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JungleBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JungleBase] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'JungleBase', N'ON'
GO
ALTER DATABASE [JungleBase] SET QUERY_STORE = OFF
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
USE [master]
GO
ALTER DATABASE [JungleBase] SET  READ_WRITE 
GO
