using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NEGOCIO;
using ENTIDAD;

namespace PRESENTACION
{
    public partial class PAginaPrincipalAdmin : System.Web.UI.Page
    {
        N_Articulos n_a = new N_Articulos();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = Request.QueryString["AdminU"];

            if (!IsPostBack)
            {
                DataTable tabla2 = new DataTable();
                tabla2 = n_a.obtenerTabla();
                rpUsuarios.DataSource = tabla2;
                rpUsuarios.DataBind();
            }
        }
        public void cargarGridView()
        {
            DataTable tabla = new DataTable();
            tabla = n_a.obtenerTabla();
            rpUsuarios.DataSource = tabla;
            rpUsuarios.DataBind();
        }
        protected void InsertButton_Click(object sender, EventArgs e)
        {

        }

        protected void lkbAgregarArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarArticulo.aspx");
        }

        protected void lkbCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx");
        }

        protected void lkbProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }

        protected void lkbUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }        

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx?");
        }

        protected void btnArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarArticulo.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void btnProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void btnCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            // Llenar para ir a pagina del perfil
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["stUser"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}