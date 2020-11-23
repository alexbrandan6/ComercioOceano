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
        N_Categoria n_c = new N_Categoria();
        N_Proveedor n_p = new N_Proveedor();
        N_Usuario n_u = new N_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["stUser"] == null)
            {
                Session["stUser"] = null;
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    cargarGridViews();
                }
            }
        }
        public void cargarGridViews()
        {
            DataTable tabla = new DataTable();

            tabla = n_a.obtenerTabla();
            rpArticulos.DataSource = tabla;
            rpArticulos.DataBind();

            tabla = n_c.obtenerTablaCategorias();
            rpCategorias.DataSource = tabla;
            rpCategorias.DataBind();

            tabla = n_p.obtenerTablaProveedores();
            rpProveedores.DataSource = tabla;
            rpProveedores.DataBind();

            tabla = n_u.obtenerTablaUsuarios();
            rpUsuarios.DataSource = tabla;
            rpUsuarios.DataBind();
        }

        protected void btnArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMArticulos.aspx");
        }

        protected void btnProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMProveedores.aspx");
        }

        protected void btnCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMCategorias.aspx");
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMUsuarios.aspx");
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