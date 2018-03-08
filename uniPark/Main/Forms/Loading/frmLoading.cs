using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (matpgbLoading.Value != 10)
            {
                matpgbLoading.Value++;
            }
            else
            {
                tmrLoading.Stop();
            }
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            /* Configuration of timer */ 
            tmrLoading.Enabled = true;
            tmrLoading.Start();
            tmrLoading.Interval = 1000;
            matpgbLoading.Maximum = 10;
            tmrLoading.Tick += new EventHandler(tmrLoading_Tick);
        }
    }
}
