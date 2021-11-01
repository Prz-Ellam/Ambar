﻿
namespace Ambar.ViewController
{
    partial class Receipts
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
            this.cbService = new System.Windows.Forms.ComboBox();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateReceipt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPDF = new System.Windows.Forms.Button();
            this.gpSearchOptions = new System.Windows.Forms.GroupBox();
            this.rbServiceNumber = new System.Windows.Forms.RadioButton();
            this.rbMeterSerialNumber = new System.Windows.Forms.RadioButton();
            this.txtSearchID = new System.Windows.Forms.TextBox();
            this.dtpPeriodSearch = new System.Windows.Forms.DateTimePicker();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.ofnReceipt = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.pbWarningIcon = new System.Windows.Forms.PictureBox();
            this.gpSearchOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblEmpleados.Location = new System.Drawing.Point(15, 15);
            this.lblEmpleados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(137, 31);
            this.lblEmpleados.TabIndex = 21;
            this.lblEmpleados.Text = "RECIBOS";
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
            this.cbService.Location = new System.Drawing.Point(196, 86);
            this.cbService.Margin = new System.Windows.Forms.Padding(2);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(202, 25);
            this.cbService.TabIndex = 22;
            this.cbService.SelectedIndexChanged += new System.EventHandler(this.cbService_SelectedIndexChanged);
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(196, 160);
            this.dtpYear.Margin = new System.Windows.Forms.Padding(2);
            this.dtpYear.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpYear.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(63, 23);
            this.dtpYear.TabIndex = 23;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpYear_ValueChanged);
            // 
            // btnGenerateReceipt
            // 
            this.btnGenerateReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnGenerateReceipt.FlatAppearance.BorderSize = 0;
            this.btnGenerateReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReceipt.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReceipt.Location = new System.Drawing.Point(196, 215);
            this.btnGenerateReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateReceipt.Name = "btnGenerateReceipt";
            this.btnGenerateReceipt.Size = new System.Drawing.Size(134, 57);
            this.btnGenerateReceipt.TabIndex = 24;
            this.btnGenerateReceipt.Text = "Generar Recibos";
            this.btnGenerateReceipt.UseVisualStyleBackColor = false;
            this.btnGenerateReceipt.Click += new System.EventHandler(this.btnGenerateReceipt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label5.Location = new System.Drawing.Point(64, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tipo de servicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Location = new System.Drawing.Point(17, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Periodo de facturacion:";
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnPDF.FlatAppearance.BorderSize = 0;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.ForeColor = System.Drawing.Color.White;
            this.btnPDF.Location = new System.Drawing.Point(528, 238);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(2);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(200, 87);
            this.btnPDF.TabIndex = 27;
            this.btnPDF.Text = "Generar Recibo PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // gpSearchOptions
            // 
            this.gpSearchOptions.Controls.Add(this.rbServiceNumber);
            this.gpSearchOptions.Controls.Add(this.rbMeterSerialNumber);
            this.gpSearchOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpSearchOptions.ForeColor = System.Drawing.Color.White;
            this.gpSearchOptions.Location = new System.Drawing.Point(545, 43);
            this.gpSearchOptions.Margin = new System.Windows.Forms.Padding(2);
            this.gpSearchOptions.Name = "gpSearchOptions";
            this.gpSearchOptions.Padding = new System.Windows.Forms.Padding(2);
            this.gpSearchOptions.Size = new System.Drawing.Size(204, 82);
            this.gpSearchOptions.TabIndex = 28;
            this.gpSearchOptions.TabStop = false;
            this.gpSearchOptions.Text = "Buscar por: ";
            // 
            // rbServiceNumber
            // 
            this.rbServiceNumber.AutoSize = true;
            this.rbServiceNumber.Location = new System.Drawing.Point(13, 46);
            this.rbServiceNumber.Margin = new System.Windows.Forms.Padding(2);
            this.rbServiceNumber.Name = "rbServiceNumber";
            this.rbServiceNumber.Size = new System.Drawing.Size(145, 20);
            this.rbServiceNumber.TabIndex = 1;
            this.rbServiceNumber.TabStop = true;
            this.rbServiceNumber.Text = "Número de Servicio";
            this.rbServiceNumber.UseVisualStyleBackColor = true;
            // 
            // rbMeterSerialNumber
            // 
            this.rbMeterSerialNumber.AutoSize = true;
            this.rbMeterSerialNumber.Checked = true;
            this.rbMeterSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMeterSerialNumber.Location = new System.Drawing.Point(13, 22);
            this.rbMeterSerialNumber.Margin = new System.Windows.Forms.Padding(2);
            this.rbMeterSerialNumber.Name = "rbMeterSerialNumber";
            this.rbMeterSerialNumber.Size = new System.Drawing.Size(146, 20);
            this.rbMeterSerialNumber.TabIndex = 0;
            this.rbMeterSerialNumber.TabStop = true;
            this.rbMeterSerialNumber.Text = "Número de Medidor";
            this.rbMeterSerialNumber.UseVisualStyleBackColor = true;
            // 
            // txtSearchID
            // 
            this.txtSearchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchID.Location = new System.Drawing.Point(545, 138);
            this.txtSearchID.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchID.Name = "txtSearchID";
            this.txtSearchID.Size = new System.Drawing.Size(204, 22);
            this.txtSearchID.TabIndex = 29;
            // 
            // dtpPeriodSearch
            // 
            this.dtpPeriodSearch.CustomFormat = "MMMM yyyy";
            this.dtpPeriodSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPeriodSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodSearch.Location = new System.Drawing.Point(651, 179);
            this.dtpPeriodSearch.Margin = new System.Windows.Forms.Padding(2);
            this.dtpPeriodSearch.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpPeriodSearch.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpPeriodSearch.Name = "dtpPeriodSearch";
            this.dtpPeriodSearch.ShowUpDown = true;
            this.dtpPeriodSearch.Size = new System.Drawing.Size(151, 23);
            this.dtpPeriodSearch.TabIndex = 30;
            // 
            // cbPeriod
            // 
            this.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Location = new System.Drawing.Point(196, 125);
            this.cbPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(202, 25);
            this.cbPeriod.TabIndex = 31;
            // 
            // ofnReceipt
            // 
            this.ofnReceipt.Filter = "PDF (*.pdf)|.pdf";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label2.Location = new System.Drawing.Point(480, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Periodo de facturacion:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblError.Location = new System.Drawing.Point(223, 55);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(84, 15);
            this.lblError.TabIndex = 34;
            this.lblError.Text = "ERROR TEXT";
            this.lblError.Visible = false;
            // 
            // pbWarningIcon
            // 
            this.pbWarningIcon.Image = global::Ambar.Properties.Resources.Warning_Icon1;
            this.pbWarningIcon.Location = new System.Drawing.Point(194, 50);
            this.pbWarningIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pbWarningIcon.Name = "pbWarningIcon";
            this.pbWarningIcon.Size = new System.Drawing.Size(22, 24);
            this.pbWarningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWarningIcon.TabIndex = 33;
            this.pbWarningIcon.TabStop = false;
            this.pbWarningIcon.Visible = false;
            // 
            // Receipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(880, 479);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pbWarningIcon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPeriod);
            this.Controls.Add(this.dtpPeriodSearch);
            this.Controls.Add(this.txtSearchID);
            this.Controls.Add(this.gpSearchOptions);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGenerateReceipt);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.cbService);
            this.Controls.Add(this.lblEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Receipts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibos";
            this.Load += new System.EventHandler(this.Receipts_Load);
            this.gpSearchOptions.ResumeLayout(false);
            this.gpSearchOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Button btnGenerateReceipt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.GroupBox gpSearchOptions;
        private System.Windows.Forms.RadioButton rbServiceNumber;
        private System.Windows.Forms.RadioButton rbMeterSerialNumber;
        private System.Windows.Forms.TextBox txtSearchID;
        private System.Windows.Forms.DateTimePicker dtpPeriodSearch;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.SaveFileDialog ofnReceipt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox pbWarningIcon;
    }
}