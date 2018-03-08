using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uniPark.Main.Forms.Landing
{
    public partial class frmLanding : Form
    {
        int panelWidth;
        bool hidden;
         
        public frmLanding()
        {
            InitializeComponent();
            panelWidth = pnlMenu.Width;
            hidden = false;
        }

        private void tmrTest_Tick(object sender, EventArgs e)
        {
        }
        
        private void btntest1_Click(object sender, EventArgs e)
        {
        }

        private void frmLanding_Load(object sender, EventArgs e)
        {

        }

        private void tmrSlide_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                pnlMenu.Width = pnlMenu.Width + 10;
                if (pnlMenu.Width >= panelWidth)
                {
                    tmrSlide.Stop();
                    hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                pnlMenu.Width = pnlMenu.Width - 10;
                if (pnlMenu.Width <= 52.5)
                {
                    tmrSlide.Stop();
                    hidden = true;
                    this.Refresh();
                }
            }
        }

        private void matBtnMenu_Click(object sender, EventArgs e)
        {
            tmrSlide.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
