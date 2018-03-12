namespace uniPark.Main.Forms.Landing
{
    partial class frmLanding
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLanding));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.matBtnMinimize = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnLogout = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnEditUser = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnMenu = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnSearchUser = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnViewParking = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnAddUser = new MaterialSkin.Controls.MaterialFlatButton();
            this.matbtnSearchParking = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnViewUsers = new MaterialSkin.Controls.MaterialFlatButton();
            this.matbtnUpdateParking = new MaterialSkin.Controls.MaterialFlatButton();
            this.matbtnAssignParking = new MaterialSkin.Controls.MaterialFlatButton();
            this.pnlHeadings = new System.Windows.Forms.Panel();
            this.lblHeadings = new System.Windows.Forms.Label();
            this.pnlViewParkings = new System.Windows.Forms.Panel();
            this.dgvParkings = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMenu.SuspendLayout();
            this.pnlHeadings.SuspendLayout();
            this.pnlViewParkings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkings)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.pnlMenu.Controls.Add(this.matBtnMinimize);
            this.pnlMenu.Controls.Add(this.matBtnLogout);
            this.pnlMenu.Controls.Add(this.matBtnEditUser);
            this.pnlMenu.Controls.Add(this.matBtnMenu);
            this.pnlMenu.Controls.Add(this.matBtnSearchUser);
            this.pnlMenu.Controls.Add(this.matBtnViewParking);
            this.pnlMenu.Controls.Add(this.matBtnAddUser);
            this.pnlMenu.Controls.Add(this.matbtnSearchParking);
            this.pnlMenu.Controls.Add(this.matBtnViewUsers);
            this.pnlMenu.Controls.Add(this.matbtnUpdateParking);
            this.pnlMenu.Controls.Add(this.matbtnAssignParking);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(207, 687);
            this.pnlMenu.TabIndex = 1;
            // 
            // matBtnMinimize
            // 
            this.matBtnMinimize.AutoSize = true;
            this.matBtnMinimize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnMinimize.Depth = 0;
            this.matBtnMinimize.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnMinimize.Icon")));
            this.matBtnMinimize.Location = new System.Drawing.Point(4, 597);
            this.matBtnMinimize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnMinimize.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnMinimize.Name = "matBtnMinimize";
            this.matBtnMinimize.Primary = false;
            this.matBtnMinimize.Size = new System.Drawing.Size(189, 36);
            this.matBtnMinimize.TabIndex = 1;
            this.matBtnMinimize.Text = "      Minimize                 ";
            this.matBtnMinimize.UseVisualStyleBackColor = true;
            this.matBtnMinimize.Click += new System.EventHandler(this.matBtnMinimize_Click);
            // 
            // matBtnLogout
            // 
            this.matBtnLogout.AutoSize = true;
            this.matBtnLogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnLogout.Depth = 0;
            this.matBtnLogout.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnLogout.Icon")));
            this.matBtnLogout.Location = new System.Drawing.Point(4, 645);
            this.matBtnLogout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnLogout.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnLogout.Name = "matBtnLogout";
            this.matBtnLogout.Primary = false;
            this.matBtnLogout.Size = new System.Drawing.Size(191, 36);
            this.matBtnLogout.TabIndex = 20;
            this.matBtnLogout.Text = "      Logout                    ";
            this.matBtnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.matBtnLogout.UseVisualStyleBackColor = true;
            this.matBtnLogout.Click += new System.EventHandler(this.matBtnLogout_Click);
            // 
            // matBtnEditUser
            // 
            this.matBtnEditUser.AutoSize = true;
            this.matBtnEditUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnEditUser.Depth = 0;
            this.matBtnEditUser.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnEditUser.Icon")));
            this.matBtnEditUser.Location = new System.Drawing.Point(4, 390);
            this.matBtnEditUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnEditUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnEditUser.Name = "matBtnEditUser";
            this.matBtnEditUser.Primary = false;
            this.matBtnEditUser.Size = new System.Drawing.Size(196, 36);
            this.matBtnEditUser.TabIndex = 10;
            this.matBtnEditUser.Text = "      View Parkings       ";
            this.matBtnEditUser.UseVisualStyleBackColor = true;
            // 
            // matBtnMenu
            // 
            this.matBtnMenu.AutoSize = true;
            this.matBtnMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnMenu.Depth = 0;
            this.matBtnMenu.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnMenu.Icon")));
            this.matBtnMenu.Location = new System.Drawing.Point(3, 6);
            this.matBtnMenu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnMenu.Name = "matBtnMenu";
            this.matBtnMenu.Primary = false;
            this.matBtnMenu.Size = new System.Drawing.Size(44, 36);
            this.matBtnMenu.TabIndex = 3;
            this.matBtnMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.matBtnMenu.UseVisualStyleBackColor = true;
            this.matBtnMenu.Click += new System.EventHandler(this.matBtnMenu_Click);
            // 
            // matBtnSearchUser
            // 
            this.matBtnSearchUser.AutoSize = true;
            this.matBtnSearchUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnSearchUser.Depth = 0;
            this.matBtnSearchUser.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnSearchUser.Icon")));
            this.matBtnSearchUser.Location = new System.Drawing.Point(3, 342);
            this.matBtnSearchUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnSearchUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnSearchUser.Name = "matBtnSearchUser";
            this.matBtnSearchUser.Primary = false;
            this.matBtnSearchUser.Size = new System.Drawing.Size(191, 36);
            this.matBtnSearchUser.TabIndex = 9;
            this.matBtnSearchUser.Text = "      Search Users       ";
            this.matBtnSearchUser.UseVisualStyleBackColor = true;
            // 
            // matBtnViewParking
            // 
            this.matBtnViewParking.AutoSize = true;
            this.matBtnViewParking.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnViewParking.Depth = 0;
            this.matBtnViewParking.ForeColor = System.Drawing.Color.White;
            this.matBtnViewParking.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnViewParking.Icon")));
            this.matBtnViewParking.Location = new System.Drawing.Point(3, 54);
            this.matBtnViewParking.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnViewParking.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnViewParking.Name = "matBtnViewParking";
            this.matBtnViewParking.Primary = false;
            this.matBtnViewParking.Size = new System.Drawing.Size(192, 36);
            this.matBtnViewParking.TabIndex = 3;
            this.matBtnViewParking.Text = "      View Parkings      ";
            this.matBtnViewParking.UseVisualStyleBackColor = true;
            this.matBtnViewParking.Click += new System.EventHandler(this.matBtnViewParking_Click);
            // 
            // matBtnAddUser
            // 
            this.matBtnAddUser.AutoSize = true;
            this.matBtnAddUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnAddUser.Depth = 0;
            this.matBtnAddUser.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnAddUser.Icon")));
            this.matBtnAddUser.Location = new System.Drawing.Point(3, 294);
            this.matBtnAddUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnAddUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnAddUser.Name = "matBtnAddUser";
            this.matBtnAddUser.Primary = false;
            this.matBtnAddUser.Size = new System.Drawing.Size(193, 36);
            this.matBtnAddUser.TabIndex = 8;
            this.matBtnAddUser.Text = "      Add Users               ";
            this.matBtnAddUser.UseVisualStyleBackColor = true;
            // 
            // matbtnSearchParking
            // 
            this.matbtnSearchParking.AutoSize = true;
            this.matbtnSearchParking.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matbtnSearchParking.Depth = 0;
            this.matbtnSearchParking.Icon = ((System.Drawing.Image)(resources.GetObject("matbtnSearchParking.Icon")));
            this.matbtnSearchParking.Location = new System.Drawing.Point(3, 102);
            this.matbtnSearchParking.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matbtnSearchParking.MouseState = MaterialSkin.MouseState.HOVER;
            this.matbtnSearchParking.Name = "matbtnSearchParking";
            this.matbtnSearchParking.Primary = false;
            this.matbtnSearchParking.Size = new System.Drawing.Size(192, 36);
            this.matbtnSearchParking.TabIndex = 4;
            this.matbtnSearchParking.Text = "      Search Parkings";
            this.matbtnSearchParking.UseVisualStyleBackColor = true;
            this.matbtnSearchParking.Click += new System.EventHandler(this.matbtnSearchParking_Click);
            // 
            // matBtnViewUsers
            // 
            this.matBtnViewUsers.AutoSize = true;
            this.matBtnViewUsers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnViewUsers.Depth = 0;
            this.matBtnViewUsers.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnViewUsers.Icon")));
            this.matBtnViewUsers.Location = new System.Drawing.Point(3, 246);
            this.matBtnViewUsers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnViewUsers.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnViewUsers.Name = "matBtnViewUsers";
            this.matBtnViewUsers.Primary = false;
            this.matBtnViewUsers.Size = new System.Drawing.Size(192, 36);
            this.matBtnViewUsers.TabIndex = 7;
            this.matBtnViewUsers.Text = "      View Users             ";
            this.matBtnViewUsers.UseVisualStyleBackColor = true;
            // 
            // matbtnUpdateParking
            // 
            this.matbtnUpdateParking.AutoSize = true;
            this.matbtnUpdateParking.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matbtnUpdateParking.Depth = 0;
            this.matbtnUpdateParking.Icon = ((System.Drawing.Image)(resources.GetObject("matbtnUpdateParking.Icon")));
            this.matbtnUpdateParking.Location = new System.Drawing.Point(3, 150);
            this.matbtnUpdateParking.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matbtnUpdateParking.MouseState = MaterialSkin.MouseState.HOVER;
            this.matbtnUpdateParking.Name = "matbtnUpdateParking";
            this.matbtnUpdateParking.Primary = false;
            this.matbtnUpdateParking.Size = new System.Drawing.Size(191, 36);
            this.matbtnUpdateParking.TabIndex = 5;
            this.matbtnUpdateParking.Text = "      Update Parkings";
            this.matbtnUpdateParking.UseVisualStyleBackColor = true;
            // 
            // matbtnAssignParking
            // 
            this.matbtnAssignParking.AutoSize = true;
            this.matbtnAssignParking.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matbtnAssignParking.Depth = 0;
            this.matbtnAssignParking.Icon = ((System.Drawing.Image)(resources.GetObject("matbtnAssignParking.Icon")));
            this.matbtnAssignParking.Location = new System.Drawing.Point(3, 198);
            this.matbtnAssignParking.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matbtnAssignParking.MouseState = MaterialSkin.MouseState.HOVER;
            this.matbtnAssignParking.Name = "matbtnAssignParking";
            this.matbtnAssignParking.Primary = false;
            this.matbtnAssignParking.Size = new System.Drawing.Size(191, 36);
            this.matbtnAssignParking.TabIndex = 6;
            this.matbtnAssignParking.Text = "      Assign Parkings ";
            this.matbtnAssignParking.UseVisualStyleBackColor = true;
            // 
            // pnlHeadings
            // 
            this.pnlHeadings.Controls.Add(this.lblHeadings);
            this.pnlHeadings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeadings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHeadings.Location = new System.Drawing.Point(207, 0);
            this.pnlHeadings.Name = "pnlHeadings";
            this.pnlHeadings.Size = new System.Drawing.Size(1028, 30);
            this.pnlHeadings.TabIndex = 4;
            // 
            // lblHeadings
            // 
            this.lblHeadings.BackColor = System.Drawing.Color.PaleGreen;
            this.lblHeadings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeadings.ForeColor = System.Drawing.Color.Black;
            this.lblHeadings.Location = new System.Drawing.Point(0, 0);
            this.lblHeadings.Name = "lblHeadings";
            this.lblHeadings.Size = new System.Drawing.Size(1028, 30);
            this.lblHeadings.TabIndex = 0;
            this.lblHeadings.Text = "Heading";
            this.lblHeadings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlViewParkings
            // 
            this.pnlViewParkings.Controls.Add(this.dgvParkings);
            this.pnlViewParkings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewParkings.Location = new System.Drawing.Point(207, 30);
            this.pnlViewParkings.Name = "pnlViewParkings";
            this.pnlViewParkings.Size = new System.Drawing.Size(1028, 657);
            this.pnlViewParkings.TabIndex = 6;
            // 
            // dgvParkings
            // 
            this.dgvParkings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParkings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParkings.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParkings.Location = new System.Drawing.Point(0, 0);
            this.dgvParkings.Name = "dgvParkings";
            this.dgvParkings.Size = new System.Drawing.Size(1025, 654);
            this.dgvParkings.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "TESTING 1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "testing 2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "testing 3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Column4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Column5";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Column6";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // frmLanding
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1235, 687);
            this.Controls.Add(this.pnlViewParkings);
            this.Controls.Add(this.pnlHeadings);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLanding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLanding";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlHeadings.ResumeLayout(false);
            this.pnlViewParkings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenu;
        private MaterialSkin.Controls.MaterialFlatButton matBtnEditUser;
        private MaterialSkin.Controls.MaterialFlatButton matBtnSearchUser;
        private MaterialSkin.Controls.MaterialFlatButton matBtnViewParking;
        private MaterialSkin.Controls.MaterialFlatButton matBtnAddUser;
        private MaterialSkin.Controls.MaterialFlatButton matbtnSearchParking;
        private MaterialSkin.Controls.MaterialFlatButton matBtnViewUsers;
        private MaterialSkin.Controls.MaterialFlatButton matbtnUpdateParking;
        private MaterialSkin.Controls.MaterialFlatButton matbtnAssignParking;
        private MaterialSkin.Controls.MaterialFlatButton matBtnMenu;
        private MaterialSkin.Controls.MaterialFlatButton matBtnLogout;
        private MaterialSkin.Controls.MaterialFlatButton matBtnMinimize;
        private System.Windows.Forms.Panel pnlHeadings;
        private System.Windows.Forms.Label lblHeadings;
        private System.Windows.Forms.Panel pnlViewParkings;
        private System.Windows.Forms.DataGridView dgvParkings;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}