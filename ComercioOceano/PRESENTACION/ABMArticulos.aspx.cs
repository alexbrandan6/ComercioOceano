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
    public partial class ABMArticulos : System.Web.UI.Page
    {
        N_Articulos n_a = new N_Articulos();
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
                        if (Request.QueryString["idArticulo"] != null)
                        {
                            CargarData(Request.QueryString["idArticulo"]);
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

        private void CargarData(String idArticulo)
        {
            CargarDdls();

            DataTable tabla = n_a.obtenerArticuloId(int.Parse(idArticulo));

            txtDescripcion.Text = tabla.Rows[0]["Descripcion"].ToString();
            txtStock.Text = tabla.Rows[0]["Stock"].ToString();
            txtPrecioCompra.Text = tabla.Rows[0]["PrecioCompra"].ToString();
            txtPrecioVenta.Text = tabla.Rows[0]["PrecioVenta"].ToString();
            ddlProveedor.SelectedValue = tabla.Rows[0]["IdProveedor"].ToString();
            ddlCategoria.SelectedValue = tabla.Rows[0]["IdCategoria"].ToString();
            txtImagenUrl.Text = tabla.Rows[0]["ImagenUrl"].ToString();
            txtFechaVencimiento.Text = FechaDDMMAAAA(tabla.Rows[0]["FechaVencimiento"].ToString());
            ddlEstado.SelectedValue = tabla.Rows[0]["Estado"].ToString();
        }

        private void CargarDdls()
        {
            DataTable tabla = n_a.obtenerTablaCategorias();
            ddlCategoria.DataSource = tabla;
            ddlCategoria.DataTextField = "DescripcionC";
            ddlCategoria.DataValueField = "ID";
            ddlCategoria.DataBind();

            tabla.Clear();

            tabla = n_a.obtenerTablaProveedores();
            ddlProveedor.DataSource = tabla;
            ddlProveedor.DataTextField = "DescripcionP";
            ddlProveedor.DataValueField = "ID";
            ddlProveedor.DataBind();
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
                    Articulo art = new Articulo(txtDescripcion.Text, Byte.Parse(txtStock.Text), decimal.Parse(txtPrecioCompra.Text),
                    decimal.Parse(txtPrecioVenta.Text), int.Parse(ddlProveedor.Text), DateTime.Parse(txtFechaVencimiento.Text),
                    int.Parse(ddlCategoria.Text), txtImagenUrl.Text, int.Parse(ddlEstado.Text));
                    N_Articulos n_Articulos = new N_Articulos();

                    if (!n_Articulos.grabarArticulo(art))
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'El Articulo no pudo guardarse.' })</script>";
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'El Articulo se guardo correctamente.' })</script>";
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
                Articulo art = new Articulo();
                art.Id = int.Parse(Request.QueryString["idArticulo"]);

                if (n_a.bajalogicaArticulo(art))
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'El Articulo se elimino correctamente.' })</script>";
                }
                else
                {
                    lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'El Articulo no se pudo eliminar.' })</script>";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected bool VerificarCampos()
        {
            if (txtDescripcion.Text != "" && txtFechaVencimiento.Text != "" && txtImagenUrl.Text != "" && txtPrecioCompra.Text != "" && txtPrecioVenta.Text != "" && txtStock.Text != "")
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
                    Articulo art = new Articulo(txtDescripcion.Text, Byte.Parse(txtStock.Text), decimal.Parse(txtPrecioCompra.Text),
                    decimal.Parse(txtPrecioVenta.Text), int.Parse(ddlProveedor.Text), DateTime.Parse(txtFechaVencimiento.Text),
                    int.Parse(ddlCategoria.Text), txtImagenUrl.Text, int.Parse(ddlEstado.Text));
                    art.Id = int.Parse(Request.QueryString["idArticulo"]);
                    N_Articulos n_Articulos = new N_Articulos();

                    if (!n_Articulos.actualizarArticulo(art))
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Error', message: 'El Articulo no se pudo actualizar.' })</script>";
                    }
                    else
                    {
                        lblAlert.Text = "<script type='text/javascript'>$('#myConfirm').simpleAlert({ title: 'Exito', message: 'El Articulo se actualizo correctamente.' })</script>";
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