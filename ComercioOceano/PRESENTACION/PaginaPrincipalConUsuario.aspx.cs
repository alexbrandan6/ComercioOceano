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
    public partial class PaginaPrincipalConUsuario : System.Web.UI.Page
    {
        /*
        N_Usuario n_u = new N_Usuario();
        N_Articulos n_a = new N_Articulos();

        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreU = Request.QueryString["NomU"];
            string idU = Request.QueryString["idU"];
            lblIdUsuario.Text = idU;
            lblNombreUsuario.Text = nombreU;
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

        protected void lkbCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

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

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPerfilUsuario.aspx?NomU=" + lblNombreUsuario.Text);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx?NomU=" + lblNombreUsuario.Text + "&idU=" + lblIdUsuario.Text);
        }

        protected void btnAgregar_Command1(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoAgregar")
            {
                if (PaginaPrincipal.id.Contains(e.CommandArgument) == false)
                {
                    PaginaPrincipal.id.Add(e.CommandArgument.ToString());
                    Label4.ForeColor = Color.Green;
                    Label4.Text = "Articulo agregado al carrito con exito";
                }
                else
                {
                    Label4.ForeColor = Color.Red;
                    Label4.Text = "Articulo ya agregado al carrito";
                }
            }
        }*/
    }
}