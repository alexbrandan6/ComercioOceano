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
    public class N_Categoria
    {
        DAOCategorias dao = new DAOCategorias();

        public DataTable obtenerTablaCategorias()
        {
            return dao.ObtenerTablaCategorias();
        }
        public DataTable obtenerCategoriaId(int idCategoria)
        {
            return dao.obtenerCategoriaId(idCategoria);
        }
        public bool grabarCategoria(Categoria cat)
        {
            if (dao.AgregarCategoria(cat))
            {
                return true;
            }
            else return false;

        }
        public bool actualizarCategoria(Categoria cat)
        {
            if (dao.ActualizarCategoria(cat))
            {
                return true;
            }
            else return false;
        }
        public bool bajalogicaCategoria(Categoria cat)
        {
            if (dao.BajaLogicaCategoria(cat))
            {
                return true;
            }
            else return false;
        }
        public DataTable filtrarCategoria(string nombreC)
        {
            if(nombreC != "")
            {
                string consulta = "Select * from Categorias where DescripcionC = '" + nombreC + "'";
                return dao.filtrarCategoria(consulta);
            }
            else
            {

                return dao.ObtenerTablaCategorias();
            }
        }
    }
    
}
