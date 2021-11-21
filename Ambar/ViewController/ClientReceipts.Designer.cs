
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lblReceipts = new System.Windows.Forms.Label();
            this.dtgContracts = new System.Windows.Forms.DataGridView();
            this.consumptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suburb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startPeriodDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMeterSerialNumber = new System.Windows.Forms.TextBox();
            this.btnPDF = new System.Windows.Forms.Button();
            this.dtpPeriod = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gpPaymentType = new System.Windows.Forms.GroupBox();
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
            this.btnMassivePaid = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMount = new System.Windows.Forms.NumericUpDown();
            this.ofnReceipt = new System.Windows.Forms.SaveFileDialog();
            this.ofnMassive = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dtgHistory = new System.Windows.Forms.DataGridView();
            this.paymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.chartHC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContracts)).BeginInit();
            this.gpPaymentType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHC)).BeginInit();
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
            this.dtgContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consumptionID,
            this.meterSerialNumber,
            this.serviceNumber,
            this.state,
            this.city,
            this.suburb,
            this.street,
            this.number,
            this.postalCode,
            this.service,
            this.startPeriodDate});
            this.dtgContracts.Location = new System.Drawing.Point(21, 65);
            this.dtgContracts.Name = "dtgContracts";
            this.dtgContracts.ReadOnly = true;
            this.dtgContracts.Size = new System.Drawing.Size(874, 218);
            this.dtgContracts.TabIndex = 23;
            this.dtgContracts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgContracts_CellDoubleClick);
            // 
            // consumptionID
            // 
            this.consumptionID.DataPropertyName = "CONTRACT_ID";
            this.consumptionID.HeaderText = "ID";
            this.consumptionID.Name = "consumptionID";
            this.consumptionID.ReadOnly = true;
            // 
            // meterSerialNumber
            // 
            this.meterSerialNumber.DataPropertyName = "METER_SERIAL_NUMBER";
            this.meterSerialNumber.HeaderText = "Número de Medidor";
            this.meterSerialNumber.Name = "meterSerialNumber";
            this.meterSerialNumber.ReadOnly = true;
            // 
            // serviceNumber
            // 
            this.serviceNumber.DataPropertyName = "SERVICE_NUMBER";
            this.serviceNumber.HeaderText = "Número de Servicio";
            this.serviceNumber.Name = "serviceNumber";
            this.serviceNumber.ReadOnly = true;
            // 
            // state
            // 
            this.state.DataPropertyName = "STATE";
            this.state.HeaderText = "Estado";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            // 
            // city
            // 
            this.city.DataPropertyName = "CITY";
            this.city.HeaderText = "Ciudad";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            // 
            // suburb
            // 
            this.suburb.DataPropertyName = "SUBURB";
            this.suburb.HeaderText = "Colonia";
            this.suburb.Name = "suburb";
            this.suburb.ReadOnly = true;
            // 
            // street
            // 
            this.street.DataPropertyName = "STREET";
            this.street.HeaderText = "Calle";
            this.street.Name = "street";
            this.street.ReadOnly = true;
            // 
            // number
            // 
            this.number.DataPropertyName = "NUMBER";
            this.number.HeaderText = "Número";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            // 
            // postalCode
            // 
            this.postalCode.DataPropertyName = "POSTAL_CODE";
            this.postalCode.HeaderText = "Código Postal";
            this.postalCode.Name = "postalCode";
            this.postalCode.ReadOnly = true;
            // 
            // service
            // 
            this.service.DataPropertyName = "SERVICE";
            this.service.HeaderText = "Servicio";
            this.service.Name = "service";
            this.service.ReadOnly = true;
            // 
            // startPeriodDate
            // 
            this.startPeriodDate.DataPropertyName = "START_PERIOD_DATE";
            this.startPeriodDate.HeaderText = "Inicio de Contrato";
            this.startPeriodDate.Name = "startPeriodDate";
            this.startPeriodDate.ReadOnly = true;
            // 
            // txtMeterSerialNumber
            // 
            this.txtMeterSerialNumber.Enabled = false;
            this.txtMeterSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtMeterSerialNumber.Location = new System.Drawing.Point(183, 310);
            this.txtMeterSerialNumber.MaxLength = 30;
            this.txtMeterSerialNumber.Name = "txtMeterSerialNumber";
            this.txtMeterSerialNumber.ReadOnly = true;
            this.txtMeterSerialNumber.Size = new System.Drawing.Size(226, 23);
            this.txtMeterSerialNumber.TabIndex = 24;
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnPDF.Enabled = false;
            this.btnPDF.FlatAppearance.BorderSize = 0;
            this.btnPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.ForeColor = System.Drawing.Color.White;
            this.btnPDF.Location = new System.Drawing.Point(26, 454);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(2);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(137, 74);
            this.btnPDF.TabIndex = 28;
            this.btnPDF.Text = "GENERAR RECIBO PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // dtpPeriod
            // 
            this.dtpPeriod.CustomFormat = "MMMM yyyy";
            this.dtpPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dtpPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriod.Location = new System.Drawing.Point(183, 340);
            this.dtpPeriod.Name = "dtpPeriod";
            this.dtpPeriod.ShowUpDown = true;
            this.dtpPeriod.Size = new System.Drawing.Size(226, 23);
            this.dtpPeriod.TabIndex = 30;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnSearch.Enabled = false;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(26, 389);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 52);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "BUSCAR";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gpPaymentType
            // 
            this.gpPaymentType.Controls.Add(this.rbTransfer);
            this.gpPaymentType.Controls.Add(this.rbCredit);
            this.gpPaymentType.Controls.Add(this.rbDebit);
            this.gpPaymentType.Controls.Add(this.rbCash);
            this.gpPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpPaymentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.gpPaymentType.Location = new System.Drawing.Point(679, 299);
            this.gpPaymentType.Name = "gpPaymentType";
            this.gpPaymentType.Size = new System.Drawing.Size(200, 142);
            this.gpPaymentType.TabIndex = 32;
            this.gpPaymentType.TabStop = false;
            this.gpPaymentType.Text = "Tipo de pago:";
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
            this.rbDebit.Text = "Tarjeta de debito";
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
            this.lblImporte.Location = new System.Drawing.Point(183, 398);
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
            this.lblTotalPagado.Location = new System.Drawing.Point(183, 430);
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
            this.lblTotalPendiente.Location = new System.Drawing.Point(183, 462);
            this.lblTotalPendiente.Name = "lblTotalPendiente";
            this.lblTotalPendiente.Size = new System.Drawing.Size(121, 16);
            this.lblTotalPendiente.TabIndex = 35;
            this.lblTotalPendiente.Text = "Total pendiente:";
            // 
            // btnPaid
            // 
            this.btnPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnPaid.Enabled = false;
            this.btnPaid.FlatAppearance.BorderSize = 0;
            this.btnPaid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaid.ForeColor = System.Drawing.Color.White;
            this.btnPaid.Location = new System.Drawing.Point(720, 490);
            this.btnPaid.Margin = new System.Windows.Forms.Padding(2);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(120, 45);
            this.btnPaid.TabIndex = 37;
            this.btnPaid.Text = "PAGAR";
            this.btnPaid.UseVisualStyleBackColor = false;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblImport.Location = new System.Drawing.Point(246, 398);
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
            this.lblAmountPad.Location = new System.Drawing.Point(295, 430);
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
            this.lblPendingPaid.Location = new System.Drawing.Point(310, 462);
            this.lblPendingPaid.Name = "lblPendingPaid";
            this.lblPendingPaid.Size = new System.Drawing.Size(17, 16);
            this.lblPendingPaid.TabIndex = 40;
            this.lblPendingPaid.Text = "...";
            // 
            // btnMassivePaid
            // 
            this.btnMassivePaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnMassivePaid.FlatAppearance.BorderSize = 0;
            this.btnMassivePaid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnMassivePaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMassivePaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMassivePaid.ForeColor = System.Drawing.Color.White;
            this.btnMassivePaid.Location = new System.Drawing.Point(720, 544);
            this.btnMassivePaid.Margin = new System.Windows.Forms.Padding(2);
            this.btnMassivePaid.Name = "btnMassivePaid";
            this.btnMassivePaid.Size = new System.Drawing.Size(120, 45);
            this.btnMassivePaid.TabIndex = 41;
            this.btnMassivePaid.Text = "PAGO MASIVO";
            this.btnMassivePaid.UseVisualStyleBackColor = false;
            this.btnMassivePaid.Click += new System.EventHandler(this.btnMassivePaid_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label4.Location = new System.Drawing.Point(75, 313);
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
            this.label5.Location = new System.Drawing.Point(23, 345);
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
            this.nudMount.Location = new System.Drawing.Point(679, 454);
            this.nudMount.Name = "nudMount";
            this.nudMount.Size = new System.Drawing.Size(200, 23);
            this.nudMount.TabIndex = 44;
            // 
            // ofnReceipt
            // 
            this.ofnReceipt.Filter = "PDF (*.pdf)|.pdf";
            // 
            // ofnMassive
            // 
            this.ofnMassive.Filter = "CSV (*.csv)|*.csv|XLSX (*.xlsx)|*.xlsx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Location = new System.Drawing.Point(183, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Estatus:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblStatus.Location = new System.Drawing.Point(248, 489);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(17, 16);
            this.lblStatus.TabIndex = 46;
            this.lblStatus.Text = "...";
            // 
            // dtgHistory
            // 
            this.dtgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paymentType,
            this.mount});
            this.dtgHistory.Location = new System.Drawing.Point(421, 307);
            this.dtgHistory.Name = "dtgHistory";
            this.dtgHistory.ReadOnly = true;
            this.dtgHistory.Size = new System.Drawing.Size(244, 170);
            this.dtgHistory.TabIndex = 47;
            // 
            // paymentType
            // 
            this.paymentType.DataPropertyName = "paymentType";
            this.paymentType.HeaderText = "Tipo de pago";
            this.paymentType.Name = "paymentType";
            this.paymentType.ReadOnly = true;
            // 
            // mount
            // 
            this.mount.DataPropertyName = "mount";
            this.mount.HeaderText = "Monto";
            this.mount.Name = "mount";
            this.mount.ReadOnly = true;
            // 
            // btnReceipt
            // 
            this.btnReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnReceipt.Enabled = false;
            this.btnReceipt.FlatAppearance.BorderSize = 0;
            this.btnReceipt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt.ForeColor = System.Drawing.Color.White;
            this.btnReceipt.Location = new System.Drawing.Point(26, 544);
            this.btnReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(137, 52);
            this.btnReceipt.TabIndex = 48;
            this.btnReceipt.Text = "VER RECIBO";
            this.btnReceipt.UseVisualStyleBackColor = false;
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            // 
            // chartHC
            // 
            chartArea1.Name = "ChartArea1";
            this.chartHC.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartHC.Legends.Add(legend1);
            this.chartHC.Location = new System.Drawing.Point(421, 490);
            this.chartHC.Name = "chartHC";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "HC";
            this.chartHC.Series.Add(series1);
            this.chartHC.Size = new System.Drawing.Size(244, 205);
            this.chartHC.TabIndex = 49;
            this.chartHC.Text = "chart1";
            title1.Name = "Historic Consumption";
            title1.Text = "Historic Consumption";
            this.chartHC.Titles.Add(title1);
            this.chartHC.Visible = false;
            // 
            // ClientReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(907, 752);
            this.Controls.Add(this.chartHC);
            this.Controls.Add(this.btnReceipt);
            this.Controls.Add(this.dtgHistory);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnMassivePaid);
            this.Controls.Add(this.lblPendingPaid);
            this.Controls.Add(this.lblAmountPad);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.btnPaid);
            this.Controls.Add(this.lblTotalPendiente);
            this.Controls.Add(this.lblTotalPagado);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.gpPaymentType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpPeriod);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.txtMeterSerialNumber);
            this.Controls.Add(this.dtgContracts);
            this.Controls.Add(this.lblReceipts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientReceipts";
            this.Text = "ClientReceipts";
            this.Load += new System.EventHandler(this.ClientReceipts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgContracts)).EndInit();
            this.gpPaymentType.ResumeLayout(false);
            this.gpPaymentType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReceipts;
        private System.Windows.Forms.DataGridView dtgContracts;
        private System.Windows.Forms.TextBox txtMeterSerialNumber;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.DateTimePicker dtpPeriod;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gpPaymentType;
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
        private System.Windows.Forms.Button btnMassivePaid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMount;
        private System.Windows.Forms.SaveFileDialog ofnReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumptionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn suburb;
        private System.Windows.Forms.DataGridViewTextBoxColumn street;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn postalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn service;
        private System.Windows.Forms.DataGridViewTextBoxColumn startPeriodDate;
        private System.Windows.Forms.OpenFileDialog ofnMassive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dtgHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn mount;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHC;
    }
}