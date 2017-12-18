using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections;

namespace _EDD_Practica1
{
    public partial class prueba : Form
    {
        public prueba()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deserealizeJSON(richTextBox1.Text);
        }

        public void deserealizeJSON(string strJson)
        {
            var json = JsonConvert.DeserializeObject<Json>(strJson);
            string lista = "hola";

            foreach (var item in json.archivo.pila.matrices.matriz)
            {
                lista += item.size_x.ToString();
            }

            richTextBox2.Text = lista;
        }
    }
}
