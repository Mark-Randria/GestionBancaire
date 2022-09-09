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
    public partial class Transfert : Form
    {
        public Transfert()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection(" server = localhost; database = bank; username = root; password =; ");

        private void txtdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string accsend, accreceive, date, montant;

            double balsend, balreceive, bal, baltotal, baltotal2;

            accsend = txtenv.Text;
            accreceive = txtrec.Text;
            date = txtdate.Text;

            montant = txtmontant.Text;

            if (accsend == "")
            {
                MessageBox.Show("Compte envoyeur manquante");
                
            }
            else if (accreceive == "")
            {
                MessageBox.Show("Compte receveur manquante");
            }
            else if (montant == "")
            {
                MessageBox.Show("Erreur, Montant non Selectionne");
            }
            else
            {


                try
                {

                    balreceive = double.Parse(labelreceive.Text);
                    balsend = double.Parse(labelsend.Text);
                    bal = double.Parse(txtmontant.Text);
                    baltotal = balsend - bal;
                    baltotal2 = balreceive + bal;

                    if (baltotal < 0)
                    {
                        MessageBox.Show("Solde Insuffisant....Operation annule");
                        txtmontant.Clear();
                    }
                    else
                    {
                        conn.Open();
                        MySqlCommand cmd1 = new MySqlCommand();
                        MySqlTransaction transaction;

                        transaction = conn.BeginTransaction();

                        cmd1.Connection = conn;
                        cmd1.Transaction = transaction;

                        try
                        {
                            cmd1.CommandText = "UPDATE compte set solde  = '"+baltotal+"' WHERE id_compte = '" + accsend + "'";
                            cmd1.ExecuteNonQuery();

                            cmd1.CommandText = "UPDATE compte set solde  = '"+baltotal2+"' WHERE id_compte = '" + accreceive + "'";
                            cmd1.ExecuteNonQuery();

                            cmd1.CommandText = "INSERT into transfert (account_send, account_receiver, date, montant) VALUES ('"+accsend+"','"+accreceive+"','"+date+"','"+montant+"')";
                            cmd1.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Transaction reussi.......");
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

                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    conn.Close();

                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string accsend, accreceive;

            accsend = txtenv.Text;
            accreceive = txtrec.Text;
            

            if (accsend == "")
            {
                MessageBox.Show("Compte envoyeur manquante");

            }
            else if (accreceive == "")
            {
                MessageBox.Show("Compte receveur manquante");
            }
            else
            {


                string comptesend;
                comptesend = txtenv.Text;



                try
                {

                    conn.Open();

                    string a = "SELECT * from compte where id_compte ='"+comptesend+"'";
                    MySqlCommand cmd = new MySqlCommand(a, conn);

                    MySqlDataReader b;
                    b = cmd.ExecuteReader();

                    if (b.HasRows)
                    {


                        while (b.Read())
                        {
                            labelsend.Text = b[4].ToString();
                        }

                        string comptereceive;
                        comptereceive = txtrec.Text;



                        try
                        {
                            conn.Close();

                            conn.Open();

                            string c = "SELECT * from compte where id_compte ='"+comptereceive+"'";
                            MySqlCommand cm = new MySqlCommand(c, conn);

                            MySqlDataReader d;
                            d = cm.ExecuteReader();

                            if (d.HasRows)
                            {



                                while (d.Read())
                                {
                                    labelreceive.Text = d[4].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ce compte receveur n'existe pas..");
                                txtrec.Clear();
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

                        guna2Button1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ce compte envoyeur n'existe pas..");
                        txtenv.Clear();
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
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }

        private void txtenv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
