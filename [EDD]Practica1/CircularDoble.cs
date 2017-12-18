using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace _EDD_Practica1
{
    public class CircularDoble
    {
        public class Nodo {

           public Nodo siguiente = null; 
           public  Nodo anterior = null;
           public  Usuarios usuario;

            public Nodo(Usuarios usuario)
            {
                this.usuario = usuario;
            }


        }

        Nodo primero = null;
        Nodo ultimo = null;
        int longitud = 0;
        public void Insertar(Usuarios usuario)
        {
            Nodo nuevo = new Nodo(usuario);
            if (primero == null)
            {
                primero = nuevo;
                primero.siguiente = primero;
                primero.anterior = ultimo;
                ultimo = nuevo;

            }
            else
            {
                ultimo.siguiente = nuevo;
                nuevo.anterior = ultimo;
                nuevo.siguiente = primero;
                primero.anterior = nuevo;
                ultimo = nuevo;
            }

            longitud++; 
        }

        public string Buscar(string nombre)
        {
          int contador = 0;
          Nodo actual = primero;
          string valor = "Nada";
          while (contador<= longitud)
          {
              if (actual.usuario.nombre.Equals(nombre))
              {
                    valor =actual.usuario.contraseña;
              }
              actual = actual.siguiente;
              contador++;
          }
          return valor;
        }
        public Usuarios getUsuario(string nombre)
        {
            int contador = 0;
            Nodo actual = primero;
            
            while (contador<= longitud && actual.usuario.nombre!= nombre)
            {
               
                actual = actual.siguiente;
                contador++;
            }
            return actual.usuario;
        }

        public void Eliminar(string nombre)
        {
            int contador = 0;
            Nodo actual = primero;
            Nodo anterior = ultimo;

            while (contador <= longitud)
            {
                if (actual.usuario.nombre.Equals(nombre))
                {
                    if (actual == primero)
                    {
                        primero = primero.siguiente;
                        ultimo.siguiente = primero;
                        primero.anterior = ultimo;
                    }
                    else if (actual == ultimo)
                    {
                        ultimo = anterior;
                        primero.anterior = ultimo;
                        anterior.siguiente = primero;

                    }
                    else
                    {
                        anterior.siguiente = actual.siguiente;
                        actual.siguiente.anterior = anterior; 
                    }
                }
                anterior = actual;
                actual = actual.siguiente;
                contador++;
                
            }

            longitud--;

        }

        public void peek()
        {
            int contadorNodo = 2;
            int contaEsp1 = 2;
            int contaEsp2 = 1;
            try
            {
                string path = "C:\\Users\\walteregv95\\Documents\\Wall-e\\lista.txt";
                string pathnuevo = "C:\\Users\\walteregv95\\Documents\\Wall-e\\lista.jpg";
                StreamWriter archivo = File.CreateText(path);

                archivo.Write("digraph G { \n");
                archivo.Write("nodesep = 0.5; \n");
                archivo.Write("rankdir = LR; \n");
                archivo.Write("node [shape = record, width =.1, height =.1]; \n");
                archivo.Write("node [width=1.5]; \n");
                archivo.Write("node1 [label = \" { | " + primero.usuario.nombre + "| } \"]; \n");

                Nodo actual = primero.siguiente;
                int contador = 0;
                while (contador < longitud)
                {
                    archivo.Write("node" + contadorNodo + " [label = \" { |" + actual.usuario.nombre + "| } \" ]; \n");
                    archivo.Write("node" + (contadorNodo - 1) + ":f" + contaEsp2 + "-> node" + contadorNodo + ":f" + contaEsp1 + "; \n");
                    archivo.Write("node" + contadorNodo + ":f" + contaEsp2 + "-> node" + (contadorNodo - 1) + ":f" + contaEsp1 + ";\n");
                    contadorNodo++;
                    contaEsp2++;
                    contaEsp1++;
                    contador++;
                    if (contador == longitud-1)
                    {
                        
                        archivo.Write("node" + (contadorNodo - 1) + ":f" + contaEsp2 + "-> node1 :f" + contaEsp1 + "; \n");
                        archivo.Write("node1 :f" + contaEsp2 + "-> node" + (contadorNodo - 1) + ":f" + contaEsp1 + ";\n");
                        break;
                        
                    }
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
    }
}
