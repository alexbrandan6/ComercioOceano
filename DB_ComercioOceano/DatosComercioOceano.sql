USE ComercioOceano
GO
-- Categorias
INSERT INTO Categorias(DescripcionC, Estado) VALUES ('Kilo',1)
INSERT INTO Categorias(DescripcionC, Estado) VALUES ('Unidad',1)
GO
-- Proveedores
INSERT INTO Proveedores(DescripcionP, Direccion, Telefono, Mail, Estado) VALUES ('Granja Sol', 'Corralito 123', '6598321', 'granjasol@gmail.com',1)
INSERT INTO Proveedores(DescripcionP, Direccion, Telefono, Mail, Estado) VALUES ('La Mejor', 'Pachaco 325', '6698731','lamejor@gmail.com',1)
GO
-- Articulos
INSERT INTO Articulos(Descripcion, Stock, PrecioCompra, PrecioVenta, IdProveedor, FechaVencimiento, IdCategoria, ImagenUrl, Estado)
VALUES ('Pollo',20,65,70,1,CONVERT(char(19),'10/11/2019',113),1,'IMAGENES\pollo.jpg',1)
INSERT INTO Articulos(Descripcion, Stock, PrecioCompra, PrecioVenta, IdProveedor, FechaVencimiento, IdCategoria, ImagenUrl, Estado)
VALUES ('Huevos',50,3.5,5,2,CONVERT(char(19),'10/11/2019',113),2,'IMAGENES\huevos.jpg',1)
INSERT INTO Articulos(Descripcion, Stock, PrecioCompra, PrecioVenta, IdProveedor, FechaVencimiento, IdCategoria, ImagenUrl, Estado)
VALUES ('Asado',50,120,170,2,CONVERT(char(19),'10/11/2019',113),1,'IMAGENES\asado.jpg',1)
INSERT INTO Articulos(Descripcion, Stock, PrecioCompra, PrecioVenta, IdProveedor, FechaVencimiento, IdCategoria, ImagenUrl, Estado)
VALUES ('Paty',30,7,10,1,CONVERT(char(19),'10/11/2019',113),2,'IMAGENES\paty.jpg',1)
GO
-- Administradores
insert into UsuariosAdmin(Nombres, Apellidos, fechaNac, Genero, Telefono, Direccion, Mail, NombreUsuario, Contrasenia, NivelCargo, Estado)
values('Enzo','Perez','02-06-1995','M',6548913,'Calle 123','mail@asd','Admin01', '123456', 'Dueño',1)