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
    public partial class Clientes : Form
    {
        SqlConnection conn = new SqlConnection();
        public Clientes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\marco\\source\\repos\\BarberProject\\BarberProject\\BarberBD.mdf;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                String consulta = "SELECT * FROM Clientes";
                DataTable dt = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conn);
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (SqlException er)
            {

                MessageBox.Show("Error" + er);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\marco\\source\\repos\\BarberProject\\BarberProject\\BarberBD.mdf;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                String consulta = "INSERT INTO Clientes(Nombre,Celular)" +
                    "VALUES('" + txtNombre.Text + "','" + txtCelular.Text+ "')";
                SqlCommand comando = new SqlCommand(consulta, conn);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se añadio cliente con exito");
                String consulta2 = "SELECT * FROM Clientes";
                DataTable dt = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta2, conn);
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error" + er);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\marco\\source\\repos\\BarberProject\\BarberProject\\BarberBD.mdf;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                String consulta = "UPDATE Clientes SET Celular='" + txtCelular.Text + "', Nombre='" + txtNombre.Text + "' WHERE Id=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();;
                SqlCommand comando = new SqlCommand(consulta, conn);
                comando.ExecuteNonQuery();
                MessageBox.Show("Cliente actualizado");
                txtNombre.Clear();
                txtCelular.Clear();


                String consulta2 = "SELECT * FROM Clientes";
                DataTable dt = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta2, conn);
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\marco\\source\\repos\\BarberProject\\BarberProject\\BarberBD.mdf;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                String consulta = "DELETE FROM Clientes WHERE Id=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString(); ;
                SqlCommand comando = new SqlCommand(consulta, conn);
                comando.ExecuteNonQuery();
                MessageBox.Show("Cliente eliminado");
                String consulta2 = "SELECT * FROM Clientes";
                DataTable dt = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta2, conn);
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Agendar agenda = new Agendar();
            agenda.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
