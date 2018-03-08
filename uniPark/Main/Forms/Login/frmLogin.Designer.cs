namespace uniPark.Main.Forms.Login
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnclose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.matTextUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.matTextPass = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblIncorrect = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.matBtnLogin = new MaterialSkin.Controls.MaterialFlatButton();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(280, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(23, 22);
            this.btnclose.TabIndex = 8;
            this.btnclose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(251, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(23, 22);
            this.btnMinimize.TabIndex = 9;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.button1_Click);
            // 
            // matTextUsername
            // 
            this.matTextUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.matTextUsername.Depth = 0;
            this.matTextUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matTextUsername.ForeColor = System.Drawing.Color.White;
            this.matTextUsername.Hint = "Enter Username";
            this.matTextUsername.Location = new System.Drawing.Point(12, 214);
            this.matTextUsername.MaxLength = 30;
            this.matTextUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.matTextUsername.Name = "matTextUsername";
            this.matTextUsername.PasswordChar = '\0';
            this.matTextUsername.SelectedText = "";
            this.matTextUsername.SelectionLength = 0;
            this.matTextUsername.SelectionStart = 0;
            this.matTextUsername.Size = new System.Drawing.Size(285, 23);
            this.matTextUsername.TabIndex = 10;
            this.matTextUsername.TabStop = false;
            this.matTextUsername.UseSystemPasswordChar = false;
            this.matTextUsername.Click += new System.EventHandler(this.matTextUsername_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnclose);
            this.pnlMenu.Controls.Add(this.btnMinimize);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(311, 31);
            this.pnlMenu.TabIndex = 11;
            // 
            // matTextPass
            // 
            this.matTextPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.matTextPass.Depth = 0;
            this.matTextPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matTextPass.ForeColor = System.Drawing.Color.White;
            this.matTextPass.Hint = "Enter Password";
            this.matTextPass.Location = new System.Drawing.Point(12, 256);
            this.matTextPass.MaxLength = 30;
            this.matTextPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.matTextPass.Name = "matTextPass";
            this.matTextPass.PasswordChar = '\0';
            this.matTextPass.SelectedText = "";
            this.matTextPass.SelectionLength = 0;
            this.matTextPass.SelectionStart = 0;
            this.matTextPass.Size = new System.Drawing.Size(285, 23);
            this.matTextPass.TabIndex = 12;
            this.matTextPass.TabStop = false;
            this.matTextPass.UseSystemPasswordChar = false;
            // 
            // lblIncorrect
            // 
            this.lblIncorrect.AutoSize = true;
            this.lblIncorrect.ForeColor = System.Drawing.Color.Red;
            this.lblIncorrect.Location = new System.Drawing.Point(59, 284);
            this.lblIncorrect.Name = "lblIncorrect";
            this.lblIncorrect.Size = new System.Drawing.Size(188, 13);
            this.lblIncorrect.TabIndex = 14;
            this.lblIncorrect.Text = "Username / Password is INCORRECT";
            this.lblIncorrect.Visible = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(73, 37);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(165, 147);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 15;
            this.pbLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(9, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "UserName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(9, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Password";
            // 
            // matBtnLogin
            // 
            this.matBtnLogin.AutoSize = true;
            this.matBtnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnLogin.Depth = 0;
            this.matBtnLogin.Icon = ((System.Drawing.Image)(resources.GetObject("matBtnLogin.Icon")));
            this.matBtnLogin.Location = new System.Drawing.Point(102, 313);
            this.matBtnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matBtnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnLogin.Name = "matBtnLogin";
            this.matBtnLogin.Primary = false;
            this.matBtnLogin.Size = new System.Drawing.Size(89, 36);
            this.matBtnLogin.TabIndex = 19;
            this.matBtnLogin.Text = "Login";
            this.matBtnLogin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.matBtnLogin.UseVisualStyleBackColor = true;
            this.matBtnLogin.Click += new System.EventHandler(this.matBtnLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(311, 374);
            this.Controls.Add(this.matBtnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblIncorrect);
            this.Controls.Add(this.matTextPass);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.matTextUsername);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Resize += new System.EventHandler(this.frmLogin_Resize);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnMinimize;
        private MaterialSkin.Controls.MaterialSingleLineTextField matTextUsername;
        private System.Windows.Forms.Panel pnlMenu;
        private MaterialSkin.Controls.MaterialSingleLineTextField matTextPass;
        private System.Windows.Forms.Label lblIncorrect;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialFlatButton matBtnLogin;
    }
}