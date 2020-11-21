using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTIDAD;

namespace DAO
{
    public class DAOArticulos
    {
        AccesoDatos ds = new AccesoDatos();
        //Nuevo ->
        string consulta = "select a.ID, a.Descripcion, a.Stock, a.PrecioCompra, a.PrecioVenta, p.DescripcionP as 'Proveedor', " +
            "a.FechaVencimiento, c.DescripcionC as 'Categoria', a.ImagenUrl, a.Estado " +
            "from Articulos a " +
            "inner join Proveedores p on a.IdProveedor = p.Id " +         
            "inner join Categorias c on a.IdCategoria = c.ID;";
            
        public DataTable obtenerTablaArticulosConJoin()
        {
            DataTable tabla = ds.ObtenerTabla("Articulos", consulta);
            return tabla;
        }
        //<-
        public DataTable obtenerTablaArticulos()
        {
            DataTable tabla = ds.ObtenerTabla("Articulos", "SELECT * FROM Articulos");
            return tabla;
        }

        public DataTable obtenerArticuloId(int idArticulo)
        {
            DataTable tabla = ds.ObtenerTabla("Articulos", "SELECT * FROM Articulos where ID = " + idArticulo);
            return tabla;
        }

        public DataTable filtrarArticulo(string consulta)
        {
            DataTable tabla = ds.ObtenerTabla("Articulos", consulta);
            return tabla;
        }
        private void ArmarParametrosArticulo(ref SqlCommand Comando, Articulo art)
        {
            SqlParameter SqlParametros = new SqlParameter();           
            SqlParametros = Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
            SqlParametros.Value = art.Descripcion;
            SqlParametros = Comando.Parameters.Add("@Stock", SqlDbType.TinyInt);
            SqlParametros.Value = art.Stock;
            SqlParametros = Comando.Parameters.Add("@PrecioCompra", SqlDbType.Money);
            SqlParametros.Value = art.PrecioCompra;
            SqlParametros = Comando.Parameters.Add("@PrecioVenta", SqlDbType.Money);
            SqlParametros.Value = art.PrecioVenta;
            SqlParametros = Comando.Parameters.Add("@IdProveedor", SqlDbType.BigInt);
            SqlParametros.Value = art.IdProveedor;
            SqlParametros = Comando.Parameters.Add("@FechaVencimiento", SqlDbType.Date);
            SqlParametros.Value = art.FechaVencimiento;
            SqlParametros = Comando.Parameters.Add("@IdCategoria", SqlDbType.Int);
            SqlParametros.Value = art.IdCategoria;
            SqlParametros = Comando.Parameters.Add("@ImagenUrl", SqlDbType.VarChar);
            SqlParametros.Value = art.ImagenUrl;
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = art.Estado;
        }
        //Nuevo->
        private void ArmarParametrosArticuloActualizar(ref SqlCommand Comando, Articulo art)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID", SqlDbType.BigInt);
            SqlParametros.Value = art.Id;
            SqlParametros = Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
            SqlParametros.Value = art.Descripcion;
            SqlParametros = Comando.Parameters.Add("@Stock", SqlDbType.TinyInt);
            SqlParametros.Value = art.Stock;
            SqlParametros = Comando.Parameters.Add("@PrecioCompra", SqlDbType.Money);
            SqlParametros.Value = art.PrecioCompra;
            SqlParametros = Comando.Parameters.Add("@PrecioVenta", SqlDbType.Money);
            SqlParametros.Value = art.PrecioVenta;
            SqlParametros = Comando.Parameters.Add("@IdProveedor", SqlDbType.BigInt);
            SqlParametros.Value = art.IdProveedor;
            SqlParametros = Comando.Parameters.Add("@FechaVencimiento", SqlDbType.Date);
            SqlParametros.Value = art.FechaVencimiento;
            SqlParametros = Comando.Parameters.Add("@IdCategoria", SqlDbType.Int);
            SqlParametros.Value = art.IdCategoria;
            SqlParametros = Comando.Parameters.Add("@ImagenUrl", SqlDbType.VarChar);
            SqlParametros.Value = art.ImagenUrl;
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = art.Estado;
        }
        private void ArmarParametrosArticuloBajaLogica(ref SqlCommand Comando, Articulo art)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID", SqlDbType.BigInt);
            SqlParametros.Value = art.Id;
        }
        public bool AgregarArticulo(Articulo art)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosArticulo(ref Comando, art);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_AgregarArticulo");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        public bool ActualizarArticulo(Articulo art)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosArticuloActualizar(ref Comando, art);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_ActualizarArticulo");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        public bool BajaLogicaArticulo(Articulo art)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosArticuloBajaLogica(ref Comando, art);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_BajaLogicaArticulo");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        //<-
        public DataTable obtenerCarrito(List<string> id)
        {
            if (id.Count > 0)
            {
                string consulta = "SELECT * FROM Articulos where ID = ";

                for (int i = 0; i < id.Count; i++)
                {
                    if (i == 0)
                    {
                        consulta += id[i].ToString();
                    }
                    else
                    {
                        consulta += " OR ID = " + id[i].ToString();
                    }
                }

                return ds.ObtenerTabla("Articulos", consulta);
            }
            else
            {
                return null;
            }
        }
        public DataTable obtenerId(string d)
        {
            return ds.ObtenerTabla("Articulos", "SELECT ID FROM Articulos where Descripcion = '" + d + "'");
        }

    }
}
