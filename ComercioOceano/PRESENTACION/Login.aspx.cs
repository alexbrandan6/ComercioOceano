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
                        Response.Redirect("PAginaPrincipalAdmin.aspx");
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'Credenciales invalidas.' })</script>";
                    }

                }
                else
                {
                    Response.Redirect("PaginaPrincipalConUsuario.aspx?NomU=" + U.Rows[0]["NombreUsuario"].ToString() + "&IdU=" + U.Rows[0]["ID"].ToString());
                }
            }
            else
            {
                lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Atencion', message: 'Complete todos los campos.' })</script>";
            }
            
        }
    }
}