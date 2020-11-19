CREATE DATABASE ComercioOceano
GO
USE ComercioOceano
GO
CREATE TABLE Usuarios(
ID bigint identity(1,1) not null primary key,
Nombres varchar(50) not null,
Apellidos varchar(50) not null,
fechaNac date not null,
Genero char null,
Telefono varchar(20) null,
Direccion varchar(50) not null,
Mail varchar(50) not null,
NombreUsuario varchar(100) not null,
Contrasenia varchar(100) not null,
Estado bit not null,
UNIQUE(ID, NombreUsuario, Mail)
)
GO
CREATE TABLE UsuariosAdmin(
ID bigint identity(1,1) not null primary key,
Nombres varchar(50) not null,
Apellidos varchar(50) not null,
fechaNac date not null,
Genero char null,
Telefono varchar(20) null,
Direccion varchar(50) not null,
Mail varchar(50) not null,
NombreUsuario varchar(100) not null,
Contrasenia varchar(100) not null,
NivelCargo varchar(50) not null,
Estado bit not null,
UNIQUE(ID, NombreUsuario, Mail)
)
GO
CREATE TABLE Categorias(
ID int not null identity(1,1) primary key,
DescripcionC varchar(100) not null,
Estado bit not null
)
GO
CREATE TABLE Proveedores(
Id bigint not null identity(1,1) primary key,
DescripcionP varchar(100) not null,
Direccion varchar(100) not null,
Telefono varchar(100) not null,
Mail varchar(100) not null,
Estado bit not null
)
GO
CREATE TABLE Articulos(
ID bigint not null identity(1,1) primary key,
Descripcion varchar(100) not null,
Stock tinyint not null,
PrecioCompra money not null,
PrecioVenta money not null,
IdProveedor bigint not null foreign key references Proveedores(Id),
FechaVencimiento date not null,
IdCategoria int not null foreign key references Categorias(Id),
ImagenUrl varchar(30) null,
Estado bit not null
)
GO
CREATE TABLE Venta(
ID bigint identity(1,1) primary key,
FechaVenta date not null,
IdUsuario bigint not null foreign key references Usuarios(ID),
Total money not null,
)
GO
CREATE TABLE SubVenta(
ID bigint identity(1,1) primary key,
IdVenta bigint not null foreign key references Venta(ID),
IdArticulo bigint not null foreign key references Articulos(ID),
Cantidad bigint not null,
PrecioArticulo money not null
)