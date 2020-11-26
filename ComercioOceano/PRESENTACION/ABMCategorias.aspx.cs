using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using ENTIDAD;
using System.Data;

namespace PRESENTACION
{
    public partial class ABMCategorias : System.Web.UI.Page
    {
        N_Categoria n_categoria = new N_Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["stUser"] == null)
            {
                Session["stUser"] = null;
                Session["stUserId"] = null;
                Response.Redirect("Login.aspx");
            }
            else
            {
                try
                {
                    if (!IsPostBack)
                    {
                        if (Request.QueryString["idCategoria"] != null)
                        {
                            CargarData(Request.QueryString["idCategoria"]);
                            btnEliminar.Visible = true;
                            btnAgregar.Visible = false;
                            btnActualizar.Visible = true;
                        }
                        else
                        {
                            btnActualizar.Visible = false;
                            btnAgregar.Visible = true;
                            btnEliminar.Visible = false;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void CargarData(String idCategoria)
        {

            DataTable tabla = n_categoria.obtenerCategoriaId(int.Parse(idCategoria));

            txtDescripcion.Text = tabla.Rows[0]["DescripcionC"].ToString();
            ddlEstado.SelectedValue = tabla.Rows[0]["Estado"].ToString();
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarCampos())
                {
                    Categoria cat = new Categoria(txtDescripcion.Text, Boolean.Parse(ddlEstado.Text));
                    if (!n_categoria.grabarCategoria(cat))
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'La Categoria no pudo guardarse.' })</script>";
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'La Categoria se guardo correctamente.' })</script>";
                    }
                }
                else
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Atencion', message: 'Complete todos los campos.' })</script>";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria cat = new Categoria();
                cat.ID = int.Parse(Request.QueryString["idCategoria"]);

                if (n_categoria.bajalogicaCategoria(cat))
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'La Categoria se elimino correctamente.' })</script>";
                }
                else
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'La Categoria no se pudo eliminar.' })</script>";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected bool VerificarCampos()
        {
            if (txtDescripcion.Text != "")
                return true;
            else
                return false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarCampos())
                {
                    Categoria cat = new Categoria(txtDescripcion.Text, Boolean.Parse(ddlEstado.Text));
                    cat.ID = int.Parse(Request.QueryString["idCategoria"]);
                    if (!n_categoria.actualizarCategoria(cat))
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'La Categoria no se pudo actualizar.' })</script>";
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'La Categoria se actualizo correctamente.' })</script>";
                    }
                }
                else
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Atencion', message: 'Complete todos los campos.' })</script>";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}