using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace GestionBancaire
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection(" server = localhost; database = bank; username = root; password =; ");

        private void listetrans()
        {

            conn.Open();
            string query = "SELECT * from transaction order by tx_id DESC";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            conn.Close();
        }

        private void listetransfert()
        {

            conn.Open();
            string query1 = "SELECT * from transfert order by id_transfert ASC";
            MySqlDataAdapter sda1 = new MySqlDataAdapter(query1, conn);
            MySqlCommandBuilder builder1 = new MySqlCommandBuilder(sda1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            guna2DataGridView2.DataSource = dt1;
            conn.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            int oldsolde, dep, ret;
            int newsolde;
            index = e.RowIndex;
            DataGridViewRow selectedrow = guna2DataGridView1.Rows[index];
            oldsolde = int.Parse(selectedrow.Cells[3].Value.ToString());
            try
            {
                dep = int.Parse(selectedrow.Cells[4].Value.ToString());
            }
            catch
            {
                dep = 0;
            }
            try
            {
                ret = int.Parse(selectedrow.Cells[5].Value.ToString());
            }
            catch
            {
                ret = 0;
            }

           
            newsolde = oldsolde+dep-ret;
            txtsolde.Text = newsolde.ToString();
        }

        private void History_Load(object sender, EventArgs e)
        {
            listetrans();
            listetransfert();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
