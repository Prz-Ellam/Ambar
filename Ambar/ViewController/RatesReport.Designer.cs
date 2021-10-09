
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntermediateLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurplusLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Year,
            this.Month,
            this.BasicLevel,
            this.IntermediateLevel,
            this.SurplusLevel});
            this.dataGridView1.Location = new System.Drawing.Point(46, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(678, 310);
            this.dataGridView1.TabIndex = 0;
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
            // BasicLevel
            // 
            this.BasicLevel.HeaderText = "Tárifa Básica";
            this.BasicLevel.MinimumWidth = 6;
            this.BasicLevel.Name = "BasicLevel";
            this.BasicLevel.Width = 125;
            // 
            // IntermediateLevel
            // 
            this.IntermediateLevel.HeaderText = "Tárifa Intermedia";
            this.IntermediateLevel.MinimumWidth = 6;
            this.IntermediateLevel.Name = "IntermediateLevel";
            this.IntermediateLevel.Width = 125;
            // 
            // SurplusLevel
            // 
            this.SurplusLevel.HeaderText = "Tárifa Excedente";
            this.SurplusLevel.MinimumWidth = 6;
            this.SurplusLevel.Name = "SurplusLevel";
            this.SurplusLevel.Width = 125;
            // 
            // dtpYear
            // 
            this.dtpYear.CalendarFont = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpYear.Location = new System.Drawing.Point(111, 86);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(200, 28);
            this.dtpYear.TabIndex = 1;
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnCSV.FlatAppearance.BorderSize = 0;
            this.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCSV.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSV.Image = global::Ambar.Properties.Resources.CSV_Logo;
            this.btnCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCSV.Location = new System.Drawing.Point(362, 469);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(225, 75);
            this.btnCSV.TabIndex = 2;
            this.btnCSV.Text = "          GENERAR CSV";
            this.btnCSV.UseVisualStyleBackColor = false;
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnPDF.FlatAppearance.BorderSize = 0;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.Image = global::Ambar.Properties.Resources.PDF_Logo;
            this.btnPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDF.Location = new System.Drawing.Point(634, 469);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(225, 75);
            this.btnPDF.TabIndex = 3;
            this.btnPDF.Text = "          GENERAR PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Montserrat", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblEmpleados.Location = new System.Drawing.Point(15, 15);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(386, 40);
            this.lblEmpleados.TabIndex = 22;
            this.lblEmpleados.Text = "REPORTE DE TARIFAS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label4.Location = new System.Drawing.Point(56, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Año:";
            // 
            // RatesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1021, 583);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEmpleados);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RatesReport";
            this.Text = "RatesReport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntermediateLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurplusLevel;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.Label label4;
    }
}