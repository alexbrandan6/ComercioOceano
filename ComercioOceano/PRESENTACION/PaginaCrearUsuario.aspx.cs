using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using NEGOCIO;
using ENTIDAD;

namespace PRESENTACION
{
    public partial class PaginaCrearUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtAnio.Text == "" || txtApellidos.Text == "" || txtContra.Text == ""
                || txtDia.Text == "" || txtDireccion.Text == "" || txtMail.Text == "" ||
                txtMes.Text == "" || txtNombres.Text == "" || txtNombreUsuario.Text == "" ||
                txtTelefono.Text == "")
            {
                lblError.Text = "COMPLETE TODOS LOS CAMPOS";
            }
            else
            {
                Usuario usr = new Usuario();
                usr.setApellidos(txtApellidos.Text);
                usr.setContrasenia(txtContra.Text);
                //usr.setFechaNac(txtDia.Text, txtMes.Text, txtAnio.Text);
                usr.setDireccion(txtDireccion.Text);
                usr.setGenero(ddlGenero.SelectedItem.ToString());
                usr.setMail(txtMail.Text);
                usr.setNombres(txtNombres.Text);
                usr.setNombreUsuario(txtNombreUsuario.Text);
                usr.setNumeroTelefono(Convert.ToInt32(txtTelefono.Text));

                N_Usuario n_Usuario = new N_Usuario();

                if (n_Usuario.usuarioExiste(usr) == "El nombre de usuario y mail ya existen")
                {
                    lblError.Text = "El nombre de usuario y mail ya existen";
                    lblNombreUsuario.ForeColor = Color.Red;
                    lblMail.ForeColor = Color.Red;

                }
                else
                {
                    if (n_Usuario.usuarioExiste(usr) == "El nombre de usuario ya existe")
                    {
                        lblError.Text = "El nombre de usuario ya existe";
                        lblMail.ForeColor = Color.Black;
                        lblNombreUsuario.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (n_Usuario.usuarioExiste(usr) == "EL mail ya existe")
                        {
                            lblError.Text = "El mail ya existe";
                            lblMail.ForeColor = Color.Red;
                            lblNombreUsuario.ForeColor = Color.Black;
                        }
                        else
                        {
                            n_Usuario.grabarUsuario(usr);
                            DataTable U = new DataTable();
                            U = n_Usuario.buscarUsuario(txtNombreUsuario.Text.Trim(), txtContra.Text.Trim());
                            Response.Redirect("PaginaPrincipalConUsuario.aspx?NomU=" + usr.getNombreUsuario() + "&IdU=" + U.Rows[0]["ID"].ToString());
                        }
                    }
                }

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void lkbPaginaPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}