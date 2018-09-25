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
using System.Diagnostics;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using Tulpep.NotificationWindow;
using System.Threading;



namespace uniPark.Main.Forms.Landing
{
    public partial class frmLanding : MaterialForm
    {
        bool hidden;
       // bool selectSpaces = false;
        bool selectedSpace = false;
        bool UpadteParkingArea = false;

        string parkingAreaIDMap; //global var for single area of map
        string UpParkingAreaID; // global var for update
        int UpSpaceID; // global var for update
        string NewCoordinates = "", TempCoordinates = ""; // used for adding and editing parking areas
        int PolyCount = 0; // used for adding and editing parking areas
        bool On_Add = true;
        GMapOverlay Tmarkers = new GMapOverlay("markers");

        uspGetAllInfo infos;

        
            Thread th = new Thread(() =>
            {
                IDBHandler handler = new DBHandler();
                DataTable dt = handler.BLL_GetParkingRequests();

                int rowCount = dt.Rows.Count;

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Info;
                popup.TitleText = "UniPark";
                popup.ContentText = "Waiting Requests : " + Convert.ToString(rowCount);
                popup.Popup();

                Thread.Sleep(5000);
            });
        

        /* Task tt = new Task(() =>
        {
            Thread.Sleep(3000);

            IDBHandler handler = new DBHandler();
            DataTable dt = handler.BLL_GetParkingRequests();

            int rowCount = dt.Rows.Count;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.Info;
            popup.TitleText = "UniPark";
            popup.ContentText = "Waiting Requests : " + Convert.ToString(rowCount);
            popup.Popup();

            Thread.Sleep(3000);

        });  */




        private void DGVload(DataGridView dgvName)
        {
            /* ==================================
            * Designing of material DataGridView
            * ================================== */
            /* changes table visuals */
            dgvName.BorderStyle = BorderStyle.None;
            dgvName.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(236, 252, 232);
            dgvName.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvName.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dgvName.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgvName.BackgroundColor = System.Drawing.Color.FromArgb(247, 255, 245);

            /* Changes column heading visualas */
            dgvName.EnableHeadersVisualStyles = false;
            dgvName.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvName.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;
            dgvName.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            
        }
        private void DGVBoldHeadings(DataGridView dgvName)
        {
            /* Changes column headings to bold */
            dgvName.Columns[0].HeaderCell.Style.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, FontStyle.Bold);
            dgvName.Columns[1].HeaderCell.Style.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, FontStyle.Bold);
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


          //  th.Start();

            

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
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.Info;
            popup.TitleText = "UniPark";
            popup.ContentText = "Select a Row by clicking on the right side of the row.";
            popup.Popup(); // show

            /* will change heading title */
            lblHeadings.Text = "View Parkings";

            /* Hides other panels, shows View Parkings */
         
            PanelVisible("pnlViewParkings");

            /*Connecting data to datagrid*/

            IDBHandler handler = new DBHandler();

            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();
            
            dgvParkings.DataSource = dt;

            // dgvParkings.Dock = DockStyle.Fill;
            dgvAddParkings.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);

            matbtnViewSingleAreaMap.Visible = false;
            matBtnBackToParkingAreas.Visible = false;

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
                    polygon.Fill = new SolidBrush(System.Drawing.Color.FromArgb(50, System.Drawing.Color.Red));
                    polygon.Stroke = new Pen(System.Drawing.Color.Red, 1);
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
           
        }

        private void matTextParkingNameAS_Click(object sender, EventArgs e)
        {
           
        }

        private void matTextParkingNameAS_Leave(object sender, EventArgs e)
        {
          
        }

        private void matbtnAssignParking_Click(object sender, EventArgs e)
        {
            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "Assign Parkings";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlAssignParkings");

            IDBHandler handler = new DBHandler();
            DataTable dt = handler.BLL_GetParkingRequests();
            dgvAssignParkings.DataSource = dt;

            if (dgvAssignParkings.Rows.Count == 0)
            {
                matbtnAutoAssign.Visible = false;
                lblNoRequests.Visible = true;
                dgvAssignParkings.Visible = false;
            }
            else matbtnAutoAssign.Visible = true;

        }

        private void matTextFacilityNoAS_Click(object sender, EventArgs e)
        {
         
        }

        private void matTextFacilityNoAS_Leave(object sender, EventArgs e)
        {
        }

        private void matBtnViewUsers_Click(object sender, EventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.Info;
            popup.TitleText = "UniPark";
            popup.ContentText = "Enter A Facillity number to view fines against that user";
            popup.Popup(); // show

            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "View Infringements";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlViewInfringements");

            
        }

        private void matBtnAddUser_Click(object sender, EventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.Info;
            popup.TitleText = "UniPark";
            popup.ContentText = "Fill out the form to add a user to the system";
            popup.Popup(); // show
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
            datepickerEnd.Value = DateTime.Today;

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.Info;
            popup.TitleText = "UniPark";
            popup.ContentText = "enter a facility number for whom you wish to generate the report, or select system.";
            popup.Popup(); // show

            mapMain.Hide();
            /* will change heading title */
            lblHeadings.Text = "Reports";

            /* Hides other panels, shows View Parkings */
            PanelVisible("pnlSearchUsers");

            panelReport.Visible = false;
            
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
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.Info;
            popup.TitleText = "UniPark";
            popup.ContentText = "Enter A Facillity number, or name, or surname to search for users in the system, whom's details you wish to edit";
            popup.Popup(); // show
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
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.Info;
            popup.TitleText = "UniPark";
            popup.ContentText = "Generate a code for a guest to use and fill out form to add a guest";
            popup.Popup(); // show

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

                //dgvParkings.Dock = DockStyle.None;
                //dgvParkings.Dock = DockStyle.Right;
                // dgvAddParkings.Anchor = AnchorStyles.Left;
                dgvAddParkings.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right );

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
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Error;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Failed to add user, userid exsists";
                    popup.Popup();
                }
                if (success == true)
                {
                   // MessageBox.Show("Successfully added user");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Info;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Successfully Added User";
                    popup.Popup(); // show
                }
                else { //MessageBox.Show("Failed to add user"); 
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Error;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Failed to add user";
                    popup.Popup();
                }
            }
            else
            {
                if (IsDigitsOnly(mattextPhoneNum.Text) == false)
                { error = error + ", telephone not all numbers"; }

                if (IsEmail2(mattextEmail.Text) == false)
                { error = error + ", email not correct format"; }

                if (matTextPersonelName.Text == "Personnel Name" || matTextPersonelName.Text == "" || isAllString(matTextPersonelName.Text) ==false)
                { error = error + ", name incorrect"; }

                if (matTextPersonelSurname.Text == "Personnel Surname"|| matTextPersonelSurname.Text == ""  || isAllString(matTextPersonelSurname.Text) == false)
                { error = error + ", surnname incorrect"; }

                if (mattextUserID.Text == ""||mattextUserID.Text=="User ID")
                { error = error + ", User ID is Incorrect"; }

                if (matTextPersonelTagNo.Text == "" || matTextPersonelTagNo.Text == "Personnel Tag Number")
                { error = error + ", User Tag Number is Incorrect"; }

                if (mattextPassword.Text =="" || mattextPassword.Text == "Password")
                { error = error + ",Password not entered or invalid"; }

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Error;
                popup.TitleText = "UniPark";
                popup.ContentText = error;
                popup.Popup();
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
               // MessageBox.Show("Personel Successfully Edited");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Info;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Personel Successfully Edited";
                    popup.Popup();
                    matBtnVerifyGuests.Enabled = true;

                }
            else {// MessageBox.Show("Personel Unsuccessfully Edited");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Error;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Personel Unsuccessfully Edited";
                    popup.Popup();
                }

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
                    //MessageBox.Show("guest verification id valid");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Info;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Guest verification id valid";
                    popup.Popup();
                    matBtnVerifyGuests.Enabled = true;
                    b = true;
                }
                else
                {
                   // MessageBox.Show("guest verification id already taken");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Error;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Guest verification id already taken";
                    popup.Popup();
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
                       // MessageBox.Show("guest added successfully");
                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.Info;
                        popup.TitleText = "UniPark";
                        popup.ContentText = "Guest added successfully";
                        popup.Popup();
                    }
                    else {
                           PopupNotifier popup = new PopupNotifier();
                           popup.Image = Properties.Resources.Error;
                           popup.TitleText = "UniPark";
                           popup.ContentText = "Guest was not added successfully";
                           popup.Popup();
                         }
                }
                catch { //MessageBox.Show("guest was not added successfully");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Error;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Guest was not added successfully";
                    popup.Popup();
                }

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



                    for (int c = 1; c <= Convert.ToInt32(spinCoveredParking.Value); c++)
                    {
                        handler.BLL_AddPakingSpace("Covered", matTextAddParkinAreaID.Text, 2);
                    }
                    for (int u = 1; u <= Convert.ToInt32(spinUncoveredParking.Value); u++)
                    {
                        handler.BLL_AddPakingSpace("UnCovered", matTextAddParkinAreaID.Text, 1);
                    }

                    if (b == true)
                    {
                        //MessageBox.Show("Parking Area successfully Added.");
                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.Info;
                        popup.TitleText = "UniPark";
                        popup.ContentText = "Parking Area Successfully. Added";
                        popup.Popup();

                        DataTable dt = new DataTable();
                        dt = handler.BLL_GetParkingAreas();
                        dgvAddParkings.DataSource = dt;
                        matTextAddParkinAreaID.Text = "Parking Area ID";

                        matTextAddParkingLocation.Text = "Parking Area Location";

                        matTextParkingAreaNameAD.Text = "Parking Area Name";
                    }
                    else {
                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.Error;
                        popup.TitleText = "UniPark";
                        popup.ContentText = "Parking Area not Added Successfully.";
                        popup.Popup();
                    }


                }
                catch
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Error;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Parking Area not Added Successfully.";
                    popup.Popup();
                }


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

           // MessageBox.Show("Parking Space successfully Updated.");
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.Info;
            popup.TitleText = "UniPark";
            popup.ContentText = "Parking Space Successfully Updated.";
            popup.Popup(); // show


            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingSpaces(UpParkingAreaID);
            dgvUpdateParkings.DataSource = dt;
        }

        private void matbtnHelpEd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. First enter the Personnel number or name/surname in the above edit." + "\n" + "2. Then Select any member in the grid to edit." +"\n"+"3. Then adjust the edits below as required" + "\n" + "4. Then click the Apply Changes button to the right of the edited infromation.");
        }



        private void matBtnBackToParkingAreas_Click(object sender, EventArgs e)
        {
            matBtnBackToParkingAreas.Visible = false;
            IDBHandler handler = new DBHandler();

            DataTable dt = new DataTable();
            dt = handler.BLL_GetParkingAreas();

            dgvParkings.DataSource = dt;
           // dgvParkings.Dock = DockStyle.Fill;
            dgvAddParkings.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);

            matbtnViewSingleAreaMap.Visible = false;

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
                    NewCoordinates = dgvUpdateParkings.SelectedRows[0].Cells["ParkingAreaCoordinates"].Value.ToString();
                    //Assigning values to edits
                    matTextParkingAreaNameUpadate.Text = parkingAreaName;
                    matTextParkingAreaLocationUpdate.Text = parkingAreaLocation;
                    numUpParkingAL.Value = parkingAL;
                    if (matTextParkingAreaNameUpadate.Text == "")
                    {
                        matTextParkingAreaNameUpadate.Text = "Parking Area Name";
                    }
                    if (matTextParkingAreaLocationUpdate.Text == "")
                    {
                        matTextParkingAreaLocationUpdate.Text = "Parking Area Location";
                    }
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
            string error = "Parking Area Update Unsuccessfull due to : ";
            

            if (matTextParkingAreaNameUpadate.Text != "Parking Area Name" && matTextParkingAreaLocationUpdate.Text != "Parking Area Location" && NewCoordinates != "")
            {
                try
                {



                    IDBHandler handler = new DBHandler();
                    ParkingArea PA = new ParkingArea();

                    PA.ParkingAreaID = UpParkingAreaID;
                    PA.ParkingAreaName = matTextParkingAreaNameUpadate.Text;
                    PA.ParkingAreaLocation = matTextParkingAreaLocationUpdate.Text;
                    PA.ParkingAreaAccessLevel = Convert.ToInt32(numUpParkingAL.Value);
                    PA.ParkingAreaCoordinates = NewCoordinates;
                    if (cbDelecteParkingArea.Checked == true)
                    {
                        PA.Status = false;
                    }
                    else PA.Status = true;
                    handler.BLL_UpdateParkingArea(PA);
                    if (cbAddMoreSpaces.Checked == true)
                    {
                        if (nupCovered.Value != 0)
                        {
                            for (int c = 1; c <= Convert.ToInt32(nupCovered.Value); c++)
                            {
                                handler.BLL_AddPakingSpace("Covered", UpParkingAreaID , 2);
                            }
                           
                        }
                        if (nupUncovered.Value != 0)
                        {
                            for (int u = 1; u <= Convert.ToInt32(nupUncovered.Value); u++)
                            {
                                handler.BLL_AddPakingSpace("UnCovered", UpParkingAreaID, 1);
                            }
                        }
                    }

                   
                    DataTable dt = new DataTable();
                    dt = handler.BLL_GetParkingAreas();
                    dgvUpdateParkings.DataSource = dt;

                    lblMoreCovered.Visible = false;
                    lblMoreUncovered.Visible = false;
                    nupCovered.Visible = false;
                    nupUncovered.Visible = false;

                    nupUncovered.Value = 0;
                    nupCovered.Value = 0;
                    cbDelecteParkingArea.Checked = false;
                    cbAddMoreSpaces.Checked = false;


                    //MessageBox.Show("Parking Area Successfully Updated.");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Info;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Parking Area Successfully Updated.";
                    popup.Popup(); // show
                    pnlUpdateArea.Visible = false;
                }
                catch { MessageBox.Show(error); }
            }
            else
            {
                if (matTextParkingAreaNameUpadate.Text == "Parking Area Name")
                {
                    error += "Parking Area Name is empty";
                }
                if (matTextParkingAreaLocationUpdate.Text == " Parking Area Location. ")
                {
                    error += " Parking Area Location is empty. ";
                }
                if (NewCoordinates == "")
                {
                    error += " Parking Area Coordinates are emptry ";
                }

                MessageBox.Show(error);
            }
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
            matbtnBacktoSpaces.Visible = true;
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
                polygon.Fill = new SolidBrush(System.Drawing.Color.FromArgb(50, System.Drawing.Color.Red));
                polygon.Stroke = new Pen(System.Drawing.Color.Red, 1);
                polyOverlay.Polygons.Add(polygon);
                map.Overlays.Add(polyOverlay);
                map.Refresh();
                map.Zoom += 1;
                map.Zoom -= 1;
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Error;
                popup.TitleText = "UniPark";
                popup.ContentText = "There is no location assigned to this parking area";
                popup.Popup(); // show
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


            try
            {
                IDBHandler handler = new DBHandler();

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
                        for (int i = 2; i < arraypoints.Length - 1; i += 2)
                        {
                            dlat = Convert.ToDouble(arraypoints[i], CultureInfo.InvariantCulture);
                            dlong = Convert.ToDouble(arraypoints[i + 1], CultureInfo.InvariantCulture);
                            points.Add(new PointLatLng(dlat, dlong));

                        }
                        GMapOverlay polyOverlay = new GMapOverlay("polygons");
                        var polygon = new GMapPolygon(points, PA.ParkingAreaName);
                        polygon.Fill = new SolidBrush(System.Drawing.Color.FromArgb(50, System.Drawing.Color.Red));
                        polygon.Stroke = new Pen(System.Drawing.Color.Red, 1);
                        polyOverlay.Polygons.Add(polygon);
                        mapMain.Overlays.Add(polyOverlay);

                        map.Refresh();
                        map.Zoom += 1;
                        map.Zoom -= 1;

                    }
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            th.Start();
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
            if (matTextEditPersonelSearch.Text == "")
            {
                matTextEditPersonelSearch.Text = "Personnel Number or Name";
                IDBHandler handler3 = new DBHandler();
                DataTable dt3 = handler3.BLL_GetPersonel();
                dgvEditPersonel.DataSource = dt3;
            }

            
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
                    polygon.Fill = new SolidBrush(System.Drawing.Color.FromArgb(50, System.Drawing.Color.Red));
                    polygon.Stroke = new Pen(System.Drawing.Color.Red, 1);
                    polyOverlay.Polygons.Add(polygon);
                    mapSearch.Overlays.Add(polyOverlay);
                    mapSearch.Refresh();
                    mapSearch.Zoom += 1;
                    mapSearch.Zoom -= 1; 
            }
                else
                {
                    
                     PopupNotifier popup = new PopupNotifier();
                     popup.Image = Properties.Resources.Error;
                     popup.TitleText = "UniPark";
                     popup.ContentText = "There is no location assigned to this parking area";
                     popup.Popup(); // show

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
                mapAdd_Edit_Coord.Overlays.Remove(Tmarkers);
                Tmarkers.Clear();
                var point = mapAdd_Edit_Coord.FromLocalToLatLng(e.X, e.Y);
                double lat = point.Lat;
                double lng = point.Lng;

                lblLatCoord.Text = lat.ToString();
                lblLongCoord.Text = lng.ToString();

                PointLatLng points = new PointLatLng(lat, lng);
                GMapMarker Tempmarker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);

                

                
                Tmarkers.Markers.Add(Tempmarker);
                mapAdd_Edit_Coord.Overlays.Add(Tmarkers);


            }
        }

        private void matLoadMarker_Click(object sender, EventArgs e)
        {
            if (lblLatCoord.Text != "" && lblLongCoord.Text != "")
            {
                NewCoordinates = lblLatCoord.Text + ", " + lblLongCoord.Text;
                mapAdd_Edit_Coord.Overlays.Remove(Tmarkers);
                Tmarkers.Clear();

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

            mapAdd_Edit_Coord.Overlays.Remove(Tmarkers);
            Tmarkers.Clear();


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
                polygon.Fill = new SolidBrush(System.Drawing.Color.FromArgb(50, System.Drawing.Color.Red));
                polygon.Stroke = new Pen(System.Drawing.Color.Red, 1);
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
            mapAdd_Edit_Coord.Overlays.Remove(Tmarkers);
            Tmarkers.Clear();

            if (PolyCount > 3 && TempCoordinates != "")
            {
                NewCoordinates += TempCoordinates;

                
                mapAdd_Edit_Coord.Overlays.Clear();  
                TempCoordinates = "";
                lblLatCoord.Text = "";
                lblLongCoord.Text = "";


                lblCaption.Text = "Please select center point of Parking Area";
                matbtnAddPolyPoint.Visible = false;
                matbtnSaveTotalArea.Visible = false;
                matbtnLoadMarker.Visible = true;

                mapAdd_Edit_Coord.Refresh();

               // MessageBox.Show("Parking Area Coordinates Successfully Added");
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Info;
                popup.TitleText = "UniPark";
                popup.ContentText = "Parking Area Coordinates Successfully Added";
                popup.Popup();

                if (On_Add == true)
                {
                    PanelVisible("pnlAddParkings");
                }
                else PanelVisible("pnlUpdateParkings");

            }

            else
            {
               // MessageBox.Show("Unsuccessful attemp please try again");
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Error;
                popup.TitleText = "UniPark";
                popup.ContentText = "Unsuccessful attemp please try again";
                popup.Popup();

                mapAdd_Edit_Coord.Overlays.Clear();
                NewCoordinates = "";
                TempCoordinates = "";
                lblLatCoord.Text = "";
                lblLongCoord.Text = "";


                lblCaption.Text = "Please select center point of Parking Area";
                matbtnAddPolyPoint.Visible = false;
                matbtnSaveTotalArea.Visible = false;
                matbtnLoadMarker.Visible = true;
                mapAdd_Edit_Coord.Overlays.Remove(Tmarkers);
                Tmarkers.Clear();

                mapAdd_Edit_Coord.Refresh();
            }

        }

        private void pnlAdd_EditMap_Leave(object sender, EventArgs e)
        {
            
            

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
            On_Add = false;
            NewCoordinates = "";
            
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
            mapAdd_Edit_Coord.Overlays.Remove(Tmarkers);
            Tmarkers.Clear();

            mapAdd_Edit_Coord.Refresh();
        }
        private bool isAllString(string text)
        {
            string letterpattern = @"^[a-zA-Z\x20]+$";
            Regex regex = new Regex(letterpattern);

            return regex.IsMatch(text);
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {

            IDBHandler handler = new DBHandler();
            DataTable dt = handler.BLL_getInfringements(mattextboxInfringements.Text);

            dgvViewUsers.DataSource = dt;
            if (dgvViewUsers.Rows.Count == 0)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Error;
                popup.TitleText = "UniPark";
                popup.ContentText = "No Infringements Found for "+ mattextboxInfringements.Text;
                popup.Popup();
            }
        }

        private void mattextboxInfringements_Click(object sender, EventArgs e)
        {
            mattextboxInfringements.Text = "";

        }

        private void mattextboxInfringements_Leave(object sender, EventArgs e)
        {
            if (mattextboxInfringements.Text != "")
            {
                mattextboxInfringements.Text = mattextboxInfringements.Text;
            }
            else
            {
                mattextboxInfringements.Text = "Personnel ID Number";
            }
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

        private void cbAddMoreSpaces_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAddMoreSpaces.Checked == true)
            {
                lblMoreCovered.Visible = true;
                lblMoreUncovered.Visible = true;
                nupCovered.Visible = true;
                nupUncovered.Visible = true;
            }
            else
            {
                lblMoreCovered.Visible = false;
                lblMoreUncovered.Visible = false;
                nupCovered.Visible = false;
                nupUncovered.Visible = false;
            }
        }

        private void mapAdd_Edit_Coord_Leave(object sender, EventArgs e)
        {
            
            
        }

        private void dgvViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dgvViewUsers[0, dgvViewUsers.CurrentRow.Index].Value.ToString();
            label8.Text = ID;

        }

        private void matBtnShowPassword_MouseHover(object sender, EventArgs e)
        {
            mattextPassword.PasswordChar = Char.MinValue;
        }

        private void matBtnShowPassword_MouseLeave(object sender, EventArgs e)
        {
            if (mattextPassword.Text == "Password")
            { mattextPassword.PasswordChar = Char.MinValue; }
            else
            {
                mattextPassword.PasswordChar = '*';

            }
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

       


        private void matbtnAutoAssign_Click(object sender, EventArgs e)
        {
            IDBHandler handler = new DBHandler();
            List<ParkingRequest> PRlist = new List<ParkingRequest>();
            PRlist = handler.BLL_GetAllRequests();
            List<ParkingSpacePersonnel> PSPlist = new List<ParkingSpacePersonnel>();
            PSPlist = handler.BLL_GetAllParkingSpacePersonnel();

            if (PRlist.Count != 0)
            {



                foreach (ParkingRequest PR in PRlist.ToList())
                {
                    int spaceID = PR.ParkingSpaceID;
                    DateTime FirstDate = PR.ParkingRequestTime;

                    foreach (ParkingRequest PR2 in PRlist.ToList())
                    {
                        if (spaceID == PR2.ParkingSpaceID && FirstDate > PR2.ParkingRequestTime)
                        {
                            FirstDate = PR2.ParkingRequestTime;
                        }
                    }

                    foreach (ParkingRequest PR3 in PRlist.ToList())
                    {


                        if (spaceID == PR3.ParkingSpaceID && FirstDate == PR3.ParkingRequestTime)
                        {
                            if (PSPlist != null)
                            {
                                foreach (ParkingSpacePersonnel PSP in PSPlist)
                                {
                                    if (PR3.PersonnelID == PSP.PersonnelID)
                                    {
                                        handler.BLL_UpdatePersonnelParkingSpace(PR3.PersonnelID);  // IF Personnel Allready has a parking
                                        handler.BLL_ChangeSpaceAvailability(PSP.ParkingSpaceID, true); // Make Parkfing Space Available again
                                    }
                                }
                            }
                            

                            handler.BLL_AssignParkingSpace(PR3.ParkingSpaceID, PR3.PersonnelID, PR3.ParkingRequestID);
                            
                            PRlist.Remove(PR3);
                            //EMAIL to USER SPACE is ALLOCATED to them..........

                        }
                        else if (spaceID == PR3.ParkingSpaceID)
                        {
                            
                            handler.BLL_RequestParkingFail(PR3.ParkingRequestID);
                            PRlist.Remove(PR3);
                            // EMAIL to user that parking request wass un successfull
                        }
                    }

                }
                matbtnAutoAssign.Visible = false;
                dgvAssignParkings.Visible = false;
                lblNoRequests.Visible = true;
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Info;
                popup.TitleText = "UniPark";
                popup.ContentText = "All request have been successfully Assigned";
                popup.Popup();

            }
            else 
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Info;
                popup.TitleText = "UniPark";
                popup.ContentText = "There are no Requests at this time to assign.";
                popup.Popup(); // show
                matbtnAutoAssign.Visible = false;
            }
        }

        private void materialFlatButton8_Click(object sender, EventArgs e)
        {
            mattextReportResult.Text = "SYSTEM";
            materialFlatButton7.Enabled = true;
            panelReport.Visible = true;



        }

        private void mattextboxReportSearch_Click(object sender, EventArgs e)
        {
            mattextboxReportSearch.Text = "";
            mattextReportResult.Text = "";
            materialFlatButton7.Enabled = false;
        }

        private void mattextboxReportSearch_Leave(object sender, EventArgs e)
        {
            if (mattextboxReportSearch.Text == "")
            {
                mattextboxReportSearch.Text = "Personnel Number / Numberplate";
            }
        }

        public void CreateWordDocument(string filePath, DataTable data, string text, string[] heading)

        {
            WordprocessingDocument doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
            MainDocumentPart mainDocPart = doc.AddMainDocumentPart();
            mainDocPart.Document = new Document();
            Body body = new Body();
            mainDocPart.Document.Append(body);

            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text(text));


            DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();

            TableProperties tblProp = new TableProperties(
                    new TableBorders(new TopBorder()
                    { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 },
                        new BottomBorder()
                        { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 },                                              
                        new InsideHorizontalBorder()
                        { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 },
                        new InsideVerticalBorder()
                        { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 })
                );
            table.Append(tblProp);

            TableRow row2 = new TableRow();

            for (int k = 0; k < heading.Count();k++ )
            {
               

                    TableCell cell2 = new TableCell();
                    cell2.Append(new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(heading[k].ToString()))));

                  

                cell2.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "1500" }));
                    row2.Append(cell2);
                
                
            }
            table.Append(row2);




            for (int i = 0; i < data.Rows.Count; ++i)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    TableCell cell = new TableCell();
                    cell.Append(new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(data.Rows[i][j].ToString()))));
                    cell.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "1500" }));
                    row.Append(cell);
                }
                table.Append(row);
            }
            
            body.Append(table);
            doc.MainDocumentPart.Document.Save();
            doc.Dispose();
            Process.Start("WINWORD.exe", filePath);
        }

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {
            IDBHandler handler2 = new DBHandler();
            infos = handler2.BLL_getallinfo(mattextboxReportSearch.Text);
            try {
                if (infos.PersonnelID != "")
                {


                    mattextReportResult.Text = infos.PersonnelID + " " + infos.PersonnelName + " " + infos.PersonnelSurname;
                    panelReport.Visible = true;
                    materialFlatButton7.Enabled = true;

                }
                else if (mattextboxReportSearch.Text == "Personnel Number")
                {
                    MessageBox.Show("Please Enter A Value In The Search Bar");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Info;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Please Enter A Value In The Search Bar";
                    popup.Popup();
                }
            }
            catch {
            
             //MessageBox.Show(mattextboxReportSearch.Text + " Not Found.");
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Error;
                popup.TitleText = "UniPark";
                popup.ContentText = mattextboxReportSearch.Text + " Not Found.";
                popup.Popup();
            }

        }
        private void materialFlatButton7_Click(object sender, EventArgs e)
        {

            var dateAndTime = datepickerBegin.Value;
            var date = dateAndTime.Date;
            DateTime begin = date;

            dateAndTime = datepickerEnd.Value;
            date = dateAndTime.Date;
            DateTime end = date;

            string[] infringementheadingS = {"ReportID","Personnel ID","Name,Surname","Report Info","Date","Amount" };
            string[] parkingS = { "Parking Space","Personnel ID","Name Surname","Location"};
            string[] LogS = {"Log Number","Personnel ID","Name Surname","LisencePlate IN","LisencePlate OUT","ENTER Time","EXIT Time"};
            string[] infringementheadingI = { "ReportID", "Personnel ID", "Name","Description","Date And Time" ,"Fine"};
            string[] parkingI1 = {"Request ID","Parking Space","Campus","Location", "Request Date" };
            string[] parkingI2 = {"Parking Space", "Personnel Number", "Name Surname", "Location"};
            string[] LogI = { "Log Number", "Personnel ID", "Gate Name", "LisencePlate IN", "LisencePlate OUT", "ENTER Time", "EXIT Time" };


            if (mattextReportResult.Text == "SYSTEM")
            {
                infos = null;
                if (matrdobtnInfringements.Checked)
                {
                    IDBHandler handler3 = new DBHandler();
                    DataTable dt = handler3.BLL_GetInfringementsS(begin, end);

                    string text = "UniPark System Infringements Report";

                    CreateWordDocument(@"..\SYSTEM_Infringment_Report.docx", dt, text, infringementheadingS);
                    materialFlatButton7.Enabled = false;
                }
                else if (matrdobtnParking.Checked)
                {
                    IDBHandler handler3 = new DBHandler();
                    DataTable dt = handler3.BLL_GetParkingReportS();
                    string text = "UniPark System Parking Log Report";
                    CreateWordDocument(@"..\SYSTEM_Parking_Log_Report.docx", dt, text, parkingS);
                    materialFlatButton7.Enabled = false;

                }
                else if (matrdobtnLog.Checked)
                {
                    IDBHandler handler3 = new DBHandler();
                    DataTable dt = handler3.BLL_GetEntranceLogS(begin, end);

                    string text = "UniPark System Entrance Log Report";

                    CreateWordDocument(@"..\SYSTEM_Entrance_Log_Report.docx", dt, text, LogS);
                    materialFlatButton7.Enabled = false;
                }
                else { //MessageBox.Show("Please Select A Report Type.");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Error;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Please Select A Report Type.";
                    popup.Popup();
                }
            }
            else if (infos != null)
            {

                if (matrdobtnInfringements.Checked)
                {
                    IDBHandler handler3 = new DBHandler();
                    DataTable dt = handler3.BLL_GetInfringementsI(infos.PersonnelID.ToString(), begin, end);

                    string text = "UniPark Individual Infringements Report: " + infos.PersonnelID.ToString() + " " + infos.PersonnelName.ToString() + " " + infos.PersonnelSurname.ToString();

                    CreateWordDocument(@"..\" + infos.PersonnelID + "_Infringment_Report.docx", dt, text, infringementheadingI);

                    materialFlatButton7.Enabled = false;
                    mattextboxReportSearch.Text = "Personnel Number";
                }
                else if (matrdobtnParking.Checked)
                {
                    IDBHandler handler3  = new DBHandler();
                    DataTable dt1 = handler3.BLL_GetParkingRequestReport(infos.PersonnelID);
                    DataTable dt2 = handler3.BLL_GetParkingReportI(infos.PersonnelID);
                    string text1 = "UniPark Individual Parking Request Report: " + infos.PersonnelID.ToString() + " " + infos.PersonnelName.ToString() + " " + infos.PersonnelSurname.ToString();
                    string text2 = "UniPark Individual Parking Report: " + infos.PersonnelID.ToString() + " " + infos.PersonnelName.ToString() + " " + infos.PersonnelSurname.ToString();

                    CreateWordDocumentParking(@"..\" + infos.PersonnelID + "_Parking_Report.docx", dt1, dt2, text1, text2, parkingI1,parkingI2);

                    materialFlatButton7.Enabled = false;
                    mattextboxReportSearch.Text = "Personnel Number";


                }
                else if (matrdobtnLog.Checked)
                {
                    IDBHandler handler3 = new DBHandler();
                    DataTable dt = handler3.BLL_GetEntranceLogI(infos.PersonnelID.ToString(), begin, end);

                    string text = "UniPark Entrance Log Report: " + infos.PersonnelID.ToString() + " " + infos.PersonnelName.ToString() + " " + infos.PersonnelSurname.ToString();

                    CreateWordDocument(@"..\" + infos.PersonnelID + "_Entrance_Log_Report.docx", dt, text, LogI);

                    materialFlatButton7.Enabled = false;
                    mattextboxReportSearch.Text = "Personnel Number";
                }
                else { //MessageBox.Show("Please Select A Report Type.");
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Error;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Please Select A Report Type.";
                    popup.Popup();
                }
            }
            infos = null;
            panelReport.Visible = false;


        }

        private void materialFlatButton9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. First enter the Personnel number or name/surname in the Search Bar." + "\n" + "2. Then Select The Dates Between which The Report Must Be Generated" + "\n" + "3. Then Select The Type Of Report to be Generated" + "\n" + "4. Then click the Generate Report Button For a Document of the Generated Report.");
        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            try {
                IDBHandler handler = new DBHandler();
                string id = label8.Text;
                handler.BLL_UpdateInfringementPaid(id);
            }
            catch
            {
               // MessageBox.Show("Fine Payment Unsuccessfull");
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Error;
                popup.TitleText = "UniPark";
                popup.ContentText = "Fine Payment Unsuccessfull";
                popup.Popup();

            }
            IDBHandler handler1 = new DBHandler();
            DataTable dt = handler1.BLL_getInfringements(mattextboxInfringements.Text);

            dgvViewUsers.DataSource = dt;
        }

        private void dgvViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void matbtnBacktoSpaces_Click(object sender, EventArgs e)
        {
            PanelVisible("pnlViewParkings");
            matbtnViewSingleAreaMap.Visible = true;
            matbtnBacktoSpaces.Visible = false;
            
        }

        private void materialFlatButton10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Search for the user you received fine payment from. \n2. Select the fine and press mark fine as paid.");
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Fill out relevant data into the fields to add a user to the system. \n2. Press enter to add the user to sytem.");
        }

        private void materialFlatButton11_Click(object sender, EventArgs e)
        {
            if (mattextboxReportSearch.Text != "" || mattextboxReportSearch.Text != "Personnel Number / Numberplate")
            {
                mattextReportResult.Text = mattextboxReportSearch.Text;
                try
                {
                    IDBHandler handler1 = new DBHandler();
                    DataTable dt = handler1.BLL_GetLicensePlateLog(mattextReportResult.Text);
                    if (dt.Rows.Count > 0)
                    {
                        string text = "Lisence Plate report for: " + mattextReportResult.Text;
                        string[] headingLisence = new string[] { "Log ID","Personnel ID", "Gate ID", "Lisenceplate IN", "Time IN", "Lisence OUT", "Time OUT"};
                        CreateWordDocument(@"..\" + mattextReportResult.Text + "_Lisence_Plate_Report.docx", dt, text,headingLisence);
                    }
                    else
                    {
                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.Error;
                        popup.TitleText = "UniPark";
                        popup.ContentText = "Lisence Plate Not Found.";
                        popup.Popup();
                    }
                }
                catch
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.Error;
                    popup.TitleText = "UniPark";
                    popup.ContentText = "Database Connection Error";
                    popup.Popup();
                }
            }
        }

        private void mattextReportResult_Click(object sender, EventArgs e)
        {

        }

        public void CreateWordDocumentParking(string filePath, DataTable data1, DataTable data2, string text, string text2, string[] heading1, string[] heading2)

        {
            WordprocessingDocument doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
            MainDocumentPart mainDocPart = doc.AddMainDocumentPart();
            mainDocPart.Document = new Document();
            Body body = new Body();
            mainDocPart.Document.Append(body);

            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text(text));
//table1
            DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();
            TableProperties tblProp = new TableProperties(
                    new TableBorders(new TopBorder()
                    { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 },
                        new BottomBorder()
                        { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 },
                        
                        new InsideHorizontalBorder()
                        { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 },
                        new InsideVerticalBorder()
                        { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 })
                );
            table.Append(tblProp);

            TableRow row2 = new TableRow();

            for (int k = 0; k < heading1.Count(); k++)
            {


                TableCell cell2 = new TableCell();
                cell2.Append(new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(heading1[k].ToString()))));



                cell2.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "1500" }));
                row2.Append(cell2);


            }
            table.Append(row2);


            for (int i = 0; i < data1.Rows.Count; ++i)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < data1.Columns.Count; j++)
                {
                    TableCell cell = new TableCell();
                    cell.Append(new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(data1.Rows[i][j].ToString()))));
                    cell.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "1500" }));
                    row.Append(cell);
                }
                table.Append(row);
            }
            body.Append(table);
            //table2

            Paragraph para2 = body.AppendChild(new Paragraph());
            Run run2 = para2.AppendChild(new Run());
            run2.AppendChild(new Text(text2));

            DocumentFormat.OpenXml.Wordprocessing.Table table2 = new DocumentFormat.OpenXml.Wordprocessing.Table();

            TableProperties tblProp2 = new TableProperties(
                    new TableBorders(new TopBorder()
                    { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 },
                        new BottomBorder()
                        { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 },
                       
                        new InsideHorizontalBorder()
                        { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 },
                        new InsideVerticalBorder()
                        { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 2 })
                );
            table2.Append(tblProp2);

            TableRow row3 = new TableRow();

            for (int k = 0; k < heading2.Count(); k++)
            {


                TableCell cell3 = new TableCell();
                cell3.Append(new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(heading2[k].ToString()))));



                cell3.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "1500" }));
                row3.Append(cell3);


            }
            table2.Append(row3);






            for (int i = 0; i < data2.Rows.Count; ++i)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < data2.Columns.Count; j++)
                {
                    TableCell cell = new TableCell();
                    cell.Append(new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(data2.Rows[i][j].ToString()))));
                    cell.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "1500" }));
                    row.Append(cell);
                }
                table2.Append(row);
            }

            body.Append(table2);




            doc.MainDocumentPart.Document.Save();
            doc.Dispose();
            Process.Start("WINWORD.exe", filePath);
        }



    }
}