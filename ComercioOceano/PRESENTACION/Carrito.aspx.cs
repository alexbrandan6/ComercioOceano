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
    public partial class Carrito : System.Web.UI.Page
    {
        N_Articulos n_a = new N_Articulos();
        N_Venta n_v = new N_Venta();

        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreU = Request.QueryString["NomU"];
            string idU = Request.QueryString["idU"];
            lblUsuario.Text = nombreU;
            lblIdUsuario.Text = idU;

            if (!IsPostBack)
            {
                if (PaginaPrincipal.id.Count > 0)
                {
                    gvSubVenta.DataSource = n_a.obtenerCarrito(PaginaPrincipal.id);
                    gvSubVenta.DataBind();
                }
            }
        }

        protected void btnCalcularPrecio_Click(object sender, EventArgs e)
        {
            if (gvSubVenta.Rows.Count > 0)
            {
                int contador = 0;
                lblError.Text = "";
                for (int i = 0; i < gvSubVenta.Rows.Count; i++)
                {
                    if (((TextBox)gvSubVenta.Rows[i].FindControl("TextBox1")).Text == "")
                    {
                        contador++;
                    }
                }

                if (contador > 0)
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Complete todas las cantidades";
                }
                else
                {
                    cargarSubtotal();
                }
            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "No hay articulos en el carrito";
            }




        }

        public void cargarSubtotal()
        {
            string precio;
            string cantidad;
            decimal total;
            decimal totalT = 0;

            for (int i = 0; i < gvSubVenta.Rows.Count; i++)
            {
                lblError.ForeColor = Color.Black;
                lblError.Text = "";
                precio = ((Label)gvSubVenta.Rows[i].FindControl("Label3")).Text;
                cantidad = ((TextBox)gvSubVenta.Rows[i].FindControl("TextBox1")).Text;
                total = Convert.ToDecimal(precio) * Convert.ToDecimal(cantidad);
                totalT += total;
                gvSubVenta.Rows[i].Cells[4].Text = total.ToString();
            }
            lbltotal.Text = totalT.ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (lblUsuario.Text != "")
            {
                Response.Redirect("PaginaPrincipalConUsuario.aspx?NomU=" + lblUsuario.Text + "&idU=" + lblIdUsuario.Text);
            }
            else
            {
                Response.Redirect("PaginaPrincipal.aspx");
            }
        }

        protected void gvSubVenta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string descripcion = ((Label)gvSubVenta.Rows[e.RowIndex].FindControl("Label1")).Text;
            List<string> cantidad = new List<string>();
            cantidad = guardarCantidad(descripcion);

            DataTable tabla = new DataTable();
            tabla = n_a.obtenerId(descripcion);

            PaginaPrincipal.id.Remove(tabla.Rows[0].Field<Int64>("ID").ToString());

            gvSubVenta.DataSource = n_a.obtenerCarrito(PaginaPrincipal.id);
            gvSubVenta.DataBind();

            cargarCantidad(cantidad);
            if (gvSubVenta.Rows.Count > 0)
            {
                int contador = 0;
                lblError.Text = "";
                for (int i = 0; i < gvSubVenta.Rows.Count; i++)
                {
                    if (((TextBox)gvSubVenta.Rows[i].FindControl("TextBox1")).Text == "")
                    {
                        contador++;
                    }
                }

                if (contador > 0)
                {
                    //cargarSubtotal();
                }
            }
        }

        public List<string> guardarCantidad(string descripcion)
        {
            List<string> cantidad = new List<string>();

            for (int i = 0; i < gvSubVenta.Rows.Count; i++)
            {
                if (((Label)gvSubVenta.Rows[i].FindControl("Label1")).Text != descripcion)
                {
                    cantidad.Add(((TextBox)gvSubVenta.Rows[i].FindControl("TextBox1")).Text);
                }
            }

            return cantidad;
        }

        public void cargarCantidad(List<string> cantidad)
        {
            for (int i = 0; i < gvSubVenta.Rows.Count; i++)
            {
                ((TextBox)gvSubVenta.Rows[i].FindControl("TextBox1")).Text = cantidad[i];
            }
        }

        protected void btnRealizarCompra_Click(object sender, EventArgs e)
        {
            if (lblUsuario.Text != "")
            {
                if (gvSubVenta.Rows.Count > 0)
                {
                    int contador = 0;
                    lblError.Text = "";
                    for (int i = 0; i < gvSubVenta.Rows.Count; i++)
                    {
                        if (((TextBox)gvSubVenta.Rows[i].FindControl("TextBox1")).Text == "")
                        {
                            contador++;
                        }
                    }

                    if (contador > 0)
                    {
                        lblError.ForeColor = Color.Red;
                        lblError.Text = "Complete todas las cantidades";
                    }
                    else
                    {
                        Venta ven = new Venta();
                        SubVenta sub = new SubVenta();
                        ven.setIdU(Convert.ToInt32(lblIdUsuario.Text));
                        ven.setTotal(Convert.ToDecimal(lbltotal.Text));
                        List<SubVenta> sv = new List<SubVenta>();
                        for (int i = 0; i < gvSubVenta.Rows.Count; i++)
                        {
                            DataTable tabla = new DataTable();
                            tabla = n_a.obtenerId(((Label)gvSubVenta.Rows[i].FindControl("Label1")).Text);
                            sub.setCantidad(Convert.ToDecimal(((TextBox)gvSubVenta.Rows[i].FindControl("TextBox1")).Text));
                            sub.setIdArt(Convert.ToInt32(tabla.Rows[0]["ID"].ToString()));
                            sub.setSubTotal(Convert.ToDecimal(gvSubVenta.Rows[i].Cells[4].Text));
                            sub.setPrecioArt(Convert.ToDecimal(((Label)gvSubVenta.Rows[i].FindControl("Label3")).Text));
                            sv.Add(sub);
                        }
                        if(n_v.altaVenta(ven, sv) == true)
                        {
                            lblError.ForeColor = Color.Green;
                            lblError.Text = "Compra realizada con exito";
                        }
                        else
                        {
                            lblError.ForeColor = Color.Red;
                            lblError.Text = "No se ha realizado la compra";
                        }
                    }
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "No hay articulos en el carrito";
                }
            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Inicie sesion para completar la compra";
            }
        }
    }
}