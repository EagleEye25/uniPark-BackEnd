using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uniPark.Main.Forms.Loading;

namespace uniPark.Main.Forms.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void matTextUsername_Click(object sender, EventArgs e)
        {
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            /* Exits the application */ 
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Minimizes the application */
            this.WindowState = FormWindowState.Minimized;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblIncorrect.Visible = false;
        }

        private void matBtnLogin_Click(object sender, EventArgs e)
        {
            /* Showing loading form, hiding login form */
            frmLoading loading = new frmLoading();
            frmLogin login = this;
            login.Hide();
            loading.Show();
        }
    }
}
