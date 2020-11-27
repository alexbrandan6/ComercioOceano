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
                Session["stUserId"] = null;
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
            txtContra.Text = tabla.Rows[0]["Contrasenia"].ToString();
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
                        txtDireccion.Text, txtEmail.Text, txtNombreUsuario.Text, txtContra.Text, int.Parse(ddlEstado.SelectedValue));
                    N_Usuario n_Usuario = new N_Usuario();

                    if (!n_Usuario.grabarUsuario(usr))
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'El Usuario no pudo guardarse.' })</script>";
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'El Usuario se guardo correctamente.' })</script>";
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
                Usuario usr = new Usuario();
                usr.SetId(int.Parse(Request.QueryString["idUsuario"]));

                if (n_u.bajaLogicaUsuario(usr))
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'El Usuario se elimino correctamente.' })</script>";
                }
                else
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'El Usuario no se pudo eliminar.' })</script>";
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
                        txtDireccion.Text, txtEmail.Text, txtNombreUsuario.Text, txtContra.Text, int.Parse(ddlEstado.SelectedValue));
                    usr.SetId(int.Parse(Request.QueryString["idUsuario"]));
                    N_Usuario n_Usuario = new N_Usuario();

                    if (!n_Usuario.actualizarUsuario(usr))
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'El Usuario no se pudo actualizar.' })</script>";
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'El Usuario se actualizo correctamente.' })</script>";
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