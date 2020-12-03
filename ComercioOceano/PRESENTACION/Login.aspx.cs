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
                Session["stUserId"] = null;
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if(txtNombreUsuario.Text != "" && txtContra.Text != "")
            {
                DataTable U = new DataTable();
                DataTable dtAdmin = new DataTable();
                U = n_u.buscarUsuario(txtNombreUsuario.Text.Trim(), txtContra.Text.Trim());
                dtAdmin = n_u.buscarAdmin(txtNombreUsuario.Text.Trim(), txtContra.Text.Trim());

                if (U == null)
                {
                    if (dtAdmin != null)
                    {
                        Session["stUser"] = null;
                        Session["stUserId"] = null;
                        Session["stUser"] = dtAdmin.Rows[0]["NombreUsuario"].ToString();
                        Session["stUserId"] = dtAdmin.Rows[0]["ID"].ToString();
                        Response.Redirect("PAginaPrincipalAdmin.aspx");
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'Credenciales invalidas.' })</script>";
                    }

                }
                else
                {
                    Session["stUser"] = null;
                    Session["stUserId"] = null;
                    Session["stUser"] = U.Rows[0]["NombreUsuario"].ToString();
                    Session["stUserId"] = U.Rows[0]["ID"].ToString();
                    Response.Redirect("PaginaPrincipalUsuario.aspx");
                }
            }
            else
            {
                lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Atencion', message: 'Complete todos los campos.' })</script>";
            }
            
        }
    }
}