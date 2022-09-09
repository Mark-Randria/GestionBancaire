using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBancaire
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Account ac2 = new Account();
            this.Hide();
            ac2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Depot depot = new Depot();
            this.Hide();
            depot.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Retrait retrait = new Retrait();
            this.Hide();
            retrait.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Transfert transfert = new Transfert();
            this.Hide();
            transfert.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            this.Hide();
            search.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            Search2 search2 = new Search2();
            this.Hide();
            search2.Show();
        }

        private void txthist_Click(object sender, EventArgs e)
        {
            History history = new History();
            this.Hide();
            history.Show();

        }
    }
}
