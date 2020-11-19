using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTIDAD;
//Todo
namespace DAO
{
    public class DAOProveedor
    {
        AccesoDatos ds = new AccesoDatos();
        public DataTable obtenerTablaProveedores()
        {
            DataTable tabla = ds.ObtenerTabla("Proveedores", "SELECT * FROM Proveedores");
            return tabla;
        }
        private void ArmarParametrosProveedor(ref SqlCommand Comando, Proveedor pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
            SqlParametros.Value = pro.Descripcion;
            SqlParametros = Comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 100);
            SqlParametros.Value = pro.Direccion;
            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100);
            SqlParametros.Value = pro.Telefono;
            SqlParametros = Comando.Parameters.Add("@Mail", SqlDbType.VarChar, 100);
            SqlParametros.Value = pro.Mail;
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = pro.Estado;
        }
        private void ArmarParametrosProveedorActualizar(ref SqlCommand Comando, Proveedor pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Id", SqlDbType.BigInt);
            SqlParametros.Value = pro.Id;
            SqlParametros = Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
            SqlParametros.Value = pro.Descripcion;
            SqlParametros = Comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 100);
            SqlParametros.Value = pro.Direccion;
            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100);
            SqlParametros.Value = pro.Telefono;
            SqlParametros = Comando.Parameters.Add("@Mail", SqlDbType.VarChar, 100);
            SqlParametros.Value = pro.Mail;
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = pro.Estado;
        }
        private void ArmarParametrosProveedorBajaLogica(ref SqlCommand Comando, Proveedor pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Id", SqlDbType.BigInt);
            SqlParametros.Value = pro.Id;            
        }
        public bool AgregarProveedor(Proveedor pro)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProveedor(ref Comando, pro);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_AgregarProveedor");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        public bool ActualizarProveedor(Proveedor pro)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProveedorActualizar(ref Comando, pro);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_ActualizarProveedor");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        public bool BajaLogicaProveedor(Proveedor pro)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProveedorBajaLogica(ref Comando, pro);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_BajaLogicaProveedor");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }

        public DataTable obtenerProovedores()
        {
            DataTable tabla = ds.ObtenerTabla("Proveedores", "SELECT * FROM Proveedores");
            return tabla;
        }
        public DataTable filtrarProveedor(string consulta)
        {
            DataTable tabla = ds.ObtenerTabla("Proveedores", consulta);
            return tabla;
        }
    }
}
