using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class AccesoDatos
    {
        string rutaSQL = "Data Source=localhost; Initial Catalog=ComercioOceano;Integrated Security=True";
        public SqlConnection obtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaSQL);
            cn.Open();
            return cn;
        }
        private SqlDataAdapter ObtenerAdaptador(string consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter(consultaSql, cn);
            return adaptador;
        }

        public DataTable ObtenerTabla(string NombreTabla, string Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = obtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }


        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP) //comando que recibe tiene los parametros incluidos
        {
            int FilasCambiadas;
            SqlConnection Conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }
    }
}
