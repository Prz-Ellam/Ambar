namespace Ambar.ViewController
{
    partial class Rates
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
            this.btnMasiveCharge = new System.Windows.Forms.Button();
            this.cbService = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtBasic = new System.Windows.Forms.TextBox();
            this.txtIntermediate = new System.Windows.Forms.TextBox();
            this.txtSurplus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpPeriod = new System.Windows.Forms.DateTimePicker();
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgRates = new System.Windows.Forms.DataGridView();
            this.RateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntermediateLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurplusLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblError = new System.Windows.Forms.Label();
            this.pbWarningIcon = new System.Windows.Forms.PictureBox();
            this.ofnMassive = new System.Windows.Forms.OpenFileDialog();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMasiveCharge
            // 
            this.btnMasiveCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnMasiveCharge.FlatAppearance.BorderSize = 0;
            this.btnMasiveCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasiveCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasiveCharge.ForeColor = System.Drawing.Color.White;
            this.btnMasiveCharge.Location = new System.Drawing.Point(196, 301);
            this.btnMasiveCharge.Margin = new System.Windows.Forms.Padding(2);
            this.btnMasiveCharge.Name = "btnMasiveCharge";
            this.btnMasiveCharge.Size = new System.Drawing.Size(112, 51);
            this.btnMasiveCharge.TabIndex = 0;
            this.btnMasiveCharge.Text = "CARGA MASIVA";
            this.btnMasiveCharge.UseVisualStyleBackColor = false;
            this.btnMasiveCharge.Click += new System.EventHandler(this.btnMasiveCharge_Click);
            // 
            // cbService
            // 
            this.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbService.FormattingEnabled = true;
            this.cbService.Items.AddRange(new object[] {
            "Seleccionar",
            "Domestico",
            "Industrial"});
            this.cbService.Location = new System.Drawing.Point(178, 119);
            this.cbService.Margin = new System.Windows.Forms.Padding(2);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(252, 25);
            this.cbService.TabIndex = 1;
            this.cbService.SelectedIndexChanged += new System.EventHandler(this.cbService_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Monto",
            "Porcentual"});
            this.comboBox2.Location = new System.Drawing.Point(366, 67);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(64, 308);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 41);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "ACEPTAR";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtBasic
            // 
            this.txtBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasic.Location = new System.Drawing.Point(178, 188);
            this.txtBasic.Margin = new System.Windows.Forms.Padding(2);
            this.txtBasic.Name = "txtBasic";
            this.txtBasic.Size = new System.Drawing.Size(252, 23);
            this.txtBasic.TabIndex = 4;
            this.txtBasic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIntermediate
            // 
            this.txtIntermediate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntermediate.Location = new System.Drawing.Point(178, 217);
            this.txtIntermediate.Margin = new System.Windows.Forms.Padding(2);
            this.txtIntermediate.Name = "txtIntermediate";
            this.txtIntermediate.Size = new System.Drawing.Size(252, 23);
            this.txtIntermediate.TabIndex = 5;
            this.txtIntermediate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSurplus
            // 
            this.txtSurplus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurplus.Location = new System.Drawing.Point(178, 246);
            this.txtSurplus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSurplus.Name = "txtSurplus";
            this.txtSurplus.Size = new System.Drawing.Size(252, 23);
            this.txtSurplus.TabIndex = 6;
            this.txtSurplus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Location = new System.Drawing.Point(44, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Consumo Básico:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label2.Location = new System.Drawing.Point(20, 220);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Consumo Intermedio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label3.Location = new System.Drawing.Point(20, 249);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Consumo Excedente:";
            // 
            // dtpPeriod
            // 
            this.dtpPeriod.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriod.CustomFormat = "yyyy";
            this.dtpPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriod.Location = new System.Drawing.Point(370, 156);
            this.dtpPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.dtpPeriod.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dtpPeriod.Name = "dtpPeriod";
            this.dtpPeriod.ShowUpDown = true;
            this.dtpPeriod.Size = new System.Drawing.Size(60, 23);
            this.dtpPeriod.TabIndex = 13;
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblEmpleados.Location = new System.Drawing.Point(15, 16);
            this.lblEmpleados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(130, 31);
            this.lblEmpleados.TabIndex = 20;
            this.lblEmpleados.Text = "TARIFAS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label4.Location = new System.Drawing.Point(44, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tipo de Servicio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label5.Location = new System.Drawing.Point(6, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Periodo de facturación:";
            // 
            // dtgRates
            // 
            this.dtgRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RateID,
            this.Service,
            this.Year,
            this.Month,
            this.BasicLevel,
            this.IntermediateLevel,
            this.SurplusLevel});
            this.dtgRates.Location = new System.Drawing.Point(12, 369);
            this.dtgRates.Margin = new System.Windows.Forms.Padding(2);
            this.dtgRates.Name = "dtgRates";
            this.dtgRates.RowHeadersWidth = 51;
            this.dtgRates.RowTemplate.Height = 24;
            this.dtgRates.Size = new System.Drawing.Size(929, 235);
            this.dtgRates.TabIndex = 23;
            // 
            // RateID
            // 
            this.RateID.DataPropertyName = "RATE_ID";
            this.RateID.HeaderText = "ID";
            this.RateID.MinimumWidth = 6;
            this.RateID.Name = "RateID";
            this.RateID.Width = 125;
            // 
            // Service
            // 
            this.Service.DataPropertyName = "SERVICE";
            this.Service.HeaderText = "Servicio";
            this.Service.MinimumWidth = 6;
            this.Service.Name = "Service";
            this.Service.Width = 125;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "YEAR";
            this.Year.HeaderText = "Año";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.Width = 125;
            // 
            // Month
            // 
            this.Month.DataPropertyName = "MONTH";
            this.Month.HeaderText = "Mes";
            this.Month.MinimumWidth = 6;
            this.Month.Name = "Month";
            this.Month.Width = 125;
            // 
            // BasicLevel
            // 
            this.BasicLevel.DataPropertyName = "BASIC_LEVEL";
            this.BasicLevel.HeaderText = "Consumo Básico";
            this.BasicLevel.MinimumWidth = 6;
            this.BasicLevel.Name = "BasicLevel";
            this.BasicLevel.Width = 125;
            // 
            // IntermediateLevel
            // 
            this.IntermediateLevel.DataPropertyName = "INTERMEDIATE_LEVEL";
            this.IntermediateLevel.HeaderText = "Consumo Intermedio";
            this.IntermediateLevel.MinimumWidth = 6;
            this.IntermediateLevel.Name = "IntermediateLevel";
            this.IntermediateLevel.Width = 125;
            // 
            // SurplusLevel
            // 
            this.SurplusLevel.DataPropertyName = "SURPLUS_LEVEL";
            this.SurplusLevel.HeaderText = "Consumo Excedente";
            this.SurplusLevel.MinimumWidth = 6;
            this.SurplusLevel.Name = "SurplusLevel";
            this.SurplusLevel.Width = 125;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblError.Location = new System.Drawing.Point(513, 123);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(84, 15);
            this.lblError.TabIndex = 25;
            this.lblError.Text = "ERROR TEXT";
            this.lblError.Visible = false;
            // 
            // pbWarningIcon
            // 
            this.pbWarningIcon.Image = global::Ambar.Properties.Resources.Warning_Icon1;
            this.pbWarningIcon.Location = new System.Drawing.Point(484, 118);
            this.pbWarningIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pbWarningIcon.Name = "pbWarningIcon";
            this.pbWarningIcon.Size = new System.Drawing.Size(22, 24);
            this.pbWarningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWarningIcon.TabIndex = 24;
            this.pbWarningIcon.TabStop = false;
            this.pbWarningIcon.Visible = false;
            // 
            // ofnMassive
            // 
            this.ofnMassive.Filter = "CSV (*.csv)|*.csv|XLSX (*.xlsx)|*.xlsx";
            // 
            // cbPeriod
            // 
            this.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Location = new System.Drawing.Point(178, 156);
            this.cbPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(188, 25);
            this.cbPeriod.TabIndex = 27;
            // 
            // Rates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(967, 615);
            this.Controls.Add(this.cbPeriod);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pbWarningIcon);
            this.Controls.Add(this.dtgRates);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEmpleados);
            this.Controls.Add(this.dtpPeriod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSurplus);
            this.Controls.Add(this.txtIntermediate);
            this.Controls.Add(this.txtBasic);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cbService);
            this.Controls.Add(this.btnMasiveCharge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Rates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifas";
            this.Load += new System.EventHandler(this.Rates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMasiveCharge;
        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtBasic;
        private System.Windows.Forms.TextBox txtIntermediate;
        private System.Windows.Forms.TextBox txtSurplus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpPeriod;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgRates;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox pbWarningIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntermediateLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurplusLevel;
        private System.Windows.Forms.OpenFileDialog ofnMassive;
        private System.Windows.Forms.ComboBox cbPeriod;
    }
}