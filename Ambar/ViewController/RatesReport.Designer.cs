
namespace Ambar.ViewController
{
    partial class RatesReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgRatesReport = new System.Windows.Forms.DataGridView();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntermediateLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurplusLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.ofnReportCSV = new System.Windows.Forms.SaveFileDialog();
            this.ofnReportPDF = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRatesReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgRatesReport
            // 
            this.dtgRatesReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dtgRatesReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgRatesReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRatesReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgRatesReport.ColumnHeadersHeight = 36;
            this.dtgRatesReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Year,
            this.Month,
            this.BasicLevel,
            this.IntermediateLevel,
            this.SurplusLevel});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgRatesReport.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgRatesReport.EnableHeadersVisualStyles = false;
            this.dtgRatesReport.Location = new System.Drawing.Point(26, 110);
            this.dtgRatesReport.Margin = new System.Windows.Forms.Padding(2);
            this.dtgRatesReport.Name = "dtgRatesReport";
            this.dtgRatesReport.ReadOnly = true;
            this.dtgRatesReport.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRatesReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgRatesReport.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.dtgRatesReport.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgRatesReport.RowTemplate.Height = 24;
            this.dtgRatesReport.Size = new System.Drawing.Size(872, 444);
            this.dtgRatesReport.TabIndex = 0;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "YEAR";
            this.Year.HeaderText = "Año";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 150;
            // 
            // Month
            // 
            this.Month.DataPropertyName = "MONTH";
            this.Month.HeaderText = "Mes";
            this.Month.MinimumWidth = 6;
            this.Month.Name = "Month";
            this.Month.ReadOnly = true;
            this.Month.Width = 150;
            // 
            // BasicLevel
            // 
            this.BasicLevel.DataPropertyName = "BASIC_LEVEL";
            this.BasicLevel.HeaderText = "Tárifa Básica";
            this.BasicLevel.MinimumWidth = 6;
            this.BasicLevel.Name = "BasicLevel";
            this.BasicLevel.ReadOnly = true;
            this.BasicLevel.Width = 150;
            // 
            // IntermediateLevel
            // 
            this.IntermediateLevel.DataPropertyName = "INTERMEDIATE_LEVEL";
            this.IntermediateLevel.HeaderText = "Tárifa Intermedia";
            this.IntermediateLevel.MinimumWidth = 6;
            this.IntermediateLevel.Name = "IntermediateLevel";
            this.IntermediateLevel.ReadOnly = true;
            this.IntermediateLevel.Width = 150;
            // 
            // SurplusLevel
            // 
            this.SurplusLevel.DataPropertyName = "SURPLUS_LEVEL";
            this.SurplusLevel.HeaderText = "Tárifa Excedente";
            this.SurplusLevel.MinimumWidth = 6;
            this.SurplusLevel.Name = "SurplusLevel";
            this.SurplusLevel.ReadOnly = true;
            this.SurplusLevel.Width = 150;
            // 
            // dtpYear
            // 
            this.dtpYear.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpYear.Location = new System.Drawing.Point(83, 70);
            this.dtpYear.Margin = new System.Windows.Forms.Padding(2);
            this.dtpYear.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpYear.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(151, 23);
            this.dtpYear.TabIndex = 1;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpYear_ValueChanged);
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblEmpleados.Location = new System.Drawing.Point(11, 12);
            this.lblEmpleados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(314, 31);
            this.lblEmpleados.TabIndex = 22;
            this.lblEmpleados.Text = "REPORTE DE TARIFAS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label4.Location = new System.Drawing.Point(42, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Año:";
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnPDF.FlatAppearance.BorderSize = 0;
            this.btnPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.ForeColor = System.Drawing.Color.White;
            this.btnPDF.Image = global::Ambar.Properties.Resources.PDF_Logo;
            this.btnPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDF.Location = new System.Drawing.Point(631, 576);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(2);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(225, 81);
            this.btnPDF.TabIndex = 3;
            this.btnPDF.Text = "          GENERAR PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnCSV.FlatAppearance.BorderSize = 0;
            this.btnCSV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSV.ForeColor = System.Drawing.Color.White;
            this.btnCSV.Image = global::Ambar.Properties.Resources.CSV_Logo;
            this.btnCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCSV.Location = new System.Drawing.Point(371, 576);
            this.btnCSV.Margin = new System.Windows.Forms.Padding(2);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(225, 81);
            this.btnCSV.TabIndex = 2;
            this.btnCSV.Text = "          GENERAR CSV";
            this.btnCSV.UseVisualStyleBackColor = false;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // ofnReportCSV
            // 
            this.ofnReportCSV.Filter = "CSV (*.csv)|*.csv";
            // 
            // ofnReportPDF
            // 
            this.ofnReportPDF.Filter = "PDF (*.pdf)|*.pdf";
            // 
            // RatesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(977, 683);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEmpleados);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.dtgRatesReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RatesReport";
            this.Text = "RatesReport";
            this.Load += new System.EventHandler(this.RatesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRatesReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgRatesReport;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog ofnReportCSV;
        private System.Windows.Forms.SaveFileDialog ofnReportPDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntermediateLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurplusLevel;
    }
}