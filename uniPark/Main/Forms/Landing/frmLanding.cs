using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uniPark.Main.Forms.Login;

namespace uniPark.Main.Forms.Landing
{
    public partial class frmLanding : Form
    {
        bool hidden;
         
        public frmLanding()
        {
            InitializeComponent();
            hidden = false;

            /* ==================================
             * Designing of material DataGridView
             * ================================== */
            /* changes table visuals */
            dgvParkings.BorderStyle = BorderStyle.None;
            dgvParkings.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 252, 232);
            dgvParkings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvParkings.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvParkings.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvParkings.BackgroundColor = Color.FromArgb(247, 255, 245);

            /* Changes column heading visualas */
            dgvParkings.EnableHeadersVisualStyles = false;
            dgvParkings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvParkings.ColumnHeadersDefaultCellStyle.BackColor = Color.PaleGreen;
            dgvParkings.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            /* Changes column headings to bold */
            dgvParkings.Columns[0].HeaderCell.Style.Font = new Font("MS Reference Sans Serif", 10F, FontStyle.Bold);
            dgvParkings.Columns[1].HeaderCell.Style.Font = new Font("MS Reference Sans Serif", 10F, FontStyle.Bold);

            /* Hides all pannels on start */
            pnlViewParkings.Hide();
        }

        private void matBtnMenu_Click(object sender, EventArgs e)
        {   /* When button is pressed, slides the panel to the left, right */
            if (hidden)
            {
                while (pnlMenu.Width != 207)
                {
                    pnlMenu.Width += 1;
                    System.Threading.Thread.Sleep(1);
                    pnlMenu.Refresh();
                    hidden = false;
                }
            }
            else
            {
                while (pnlMenu.Width != 54)
                {
                    pnlMenu.Width -= 1;
                    System.Threading.Thread.Sleep(1);
                    pnlMenu.Refresh();
                    hidden = true;
                }
            }
        }

        private void matBtnMinimize_Click(object sender, EventArgs e)
        {
            /* Minimizes application */
            this.WindowState = FormWindowState.Minimized;
        }

        private void matBtnLogout_Click(object sender, EventArgs e)
        {
            /* Closes landing form
             * Shows Login Form */
            frmLanding landing = this;
            landing.Close();

            frmLogin login = new frmLogin();
            login.Show();
        }

        private void matBtnViewParking_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "View Parkings";

            pnlViewParkings.Show();
            pnlViewParkings.Dock = DockStyle.Bottom;
        }

        private void matbtnSearchParking_Click(object sender, EventArgs e)
        {
        }

        private void lblHeadings_Click(object sender, EventArgs e)
        {

        }
    }
}
