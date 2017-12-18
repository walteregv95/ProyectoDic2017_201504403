using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace _EDD_Practica1
{
    public partial class Operar : Form
    {
        Pilas pila = new Pilas();
        Colas cola = new Colas();
        
        public Operar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            string strJson="";

            if (buscar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(buscar.FileName);
                strJson = sr.ReadToEnd();

                sr.Close();
            }

            deserealizeJSON(strJson);
            Usuarios usuarioActual = Registro.usuarios.getUsuario(Form1.nombre);

            usuarioActual.cola = cola;
            usuarioActual.pila = pila;

            
        }

        public void deserealizeJSON(string strJson)
        {
            var json = JsonConvert.DeserializeObject<Json>(strJson);
           
            //Matrices de la Pila
            foreach (var item in json.archivo.pila.matrices.matriz)

            {
                int dimension = (int.Parse(item.size_x )* int.Parse(item.size_y));
                Matriz_Ortogonal nuevaMatriz = new Matriz_Ortogonal(dimension);
                nuevaMatriz.dimension_x = int.Parse(item.size_x);
                nuevaMatriz.dimension_y = int.Parse(item.size_y);
                nuevaMatriz.CrearMatriz(dimension);

                foreach (var n in item.valores.valor)
                {
                    Dato nuevodato = new Dato(int.Parse(n.dato));
                    nuevaMatriz.setValor(int.Parse(n.pos_y),int.Parse( n.pos_x), nuevodato);
                   
                }

                //Llenar de 0 los espacios vacios
                for (int i = 0; i <= (int.Parse(item.size_x)); i++)
                {
                    for (int j = 0; j < (int.Parse(item.size_y)); j++)
                    {
                        if (nuevaMatriz.getValorNodo(i, j)== null)
                        {
                            Dato cero = new Dato(0);
                            nuevaMatriz.setValor(i, j, cero);
                        }
                    }
                }

                pila.Push(nuevaMatriz);

               

            }

            //Matrices de la Cola

            foreach (var item in json.archivo.cola.matrices.matriz)
            {
                int dimension2 = (int.Parse(item.size_x) * int.Parse(item.size_y));

                Matriz_Ortogonal nuevaMatriz2 = new Matriz_Ortogonal(dimension2);
                nuevaMatriz2.dimension_x = int.Parse(item.size_x);
                nuevaMatriz2.dimension_y = int.Parse(item.size_y);
                nuevaMatriz2.CrearMatriz(dimension2);

                foreach (var i in item.valores.valor)
                {
                    Dato nuevodato2 = new Dato(int.Parse(i.dato));
                    nuevaMatriz2.setValor(int.Parse(i.pos_y), int.Parse(i.pos_x), nuevodato2);
                    
                }
                //Llenar de 0 los espacios vacios
                for (int i = 0; i <= (int.Parse(item.size_x)); i++)
                {
                    for (int j = 0; j < (int.Parse(item.size_y)); j++)
                    {
                        if (nuevaMatriz2.getValorNodo(i, j) == null)
                        {
                            Dato cero = new Dato(0);
                            nuevaMatriz2.setValor(i, j, cero);
                        }
                    }
                }

                cola.encolar(nuevaMatriz2);
            }

           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 enlace = new Form1();
            enlace.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Matriz_Ortogonal matriz1 = cola.Desencolar();
            Matriz_Ortogonal matriz2 = pila.Pop();

            
        }

        private void pilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pila.peek();
            pictureBox1.Image = Image.FromFile("C:\\Users\\walteregv95\\Documents\\Wall-e\\pila.jpg");
                
        }

        private void colaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cola.peek();
            pictureBox1.Image = Image.FromFile("C:\\Users\\walteregv95\\Documents\\Wall-e\\cola.jpg");
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CircularDoble listado = Registro.usuarios;
            listado.peek();
            pictureBox1.Image = Image.FromFile("C:\\Users\\walteregv95\\Documents\\Wall-e\\lista.jpg");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
