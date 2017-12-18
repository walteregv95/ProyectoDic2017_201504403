using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _EDD_Practica1
{
    public class Valor
    {
        public string pos_x { get; set; }
        public string pos_y { get; set; }
        public string dato { get; set; }
    }

    public class Valores
    {
        public List<Valor> valor { get; set; }
    }

    public class Matriz
    {
        public string size_x { get; set; }
        public string size_y { get; set; }
        public Valores valores { get; set; }
    }

    public class Matrices
    {
        public List<Matriz> matriz { get; set; }
    }

    public class Pila
    {
        public Matrices matrices { get; set; }
    }

    public class Valor2
    {
        public string pos_x { get; set; }
        public string pos_y { get; set; }
        public string dato { get; set; }
    }

    public class Valores2
    {
        public List<Valor2> valor { get; set; }
    }

    public class Matriz2
    {
        public string size_x { get; set; }
        public string size_y { get; set; }
        public Valores2 valores { get; set; }
    }

    public class Matrices2
    {
        public List<Matriz2> matriz { get; set; }
    }

    public class Cola
    {
        public Matrices2 matrices { get; set; }
    }

    public class Archivo
    {
        public Pila pila { get; set; }
        public Cola cola { get; set; }
    }

    public class Json
    {
        public Archivo archivo { get; set; }
    }
}
