using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Usuario
    {
        private int id;
        private string apellidos;
        private string nombres;
        private DateTime fechaNac;
        private string genero;
        private int numeroTelefono;
        private string direccion;
        private string contrasenia;
        private string mail;
        private string nombreUsuario;
        private int b_Estado;
        public Usuario()
        {
        }
        public Usuario(string nombres, string apellidos, DateTime fechaNac, string genero, int numeroTelefono, string direccion,
           string mail, string nombreUsuario, string contrasenia, int b_Estado)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.genero = genero;
            this.numeroTelefono = numeroTelefono;
            this.direccion = direccion;
            this.mail = mail;
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
            this.b_Estado = b_Estado;
        }
        // Sets y Gets
        public void setId(int i)
        {
            id = i;
        }
        public int getId()
        {
            return id;
        }
        public void setFechaNac(DateTime fechaNaci)
        {
            fechaNac = fechaNaci;
        }
        public void SetId(int i)
        {
            id = i;
        }
        public void setApellidos(string a)
        {
            apellidos = a;
        }
        public string getApellidos()
        {
            return apellidos;
        }
        public void setNombres(string n)
        {
            nombres = n;
        }
        public string getNombres()
        {
            return nombres;
        }
        public DateTime getFechaNac()
        {
            return fechaNac;
        }
        public int getEstado()
        {
            return b_Estado;
        }
        public void setGenero(string g)
        {
            genero = g;
        }
        public string getGenero()
        {
            return genero;
        }
        public void setNumeroTelefono(int t)
        {
            numeroTelefono = t;
        }
        public int getNumeroTelefono()
        {
            return numeroTelefono;
        }
        public void setDireccion(string d)
        {
            direccion = d;
        }
        public string getDireccion()
        {
            return direccion;
        }
        public void setContrasenia(string c)
        {
            contrasenia = c;
        }
        public string getContrasenia()
        {
            return contrasenia;
        }
        public void setMail(string m)
        {
            mail = m;
        }
        public string getMail()
        {
            return mail;
        }
        public void setNombreUsuario(string n)
        {
            nombreUsuario = n;
        }
        public string getNombreUsuario()
        {
            return nombreUsuario;
        }
        public int Estado
        {
            get { return b_Estado; }
            set { b_Estado = value; }
        }
    }
}
