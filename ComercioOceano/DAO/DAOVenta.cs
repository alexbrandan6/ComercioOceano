using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ENTIDAD;

namespace DAO
{
    public class DAOVenta
    {
        AccesoDatos ds = new AccesoDatos();

        public bool altaVenta(Venta ven, List<SubVenta> sv)
        {
           SqlCommand Comando = new SqlCommand();
           ArmarParametrosVenta(ref Comando, ven);
           int filas = ds.EjecutarProcedimientoAlmacenado(Comando, "SP_AgregaVenta");

            if (filas > 0)
            {
                foreach (SubVenta suv in sv)
                {
                    DataTable tabla = new DataTable();
                    tabla = buscarUltimiIdVenta();
                    suv.setIdVenta(Convert.ToInt32(tabla.Rows[0]["ID"].ToString()));

                    SqlCommand Comando2 = new SqlCommand();
                    ArmarParametrosSubVenta(ref Comando2, suv);
                    filas = ds.EjecutarProcedimientoAlmacenado(Comando2, "SP_AgregarSubVenta");
                }
                if(filas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void ArmarParametrosVenta(ref SqlCommand Comando, Venta ven)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdUsuario", SqlDbType.BigInt);
            SqlParametros.Value = ven.getIdU();
            SqlParametros = Comando.Parameters.Add("@Total", SqlDbType.Money);
            SqlParametros.Value = ven.getTotal();
        }

        private DataTable buscarUltimiIdVenta()
        {
            string consulta = "SELECT TOP 1 ID FROM Venta ORDER BY ID DESC";
            return ds.ObtenerTabla("Venta", consulta);
        }

        private void ArmarParametrosSubVenta(ref SqlCommand Comando, SubVenta sven)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdVenta", SqlDbType.BigInt);
            SqlParametros.Value = sven.getIdVenta();
            SqlParametros = Comando.Parameters.Add("@IdArt", SqlDbType.BigInt);
            SqlParametros.Value = sven.getIdArt();
            SqlParametros = Comando.Parameters.Add("@Cant", SqlDbType.BigInt);
            SqlParametros.Value = sven.getCantidad();
            SqlParametros = Comando.Parameters.Add("@PrecioArt", SqlDbType.Money);
            SqlParametros.Value = sven.getPrecioArt();
        }

        public DataTable obtenerTablaVentas(int idU)
        {
            string consulta = "select V.FechaVenta, V.Total, A.Descripcion, Cantidad, SB.PrecioArticulo, (SB.Cantidad * SB.PrecioArticulo) as 'SubTotal' from Venta as V inner join " +
                    "SubVenta as SB on SB.IdVenta = V.ID inner join Articulos as A on A.ID = SB.IdArticulo where V.ID = SB.IdVenta and V.IdUsuario = " + idU;
            return ds.ObtenerTabla("Venta", consulta);
        }
    }
}
