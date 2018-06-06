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
using TypeLib.Models;
using TypeLib.ViewModels;
using TypeLib.Interfaces;
using uniPark_BLL;


namespace uniPark.Main.Forms.Landing
{
    public partial class frmLanding : Form
    {
        bool hidden;


    private void DGVload(DataGridView dgvName)
        {
            /* ==================================
            * Designing of material DataGridView
            * ================================== */
            /* changes table visuals */
            dgvName.BorderStyle = BorderStyle.None;
            dgvName.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 252, 232);
            dgvName.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvName.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvName.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvName.BackgroundColor = Color.FromArgb(247, 255, 245);

            /* Changes column heading visualas */
            dgvName.EnableHeadersVisualStyles = false;
            dgvName.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvName.ColumnHeadersDefaultCellStyle.BackColor = Color.PaleGreen;
            dgvName.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            
        }
        private void DGVBoldHeadings(DataGridView dgvName)
        {
            /* Changes column headings to bold */
            dgvName.Columns[0].HeaderCell.Style.Font = new Font("MS Reference Sans Serif", 10F, FontStyle.Bold);
            dgvName.Columns[1].HeaderCell.Style.Font = new Font("MS Reference Sans Serif", 10F, FontStyle.Bold);
        }
        public frmLanding()
        {
            InitializeComponent();
            hidden = false;

            /*the datagridview loaded on initial startup*/
            DGVload(dgvParkings);

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
            pnlVerifyGuest.Hide();
         /* ======================== */
        }

        //Method for hide all panels, but one.
        private void PanelVisible(string panelName)
        {
            List<Panel> landingPanels = new List<Panel>();
            landingPanels.Add(pnlViewParkings);
            landingPanels.Add(pnlSearchParkings);
            landingPanels.Add(pnlUpdateParkings);
            landingPanels.Add(pnlAssignParkings);
            landingPanels.Add(pnlViewUsers);
            landingPanels.Add(pnlAddUsers);
            landingPanels.Add(pnlSearchUsers);
            landingPanels.Add(pnlEditUser);
            landingPanels.Add(pnlAddParkings);
            landingPanels.Add(pnlVerifyGuest);
            
            foreach (Panel p in landingPanels)
            {
                if (p.Name == panelName)
                {
                    p.Visible = true;
                    p.Dock = DockStyle.Fill;
                }
                else
                    p.Visible = false;
            }
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
         
            PanelVisible("pnlViewParkings");

            /*Connecting data to datagrid*/

            IDBHandler handler = new DBHandler();

            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();
            
            dgvParkings.DataSource = dt;
          // cmbParkingAreas.DataSource = dt;
          // cmbParkingAreas.DisplayMember = "ParkingAreaName";
          // cmbParkingAreas.ValueMember = "ParkingAreaID";
            

        }

        private void matbtnSearchParking_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Search Parkings";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlSearchParkings");

            /*Connecting data to combobox*/
            IDBHandler handler = new DBHandler();

            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();
    
             cmbParkingAreas.DataSource = dt;
             cmbParkingAreas.DisplayMember = "ParkingAreaName";
             cmbParkingAreas.ValueMember = "ParkingAreaID";
        }

        private void lblHeadings_Click(object sender, EventArgs e)
        {

        }

        private void matTextParkingName_Click(object sender, EventArgs e)
        {
            /* sets the text of the textbox to nothing */
            //matTextParkingName.Text = "";
        }

        private void matTextParkingName_Leave(object sender, EventArgs e)
        {
            
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
            PanelVisible("pnlUpdateParkings");
            

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
            PanelVisible("pnlAssignParkings");
           
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
            PanelVisible("pnlViewUsers");

            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            dt = handler.BLL_GetPersonel();
            dgvViewUsers.DataSource = dt;
            
        }

        private void matBtnAddUser_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Add Personel";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlAddUsers");

            IDBHandler handler = new DBHandler();
            DataTable dt1 = handler.BLL_GetLevels();
            cmbPersonelLevel.DataSource = dt1;
            cmbPersonelLevel.DisplayMember = "PersonnelLevelDesc";
            cmbPersonelLevel.ValueMember = "PersonnelLevelID";

            IDBHandler handler2 = new DBHandler();
            DataTable dt2 = handler2.BLL_GetTypes();
            cmbPersonelType.DataSource = dt2;
            cmbPersonelType.ValueMember = "PersonnelTypeID";
            cmbPersonelType.DisplayMember = "PersonnelTypeDesc";
        


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
            //matTextPersonelType.Text = "";
        }

        private void matTextPersonelType_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data 
            if (matTextPersonelType.Text != "")
                matTextPersonelType.Text = matTextPersonelType.Text;
            else
                matTextPersonelType.Text = "Personel Type";*/
        }

        private void matTextPersonelLevel_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
           // matTextPersonelLevel.Text = "";
        }

        private void matTextPersonelLevel_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data 
            if (matTextPersonelLevel.Text != "")
                matTextPersonelLevel.Text = matTextPersonelLevel.Text;
            else
                matTextPersonelLevel.Text = "Personel Level"; */
        }

        private void matBtnSearchUser_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Search Personel";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlSearchUsers");
            
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
            PanelVisible("pnlEditUser");
            
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
            PanelVisible("pnlAddParkings");
            
        }

        private void matBtnVerifyGuest_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Verify Guest";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlVerifyGuest");
           
        }

        private void matTextGuestVerifyNo_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextGuestVerifyNo.Text = "";
        }

        private void matTextGuestVerifyNo_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextGuestVerifyNo.Text != "")
                matTextGuestVerifyNo.Text = matTextGuestVerifyNo.Text;
            else
                matTextGuestVerifyNo.Text = "Guest Verification Number";
        }

        private void matTextGuestName_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextGuestName.Text = "";
        }

        private void matTextGuestName_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextGuestName.Text != "")
                matTextGuestName.Text = matTextGuestName.Text;
            else
                matTextGuestName.Text = "Guest Name";
        }

        private void matTextGuestSurname_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextGuestSurname.Text = "";
        }

        private void matTextGuestSurname_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextGuestSurname.Text != "")
                matTextGuestSurname.Text = matTextGuestSurname.Text;
            else
                matTextGuestSurname.Text = "Guest Surname";
        }

        private void matTextGuestType_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextGuestType.Text = "";
        }

        private void matTextGuestType_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextGuestType.Text != "")
                matTextGuestType.Text = matTextGuestType.Text;
            else
                matTextGuestType.Text = "Guest Type";
        }

        private void matTextGuestLevel_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextGuestLevel.Text = "";
        }

        private void matTextGuestLevel_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextGuestLevel.Text != "")
                matTextGuestLevel.Text = matTextGuestLevel.Text;
            else
                matTextGuestLevel.Text = "Guest Access Level";
        }

        private void cmbParkingAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Getting paramaters from ParkingAreas combobox*/
            string parkingAreaID;
            parkingAreaID = cmbParkingAreas.SelectedValue.ToString();

            /*Connecting data to ParkingSpace combobox*/
            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            
            dt = handler.BLL_GetParkingSpaces(parkingAreaID);
            
            cmbParkingSpace.DataSource = dt;
            cmbParkingSpace.DisplayMember = "ParkingSpaceID";
            cmbParkingSpace.ValueMember = "ParkingSpaceID";

        }

        private void dgvParkings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvParkings_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvParkings.SelectedRows.Count > 0)
            {
                string parkindAreaID;
                parkindAreaID = dgvParkings.SelectedRows[0].Cells["ParkingAreaID"].Value.ToString();

                IDBHandler handler = new DBHandler();
                DataTable dt = new DataTable();
               dt = handler.BLL_GetParkingSpaces(parkindAreaID);
             
                dgvParkings.DataSource = dt;
                
                
            }
        }

        private void dgvSearchParkings_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void cmbParkingSpace_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*Get Parameter for ParkingSpace details*/
            string parkindAreaID = cmbParkingAreas.SelectedValue.ToString();
            string parkingSearchID = cmbParkingSpace.SelectedValue.ToString();

            IDBHandler handler = new DBHandler();
                DataTable dt = new DataTable();
                dt = handler.BLL_SearchParkingSpaceDetails(parkindAreaID,parkingSearchID);

                dgvSearchParkings.DataSource = dt;
            }

        private void matBtnAddUsers_Click(object sender, EventArgs e)
        {
            bool success = false;
            try
            {
                IDBHandler handler = new DBHandler();
                success = handler.BLL_AddPersonel(matTextPersonelName.Text, matTextPersonelTagNo.Text, mattextPassword.Text, matTextPersonelSurname.Text, matTextPersonelName.Text, mattextPhoneNum.Text, mattextEmail.Text, (int)cmbPersonelLevel.SelectedValue, (int)cmbPersonelType.SelectedValue);
            }
            catch
            {
                MessageBox.Show("Failure");
            }
            if (success == true)
            {
                MessageBox.Show("Successfully added user");
            }
            else { MessageBox.Show("Failure to add user"); }

        }

        private void mattextUserID_Click(object sender, EventArgs e)
        {
            mattextUserID.Text = "";
        }

        private void mattextPassword_Click(object sender, EventArgs e)
        {
            mattextPassword.Text = "";
            mattextPassword.PasswordChar = '*';
        }

        private void mattextUserID_Leave_1(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (mattextUserID.Text != "")
                mattextUserID.Text = mattextUserID.Text;
            else
                mattextUserID.Text = "User ID";
        }

        private void mattextPassword_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (mattextPassword.Text != "")
                mattextPassword.Text = mattextPassword.Text;
            else
            {
                mattextPassword.Text = "Password";
                mattextPassword.PasswordChar = '\0';
            }

        }

        private void frmLanding_Load(object sender, EventArgs e)
        {



            
            
        }

        private void mattextPhoneNum_Leave(object sender, EventArgs e)
        {
            if (mattextPhoneNum.Text != "")
                mattextPhoneNum.Text = mattextPhoneNum.Text;
            else
            {
                mattextPhoneNum.Text = "Personel Phone Number";
            }
        }

        private void mattextEmail_Leave(object sender, EventArgs e)
        {
            if (mattextEmail.Text != "")
                mattextEmail.Text = mattextEmail.Text;
            else
            {
                mattextEmail.Text = "Personel Email";

            }
        }

        private void mattextPhoneNum_Click(object sender, EventArgs e)
        {
            mattextPhoneNum.Text = "";
        }

        private void mattextEmail_Click(object sender, EventArgs e)
        {
            mattextEmail.Text = "";
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}