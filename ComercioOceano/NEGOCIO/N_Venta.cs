using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ENTIDAD;
using DAO;

namespace NEGOCIO
{
    public class N_Venta
    {
        DAOVenta d_o = new DAOVenta();

        public bool altaVenta(Venta ven, List<SubVenta> sv)
        {
           return d_o.altaVenta(ven, sv);
        }

        public DataTable obtenerTablaVentas(int idU)
        {
            return d_o.obtenerTablaVentas(idU);
        }
    }
}
