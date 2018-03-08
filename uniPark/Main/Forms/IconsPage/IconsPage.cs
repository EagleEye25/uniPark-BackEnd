using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uniPark
{
    public partial class IconsPage : Form
    {
        private Color colorDefualt = Color.FromArgb(62, 62, 66);
        private Color colorChange = Color.FromArgb(54, 54, 57);
        public IconsPage()
        {
            InitializeComponent();
        }

        private void IconsPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = colorChange;
            pnlRight.Height = button1.Height;
            pnlRight.Top = button1.Top;
            button2.BackColor = colorDefualt;
            button3.BackColor = colorDefualt;
            button4.BackColor = colorDefualt;
            button5.BackColor = colorDefualt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = colorChange;
            pnlRight.Height = button2.Height;
            pnlRight.Top = button2.Top;
            button1.BackColor = colorDefualt;
            button3.BackColor = colorDefualt;
            button4.BackColor = colorDefualt;
            button5.BackColor = colorDefualt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = colorChange;
            pnlRight.Height = button4.Height;
            pnlRight.Top = button3.Top;
            button2.BackColor = colorDefualt;
            button1.BackColor = colorDefualt;
            button4.BackColor = colorDefualt;
            button5.BackColor = colorDefualt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = colorChange;
            pnlRight.Height = button4.Height;
            pnlRight.Top = button4.Top;
            button2.BackColor = colorDefualt;
            button3.BackColor = colorDefualt;
            button1.BackColor = colorDefualt;
            button5.BackColor = colorDefualt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = colorChange;
            pnlRight.Height = button5.Height;
            pnlRight.Top = button5.Top;
            button2.BackColor = colorDefualt;
            button3.BackColor = colorDefualt;
            button4.BackColor = colorDefualt;
            button1.BackColor = colorDefualt;
        }
    }
}
