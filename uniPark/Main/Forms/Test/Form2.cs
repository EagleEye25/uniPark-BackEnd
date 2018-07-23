using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using uniPark.Main.Forms.Login;
using uniPark.Main.Forms.Landing;
using uniPark.Main;

namespace uniPark
{
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();

            MaterialClass.material(this);
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IconsPage ip = new IconsPage();
            ip.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            Form2 test = this;
            login.Show();
            test.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmLanding landing = new frmLanding();
            landing.Show();
            Form2 test = this;
            test.Hide();
        }
    }
}
