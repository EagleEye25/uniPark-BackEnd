using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uniPark.Main.Forms.Landing;

namespace uniPark.Main.Forms.Loading
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void tmrLoading_Tick(object sender, EventArgs e)
        {
            /* Checks to see if the loading value is not 10
             * if it is timer stops */
            bool bFlag = false;
            if (matpgbLoading.Value != 10)
            {
                matpgbLoading.Value++;
            }
            else
            {
                tmrLoading.Stop();
                bFlag = true;               
            }

            if (bFlag == true)
            {
                frmLanding landing = new frmLanding();
                frmLoading loading = this;
                landing.Show();
                loading.Hide();
            }
            
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            /* Configuration of timer */ 
            tmrLoading.Enabled = true;
            tmrLoading.Start();
            tmrLoading.Interval = 1000;
            matpgbLoading.Maximum = 10;
        }
    }
}
