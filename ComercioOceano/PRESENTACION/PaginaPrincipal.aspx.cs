using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using NEGOCIO;

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
                DataTable tabla = n_a.obtenerTablaCategorias();
                ddlCategorias.Items.Add("");
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    ddlCategorias.Items.Add(tabla.Rows[i]["DescripcionC"].ToString());
                }


                DataTable tabla2 = new DataTable();
                tabla2 = n_a.obtenerTabla();
                lvArticulos.DataSource = tabla2;
                lvArticulos.DataBind();
            }

        }

        protected void btnEntrar_Click1(object sender, EventArgs e)
        {
            DataTable U = new DataTable();
            U = n_u.buscarUsuario(txtNombreUsuario.Text.Trim(), txtContra.Text.Trim());
            string A = n_u.buscarAdmin(txtNombreUsuario.Text.Trim(), txtContra.Text.Trim());

            if (U == null)
            {
                if (A != "0")
                {
                    Response.Redirect("PAginaPrincipalAdmin.aspx?AdminU=" + A);
                }
                else
                {
                    lblError.Text = "Nombre de usuario o contraseña incorrecto";
                    lblError.ForeColor = Color.Red;
                }

            }
            else
            {
                Response.Redirect("PaginaPrincipalConUsuario.aspx?NomU=" + U.Rows[0]["NombreUsuario"].ToString() + "&IdU=" + U.Rows[0]["ID"].ToString());
            }
        }

        protected void lkbCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaCrearUsuario.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreA = txtNombreArticulo.Text.Trim();
            string cat = ddlCategorias.SelectedItem.ToString();
            string precio = txtPrecio.Text.Trim();
            string rangoP = ddlPrecio.SelectedValue;

            DataTable tabla = new DataTable();
            tabla = n_a.filtrarArticulo(nombreA, cat, precio, rangoP);
            lvArticulos.DataSource = tabla;
            lvArticulos.DataBind();
        }

        protected void btnAgregar_Command1(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoAgregar")
            {
                if (id.Contains(e.CommandArgument) == false)
                {
                    id.Add(e.CommandArgument.ToString());
                    Label4.ForeColor = Color.Green;
                    Label4.Text = "Articulo agregado al carrito con exito";
                }
                else
                {
                    Label4.ForeColor = Color.Red;
                    Label4.Text = "Articulo ya agregado al carrito";
                }
            }
        }

        protected void lkbRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaCrearUsuario.aspx");
        }

        protected void lkbCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }
    }
}