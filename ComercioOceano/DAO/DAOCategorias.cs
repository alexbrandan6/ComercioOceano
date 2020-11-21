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
    public class DAOCategorias
    {
        AccesoDatos ds = new AccesoDatos();        
        public DataTable ObtenerTablaCategorias()
        {
            DataTable tabla = ds.ObtenerTabla("Categorias", "SELECT * FROM Categorias");
            return tabla;
        }
        public DataTable obtenerCategoriaId(int idCategoria)
        {
            DataTable tabla = ds.ObtenerTabla("Articulos", "SELECT * FROM Categoria where ID = " + idCategoria);
            return tabla;
        }
        private void ArmarParametrosCategoria(ref SqlCommand Comando, Categoria cat)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
            SqlParametros.Value = cat.Descripcion;
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = cat.Estado;
        }
        private void ArmarParametrosCategoriaActualizar(ref SqlCommand Comando, Categoria cat)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID", SqlDbType.Int);
            SqlParametros.Value = cat.ID;
            SqlParametros = Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
            SqlParametros.Value = cat.Descripcion;
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = cat.Estado;
        }
        private void ArmarParametrosCategoriaBajaLogica(ref SqlCommand Comando, Categoria cat)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID", SqlDbType.Int);
            SqlParametros.Value = cat.ID;            
        }
        public bool AgregarCategoria(Categoria cat)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosCategoria(ref Comando, cat);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_AgregarCategoria");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        public bool ActualizarCategoria(Categoria cat)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosCategoriaActualizar(ref Comando, cat);            
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_ActualizarCategoria");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        public bool BajaLogicaCategoria(Categoria cat)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosCategoriaBajaLogica(ref Comando, cat);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_BajaLogicaCategoria");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        public DataTable obtenerCategorias()
        {
            DataTable tabla = ds.ObtenerTabla("Categorias", "SELECT * FROM Categorias");
            return tabla;
        }
        public DataTable filtrarCategoria(string consulta)
        {
            DataTable tabla = ds.ObtenerTabla("Categorias", consulta);
            return tabla;
        }
    }
}
