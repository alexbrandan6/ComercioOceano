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
    public partial class ABMProveedores : System.Web.UI.Page
    {
        N_Proveedor n_proveedor = new N_Proveedor();
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
                        if (Request.QueryString["idProveedor"] != null)
                        {
                            CargarData(Request.QueryString["idProveedor"]);
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

        private void CargarData(String idArticulo)
        {

            DataTable tabla = n_proveedor.obtenerProveedorId(int.Parse(idArticulo));

            txtDescripcion.Text = tabla.Rows[0]["DescripcionP"].ToString();
            txtDireccion.Text = tabla.Rows[0]["Direccion"].ToString();
            txtTelefono.Text = tabla.Rows[0]["Telefono"].ToString();
            txtMail.Text = tabla.Rows[0]["Mail"].ToString();
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
                    Proveedor pro = new Proveedor(txtDescripcion.Text, txtDireccion.Text, txtTelefono.Text, txtMail.Text,
                                    int.Parse(ddlEstado.Text));
                    if (!n_proveedor.grabarProveedor(pro))
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'El Proveedor no pudo guardarse.' })</script>";
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'El Proveedor se guardo correctamente.' })</script>";
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
                Proveedor pro = new Proveedor();
                pro.Id = int.Parse(Request.QueryString["idProveedor"]);

                if (n_proveedor.bajaLogicaProveedor(pro))
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'El Proveedor se elimino correctamente.' })</script>";
                }
                else
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'El Proveedor no se pudo eliminar.' })</script>";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected bool VerificarCampos()
        {
            if (txtDescripcion.Text != "" && txtDireccion.Text != "" && txtMail.Text != "" && txtTelefono.Text != "")
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
                    Proveedor pro = new Proveedor(txtDescripcion.Text, txtDireccion.Text, txtTelefono.Text, txtMail.Text,
                                    int.Parse(ddlEstado.Text));
                    pro.Id = int.Parse(Request.QueryString["idProveedor"]);
                    if (!n_proveedor.actualizarProveedor(pro))
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'El Proveedor no se pudo actualizar.' })</script>";
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'El Proveedor se actualizo correctamente.' })</script>";
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