
namespace Ambar.ViewController
{
    partial class ClientReceipts
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
            this.lblReceipts = new System.Windows.Forms.Label();
            this.dtgContracts = new System.Windows.Forms.DataGridView();
            this.txtMeterSerialNumber = new System.Windows.Forms.TextBox();
            this.btnPDF = new System.Windows.Forms.Button();
            this.dtpPeriodSearch = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTransfer = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.rbDebit = new System.Windows.Forms.RadioButton();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblTotalPagado = new System.Windows.Forms.Label();
            this.lblTotalPendiente = new System.Windows.Forms.Label();
            this.btnPaid = new System.Windows.Forms.Button();
            this.lblImport = new System.Windows.Forms.Label();
            this.lblAmountPad = new System.Windows.Forms.Label();
            this.lblPendingPaid = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContracts)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReceipts
            // 
            this.lblReceipts.AutoSize = true;
            this.lblReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceipts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblReceipts.Location = new System.Drawing.Point(15, 15);
            this.lblReceipts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReceipts.Name = "lblReceipts";
            this.lblReceipts.Size = new System.Drawing.Size(137, 31);
            this.lblReceipts.TabIndex = 22;
            this.lblReceipts.Text = "RECIBOS";
            // 
            // dtgContracts
            // 
            this.dtgContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgContracts.Location = new System.Drawing.Point(21, 65);
            this.dtgContracts.Name = "dtgContracts";
            this.dtgContracts.Size = new System.Drawing.Size(824, 185);
            this.dtgContracts.TabIndex = 23;
            // 
            // txtMeterSerialNumber
            // 
            this.txtMeterSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtMeterSerialNumber.Location = new System.Drawing.Point(183, 284);
            this.txtMeterSerialNumber.Name = "txtMeterSerialNumber";
            this.txtMeterSerialNumber.Size = new System.Drawing.Size(226, 23);
            this.txtMeterSerialNumber.TabIndex = 24;
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnPDF.FlatAppearance.BorderSize = 0;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.ForeColor = System.Drawing.Color.White;
            this.btnPDF.Location = new System.Drawing.Point(435, 284);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(2);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(200, 87);
            this.btnPDF.TabIndex = 28;
            this.btnPDF.Text = "GENERAR RECIBO PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            // 
            // dtpPeriodSearch
            // 
            this.dtpPeriodSearch.CustomFormat = "MMMM yyyy";
            this.dtpPeriodSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dtpPeriodSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodSearch.Location = new System.Drawing.Point(183, 314);
            this.dtpPeriodSearch.Name = "dtpPeriodSearch";
            this.dtpPeriodSearch.ShowUpDown = true;
            this.dtpPeriodSearch.Size = new System.Drawing.Size(226, 23);
            this.dtpPeriodSearch.TabIndex = 30;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(26, 358);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 52);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "BUSCAR";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTransfer);
            this.groupBox1.Controls.Add(this.rbCredit);
            this.groupBox1.Controls.Add(this.rbDebit);
            this.groupBox1.Controls.Add(this.rbCash);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.groupBox1.Location = new System.Drawing.Point(659, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 142);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de pago:";
            // 
            // rbTransfer
            // 
            this.rbTransfer.AutoSize = true;
            this.rbTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTransfer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rbTransfer.Location = new System.Drawing.Point(12, 106);
            this.rbTransfer.Name = "rbTransfer";
            this.rbTransfer.Size = new System.Drawing.Size(165, 20);
            this.rbTransfer.TabIndex = 3;
            this.rbTransfer.Text = "Transferencia bancaria";
            this.rbTransfer.UseVisualStyleBackColor = true;
            // 
            // rbCredit
            // 
            this.rbCredit.AutoSize = true;
            this.rbCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rbCredit.Location = new System.Drawing.Point(12, 79);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(132, 20);
            this.rbCredit.TabIndex = 2;
            this.rbCredit.Text = "Tarjeta de credito";
            this.rbCredit.UseVisualStyleBackColor = true;
            // 
            // rbDebit
            // 
            this.rbDebit.AutoSize = true;
            this.rbDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDebit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rbDebit.Location = new System.Drawing.Point(12, 51);
            this.rbDebit.Name = "rbDebit";
            this.rbDebit.Size = new System.Drawing.Size(129, 20);
            this.rbDebit.TabIndex = 1;
            this.rbDebit.Text = "Tarjeta de débito";
            this.rbDebit.UseVisualStyleBackColor = true;
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Checked = true;
            this.rbCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rbCash.Location = new System.Drawing.Point(12, 25);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(74, 20);
            this.rbCash.TabIndex = 0;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Efectivo";
            this.rbCash.UseVisualStyleBackColor = true;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblImporte.Location = new System.Drawing.Point(436, 393);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(64, 16);
            this.lblImporte.TabIndex = 33;
            this.lblImporte.Text = "Importe:";
            // 
            // lblTotalPagado
            // 
            this.lblTotalPagado.AutoSize = true;
            this.lblTotalPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblTotalPagado.Location = new System.Drawing.Point(436, 425);
            this.lblTotalPagado.Name = "lblTotalPagado";
            this.lblTotalPagado.Size = new System.Drawing.Size(106, 16);
            this.lblTotalPagado.TabIndex = 34;
            this.lblTotalPagado.Text = "Total pagado:";
            // 
            // lblTotalPendiente
            // 
            this.lblTotalPendiente.AutoSize = true;
            this.lblTotalPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPendiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblTotalPendiente.Location = new System.Drawing.Point(436, 457);
            this.lblTotalPendiente.Name = "lblTotalPendiente";
            this.lblTotalPendiente.Size = new System.Drawing.Size(121, 16);
            this.lblTotalPendiente.TabIndex = 35;
            this.lblTotalPendiente.Text = "Total pendiente:";
            // 
            // btnPaid
            // 
            this.btnPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnPaid.FlatAppearance.BorderSize = 0;
            this.btnPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaid.ForeColor = System.Drawing.Color.White;
            this.btnPaid.Location = new System.Drawing.Point(793, 473);
            this.btnPaid.Margin = new System.Windows.Forms.Padding(2);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(66, 31);
            this.btnPaid.TabIndex = 37;
            this.btnPaid.Text = "Pagar";
            this.btnPaid.UseVisualStyleBackColor = false;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblImport.Location = new System.Drawing.Point(499, 393);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(17, 16);
            this.lblImport.TabIndex = 38;
            this.lblImport.Text = "...";
            // 
            // lblAmountPad
            // 
            this.lblAmountPad.AutoSize = true;
            this.lblAmountPad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblAmountPad.Location = new System.Drawing.Point(548, 425);
            this.lblAmountPad.Name = "lblAmountPad";
            this.lblAmountPad.Size = new System.Drawing.Size(17, 16);
            this.lblAmountPad.TabIndex = 39;
            this.lblAmountPad.Text = "...";
            // 
            // lblPendingPaid
            // 
            this.lblPendingPaid.AutoSize = true;
            this.lblPendingPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblPendingPaid.Location = new System.Drawing.Point(563, 457);
            this.lblPendingPaid.Name = "lblPendingPaid";
            this.lblPendingPaid.Size = new System.Drawing.Size(17, 16);
            this.lblPendingPaid.TabIndex = 40;
            this.lblPendingPaid.Text = "...";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(659, 473);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 31);
            this.button1.TabIndex = 41;
            this.button1.Text = "Pago Masivo";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label4.Location = new System.Drawing.Point(23, 287);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "N° de Medidor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label5.Location = new System.Drawing.Point(23, 319);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Periodo de facturación:";
            // 
            // nudMount
            // 
            this.nudMount.DecimalPlaces = 2;
            this.nudMount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.nudMount.Location = new System.Drawing.Point(659, 439);
            this.nudMount.Name = "nudMount";
            this.nudMount.Size = new System.Drawing.Size(200, 23);
            this.nudMount.TabIndex = 44;
            // 
            // ClientReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(907, 558);
            this.Controls.Add(this.nudMount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPendingPaid);
            this.Controls.Add(this.lblAmountPad);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.btnPaid);
            this.Controls.Add(this.lblTotalPendiente);
            this.Controls.Add(this.lblTotalPagado);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpPeriodSearch);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.txtMeterSerialNumber);
            this.Controls.Add(this.dtgContracts);
            this.Controls.Add(this.lblReceipts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientReceipts";
            this.Text = "ClientReceipts";
            this.Load += new System.EventHandler(this.ClientReceipts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgContracts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReceipts;
        private System.Windows.Forms.DataGridView dtgContracts;
        private System.Windows.Forms.TextBox txtMeterSerialNumber;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.DateTimePicker dtpPeriodSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDebit;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbTransfer;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblTotalPagado;
        private System.Windows.Forms.Label lblTotalPendiente;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Label lblAmountPad;
        private System.Windows.Forms.Label lblPendingPaid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMount;
    }
}