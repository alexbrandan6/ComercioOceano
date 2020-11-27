using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using ENTIDAD;
using System.Data;

namespace NEGOCIO
{
    public class N_Usuario
    {
        DAOUsuarios dao_u = new DAOUsuarios();

        public string usuarioExiste(Usuario usr)
        {
            DataTable dt = new DataTable();
            dt = dao_u.existeUsuario(usr.getNombreUsuario(), usr.getMail());

            if (dt.Rows.Count > 0)
            {
                if(dt.Rows[0]["NombreUsuario"].ToString() == usr.getNombreUsuario()
                    && dt.Rows[0]["Mail"].ToString() == usr.getMail())
                {
                    return "El nombre de usuario y mail ya existen";
                }
                else
                {
                    if(dt.Rows[0]["NombreUsuario"].ToString() == usr.getNombreUsuario())
                    {
                        return "El nombre de usuario ya existe";
                    }
                    else
                    {
                        return "El mail ya existe";
                    }
                }
            }
            else return "nada";
            
        }

        public bool grabarUsuario(Usuario usr)
        {
            if(dao_u.grabarUsuario(usr))
            {
                return true;
            }
            else return false;
        }

        public DataTable buscarUsuario(string nombreU, string contra)
        {
            DataTable dt = new DataTable();
            dt = dao_u.buscarUsuario(nombreU, contra);

            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else return null;
        }

        public DataTable obtenerUsuarioId(int idUsuario)
        {
            return dao_u.obtenerUsuarioId(idUsuario);
        }
        public DataTable obtenerAdminId(int idAdmin)
        {
            return dao_u.obtenerAdminId(idAdmin);
        }

        public DataTable buscarAdmin(string nombreU, string contra)
        {
            DataTable dt = new DataTable();
            dt = dao_u.buscarAdmin(nombreU, contra);

            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else return null;
        }

        public DataTable cargarUsuario(string nombreU)
        {
            DataTable dt = new DataTable();
            dt = dao_u.cargarUsuario(nombreU);
            return dt;
        }
        public DataTable obtenerTablaUsuarios()
        {
            return dao_u.ObtenerTablaUsuarios();
        }
        public bool actualizarUsuario(Usuario usu)
        {
            if (dao_u.ActualizarUsuario(usu))
            {
                return true;
            }
            else return false;
        }
        public void actualizarUsuarioDato(string scriptSql)
        {
            dao_u.EjecutarScript(scriptSql);
        }
        public bool bajaLogicaUsuario(Usuario usr)
        {
            if (dao_u.BajaLogicaUsuario(usr))
            {
                return true;
            }
            else return false;
        }
        public DataTable filtrarUsuario(string nombre, string apellido, string nombreU, int ch)
        {
            string consulta;

            if(nombre != "")
            {
                if(apellido != "")
                {
                    if(nombreU != "")
                    {
                        if(ch == 1)
                        {
                            consulta = "Select * from Usuarios where Nombres like '%" + nombre + "%' and Apellidos like '%" +
                            apellido + "%' and NombreUsuario like '%" + nombreU + "%' order by Apellidos asc";
                            return dao_u.filtrarUsuario(consulta);
                        }
                        else
                        {
                            consulta = "Select * from Usuarios where Nombres like '%" + nombre + "%' and Apellidos like '%" +
                            apellido + "%' and NombreUsuario like '%" + nombreU + "%'";
                            return dao_u.filtrarUsuario(consulta);
                        }
                    }
                    else
                    {   
                         if(ch == 1)
                         {
                            consulta = "Select * from Usuarios where Nombres like '%" + nombre + "%' and Apellidos like '%" +
                            apellido + "%' order by Apellidos asc";
                            return dao_u.filtrarUsuario(consulta);
                        }
                        else
                        {
                            consulta = "Select * from Usuarios where Nombres like '%" + nombre + "%' and Apellidos like '%" +
                            apellido + "%'";
                            return dao_u.filtrarUsuario(consulta);
                        }
                    }
                }
                else
                {
                    if(ch == 1)
                    {
                        consulta = "Select * from Usuarios where Nombres like '%" + nombre + "%' order by Apellidos asc";
                        return dao_u.filtrarUsuario(consulta);
                    }
                    else
                    {
                        consulta = "Select * from Usuarios where Nombres like '%" + nombre + "%'";
                        return dao_u.filtrarUsuario(consulta);
                    }
                }
            }
            else
            {
                if(apellido != "")
                {
                    if(nombreU != "")
                    {
                        if(ch == 1)
                        {
                            consulta = "select * from Usuarios where Apellidos like '%" +
                            apellido + "%' and NombreUsuario like '%" + nombreU + "%' order by Apellidos asc";
                            return dao_u.filtrarUsuario(consulta);
                        }
                        else
                        {
                            consulta = "select * from Usuarios where Apellidos like '%" +
                            apellido + "%' and NombreUsuario like '%" + nombreU + "%'";
                            return dao_u.filtrarUsuario(consulta);
                        }
                    }
                    else
                    {
                        if(ch == 1)
                        {
                            consulta = "select * from Usuarios where Apellidos like '%" + apellido +
                                "%' order by Apellidos asc";
                            return dao_u.filtrarUsuario(consulta);
                        }
                        else
                        {
                            consulta = "select * from Usuarios where Apellidos like '%" + apellido +
                                "%'";
                            return dao_u.filtrarUsuario(consulta);
                        }
                    }
                }
                else
                {
                    if(nombreU != "")
                    {
                        if(ch == 1)
                        {
                            consulta = "select * from Usuarios where NombreUsuario like '%" + nombreU +
                                "%' order by Apellidos asc";
                            return dao_u.filtrarUsuario(consulta);
                        }
                        else
                        {
                            consulta = "select * from Usuarios where NombreUsuario like '%" + nombreU +
                                "%'";
                            return dao_u.filtrarUsuario(consulta);
                        }
                    }
                    else
                    {
                        if(ch == 1)
                        {
                            consulta = "select * from Usuarios order by Apellidos asc";
                            return dao_u.filtrarUsuario(consulta);
                        }
                        else
                        {
                            consulta = "select * from Usuarios";
                            return dao_u.filtrarUsuario(consulta);
                        }
                    }
                }
            }
        }

    }
}
