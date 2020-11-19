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

                lbl_Mensaje.Text = "";
                lbl_Mensaje.Visible = false;
            }
        }
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txt_Descripcion.Text != "" && txt_Fecha.Text != "" && txt_ImagenUrl.Text != "" && txt_PrecioCompra.Text != "" && txt_PrecioVenta.Text != "" && txt_Stock.Text != "")
            {
                Articulo art = new Articulo(txt_Descripcion.Text, Byte.Parse(txt_Stock.Text), decimal.Parse(txt_PrecioCompra.Text),
                decimal.Parse(txt_PrecioVenta.Text), int.Parse(ddl_Proveedor.Text), DateTime.Parse(txt_Fecha.Text),
                int.Parse(ddl_Categoria.Text), txt_ImagenUrl.Text, Boolean.Parse(ddl_Estado.Text));
                N_Articulos n_Articulos = new N_Articulos();

                if (!n_Articulos.grabarArticulo(art))
                {
                    lbl_Mensaje.Text = "";
                    lbl_Mensaje.Text = "Error! en el guardado del Articulo";
                    lbl_Mensaje.Attributes.Remove("class");
                    lbl_Mensaje.Attributes.Add("class", "alert alert-danger");
                    lbl_Mensaje.Visible = true;
                }
                else
                {
                    lbl_Mensaje.Text = "";
                    lbl_Mensaje.Text = "El Articulo se ha guardado con exito!";
                    lbl_Mensaje.Attributes.Remove("class");
                    lbl_Mensaje.Attributes.Add("class", "alert alert-success");
                    lbl_Mensaje.Visible = true;
                }
            }
            else
            {
                lbl_Mensaje.Text = "";
                lbl_Mensaje.Text = "Complete todos los campos";
                lbl_Mensaje.Attributes.Remove("class");
                lbl_Mensaje.Attributes.Add("class", "alert alert-warning");
                lbl_Mensaje.Visible = true;
            }
                
        }

        protected void btnPaginaPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("PAginaPrincipalAdmin.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void btnPaginaProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void btnPaginaUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PAginaPrincipalAdmin.aspx?AdminU=" + lblAdmin.Text);
        }
    }
}