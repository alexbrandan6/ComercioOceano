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
        private string fechaNac;
        private string genero;
        private int numeroTelefono;
        private string direccion;
        private string contrasenia;
        private string mail;
        private string nombreUsuario;
        public Usuario()
        {
        }
        public Usuario(string nombres, string apellidos, string fechaNac, string genero, int numeroTelefono, string direccion,
           string mail, string nombreUsuario, string contrasenia)
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
        public void setFechaNac(string d, string m, string a)
        {
            fechaNac = d + "-" + m + "-" + a;
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
        public void setFechaNac(string fecha)
        {
            fechaNac = fecha;
        }
        public string getFechaNac()
        {
            return fechaNac;
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
    }
}
