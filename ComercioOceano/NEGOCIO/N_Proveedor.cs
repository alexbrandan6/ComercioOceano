using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using ENTIDAD;

namespace NEGOCIO
{
    public class N_Proveedor
    {
        DAOProveedor dao = new DAOProveedor();

        public DataTable obtenerTablaProveedores()
        {
            return dao.obtenerTablaProveedores();
        }
        public bool grabarProveedor(Proveedor pro)
        {
            if (dao.AgregarProveedor(pro))
            {
                return true;
            }
            else return false;

        }
        public bool actualizarProveedor(Proveedor pro)
        {
            if (dao.ActualizarProveedor(pro))
            {
                return true;
            }
            else return false;
        }
        public bool bajaLogicaProveedor(Proveedor pro)
        {
            if (dao.BajaLogicaProveedor(pro))
            {
                return true;
            }
            else return false;
        }
        public DataTable filtrarProveedor(string nombreP)
        {
            if(nombreP != "")
            {
                string consulta = "Select * from Proveedores where DescripcionP like '%" + nombreP + "%'";
                return dao.filtrarProveedor(consulta);
            }
            else
            {
                return dao.obtenerTablaProveedores();
            }
        }
    }
}
