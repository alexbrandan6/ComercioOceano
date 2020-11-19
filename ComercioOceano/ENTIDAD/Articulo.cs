using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Articulo
    {
        private int i_Id;
        private String s_Descripcion;
        private Byte b_Stock;
        private Decimal d_PrecioCompra;
        private Decimal d_PrecioVenta;
        private int i_IdProveedor;
        private DateTime dt_FechaVencimiento;
        private int i_IdCategoria;
        private String s_ImagenUrl;
        private Boolean b_Estado;
        public Articulo()
        {
        }
        public Articulo(/*int i_Id,*/ String s_Descripcion, Byte b_Stock, Decimal d_PrecioCompra, Decimal d_PrecioVenta,
            int i_IdProveedor, DateTime dt_FechaVencimiento, int i_IdCategoria, String s_ImagenUrl, Boolean b_Estado)
        {
            //this.i_Id = i_Id;
            this.s_Descripcion = s_Descripcion;
            this.b_Stock = b_Stock;
            this.d_PrecioCompra = d_PrecioCompra;
            this.d_PrecioVenta = d_PrecioVenta;
            this.i_IdProveedor = i_IdProveedor;
            this.dt_FechaVencimiento = dt_FechaVencimiento;
            this.i_IdCategoria = i_IdCategoria;
            this.s_ImagenUrl = s_ImagenUrl;
            this.b_Estado = b_Estado;
        }
        public int Id
        {
            get { return i_Id; }
            set { i_Id = value; }
        }
        public String Descripcion
        {
            get { return s_Descripcion; }
            set { s_Descripcion = value; }
        }
        public Byte Stock
        {
            get { return b_Stock; }
            set { b_Stock = value; }
        }
        public Decimal PrecioCompra
        {
            get { return d_PrecioCompra; }
            set { d_PrecioCompra = value; }
        }
        public Decimal PrecioVenta
        {
            get { return d_PrecioVenta; }
            set { d_PrecioVenta = value; }
        }
        public int IdProveedor
        {
            get { return i_IdProveedor; }
            set { i_IdProveedor = value; }
        }
        public DateTime FechaVencimiento
        {
            get { return dt_FechaVencimiento; }
            set { dt_FechaVencimiento = value; }
        }
        public int IdCategoria
        {
            get { return i_IdCategoria; }
            set { i_IdCategoria = value; }
        }
        public String ImagenUrl
        {
            get { return s_ImagenUrl; }
            set { s_ImagenUrl = value; }
        }
        public Boolean Estado
        {
            get { return b_Estado; }
            set { b_Estado = value; }
        }
    }
    


}
