using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Venta
    {
        private Usuario usr = new Usuario();
        private decimal Total;

        public void setIdU(int idU)
        {
            usr.setId(idU);
        }
        public int getIdU()
        {
            return usr.getId();
        }
        public void setTotal(decimal t)
        {
            Total = t;
        }
        public decimal getTotal()
        {
            return Total;
        }
    }
}
