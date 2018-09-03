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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.CacheProviders;
using GMap.NET.ObjectModel;
using GMap.NET.WindowsForms.Markers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace uniPark.Main.Forms.Landing
{
    public partial class frmLanding : MaterialForm
    {
        bool hidden;
        bool selectSpaces = false;
        bool selectedSpace = false;
        bool UpadteParkingArea = false;

        string parkingAreaIDMap; //global var for single area of map
        string UpParkingAreaID; // global var for update
        int UpSpaceID; // global var for update
        string NewCoordinates = "", TempCoordinates = ""; // used for adding and editing parking areas
        int PolyCount = 0; // used for adding and editing parking areas
        bool On_Add = true;
       
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
            pnlViewInfringements.Hide();
            pnlAddUsers.Hide();
            pnlSearchUsers.Hide();
            pnlEditUser.Hide();
            pnlAddParkings.Hide();
            pnlVerifyGuest.Hide();
            pnlMap.Hide();
            /* ======================== */
            MaterialClass.material(this);

            //Load Main Map 
            mapMain.Dock = DockStyle.Fill;
        }

        //Method for hide all panels, but one.
        private void PanelVisible(string panelName)
        {
            
            List<Panel> landingPanels = new List<Panel>();
            landingPanels.Add(pnlViewParkings);
            landingPanels.Add(pnlSearchParkings);
            landingPanels.Add(pnlUpdateParkings);
            landingPanels.Add(pnlAssignParkings);
            landingPanels.Add(pnlViewInfringements);
            landingPanels.Add(pnlAddUsers);
            landingPanels.Add(pnlSearchUsers);
            landingPanels.Add(pnlEditUser);
            landingPanels.Add(pnlAddParkings);
            landingPanels.Add(pnlVerifyGuest);
            landingPanels.Add(pnlMap);
            landingPanels.Add(pnlAdd_EditMap);

            
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
                    pnlMenu.Width += 5;
                    System.Threading.Thread.Sleep(1);
                    pnlMenu.Refresh();
                    hidden = false;
                    btnclose.Location = new Point(1039, 0);
                }
            }
            else
            {
                while (pnlMenu.Width != 57)
                {
                    pnlMenu.Width -= 5;
                    btnclose.Location = new Point(1039 + 153, 0);
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
            mapMain.Hide();
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
            mapSearch.Overlays.Clear();
            mapMain.Hide();
            mapSearch.Visible = true;
            dgvAddParkings.Visible = false;
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

            //..... Map Implementation.....

            string location = "";
            double dlat = -34.002328, dlong = 25.669922;

            mapSearch.ShowCenter = false;
            mapSearch.DragButton = MouseButtons.Left;

            mapSearch.MinZoom = 5;
            mapSearch.MaxZoom = 100;
            mapSearch.Zoom = 15;

            mapSearch.MapProvider = GMapProviders.GoogleMap;
            mapSearch.Position = new PointLatLng(dlat, dlong);




            

            List<ParkingArea> list = new List<ParkingArea>();

            list = handler.BLL_GetAllParkingAreaDetails();


            foreach (ParkingArea PA in list)
            {
                string[] arraypoints;
                if (PA.ParkingAreaCoordinates != "")
                {
                    location = PA.ParkingAreaCoordinates;
                    arraypoints = location.Split(',');

                    string lat = arraypoints[0];
                    dlat = Convert.ToDouble(lat, CultureInfo.InvariantCulture);
                    string lng = arraypoints[1];
                    dlong = Convert.ToDouble(arraypoints[1], CultureInfo.InvariantCulture);

                    mapSearch.MapProvider = GMapProviders.GoogleMap;

                    mapSearch.Position = new PointLatLng(dlat, dlong);
                    PointLatLng point = new PointLatLng(dlat, dlong);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);


                    marker.ToolTipText = PA.ParkingAreaName + " Access Level - " + Convert.ToString(PA.ParkingAreaAccessLevel);
                    marker.ToolTip.Fill = Brushes.Black;
                    marker.ToolTip.Foreground = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Black;
                    marker.ToolTip.TextPadding = new Size(20, 20);

                    GMapOverlay markers = new GMapOverlay("markers");
                    markers.Markers.Add(marker);
                    mapSearch.Overlays.Add(markers);

                    List<PointLatLng> points = new List<PointLatLng>();
                    for (int i = 2; i < arraypoints.Length - 1; i += 2)
                    {
                        dlat = Convert.ToDouble(arraypoints[i], CultureInfo.InvariantCulture);
                        dlong = Convert.ToDouble(arraypoints[i + 1], CultureInfo.InvariantCulture);
                        points.Add(new PointLatLng(dlat, dlong));

                    }
                    GMapOverlay polyOverlay = new GMapOverlay("polygons");
                    var polygon = new GMapPolygon(points, PA.ParkingAreaName);
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);
                    polyOverlay.Polygons.Add(polygon);
                    mapSearch.Overlays.Add(polyOverlay);
                }
            }
            mapSearch.Refresh();
            mapSearch.Zoom += 1;
            mapSearch.Zoom -= 1;
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
            matTextParkingAreaNameUpadate.Text = "";
        }

        private void matTextParkingAreaID_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            if (matTextParkingAreaNameUpadate.Text != "")
                matTextParkingAreaNameUpadate.Text = matTextParkingAreaNameUpadate.Text;
            else
                matTextParkingAreaNameUpadate.Text = "Parking Area Name";
        }

        private void matbtnUpdateParking_Click(object sender, EventArgs e)
        {
            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "Update Parkings";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlUpdateParkings");

            dgvUpdateParkings.Visible = false;
            matlblUpdateSpace.Visible = false;
            cmbSelectArea.Visible = false;
            pnlUpdateArea.Visible = false;
            pnlUpdateSpace.Visible = false;
            matlblEditArea.Visible = false;
            selectedSpace = false;
            UpadteParkingArea = false;
            matlblSelectSpace.Visible = false;

            matBtnBackToUpdate.Visible = false;

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
                matTextParkingAreaLocationUpdate.Text = "Parking Area Location";
        }

        private void matTextParkingAreaAL_Click(object sender, EventArgs e)
        {
            /* Sets text to nothing */
           // matTextParkingAreaALUpdate.Text = "";
        }

        private void matTextParkingAreaAL_Leave(object sender, EventArgs e)
        {
            /* will set text field back to message if user doesnt enter data */
            //if (matTextParkingAreaALUpdate.Text != "")
             //   matTextParkingAreaALUpdate.Text = matTextParkingAreaALUpdate.Text;
            //else
              //  matTextParkingAreaALUpdate.Text = "Parking Area Access Level";
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
            mapMain.Hide();
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
            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "View Infringements";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlViewInfringements");

            
        }

        private void matBtnAddUser_Click(object sender, EventArgs e)
        {
            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "Add Personnel";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlAddUsers");

            mattextUserID.Text = "User ID";
            matTextPersonelTagNo.Text = "Personnel Tag Number";
            mattextPassword.Text = "Password";
            matTextPersonelSurname.Text = "Personnel Surname";
            matTextPersonelName.Text = "Personnel Name";
            mattextPhoneNum.Text = "Personnel Phone Number";
            mattextEmail.Text = "Personnel Email";


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
            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "Reports";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlSearchUsers");
            
        }

        private void matTextSearchUsers_Click(object sender, EventArgs e)
        {

        }

        private void matTextSearchUsers_Leave(object sender, EventArgs e)
        {

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
            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "Edit Personel";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlEditUser");

            matTextPersonelNameED.Text = "Personnel Name";
            matTextPersonelTagNoED.Text = "Personnel Tag Number";
            matTextPersonelSurED.Text = "Personnel Surname";
            matbtnEmailedit.Text = "Personnel Email Address";

                

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
            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "Add Parkings";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlAddParkings");

            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();

            dgvAddParkings.DataSource = dt;
            dgvAddParkings.Visible = true;

            
            
        }

        private void matBtnVerifyGuest_Click(object sender, EventArgs e)
        {
            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "Verify Guest";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlVerifyGuest");

            matBtnVerifyGuests.Enabled = false;

            matTextGuestSurname.Text = "Guest Surname";
            matTextGuestName.Text = "Guest Name";
            matTextPhoneGuest.Text = "Guest Phone";
            matTextEmailGuest.Text = "Guest Email Address";
            matTextGuestVerifyNo.Text = "Guest Verification Number";

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
            string parkingAreaID = "";
            parkingAreaID = cmbParkingAreas.SelectedValue.ToString();

            /*Connecting data to ParkingSpace combobox*/
            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            
            dt = handler.BLL_GetParkingSpaces(parkingAreaID);
            
            cmbParkingSpace.DataSource = dt;
            cmbParkingSpace.DisplayMember = "ParkingSpaceID";
            cmbParkingSpace.ValueMember = "ParkingSpaceID";

            // show on map 
            /*
            if (parkingAreaID != "" )
            {
                mapSearch.Overlays.Clear();
                string[] locations;
                string location = "", areaName = "", accessLvl = "";
                double dlat = -34.002328, dlong = 25.669922;

                matbtnViewSingleAreaMap.Visible = false;
                PanelVisible("pnlMap");

                mapSearch.MapProvider = GMapProviders.GoogleMap;

                mapSearch.Position = new PointLatLng(dlat, dlong);




                List<ParkingArea> list = new List<ParkingArea>();

                list = handler.BLL_GetAllParkingAreaDetails();


                foreach (ParkingArea PA in list)
                {
                    if (parkingAreaIDMap == PA.ParkingAreaID)
                    {
                        location = PA.ParkingAreaCoordinates;
                        areaName = PA.ParkingAreaName;
                        accessLvl = Convert.ToString(PA.ParkingAreaAccessLevel);
                    }
                }

                if (location != "")
                {
                    locations = location.Split(',');



                    dlat = Convert.ToDouble(locations[0]);
                    dlong = Convert.ToDouble(locations[1]);








                    PointLatLng point = new PointLatLng(dlat, dlong);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);

                    marker.ToolTipText = areaName + " Access Level - " + accessLvl;
                    marker.ToolTip.Fill = Brushes.Black;
                    marker.ToolTip.Foreground = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Black;
                    marker.ToolTip.TextPadding = new Size(20, 20);

                    GMapOverlay markers = new GMapOverlay("markers");
                    markers.Markers.Add(marker);
                    mapSearch.Overlays.Add(markers);


                    List<PointLatLng> points = new List<PointLatLng>();
                    for (int i = 2; i < locations.Length - 1; i += 2)
                    {
                        dlat = Convert.ToDouble(locations[i]);
                        dlong = Convert.ToDouble(locations[i + 1]);
                        points.Add(new PointLatLng(dlat, dlong));

                    }
                    GMapOverlay polyOverlay = new GMapOverlay("polygons");
                    var polygon = new GMapPolygon(points, areaName);
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);
                    polyOverlay.Polygons.Add(polygon);
                    mapSearch.Overlays.Add(polyOverlay);
                }
                else
                {
                    MessageBox.Show("There is no location assigned to this parking area");
                }
                

            }
            */


        }

        private void dgvParkings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvParkings_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (dgvParkings.SelectedRows.Count > 0)
            {
                
                parkingAreaIDMap = dgvParkings.SelectedRows[0].Cells["ParkingAreaID"].Value.ToString();

                IDBHandler handler = new DBHandler();
                DataTable dt = new DataTable();
               dt = handler.BLL_GetParkingSpaces(parkingAreaIDMap);
             
                dgvParkings.DataSource = dt;

                dgvParkings.Dock = DockStyle.None;
                matBtnBackToParkingAreas.Visible = true;
                matbtnViewSingleAreaMap.Visible = true;
                
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
                dt = handler.BLL_SearchParkingSpaceDetails(parkindAreaID, parkingSearchID);

                dgvSearchParkings.DataSource = dt;
                dgvSearchParkings.Visible = true;
                mapSearch.Visible = false;
           
            }

        private void matBtnAddUsers_Click(object sender, EventArgs e)
        {
            string error = "Personnel not added Successfully";
            if (mattextUserID.Text != "" && matTextPersonelTagNo.Text != ""&& mattextPassword.Text != ""&& matTextPersonelSurname.Text != "" && matTextPersonelName.Text != "" && mattextPhoneNum.Text != ""&& mattextEmail.Text != ""
                && mattextUserID.Text != "User ID" && matTextPersonelTagNo.Text != "Personnel Tag Number" && mattextPassword.Text != "Password" && matTextPersonelSurname.Text != "Personnel Surname" && 
                matTextPersonelName.Text != "Personnel Name" && mattextPhoneNum.Text != "Personnel Phone Number" && mattextEmail.Text != "Personnel Email"
                 && IsDigitsOnly(mattextPhoneNum.Text) == true && IsEmail2(mattextEmail.Text) == true && isAllString(matTextPersonelName.Text) == true && isAllString(matTextPersonelSurname.Text) == true)
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
            else
            {
                if (IsDigitsOnly(mattextPhoneNum.Text) == false)
                { error = error + ", telephone not all numbers"; }

                if (IsEmail2(mattextEmail.Text) == false)
                { error = error + ", email not correct format"; }

                if (matTextPersonelName.Text == "Personnel Name" || matTextPersonelName.Text == "")
                { error = error + ", name incorrect"; }

                if (matTextPersonelSurname.Text == "Personnel Surname"|| matTextPersonelSurname.Text == "")
                { error = error + ", surnname incorrect"; }

                if (mattextUserID.Text == ""||mattextUserID.Text=="User ID")
                { error = error + ", User ID is Incorrect"; }

                if (matTextPersonelTagNo.Text == "" || matTextPersonelTagNo.Text == "Personnel Tag Number")
                { error = error + ", User ID is Incorrect"; }

                if (mattextPassword.Text =="" || mattextPassword.Text == "Password")
                { error = error + ",Password not entered or invalid"; }

                MessageBox.Show(error);
            }

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
            try
            {
                //
                IDBHandler handler = new DBHandler();
                uspGetAllInfo get = new uspGetAllInfo();

                get = handler.BLL_getallinfo(ID);

                //load data into controlls
                if (get.PersonnelName != "")
                { matTextPersonelNameED.Text = get.PersonnelName; }
                if (get.PersonnelSurname != "")
                { matTextPersonelSurED.Text = get.PersonnelSurname; }
                if (get.PersonnelEmail != "")
                { matbtnEmailedit.Text = get.PersonnelEmail; }


                cmbPersonnelLevelEdit.SelectedValue = get.PersonnelLevelID;
                cmbPersonnelTypeEdit.SelectedValue = get.PersonnelTypeID;
            }
            catch { }
        }

        private void matbtnEditPersonnel_Click(object sender, EventArgs e)
        {
            string error = "Personnel not successfully edited";
            
            if (matTextPersonelNameED.Text != "Personnel Name" && matTextPersonelTagNoED.Text != "Personnel Tag Number" && matTextPersonelSurED.Text != "Personnel Surname" && matbtnEmailedit.Text != "Personnel Email Address" &&
                matTextPersonelNameED.Text != "" && matTextPersonelTagNoED.Text != "" && matTextPersonelSurED.Text != "" && matbtnEmailedit.Text != "" && IsEmail2(matbtnEmailedit.Text) == true && isAllString(matTextPersonelSurED.Text) == true && isAllString(matTextPersonelNameED.Text) == true)
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
            else
            {
                if (matTextPersonelTagNoED.Text == "Personnel Tag Number")
                { error = error + ", Personnel not selected"; }
                else
                { 
                if (IsEmail2(matbtnEmailedit.Text) == false)
                { error = error + ", email not correct format"; }
                if (matTextPersonelNameED.Text == "Personnel Name" || isAllString(matTextPersonelNameED.Text) == false)
                { error = error + ", name not correct"; }
                if (matTextPersonelSurED.Text == "Personnel Surname" || isAllString(matTextPersonelSurED.Text) == false)
                { error = error + ", surname not correct"; }
                }
                MessageBox.Show(error);
            }



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
            string password = matTextGuestVerifyNo.Text;

            string error = "guest not added successfully";
//

            if (matTextGuestSurname.Text != "Guest Surname" && matTextGuestName.Text != "Guest Name" && matTextPhoneGuest.Text != "Guest Phone" && matTextEmailGuest.Text != "Guest Email Address" &&
            matTextGuestVerifyNo.Text != "Guest Verification Number" && matTextGuestSurname.Text != "" && matTextGuestName.Text != "" && matTextPhoneGuest.Text != "" && matTextEmailGuest.Text != "" &&
            matTextGuestVerifyNo.Text != "" && IsDigitsOnly(matTextPhoneGuest.Text) == true && IsEmail2(matTextEmailGuest.Text) == true && isAllString(matTextGuestSurname.Text) == true && isAllString(matTextGuestName.Text) == true)
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
                if (IsDigitsOnly(matTextPhoneGuest.Text) == false)
                { error = error + ", telephone not all numbers"; }

                if (IsEmail2(matTextEmailGuest.Text) == false)
                { error = error + ", email not correct format"; }

                if( matTextGuestName.Text == "Guest Name" || isAllString(matTextGuestName.Text) == false)
                { error = error + ", guest name incorrect"; }

                if (matTextGuestSurname.Text == "Guest Surname" || isAllString(matTextGuestSurname.Text) == false)
                { error = error + ", guest surnname incorrect"; }

                matTextGuestSurname.Text = "Guest Surname";
                matTextGuestName.Text = "Guest Name";
                matTextPhoneGuest.Text = "Guest Phone";
                matTextEmailGuest.Text = "Guest Email Address";
                matTextGuestVerifyNo.Text = "Guest Verification Number";
                MessageBox.Show(error);

            }
            matBtnVerifyGuests.Enabled = false;

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
            string error = "Parking area not successfully added ";       

            if (matTextAddParkinAreaID.Text != "Parking Area ID" && matTextParkingAreaNameAD.Text != "Parking Area Name" 
                && matTextAddParkingLocation.Text != "Parking Area Location" && (spinCoveredParking.Value + spinUncoveredParking.Value) != 0 
                && NewCoordinates != "")
            {
                try
                {
                    IDBHandler handler = new DBHandler();
                    ParkingArea PA = new ParkingArea();

                    PA.ParkingAreaID = matTextAddParkinAreaID.Text;
                    PA.ParkingAreaName = matTextParkingAreaNameAD.Text;
                    PA.ParkingAreaLocation = matTextAddParkingLocation.Text;
                    PA.ParkingAreaAccessLevel = Convert.ToInt32(spinParkingAl.Value);
                    PA.Status = true;
                    PA.ParkingAreaCoordinates = NewCoordinates;
                    bool b = handler.BLL_AddParkingArea(PA);



                    for (int c = 0; c <= Convert.ToInt32(spinCoveredParking.Value); c++)
                    {
                        handler.BLL_AddPakingSpace("Covered", matTextAddParkinAreaID.Text);
                    }
                    for (int u = 0; u <= Convert.ToInt32(spinUncoveredParking.Value); u++)
                    {
                        handler.BLL_AddPakingSpace("UnCovered", matTextAddParkinAreaID.Text);
                    }

                    if (b == true)
                    {
                        MessageBox.Show("Parking Area successfully Added.");
                        DataTable dt = new DataTable();
                        dt = handler.BLL_GetParkingAreas();
                        dgvAddParkings.DataSource = dt;
                        matTextAddParkinAreaID.Text = "Parking Area ID";

                        matTextAddParkingLocation.Text = "Parking Area Location";

                        matTextParkingAreaNameAD.Text = "Parking Area Name";
                    }
                    else MessageBox.Show("Parking Area not Added Successfully.");


                }
                catch { MessageBox.Show("Parking Area not Added Successfully."); }
                
                    
                    matTextAddParkinAreaID.Text = "Parking Area ID";
                    
                    matTextAddParkingLocation.Text = "Parking Area Location";
                   
                    matTextParkingAreaNameAD.Text = "Parking Area Name";
                    spinCoveredParking.Value = 0;
                    spinUncoveredParking.Value = 0;


            }
            else
            {
                if (matTextAddParkinAreaID.Text == "Parking Area ID")
                {
                    error += ", Parking Area ID is Incorrect ";
                }

                if (matTextAddParkingLocation.Text == "Parking Area Location")
                {
                    error += ", Parking Area Location is Incorrect ";
                }

                if (matTextParkingAreaNameAD.Text == "Parking Area Name")
                {
                    error += ", Parking Area Name is Incorrect ";
                }

                if ((spinCoveredParking.Value + spinUncoveredParking.Value) == 0)
                {
                    error += ", Parking Spaces can not be 0 ";
                }

                if (NewCoordinates == "")
                {
                    error += ", Parking Area Map Coordinates was not Included ";
                }

                matTextAddParkinAreaID.Text = "Parking Area ID";

                matTextAddParkingLocation.Text = "Parking Area Location";

                matTextParkingAreaNameAD.Text = "Parking Area Name";

                spinCoveredParking.Value = 0;
                spinUncoveredParking.Value = 0;

                MessageBox.Show(error);

            }

               
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
                
            }

            if (selectSpaces == true)
            {
                if (dgvUpdateParkings.SelectedRows.Count > 0)
                {
                    string parkingAreaID;
                    parkingAreaID = dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaID"].Value.ToString();

                   

                    selectedSpace = true;
                    MessageBox.Show("Please double click parking space row header");
                    selectSpaces = false;
                }
            }

             
        }

        private void matmatBtnEditArea_Click(object sender, EventArgs e)
        {
            matBtnBackToUpdate.Visible = true;
            dgvUpdateParkings.Visible = true;
            matlblEditArea.Visible = true;
            

            UpadteParkingArea = true;

            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();
            dgvUpdateParkings.DataSource = dt;

            
        }

        private void matBtnEditParkingSpace_Click(object sender, EventArgs e)
        {
            matlblUpdateSpace.Visible = true;
            cmbSelectArea.Visible = true;

            selectedSpace = true;

            matBtnBackToUpdate.Visible = true;

            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();

            dt = handler.BLL_GetParkingAreas();

            cmbSelectArea.DataSource = dt;
            cmbSelectArea.DisplayMember = "ParkingAreaName";
            cmbSelectArea.ValueMember = "ParkingAreaID";








            
           // IDBHandler handler = new DBHandler();
           //DataTable dt = new DataTable();
           // dt = handler.BLL_GetParkingAreas();
           // dgvUpdateParkings.DataSource = dt;
           // MessageBox.Show("Please select area where parking space is located");
        }

        private void dgvUpdateParkings_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)

         {

        }

        private void matBtnUpdateParkingSpace_Click(object sender, EventArgs e)
        {
            bool status = true, Available;
            string type;

            if (cbDeleteSpace.Checked == true)
                status = false;
           else status = true;

            if (cmbAvailibality.SelectedIndex == 0)
            {
                Available = true;
            }
            else Available = false;

            if (cmbEditType.SelectedIndex == 0)
            {
                type = "Covered";
            }
            else type = "UnCovered";

            IDBHandler handler = new DBHandler();
            handler.BLL_UpdateParkingSpace(UpParkingAreaID,type,UpSpaceID,Available,status);
        }

        private void matbtnHelpEd_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Editing or deleting a Personnel Member.pdf");
            }
            catch { }
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

        private void matBtnBackToUpdate_Click(object sender, EventArgs e)
        {
            dgvUpdateParkings.Visible = false;
            matlblUpdateSpace.Visible = false;
            cmbSelectArea.Visible = false;
            pnlUpdateArea.Visible = false;
            pnlUpdateSpace.Visible = false;
            matlblEditArea.Visible = false;
            selectedSpace = false;
            UpadteParkingArea = false;
            matlblSelectSpace.Visible = false;

            matBtnBackToUpdate.Visible = false;

        }

        private void dgvUpdateParkings_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (UpadteParkingArea == true)
            {

                if (dgvUpdateParkings.SelectedRows.Count > 0)
                {
                    pnlUpdateArea.Visible = true;
                    string parkingAreaLocation, parkingAreaName;
                    int parkingAL;
                    //Global AreaID
                    UpParkingAreaID = dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaID"].Value.ToString();
                    //Giving values from grid
                    parkingAreaName = dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaName"].Value.ToString();
                    parkingAreaLocation = dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaLocation"].Value.ToString();
                    parkingAL = int.Parse(dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaAccessLevel"].Value.ToString());
                    //Assigning values to edits
                    matTextParkingAreaNameUpadate.Text = parkingAreaName;
                    matTextParkingAreaLocationUpdate.Text = parkingAreaLocation;
                    numUpParkingAL.Value = parkingAL;
                }
            }

            if (selectedSpace == true)
            {
                pnlUpdateSpace.Visible = true;
                
                string available = dgvUpdateParkings.SelectedRows[0].Cells["Available"].Value.ToString();

                if (available == "UnAvailable")
                {
                    cmbAvailibality.SelectedIndex = 1;
                }
                else cmbAvailibality.SelectedIndex = 0;

                string covered = dgvUpdateParkings.SelectedRows[0].Cells["ParkingType"].Value.ToString();
                if (covered == "UnCovered")
                {
                    cmbEditType.SelectedIndex = 1;
                }
                else cmbEditType.SelectedIndex = 0;

                UpSpaceID = Convert.ToInt32(dgvUpdateParkings.SelectedRows[0].Cells["ParkingSpaceID"].Value.ToString());
            }
        }

        private void matBtnUpdateParkingA_Click(object sender, EventArgs e)
        {
            IDBHandler handler = new DBHandler();
            ParkingArea PA = new ParkingArea();

            PA.ParkingAreaID = UpParkingAreaID;
            PA.ParkingAreaName = matTextParkingAreaNameUpadate.Text;
            PA.ParkingAreaLocation = matTextParkingAreaLocationUpdate.Text;
            PA.ParkingAreaAccessLevel = Convert.ToInt32(numUpParkingAL.Value);
            if (cbDelecteParkingArea.Checked == true)
            {
                PA.Status = false;
            }
            else PA.Status = true;
            handler.BLL_UpdateParkingArea(PA);


            /*
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
           */
            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();
            dgvUpdateParkings.DataSource = dt;

        }

        private void cmbSelectArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvUpdateParkings.Visible = true;

            matlblSelectSpace.Visible = true;

            IDBHandler handler = new DBHandler();
            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingSpaces(cmbSelectArea.SelectedValue.ToString());

            dgvUpdateParkings.DataSource = dt;
            UpParkingAreaID = cmbSelectArea.SelectedValue.ToString();
        }

        private bool IsDigitsOnly(string str)
        {
            if (str.Length != 10)
            { return false; }
            else
            {
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                        return false;
                }
            }

            return true;
        }

        private void matViewSingleAreaMap_Click(object sender, EventArgs e)
        {
            string[] locations;
            string location = "", areaName = "", accessLvl = "";
            double dlat = -34.002328, dlong = 25.669922;

            matbtnViewSingleAreaMap.Visible = false;
            PanelVisible("pnlMap");

            map.MapProvider = GMapProviders.GoogleMap;

            map.Position = new PointLatLng(dlat, dlong);

            IDBHandler handler = new DBHandler();


            List<ParkingArea> list = new List<ParkingArea>();

            list = handler.BLL_GetAllParkingAreaDetails();
            

            foreach (ParkingArea PA in list)
            {
                if (parkingAreaIDMap == PA.ParkingAreaID)
                {
                    location = PA.ParkingAreaCoordinates;
                    areaName = PA.ParkingAreaName;
                    accessLvl = Convert.ToString(PA.ParkingAreaAccessLevel);
                }
            }

            if (location != "")
            {
                locations = location.Split(',');



                dlat = Convert.ToDouble(locations[0]);
                dlong = Convert.ToDouble(locations[1]);




                



                PointLatLng point = new PointLatLng(dlat, dlong);
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);

                marker.ToolTipText = areaName + " Access Level - " + accessLvl;
                marker.ToolTip.Fill = Brushes.Black;
                marker.ToolTip.Foreground = Brushes.White;
                marker.ToolTip.Stroke = Pens.Black;
                marker.ToolTip.TextPadding = new Size(20, 20);

                GMapOverlay markers = new GMapOverlay("markers");
                markers.Markers.Add(marker);
                map.Overlays.Add(markers);


                List<PointLatLng> points = new List<PointLatLng>();
                for (int i = 2; i < locations.Length - 1; i += 2)
                {
                    dlat = Convert.ToDouble(locations[i]);
                    dlong = Convert.ToDouble(locations[i + 1]);
                    points.Add(new PointLatLng(dlat, dlong));

                }
                GMapOverlay polyOverlay = new GMapOverlay("polygons");
                var polygon = new GMapPolygon(points, areaName);
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 1);
                polyOverlay.Polygons.Add(polygon);
                map.Overlays.Add(polyOverlay);
                map.Refresh();
                map.Zoom += 1;
                map.Zoom -= 1;
            }
            else
            {
                MessageBox.Show("There is no location assigned to this parking area");
            }

            

           


        }

        private void map_Load(object sender, EventArgs e)
        {
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            
            map.MinZoom = 5; 
            map.MaxZoom = 100;
            map.Zoom = 15;

            
        }

        private void map_Leave(object sender, EventArgs e)
        {
            map.Overlays.Clear();
        }

        private void mapMain_Load(object sender, EventArgs e)
        {
            
            string location = "";
            double dlat = -34.002328, dlong = 25.669922;

            mapMain.ShowCenter = false;
            mapMain.DragButton = MouseButtons.Left;

            mapMain.MinZoom = 5;
            mapMain.MaxZoom = 100;
            mapMain.Zoom = 15;

            mapMain.MapProvider = GMapProviders.GoogleMap;
            mapMain.Position = new PointLatLng(dlat, dlong);




            IDBHandler handler = new DBHandler();

            List<ParkingArea> list = new List<ParkingArea>();

            list = handler.BLL_GetAllParkingAreaDetails();


            foreach (ParkingArea PA in list)
            {
                string[] arraypoints ;
                if (PA.ParkingAreaCoordinates != "")
                {
                    location = PA.ParkingAreaCoordinates;
                    arraypoints = location.Split(',');

                    string lat = arraypoints[0];
                   dlat = Convert.ToDouble(lat,CultureInfo.InvariantCulture);
                    string lng = arraypoints[1]; 
                    dlong = Convert.ToDouble(arraypoints[1],CultureInfo.InvariantCulture);

                    mapMain.MapProvider = GMapProviders.GoogleMap;

                    mapMain.Position = new PointLatLng(dlat, dlong);
                    PointLatLng point = new PointLatLng(dlat, dlong);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);

                    
                    marker.ToolTipText = PA.ParkingAreaName + " Access Level - " + Convert.ToString(PA.ParkingAreaAccessLevel);
                    marker.ToolTip.Fill = Brushes.Black;
                    marker.ToolTip.Foreground = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Black;
                    marker.ToolTip.TextPadding = new Size(20, 20);

                    GMapOverlay markers = new GMapOverlay("markers");
                    markers.Markers.Add(marker);
                    mapMain.Overlays.Add(markers);

                    List<PointLatLng> points = new List<PointLatLng>();
                    for (int i = 2; i < arraypoints.Length-1; i+=2)
                      {
                          dlat = Convert.ToDouble(arraypoints[i], CultureInfo.InvariantCulture);
                           dlong = Convert.ToDouble(arraypoints[i+1],CultureInfo.InvariantCulture);
                            points.Add(new PointLatLng(dlat, dlong));
                        
                      }
                    GMapOverlay polyOverlay = new GMapOverlay("polygons");
                    var polygon = new GMapPolygon(points, PA.ParkingAreaName);
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);
                    polyOverlay.Polygons.Add(polygon);
                    mapMain.Overlays.Add(polyOverlay);

                    map.Refresh();
                    map.Zoom += 1;
                    map.Zoom -= 1;



                    //;
                    //areaName = PA.ParkingAreaName;
                    //accessLvl = Convert.ToString(PA.ParkingAreaAccessLevel);

                    // polygon.ToolTipText = areaName + " Access Level - " + accessLvl;
                    //marker.ToolTip.Fill = Brushes.Black;
                    //marker.ToolTip.Foreground = Brushes.White;
                    //marker.ToolTip.Stroke = Pens.Black;
                    //marker.ToolTip.TextPadding = new Size(20, 20);
                }

                
            }



           












        }

        private void matTextSearchUsers_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void matTextSearchUsers_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            string id = matTextEditPersonelSearch.Text;
            if (id != "" || id != "Personnel Number or Name")
            {
                IDBHandler handler = new DBHandler();
                DataTable dt = handler.BLL_SearchPersonnel(id);

                dgvEditPersonel.DataSource = dt;
            }
            else
            {
                IDBHandler handler3 = new DBHandler();
                DataTable dt3 = handler3.BLL_GetPersonel();
                dgvEditPersonel.DataSource = dt3;
            }
        }

        private void matTextEditPersonelSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void matTextEditPersonelSearch_Leave(object sender, EventArgs e)
        {
            if (matTextEditPersonelSearch.Text == "") { matTextEditPersonelSearch.Text = "Personnel Number or Name"; }

            
        }

        private void matTextEditPersonelSearch_Click(object sender, EventArgs e)
        {
            matTextEditPersonelSearch.Text = "";
        }

        private void mapSearch_Leave(object sender, EventArgs e)
        {
           
        }

        private void mapMain_Leave(object sender, EventArgs e)
        {
            mapMain.Overlays.Clear();
        }

        private void cmbParkingAreas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // show on map 

            mapSearch.Visible = true;
            
                mapSearch.Overlays.Clear();
                string[] locations;
                string location = "", areaName = "", accessLvl = "";
                double dlat = -34.002328, dlong = 25.669922;

                
                

                


                IDBHandler handler = new DBHandler();

                List<ParkingArea> list = new List<ParkingArea>();

                list = handler.BLL_GetAllParkingAreaDetails();


                foreach (ParkingArea PA in list)
                {
                    if (cmbParkingAreas.SelectedValue.ToString() == PA.ParkingAreaID)
                    {
                        location = PA.ParkingAreaCoordinates;
                        areaName = PA.ParkingAreaName;
                        accessLvl = Convert.ToString(PA.ParkingAreaAccessLevel);
                    }
                }

                if (location != "")
                {
                    locations = location.Split(',');



                    dlat = Convert.ToDouble(locations[0]);
                    dlong = Convert.ToDouble(locations[1]);








                    PointLatLng point = new PointLatLng(dlat, dlong);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);

                    marker.ToolTipText = areaName + " Access Level - " + accessLvl;
                    marker.ToolTip.Fill = Brushes.Black;
                    marker.ToolTip.Foreground = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Black;
                    marker.ToolTip.TextPadding = new Size(20, 20);

                    GMapOverlay markers = new GMapOverlay("markers");
                    markers.Markers.Add(marker);
                    mapSearch.Overlays.Add(markers);


                    List<PointLatLng> points = new List<PointLatLng>();
                    for (int i = 2; i < locations.Length - 1; i += 2)
                    {
                        dlat = Convert.ToDouble(locations[i]);
                        dlong = Convert.ToDouble(locations[i + 1]);
                        points.Add(new PointLatLng(dlat, dlong));

                    }
                    GMapOverlay polyOverlay = new GMapOverlay("polygons");
                    var polygon = new GMapPolygon(points, areaName);
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);
                    polyOverlay.Polygons.Add(polygon);
                    mapSearch.Overlays.Add(polyOverlay);
                    mapSearch.Refresh();
                    mapSearch.Zoom += 1;
                    mapSearch.Zoom -= 1; 
            }
                else
                {
                    MessageBox.Show("There is no location assigned to this parking area");
                }



            }

        private void matbtnBackToSearchMap_Click(object sender, EventArgs e)
        {
            dgvSearchParkings.Visible = false;
            mapSearch.Visible = true;
        }

        private void matBtnAddCoordinates_Click(object sender, EventArgs e)
        {
            On_Add = true;
            NewCoordinates = "";
         
            PanelVisible("pnlAdd_EditMap");
        }

        private void mapAdd_Edit_Coord_Load(object sender, EventArgs e)
        {
            
            double dlat = -34.002328, dlong = 25.669922;

            mapAdd_Edit_Coord.ShowCenter = false;
            mapAdd_Edit_Coord.DragButton = MouseButtons.Left;

            mapAdd_Edit_Coord.MinZoom = 5;
            mapAdd_Edit_Coord.MaxZoom = 100;
            mapAdd_Edit_Coord.Zoom = 15;

            mapAdd_Edit_Coord.MapProvider = GMapProviders.GoogleMap;
            mapAdd_Edit_Coord.Position = new PointLatLng(dlat, dlong);

            lblLongCoord.Text = "";
            lblLatCoord.Text = "";
        }

        private void mapAdd_Edit_Coord_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var point = mapAdd_Edit_Coord.FromLocalToLatLng(e.X, e.Y);
                double lat = point.Lat;
                double lng = point.Lng;

                lblLatCoord.Text = lat.ToString();
                lblLongCoord.Text = lng.ToString();

            }
        }

        private void matLoadMarker_Click(object sender, EventArgs e)
        {
            if (lblLatCoord.Text != "" && lblLongCoord.Text != "")
            {
                NewCoordinates = lblLatCoord.Text + ", " + lblLongCoord.Text;

                PointLatLng point = new PointLatLng(Convert.ToDouble(lblLatCoord.Text), Convert.ToDouble(lblLongCoord.Text));
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);

                marker.ToolTipText = "Selected Center of Parking Area";
                marker.ToolTip.Fill = Brushes.Black;
                marker.ToolTip.Foreground = Brushes.White;
                marker.ToolTip.Stroke = Pens.Black;
                marker.ToolTip.TextPadding = new Size(20, 20);

                GMapOverlay markers = new GMapOverlay("markers");
                markers.Markers.Add(marker);
                mapAdd_Edit_Coord.Overlays.Add(markers);

                lblLatCoord.Text = "";
                lblLongCoord.Text = "";

                matbtnLoadMarker.Visible = false;
                matbtnAddPolyPoint.Visible = true;
                matbtnSaveTotalArea.Visible = true;

                mapAdd_Edit_Coord.Refresh();
                mapAdd_Edit_Coord.Zoom += 1;
                mapAdd_Edit_Coord.Zoom -= 1;

                lblCaption.Text = "Please select multiple points to draw area";


            }
            else MessageBox.Show("Please select Parking Area center point");
          

        }

        private void matbtnAddPolyPoint_Click(object sender, EventArgs e)
        {
            string Coordinates = "";
            string[] Coord;
            double dlat, dlng;

            


            if (lblLatCoord.Text != "" && lblLongCoord.Text != "")
            {
                PolyCount++;
                TempCoordinates += ", " + lblLatCoord.Text + ", " + lblLongCoord.Text;

                Coordinates = NewCoordinates + TempCoordinates;
                Coord = Coordinates.Split(',');

                mapAdd_Edit_Coord.Overlays.Clear();

                PointLatLng point = new PointLatLng(Convert.ToDouble(Coord[0]), Convert.ToDouble(Coord[1]));
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);

                marker.ToolTipText = "Selected Center of Parking Area";
                marker.ToolTip.Fill = Brushes.Black;
                marker.ToolTip.Foreground = Brushes.White;
                marker.ToolTip.Stroke = Pens.Black;
                marker.ToolTip.TextPadding = new Size(20, 20);

                GMapOverlay markers = new GMapOverlay("markers");
                markers.Markers.Add(marker);
                mapAdd_Edit_Coord.Overlays.Add(markers);

                List<PointLatLng> points = new List<PointLatLng>();
                for (int i = 2; i < Coord.Length - 1; i += 2)
                {
                    dlat = Convert.ToDouble(Coord[i]);
                    dlng = Convert.ToDouble(Coord[i + 1]);
                    points.Add(new PointLatLng(dlat, dlng));

                }
                GMapOverlay polyOverlay = new GMapOverlay("polygons");
                var polygon = new GMapPolygon(points, "New Area");
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 1);
                polyOverlay.Polygons.Add(polygon);
                mapAdd_Edit_Coord.Overlays.Add(polyOverlay);

                mapAdd_Edit_Coord.Refresh();
                mapAdd_Edit_Coord.Zoom += 1;
                mapAdd_Edit_Coord.Zoom -= 1;

                lblLatCoord.Text = "";
                lblLongCoord.Text = "";

            }
            else MessageBox.Show("Please Select Area Point");

        }

        private void matbtnSaveTotalArea_Click(object sender, EventArgs e)
        {
            if (PolyCount > 3 && TempCoordinates != "")
            {
                NewCoordinates += TempCoordinates;

                
                mapAdd_Edit_Coord.Overlays.Clear();
                NewCoordinates = "";
                TempCoordinates = "";
                lblLatCoord.Text = "";
                lblLongCoord.Text = "";


                lblCaption.Text = "Please select center point of Parking Area";
                matbtnAddPolyPoint.Visible = false;
                matbtnSaveTotalArea.Visible = false;
                matbtnLoadMarker.Visible = true;

                mapAdd_Edit_Coord.Refresh();

                MessageBox.Show("Parking Area Coordinates Successfully Added");
                PanelVisible("pnlAddParkings");
            }

            else
            {
                MessageBox.Show("Unsuccessful attemp please try again");

                mapAdd_Edit_Coord.Overlays.Clear();
                NewCoordinates = "";
                TempCoordinates = "";
                lblLatCoord.Text = "";
                lblLongCoord.Text = "";


                lblCaption.Text = "Please select center point of Parking Area";
                matbtnAddPolyPoint.Visible = false;
                matbtnSaveTotalArea.Visible = false;
                matbtnLoadMarker.Visible = true;

                mapAdd_Edit_Coord.Refresh();
            }

        }

        private void pnlAdd_EditMap_Leave(object sender, EventArgs e)
        {
            if (On_Add == true)
            {
                PanelVisible("pnlAddParkings");
            }
            else PanelVisible("pnlUpdateArea");
            

        }

        private void matTextEditPersonelSearch_TextChanged(object sender, EventArgs e)
        {
            string id = matTextEditPersonelSearch.Text;
            if (id != "" || id != "Personnel Number or Name")
            {
                IDBHandler handler = new DBHandler();
                DataTable dt = handler.BLL_SearchPersonnel(id);

                dgvEditPersonel.DataSource = dt;
            }
            else
            {
                IDBHandler handler3 = new DBHandler();
                DataTable dt3 = handler3.BLL_GetPersonel();
                dgvEditPersonel.DataSource = dt3;
            }
        }

        private void matbtnGetCoords_Click(object sender, EventArgs e)
        {
            PanelVisible("pnlAdd_EditMap");
        }

        private void matbtnRedo_Click(object sender, EventArgs e)
        {
            mapAdd_Edit_Coord.Overlays.Clear();
            NewCoordinates = "";
            TempCoordinates = "";
            lblLatCoord.Text = "";
            lblLongCoord.Text = "";
            

            lblCaption.Text = "Please select center point of Parking Area";
            matbtnAddPolyPoint.Visible = false;
            matbtnSaveTotalArea.Visible = false;
            matbtnLoadMarker.Visible = true;

            mapAdd_Edit_Coord.Refresh();
        }
        private bool isAllString(string text)
        {
            string letterpattern = @"^[a-zA-Z]+$";
            Regex regex = new Regex(letterpattern);

            return regex.IsMatch(text);
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {

            IDBHandler handler = new DBHandler();
            DataTable dt = handler.BLL_getInfringements(mattextboxInfringements.Text);

            dgvViewUsers.DataSource = dt;
        }

        private void mattextboxInfringements_Click(object sender, EventArgs e)
        {
            mattextboxInfringements.Text = "";
        }

        private void mattextboxInfringements_Leave(object sender, EventArgs e)
        {
            mattextboxInfringements.Text = "Personnel ID Number";
        }

        private void matTextAddParkinAreaID_Leave(object sender, EventArgs e)
        {
            if (matTextAddParkinAreaID.Text != "")
                matTextAddParkinAreaID.Text = matTextAddParkinAreaID.Text;
            else
                matTextAddParkinAreaID.Text = "Parking Area ID";
        }

        private void matTextAddParkingLocation_Leave(object sender, EventArgs e)
        {
            if (matTextAddParkingLocation.Text != "")
                matTextAddParkingLocation.Text = matTextAddParkingLocation.Text;
            else
                matTextAddParkingLocation.Text = "Parking Area Location";
        }

        private bool IsEmail2(string email)
        {
            string MatchEmailPattern =
          @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

           return Regex.IsMatch(email, MatchEmailPattern);

        
    } 



    }
}