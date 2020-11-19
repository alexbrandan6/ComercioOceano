using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Categoria
    {
        private int i_ID;
        private String s_Descripcion;
        private Boolean b_Estado;
        public Categoria()
        {
        }
        //SI ES AUTONUMERICO EL ID DEJARLO COMENTADO DE LO CONTRARIO COMENTARLO
        public Categoria(/*int i_ID, */String s_Descripcion, Boolean b_Estado)
        {
            //this.i_ID = i_ID;
            this.s_Descripcion = s_Descripcion;
            this.b_Estado = b_Estado;
        }
        public int ID
        {
            get { return i_ID; }
            set { i_ID = value; }
        }
        public String Descripcion
        {
            get { return s_Descripcion; }
            set { s_Descripcion = value; }
        }
        public Boolean Estado
        {
            get { return b_Estado; }
            set { b_Estado = value; }
        }
    }
}
