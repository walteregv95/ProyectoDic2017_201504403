using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _EDD_Practica1
{
    class Pilas
    {
        public class Nodo
        {
            public Matriz matriz;
            public Nodo siguiente = null;

            public Nodo(Matriz matriz)
            {
                this.matriz = matriz;
            }

            

        }

        public  Nodo cima = null;

        public void Push(Matriz matriz)
        {
            Nodo nodo = new Nodo(matriz);
            nodo.siguiente = cima;
            cima = nodo;


        }

        public Nodo Pop()
        {
            if (cima != null)
            {
                Nodo nodo = cima;                
                cima = cima.siguiente;
                return nodo;
            }
            else
            {
                return null;
            }
            

        }

       
       
         
    }
}
