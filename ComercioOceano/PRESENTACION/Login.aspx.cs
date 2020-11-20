using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;

namespace PRESENTACION
{
    public partial class Login : System.Web.UI.Page
    {
        N_Usuario n_u = new N_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["stUser"] = null;
                alertMensaje.Attributes.Remove("class");
                lblMensaje.Text = "";
                alertMensaje.Visible = false;
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if(txtNombreUsuario.Text != "" && txtContra.Text != "")
            {
                DataTable U = new DataTable();
                U = n_u.buscarUsuario(txtNombreUsuario.Text.Trim(), txtContra.Text.Trim());
                string A = n_u.buscarAdmin(txtNombreUsuario.Text.Trim(), txtContra.Text.Trim());

                if (U == null)
                {
                    if (A != "0")
                    {
                        Session["stUser"] = txtNombreUsuario.Text.Trim();
                        Response.Redirect("PAginaPrincipalAdmin.aspx?AdminU=" + A);
                    }
                    else
                    {
                        alertMensaje.Attributes.Remove("class");
                        alertMensaje.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                        lblMensaje.Text = "Credenciales invalidas!";
                        alertMensaje.Visible = true;
                    }

                }
                else
                {
                    Response.Redirect("PaginaPrincipalConUsuario.aspx?NomU=" + U.Rows[0]["NombreUsuario"].ToString() + "&IdU=" + U.Rows[0]["ID"].ToString());
                }
            }
            else
            {
                alertMensaje.Attributes.Remove("class");
                alertMensaje.Attributes.Add("class", "alert alert-warning alert-dismissible fade show");
                lblMensaje.Text = "Complete los campos!";
                alertMensaje.Visible = true;
            }
            
        }
    }
}