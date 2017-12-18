using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace _EDD_Practica1
{
   public  class ListaSimple
    {

       public class Nodo
       {

           public Nodo siguiente = null;
           public Object objeto;
           

           public Nodo(Object objeto)
           {
               this.objeto = objeto;
           }

           
       }

       public Nodo cabeza = null;
       public Nodo ultimo = null;
       public int longitud = 0; 

       public void addPrimero(Object obj)
           {  
               Nodo nuevo = new Nodo(obj);
               if (cabeza == null)
               {
                   cabeza = nuevo;
               }
               else
               {
                   nuevo.siguiente = cabeza;
                   cabeza = nuevo;
               }

               longitud++;
           }

       public void RemoveAt(int index)
       {
           if (index == 0)
           {
               Nodo aux = cabeza;
               cabeza.siguiente = cabeza;
               aux.siguiente = null;
           }
           else
           {
               int contador = 0;
               Nodo temporal = cabeza;
               while (contador < index-1)
               {
                   temporal = temporal.siguiente;
                   contador++;
               }
               temporal.siguiente = temporal.siguiente.siguiente;
           }

           longitud--;
           
           
       }

       public Object Buscar(int index)
       {
           int contador = 0;
           Nodo temporal = cabeza;
           while (contador < index)
           {
               temporal = temporal.siguiente;
               contador++;
           }
           return temporal.objeto;
       }

       public int size()
       {
           return longitud;
       }

       public void vaciar()
       {
           cabeza = null;
           longitud = 0;
       }

       public Object getValorNodo(int index)
       {
           int contador = 0;
           Nodo temporal = cabeza;
           while (contador< index)
           {
               temporal = temporal.siguiente;
               contador++;
           }

           return temporal.objeto;
       }
    }
}
