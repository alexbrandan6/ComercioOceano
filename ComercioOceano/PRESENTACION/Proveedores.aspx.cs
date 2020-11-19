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
    public partial class Proveedores : System.Web.UI.Page
    {
        N_Proveedor n_proveedor = new N_Proveedor();

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
            tabla = n_proveedor.obtenerTablaProveedores();
           // DataRow row = tabla.Rows[0];
          //  lbl_Data.Text = row["Mail"].ToString(); 
            grid_Proveedor.DataSource = tabla;
            grid_Proveedor.DataBind();
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            Proveedor pro = new Proveedor(txt_Descripcion.Text, txt_Direccion.Text, txt_Telefono.Text, txt_Mail.Text, 
                Boolean.Parse(ddl_Estado.Text));           
            if (!n_proveedor.grabarProveedor(pro))
            {
                lbl_Mensaje.Text = "Error en el registro del Proveedor";
            }
            else
            {
                lbl_Mensaje.Text = "El Proveedor se ha grabado Ok";
            }
            cargarGridView();
        }

        protected void grid_Proveedor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid_Proveedor.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void grid_Proveedor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid_Proveedor.EditIndex = -1;
            cargarGridView();
        }

        protected void grid_Proveedor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Proveedor pro = new Proveedor();
            pro.Id = Convert.ToInt64(((Label)grid_Proveedor.Rows[e.RowIndex].FindControl("lbl_eit_Id")).Text);
            pro.Descripcion = ((TextBox)grid_Proveedor.Rows[e.RowIndex].FindControl("txt_eit_Descripcion")).Text;
            pro.Direccion = ((TextBox)grid_Proveedor.Rows[e.RowIndex].FindControl("txt_eit_Direccion")).Text;
            pro.Telefono = ((TextBox)grid_Proveedor.Rows[e.RowIndex].FindControl("txt_eit_Telefono")).Text;
            pro.Mail = ((TextBox)grid_Proveedor.Rows[e.RowIndex].FindControl("txt_eit_Mail")).Text;
            pro.Estado = Boolean.Parse(((TextBox)grid_Proveedor.Rows[e.RowIndex].FindControl("txt_eit_Estado")).Text);           
            n_proveedor.actualizarProveedor(pro);

            grid_Proveedor.EditIndex = -1;
            cargarGridView();
        }

        protected void grid_Proveedor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Proveedor pro = new Proveedor();
            pro.Id = Convert.ToInt64(((Label)grid_Proveedor.Rows[e.RowIndex].FindControl("lbl_it_Id")).Text);
            n_proveedor.bajaLogicaProveedor(pro);

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

        protected void Button3_Click(object sender, EventArgs e)
        {
            string nombreP = txtBuscarProveedor.Text.Trim();
            DataTable tabla = new DataTable();
            tabla = n_proveedor.filtrarProveedor(nombreP);
            grid_Proveedor.DataSource = tabla;
            grid_Proveedor.DataBind();
        }
    }
}