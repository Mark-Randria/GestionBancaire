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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection(" server = localhost; database = bank; username = root; password =; ");

        private void listecompte(string a)
        {

            conn.Open();
            string query = "SELECT * from compte WHERE id_client = '"+a+"'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string client, nomprenom, nom_prenom;
            double id;

            string nom, prenom, ville, datenais, numero, nationality, genre, email, date_ins, idclient;

            client = txtclient.Text;

            if (client == "")
            {
                id = 0;
            }
            else
            {
                id = double.Parse(client);
            }

            nomprenom = txtnom.Text;

            if (nomprenom != "")
            {
                nom_prenom = "%"+nomprenom+"%";
            }
            else
            {
                nom_prenom = nomprenom;
            }

            try
            {
                conn.Open();

                string str = "SELECT * from client WHERE id_client = '"+id+"' OR nom LIKE '"+nom_prenom+"' OR prenom LIKE '"+nom_prenom+"'";
                MySqlCommand cmd = new MySqlCommand(str, conn);

                MySqlDataReader rd;
                rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    if (rd.Read())
                    {
                        idclient = rd.GetString("id_client");
                        nom = rd.GetString("nom");
                        prenom = rd.GetString("prenom");
                        ville = rd.GetString("ville");
                        datenais = rd.GetString("datenais");
                        numero = rd.GetString("numero");
                        nationality = rd.GetString("nationality");
                        genre = rd.GetString("genre");
                        email = rd.GetString("email");
                        date_ins = rd.GetString("date_ins");


                        txtid.Text = idclient;
                        txtname.Text = nom;
                        txtprenom.Text = prenom;
                        txtemail.Text = email;
                        txtville.Text = ville;
                        
                        /*
                         * txtcompte.Text = ;
                        txttype.Text = ;
                        txtdescr.Text = ;
                        txtsolde.Text = ;  
                        
                         */

                        conn.Close();
                        listecompte(idclient);

                    }
                    MessageBox.Show("Recherche terminee......");
                    txtclient.Clear();
                    txtnom.Clear();
                    guna2Button2.Show();
                    guna2Button4.Show();
                    
                }

                else
                {
                    MessageBox.Show("Donnees Introuvable.....");
                    txtclient.Clear();
                    txtnom.Clear();
                    txtid.Clear();
                    txtname.Clear();
                    txtprenom.Clear();
                    txtemail.Clear();
                    txtville.Clear();
                    txtcompte.Clear();
                    txttype.Clear();
                    txtdescr.Clear();
                    txtemail.Clear();
                    txtsolde.Clear();
                }


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

            finally
            {

                conn.Close();

            }

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }

        private void txtnom_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            MySqlCommand cmd4 = new MySqlCommand("UPDATE compte set type=@type, description=@description, solde=@solde WHERE id_compte=@id_compte", conn);
            cmd4.Parameters.AddWithValue("id_compte", txtid.Text);
            cmd4.Parameters.AddWithValue("type", txttype.Text);
            cmd4.Parameters.AddWithValue("description", txtdescr.Text);
            cmd4.Parameters.AddWithValue("solde", txtsolde.Text);

            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
            listecompte(txtid.Text);

            MessageBox.Show("Enregistrement effectue....");
            Search search = new Search();
            this.Hide();
            search.Show();

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = guna2DataGridView1.Rows[index];
            txtcompte.Text = selectedrow.Cells[0].Value.ToString();
            txtid.Text = selectedrow.Cells[1].Value.ToString();
            txttype.Text = selectedrow.Cells[2].Value.ToString();
            txtdescr.Text = selectedrow.Cells[3].Value.ToString();
            txtsolde.Text = selectedrow.Cells[4].Value.ToString();

        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd5 = new MySqlCommand("DELETE from compte WHERE id_client=@id", conn);
            cmd5.Parameters.AddWithValue("id", txtid.Text);
            conn.Open();
            cmd5.ExecuteNonQuery();
            conn.Close();
            listecompte(txtid.Text);

            MessageBox.Show("Suppression effectue....");
            Search search = new Search();
            this.Hide();
            search.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
