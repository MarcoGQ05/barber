using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarberProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text== "admin" && txtContraseña.Text== "1234")
            {
                this.Hide();
                Agendar agendarr = new Agendar();
                agendarr.Show();
            }
            else
            {
                label3.Text = "Favor de ingresar la contraseña correcta";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
