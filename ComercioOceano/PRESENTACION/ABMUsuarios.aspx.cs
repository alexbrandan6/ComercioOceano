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
    public partial class ABMUsuarios : System.Web.UI.Page
    {
        N_Usuario n_u = new N_Usuario();
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
                    if (!IsPostBack)
                    {
                        if (Request.QueryString["idUsuario"] != null)
                        {
                            CargarData(Request.QueryString["idUsuario"]);
                            btnAgregar.Visible = false;
                            btnActualizar.Visible = true;
                            btnEliminar.Visible = true;
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

        private void CargarData(String idUsuario)
        {

            DataTable tabla = n_u.obtenerUsuarioId(int.Parse(idUsuario));

            txtApellidos.Text = tabla.Rows[0]["Apellidos"].ToString();
            txtNombres.Text = tabla.Rows[0]["Nombres"].ToString();
            txtTelefono.Text = tabla.Rows[0]["Telefono"].ToString();
            txtNombreUsuario.Text = tabla.Rows[0]["NombreUsuario"].ToString();
            ddlEstado.SelectedValue = tabla.Rows[0]["Estado"].ToString();
            ddlGenero.SelectedValue = tabla.Rows[0]["Genero"].ToString();
            txtEmail.Text = tabla.Rows[0]["Mail"].ToString();
            txtFechaNacimiento.Text = FechaDDMMAAAA(tabla.Rows[0]["fechaNac"].ToString());
            ddlEstado.SelectedValue = tabla.Rows[0]["Estado"].ToString();
            txtDireccion.Text = tabla.Rows[0]["Direccion"].ToString();
        }
        private string FechaDDMMAAAA(string stFEcha)
        {
            string año;
            string mes;
            string dia;
            string fechaDDMMAAAA;
            dia = stFEcha.Substring(0, 2);
            mes = stFEcha.Substring(3, 2);
            año = stFEcha.Substring(6, 4);
            fechaDDMMAAAA = dia + "/" + mes + "/" + año;
            return fechaDDMMAAAA;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarCampos())
                {
                    Usuario usr = new Usuario(txtNombres.Text, txtApellidos.Text, DateTime.Parse(txtFechaNacimiento.Text), ddlGenero.SelectedValue, int.Parse(txtTelefono.Text),
                        txtDireccion.Text, txtEmail.Text, txtNombreUsuario.Text, txtContra.Text);
                    N_Usuario n_Usuario = new N_Usuario();

                    if (!n_Usuario.grabarUsuario(usr))
                    {
                        lblMensaje.Text = "";
                        lblMensaje.Text = "Error al guardar el Usuario!";
                        lblMensaje.Attributes.Remove("class");
                        lblMensaje.Attributes.Add("class", "alert alert-danger");
                        lblMensaje.Visible = true;
                    }
                    else
                    {
                        lblMensaje.Text = "";
                        lblMensaje.Text = "El Usuario se ha guardado con exito!";
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
                Usuario usr = new Usuario();
                usr.SetId(int.Parse(Request.QueryString["idUsuario"]));

                if (n_u.bajaLogicaUsuario(usr))
                {
                    lblMensaje.Text = "";
                    lblMensaje.Text = "El Usuario se ha eliminado con exito!";
                    lblMensaje.Attributes.Remove("class");
                    lblMensaje.Attributes.Add("class", "alert alert-success");
                    lblMensaje.Visible = true;
                }
                else
                {
                    lblMensaje.Text = "";
                    lblMensaje.Text = "Error al eliminar el Usuario!";
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
            if (txtApellidos.Text != "" && txtContra.Text != "" && txtDireccion.Text != "" && txtEmail.Text != "" && txtFechaNacimiento.Text != "" && txtNombres.Text != ""
                && txtNombreUsuario.Text != "" && txtTelefono.Text != "")
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
                    Usuario usr = new Usuario(txtNombres.Text, txtApellidos.Text, DateTime.Parse(txtFechaNacimiento.Text), ddlGenero.SelectedValue, int.Parse(txtTelefono.Text),
                        txtDireccion.Text, txtEmail.Text, txtNombreUsuario.Text, txtContra.Text);
                    usr.SetId(int.Parse(Request.QueryString["idUsuario"]));
                    N_Usuario n_Usuario = new N_Usuario();

                    if (!n_Usuario.actualizarUsuario(usr))
                    {
                        lblMensaje.Text = "";
                        lblMensaje.Text = "Error al actualizar el Usuario!";
                        lblMensaje.Attributes.Remove("class");
                        lblMensaje.Attributes.Add("class", "alert alert-danger");
                        lblMensaje.Visible = true;
                    }
                    else
                    {
                        lblMensaje.Text = "";
                        lblMensaje.Text = "El Usuario se ha actualizado con exito!";
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
    }
}