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
                Response.Redirect("Login.aspx");
            }
            else
            {
                try
                {
                    if (Request.QueryString["idCategoria"] != null)
                    {
                        CargarData(Request.QueryString["idCategoria"]);
                        btnEliminar.Visible = true;
                    }
                    else
                    {
                        btnEliminar.Visible = false;
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

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
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
                        lblMensaje.Text = "";
                        lblMensaje.Text = "Error al guardar el Proveedor!";
                        lblMensaje.Attributes.Remove("class");
                        lblMensaje.Attributes.Add("class", "alert alert-danger");
                        lblMensaje.Visible = true;
                    }
                    else
                    {
                        lblMensaje.Text = "";
                        lblMensaje.Text = "El Proveedor se ha guardado con exito!";
                        lblMensaje.Attributes.Remove("class");
                        lblMensaje.Attributes.Add("class", "alert alert-success");
                        lblMensaje.Visible = true;
                    }
                }
                else
                {
                    lblMensaje.Text = "";
                    lblMensaje.Text = "Complete todos los campos!";
                    lblMensaje.Attributes.Remove("class");
                    lblMensaje.Attributes.Add("class", "alert alert-warning");
                    lblMensaje.Visible = true;
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
                    lblMensaje.Text = "";
                    lblMensaje.Text = "El Proveedor se ha eliminado con exito!";
                    lblMensaje.Attributes.Remove("class");
                    lblMensaje.Attributes.Add("class", "alert alert-success");
                    lblMensaje.Visible = true;
                }
                else
                {
                    lblMensaje.Text = "";
                    lblMensaje.Text = "Error al eliminar el Proveedor!";
                    lblMensaje.Attributes.Remove("class");
                    lblMensaje.Attributes.Add("class", "alert alert-danger");
                    lblMensaje.Visible = true;
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
    }
}