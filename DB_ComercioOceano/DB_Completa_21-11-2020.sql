USE [master]
GO
/****** Object:  Database [ComercioOceano]    Script Date: 21/11/2020 06:16:29 p. m. ******/
CREATE DATABASE [ComercioOceano]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComercioOceano', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ComercioOceano.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ComercioOceano_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ComercioOceano_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ComercioOceano] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComercioOceano].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComercioOceano] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComercioOceano] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComercioOceano] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComercioOceano] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComercioOceano] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComercioOceano] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ComercioOceano] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComercioOceano] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComercioOceano] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComercioOceano] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComercioOceano] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComercioOceano] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComercioOceano] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComercioOceano] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComercioOceano] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ComercioOceano] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComercioOceano] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComercioOceano] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComercioOceano] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComercioOceano] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComercioOceano] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComercioOceano] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComercioOceano] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ComercioOceano] SET  MULTI_USER 
GO
ALTER DATABASE [ComercioOceano] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComercioOceano] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComercioOceano] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComercioOceano] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ComercioOceano] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ComercioOceano] SET QUERY_STORE = OFF
GO
USE [ComercioOceano]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Stock] [tinyint] NOT NULL,
	[PrecioCompra] [money] NOT NULL,
	[PrecioVenta] [money] NOT NULL,
	[IdProveedor] [bigint] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[ImagenUrl] [varchar](30) NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionC] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DescripcionP] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Mail] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubVenta]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubVenta](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdVenta] [bigint] NOT NULL,
	[IdArticulo] [bigint] NOT NULL,
	[Cantidad] [bigint] NOT NULL,
	[PrecioArticulo] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[fechaNac] [date] NOT NULL,
	[Genero] [char](1) NULL,
	[Telefono] [varchar](20) NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[Contrasenia] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosAdmin]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosAdmin](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[fechaNac] [date] NOT NULL,
	[Genero] [char](1) NULL,
	[Telefono] [varchar](20) NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[Contrasenia] [varchar](100) NOT NULL,
	[NivelCargo] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaVenta] [date] NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[Total] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 

INSERT [dbo].[Articulos] ([ID], [Descripcion], [Stock], [PrecioCompra], [PrecioVenta], [IdProveedor], [FechaVencimiento], [IdCategoria], [ImagenUrl], [Estado]) VALUES (1, N'Pollo', 20, 65.0000, 70.0000, 1, CAST(N'2019-10-11' AS Date), 1, N'IMAGENES\pollo.jpg', 1)
INSERT [dbo].[Articulos] ([ID], [Descripcion], [Stock], [PrecioCompra], [PrecioVenta], [IdProveedor], [FechaVencimiento], [IdCategoria], [ImagenUrl], [Estado]) VALUES (2, N'Huevos', 50, 3.5000, 5.0000, 2, CAST(N'2019-10-11' AS Date), 2, N'IMAGENES\huevos.jpg', 1)
INSERT [dbo].[Articulos] ([ID], [Descripcion], [Stock], [PrecioCompra], [PrecioVenta], [IdProveedor], [FechaVencimiento], [IdCategoria], [ImagenUrl], [Estado]) VALUES (3, N'Asado', 50, 120.0000, 170.0000, 2, CAST(N'2019-10-11' AS Date), 1, N'IMAGENES\asado.jpg', 1)
INSERT [dbo].[Articulos] ([ID], [Descripcion], [Stock], [PrecioCompra], [PrecioVenta], [IdProveedor], [FechaVencimiento], [IdCategoria], [ImagenUrl], [Estado]) VALUES (4, N'Paty', 30, 7.0000, 10.0000, 1, CAST(N'2019-10-11' AS Date), 2, N'IMAGENES\paty.jpg', 0)
SET IDENTITY_INSERT [dbo].[Articulos] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([ID], [DescripcionC], [Estado]) VALUES (1, N'Kilo', 1)
INSERT [dbo].[Categorias] ([ID], [DescripcionC], [Estado]) VALUES (2, N'Unidad', 1)
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([Id], [DescripcionP], [Direccion], [Telefono], [Mail], [Estado]) VALUES (1, N'Granja Sol', N'Corralito 123', N'6598321', N'granjasol@gmail.com', 1)
INSERT [dbo].[Proveedores] ([Id], [DescripcionP], [Direccion], [Telefono], [Mail], [Estado]) VALUES (2, N'La Mejor', N'Pachaco 325', N'6698731', N'lamejor@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([ID], [Nombres], [Apellidos], [fechaNac], [Genero], [Telefono], [Direccion], [Mail], [NombreUsuario], [Contrasenia], [Estado]) VALUES (1, N'Alex', N'Brandan', CAST(N'1998-05-12' AS Date), N'M', N'123124', N'direccion 123', N'mail@mail.com', N'alex01', N'1234', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuariosAdmin] ON 

INSERT [dbo].[UsuariosAdmin] ([ID], [Nombres], [Apellidos], [fechaNac], [Genero], [Telefono], [Direccion], [Mail], [NombreUsuario], [Contrasenia], [NivelCargo], [Estado]) VALUES (1, N'Enzo', N'Perez', CAST(N'1995-02-06' AS Date), N'M', N'6548913', N'Calle 123', N'mail@asd', N'admin', N'1234', N'Dueño', 1)
SET IDENTITY_INSERT [dbo].[UsuariosAdmin] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuarios__E5833D3A29C11579]    Script Date: 21/11/2020 06:16:29 p. m. ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[ID] ASC,
	[NombreUsuario] ASC,
	[Mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuarios__E5833D3AC692BF13]    Script Date: 21/11/2020 06:16:29 p. m. ******/
ALTER TABLE [dbo].[UsuariosAdmin] ADD UNIQUE NONCLUSTERED 
(
	[ID] ASC,
	[NombreUsuario] ASC,
	[Mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([ID])
GO
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([Id])
GO
ALTER TABLE [dbo].[SubVenta]  WITH CHECK ADD FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[Articulos] ([ID])
GO
ALTER TABLE [dbo].[SubVenta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([ID])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarArticulo]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ActualizarArticulo]
(
@Id bigint,
@Descripcion VARCHAR(100),
@Stock tinyint,
@PrecioCompra money,
@PrecioVenta money,
@IdProveedor bigint,
@FechaVencimiento date,
@IdCategoria int,
@ImagenUrl varchar(30),
@Estado bit
)
AS
UPDATE Articulos
SET
Descripcion=@Descripcion,
Stock=@Stock,
PrecioCompra=@PrecioCompra,
PrecioVenta=@PrecioVenta,
IdProveedor=@IdProveedor,
FechaVencimiento=@FechaVencimiento,
IdCategoria=@IdCategoria,
ImagenUrl=@ImagenUrl,
Estado=@Estado
WHERE ID=@Id
RETURN

GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarCategoria]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ActualizarCategoria]
(
@ID int,
@Descripcion VARCHAR(100),
@Estado bit
)
AS
UPDATE Categorias
SET
DescripcionC=@Descripcion,
Estado=@Estado
WHERE ID=@ID
RETURN

GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarProveedor]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ActualizarProveedor]
(
@Id bigint,
@Descripcion VARCHAR(100),
@Direccion varchar(100),
@Telefono varchar(100),
@Mail varchar(100),
@Estado bit
)
AS
UPDATE Proveedores
SET
DescripcionP=@Descripcion,
Direccion=@Direccion,
Telefono=@Telefono,
Mail=@Mail,
Estado=@Estado
WHERE Id=@Id
RETURN

GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarUsuario]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ActualizarUsuario]
(
@ID bigint,
@Nombres VARCHAR(50),
@Apellidos varchar(50),
@FechaNacimiento date,
@Genero char(1),
@Telefono varchar(20),
@Direccion varchar(50),
@Mail varchar(50),
@NombreUsuario varchar(100),
@Contraseña varchar(100)
)
AS
UPDATE Usuarios
SET
Nombres=@Nombres,
Apellidos=@Apellidos,
fechaNac=@FechaNacimiento,
Genero=@Genero,
Telefono=@Telefono,
Direccion=@Direccion,
Mail=@Mail,
NombreUsuario=@NombreUsuario,
Contrasenia=@Contraseña
WHERE ID=@ID
RETURN

GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarArticulo]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AgregarArticulo]
(
@Descripcion VARCHAR(100),
@Stock tinyint,
@PrecioCompra money,
@PrecioVenta money,
@IdProveedor bigint,
@FechaVencimiento date,
@IdCategoria int,
@ImagenUrl varchar(30),
@Estado bit
)
AS

DECLARE @Art INT
SET @Art = (SELECT ID FROM Articulos WHERE Descripcion = @Descripcion)

IF @Art is null BEGIN
INSERT INTO Articulos
(
Descripcion,
Stock,
PrecioCompra,
PrecioVenta,
IdProveedor,
FechaVencimiento,
IdCategoria,
ImagenUrl,
Estado
)
VALUES
(
@Descripcion,
@Stock,
@PrecioCompra,
@PrecioVenta,
@IdProveedor,
@FechaVencimiento,
@IdCategoria,
@ImagenUrl,
@Estado
)
SELECT 'OK' msj
END
ELSE BEGIN
SELECT 'Atencion! Ya existe un Articulo con ese nombre.' msj
END

GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarCategoria]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AgregarCategoria](
@Descripcion varchar(50),
@Estado bit
)
AS
INSERT INTO Categorias(DescripcionC, Estado) VALUES (@Descripcion, @Estado)
GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarProveedor]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AgregarProveedor]
(
@Descripcion VARCHAR(100),
@Direccion varchar(100),
@Telefono varchar(100),
@Mail varchar(100),
@Estado bit
)
AS
INSERT INTO Proveedores
(
DescripcionP,
Direccion,
Telefono,
Mail,
Estado
)
VALUES
(
@Descripcion,
@Direccion,
@Telefono,
@Mail,
@Estado
)RETURN

GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarSubVenta]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AgregarSubVenta](
@IdVenta bigint,
@IdArt bigint,
@Cant bigint,
@PrecioArt money
)AS
BEGIN
IF (SELECT Stock from Articulos WHERE ID = @IdArt) > @Cant
	BEGIN
		INSERT INTO SubVenta(IdVenta, IdArticulo, Cantidad, PrecioArticulo) VALUES(@IdVenta, @IdArt, @Cant, @PrecioArt)
		UPDATE Articulos SET Stock = Stock - @Cant WHERE ID = @IdArt
	END
ELSE
	BEGIN
	RAISERROR('STOCK INSUFICIENTE',16,1)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AgregaVenta]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AgregaVenta](
@IdUsuario bigint,
@Total money
)AS
BEGIN
INSERT INTO Venta(FechaVenta, IdUsuario, Total) VALUES(GETDATE(),@IdUsuario, @Total)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_BajaLogicaArticulo]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BajaLogicaArticulo]
(
@Id bigint
)
AS
UPDATE Articulos
SET
Estado=0
WHERE ID=@Id
RETURN

GO
/****** Object:  StoredProcedure [dbo].[SP_BajaLogicaCategoria]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BajaLogicaCategoria]
(
@ID int
)
AS
UPDATE Categorias
SET
Estado=0
WHERE ID=@ID
RETURN

GO
/****** Object:  StoredProcedure [dbo].[SP_BajaLogicaProveedor]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BajaLogicaProveedor]
(
@Id bigint
)
AS
UPDATE Proveedores
SET
Estado=0
WHERE Id=@Id
RETURN

GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarAdmin]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BuscarAdmin](
@NombreUsuario varchar(100),
@Contrasenia varchar(100)
)
AS
BEGIN
	SELECT NombreUsuario, Contrasenia from UsuariosAdmin where
	@NombreUsuario = NombreUsuario and @Contrasenia = Contrasenia and Estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarUsuario]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BuscarUsuario](
@NombreUsuario varchar(100),
@Contrasenia varchar(100)
)
AS
BEGIN
	SELECT * from Usuarios where
	@NombreUsuario = NombreUsuario and @Contrasenia = Contrasenia and Estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarVentas]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BuscarVentas]
AS
BEGIN
	SELECT V.FechaVenta, V.Total,SV.IdArticulo, SV.PrecioArticulo, SV.Cantidad FROM Venta AS V INNER JOIN
	SubVenta AS SV ON V.ID = SV.IdVenta
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ExisteUsuario]    Script Date: 21/11/2020 06:16:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ExisteUsuario](
@NombreUsuario varchar(100),
@Mail varchar(100)
)
AS
BEGIN
	SELECT NombreUsuario, Mail from Usuarios where @NombreUsuario = NombreUsuario or @Mail = Mail and Estado = 1
END
GO
USE [master]
GO
ALTER DATABASE [ComercioOceano] SET  READ_WRITE 
GO
