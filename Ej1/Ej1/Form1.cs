using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ej1.Models;

namespace Ej1
{
    public partial class Form1 : Form
    {
        List<cuenta> cuentas = new List<cuenta> ();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            int dni = Convert.ToInt32(textBox2.Text);
            double importe = Convert.ToDouble(textBox3.Text);
            cuenta c = new cuenta(nombre, dni, importe);
            cuentas.Sort();
            int idx = cuentas.BinarySearch(c);
            if (idx >= 0)
            {
                cuentas[idx].nombre = nombre;
                cuentas[idx].importe += importe;
            }
            else
            {
                cuentas.Add(c);
            }
            button2.PerformClick();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (cuenta c in cuentas)
            {
                listBox1.Items.Add(c);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cuenta c = listBox1.SelectedItem as cuenta;
            if (c != null)
            {
                textBox2.Text = $"{c.dni}";
                textBox1.Text = $"{c.nombre}";
                textBox1.Text = $"{c.importe}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                while (sr.EndOfStream == false)
                { 
                    string linea = sr.ReadLine();
                    string dni = linea.Substring(0,9).Trim();
                    string nombre = linea.Substring(9,10).Trim(); 
                    string importe = linea.Substring(19,9).Trim();
                    cuenta c = new cuenta(nombre, Convert.ToInt32(dni), Convert.ToDouble(importe));
                }
                
            }
        }
    }
}
