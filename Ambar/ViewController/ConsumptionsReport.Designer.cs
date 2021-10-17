
namespace Ambar.ViewController
{
    partial class ConsumptionsReport
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
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.dtgConsumptionsReport = new System.Windows.Forms.DataGridView();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LevelSerialMeter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntermediateLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurplusLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofnReportCSV = new System.Windows.Forms.SaveFileDialog();
            this.ofnReportPDF = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsumptionsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Montserrat", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblEmpleados.Location = new System.Drawing.Point(15, 15);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(453, 40);
            this.lblEmpleados.TabIndex = 23;
            this.lblEmpleados.Text = "REPORTE DE CONSUMOS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label4.Location = new System.Drawing.Point(31, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Año:";
            // 
            // dtpYear
            // 
            this.dtpYear.CalendarFont = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpYear.Location = new System.Drawing.Point(86, 85);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(200, 28);
            this.dtpYear.TabIndex = 24;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpYear_ValueChanged);
            // 
            // dtgConsumptionsReport
            // 
            this.dtgConsumptionsReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsumptionsReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Year,
            this.Month,
            this.LevelSerialMeter,
            this.BasicLevel,
            this.IntermediateLevel,
            this.SurplusLevel});
            this.dtgConsumptionsReport.Location = new System.Drawing.Point(22, 133);
            this.dtgConsumptionsReport.Name = "dtgConsumptionsReport";
            this.dtgConsumptionsReport.RowHeadersWidth = 51;
            this.dtgConsumptionsReport.RowTemplate.Height = 24;
            this.dtgConsumptionsReport.Size = new System.Drawing.Size(870, 310);
            this.dtgConsumptionsReport.TabIndex = 26;
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnPDF.FlatAppearance.BorderSize = 0;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.Image = global::Ambar.Properties.Resources.PDF_Logo;
            this.btnPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDF.Location = new System.Drawing.Point(637, 480);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(300, 100);
            this.btnPDF.TabIndex = 28;
            this.btnPDF.Text = "          GENERAR PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnCSV.FlatAppearance.BorderSize = 0;
            this.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCSV.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSV.Image = global::Ambar.Properties.Resources.CSV_Logo;
            this.btnCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCSV.Location = new System.Drawing.Point(276, 480);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(300, 100);
            this.btnCSV.TabIndex = 27;
            this.btnCSV.Text = "          GENERAR CSV";
            this.btnCSV.UseVisualStyleBackColor = false;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
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
            // LevelSerialMeter
            // 
            this.LevelSerialMeter.DataPropertyName = "METER_SERIAL_NUMBER";
            this.LevelSerialMeter.HeaderText = "Número de Medidor";
            this.LevelSerialMeter.MinimumWidth = 6;
            this.LevelSerialMeter.Name = "LevelSerialMeter";
            this.LevelSerialMeter.Width = 125;
            // 
            // BasicLevel
            // 
            this.BasicLevel.DataPropertyName = "BASIC_KW";
            this.BasicLevel.HeaderText = "kW Básica";
            this.BasicLevel.MinimumWidth = 6;
            this.BasicLevel.Name = "BasicLevel";
            this.BasicLevel.Width = 125;
            // 
            // IntermediateLevel
            // 
            this.IntermediateLevel.DataPropertyName = "INTERMEDIATE_KW";
            this.IntermediateLevel.HeaderText = "kW Intermedia";
            this.IntermediateLevel.MinimumWidth = 6;
            this.IntermediateLevel.Name = "IntermediateLevel";
            this.IntermediateLevel.Width = 125;
            // 
            // SurplusLevel
            // 
            this.SurplusLevel.DataPropertyName = "SURPLUS_KW";
            this.SurplusLevel.HeaderText = "kW Excedente";
            this.SurplusLevel.MinimumWidth = 6;
            this.SurplusLevel.Name = "SurplusLevel";
            this.SurplusLevel.Width = 125;
            // 
            // ofnReportCSV
            // 
            this.ofnReportCSV.Filter = "CSV (*.csv)|*.csv";
            // 
            // ofnReportPDF
            // 
            this.ofnReportPDF.Filter = "PDF (*.pdf)|*.pdf";
            // 
            // ConsumptionsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1062, 616);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.dtgConsumptionsReport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.lblEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsumptionsReport";
            this.Text = "ConsumptionsReport";
            this.Load += new System.EventHandler(this.ConsumptionsReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsumptionsReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.DataGridView dtgConsumptionsReport;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelSerialMeter;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntermediateLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurplusLevel;
        private System.Windows.Forms.SaveFileDialog ofnReportCSV;
        private System.Windows.Forms.SaveFileDialog ofnReportPDF;
    }
}