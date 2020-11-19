using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NEGOCIO;

namespace PRESENTACION
{
    public partial class PaginaPerfilUsuario : System.Web.UI.Page
    {
        N_Usuario n_u = new N_Usuario();
        N_Venta n_v = new N_Venta();

        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreU = Request.QueryString["NomU"];
            txtNombreUsuario.Text = nombreU;

            DataTable tabla = new DataTable();
            tabla = n_u.cargarUsuario(nombreU);

            txtNombres.Text = tabla.Rows[0]["Nombres"].ToString();
            txtApellidos.Text = tabla.Rows[0]["Apellidos"].ToString();
            txtGenero.Text = tabla.Rows[0]["Genero"].ToString();
            txtTelefono.Text = tabla.Rows[0]["Telefono"].ToString();
            txtDireccion.Text = tabla.Rows[0]["Direccion"].ToString();
            txtMail.Text = tabla.Rows[0]["Mail"].ToString();
            txtNombreUsuario.Text = tabla.Rows[0]["NombreUsuario"].ToString();
            txtContra.Text = tabla.Rows[0]["Contrasenia"].ToString();
            int idU = Convert.ToInt32(tabla.Rows[0]["ID"].ToString());
            tabla = n_v.obtenerTablaVentas(idU);
            grid_Compras.DataSource = tabla;
            grid_Compras.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla = n_u.cargarUsuario(txtNombreUsuario.Text);
            Response.Redirect("PaginaPrincipalConUsuario.aspx?NomU=" + txtNombreUsuario.Text + "&IdU=" + tabla.Rows[0]["ID"].ToString());
        }

        protected void lkbPaginaPrincipal_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla = n_u.cargarUsuario(txtNombreUsuario.Text);
            Response.Redirect("PaginaPrincipalConUsuario.aspx?NomU=" + txtNombreUsuario.Text + "&IdU=" + tabla.Rows[0]["ID"].ToString());
        }

        protected void lkbCarrito_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla = n_u.cargarUsuario(txtNombreUsuario.Text);
            Response.Redirect("Carrito.aspx?NomU=" + txtNombreUsuario.Text + "&IdU=" + tabla.Rows[0]["ID"].ToString()); ;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}