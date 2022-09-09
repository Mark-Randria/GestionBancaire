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
    public partial class LoadingBar2 : Form
    {
        public LoadingBar2()
        {
            InitializeComponent();
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
                    AccountCreate ac = new AccountCreate();
                    this.Hide();
                    ac.Show();

                    timer1.Enabled = false;
                    ProgressBar1.Value = ProgressBar1.Value - 1;
                }
            }
        }

        private void ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void LoadingBar2_Load(object sender, EventArgs e)
        {

        }
    }
}
