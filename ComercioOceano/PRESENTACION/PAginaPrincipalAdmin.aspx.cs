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
                DataTable tabla = n_a.obtenerTablaCategorias();
                ddlCategorias.Items.Add("");
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    ddlCategorias.Items.Add(tabla.Rows[i]["DescripcionC"].ToString());
                }


                DataTable tabla2 = new DataTable();
                tabla2 = n_a.obtenerTabla();
                grid_Articulos.DataSource = tabla2;
                grid_Articulos.DataBind();
            }
        }
        public void cargarGridView()
        {
            DataTable tabla = new DataTable();
            tabla = n_a.obtenerTabla();
            grid_Articulos.DataSource = tabla;
            grid_Articulos.DataBind();
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

        protected void grid_Articulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Articulo art = new Articulo();
            art.Id = Convert.ToInt32(((Label)grid_Articulos.Rows[e.RowIndex].FindControl("lbl_it_ID")).Text);
            n_a.bajalogicaArticulo(art);

            cargarGridView();
        }

        protected void grid_Articulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid_Articulos.EditIndex = e.NewEditIndex;

            cargarGridView();
        }

        protected void grid_Articulos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Articulo art = new Articulo();
            art.Id = Convert.ToInt32(((Label)grid_Articulos.Rows[e.RowIndex].FindControl("lbl_eit_ID")).Text);
            art.Descripcion = ((TextBox)grid_Articulos.Rows[e.RowIndex].FindControl("txt_eit_Descripcion")).Text;
            art.Stock = Byte.Parse(((TextBox)grid_Articulos.Rows[e.RowIndex].FindControl("txt_eit_Stock")).Text);
            art.PrecioCompra = Decimal.Parse(((TextBox)grid_Articulos.Rows[e.RowIndex].FindControl("txt_eit_PrecioCompra")).Text);
            art.PrecioVenta = Decimal.Parse(((TextBox)grid_Articulos.Rows[e.RowIndex].FindControl("txt_eit_PrecioVenta")).Text);
            art.IdProveedor = Convert.ToInt32(((DropDownList)grid_Articulos.Rows[e.RowIndex].FindControl("ddl_eit_Proveedor")).Text);
            art.FechaVencimiento = DateTime.Parse(((TextBox)grid_Articulos.Rows[e.RowIndex].FindControl("txt_eit_FechaVencimiento")).Text);
            art.IdCategoria = Convert.ToInt32(((DropDownList)grid_Articulos.Rows[e.RowIndex].FindControl("ddl_eit_Categoria")).Text);
            art.ImagenUrl = ((TextBox)grid_Articulos.Rows[e.RowIndex].FindControl("txt_eit_ImagenUrl")).Text;
            art.Estado = Boolean.Parse(((TextBox)grid_Articulos.Rows[e.RowIndex].FindControl("txt_eit_Estado")).Text);
            n_a.actualizarArticulo(art);

            grid_Articulos.EditIndex = -1;
            cargarGridView();
        }

        protected void grid_Articulos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid_Articulos.EditIndex = -1;

            cargarGridView();
        }

        protected void lkbArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarArticulo.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void lkbProveedores_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void lkbCategorias_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void lkbUsuarios_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx?");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreA = txtNombreArticulo.Text.Trim();
            string cat = ddlCategorias.SelectedItem.ToString();
            string precio = txtPrecio.Text.Trim();
            string rangoP = ddlPrecio.SelectedValue;

            DataTable tabla = new DataTable();
            tabla = n_a.filtrarArticuloAdmin(nombreA, cat, precio, rangoP);
            grid_Articulos.DataSource = tabla;
            grid_Articulos.DataBind();
        }
    }
}