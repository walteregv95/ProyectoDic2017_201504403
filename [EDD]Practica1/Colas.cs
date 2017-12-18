using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace _EDD_Practica1
{
   public class Colas
    {

        public class Nodo
        {
            public Matriz_Ortogonal matriz;
            public Nodo siguiente = null;

            public Nodo(Matriz_Ortogonal matriz)
            {
                this.matriz = matriz;
            } 
           

        }

        public Nodo cabeza, ultimo;

        public void encolar(Matriz_Ortogonal matriz)
        {
            Nodo nuevoNodo = new Nodo(matriz);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                ultimo.siguiente = nuevoNodo;
            }

            ultimo = nuevoNodo;
                
        }

        public Matriz_Ortogonal Desencolar() 
        {
            if (cabeza != null)
            {
                Nodo nodo = cabeza;
                cabeza = cabeza.siguiente;
                nodo.siguiente = null;
                return nodo.matriz;

            }
            else
            {
                return null;
            }
            
        }

        public void peek()
        {
            int contadorNodo = 2;
            int contaEsp1 = 2;
            int contaEsp2 = 1;
            try
            {
                string path = "C:\\Users\\walteregv95\\Documents\\Wall-e\\cola.txt";
                string pathnuevo = "C:\\Users\\walteregv95\\Documents\\Wall-e\\cola.jpg";
                StreamWriter archivo = File.CreateText(path);

                archivo.Write("digraph G { \n");
                archivo.Write("nodesep = 0.5; \n");
                archivo.Write("rankdir = LR; \n");
                archivo.Write("node [shape = record, width =.1, height =.1]; \n");
                archivo.Write("node [width=1.5]; \n");
                archivo.Write("node1 [label = \" {  " + getValorMatriz(cabeza.matriz) + "| } \"]; \n");

                Nodo actual = cabeza.siguiente;
                while (actual != null)
                {
                    archivo.Write("node" + contadorNodo + " [label = \" {" + getValorMatriz(actual.matriz) + "| } \" ]; \n");
                    archivo.Write("node" + (contadorNodo - 1) + ":f" + contaEsp2 + "-> node" + contadorNodo + ":f" + contaEsp1 + "; \n");
                    contadorNodo++;
                    contaEsp2++;
                    contaEsp1++;
                    actual = actual.siguiente;
                }
                archivo.Write("}");
                archivo.Close();
                var comand = string.Format("dot -Tjpg " + path + "  -o  " + pathnuevo);
                var procStarInfo = new ProcessStartInfo("cmd", "/C" + comand);
                var proc = new Process();

                proc.StartInfo = procStarInfo;
                proc.Start();


            }
            catch (Exception x)
            {

                throw;
            }


        }

        public int getValorMatriz(Matriz_Ortogonal matriz)
        {
            int valor = 0;

            for (int i = 0; i < matriz.dimension_x; i++)
            {
                for (int j = 0; j < matriz.dimension_y; j++)
                {
                    Dato numero = matriz.getValorNodo(i, j);
                    valor = valor + numero.dato;
                }
            }

            return valor;
        }
            
      }


    }
