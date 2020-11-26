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

        public bool grabarUsuario(Usuario usr)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosUsuarioAgregar(ref Comando, usr);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_AgregarUsuario");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
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

        public DataTable obtenerUsuarioId(int idUsuario)
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT * FROM Usuarios where ID = " + idUsuario);
            return tabla;
        }
        public DataTable obtenerAdminId(int idAdmin)
        {
            DataTable tabla = ds.ObtenerTabla("UsuariosAdmin", "SELECT * FROM UsuariosAdmin where ID = " + idAdmin);
            return tabla;
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
        private void ArmarParametrosUsuarioAgregar(ref SqlCommand Comando, Usuario usu)
        {
            SqlParameter SqlParametros = new SqlParameter();
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
        private void ArmarParametrosUsuarioBajaLogica(ref SqlCommand Comando, Usuario usr)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Id", SqlDbType.BigInt);
            SqlParametros.Value = usr.getId();
        }
        public bool BajaLogicaUsuario(Usuario usr)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosUsuarioBajaLogica(ref Comando, usr);
            int FilasInsertadas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_BajaLogicaUsuario");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
    }
}
