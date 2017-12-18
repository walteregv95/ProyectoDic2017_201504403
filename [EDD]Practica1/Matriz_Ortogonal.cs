using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _EDD_Practica1
{
    public class Matriz_Ortogonal
    {
        public class Nodo
        {
           public Nodo arriba = null;
           public Nodo abajo = null;
           public Nodo derecha = null;
           public   Nodo izquierda = null;
           public  Dato valor;

            public Nodo(Dato valor)
            {
                this.valor = valor;
            }


        }

         int dimension;
         Nodo raiz;
         Dato valor;
         Nodo cabeza;
         Nodo cabeza2;
         public int dimension_x { get; set; }
         public int dimension_y { get; set; }

        public Matriz_Ortogonal(int dimension)
        {
            this.dimension = dimension;
            raiz = null;
            CrearMatriz(dimension);
        }
        
        public Dato getValorNodo(int fila, int columna)
        {
            Nodo temp = raiz;
            for (int i = 0; i < fila; i++)
            {
                temp = temp.abajo;
            }
            for (int i = 0; i < columna; i++)
            {
                temp = temp.derecha;
            }
            return temp.valor;
        }

        public Nodo getNodo(int fila, int columna)
        {
            Nodo temp = raiz;
            for (int i = 0; i < fila; i++)
            {
                temp = temp.abajo;
            }

            for (int i = 0; i < columna; i++)
            {
                temp = temp.derecha;
            }
            return temp;
        }

        public void setValor(int fila, int columna, Dato valor)
        {
            Nodo temp = raiz;
            for (int i = 0; i < fila; i++)
            {
                temp = temp.abajo;
            }

            for (int i = 0; i < columna; i++)
            {
                temp = temp.derecha;
                    
            }

            temp.valor = valor;
        }
        public void CrearMatriz(int dimension)
        {
            ListaSimple list = new ListaSimple();
            ListaSimple list2 = new ListaSimple();
            Boolean par = true;
            int contador = 1;

            int numero = dimension;
            while (numero > 0)
            {
                numero -= 2;

            } if (numero == 0)
            {
                par = true;
            }
            else
            {
                par = false;
            }

            int iteracion;
            if (par)
            {
                iteracion = (dimension / 2);
            }
            else
            {
                iteracion = dimension;
                iteracion += 1;
                iteracion = iteracion / 2;
            }

            for (int ii = 0; ii < iteracion; ii++)
            {
                list.vaciar();
                cabeza = new Nodo(null);
                list.addPrimero(cabeza);
                contador = 1;

                //Primera fila en crearse
                for (int i = 0; i < dimension-1; i++)
                {
                    Nodo temp = cabeza;
                    Nodo n = new Nodo(null);
                    n.derecha = temp;
                    temp.izquierda = n;
                    // si hay elementos en la lista2 es que hay otra iteracion

                    if (list2.size()!=0)
                    {
                        Nodo NodoSuperior = (Nodo)list2.getValorNodo(dimension - contador);
                        temp.arriba = NodoSuperior;
                        NodoSuperior.abajo = temp;
                        contador++;

                        //si esta en ultima iteracion
                        if (i==dimension-2)
                        {
                            Nodo NodoArriba = (Nodo)list2.getValorNodo(dimension - (contador + 1));
                            n.arriba = NodoArriba;
                            NodoArriba.abajo = n;
                        }
                    }
                    if (ii== 0 && i == dimension-2)
                    {
                        raiz = n;
                    }

                    cabeza = n;
                    list.addPrimero(n);
                }

                list2.vaciar();
                cabeza2 = new Nodo(null);
                list2.addPrimero(cabeza2);
                contador = 1;

                if (par|| (par==false && ii!=iteracion-1))
                {
                    for (int i = 0; i < dimension-1; i++)
                    {
                        Nodo NodoSuperior = (Nodo)list.getValorNodo(dimension - contador);
                        Nodo temp = cabeza2;
                        Nodo n = new Nodo(null);
                        n.derecha = temp;
                        temp.izquierda = n;
                        temp.arriba = NodoSuperior;
                        NodoSuperior.abajo = temp;

                        //si esta en la ultima iteracion
                        if (i==dimension-2)
                        {
                            Nodo NodoArriba = (Nodo)list.getValorNodo(dimension - (contador + 1));
                            n.arriba = NodoArriba;
                            NodoArriba.abajo = n;
                        }

                        cabeza2 = n;
                        list2.addPrimero(n);
                        contador++;
                    }
                }
            }
        }

        public Nodo getRaiz()
        {
            return raiz;
        }

        
    }
}
