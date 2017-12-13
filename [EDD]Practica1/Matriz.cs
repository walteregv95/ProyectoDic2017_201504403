using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _EDD_Practica1
{
    class Matriz
    {
        public string nombre;

        public Matriz(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
          
    }
}
