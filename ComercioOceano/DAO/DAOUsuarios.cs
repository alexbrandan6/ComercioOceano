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
    public class DAOUsuarios
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable existeUsuario(string nombreU, string mailU)
        {
            string nombreProcedure = "SP_ExisteUsuario";

            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection();
            cnn = ds.obtenerConexion();
            SqlDataAdapter da = new SqlDataAdapter(nombreProcedure, cnn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = nombreU;
            da.SelectCommand.Parameters.Add("@Mail", SqlDbType.VarChar).Value = mailU;

            da.Fill(dt);

            cnn.Close();
            return dt;
        }

        public void grabarUsuario(Usuario usr)
        {
            string insert = "INSERT INTO Usuarios(Nombres, Apellidos, fechaNac, Genero, Telefono, Direccion, " +
                "Mail, NombreUsuario, Contrasenia, Estado) VALUES (@nombres, @apellidos, @fechaNac, @genero, @telefono, " +
                "@direccion, @mail, @nombreU, @contra, @estado)";
            SqlConnection cnn = new SqlConnection();
            cnn = ds.obtenerConexion();
            SqlCommand cm = new SqlCommand(insert, cnn);
            cm.Parameters.AddWithValue("@nombres", usr.getNombres());
            cm.Parameters.AddWithValue("@apellidos", usr.getApellidos());
            cm.Parameters.AddWithValue("@fechaNac", usr.getFechaNac());
            cm.Parameters.AddWithValue("@genero", usr.getGenero());
            cm.Parameters.AddWithValue("@telefono", usr.getNumeroTelefono());
            cm.Parameters.AddWithValue("@direccion", usr.getDireccion());
            cm.Parameters.AddWithValue("@mail", usr.getMail());
            cm.Parameters.AddWithValue("@nombreU", usr.getNombreUsuario());
            cm.Parameters.AddWithValue("@contra", usr.getContrasenia());
            cm.Parameters.AddWithValue("@estado",1);

            cm.ExecuteNonQuery();
            cnn.Close();
        }

        public DataTable buscarUsuario(string nombreU, string contra)
        {
            string nombreProcedure = "SP_BuscarUsuario";

            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection();
            cnn = ds.obtenerConexion();
            SqlDataAdapter da = new SqlDataAdapter(nombreProcedure, cnn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = nombreU;
            da.SelectCommand.Parameters.Add("@Contrasenia", SqlDbType.VarChar).Value = contra;

            da.Fill(dt);

            cnn.Close();
            return dt;
        }

        public DataTable buscarAdmin(string nombreU, string contra)
        {
            string nombreProcedure = "SP_BuscarAdmin";

            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection();
            cnn = ds.obtenerConexion();
            SqlDataAdapter da = new SqlDataAdapter(nombreProcedure, cnn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = nombreU;
            da.SelectCommand.Parameters.Add("@Contrasenia", SqlDbType.VarChar).Value = contra;

            da.Fill(dt);

            cnn.Close();
            return dt;
        }

        public DataTable cargarUsuario(string nombreU)
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT * FROM Usuarios WHERE NombreUsuario = '" + 
                nombreU + "'");
            return tabla;
        }
        public DataTable ObtenerTablaUsuarios()
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT * FROM Usuarios ");
            return tabla;
        }
        public bool ActualizarUsuario(Usuario usu)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosUsuarioActualizar(ref Comando, usu);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_ActualizarUsuario");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        private void ArmarParametrosUsuarioActualizar(ref SqlCommand Comando, Usuario usu)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID", SqlDbType.BigInt);
            SqlParametros.Value = usu.getId();
            SqlParametros = Comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 50);
            SqlParametros.Value = usu.getNombres();
            SqlParametros = Comando.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50);
            SqlParametros.Value = usu.getApellidos();
            SqlParametros = Comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
            SqlParametros.Value = usu.getFechaNac();
            SqlParametros = Comando.Parameters.Add("@Genero", SqlDbType.Char, 1);
            SqlParametros.Value = usu.getGenero();
            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20);
            SqlParametros.Value = usu.getNumeroTelefono();
            SqlParametros = Comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 50);
            SqlParametros.Value = usu.getDireccion();
            SqlParametros = Comando.Parameters.Add("@Mail", SqlDbType.VarChar, 50);
            SqlParametros.Value = usu.getMail();
            SqlParametros = Comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 100);
            SqlParametros.Value = usu.getNombreUsuario();
            SqlParametros = Comando.Parameters.Add("@Contraseña", SqlDbType.VarChar, 100);
            SqlParametros.Value = usu.getContrasenia();
        }
        public DataTable filtrarUsuario(string consulta)
        {
            return ds.ObtenerTabla("Usuarios", consulta);
        }
    }
}
