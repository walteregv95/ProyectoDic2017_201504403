using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _EDD_Practica1
{
    public partial class Registro : Form
    {
         public static CircularDoble usuarios = new CircularDoble();
        
        
        public Registro()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 enlace = new Form1();
            
            enlace.ShowDialog();
            this.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Pilas pila = new Pilas();
            Colas cola = new Colas();
            Usuarios nuevoUser = new Usuarios(txtUsuario.Text, txtContraseña.Text, cola, pila);
            usuarios.Insertar(nuevoUser);
        }
    }
}
