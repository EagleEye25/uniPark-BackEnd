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
            /*=======================================================================================================*/

            /* Sets defualt headding */
            lblHeadings.Text = "Please select an option...";

          /* ==========================
          * Hides all pannels on start
          * ========================== */
            pnlViewParkings.Hide();
            pnlSearchParkings.Hide();
            pnlUpdateParkings.Hide();
            pnlAssignParkings.Hide();
            pnlViewUsers.Hide();
            pnlAddUsers.Hide();
            pnlSearchUsers.Hide();
            pnlEditUser.Hide();
            pnlAddParkings.Hide();
         /* ======================== */
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

            /* Hides other panels, shows View Parkings */
            pnlViewParkings.Show();
            pnlSearchParkings.Hide();
            pnlUpdateParkings.Hide();
            pnlAssignParkings.Hide();
            pnlViewUsers.Hide();
            pnlAddUsers.Hide();
            pnlSearchUsers.Hide();
            pnlEditUser.Hide();
            pnlAddParkings.Hide();
            pnlViewParkings.Dock = DockStyle.Fill;
        }

        private void matbtnSearchParking_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Search Parkings";

            /* Hides other panels, shows View Parkings */
            pnlViewParkings.Hide();
            pnlSearchParkings.Show();
            pnlUpdateParkings.Hide();
            pnlAssignParkings.Hide();
            pnlViewUsers.Hide();
            pnlAddUsers.Hide();
            pnlSearchUsers.Hide();
            pnlEditUser.Hide();
            pnlAddParkings.Hide();
            pnlSearchParkings.Dock = DockStyle.Fill;
        }

        private void lblHeadings_Click(object sender, EventArgs e)
        {

        }

        private void matTextParkingName_Click(object sender, EventArgs e)
        {
            /* sets the text of the textbox to nothing */
            matTextParkingName.Text = "";
        }

        private void matTextParkingName_Leave(object sender, EventArgs e)
        {
            if (matTextParkingName.Text != "")
                matTextParkingName.Text = matTextParkingName.Text;
            else
                matTextParkingName.Text = "Enter Parking Number";
        }

        private void matTextParkingAreaID_Click(object sender, EventArgs e)
        {
            matTextParkingAreaID.Text = "";
        }

        private void matTextParkingAreaID_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingAreaID.Text != "")
                matTextParkingAreaID.Text = matTextParkingAreaID.Text;
            else
                matTextParkingAreaID.Text = "Parking Area ID";
        }

        private void matbtnUpdateParking_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Update Parkings";

            /* Hides other panels, shows View Parkings */
            pnlViewParkings.Hide();
            pnlSearchParkings.Hide();
            pnlUpdateParkings.Show();
            pnlAssignParkings.Hide();
            pnlViewUsers.Hide();
            pnlAddUsers.Hide();
            pnlSearchUsers.Hide();
            pnlEditUser.Hide();
            pnlAddParkings.Hide();
            pnlUpdateParkings.Dock = DockStyle.Fill;
        }

        private void matTextParkingAreaName_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextParkingAreaName.Text = "";
        }

        private void matTextParkingAreaName_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingAreaName.Text != "")
                matTextParkingAreaName.Text = matTextParkingAreaName.Text;
            else
                matTextParkingAreaName.Text = "Parking Area Name";
        }

        private void matTextParkingAreaAL_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextParkingAreaAL.Text = "";
        }

        private void matTextParkingAreaAL_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingAreaAL.Text != "")
                matTextParkingAreaAL.Text = matTextParkingAreaAL.Text;
            else
                matTextParkingAreaAL.Text = "Parking Area Access Level";
        }

        private void matTextParkingNameAS_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextParkingNameAS.Text = "";
        }

        private void matTextParkingNameAS_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingNameAS.Text != "")
                matTextParkingNameAS.Text = matTextParkingNameAS.Text;
            else
                matTextParkingNameAS.Text = "Parking Area Name";
        }

        private void matbtnAssignParking_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Assign Parkings";

            /* Hides other panels, shows View Parkings */
            pnlViewParkings.Hide();
            pnlSearchParkings.Hide();
            pnlUpdateParkings.Hide();
            pnlAssignParkings.Show();
            pnlViewUsers.Hide();
            pnlAddUsers.Hide();
            pnlSearchUsers.Hide();
            pnlEditUser.Hide();
            pnlAddParkings.Hide();
            pnlAssignParkings.Dock = DockStyle.Fill;
        }

        private void matTextFacilityNoAS_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextFacilityNoAS.Text = "";
        }

        private void matTextFacilityNoAS_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextFacilityNoAS.Text != "")
                matTextFacilityNoAS.Text = matTextFacilityNoAS.Text;
            else
                matTextFacilityNoAS.Text = "User Facility Number";
        }

        private void matBtnViewUsers_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "View Personel";

            /* Hides other panels, shows View Parkings */
            pnlViewParkings.Hide();
            pnlSearchParkings.Hide();
            pnlUpdateParkings.Hide();
            pnlAssignParkings.Hide();
            pnlViewUsers.Show();
            pnlAddUsers.Hide();
            pnlSearchUsers.Hide();
            pnlEditUser.Hide();
            pnlAddParkings.Hide();
            pnlViewUsers.Dock = DockStyle.Fill;
        }

        private void matBtnAddUser_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Add Personel";

            /* Hides other panels, shows View Parkings */
            pnlViewParkings.Hide();
            pnlSearchParkings.Hide();
            pnlUpdateParkings.Hide();
            pnlAssignParkings.Hide();
            pnlViewUsers.Hide();
            pnlAddUsers.Show();
            pnlSearchUsers.Hide();
            pnlEditUser.Hide();
            pnlAddParkings.Hide();
            pnlAddUsers.Dock = DockStyle.Fill;
        }

        private void matTextPersonelTagNo_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelTagNo.Text = "";
        }

        private void matTextPersonelTagNo_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelTagNo.Text != "")
                matTextPersonelTagNo.Text = matTextPersonelTagNo.Text;
            else
                matTextPersonelTagNo.Text = "Perosnel Tag Number";
        }

        private void matTextPersonelName_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelName.Text = "";
        }

        private void matTextPersonelName_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelName.Text != "")
                matTextPersonelName.Text = matTextPersonelName.Text;
            else
                matTextPersonelName.Text = "Personel Name";
        }

        private void matTextPersonelSurname_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelSurname.Text = "";
        }

        private void matTextPersonelSurname_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelSurname.Text != "")
                matTextPersonelSurname.Text = matTextPersonelSurname.Text;
            else
                matTextPersonelSurname.Text = "Personel Surname";
        }

        private void matTextPersonelType_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelType.Text = "";
        }

        private void matTextPersonelType_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelType.Text != "")
                matTextPersonelType.Text = matTextPersonelType.Text;
            else
                matTextPersonelType.Text = "Personel Type";
        }

        private void matTextPersonelLevel_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelLevel.Text = "";
        }

        private void matTextPersonelLevel_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelLevel.Text != "")
                matTextPersonelLevel.Text = matTextPersonelLevel.Text;
            else
                matTextPersonelLevel.Text = "Personel Level";
        }

        private void matBtnSearchUser_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Search Personel";

            /* Hides other panels, shows View Parkings */
            pnlViewParkings.Hide();
            pnlSearchParkings.Hide();
            pnlUpdateParkings.Hide();
            pnlAssignParkings.Hide();
            pnlViewUsers.Hide();
            pnlAddUsers.Hide();
            pnlSearchUsers.Show();
            pnlEditUser.Hide();
            pnlAddParkings.Hide();
            pnlSearchUsers.Dock = DockStyle.Fill;
        }

        private void matTextSearchUsers_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextSearchUsers.Text = "";
        }

        private void matTextSearchUsers_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextSearchUsers.Text != "")
                matTextSearchUsers.Text = matTextSearchUsers.Text;
            else
                matTextSearchUsers.Text = "Enter Personel Number";
        }

        private void matTextPersonelTagNoED_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelTagNoED.Text = "";
        }

        private void matTextPersonelTagNoED_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelTagNoED.Text != "")
                matTextPersonelTagNoED.Text = matTextPersonelTagNoED.Text;
            else
                matTextPersonelTagNoED.Text = "Personel Tag Number";
        }

        private void matTextPersonelNameED_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelNameED.Text = "";
        }

        private void matTextPersonelNameED_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelNameED.Text != "")
                matTextPersonelNameED.Text = matTextPersonelNameED.Text;
            else
                matTextPersonelNameED.Text = "Personel Name";
        }

        private void matTextPersonelSurED_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelSurED.Text = "";
        }

        private void matTextPersonelSurED_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelSurED.Text != "")
                matTextPersonelSurED.Text = matTextPersonelSurED.Text;
            else
                matTextPersonelSurED.Text = "Personel Surname";
        }

        private void matTextPersonelTypeED_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelTypeED.Text = "";
        }

        private void matTextPersonelTypeED_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelTypeED.Text != "")
                matTextPersonelTypeED.Text = matTextPersonelTypeED.Text;
            else
                matTextPersonelTypeED.Text = "Personel Type";
        }

        private void matTextPersonelLvlED_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextPersonelLvlED.Text = "";
        }

        private void matTextPersonelLvlED_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextPersonelLvlED.Text != "")
                matTextPersonelLvlED.Text = matTextPersonelLvlED.Text;
            else
                matTextPersonelLvlED.Text = "Personel level";
        }

        private void matBtnEditUser_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Edit Personel";

            /* Hides other panels, shows View Parkings */
            pnlViewParkings.Hide();
            pnlSearchParkings.Hide();
            pnlUpdateParkings.Hide();
            pnlAssignParkings.Hide();
            pnlViewUsers.Hide();
            pnlAddUsers.Hide();
            pnlSearchUsers.Hide();
            pnlEditUser.Show();
            pnlAddParkings.Hide();
            pnlEditUser.Dock = DockStyle.Fill;
        }

        private void matTextParkingAreaNameAD_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextParkingAreaNameAD.Text = "";
        }

        private void matTextParkingAreaNameAD_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingAreaNameAD.Text != "")
                matTextParkingAreaNameAD.Text = matTextParkingAreaNameAD.Text;
            else
                matTextParkingAreaNameAD.Text = "Parking Area Name";
        }

        private void matTextParkingAreaALAD_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextParkingAreaALAD.Text = "";
        }

        private void matTextParkingAreaALAD_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingAreaALAD.Text != "")
                matTextParkingAreaALAD.Text = matTextParkingAreaALAD.Text;
            else
                matTextParkingAreaALAD.Text = "Parking Area Access Level";
        }

        private void matBtnAddParking_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Add Parkings";

            /* Hides other panels, shows View Parkings */
            pnlViewParkings.Hide();
            pnlSearchParkings.Hide();
            pnlUpdateParkings.Hide();
            pnlAssignParkings.Hide();
            pnlViewUsers.Hide();
            pnlAddUsers.Hide();
            pnlSearchUsers.Hide();
            pnlEditUser.Hide();
            pnlAddParkings.Show();
            pnlAddParkings.Dock = DockStyle.Fill;
        }
    }
}