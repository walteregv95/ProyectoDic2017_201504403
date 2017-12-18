using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _EDD_Practica1
{
   public class Usuarios
    {

       public string nombre { get; set; }
       public string contraseña { get; set; }
       public Colas cola { get; set; }
       public Pilas pila { get; set; }

        public Usuarios(string nombre, string contraseña, Colas cola, Pilas pila)
        {
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.cola = cola;
            this.pila = pila;
        }

    }
}
