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
    public partial class Depot : Form
    {
        public Depot()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection(" server = localhost; database = bank; username = root; password =; ");


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string compte;
            compte = txtcompte.Text;



            try
            {

                conn.Open();

                string str = "SELECT * from compte where id_compte ='"+compte+"'";
                MySqlCommand cmd = new MySqlCommand(str, conn);

                MySqlDataReader rd;
                rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {



                    while (rd.Read())
                    {
                        txtsolde.Text = rd[4].ToString();
                    }
                    MessageBox.Show("Compte Trouvee......");
                    guna2Button1.Show();
                }
                else
                {
                    MessageBox.Show("Ce compte n'existe pas..");
                    txtcompte.Clear();
                }

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

            finally
            {

                conn.Close();

            }

        }

        private void txtcompte_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string compte_no, date, soldecomp, montantcomp;
            double solde, montant;

            compte_no = txtcompte.Text;
            date = txtdate.Text;
            soldecomp = txtsolde.Text;
            montantcomp = txtmontant.Text;
            try
            {

                conn.Open();

                string str = "SELECT * from compte where id_compte ='"+compte_no+"'";
                MySqlCommand cmd = new MySqlCommand(str, conn);

                MySqlDataReader rd;
                rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {



                    if (soldecomp == "")
                    {
                        MessageBox.Show("Erreur, Solde Introuvable");
                    }
                    else if (montantcomp == "")
                    {
                        MessageBox.Show("Erreur, Montant non Selectionne");
                    }

                    else if (compte_no == "")
                    {
                        MessageBox.Show("Erreur, Compte introuvable");
                    }

                    else
                    {
                        conn.Close();
                        solde = double.Parse(txtsolde.Text);
                        montant = double.Parse(txtmontant.Text);

                        conn.Open();
                        MySqlCommand cmd1 = new MySqlCommand();
                        MySqlTransaction transaction;

                        transaction = conn.BeginTransaction();

                        cmd1.Connection = conn;
                        cmd1.Transaction = transaction;

                        try
                        {
                            cmd1.CommandText = "UPDATE compte set solde  = solde + '"+montant+"' WHERE id_compte = '" + compte_no+ "'";
                            cmd1.ExecuteNonQuery();

                            cmd1.CommandText = "INSERT into transaction (id_compte, date, solde, depot) VALUES ('"+compte_no+"','"+date+"','"+solde+"','"+montant+"')";
                            cmd1.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Transaction reussi.......");
                            txtcompte.Clear();
                            txtmontant.Clear();
                            txtsolde.Clear();



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
                else
                {
                    MessageBox.Show("Ce compte n'existe pas..");
                    txtcompte.Clear();
                    txtmontant.Clear();
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
    }
}
