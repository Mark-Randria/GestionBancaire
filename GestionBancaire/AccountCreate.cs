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
    public partial class AccountCreate : Form
    {
        public AccountCreate()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection(" server = localhost; database = bank; username = root; password =; ");

        

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string pseudo, pwd;

                pseudo = txtpseudo.Text;
                pwd = txtpwd.Text;

            if (pseudo == "" || pwd == "")
            {
                MessageBox.Show("Formulaire manquante.....");
            }
            else
            {



                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                MySqlTransaction transaction;

                transaction = conn.BeginTransaction();

                cmd.Connection = conn;
                cmd.Transaction = transaction;


                try
                {

                    cmd.CommandText = "REPLACE into utilisateur (pseudo, mdp) VALUES ('"+pseudo+"','"+pwd+"')";
                    cmd.ExecuteNonQuery();


                    transaction.Commit();

                    MessageBox.Show("Enregistrement reussi ............");
                    txtpseudo.Clear();
                    txtpwd.Clear();

                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.ToString());


                }

                finally
                {
                    conn.Close();
                }
            }

            

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void AccountCreate_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtgenre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtpwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
