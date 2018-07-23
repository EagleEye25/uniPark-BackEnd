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
using uniPark.Main;
using MaterialSkin;
using MaterialSkin.Controls;



namespace uniPark.Main.Forms.Landing
{
    public partial class frmLanding : MaterialForm
    {
        bool hidden;
        bool selectSpaces = false;
        bool selectedSpace = false;
        bool UpadteParkingArea = false;


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
            DGVload(dgvAddParkings);
            DGVload(dgvAssignParkings);
            DGVload(dgvViewUsers);
            DGVload(dgvSearchParkings);
            DGVload(dgvSearchUsers);
            DGVload(dgvEditPersonel);
            DGVload(dgvUpdateParkings);
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
            MaterialClass.material(this);
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

            dgvParkings.Dock = DockStyle.Fill;
            
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
            matTextParkingAreaINameUpadate.Text = "";
        }

        private void matTextParkingAreaID_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingAreaINameUpadate.Text != "")
                matTextParkingAreaINameUpadate.Text = matTextParkingAreaINameUpadate.Text;
            else
                matTextParkingAreaINameUpadate.Text = "Parking Area ID";
        }

        private void matbtnUpdateParking_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Update Parkings";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlUpdateParkings");

            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();
            dgvUpdateParkings.DataSource = dt;
        

            

        }

        private void matTextParkingAreaName_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextParkingAreaLocationUpdate.Text = "";
        }

        private void matTextParkingAreaName_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingAreaLocationUpdate.Text != "")
                matTextParkingAreaLocationUpdate.Text = matTextParkingAreaLocationUpdate.Text;
            else
                matTextParkingAreaLocationUpdate.Text = "Parking Area Name";
        }

        private void matTextParkingAreaAL_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
            matTextParkingAreaALUpdate.Text = "";
        }

        private void matTextParkingAreaAL_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingAreaALUpdate.Text != "")
                matTextParkingAreaALUpdate.Text = matTextParkingAreaALUpdate.Text;
            else
                matTextParkingAreaALUpdate.Text = "Parking Area Access Level";
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
            lblHeadings.Text = "View Personnel";

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
            lblHeadings.Text = "Add Personnel";

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
                matTextPersonelTagNo.Text = "Perosnnel Tag Number";
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
                matTextPersonelName.Text = "Personnel Name";
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
                matTextPersonelSurname.Text = "Personnel Surname";
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
            lblHeadings.Text = "Search Personnel";

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
                matTextSearchUsers.Text = "Enter Personnel Number";
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
                matTextPersonelTagNoED.Text = "Personnel Tag Number";
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
                matTextPersonelNameED.Text = "Personnel Name";
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
                matTextPersonelSurED.Text = "Personnel Surname";
        }

        private void matTextPersonelTypeED_Click(object sender, EventArgs e)
        {

        }

        private void matTextPersonelTypeED_Leave(object sender, EventArgs e)
        {

        }

        private void matTextPersonelLvlED_Click(object sender, EventArgs e)
        {

        }

        private void matTextPersonelLvlED_Leave(object sender, EventArgs e)
        {

        }

        private void matBtnEditUser_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Edit Personel";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlEditUser");

            IDBHandler handler = new DBHandler();
            DataTable dt1 = handler.BLL_GetLevels();
            cmbPersonnelLevelEdit.DataSource = dt1;
            cmbPersonnelLevelEdit.DisplayMember = "PersonnelLevelDesc";
            cmbPersonnelLevelEdit.ValueMember = "PersonnelLevelID";

            IDBHandler handler2 = new DBHandler();
            DataTable dt2 = handler2.BLL_GetTypes();
            cmbPersonnelTypeEdit.DataSource = dt2;
            cmbPersonnelTypeEdit.ValueMember = "PersonnelTypeID";
            cmbPersonnelTypeEdit.DisplayMember = "PersonnelTypeDesc";

            IDBHandler handler3 = new DBHandler();
            DataTable dt3 = handler3.BLL_GetPersonel();
            dgvEditPersonel.DataSource = dt3;


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
            
        }

        private void matTextParkingAreaALAD_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */

        }

        private void matBtnAddParking_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Add Parkings";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlAddParkings");

            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();

            dgvAddParkings.DataSource = dt;

            
            
        }

        private void matBtnVerifyGuest_Click(object sender, EventArgs e)
        {
            /* will change heading title */
            lblHeadings.Text = "Verify Guest";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlVerifyGuest");

            matBtnVerifyGuests.Enabled = false;

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

                dgvParkings.Dock = DockStyle.None;
                matBtnBackToParkingAreas.Visible = true;

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
            if (mattextUserID.Text != "" && matTextPersonelTagNo.Text != ""&& mattextPassword.Text != ""&& matTextPersonelSurname.Text != "" && matTextPersonelName.Text != "" && mattextPhoneNum.Text != ""&& mattextEmail.Text != ""
                && mattextUserID.Text != "User ID" && matTextPersonelTagNo.Text != "Personel Tag Number" && mattextPassword.Text != "Password" && matTextPersonelSurname.Text != "Personnel Surname" && matTextPersonelName.Text != "Personel Name" && mattextPhoneNum.Text != "Personnel Phone Number" && mattextEmail.Text != "Personnel Email")
            {
                bool success = false;
                try
                {
                    IDBHandler handler = new DBHandler();
                    success = handler.BLL_AddPersonel(mattextUserID.Text, matTextPersonelTagNo.Text, mattextPassword.Text, matTextPersonelSurname.Text, matTextPersonelName.Text, mattextPhoneNum.Text, mattextEmail.Text, (int)cmbPersonelLevel.SelectedValue, (int)cmbPersonelType.SelectedValue);
                }
                catch
                {
                    MessageBox.Show("Failed to add user");
                }
                if (success == true)
                {
                    MessageBox.Show("Successfully added user");
                }
                else { MessageBox.Show("Failed to add user"); }
            }
            else { MessageBox.Show("Failed to add user"); }

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
                mattextPhoneNum.Text = "Personnel Phone Number";
            }
        }

        private void mattextEmail_Leave(object sender, EventArgs e)
        {
            if (IsEmail2(mattextEmail.Text) == true)
                mattextEmail.Text = mattextEmail.Text;
            else
            {
                mattextEmail.Text = "Personnel Email";

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

        private void matBtnEditUsers_Click(object sender, EventArgs e)
        {

        }

        private void pnlAddUsers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void matbtnEmailedit_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (IsEmail2(matbtnEmailedit.Text)==true)
                matbtnEmailedit.Text = matbtnEmailedit.Text;
            else
                matbtnEmailedit.Text = "Personnel Email";
        }

        private void matbtnEmailedit_Click(object sender, EventArgs e)
        {
            matbtnEmailedit.Text = "";
        }

        private void dgvEditPersonel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEditPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dgvEditPersonel[0, dgvEditPersonel.CurrentRow.Index].Value.ToString();
            matTextPersonelTagNoED.Text = ID;

            //
            IDBHandler handler = new DBHandler();
            uspGetAllInfo get = new uspGetAllInfo();

            get = handler.BLL_getallinfo(ID);

            //load data into controlls
            matTextPersonelNameED.Text = get.PersonnelName;
            matTextPersonelSurED.Text = get.PersonnelSurname;
            matbtnEmailedit.Text = get.PersonnelEmail;

            cmbPersonnelLevelEdit.SelectedValue = get.PersonnelLevelID;
            cmbPersonnelTypeEdit.SelectedValue = get.PersonnelTypeID;
        }

        private void matbtnEditPersonnel_Click(object sender, EventArgs e)
        {
            if (matTextPersonelNameED.Text != "Personnel Name" && matTextPersonelTagNoED.Text != "Personnel Tag Number" && matTextPersonelSurED.Text != "Personnel Surname" && matbtnEmailedit.Text != "Personnel Email Address" &&
                matTextPersonelNameED.Text != "" && matTextPersonelTagNoED.Text != "" && matTextPersonelSurED.Text != "" && matbtnEmailedit.Text != "")
            { 
            IDBHandler handler = new DBHandler();
            bool b = handler.BLL_EditPersonel(matTextPersonelNameED.Text, matTextPersonelTagNoED.Text, matTextPersonelSurED.Text, matbtnEmailedit.Text, Convert.ToInt32(cmbPersonnelLevelEdit.SelectedValue), Convert.ToInt32(cmbPersonnelTypeEdit.SelectedValue));
            if (b == true)
            {
                MessageBox.Show("Personel Successfully Edited");
            }
            else { MessageBox.Show("Personel Unsuccessfully Edited"); }

            DataTable dt = handler.BLL_GetPersonel();
            dgvEditPersonel.DataSource = dt;

                matTextPersonelNameED.Text = "Personnel Name";
                matTextPersonelTagNoED.Text = "Personnel Tag Number";
                matTextPersonelSurED.Text = "Personnel Surname";
                matbtnEmailedit.Text = "Personnel Email Address";
            }
            else { MessageBox.Show("Personel Unsuccessfully Edited"); }
    }

        private void matBtnGenGuestNo_Click(object sender, EventArgs e)
        {
            bool b = false;
            while (b == false)
            {
                string random = RandomDigits(4);

                matTextGuestVerifyNo.Text = random;

                IDBHandler handler = new DBHandler();
                if (handler.BLL_checkguest(matTextGuestVerifyNo.Text) == null)
                {
                    MessageBox.Show("guest verification id valid");
                    matBtnVerifyGuests.Enabled = true;
                    b = true;
                }
                else
                {
                    MessageBox.Show("guest verification id already taken");
                    matTextGuestVerifyNo.Text = "";
                    matBtnVerifyGuests.Enabled = false;
                }
            }

        }

        private void pnlVerifyGuest_Paint(object sender, PaintEventArgs e)
        {

        }
        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        private void matBtnVerifyGuests_Click(object sender, EventArgs e)
        {
            string password = "guest" + matTextGuestVerifyNo.Text;



            if (matTextGuestSurname.Text != "Guest Surname" && matTextGuestName.Text != "Guest Name" && matTextPhoneGuest.Text != "Guest Phone" && matTextEmailGuest.Text != "Guest Email Address" &&
            matTextGuestVerifyNo.Text != "Guest Verification Number" && matTextGuestSurname.Text != "" && matTextGuestName.Text != "" && matTextPhoneGuest.Text != "" && matTextEmailGuest.Text != "" &&
            matTextGuestVerifyNo.Text != "")
            {
                try
                {
                    IDBHandler handler = new DBHandler();
                    bool b = handler.BLL_addguest(matTextGuestVerifyNo.Text, password, matTextGuestSurname.Text, matTextGuestName.Text, matTextPhoneGuest.Text, matTextEmailGuest.Text, 1);
                    if (b == true)
                    {
                        MessageBox.Show("guest added successfully");
                    }
                    else { MessageBox.Show("guest was not added successfully"); }
                }
                catch { MessageBox.Show("guest was not added successfully"); }

                matTextGuestSurname.Text = "Guest Surname";
                matTextGuestName.Text = "Guest Name";
                matTextPhoneGuest.Text = "Guest Phone";
                matTextEmailGuest.Text = "Guest Email Address";
                matTextGuestVerifyNo.Text = "Verify Number";
            }
            else
            {
                matTextGuestSurname.Text = "Guest Surname";
                matTextGuestName.Text = "Guest Name";
                matTextPhoneGuest.Text = "Guest Phone";
                matTextEmailGuest.Text = "Guest Email Address";
                matTextGuestVerifyNo.Text = "Guest Verification Number";
                MessageBox.Show("guest was not added successfully");

            }


        }

        private void matTextPhoneGuest_Leave(object sender, EventArgs e)
        {
            if (matTextPhoneGuest.Text != "")
                matTextPhoneGuest.Text = matTextPhoneGuest.Text;
            else
                matTextPhoneGuest.Text = "Guest Phone Number";
        }

        private void matTextEmailGuest_Leave(object sender, EventArgs e)
        {
            if (IsEmail2(matTextEmailGuest.Text) == true )
            {
                matTextEmailGuest.Text = matTextEmailGuest.Text;

            }
            else
                matTextEmailGuest.Text = "Guest Email";
        }

        private void matTextPhoneGuest_Click(object sender, EventArgs e)
        {
            matTextPhoneGuest.Text = "";
        }

        private void matTextEmailGuest_Click(object sender, EventArgs e)
        {
            matTextEmailGuest.Text = "";
        }

		private void matBtnSearchUsers_Click(object sender, EventArgs e)

        {
            //Search user
            string id = "";
            id = matTextSearchUsers.Text;

            IDBHandler handler = new DBHandler();
            DataTable dt = handler.BLL_GetAllInfo(id);
            
            dgvSearchUsers.DataSource = dt;
        }

        private void matbtnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                IDBHandler handler = new DBHandler();
                DialogResult dialogResult = MessageBox.Show("Delete Personel Member: " + matTextPersonelTagNoED.Text, "Delete Member", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool b = handler.BLL_deleteuser(matTextPersonelTagNoED.Text);
                    MessageBox.Show("Deletion Successfull");
                    DataTable dt3 = handler.BLL_GetPersonel();
                    dgvEditPersonel.DataSource = dt3;  

                }
                else if (dialogResult == DialogResult.No || matTextPersonelTagNoED.Text == "")
                {
                    MessageBox.Show("Deletion Cancelled");
                    DataTable dt3 = handler.BLL_GetPersonel();
                    dgvEditPersonel.DataSource = dt3;
                }           
            }
            catch
            { MessageBox.Show("Deletion could not take place"); }
        }

        private void matBtnAddParkingAreas_Click(object sender, EventArgs e)
        
            {

                IDBHandler handler = new DBHandler();
                ParkingArea PA = new ParkingArea();

                PA.ParkingAreaID = matTextAddParkinAreaID.Text;
                PA.ParkingAreaName = matTextParkingAreaNameAD.Text;
                PA.ParkingAreaLocation = matTextAddParkingLocation.Text;
                PA.ParkingAreaAccessLevel = Convert.ToInt32(spinParkingAl.Value);

                handler.BLL_AddParkingArea(PA);



                for (int c = 0; c <= Convert.ToInt32(spinCoveredParking.Value); c++)
                {
                    handler.BLL_AddPakingSpace("Covered", matTextAddParkinAreaID.Text);
                }
                for (int u = 0; u <= Convert.ToInt32(spinUncoveredParking.Value); u++)
                {
                    handler.BLL_AddPakingSpace("UnCovered", matTextAddParkinAreaID.Text);
                }

                matTextAddParkinAreaID.Clear();
                matTextAddParkinAreaID.Text = "Parking Area ID";
                matTextAddParkingLocation.Clear();
                matTextAddParkingLocation.Text = "Parking Area Location";
                matTextParkingAreaNameAD.Clear();
                matTextParkingAreaNameAD.Text = "Parking Area Name";

                DataTable dt = new DataTable();
                dt = handler.BLL_GetParkingAreas();
                dgvAddParkings.DataSource = dt;
            }


        private void matTextAddParkinAreaID_Click(object sender, EventArgs e)
        {
            //Clear text
            matTextAddParkinAreaID.Text = "";
        }

        private void matTextAddParkingLocation_Click(object sender, EventArgs e)
        {
            //Clear text
            matTextAddParkingLocation.Text = "";
        }

        private void dgvUpdateParkings_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (UpadteParkingArea == true)
            {
                if (dgvUpdateParkings.SelectedRows.Count > 0)
                {
                    string parkingAreaLocation, parkingAreaName, ParkingAL;
                    parkingAreaName = dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaName"].Value.ToString();
                    parkingAreaLocation = dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaLocation"].Value.ToString();
                    ParkingAL = dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaAccessLevel"].Value.ToString();

                    matTextParkingAreaINameUpadate.Text = parkingAreaName;
                    matTextParkingAreaLocationUpdate.Text = parkingAreaLocation;
                    matTextParkingAreaALUpdate.Text = ParkingAL;
                    
                }
            }

            if (selectSpaces == true)
            {
                if (dgvUpdateParkings.SelectedRows.Count > 0)
                {
                    string parkingAreaID;
                    parkingAreaID = dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaID"].Value.ToString();

                    IDBHandler handler = new DBHandler();
                    DataTable dt = new DataTable();
                    dt = handler.BLL_GetParkingSpaces(parkingAreaID);

                    dgvUpdateParkings.DataSource = dt;

                    selectedSpace = true;
                    MessageBox.Show("Please double click parking space row header");
                    selectSpaces = false;
                }
            }

             
        }

        private void matmatBtnEditArea_Click(object sender, EventArgs e)
        {
            pnlUpdateSpace.Visible = false;
            pnlUpdateArea.Visible = true;
            UpadteParkingArea = true;
            selectSpaces = false;
            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();
            dgvUpdateParkings.DataSource = dt;
        }

        private void matBtnEditParkingSpace_Click(object sender, EventArgs e)
        {
            pnlUpdateSpace.Visible = true;
            pnlUpdateArea.Visible = false;
            UpadteParkingArea = false;
            selectSpaces = true;
            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();
            dgvUpdateParkings.DataSource = dt;
            MessageBox.Show("Please select area where parking space is located");
        }

        private void dgvUpdateParkings_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)

         {
            if (selectedSpace == true)
            {
                string available = dgvUpdateParkings.SelectedRows[0].Cells["Available"].Value.ToString();

                if (available == "UnAvailable")
                {
                    cmbAvailibality.SelectedIndex = 2;
                }
                else cmbAvailibality.SelectedIndex = 1;
            }
        }

        private void matBtnUpdateParkingSpace_Click(object sender, EventArgs e)
        {

        }

        private void matbtnHelpEd_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Editing or deleting a Personnel Member.pdf");
            }
            catch { }
        }

        private bool IsEmail2(string email)
        {
            bool b = TestEmail.IsEmail(email);

            if (b == true)
            { MessageBox.Show("Valid email entered"); }
            else { MessageBox.Show("Invalid email entered"); }


            return b;  
        }

        private void matBtnBackToParkingAreas_Click(object sender, EventArgs e)
        {
            matBtnBackToParkingAreas.Visible = false;
            IDBHandler handler = new DBHandler();

            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();

            dgvParkings.DataSource = dt;
            dgvParkings.Dock = DockStyle.Fill;
        }
    }
}