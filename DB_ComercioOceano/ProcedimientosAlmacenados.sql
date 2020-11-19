USE ComercioOceano
GO
CREATE PROCEDURE SP_ExisteUsuario(
@NombreUsuario varchar(100),
@Mail varchar(100)
)
AS
BEGIN
	SELECT NombreUsuario, Mail from Usuarios where @NombreUsuario = NombreUsuario or @Mail = Mail and Estado = 1
END
GO
CREATE PROCEDURE SP_BuscarUsuario(
@NombreUsuario varchar(100),
@Contrasenia varchar(100)
)
AS
BEGIN
	SELECT * from Usuarios where
	@NombreUsuario = NombreUsuario and @Contrasenia = Contrasenia and Estado = 1
END
GO
CREATE PROCEDURE SP_BuscarAdmin(
@NombreUsuario varchar(100),
@Contrasenia varchar(100)
)
AS
BEGIN
	SELECT NombreUsuario, Contrasenia from UsuariosAdmin where
	@NombreUsuario = NombreUsuario and @Contrasenia = Contrasenia and Estado = 1
END
GO
CREATE PROCEDURE SP_BuscarVentas
AS
BEGIN
	SELECT V.FechaVenta, V.Total,SV.IdArticulo, SV.PrecioArticulo, SV.Cantidad FROM Venta AS V INNER JOIN
	SubVenta AS SV ON V.ID = SV.IdVenta
	
END
GO
CREATE PROCEDURE SP_ActualizarArticulo
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
CREATE PROCEDURE SP_AgregarArticulo
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
)RETURN

GO
CREATE PROCEDURE SP_ActualizarCategoria
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
CREATE PROCEDURE SP_AgregarProveedor
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
CREATE PROCEDURE SP_ActualizarProveedor
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
CREATE PROCEDURE SP_BajaLogicaProveedor
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
CREATE PROCEDURE SP_BajaLogicaCategoria
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
CREATE PROCEDURE SP_BajaLogicaArticulo
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
CREATE PROCEDURE SP_ActualizarUsuario
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
CREATE PROCEDURE SP_AgregarCategoria(
@Descripcion varchar(50),
@Estado bit
)
AS
INSERT INTO Categorias(DescripcionC, Estado) VALUES (@Descripcion, @Estado)
GO
CREATE PROCEDURE SP_AgregaVenta(
@IdUsuario bigint,
@Total money
)AS
BEGIN
INSERT INTO Venta(FechaVenta, IdUsuario, Total) VALUES(GETDATE(),@IdUsuario, @Total)
END
GO
CREATE PROCEDURE SP_AgregarSubVenta(
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

select V.FechaVenta, V.Total, A.Descripcion, SB.Cantidad, SB.PrecioArticulo, (SB.Cantidad * SB.PrecioArticulo) as 'SubTotal' from Venta as V inner join
SubVenta as SB on SB.IdVenta = V.ID inner join Articulos as A on A.ID = SB.IdArticulo where V.ID = SB.IdVenta and V.IdUsuario = 1