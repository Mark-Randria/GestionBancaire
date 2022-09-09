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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        MySqlConnection conn = new MySqlConnection(" server = localhost; database = bank; username = root; password =; ");
        int count;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username, password;

            username = txtuser.Text;
            password = txtpass.Text;

            string admin, admin_pwd;

            MySqlCommand cmd = new MySqlCommand();

          
            MySqlDataReader reader = null;

            try
            {
                string sql = "SELECT pseudo, mdp FROM utilisateur WHERE pseudo ='"+username+"' ";

                cmd = new MySqlCommand(sql, conn);

                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {



                    while (reader.Read())
                    {
                        admin = reader.GetString("pseudo");
                        admin_pwd = reader.GetString("mdp");

                        if (username == admin && password == admin_pwd)
                        {

                            count = 1;
                            LoadingBar L = new LoadingBar();
                            this.Hide();
                            L.Show();

                        }
                        else
                        {
                            count += 1;

                            if (count > 3)
                            {
                                MessageBox.Show("Limite de tentative atteinte.......");
                                MessageBox.Show("Arret du Systeme....");
                                Application.Exit();
                            }

                            label4.Text = "Incorrect..." + (4 - count) + " tentative(s) restante(s)";
                            txtpass.Clear();
                            txtuser.Clear();
                            txtuser.Focus();
                        }

                    }
                }

                else
                {
                     if (username == "" || password == "")
                    {
                        label4.Text = "Formulaire manquante!";
                    }
                    else
                    {
                        count += 1;

                        if (count > 3)
                        {
                            MessageBox.Show("Limite de tentative atteinte.......");
                            MessageBox.Show("Arret du Systeme....");
                            Application.Exit();
                        }

                        label4.Text = "Incorrect..." + (4 - count) + " tentative(s) restante(s)";
                        txtpass.Clear();
                        txtuser.Clear();
                        txtuser.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }




            




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadingBar2 L2 = new LoadingBar2();
            this.Hide();
            L2.Show();

        }
    }
}
