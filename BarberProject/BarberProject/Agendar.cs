using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BarberProject
{
    public partial class Agendar : Form
    {
        SqlConnection conn = new SqlConnection();
        public Agendar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clientes clients = new Clientes();
            clients.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Agendar_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            var fechahoy = DateTime.Now;
            dateTimePicker1.MinDate = fechahoy;
            try
            {
                conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\marco\\source\\repos\\BarberProject\\BarberProject\\BarberBD.mdf;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                String consulta = "SELECT * FROM Citas";
                DataTable dt1 = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conn);
                adaptador.Fill(dt1);
                dataGridView1.DataSource = dt1;
                //asrasrasrasras
                String consulta2 = "SELECT * FROM Clientes";
                DataTable dt2 = new DataTable();
                SqlDataAdapter adaptador2 = new SqlDataAdapter(consulta2, conn);
                adaptador2.Fill(dt2);
                dataGridView2.DataSource = dt2;

                conn.Close();
            }
            catch (SqlException er)
            {

                MessageBox.Show("Error" + er);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHorario.Text = listBox1.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\marco\\source\\repos\\BarberProject\\BarberProject\\BarberBD.mdf;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                String consulta = "INSERT INTO Citas(Fecha, IdCliente, Hora)" +
                    "VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + txtId.Text + "','" + listBox1.SelectedItem.ToString() + "')";
                SqlCommand comando = new SqlCommand(consulta, conn);          
                comando.ExecuteNonQuery();
                MessageBox.Show("Se agendo cita");

                String consulta2 = "SELECT * FROM Citas";
                DataTable dt1 = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta2, conn);
                adaptador.Fill(dt1);
                dataGridView1.DataSource = dt1;
                conn.Close();
            }
            catch (SqlException er)
            {

                MessageBox.Show("Error" + er);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\marco\\source\\repos\\BarberProject\\BarberProject\\BarberBD.mdf;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                String consulta = "DELETE FROM Citas WHERE IdCita =" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString(); ;
                SqlCommand comando = new SqlCommand(consulta, conn);
                comando.ExecuteNonQuery();
                MessageBox.Show("Cita Eliminada");

                String consulta2 = "SELECT * FROM Citas";
                DataTable dt1 = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta2, conn);
                adaptador.Fill(dt1);
                dataGridView1.DataSource = dt1;
                conn.Close();
            }
            catch (SqlException er)
            {

                MessageBox.Show("Error" + er);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
