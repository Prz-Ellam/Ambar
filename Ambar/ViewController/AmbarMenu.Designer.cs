﻿namespace Ambar.ViewController
{
    partial class AmbarMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmbarMenu));
            this.panelStorage = new System.Windows.Forms.Panel();
            this.btnMinimized = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            this.gradientPanel1 = new Ambar.Utils.GradientPanel();
            this.lblUsernameLogged = new System.Windows.Forms.Label();
            this.lblPositionLogged = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SubmenuReportes = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnConsumptionsReport = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRatesReport = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelEmployees = new System.Windows.Forms.Panel();
            this.panelClients = new System.Windows.Forms.Panel();
            this.panelContracts = new System.Windows.Forms.Panel();
            this.panelConsumptions = new System.Windows.Forms.Panel();
            this.panelRates = new System.Windows.Forms.Panel();
            this.panelReports = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnConsumptions = new System.Windows.Forms.Button();
            this.btnRates = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnReports = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnContracts = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReceipts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.SubmenuReportes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStorage
            // 
            this.panelStorage.Location = new System.Drawing.Point(306, 43);
            this.panelStorage.Name = "panelStorage";
            this.panelStorage.Size = new System.Drawing.Size(1235, 845);
            this.panelStorage.TabIndex = 8;
            // 
            // btnMinimized
            // 
            this.btnMinimized.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimized.Image = global::Ambar.Properties.Resources.Minimized_Button_Logo;
            this.btnMinimized.Location = new System.Drawing.Point(1487, 10);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(25, 25);
            this.btnMinimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimized.TabIndex = 5;
            this.btnMinimized.TabStop = false;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Ambar.Properties.Resources.Close_Button_Logo;
            this.btnClose.Location = new System.Drawing.Point(1518, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fadeIn
            // 
            this.fadeIn.Enabled = true;
            this.fadeIn.Interval = 30;
            this.fadeIn.Tick += new System.EventHandler(this.fadeIn_Tick);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.angle = 90F;
            this.gradientPanel1.Controls.Add(this.panel1);
            this.gradientPanel1.Controls.Add(this.btnReceipts);
            this.gradientPanel1.Controls.Add(this.lblUsernameLogged);
            this.gradientPanel1.Controls.Add(this.lblPositionLogged);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.SubmenuReportes);
            this.gradientPanel1.Controls.Add(this.panelEmployees);
            this.gradientPanel1.Controls.Add(this.panelClients);
            this.gradientPanel1.Controls.Add(this.panelContracts);
            this.gradientPanel1.Controls.Add(this.panelConsumptions);
            this.gradientPanel1.Controls.Add(this.panelRates);
            this.gradientPanel1.Controls.Add(this.panelReports);
            this.gradientPanel1.Controls.Add(this.btnLogout);
            this.gradientPanel1.Controls.Add(this.btnConsumptions);
            this.gradientPanel1.Controls.Add(this.btnRates);
            this.gradientPanel1.Controls.Add(this.lblPosition);
            this.gradientPanel1.Controls.Add(this.btnReports);
            this.gradientPanel1.Controls.Add(this.lblUsername);
            this.gradientPanel1.Controls.Add(this.btnEmployees);
            this.gradientPanel1.Controls.Add(this.btnContracts);
            this.gradientPanel1.Controls.Add(this.btnClients);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gradientPanel1.first = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.second = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.gradientPanel1.Size = new System.Drawing.Size(300, 900);
            this.gradientPanel1.TabIndex = 3;
            // 
            // lblUsernameLogged
            // 
            this.lblUsernameLogged.AutoSize = true;
            this.lblUsernameLogged.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblUsernameLogged.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameLogged.Location = new System.Drawing.Point(8, 74);
            this.lblUsernameLogged.Name = "lblUsernameLogged";
            this.lblUsernameLogged.Size = new System.Drawing.Size(113, 20);
            this.lblUsernameLogged.TabIndex = 17;
            this.lblUsernameLogged.Text = "@Username";
            this.lblUsernameLogged.Click += new System.EventHandler(this.lblUsernameLogged_Click);
            // 
            // lblPositionLogged
            // 
            this.lblPositionLogged.AutoSize = true;
            this.lblPositionLogged.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblPositionLogged.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositionLogged.Location = new System.Drawing.Point(8, 30);
            this.lblPositionLogged.Name = "lblPositionLogged";
            this.lblPositionLogged.Size = new System.Drawing.Size(100, 20);
            this.lblPositionLogged.TabIndex = 16;
            this.lblPositionLogged.Text = "@Position ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 15;
            // 
            // SubmenuReportes
            // 
            this.SubmenuReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SubmenuReportes.Controls.Add(this.panel4);
            this.SubmenuReportes.Controls.Add(this.btnConsumptionsReport);
            this.SubmenuReportes.Controls.Add(this.panel3);
            this.SubmenuReportes.Controls.Add(this.btnRatesReport);
            this.SubmenuReportes.Controls.Add(this.panel2);
            this.SubmenuReportes.Controls.Add(this.button1);
            this.SubmenuReportes.Location = new System.Drawing.Point(12, 526);
            this.SubmenuReportes.Name = "SubmenuReportes";
            this.SubmenuReportes.Size = new System.Drawing.Size(288, 164);
            this.SubmenuReportes.TabIndex = 0;
            this.SubmenuReportes.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.Location = new System.Drawing.Point(12, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(14, 40);
            this.panel4.TabIndex = 12;
            // 
            // btnConsumptionsReport
            // 
            this.btnConsumptionsReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConsumptionsReport.FlatAppearance.BorderSize = 0;
            this.btnConsumptionsReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnConsumptionsReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConsumptionsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumptionsReport.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumptionsReport.ForeColor = System.Drawing.Color.White;
            this.btnConsumptionsReport.Location = new System.Drawing.Point(25, 100);
            this.btnConsumptionsReport.Name = "btnConsumptionsReport";
            this.btnConsumptionsReport.Size = new System.Drawing.Size(263, 40);
            this.btnConsumptionsReport.TabIndex = 17;
            this.btnConsumptionsReport.Text = "Reporte de Consumos";
            this.btnConsumptionsReport.UseVisualStyleBackColor = false;
            this.btnConsumptionsReport.Click += new System.EventHandler(this.btnConsumptionsReport_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.Location = new System.Drawing.Point(12, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(14, 40);
            this.panel3.TabIndex = 11;
            // 
            // btnRatesReport
            // 
            this.btnRatesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRatesReport.FlatAppearance.BorderSize = 0;
            this.btnRatesReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRatesReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRatesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRatesReport.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRatesReport.ForeColor = System.Drawing.Color.White;
            this.btnRatesReport.Location = new System.Drawing.Point(25, 50);
            this.btnRatesReport.Name = "btnRatesReport";
            this.btnRatesReport.Size = new System.Drawing.Size(263, 40);
            this.btnRatesReport.TabIndex = 16;
            this.btnRatesReport.Text = "Reporte de Tarifas";
            this.btnRatesReport.UseVisualStyleBackColor = false;
            this.btnRatesReport.Click += new System.EventHandler(this.btnRatesReport_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.Location = new System.Drawing.Point(12, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 40);
            this.panel2.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(25, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 40);
            this.button1.TabIndex = 15;
            this.button1.Text = "Reporte General";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelEmployees
            // 
            this.panelEmployees.Location = new System.Drawing.Point(0, 110);
            this.panelEmployees.Name = "panelEmployees";
            this.panelEmployees.Size = new System.Drawing.Size(14, 50);
            this.panelEmployees.TabIndex = 14;
            // 
            // panelClients
            // 
            this.panelClients.Location = new System.Drawing.Point(0, 170);
            this.panelClients.Name = "panelClients";
            this.panelClients.Size = new System.Drawing.Size(14, 50);
            this.panelClients.TabIndex = 13;
            // 
            // panelContracts
            // 
            this.panelContracts.Location = new System.Drawing.Point(0, 230);
            this.panelContracts.Name = "panelContracts";
            this.panelContracts.Size = new System.Drawing.Size(14, 50);
            this.panelContracts.TabIndex = 12;
            // 
            // panelConsumptions
            // 
            this.panelConsumptions.Location = new System.Drawing.Point(0, 290);
            this.panelConsumptions.Name = "panelConsumptions";
            this.panelConsumptions.Size = new System.Drawing.Size(14, 50);
            this.panelConsumptions.TabIndex = 11;
            // 
            // panelRates
            // 
            this.panelRates.Location = new System.Drawing.Point(0, 350);
            this.panelRates.Name = "panelRates";
            this.panelRates.Size = new System.Drawing.Size(14, 50);
            this.panelRates.TabIndex = 10;
            // 
            // panelReports
            // 
            this.panelReports.Location = new System.Drawing.Point(0, 470);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(14, 50);
            this.panelReports.TabIndex = 9;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(0, 775);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(300, 60);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "CERRAR SESIÓN";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnConsumptions
            // 
            this.btnConsumptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConsumptions.FlatAppearance.BorderSize = 0;
            this.btnConsumptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnConsumptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConsumptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumptions.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumptions.ForeColor = System.Drawing.Color.White;
            this.btnConsumptions.Location = new System.Drawing.Point(12, 290);
            this.btnConsumptions.Name = "btnConsumptions";
            this.btnConsumptions.Size = new System.Drawing.Size(288, 50);
            this.btnConsumptions.TabIndex = 4;
            this.btnConsumptions.Text = "Consumos";
            this.btnConsumptions.UseVisualStyleBackColor = false;
            this.btnConsumptions.Click += new System.EventHandler(this.btnConsumos_Click);
            // 
            // btnRates
            // 
            this.btnRates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRates.FlatAppearance.BorderSize = 0;
            this.btnRates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRates.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRates.ForeColor = System.Drawing.Color.White;
            this.btnRates.Location = new System.Drawing.Point(12, 350);
            this.btnRates.Name = "btnRates";
            this.btnRates.Size = new System.Drawing.Size(288, 50);
            this.btnRates.TabIndex = 3;
            this.btnRates.Text = "Tarifas";
            this.btnRates.UseVisualStyleBackColor = false;
            this.btnRates.Click += new System.EventHandler(this.btnTarifas_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblPosition.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(6, 10);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(100, 20);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Position: ";
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::Ambar.Properties.Resources.Reports_Logo1;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(12, 470);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(288, 50);
            this.btnReports.TabIndex = 1;
            this.btnReports.Text = "Reportes";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblUsername.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(6, 53);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(118, 20);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username: ";
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEmployees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Image = global::Ambar.Properties.Resources.Employee_Logo;
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(12, 110);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(288, 50);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Text = "Empleados";
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnContracts
            // 
            this.btnContracts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnContracts.FlatAppearance.BorderSize = 0;
            this.btnContracts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnContracts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnContracts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContracts.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContracts.ForeColor = System.Drawing.Color.White;
            this.btnContracts.Image = global::Ambar.Properties.Resources.Contract_Logo;
            this.btnContracts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContracts.Location = new System.Drawing.Point(12, 230);
            this.btnContracts.Name = "btnContracts";
            this.btnContracts.Size = new System.Drawing.Size(288, 50);
            this.btnContracts.TabIndex = 1;
            this.btnContracts.Text = "Contratos";
            this.btnContracts.UseVisualStyleBackColor = false;
            this.btnContracts.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnClients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Image = global::Ambar.Properties.Resources.Client_Logo;
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(12, 170);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(288, 50);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Clientes";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 50);
            this.panel1.TabIndex = 19;
            // 
            // btnReceipts
            // 
            this.btnReceipts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnReceipts.FlatAppearance.BorderSize = 0;
            this.btnReceipts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnReceipts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceipts.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipts.ForeColor = System.Drawing.Color.White;
            this.btnReceipts.Image = global::Ambar.Properties.Resources.Reports_Logo1;
            this.btnReceipts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceipts.Location = new System.Drawing.Point(12, 410);
            this.btnReceipts.Name = "btnReceipts";
            this.btnReceipts.Size = new System.Drawing.Size(288, 50);
            this.btnReceipts.TabIndex = 18;
            this.btnReceipts.Text = "Recibos";
            this.btnReceipts.UseVisualStyleBackColor = false;
            this.btnReceipts.Click += new System.EventHandler(this.btnReceipts_Click);
            // 
            // AmbarMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1553, 900);
            this.Controls.Add(this.panelStorage);
            this.Controls.Add(this.btnMinimized);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AmbarMenu";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.AmbarMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.SubmenuReportes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnContracts;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPosition;
        private Utils.GradientPanel gradientPanel1;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnMinimized;
        private System.Windows.Forms.Panel panelStorage;
        private System.Windows.Forms.Button btnConsumptions;
        private System.Windows.Forms.Button btnRates;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelReports;
        private System.Windows.Forms.Panel panelEmployees;
        private System.Windows.Forms.Panel panelClients;
        private System.Windows.Forms.Panel panelContracts;
        private System.Windows.Forms.Panel panelConsumptions;
        private System.Windows.Forms.Panel panelRates;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel SubmenuReportes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRatesReport;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnConsumptionsReport;
        private System.Windows.Forms.Label lblUsernameLogged;
        private System.Windows.Forms.Label lblPositionLogged;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer fadeIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReceipts;
    }
}