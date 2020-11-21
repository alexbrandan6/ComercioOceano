using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAO;
using System.Data;

namespace NEGOCIO
{
    public class N_Articulos
    {
        DAOArticulos dao = new DAOArticulos();
        DAOCategorias daoC = new DAOCategorias();
        DAOProveedor daoP = new DAOProveedor();

        public DataTable obtenerTabla()
        {
            return dao.obtenerTablaArticulosConJoin();
        }
        public DataTable obtenerTablaArticulos()
        {
            return dao.obtenerTablaArticulos();
        }

        public DataTable obtenerArticuloId(int idArticulo)
        {
            return dao.obtenerArticuloId(idArticulo);
        }

        public DataTable filtrarArticulo(string nombreA, string cat, string precio, string precioRango)
        {
            DataTable tabla = new DataTable();
            string consulta = "";
            if(nombreA != "")
            {
                if(cat != "")
                {
                    if(precioRango != "")
                    {
                        consulta = "SELECT * FROM Articulos AS A inner join Categorias AS C ON A.IdCategoria = C.ID WHERE A.Descripcion LIKE '%" +nombreA + "%' AND C.DescripcionC like '%"
                            + cat + "%' AND A.PrecioVenta " + precioRango + " " + precio;
                        return dao.filtrarArticulo(consulta);
                    }
                    else
                    {
                        consulta = "SELECT * FROM Articulos AS A inner join Categorias AS C ON A.IdCategoria = C.ID WHERE A.Descripcion LIKE '%" + nombreA + "%' AND C.DescripcionC like '%"
                            + cat + "%'";
                    return dao.filtrarArticulo(consulta);
                    }
                }
                else
                {
                    consulta = "SELECT * FROM Articulos WHERE Descripcion LIKE '%" + nombreA + "%'";
                    return dao.filtrarArticulo(consulta);
                }
            }
            else
            {
                if(cat != "")
                {
                    if(precioRango != "")
                    {
                        consulta = "SELECT * FROM Articulos AS A inner join Categorias AS C ON A.IdCategoria = C.ID WHERE C.DescripcionC like '%"
                            + cat + "%' AND A.PrecioVenta " + precioRango + " " + precio;
                        return dao.filtrarArticulo(consulta);
                    }
                    else
                    {
                        consulta = "SELECT * FROM Articulos AS A inner join Categorias AS C ON A.IdCategoria = C.ID WHERE C.DescripcionC like '%" + cat + "%'";
                        return dao.filtrarArticulo(consulta);
                    }
                }
                else
                {
                    if(precioRango != "")
                    {
                        consulta = "SELECT * FROM Articulos WHERE PrecioVenta " + precioRango + " " + precio;
                        return dao.filtrarArticulo(consulta);
                    }
                    else
                    {
                        consulta = "SELECT * FROM Articulos";
                        return dao.filtrarArticulo(consulta);
                    }
                }
            }
        }
        public bool grabarArticulo(Articulo art)
        {
            if (dao.AgregarArticulo(art))
            {
                return true;
            }
            else return false;            
        }
        public bool actualizarArticulo(Articulo art)
        {
            if (dao.ActualizarArticulo(art))
            {
                return true;
            }
            else return false;
        }
        public bool bajalogicaArticulo(Articulo art)
        {
            if (dao.BajaLogicaArticulo(art))
            {
                return true;
            }
            else return false;

        }
        public DataTable obtenerTablaCategorias()
        {
            return daoC.obtenerCategorias();
        }

        public DataTable obtenerTablaProveedores()
        {
            return daoP.obtenerProovedores();
        }

        public DataTable obtenerCarrito(List<string> id)
        {
            return dao.obtenerCarrito(id);
        }
        public DataTable obtenerId(string d)
        {
            return dao.obtenerId(d);
        }

        public DataTable filtrarArticuloAdmin(string nombreA, string cat, string precio, string precioRango)
        {
            DataTable tabla = new DataTable();
            string consulta = "";
            if (nombreA != "")
            {
                if (cat != "")
                {
                    if (precioRango != "")
                    {
                        consulta = "SELECT A.ID, A.Descripcion, A.Stock, A.PrecioCompra, A.PrecioVenta,  P.DescripcionP as 'Proveedor', A.FechaVencimiento, C.DescripcionC as 'Categoria'," +
                                   "A.ImagenUrl, A.Estado FROM Articulos AS A inner join Proveedores as P on P.Id = A.IdProveedor inner join Categorias AS C ON A.IdCategoria = C.ID WHERE A.Descripcion LIKE '%" +
                                    nombreA + "%' AND C.DescripcionC like '%" +
                                    cat + "%' AND A.PrecioVenta " + precioRango + " " + precio;
                        return dao.filtrarArticulo(consulta);
                    }
                    else
                    {
                        consulta = "SELECT A.ID, A.Descripcion, A.Stock, A.PrecioCompra, A.PrecioVenta,   P.DescripcionP as 'Proveedor', A.FechaVencimiento, C.DescripcionC as 'Categoria'," +
                                   "A.ImagenUrl, A.Estado FROM Articulos AS A inner join Proveedores as P on P.Id = A.IdProveedor inner join Categorias AS C ON A.IdCategoria = C.ID WHERE A.Descripcion LIKE '%" + nombreA + "%' AND C.DescripcionC like '%"
                            + cat + "%'";
                        return dao.filtrarArticulo(consulta);
                    }
                }
                else
                {
                    consulta = "SELECT A.ID, A.Descripcion, A.Stock, A.PrecioCompra, A.PrecioVenta,  P.DescripcionP as 'Proveedor', A.FechaVencimiento, C.DescripcionC as 'Categoria'," +
                                   "A.ImagenUrl, A.Estado FROM Articulos AS A inner join Proveedores as P on P.Id = A.IdProveedor inner join Categorias AS C ON A.IdCategoria = C.ID WHERE A.Descripcion LIKE '%" + nombreA + "%'";
                    return dao.filtrarArticulo(consulta);
                }
            }
            else
            {
                if (cat != "")
                {
                    if (precioRango != "")
                    {
                        consulta = "SELECT A.ID, A.Descripcion, A.Stock, A.PrecioCompra, A.PrecioVenta,  P.DescripcionP as 'Proveedor', A.FechaVencimiento, C.DescripcionC as 'Categoria'," +
                                   "A.ImagenUrl, A.Estado FROM Articulos AS A inner join Proveedores as P on P.Id = A.IdProveedor inner join Categorias AS C ON A.IdCategoria = C.ID WHERE C.DescripcionC like '%"
                            + cat + "%' AND A.PrecioVenta " + precioRango + " " + precio;
                        return dao.filtrarArticulo(consulta);
                    }
                    else
                    {
                        consulta = "SELECT A.ID, A.Descripcion, A.Stock, A.PrecioCompra, A.PrecioVenta, P.DescripcionP as 'Proveedor', A.FechaVencimiento, C.DescripcionC as 'Categoria'," +
                                   "A.ImagenUrl, A.Estado FROM Articulos AS A inner join Proveedores as P on P.Id = A.IdProveedor inner join Categorias AS C ON A.IdCategoria = C.ID WHERE C.DescripcionC like '%" + cat + "%'";
                        return dao.filtrarArticulo(consulta);
                    }
                }
                else
                {
                    if (precioRango != "")
                    {
                        consulta = "SELECT A.ID, A.Descripcion, A.Stock, A.PrecioCompra, A.PrecioVenta,  P.DescripcionP as 'Proveedor', A.FechaVencimiento, C.DescripcionC as 'Categoria'," +
                                   "A.ImagenUrl, A.Estado FROM Articulos AS A inner join Proveedores as P on P.Id = A.IdProveedor inner join Categorias AS C ON A.IdCategoria = C.ID WHERE PrecioVenta " + precioRango + " " + precio;
                        return dao.filtrarArticulo(consulta);
                    }
                    else
                    {
                        consulta = "SELECT A.ID, A.Descripcion, A.Stock, A.PrecioCompra, A.PrecioVenta,  P.DescripcionP as 'Proveedor', A.FechaVencimiento, C.DescripcionC as 'Categoria'," +
                                   "A.ImagenUrl, A.Estado FROM Articulos AS A inner join Proveedores as P on P.Id = A.IdProveedor inner join Categorias AS C ON A.IdCategoria = C.ID;";
                        return dao.filtrarArticulo(consulta);
                    }
                }
            }
        }
    }

}
