namespace Ambar.ViewController
{
    partial class Consumos
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
            this.txtKilowatts = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeterSerialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.dtgConsumptions = new System.Windows.Forms.DataGridView();
            this.ConsumptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicKW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntermediateKW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurplusKW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalKW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPeriod = new System.Windows.Forms.DateTimePicker();
            this.dtgContracts = new System.Windows.Forms.DataGridView();
            this.ContractID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suburb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartPeriodDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblError = new System.Windows.Forms.Label();
            this.pbWarningIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsumptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContracts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKilowatts
            // 
            this.txtKilowatts.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKilowatts.Location = new System.Drawing.Point(259, 147);
            this.txtKilowatts.Name = "txtKilowatts";
            this.txtKilowatts.Size = new System.Drawing.Size(279, 28);
            this.txtKilowatts.TabIndex = 0;
            this.txtKilowatts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(94, 267);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(150, 50);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "ACEPTAR";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(273, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "CARGA MASIVA";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Location = new System.Drawing.Point(23, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "kiloWatts Consumidos:";
            // 
            // txtMeterSerialNumber
            // 
            this.txtMeterSerialNumber.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterSerialNumber.Location = new System.Drawing.Point(259, 97);
            this.txtMeterSerialNumber.Name = "txtMeterSerialNumber";
            this.txtMeterSerialNumber.Size = new System.Drawing.Size(279, 28);
            this.txtMeterSerialNumber.TabIndex = 4;
            this.txtMeterSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label2.Location = new System.Drawing.Point(40, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número de Medidor:";
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Montserrat", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblEmpleados.Location = new System.Drawing.Point(20, 20);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(224, 40);
            this.lblEmpleados.TabIndex = 21;
            this.lblEmpleados.Text = "CONSUMOS";
            // 
            // dtgConsumptions
            // 
            this.dtgConsumptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsumptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConsumptionID,
            this.MeterSerialNumber,
            this.BasicKW,
            this.IntermediateKW,
            this.SurplusKW,
            this.Year,
            this.Month,
            this.TotalKW});
            this.dtgConsumptions.Location = new System.Drawing.Point(12, 444);
            this.dtgConsumptions.Name = "dtgConsumptions";
            this.dtgConsumptions.RowHeadersWidth = 51;
            this.dtgConsumptions.RowTemplate.Height = 24;
            this.dtgConsumptions.Size = new System.Drawing.Size(635, 150);
            this.dtgConsumptions.TabIndex = 22;
            // 
            // ConsumptionID
            // 
            this.ConsumptionID.HeaderText = "ID";
            this.ConsumptionID.MinimumWidth = 6;
            this.ConsumptionID.Name = "ConsumptionID";
            this.ConsumptionID.Width = 125;
            // 
            // MeterSerialNumber
            // 
            this.MeterSerialNumber.HeaderText = "Número de Medidor";
            this.MeterSerialNumber.MinimumWidth = 6;
            this.MeterSerialNumber.Name = "MeterSerialNumber";
            this.MeterSerialNumber.Width = 125;
            // 
            // BasicKW
            // 
            this.BasicKW.HeaderText = "kW Básica";
            this.BasicKW.MinimumWidth = 6;
            this.BasicKW.Name = "BasicKW";
            this.BasicKW.Width = 125;
            // 
            // IntermediateKW
            // 
            this.IntermediateKW.HeaderText = "kW Intermedia";
            this.IntermediateKW.MinimumWidth = 6;
            this.IntermediateKW.Name = "IntermediateKW";
            this.IntermediateKW.Width = 125;
            // 
            // SurplusKW
            // 
            this.SurplusKW.HeaderText = "kW Excedente";
            this.SurplusKW.MinimumWidth = 6;
            this.SurplusKW.Name = "SurplusKW";
            this.SurplusKW.Width = 125;
            // 
            // Year
            // 
            this.Year.HeaderText = "Año";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.Width = 125;
            // 
            // Month
            // 
            this.Month.HeaderText = "Mes";
            this.Month.MinimumWidth = 6;
            this.Month.Name = "Month";
            this.Month.Width = 125;
            // 
            // TotalKW
            // 
            this.TotalKW.HeaderText = "kW Total";
            this.TotalKW.MinimumWidth = 6;
            this.TotalKW.Name = "TotalKW";
            this.TotalKW.Width = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label5.Location = new System.Drawing.Point(23, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Periodo de facturación:";
            // 
            // dtpPeriod
            // 
            this.dtpPeriod.CalendarFont = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriod.CustomFormat = "MMMM yyyy";
            this.dtpPeriod.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriod.Location = new System.Drawing.Point(259, 202);
            this.dtpPeriod.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dtpPeriod.Name = "dtpPeriod";
            this.dtpPeriod.ShowUpDown = true;
            this.dtpPeriod.Size = new System.Drawing.Size(279, 28);
            this.dtpPeriod.TabIndex = 23;
            // 
            // dtgContracts
            // 
            this.dtgContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContractID,
            this.dataGridViewTextBoxColumn1,
            this.ServiceNumber,
            this.State,
            this.City,
            this.Suburb,
            this.Street,
            this.Number,
            this.PostalCode,
            this.Service,
            this.StartPeriodDate});
            this.dtgContracts.Location = new System.Drawing.Point(694, 79);
            this.dtgContracts.Name = "dtgContracts";
            this.dtgContracts.RowHeadersWidth = 51;
            this.dtgContracts.RowTemplate.Height = 24;
            this.dtgContracts.Size = new System.Drawing.Size(479, 292);
            this.dtgContracts.TabIndex = 25;
            // 
            // ContractID
            // 
            this.ContractID.DataPropertyName = "CONTRACT_ID";
            this.ContractID.HeaderText = "ID";
            this.ContractID.MinimumWidth = 6;
            this.ContractID.Name = "ContractID";
            this.ContractID.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "METER_SERIAL_NUMBER";
            this.dataGridViewTextBoxColumn1.HeaderText = "Meter Serial Number";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // ServiceNumber
            // 
            this.ServiceNumber.DataPropertyName = "SERVICE_NUMBER";
            this.ServiceNumber.HeaderText = "Service Number";
            this.ServiceNumber.MinimumWidth = 6;
            this.ServiceNumber.Name = "ServiceNumber";
            this.ServiceNumber.Width = 125;
            // 
            // State
            // 
            this.State.DataPropertyName = "STATE";
            this.State.HeaderText = "State";
            this.State.MinimumWidth = 6;
            this.State.Name = "State";
            this.State.Width = 125;
            // 
            // City
            // 
            this.City.DataPropertyName = "CITY";
            this.City.HeaderText = "City";
            this.City.MinimumWidth = 6;
            this.City.Name = "City";
            this.City.Width = 125;
            // 
            // Suburb
            // 
            this.Suburb.DataPropertyName = "SUBURB";
            this.Suburb.HeaderText = "Suburb";
            this.Suburb.MinimumWidth = 6;
            this.Suburb.Name = "Suburb";
            this.Suburb.Width = 125;
            // 
            // Street
            // 
            this.Street.DataPropertyName = "STREET";
            this.Street.HeaderText = "Street";
            this.Street.MinimumWidth = 6;
            this.Street.Name = "Street";
            this.Street.Width = 125;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "NUMBER";
            this.Number.HeaderText = "Number";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.Width = 125;
            // 
            // PostalCode
            // 
            this.PostalCode.DataPropertyName = "POSTAL_CODE";
            this.PostalCode.HeaderText = "Postal Code";
            this.PostalCode.MinimumWidth = 6;
            this.PostalCode.Name = "PostalCode";
            this.PostalCode.Width = 125;
            // 
            // Service
            // 
            this.Service.DataPropertyName = "SERVICE";
            this.Service.HeaderText = "Service";
            this.Service.MinimumWidth = 6;
            this.Service.Name = "Service";
            this.Service.Width = 125;
            // 
            // StartPeriodDate
            // 
            this.StartPeriodDate.DataPropertyName = "START_PERIOD_DATE";
            this.StartPeriodDate.HeaderText = "Start Period Date";
            this.StartPeriodDate.MinimumWidth = 6;
            this.StartPeriodDate.Name = "StartPeriodDate";
            this.StartPeriodDate.Width = 125;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblError.Location = new System.Drawing.Point(416, 58);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(107, 19);
            this.lblError.TabIndex = 27;
            this.lblError.Text = "ERROR TEXT";
            this.lblError.Visible = false;
            // 
            // pbWarningIcon
            // 
            this.pbWarningIcon.Image = global::Ambar.Properties.Resources.Warning_Icon1;
            this.pbWarningIcon.Location = new System.Drawing.Point(377, 52);
            this.pbWarningIcon.Name = "pbWarningIcon";
            this.pbWarningIcon.Size = new System.Drawing.Size(30, 30);
            this.pbWarningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWarningIcon.TabIndex = 26;
            this.pbWarningIcon.TabStop = false;
            this.pbWarningIcon.Visible = false;
            // 
            // Consumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1301, 676);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pbWarningIcon);
            this.Controls.Add(this.dtgContracts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpPeriod);
            this.Controls.Add(this.dtgConsumptions);
            this.Controls.Add(this.lblEmpleados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMeterSerialNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtKilowatts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Consumos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumos";
            this.Load += new System.EventHandler(this.Consumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsumptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContracts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKilowatts;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeterSerialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.DataGridView dtgConsumptions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsumptionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicKW;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntermediateKW;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurplusKW;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalKW;
        private System.Windows.Forms.DataGridView dtgContracts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suburb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartPeriodDate;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox pbWarningIcon;
    }
}