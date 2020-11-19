using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class SubVenta
    {
        private int IDVenta;
        private int IdArticulo;
        private decimal Cantidad;
        private decimal PrecioArticulo;
        private decimal subTotal;

        public void setCantidad(decimal c)
        {
            Cantidad = c;
        }
        public decimal getCantidad()
        {
            return Cantidad;
        }
        public void setSubTotal(decimal st)
        {
            subTotal = st;
        }
        public decimal getSubTotal()
        {
            return subTotal;
        }
        public int getIdArt()
        {
            return IdArticulo;
        }
        public void setIdArt(int i)
        {
            IdArticulo = i;
        }
        public void setIdVenta(int i)
        {
            IDVenta = i;
        }
        public int getIdVenta()
        {
            return IDVenta;
        }
        public void setPrecioArt(decimal pre)
        {
            PrecioArticulo = pre;
        }
        public decimal getPrecioArt()
        {
            return PrecioArticulo;
        }
    }
}
