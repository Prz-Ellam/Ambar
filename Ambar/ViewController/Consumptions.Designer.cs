namespace Ambar.ViewController
{
    partial class Consumptions
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnMassiveCharge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeterSerialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.dtgConsumptions = new System.Windows.Forms.DataGridView();
            this.ConsumptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceNumberr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicKW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntermediateKW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurplusKW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalKW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPeriod = new System.Windows.Forms.DateTimePicker();
            this.dtgContracts = new System.Windows.Forms.DataGridView();
            this.ContractID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suburb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartPeriodDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofnMassive = new System.Windows.Forms.OpenFileDialog();
            this.nudKilowatts = new System.Windows.Forms.NumericUpDown();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsumptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContracts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKilowatts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnAccept.Enabled = false;
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(194, 206);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 41);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "ACEPTAR";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnMassiveCharge
            // 
            this.btnMassiveCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnMassiveCharge.FlatAppearance.BorderSize = 0;
            this.btnMassiveCharge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnMassiveCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMassiveCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMassiveCharge.ForeColor = System.Drawing.Color.White;
            this.btnMassiveCharge.Location = new System.Drawing.Point(331, 206);
            this.btnMassiveCharge.Margin = new System.Windows.Forms.Padding(2);
            this.btnMassiveCharge.Name = "btnMassiveCharge";
            this.btnMassiveCharge.Size = new System.Drawing.Size(129, 41);
            this.btnMassiveCharge.TabIndex = 5;
            this.btnMassiveCharge.Text = "CARGA MASIVA";
            this.btnMassiveCharge.UseVisualStyleBackColor = false;
            this.btnMassiveCharge.Click += new System.EventHandler(this.btnMassiveCharge_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Location = new System.Drawing.Point(23, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "kiloWatts Consumidos:";
            // 
            // txtMeterSerialNumber
            // 
            this.txtMeterSerialNumber.Enabled = false;
            this.txtMeterSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterSerialNumber.Location = new System.Drawing.Point(194, 81);
            this.txtMeterSerialNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtMeterSerialNumber.MaxLength = 30;
            this.txtMeterSerialNumber.Name = "txtMeterSerialNumber";
            this.txtMeterSerialNumber.ReadOnly = true;
            this.txtMeterSerialNumber.Size = new System.Drawing.Size(287, 23);
            this.txtMeterSerialNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label2.Location = new System.Drawing.Point(36, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número de Medidor:";
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblEmpleados.Location = new System.Drawing.Point(15, 15);
            this.lblEmpleados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(174, 31);
            this.lblEmpleados.TabIndex = 21;
            this.lblEmpleados.Text = "CONSUMOS";
            // 
            // dtgConsumptions
            // 
            this.dtgConsumptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsumptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConsumptionID,
            this.MeterSerialNumber,
            this.ServiceNumberr,
            this.BasicKW,
            this.IntermediateKW,
            this.SurplusKW,
            this.TotalKW,
            this.Year,
            this.Month,
            this.day});
            this.dtgConsumptions.Location = new System.Drawing.Point(9, 289);
            this.dtgConsumptions.Margin = new System.Windows.Forms.Padding(2);
            this.dtgConsumptions.Name = "dtgConsumptions";
            this.dtgConsumptions.ReadOnly = true;
            this.dtgConsumptions.RowHeadersWidth = 51;
            this.dtgConsumptions.RowTemplate.Height = 24;
            this.dtgConsumptions.Size = new System.Drawing.Size(870, 329);
            this.dtgConsumptions.TabIndex = 7;
            // 
            // ConsumptionID
            // 
            this.ConsumptionID.DataPropertyName = "CONSUMPTION_ID";
            this.ConsumptionID.HeaderText = "ID";
            this.ConsumptionID.MinimumWidth = 6;
            this.ConsumptionID.Name = "ConsumptionID";
            this.ConsumptionID.ReadOnly = true;
            this.ConsumptionID.Width = 125;
            // 
            // MeterSerialNumber
            // 
            this.MeterSerialNumber.DataPropertyName = "METER_SERIAL_NUMBER";
            this.MeterSerialNumber.HeaderText = "Número de Medidor";
            this.MeterSerialNumber.MinimumWidth = 6;
            this.MeterSerialNumber.Name = "MeterSerialNumber";
            this.MeterSerialNumber.ReadOnly = true;
            this.MeterSerialNumber.Width = 125;
            // 
            // ServiceNumberr
            // 
            this.ServiceNumberr.DataPropertyName = "SERVICE_NUMBER";
            this.ServiceNumberr.HeaderText = "Número de Servicio";
            this.ServiceNumberr.Name = "ServiceNumberr";
            this.ServiceNumberr.ReadOnly = true;
            // 
            // BasicKW
            // 
            this.BasicKW.DataPropertyName = "BASIC_KW";
            this.BasicKW.HeaderText = "kW Básica";
            this.BasicKW.MinimumWidth = 6;
            this.BasicKW.Name = "BasicKW";
            this.BasicKW.ReadOnly = true;
            this.BasicKW.Width = 125;
            // 
            // IntermediateKW
            // 
            this.IntermediateKW.DataPropertyName = "INTERMEDIATE_KW";
            this.IntermediateKW.HeaderText = "kW Intermedia";
            this.IntermediateKW.MinimumWidth = 6;
            this.IntermediateKW.Name = "IntermediateKW";
            this.IntermediateKW.ReadOnly = true;
            this.IntermediateKW.Width = 125;
            // 
            // SurplusKW
            // 
            this.SurplusKW.DataPropertyName = "SURPLUS_KW";
            this.SurplusKW.HeaderText = "kW Excedente";
            this.SurplusKW.MinimumWidth = 6;
            this.SurplusKW.Name = "SurplusKW";
            this.SurplusKW.ReadOnly = true;
            this.SurplusKW.Width = 125;
            // 
            // TotalKW
            // 
            this.TotalKW.DataPropertyName = "TOTAL_KW";
            this.TotalKW.HeaderText = "kW Total";
            this.TotalKW.MinimumWidth = 6;
            this.TotalKW.Name = "TotalKW";
            this.TotalKW.ReadOnly = true;
            this.TotalKW.Width = 125;
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
            // day
            // 
            this.day.DataPropertyName = "DAY";
            this.day.HeaderText = "Dia";
            this.day.Name = "day";
            this.day.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label5.Location = new System.Drawing.Point(18, 148);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Periodo de facturación:";
            // 
            // dtpPeriod
            // 
            this.dtpPeriod.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriod.CustomFormat = "MMMM yyyy";
            this.dtpPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriod.Location = new System.Drawing.Point(194, 143);
            this.dtpPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.dtpPeriod.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpPeriod.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpPeriod.Name = "dtpPeriod";
            this.dtpPeriod.ShowUpDown = true;
            this.dtpPeriod.Size = new System.Drawing.Size(287, 23);
            this.dtpPeriod.TabIndex = 3;
            this.dtpPeriod.Value = new System.DateTime(2021, 10, 1, 14, 33, 0, 0);
            // 
            // dtgContracts
            // 
            this.dtgContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContractID,
            this.dataGridViewTextBoxColumn1,
            this.ServiceNumber,
            this.Service,
            this.State,
            this.City,
            this.Suburb,
            this.Street,
            this.Number,
            this.PostalCode,
            this.StartPeriodDate});
            this.dtgContracts.Location = new System.Drawing.Point(520, 81);
            this.dtgContracts.Margin = new System.Windows.Forms.Padding(2);
            this.dtgContracts.Name = "dtgContracts";
            this.dtgContracts.ReadOnly = true;
            this.dtgContracts.RowHeadersWidth = 51;
            this.dtgContracts.RowTemplate.Height = 24;
            this.dtgContracts.Size = new System.Drawing.Size(359, 183);
            this.dtgContracts.TabIndex = 6;
            this.dtgContracts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgContracts_CellDoubleClick);
            // 
            // ContractID
            // 
            this.ContractID.DataPropertyName = "CONTRACT_ID";
            this.ContractID.HeaderText = "ID";
            this.ContractID.MinimumWidth = 6;
            this.ContractID.Name = "ContractID";
            this.ContractID.ReadOnly = true;
            this.ContractID.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "METER_SERIAL_NUMBER";
            this.dataGridViewTextBoxColumn1.HeaderText = "Número de Medidor";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // ServiceNumber
            // 
            this.ServiceNumber.DataPropertyName = "SERVICE_NUMBER";
            this.ServiceNumber.HeaderText = "Número de Servicio";
            this.ServiceNumber.MinimumWidth = 6;
            this.ServiceNumber.Name = "ServiceNumber";
            this.ServiceNumber.ReadOnly = true;
            this.ServiceNumber.Width = 125;
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
            // State
            // 
            this.State.DataPropertyName = "STATE";
            this.State.HeaderText = "Estado";
            this.State.MinimumWidth = 6;
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 125;
            // 
            // City
            // 
            this.City.DataPropertyName = "CITY";
            this.City.HeaderText = "Ciudad";
            this.City.MinimumWidth = 6;
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Width = 125;
            // 
            // Suburb
            // 
            this.Suburb.DataPropertyName = "SUBURB";
            this.Suburb.HeaderText = "Colonia";
            this.Suburb.MinimumWidth = 6;
            this.Suburb.Name = "Suburb";
            this.Suburb.ReadOnly = true;
            this.Suburb.Width = 125;
            // 
            // Street
            // 
            this.Street.DataPropertyName = "STREET";
            this.Street.HeaderText = "Calle";
            this.Street.MinimumWidth = 6;
            this.Street.Name = "Street";
            this.Street.ReadOnly = true;
            this.Street.Width = 125;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "NUMBER";
            this.Number.HeaderText = "Número";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 125;
            // 
            // PostalCode
            // 
            this.PostalCode.DataPropertyName = "POSTAL_CODE";
            this.PostalCode.HeaderText = "Código Postal";
            this.PostalCode.MinimumWidth = 6;
            this.PostalCode.Name = "PostalCode";
            this.PostalCode.ReadOnly = true;
            this.PostalCode.Width = 125;
            // 
            // StartPeriodDate
            // 
            this.StartPeriodDate.DataPropertyName = "START_PERIOD_DATE";
            this.StartPeriodDate.HeaderText = "Inicio de Periodo";
            this.StartPeriodDate.MinimumWidth = 6;
            this.StartPeriodDate.Name = "StartPeriodDate";
            this.StartPeriodDate.ReadOnly = true;
            this.StartPeriodDate.Width = 125;
            // 
            // ofnMassive
            // 
            this.ofnMassive.Filter = "CSV (*.csv)|*.csv|XLSX (*.xlsx)|*.xlsx";
            // 
            // nudKilowatts
            // 
            this.nudKilowatts.DecimalPlaces = 4;
            this.nudKilowatts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.nudKilowatts.Location = new System.Drawing.Point(194, 112);
            this.nudKilowatts.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudKilowatts.Name = "nudKilowatts";
            this.nudKilowatts.Size = new System.Drawing.Size(287, 23);
            this.nudKilowatts.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblDate.Location = new System.Drawing.Point(521, 47);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(21, 20);
            this.lblDate.TabIndex = 41;
            this.lblDate.Text = "...";
            // 
            // Consumptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(976, 638);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.nudKilowatts);
            this.Controls.Add(this.dtgContracts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpPeriod);
            this.Controls.Add(this.dtgConsumptions);
            this.Controls.Add(this.lblEmpleados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMeterSerialNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMassiveCharge);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Consumptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumos";
            this.Load += new System.EventHandler(this.Consumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsumptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContracts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKilowatts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnMassiveCharge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeterSerialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.DataGridView dtgConsumptions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpPeriod;
        private System.Windows.Forms.DataGridView dtgContracts;
        private System.Windows.Forms.OpenFileDialog ofnMassive;
        private System.Windows.Forms.NumericUpDown nudKilowatts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsumptionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceNumberr;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicKW;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntermediateKW;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurplusKW;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalKW;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn day;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suburb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartPeriodDate;
        private System.Windows.Forms.Label lblDate;
    }
}