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
    public partial class AgregarCategoria : System.Web.UI.Page
    {
        N_Categoria n_a = new N_Categoria();
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
            tabla = n_a.obtenerTablaCategorias();           
            gv_Categoria.DataSource = tabla;
            gv_Categoria.DataBind();
        }
        protected void btn_AgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria(txt_Descripcion.Text, Boolean.Parse(ddl_Estado.Text));
            N_Categoria n_Categoria = new N_Categoria();
            if (!n_Categoria.grabarCategoria(cat))
            {
                lbl_Mensaje.Text = "Error en el registro del Categoria";
            }
            else
            {
                lbl_Mensaje.Text = "La Categoria se ha grabado Ok";
            }
            cargarGridView();
        }       
        protected void gv_Categoria_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_Categoria.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void gv_Categoria_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_Categoria.EditIndex = -1;
            cargarGridView();
        }

        protected void gv_Categoria_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Categoria cat = new Categoria();
            cat.ID = Convert.ToInt32(((Label)gv_Categoria.Rows[e.RowIndex].FindControl("lbl_eit_ID")).Text);
            cat.Descripcion = ((TextBox)gv_Categoria.Rows[e.RowIndex].FindControl("txt_eit_Descripcion")).Text;
            cat.Estado = Boolean.Parse(((TextBox)gv_Categoria.Rows[e.RowIndex].FindControl("txt_eit_Estado")).Text);
            N_Categoria n_Categoria = new N_Categoria();
            n_Categoria.actualizarCategoria(cat);
            
            gv_Categoria.EditIndex = -1;
            cargarGridView();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipalAdmin.aspx");
        }

        protected void gv_Categoria_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Categoria cat = new Categoria();
            cat.ID = Convert.ToInt32(((Label)gv_Categoria.Rows[e.RowIndex].FindControl("lbl_it_ID")).Text);
            n_a.bajalogicaCategoria(cat);

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

        protected void lkbUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void lkbProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx?AdminU=" + lblAdmin.Text);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string nombreC = txtDescripcionBuscar.Text.Trim();
            DataTable tabla = new DataTable();
            tabla = n_a.filtrarCategoria(nombreC);
            gv_Categoria.DataSource = tabla;
            gv_Categoria.DataBind();
        }
    }
}