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
    public partial class LoadingBar : Form
    {
        public LoadingBar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ProgressBar1.Value < 40)
            {
                ProgressBar1.Value += 1;
            }

            else if (ProgressBar1.Value < 60)
            {
                ProgressBar1.Value += 2;
            }
            else if (ProgressBar1.Value < 75)
            {
                ProgressBar1.Value += 1;
            }
            else
            {
                ProgressBar1.Value += 1;
                if (ProgressBar1.Value >= 99)
                {
                    Main M = new Main();
                    this.Hide();
                    M.Show();

                    timer1.Enabled = false;
                    ProgressBar1.Value = ProgressBar1.Value - 1;
                }
            }

        }
    }
}
