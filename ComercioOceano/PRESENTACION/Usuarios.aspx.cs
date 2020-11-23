using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NEGOCIO;
using ENTIDAD;

namespace PRESENTACION.PaginaAdmin
{
    public partial class Usuarios : System.Web.UI.Page
    {
        N_Usuario n_u = new N_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = Request.QueryString["AdminU"];
            if (!IsPostBack)
            {
                cargarGridView();
            }
        }
        public void cargarGridView()
        {
            DataTable tabla = new DataTable();
            tabla = n_u.obtenerTablaUsuarios();            
            grid_Usuarios.DataSource = tabla;
            grid_Usuarios.DataBind();
        }

        protected void grid_Usuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid_Usuarios.EditIndex = e.NewEditIndex;

            cargarGridView();
        }

        protected void grid_Usuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid_Usuarios.EditIndex = -1;

            cargarGridView();
        }

        protected void grid_Usuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Usuario usu = new Usuario();
            usu.SetId(Convert.ToInt32(((Label)grid_Usuarios.Rows[e.RowIndex].FindControl("lbl_eit_ID")).Text));
            usu.setNombres(((TextBox)grid_Usuarios.Rows[e.RowIndex].FindControl("txt_eit_Nombres")).Text);
            usu.setApellidos(((TextBox)grid_Usuarios.Rows[e.RowIndex].FindControl("txt_eit_Apellidos")).Text);
            //usu.setFechaNac(((TextBox)grid_Usuarios.Rows[e.RowIndex].FindControl("txt_eit_FechaNacimiento")).Text);            
            usu.setGenero(((DropDownList)grid_Usuarios.Rows[e.RowIndex].FindControl("ddl_eit_Genero")).Text.Trim());
            usu.setNumeroTelefono(Convert.ToInt32(((TextBox)grid_Usuarios.Rows[e.RowIndex].FindControl("txt_eit_Telefono")).Text));
            usu.setDireccion(((TextBox)grid_Usuarios.Rows[e.RowIndex].FindControl("txt_eit_Direccion")).Text);
            usu.setMail(((TextBox)grid_Usuarios.Rows[e.RowIndex].FindControl("txt_eit_Mail")).Text);
            usu.setNombreUsuario(((TextBox)grid_Usuarios.Rows[e.RowIndex].FindControl("txt_eit_NombreUsuario")).Text);
            usu.setContrasenia(((TextBox)grid_Usuarios.Rows[e.RowIndex].FindControl("txt_eit_Contraseña")).Text);

            n_u.actualizarUsuario(usu);

            grid_Usuarios.EditIndex = -1;
            cargarGridView();
        }

        protected void lkbPaginaPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("PAginaPrincipalAdmin.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void lkbArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarArticulo.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void lkbProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreBuscar.Text.Trim();
            string apellido = txtApellidoBuscar.Text.Trim();
            string nomreUsuario = txtNombreUsuarioBuscar.Text.Trim();
            int ch = 0;
            if(chbAlfabetico.Checked == true)
            {
                ch = 1;
            }
            DataTable tabla = new DataTable();
            tabla = n_u.filtrarUsuario(nombre, apellido, nomreUsuario, ch);
            grid_Usuarios.DataSource = tabla;
            grid_Usuarios.DataBind();
        }
    }
}