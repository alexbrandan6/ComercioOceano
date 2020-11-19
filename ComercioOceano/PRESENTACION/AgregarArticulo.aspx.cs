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
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        N_Articulos n_a = new N_Articulos();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = Request.QueryString["AdminU"];
            if (!IsPostBack)
            {
                DataTable tabla = n_a.obtenerTablaCategorias();
                ddl_Categoria.DataSource = tabla;
                ddl_Categoria.DataTextField = "DescripcionC";
                ddl_Categoria.DataValueField = "ID";
                ddl_Categoria.DataBind();

                DataTable tabla2 = n_a.obtenerTablaProveedores();
                ddl_Proveedor.DataSource = tabla2;
                ddl_Proveedor.DataTextField = "DescripcionP";
                ddl_Proveedor.DataValueField = "ID";
                ddl_Proveedor.DataBind();
            }
        }
        
        protected void txt_Agregar_Click(object sender, EventArgs e)
        {
            Articulo art = new Articulo(txt_Descripcion.Text, Byte.Parse(txt_Stock.Text), decimal.Parse(txt_PrecioCompra.Text),
                decimal.Parse(txt_PrecioVenta.Text), int.Parse(ddl_Proveedor.Text), DateTime.Parse(txt_Fecha.Text),
                int.Parse(ddl_Categoria.Text), txt_ImagenUrl.Text, Boolean.Parse(ddl_Estado.Text));
            N_Articulos n_Articulos = new N_Articulos();
            if(!n_Articulos.grabarArticulo(art))
            {
                lbl_Mensaje.Text = "Error en el registro del Articulo";
            }
            else
            {
                lbl_Mensaje.Text = "El Articulo se ha grabado Ok";
            }
                                  
        }

        protected void lkbPaginaPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("PAginaPrincipalAdmin.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void lkbProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void lkbUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PAginaPrincipalAdmin.aspx?AdminU=" + lblAdmin.Text);
        }
    }
}