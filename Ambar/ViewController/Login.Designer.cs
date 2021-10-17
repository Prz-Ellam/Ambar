namespace Ambar.ViewController
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.pbWarningIcon = new System.Windows.Forms.PictureBox();
            this.btnMinimized = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.pbPassword = new System.Windows.Forms.PictureBox();
            this.pbUsername = new System.Windows.Forms.PictureBox();
            this.lblError = new System.Windows.Forms.Label();
            this.cbPositions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            this.gradientPanel = new Ambar.Utils.GradientPanel();
            this.pbAmbar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsername)).BeginInit();
            this.gradientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAmbar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Montserrat", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblLogin.Location = new System.Drawing.Point(471, 27);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(126, 40);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "LOGIN";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtUsername.Location = new System.Drawing.Point(340, 159);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(430, 25);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.txtPassword.Location = new System.Drawing.Point(340, 234);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(430, 25);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(280, 362);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(490, 48);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "ACCEDER";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.panel1.Location = new System.Drawing.Point(340, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 1);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.panel2.Location = new System.Drawing.Point(340, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 1);
            this.panel2.TabIndex = 6;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.FlatAppearance.BorderSize = 0;
            this.chkRemember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRemember.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.chkRemember.Location = new System.Drawing.Point(339, 283);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(152, 27);
            this.chkRemember.TabIndex = 7;
            this.chkRemember.Text = "Recuérdame";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // pbWarningIcon
            // 
            this.pbWarningIcon.Image = global::Ambar.Properties.Resources.Warning_Icon1;
            this.pbWarningIcon.Location = new System.Drawing.Point(290, 321);
            this.pbWarningIcon.Name = "pbWarningIcon";
            this.pbWarningIcon.Size = new System.Drawing.Size(30, 30);
            this.pbWarningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWarningIcon.TabIndex = 12;
            this.pbWarningIcon.TabStop = false;
            this.pbWarningIcon.Visible = false;
            // 
            // btnMinimized
            // 
            this.btnMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimized.Image = global::Ambar.Properties.Resources.Minimized_Button_Logo;
            this.btnMinimized.Location = new System.Drawing.Point(732, 12);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(25, 25);
            this.btnMinimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimized.TabIndex = 11;
            this.btnMinimized.TabStop = false;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Ambar.Properties.Resources.Close_Button_Logo;
            this.btnClose.Location = new System.Drawing.Point(763, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 10;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbPassword
            // 
            this.pbPassword.Image = global::Ambar.Properties.Resources.Password_Logo;
            this.pbPassword.Location = new System.Drawing.Point(288, 219);
            this.pbPassword.Name = "pbPassword";
            this.pbPassword.Size = new System.Drawing.Size(40, 40);
            this.pbPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPassword.TabIndex = 9;
            this.pbPassword.TabStop = false;
            // 
            // pbUsername
            // 
            this.pbUsername.Image = global::Ambar.Properties.Resources.Username_Logo;
            this.pbUsername.Location = new System.Drawing.Point(288, 144);
            this.pbUsername.Name = "pbUsername";
            this.pbUsername.Size = new System.Drawing.Size(40, 40);
            this.pbUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUsername.TabIndex = 8;
            this.pbUsername.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblError.Location = new System.Drawing.Point(329, 327);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(107, 19);
            this.lblError.TabIndex = 13;
            this.lblError.Text = "ERROR TEXT";
            this.lblError.Visible = false;
            // 
            // cbPositions
            // 
            this.cbPositions.BackColor = System.Drawing.Color.White;
            this.cbPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPositions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPositions.Font = new System.Drawing.Font("Montserrat", 10F);
            this.cbPositions.ForeColor = System.Drawing.Color.Black;
            this.cbPositions.FormattingEnabled = true;
            this.cbPositions.Items.AddRange(new object[] {
            "Administrador",
            "Empleado",
            "Cliente"});
            this.cbPositions.Location = new System.Drawing.Point(351, 93);
            this.cbPositions.Name = "cbPositions";
            this.cbPositions.Size = new System.Drawing.Size(227, 28);
            this.cbPositions.TabIndex = 14;
            this.cbPositions.SelectedIndexChanged += new System.EventHandler(this.cbPositions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Location = new System.Drawing.Point(286, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tipo:";
            // 
            // fadeIn
            // 
            this.fadeIn.Enabled = true;
            this.fadeIn.Interval = 30;
            this.fadeIn.Tick += new System.EventHandler(this.fadeIn_Tick);
            // 
            // gradientPanel
            // 
            this.gradientPanel.angle = 90F;
            this.gradientPanel.Controls.Add(this.pbAmbar);
            this.gradientPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.gradientPanel.first = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.gradientPanel.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel.Name = "gradientPanel";
            this.gradientPanel.second = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.gradientPanel.Size = new System.Drawing.Size(250, 450);
            this.gradientPanel.TabIndex = 0;
            // 
            // pbAmbar
            // 
            this.pbAmbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pbAmbar.Image = global::Ambar.Properties.Resources.Ambar_Logo;
            this.pbAmbar.Location = new System.Drawing.Point(38, 111);
            this.pbAmbar.Name = "pbAmbar";
            this.pbAmbar.Size = new System.Drawing.Size(174, 162);
            this.pbAmbar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAmbar.TabIndex = 14;
            this.pbAmbar.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPositions);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pbWarningIcon);
            this.Controls.Add(this.btnMinimized);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbPassword);
            this.Controls.Add(this.pbUsername);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.gradientPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsername)).EndInit();
            this.gradientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAmbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.GradientPanel gradientPanel;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.PictureBox pbUsername;
        private System.Windows.Forms.PictureBox pbPassword;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnMinimized;
        private System.Windows.Forms.PictureBox pbWarningIcon;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox pbAmbar;
        private System.Windows.Forms.ComboBox cbPositions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer fadeIn;
    }
}