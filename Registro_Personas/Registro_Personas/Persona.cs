using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Registro_Personas
{
    class Persona
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string edad { get; set; }
        public string correo { get; set; }
        public ObjectId id { get; set; }

        public Persona() {}

        public Persona (string dni, string nombre, string apellido, string edad, string correo)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.correo = correo;
        }
        public Persona(string dni, string nombre, string apellido, string edad, string correo, ObjectId id)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.correo = correo;
            this.id = id; 
        }
    }
}
