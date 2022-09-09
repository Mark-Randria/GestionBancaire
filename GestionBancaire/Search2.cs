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
    public partial class Search2 : Form
    {
        public Search2()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection(" server = localhost; database = bank; username = root; password =; ");

        private void listeclient(double a, string b)
        {

            conn.Open();
            string query = "SELECT * from client WHERE id_client = '"+a+"' OR nom LIKE '"+b+"' OR prenom LIKE '"+b+"'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            conn.Close();
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

                        conn.Close();
                        listeclient(id,nom_prenom);

                        /* 
                         nom = rd.GetString("nom");
                         prenom = rd.GetString("prenom");
                         ville = rd.GetString("ville");
                         datenais = rd.GetString("datenais");
                         numero = rd.GetString("numero");
                         nationality = rd.GetString("nationality");
                         genre = rd.GetString("genre");
                         email = rd.GetString("email");
                         date_ins = rd.GetString("date_ins"); */



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
                    txtville.Clear();
                    txtdatenais.Clear();
                    txtnumero.Clear();
                    txtnationalite.Clear();
                    txtemail.Clear();
                    txtdate_ins.Clear();
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            Main m = new Main();
            this.Hide();
            m.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = guna2DataGridView1.Rows[index];
            txtid.Text = selectedrow.Cells[0].Value.ToString();
            txtname.Text = selectedrow.Cells[1].Value.ToString();
            txtprenom.Text = selectedrow.Cells[2].Value.ToString();
            txtville.Text = selectedrow.Cells[3].Value.ToString();
            txtdatenais.Text = selectedrow.Cells[4].Value.ToString();
            txtnumero.Text = selectedrow.Cells[5].Value.ToString(); 
            txtnationalite.Text = selectedrow.Cells[6].Value.ToString(); 
            txtgenre.Text = selectedrow.Cells[7].Value.ToString(); 
            txtemail.Text = selectedrow.Cells[8].Value.ToString();
            txtdate_ins.Text = selectedrow.Cells[9].Value.ToString();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            MySqlCommand cmd3 = new MySqlCommand("UPDATE client set nom=@nom, prenom=@prenom, ville=@ville, datenais=@datenais, numero=@numero, nationality=@nationalite, genre=@genre, email=@email, date_ins=@date_ins WHERE id_client=@id_client", conn);

            cmd3.Parameters.AddWithValue("id_client", txtid.Text);
            cmd3.Parameters.AddWithValue("nom", txtname.Text);
            cmd3.Parameters.AddWithValue("prenom", txtprenom.Text);
            cmd3.Parameters.AddWithValue("ville", txtville.Text);
            cmd3.Parameters.AddWithValue("datenais", txtdatenais.Text);
            cmd3.Parameters.AddWithValue("numero", int.Parse(txtnumero.Text));
            cmd3.Parameters.AddWithValue("nationalite", txtnationalite.Text);
            cmd3.Parameters.AddWithValue("genre", txtgenre.Text);
            cmd3.Parameters.AddWithValue("email", txtemail.Text);
            cmd3.Parameters.AddWithValue("date_ins", txtdate_ins.Text);

            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();
            double id;
            id = double.Parse(txtid.Text);
            listeclient(id, txtnom.Text);

            MessageBox.Show("Enregistrement effectue....");
            Search2 search2 = new Search2();
            this.Hide();
            search2.Show();



        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd4 = new MySqlCommand("DELETE from client WHERE id_client=@id",conn);
            cmd4.Parameters.AddWithValue("id", txtid.Text);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();

            MySqlCommand cmd5 = new MySqlCommand("DELETE from compte WHERE id_client=@id", conn);
            cmd5.Parameters.AddWithValue("id", txtid.Text);
            conn.Open();
            cmd5.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Tous les comptes associes a ce client vont tous etre supprime....");

            double id;
            id = double.Parse(txtid.Text);
            listeclient(id, txtnom.Text);

            MessageBox.Show("Suppression effectue....");
            Search2 search2 = new Search2();
            this.Hide();
            search2.Show();
        }
    }
}
