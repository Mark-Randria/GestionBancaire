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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection(" server = localhost; database = bank; username = root; password =; ");


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Compte_Click(object sender, EventArgs e)
        {

        }

        private void Account_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            



            string client_id1, nom, prenom, ville, datenais, numero, nationalite, genre, email, date_ins;

            string compte_id1, type, descr, solde;
            int balance;
            int client_id;
            int compte_id;






            client_id1 = txtclient.Text;
            compte_id1 = txtcompte_id.Text;
            nom = txtnom.Text;
            prenom = txtprenom.Text;
            ville = txtville.Text;
            datenais = txtdatenais.Text;
            numero = txtphone.Text;
            nationalite = txtnation.Text;
            genre = txtgenre.Text;
            email = txtemail.Text;
            date_ins = txtdate_ins.Text;
            type = txttype.Text;
            descr = txtdescr.Text;
            solde = txtsolde.Text;


            if (compte_id1 == "")
            {
                MessageBox.Show("Identifiant du Compte ne doit pas etre vide");
            }

            else if (client_id1 == "")
            {
                MessageBox.Show("Identifiant du Client ne doit pas etre vide");

            }
            else if (type == "")
            {
                MessageBox.Show("Selectionner le type de compte");

            }
            else if (solde == "")
            {
                MessageBox.Show("Solde Manquante...");

            }

            else
            {
                client_id = int.Parse(client_id1);
                compte_id = int.Parse(compte_id1);
                balance = int.Parse(solde);


                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                MySqlTransaction transaction;

                transaction = conn.BeginTransaction();

                cmd.Connection = conn;
                cmd.Transaction = transaction;

                try
                {

                    cmd.CommandText = "INSERT IGNORE into client (id_client, nom, prenom, ville, datenais, numero, nationality, genre, email, date_ins) VALUES ('"+client_id+"','"+nom+"','"+prenom+"','"+ville+"','"+datenais+"','"+numero+"','"+nationalite+"','"+genre+"','"+email+"','"+date_ins+"')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT IGNORE into compte (id_compte, id_client, type, description, solde) VALUES ('"+compte_id+"','"+client_id+"','"+type+"','"+descr+"','"+balance+"')";
                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("Enregistrement reussi ............");

                    Main m = new Main();
                    this.Hide();
                    m.Show();



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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }

        private void txtsolde_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtclient_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
