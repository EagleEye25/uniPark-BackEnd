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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLanding));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.matBtnEditUser = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnMenu = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnSearchUser = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnViewParking = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnAddUser = new MaterialSkin.Controls.MaterialFlatButton();
            this.matbtnSearchParking = new MaterialSkin.Controls.MaterialFlatButton();
            this.matBtnViewUsers = new MaterialSkin.Controls.MaterialFlatButton();
            this.matbtnUpdateParking = new MaterialSkin.Controls.MaterialFlatButton();
            this.matbtnAssignParking = new MaterialSkin.Controls.MaterialFlatButton();
            this.tmrSlide = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.pnlMenu.Controls.Add(this.label8);
            this.pnlMenu.Controls.Add(this.label7);
            this.pnlMenu.Controls.Add(this.label6);
            this.pnlMenu.Controls.Add(this.label5);
            this.pnlMenu.Controls.Add(this.label4);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.label1);
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
            this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenu_Paint);
            // 
            // matBtnEditUser
            // 
            this.matBtnEditUser.AutoSize = true;
            this.matBtnEditUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnEditUser.Depth = 0;
            this.matBtnEditUser.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnEditUser.Icon")));
            this.matBtnEditUser.Location = new System.Drawing.Point(3, 390);
            this.matBtnEditUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnEditUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnEditUser.Name = "matBtnEditUser";
            this.matBtnEditUser.Primary = false;
            this.matBtnEditUser.Size = new System.Drawing.Size(44, 36);
            this.matBtnEditUser.TabIndex = 10;
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
            this.matBtnSearchUser.Size = new System.Drawing.Size(44, 36);
            this.matBtnSearchUser.TabIndex = 9;
            this.matBtnSearchUser.UseVisualStyleBackColor = true;
            // 
            // matBtnViewParking
            // 
            this.matBtnViewParking.AutoSize = true;
            this.matBtnViewParking.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnViewParking.Depth = 0;
            this.matBtnViewParking.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnViewParking.Icon")));
            this.matBtnViewParking.Location = new System.Drawing.Point(3, 54);
            this.matBtnViewParking.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnViewParking.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnViewParking.Name = "matBtnViewParking";
            this.matBtnViewParking.Primary = false;
            this.matBtnViewParking.Size = new System.Drawing.Size(44, 36);
            this.matBtnViewParking.TabIndex = 3;
            this.matBtnViewParking.UseVisualStyleBackColor = true;
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
            this.matBtnAddUser.Size = new System.Drawing.Size(44, 36);
            this.matBtnAddUser.TabIndex = 8;
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
            this.matbtnSearchParking.Size = new System.Drawing.Size(44, 36);
            this.matbtnSearchParking.TabIndex = 4;
            this.matbtnSearchParking.UseVisualStyleBackColor = true;
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
            this.matBtnViewUsers.Size = new System.Drawing.Size(44, 36);
            this.matBtnViewUsers.TabIndex = 7;
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
            this.matbtnUpdateParking.Size = new System.Drawing.Size(44, 36);
            this.matbtnUpdateParking.TabIndex = 5;
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
            this.matbtnAssignParking.Size = new System.Drawing.Size(44, 36);
            this.matbtnAssignParking.TabIndex = 6;
            this.matbtnAssignParking.UseVisualStyleBackColor = true;
            // 
            // tmrSlide
            // 
            this.tmrSlide.Tick += new System.EventHandler(this.tmrSlide_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(54, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "View Parkings";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Search Parkings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(54, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Update Parkings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(54, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Assign Parkings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(54, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "View Users";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(54, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Add Users";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(54, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "Search Users";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(54, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "Modify Users";
            // 
            // frmLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1235, 687);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLanding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLanding";
            this.Load += new System.EventHandler(this.frmLanding_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenu;
        private MaterialSkin.Controls.MaterialFlatButton matBtnMenu;
        private MaterialSkin.Controls.MaterialFlatButton matBtnEditUser;
        private MaterialSkin.Controls.MaterialFlatButton matBtnSearchUser;
        private MaterialSkin.Controls.MaterialFlatButton matBtnViewParking;
        private MaterialSkin.Controls.MaterialFlatButton matBtnAddUser;
        private MaterialSkin.Controls.MaterialFlatButton matbtnSearchParking;
        private MaterialSkin.Controls.MaterialFlatButton matBtnViewUsers;
        private MaterialSkin.Controls.MaterialFlatButton matbtnUpdateParking;
        private MaterialSkin.Controls.MaterialFlatButton matbtnAssignParking;
        private System.Windows.Forms.Timer tmrSlide;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}