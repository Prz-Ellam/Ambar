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
            this.btnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
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
            this.ofnMassive = new System.Windows.Forms.OpenFileDialog();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.nudBasic = new System.Windows.Forms.NumericUpDown();
            this.nudSurplus = new System.Windows.Forms.NumericUpDown();
            this.nudIntermediate = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSurplus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntermediate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMasiveCharge
            // 
            this.btnMasiveCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnMasiveCharge.FlatAppearance.BorderSize = 0;
            this.btnMasiveCharge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnMasiveCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasiveCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasiveCharge.ForeColor = System.Drawing.Color.White;
            this.btnMasiveCharge.Location = new System.Drawing.Point(315, 256);
            this.btnMasiveCharge.Margin = new System.Windows.Forms.Padding(2);
            this.btnMasiveCharge.Name = "btnMasiveCharge";
            this.btnMasiveCharge.Size = new System.Drawing.Size(129, 41);
            this.btnMasiveCharge.TabIndex = 8;
            this.btnMasiveCharge.Text = "CARGA MASIVA";
            this.btnMasiveCharge.UseVisualStyleBackColor = false;
            this.btnMasiveCharge.Click += new System.EventHandler(this.btnMasiveCharge_Click);
            // 
            // cbService
            // 
            this.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbService.FormattingEnabled = true;
            this.cbService.Items.AddRange(new object[] {
            "Seleccionar",
            "Domestico",
            "Industrial"});
            this.cbService.Location = new System.Drawing.Point(178, 81);
            this.cbService.Margin = new System.Windows.Forms.Padding(2);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(430, 25);
            this.cbService.TabIndex = 1;
            this.cbService.SelectedIndexChanged += new System.EventHandler(this.cbService_SelectedIndexChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(178, 256);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 41);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "ACEPTAR";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Location = new System.Drawing.Point(44, 146);
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
            this.label2.Location = new System.Drawing.Point(20, 177);
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
            this.label3.Location = new System.Drawing.Point(20, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Consumo Excedente:";
            // 
            // dtpYear
            // 
            this.dtpYear.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(373, 113);
            this.dtpYear.Margin = new System.Windows.Forms.Padding(2);
            this.dtpYear.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpYear.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(71, 23);
            this.dtpYear.TabIndex = 3;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpPeriod_ValueChanged);
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblEmpleados.Location = new System.Drawing.Point(15, 15);
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
            this.label4.Location = new System.Drawing.Point(44, 84);
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
            this.label5.Location = new System.Drawing.Point(3, 115);
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
            this.dtgRates.Location = new System.Drawing.Point(15, 327);
            this.dtgRates.Margin = new System.Windows.Forms.Padding(2);
            this.dtgRates.Name = "dtgRates";
            this.dtgRates.ReadOnly = true;
            this.dtgRates.RowHeadersWidth = 51;
            this.dtgRates.RowTemplate.Height = 24;
            this.dtgRates.Size = new System.Drawing.Size(929, 235);
            this.dtgRates.TabIndex = 9;
            // 
            // RateID
            // 
            this.RateID.DataPropertyName = "RATE_ID";
            this.RateID.HeaderText = "ID";
            this.RateID.MinimumWidth = 6;
            this.RateID.Name = "RateID";
            this.RateID.ReadOnly = true;
            this.RateID.Width = 125;
            // 
            // Service
            // 
            this.Service.DataPropertyName = "SERVICE";
            this.Service.HeaderText = "Servicio";
            this.Service.MinimumWidth = 6;
            this.Service.Name = "Service";
            this.Service.ReadOnly = true;
            this.Service.Width = 125;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "YEAR";
            this.Year.HeaderText = "Año";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 125;
            // 
            // Month
            // 
            this.Month.DataPropertyName = "MONTH";
            this.Month.HeaderText = "Mes";
            this.Month.MinimumWidth = 6;
            this.Month.Name = "Month";
            this.Month.ReadOnly = true;
            this.Month.Width = 125;
            // 
            // BasicLevel
            // 
            this.BasicLevel.DataPropertyName = "BASIC_LEVEL";
            this.BasicLevel.HeaderText = "Nivel Básico";
            this.BasicLevel.MinimumWidth = 6;
            this.BasicLevel.Name = "BasicLevel";
            this.BasicLevel.ReadOnly = true;
            this.BasicLevel.Width = 125;
            // 
            // IntermediateLevel
            // 
            this.IntermediateLevel.DataPropertyName = "INTERMEDIATE_LEVEL";
            this.IntermediateLevel.HeaderText = "Nivel Intermedio";
            this.IntermediateLevel.MinimumWidth = 6;
            this.IntermediateLevel.Name = "IntermediateLevel";
            this.IntermediateLevel.ReadOnly = true;
            this.IntermediateLevel.Width = 125;
            // 
            // SurplusLevel
            // 
            this.SurplusLevel.DataPropertyName = "SURPLUS_LEVEL";
            this.SurplusLevel.HeaderText = "Nivel Excedente";
            this.SurplusLevel.MinimumWidth = 6;
            this.SurplusLevel.Name = "SurplusLevel";
            this.SurplusLevel.ReadOnly = true;
            this.SurplusLevel.Width = 125;
            // 
            // ofnMassive
            // 
            this.ofnMassive.Filter = "CSV (*.csv)|*.csv|XLSX (*.xlsx)|*.xlsx";
            // 
            // cbPeriod
            // 
            this.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Location = new System.Drawing.Point(178, 112);
            this.cbPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(188, 25);
            this.cbPeriod.TabIndex = 2;
            // 
            // nudBasic
            // 
            this.nudBasic.DecimalPlaces = 3;
            this.nudBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.nudBasic.Location = new System.Drawing.Point(178, 145);
            this.nudBasic.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBasic.Name = "nudBasic";
            this.nudBasic.Size = new System.Drawing.Size(188, 23);
            this.nudBasic.TabIndex = 4;
            // 
            // nudSurplus
            // 
            this.nudSurplus.DecimalPlaces = 3;
            this.nudSurplus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.nudSurplus.Location = new System.Drawing.Point(178, 207);
            this.nudSurplus.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSurplus.Name = "nudSurplus";
            this.nudSurplus.Size = new System.Drawing.Size(188, 23);
            this.nudSurplus.TabIndex = 6;
            // 
            // nudIntermediate
            // 
            this.nudIntermediate.DecimalPlaces = 3;
            this.nudIntermediate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.nudIntermediate.Location = new System.Drawing.Point(178, 176);
            this.nudIntermediate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudIntermediate.Name = "nudIntermediate";
            this.nudIntermediate.Size = new System.Drawing.Size(188, 23);
            this.nudIntermediate.TabIndex = 5;
            // 
            // Rates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(967, 615);
            this.Controls.Add(this.nudIntermediate);
            this.Controls.Add(this.nudSurplus);
            this.Controls.Add(this.nudBasic);
            this.Controls.Add(this.cbPeriod);
            this.Controls.Add(this.dtgRates);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEmpleados);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cbService);
            this.Controls.Add(this.btnMasiveCharge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Rates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifas";
            this.Load += new System.EventHandler(this.Rates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSurplus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntermediate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMasiveCharge;
        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgRates;
        private System.Windows.Forms.OpenFileDialog ofnMassive;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.NumericUpDown nudBasic;
        private System.Windows.Forms.NumericUpDown nudSurplus;
        private System.Windows.Forms.NumericUpDown nudIntermediate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntermediateLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurplusLevel;
    }
}