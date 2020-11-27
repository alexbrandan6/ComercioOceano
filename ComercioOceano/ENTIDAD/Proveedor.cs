using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Proveedor
    {
        private Int64 i_Id;
        private String s_Descripcion;
        private String s_Direccion;
        private String s_Telefono;
        private String s_Mail;
        private int b_Estado;
        public Proveedor()
        {
        }
        public Proveedor(String s_Descripcion, String s_Direccion, String s_Telefono, String s_Mail, int b_Estado)
        {
            this.s_Descripcion = s_Descripcion;
            this.s_Direccion = s_Direccion;
            this.s_Telefono = s_Telefono;
            this.s_Mail = s_Mail;
            this.b_Estado = b_Estado;
        }
        public Int64 Id
        {
            get { return i_Id; }
            set { i_Id = value; }
        }
        public String Descripcion
        {
            get { return s_Descripcion; }
            set { s_Descripcion = value; }
        }
        public String Direccion
        {
            get { return s_Direccion; }
            set { s_Direccion = value; }
        }
        public String Telefono
        {
            get { return s_Telefono; }
            set { s_Telefono = value; }
        }
        public String Mail
        {
            get { return s_Mail; }
            set { s_Mail = value; }
        }
        public int Estado
        {
            get { return b_Estado; }
            set { b_Estado = value; }
        }
        
    }
}
