namespace Ambar.ViewController
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
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            this.gradientPanel1 = new Ambar.Utils.GradientPanel();
            this.panelReceipts = new System.Windows.Forms.Panel();
            this.btnReceipts = new System.Windows.Forms.Button();
            this.lblUsernameLogged = new System.Windows.Forms.Label();
            this.lblPositionLogged = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSubmenuReports = new System.Windows.Forms.Panel();
            this.panelHistoricConsumption = new System.Windows.Forms.Panel();
            this.btnHistoricConsumption = new System.Windows.Forms.Button();
            this.panelConsumptionsReport = new System.Windows.Forms.Panel();
            this.btnConsumptionsReport = new System.Windows.Forms.Button();
            this.panelRatesReport = new System.Windows.Forms.Panel();
            this.btnRatesReport = new System.Windows.Forms.Button();
            this.panelGeneralReport = new System.Windows.Forms.Panel();
            this.btnGeneralReport = new System.Windows.Forms.Button();
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
            this.btnMinimized = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.gradientPanel1.SuspendLayout();
            this.panelSubmenuReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStorage
            // 
            this.panelStorage.Location = new System.Drawing.Point(230, 35);
            this.panelStorage.Margin = new System.Windows.Forms.Padding(2);
            this.panelStorage.Name = "panelStorage";
            this.panelStorage.Size = new System.Drawing.Size(926, 687);
            this.panelStorage.TabIndex = 8;
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
            this.gradientPanel1.Controls.Add(this.panelReceipts);
            this.gradientPanel1.Controls.Add(this.btnReceipts);
            this.gradientPanel1.Controls.Add(this.lblUsernameLogged);
            this.gradientPanel1.Controls.Add(this.lblPositionLogged);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.panelSubmenuReports);
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
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.second = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.gradientPanel1.Size = new System.Drawing.Size(225, 727);
            this.gradientPanel1.TabIndex = 3;
            // 
            // panelReceipts
            // 
            this.panelReceipts.Location = new System.Drawing.Point(0, 333);
            this.panelReceipts.Margin = new System.Windows.Forms.Padding(2);
            this.panelReceipts.Name = "panelReceipts";
            this.panelReceipts.Size = new System.Drawing.Size(10, 41);
            this.panelReceipts.TabIndex = 19;
            // 
            // btnReceipts
            // 
            this.btnReceipts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnReceipts.FlatAppearance.BorderSize = 0;
            this.btnReceipts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnReceipts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipts.ForeColor = System.Drawing.Color.White;
            this.btnReceipts.Image = global::Ambar.Properties.Resources.Receipt_Logo;
            this.btnReceipts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceipts.Location = new System.Drawing.Point(9, 333);
            this.btnReceipts.Margin = new System.Windows.Forms.Padding(2);
            this.btnReceipts.Name = "btnReceipts";
            this.btnReceipts.Size = new System.Drawing.Size(216, 41);
            this.btnReceipts.TabIndex = 18;
            this.btnReceipts.Text = "Recibos";
            this.btnReceipts.UseVisualStyleBackColor = false;
            this.btnReceipts.Click += new System.EventHandler(this.btnReceipts_Click);
            // 
            // lblUsernameLogged
            // 
            this.lblUsernameLogged.AutoSize = true;
            this.lblUsernameLogged.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblUsernameLogged.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameLogged.Location = new System.Drawing.Point(6, 59);
            this.lblUsernameLogged.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsernameLogged.Name = "lblUsernameLogged";
            this.lblUsernameLogged.Size = new System.Drawing.Size(87, 17);
            this.lblUsernameLogged.TabIndex = 17;
            this.lblUsernameLogged.Text = "@Username";
            // 
            // lblPositionLogged
            // 
            this.lblPositionLogged.AutoSize = true;
            this.lblPositionLogged.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblPositionLogged.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositionLogged.Location = new System.Drawing.Point(6, 22);
            this.lblPositionLogged.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPositionLogged.Name = "lblPositionLogged";
            this.lblPositionLogged.Size = new System.Drawing.Size(76, 17);
            this.lblPositionLogged.TabIndex = 16;
            this.lblPositionLogged.Text = "@Position ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 15;
            // 
            // panelSubmenuReports
            // 
            this.panelSubmenuReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelSubmenuReports.Controls.Add(this.panelHistoricConsumption);
            this.panelSubmenuReports.Controls.Add(this.btnHistoricConsumption);
            this.panelSubmenuReports.Controls.Add(this.panelConsumptionsReport);
            this.panelSubmenuReports.Controls.Add(this.btnConsumptionsReport);
            this.panelSubmenuReports.Controls.Add(this.panelRatesReport);
            this.panelSubmenuReports.Controls.Add(this.btnRatesReport);
            this.panelSubmenuReports.Controls.Add(this.panelGeneralReport);
            this.panelSubmenuReports.Controls.Add(this.btnGeneralReport);
            this.panelSubmenuReports.Location = new System.Drawing.Point(9, 427);
            this.panelSubmenuReports.Margin = new System.Windows.Forms.Padding(2);
            this.panelSubmenuReports.Name = "panelSubmenuReports";
            this.panelSubmenuReports.Size = new System.Drawing.Size(216, 166);
            this.panelSubmenuReports.TabIndex = 0;
            this.panelSubmenuReports.Visible = false;
            // 
            // panelHistoricConsumption
            // 
            this.panelHistoricConsumption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelHistoricConsumption.Location = new System.Drawing.Point(9, 120);
            this.panelHistoricConsumption.Margin = new System.Windows.Forms.Padding(2);
            this.panelHistoricConsumption.Name = "panelHistoricConsumption";
            this.panelHistoricConsumption.Size = new System.Drawing.Size(10, 32);
            this.panelHistoricConsumption.TabIndex = 18;
            // 
            // btnHistoricConsumption
            // 
            this.btnHistoricConsumption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnHistoricConsumption.FlatAppearance.BorderSize = 0;
            this.btnHistoricConsumption.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnHistoricConsumption.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnHistoricConsumption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoricConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoricConsumption.ForeColor = System.Drawing.Color.White;
            this.btnHistoricConsumption.Location = new System.Drawing.Point(19, 120);
            this.btnHistoricConsumption.Margin = new System.Windows.Forms.Padding(2);
            this.btnHistoricConsumption.Name = "btnHistoricConsumption";
            this.btnHistoricConsumption.Size = new System.Drawing.Size(197, 32);
            this.btnHistoricConsumption.TabIndex = 19;
            this.btnHistoricConsumption.Text = "Consumo Historico";
            this.btnHistoricConsumption.UseVisualStyleBackColor = false;
            this.btnHistoricConsumption.Click += new System.EventHandler(this.btnHistoricConsumption_Click);
            // 
            // panelConsumptionsReport
            // 
            this.panelConsumptionsReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelConsumptionsReport.Location = new System.Drawing.Point(9, 81);
            this.panelConsumptionsReport.Margin = new System.Windows.Forms.Padding(2);
            this.panelConsumptionsReport.Name = "panelConsumptionsReport";
            this.panelConsumptionsReport.Size = new System.Drawing.Size(10, 32);
            this.panelConsumptionsReport.TabIndex = 12;
            // 
            // btnConsumptionsReport
            // 
            this.btnConsumptionsReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConsumptionsReport.FlatAppearance.BorderSize = 0;
            this.btnConsumptionsReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnConsumptionsReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConsumptionsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumptionsReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumptionsReport.ForeColor = System.Drawing.Color.White;
            this.btnConsumptionsReport.Location = new System.Drawing.Point(19, 81);
            this.btnConsumptionsReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsumptionsReport.Name = "btnConsumptionsReport";
            this.btnConsumptionsReport.Size = new System.Drawing.Size(197, 32);
            this.btnConsumptionsReport.TabIndex = 17;
            this.btnConsumptionsReport.Text = "Reporte de Consumos";
            this.btnConsumptionsReport.UseVisualStyleBackColor = false;
            this.btnConsumptionsReport.Click += new System.EventHandler(this.btnConsumptionsReport_Click);
            // 
            // panelRatesReport
            // 
            this.panelRatesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelRatesReport.Location = new System.Drawing.Point(9, 41);
            this.panelRatesReport.Margin = new System.Windows.Forms.Padding(2);
            this.panelRatesReport.Name = "panelRatesReport";
            this.panelRatesReport.Size = new System.Drawing.Size(10, 32);
            this.panelRatesReport.TabIndex = 11;
            // 
            // btnRatesReport
            // 
            this.btnRatesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRatesReport.FlatAppearance.BorderSize = 0;
            this.btnRatesReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRatesReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRatesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRatesReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRatesReport.ForeColor = System.Drawing.Color.White;
            this.btnRatesReport.Location = new System.Drawing.Point(19, 41);
            this.btnRatesReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnRatesReport.Name = "btnRatesReport";
            this.btnRatesReport.Size = new System.Drawing.Size(197, 32);
            this.btnRatesReport.TabIndex = 16;
            this.btnRatesReport.Text = "Reporte de Tarifas";
            this.btnRatesReport.UseVisualStyleBackColor = false;
            this.btnRatesReport.Click += new System.EventHandler(this.btnRatesReport_Click);
            // 
            // panelGeneralReport
            // 
            this.panelGeneralReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelGeneralReport.Location = new System.Drawing.Point(9, 0);
            this.panelGeneralReport.Margin = new System.Windows.Forms.Padding(2);
            this.panelGeneralReport.Name = "panelGeneralReport";
            this.panelGeneralReport.Size = new System.Drawing.Size(10, 32);
            this.panelGeneralReport.TabIndex = 10;
            // 
            // btnGeneralReport
            // 
            this.btnGeneralReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGeneralReport.FlatAppearance.BorderSize = 0;
            this.btnGeneralReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnGeneralReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGeneralReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneralReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneralReport.ForeColor = System.Drawing.Color.White;
            this.btnGeneralReport.Location = new System.Drawing.Point(19, 0);
            this.btnGeneralReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeneralReport.Name = "btnGeneralReport";
            this.btnGeneralReport.Size = new System.Drawing.Size(197, 32);
            this.btnGeneralReport.TabIndex = 15;
            this.btnGeneralReport.Text = "Reporte General";
            this.btnGeneralReport.UseVisualStyleBackColor = false;
            this.btnGeneralReport.Click += new System.EventHandler(this.btnGeneralReport_Click);
            // 
            // panelEmployees
            // 
            this.panelEmployees.Location = new System.Drawing.Point(0, 89);
            this.panelEmployees.Margin = new System.Windows.Forms.Padding(2);
            this.panelEmployees.Name = "panelEmployees";
            this.panelEmployees.Size = new System.Drawing.Size(10, 41);
            this.panelEmployees.TabIndex = 14;
            // 
            // panelClients
            // 
            this.panelClients.Location = new System.Drawing.Point(0, 138);
            this.panelClients.Margin = new System.Windows.Forms.Padding(2);
            this.panelClients.Name = "panelClients";
            this.panelClients.Size = new System.Drawing.Size(10, 41);
            this.panelClients.TabIndex = 13;
            // 
            // panelContracts
            // 
            this.panelContracts.Location = new System.Drawing.Point(0, 187);
            this.panelContracts.Margin = new System.Windows.Forms.Padding(2);
            this.panelContracts.Name = "panelContracts";
            this.panelContracts.Size = new System.Drawing.Size(10, 41);
            this.panelContracts.TabIndex = 12;
            // 
            // panelConsumptions
            // 
            this.panelConsumptions.Location = new System.Drawing.Point(0, 236);
            this.panelConsumptions.Margin = new System.Windows.Forms.Padding(2);
            this.panelConsumptions.Name = "panelConsumptions";
            this.panelConsumptions.Size = new System.Drawing.Size(10, 41);
            this.panelConsumptions.TabIndex = 11;
            // 
            // panelRates
            // 
            this.panelRates.Location = new System.Drawing.Point(0, 284);
            this.panelRates.Margin = new System.Windows.Forms.Padding(2);
            this.panelRates.Name = "panelRates";
            this.panelRates.Size = new System.Drawing.Size(10, 41);
            this.panelRates.TabIndex = 10;
            // 
            // panelReports
            // 
            this.panelReports.Location = new System.Drawing.Point(0, 382);
            this.panelReports.Margin = new System.Windows.Forms.Padding(2);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(10, 41);
            this.panelReports.TabIndex = 9;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(0, 630);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(225, 49);
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
            this.btnConsumptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumptions.ForeColor = System.Drawing.Color.White;
            this.btnConsumptions.Image = global::Ambar.Properties.Resources.Consumption_Logo;
            this.btnConsumptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsumptions.Location = new System.Drawing.Point(9, 236);
            this.btnConsumptions.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsumptions.Name = "btnConsumptions";
            this.btnConsumptions.Size = new System.Drawing.Size(216, 41);
            this.btnConsumptions.TabIndex = 4;
            this.btnConsumptions.Text = "Consumos";
            this.btnConsumptions.UseVisualStyleBackColor = false;
            this.btnConsumptions.Click += new System.EventHandler(this.btnConsumptions_Click);
            // 
            // btnRates
            // 
            this.btnRates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRates.FlatAppearance.BorderSize = 0;
            this.btnRates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRates.ForeColor = System.Drawing.Color.White;
            this.btnRates.Image = global::Ambar.Properties.Resources.Rates_Logo;
            this.btnRates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRates.Location = new System.Drawing.Point(9, 284);
            this.btnRates.Margin = new System.Windows.Forms.Padding(2);
            this.btnRates.Name = "btnRates";
            this.btnRates.Size = new System.Drawing.Size(216, 41);
            this.btnRates.TabIndex = 3;
            this.btnRates.Text = "Tarifas";
            this.btnRates.UseVisualStyleBackColor = false;
            this.btnRates.Click += new System.EventHandler(this.btnRates_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(4, 6);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(76, 17);
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
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::Ambar.Properties.Resources.Reports_Logo1;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(9, 382);
            this.btnReports.Margin = new System.Windows.Forms.Padding(2);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(216, 41);
            this.btnReports.TabIndex = 1;
            this.btnReports.Text = "Reportes";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(4, 42);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(91, 17);
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
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Image = global::Ambar.Properties.Resources.Employee_Logo;
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(9, 89);
            this.btnEmployees.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(216, 41);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Text = "Empleados";
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnContracts
            // 
            this.btnContracts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnContracts.FlatAppearance.BorderSize = 0;
            this.btnContracts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnContracts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnContracts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContracts.ForeColor = System.Drawing.Color.White;
            this.btnContracts.Image = global::Ambar.Properties.Resources.Contract_Logo;
            this.btnContracts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContracts.Location = new System.Drawing.Point(9, 187);
            this.btnContracts.Margin = new System.Windows.Forms.Padding(2);
            this.btnContracts.Name = "btnContracts";
            this.btnContracts.Size = new System.Drawing.Size(216, 41);
            this.btnContracts.TabIndex = 1;
            this.btnContracts.Text = "Contratos";
            this.btnContracts.UseVisualStyleBackColor = false;
            this.btnContracts.Click += new System.EventHandler(this.btnContracts_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnClients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Image = global::Ambar.Properties.Resources.Client_Logo;
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(9, 138);
            this.btnClients.Margin = new System.Windows.Forms.Padding(2);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(216, 41);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Clientes";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnMinimized
            // 
            this.btnMinimized.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimized.Image = global::Ambar.Properties.Resources.Minimized_Button_Logo;
            this.btnMinimized.Location = new System.Drawing.Point(1115, 8);
            this.btnMinimized.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(19, 20);
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
            this.btnClose.Location = new System.Drawing.Point(1138, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(19, 20);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AmbarMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1174, 727);
            this.Controls.Add(this.panelStorage);
            this.Controls.Add(this.btnMinimized);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AmbarMenu";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.AmbarMenu_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.panelSubmenuReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
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
        private System.Windows.Forms.Panel panelGeneralReport;
        private System.Windows.Forms.Panel panelSubmenuReports;
        private System.Windows.Forms.Button btnGeneralReport;
        private System.Windows.Forms.Button btnRatesReport;
        private System.Windows.Forms.Panel panelConsumptionsReport;
        private System.Windows.Forms.Panel panelRatesReport;
        private System.Windows.Forms.Button btnConsumptionsReport;
        private System.Windows.Forms.Label lblUsernameLogged;
        private System.Windows.Forms.Label lblPositionLogged;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer fadeIn;
        private System.Windows.Forms.Panel panelReceipts;
        private System.Windows.Forms.Button btnReceipts;
        private System.Windows.Forms.Panel panelHistoricConsumption;
        private System.Windows.Forms.Button btnHistoricConsumption;
    }
}