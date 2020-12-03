using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        N_Usuario n_u = new N_Usuario();
        N_Articulos n_a = new N_Articulos();
        public static List<string> id = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGridViews();
            }

        }
        public void cargarGridViews()
        {
            DataTable tabla = new DataTable();

            tabla = n_a.obtenerTabla();
            rpArticulos.DataSource = tabla;
            rpArticulos.DataBind();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {

        }
    }
}