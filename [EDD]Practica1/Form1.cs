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
    public partial class Form1 : Form
    {
        public static string nombre;
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro enlace = new Registro();
            enlace.ShowDialog();
           
            this.Dispose();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string validar;
            validar = Registro.usuarios.Buscar(txtUsuario.Text);
            if (validar.Equals("Nada"))
            {
                MessageBox.Show("Usuario incorrecto", "Error");
            }
            else if(validar.Equals(txtContraseña.Text))
            {
                nombre = txtUsuario.Text;
                Operar enlace = new Operar();
                
                enlace.ShowDialog();
                //prueba enlace = new prueba();
                //enlace.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta", "Error");
            }
        }
    }
}
