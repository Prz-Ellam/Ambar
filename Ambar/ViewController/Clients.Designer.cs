namespace Ambar.ViewController
{
    partial class Clients
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtFatherLastName = new System.Windows.Forms.TextBox();
            this.txtMotherLastName = new System.Windows.Forms.TextBox();
            this.txtCURP = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblClientes = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbEmails = new System.Windows.Forms.ComboBox();
            this.lbDisableClients = new System.Windows.Forms.ListBox();
            this.txtDisable = new System.Windows.Forms.TextBox();
            this.btnEnabling = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.dtgEmails = new System.Windows.Forms.DataGridView();
            this.Emails2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbWarningIcon = new System.Windows.Forms.PictureBox();
            this.Emails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotherLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatherLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgClients = new System.Windows.Forms.DataGridView();
            this.lblBlockedClients = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClients)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(184, 410);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 41);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "ACEPTAR";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(184, 81);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFirstName.MaxLength = 30;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(430, 23);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtFatherLastName
            // 
            this.txtFatherLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherLastName.Location = new System.Drawing.Point(184, 112);
            this.txtFatherLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFatherLastName.MaxLength = 30;
            this.txtFatherLastName.Name = "txtFatherLastName";
            this.txtFatherLastName.Size = new System.Drawing.Size(430, 23);
            this.txtFatherLastName.TabIndex = 2;
            // 
            // txtMotherLastName
            // 
            this.txtMotherLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotherLastName.Location = new System.Drawing.Point(184, 143);
            this.txtMotherLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMotherLastName.MaxLength = 30;
            this.txtMotherLastName.Name = "txtMotherLastName";
            this.txtMotherLastName.Size = new System.Drawing.Size(430, 23);
            this.txtMotherLastName.TabIndex = 3;
            // 
            // txtCURP
            // 
            this.txtCURP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCURP.Location = new System.Drawing.Point(184, 205);
            this.txtCURP.Margin = new System.Windows.Forms.Padding(2);
            this.txtCURP.MaxLength = 30;
            this.txtCURP.Name = "txtCURP";
            this.txtCURP.Size = new System.Drawing.Size(430, 23);
            this.txtCURP.TabIndex = 5;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(184, 236);
            this.dtpDateOfBirth.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(199, 23);
            this.dtpDateOfBirth.TabIndex = 6;
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Femenino",
            "Masculino",
            "Otro",
            "Prefiero no decir"});
            this.cbGender.Location = new System.Drawing.Point(184, 266);
            this.cbGender.Margin = new System.Windows.Forms.Padding(2);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(199, 25);
            this.cbGender.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Location = new System.Drawing.Point(86, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre(s):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label2.Location = new System.Drawing.Point(46, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Apellido Paterno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label3.Location = new System.Drawing.Point(42, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Apellido Materno:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label4.Location = new System.Drawing.Point(112, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Emails:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label5.Location = new System.Drawing.Point(118, 208);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "CURP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label6.Location = new System.Drawing.Point(16, 240);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fecha de Nacimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label7.Location = new System.Drawing.Point(107, 268);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Género:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(184, 297);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.MaxLength = 30;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(430, 23);
            this.txtUsername.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(184, 328);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 30;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(430, 23);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label8.Location = new System.Drawing.Point(106, 300);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Usuario:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label9.Location = new System.Drawing.Point(80, 331);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Contraseña:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label10.Location = new System.Drawing.Point(10, 362);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Confirmar Contraseña:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(184, 359);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmPassword.MaxLength = 30;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(430, 23);
            this.txtConfirmPassword.TabIndex = 10;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblClientes.Location = new System.Drawing.Point(15, 15);
            this.lblClientes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(148, 31);
            this.lblClientes.TabIndex = 21;
            this.lblClientes.Text = "CLIENTES";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(342, 410);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 41);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Text = "ACTUALIZAR";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(500, 410);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 41);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "BORRAR";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbEmails
            // 
            this.cbEmails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmails.FormattingEnabled = true;
            this.cbEmails.Location = new System.Drawing.Point(184, 174);
            this.cbEmails.Margin = new System.Windows.Forms.Padding(2);
            this.cbEmails.Name = "cbEmails";
            this.cbEmails.Size = new System.Drawing.Size(430, 25);
            this.cbEmails.TabIndex = 4;
            this.cbEmails.SelectedIndexChanged += new System.EventHandler(this.cbEmails_SelectedIndexChanged);
            this.cbEmails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEmails_KeyDown);
            // 
            // lbDisableClients
            // 
            this.lbDisableClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbDisableClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisableClients.FormattingEnabled = true;
            this.lbDisableClients.ItemHeight = 17;
            this.lbDisableClients.Location = new System.Drawing.Point(669, 81);
            this.lbDisableClients.Margin = new System.Windows.Forms.Padding(2);
            this.lbDisableClients.Name = "lbDisableClients";
            this.lbDisableClients.Size = new System.Drawing.Size(188, 408);
            this.lbDisableClients.TabIndex = 31;
            this.lbDisableClients.SelectedIndexChanged += new System.EventHandler(this.lbDisableClients_SelectedIndexChanged);
            // 
            // txtDisable
            // 
            this.txtDisable.Enabled = false;
            this.txtDisable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisable.Location = new System.Drawing.Point(669, 513);
            this.txtDisable.Margin = new System.Windows.Forms.Padding(2);
            this.txtDisable.Name = "txtDisable";
            this.txtDisable.ReadOnly = true;
            this.txtDisable.Size = new System.Drawing.Size(188, 23);
            this.txtDisable.TabIndex = 30;
            // 
            // btnEnabling
            // 
            this.btnEnabling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.btnEnabling.Enabled = false;
            this.btnEnabling.FlatAppearance.BorderSize = 0;
            this.btnEnabling.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.btnEnabling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnabling.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnabling.ForeColor = System.Drawing.Color.White;
            this.btnEnabling.Location = new System.Drawing.Point(702, 553);
            this.btnEnabling.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnabling.Name = "btnEnabling";
            this.btnEnabling.Size = new System.Drawing.Size(112, 41);
            this.btnEnabling.TabIndex = 29;
            this.btnEnabling.Text = "HABILITAR";
            this.btnEnabling.UseVisualStyleBackColor = false;
            this.btnEnabling.Click += new System.EventHandler(this.btnEnabling_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblError.Location = new System.Drawing.Point(213, 56);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(84, 15);
            this.lblError.TabIndex = 33;
            this.lblError.Text = "ERROR TEXT";
            this.lblError.Visible = false;
            // 
            // dtgEmails
            // 
            this.dtgEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Emails2});
            this.dtgEmails.Location = new System.Drawing.Point(454, 470);
            this.dtgEmails.Margin = new System.Windows.Forms.Padding(2);
            this.dtgEmails.Name = "dtgEmails";
            this.dtgEmails.ReadOnly = true;
            this.dtgEmails.RowHeadersWidth = 51;
            this.dtgEmails.RowTemplate.Height = 24;
            this.dtgEmails.Size = new System.Drawing.Size(159, 130);
            this.dtgEmails.TabIndex = 34;
            // 
            // Emails2
            // 
            this.Emails2.DataPropertyName = "EMAILS";
            this.Emails2.HeaderText = "Emails";
            this.Emails2.MinimumWidth = 6;
            this.Emails2.Name = "Emails2";
            this.Emails2.ReadOnly = true;
            this.Emails2.Width = 125;
            // 
            // pbWarningIcon
            // 
            this.pbWarningIcon.Image = global::Ambar.Properties.Resources.Warning_Icon1;
            this.pbWarningIcon.Location = new System.Drawing.Point(184, 51);
            this.pbWarningIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pbWarningIcon.Name = "pbWarningIcon";
            this.pbWarningIcon.Size = new System.Drawing.Size(22, 24);
            this.pbWarningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWarningIcon.TabIndex = 32;
            this.pbWarningIcon.TabStop = false;
            this.pbWarningIcon.Visible = false;
            // 
            // Emails
            // 
            this.Emails.DataPropertyName = "EMAILS";
            this.Emails.HeaderText = "Emails";
            this.Emails.MinimumWidth = 6;
            this.Emails.Name = "Emails";
            this.Emails.ReadOnly = true;
            this.Emails.Width = 125;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "GENDER";
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 125;
            // 
            // CURP
            // 
            this.CURP.DataPropertyName = "CURP";
            this.CURP.HeaderText = "CURP";
            this.CURP.MinimumWidth = 6;
            this.CURP.Name = "CURP";
            this.CURP.ReadOnly = true;
            this.CURP.Width = 125;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.DataPropertyName = "DATE_OF_BIRTH";
            this.DateOfBirth.HeaderText = "Date of Birth";
            this.DateOfBirth.MinimumWidth = 6;
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            this.DateOfBirth.Width = 125;
            // 
            // MotherLastName
            // 
            this.MotherLastName.DataPropertyName = "MOTHER_LAST_NAME";
            this.MotherLastName.HeaderText = "Mother Last Name";
            this.MotherLastName.MinimumWidth = 6;
            this.MotherLastName.Name = "MotherLastName";
            this.MotherLastName.ReadOnly = true;
            this.MotherLastName.Width = 125;
            // 
            // FatherLastName
            // 
            this.FatherLastName.DataPropertyName = "FATHER_LAST_NAME";
            this.FatherLastName.HeaderText = "Father Last Name";
            this.FatherLastName.MinimumWidth = 6;
            this.FatherLastName.Name = "FatherLastName";
            this.FatherLastName.ReadOnly = true;
            this.FatherLastName.Width = 125;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FIRST_NAME";
            this.FirstName.HeaderText = "First Name";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 125;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "PASSWORD";
            this.Password.HeaderText = "Password";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 125;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "USER_NAME";
            this.Username.HeaderText = "Username";
            this.Username.MinimumWidth = 6;
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Width = 125;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "USER_ID";
            this.UserID.HeaderText = "ID";
            this.UserID.MinimumWidth = 6;
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Width = 125;
            // 
            // dtgClients
            // 
            this.dtgClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.Username,
            this.Password,
            this.FirstName,
            this.FatherLastName,
            this.MotherLastName,
            this.DateOfBirth,
            this.CURP,
            this.Gender,
            this.Emails});
            this.dtgClients.Location = new System.Drawing.Point(14, 470);
            this.dtgClients.Margin = new System.Windows.Forms.Padding(2);
            this.dtgClients.Name = "dtgClients";
            this.dtgClients.ReadOnly = true;
            this.dtgClients.RowHeadersWidth = 51;
            this.dtgClients.RowTemplate.Height = 24;
            this.dtgClients.Size = new System.Drawing.Size(436, 130);
            this.dtgClients.TabIndex = 22;
            this.dtgClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgClients_CellDoubleClick);
            // 
            // lblBlockedClients
            // 
            this.lblBlockedClients.AutoSize = true;
            this.lblBlockedClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockedClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lblBlockedClients.Location = new System.Drawing.Point(659, 51);
            this.lblBlockedClients.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlockedClients.Name = "lblBlockedClients";
            this.lblBlockedClients.Size = new System.Drawing.Size(204, 20);
            this.lblBlockedClients.TabIndex = 35;
            this.lblBlockedClients.Text = "CLIENTES BLOQUEADOS";
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(926, 630);
            this.Controls.Add(this.lblBlockedClients);
            this.Controls.Add(this.dtgEmails);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pbWarningIcon);
            this.Controls.Add(this.lbDisableClients);
            this.Controls.Add(this.txtDisable);
            this.Controls.Add(this.btnEnabling);
            this.Controls.Add(this.cbEmails);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dtgClients);
            this.Controls.Add(this.lblClientes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.txtCURP);
            this.Controls.Add(this.txtMotherLastName);
            this.Controls.Add(this.txtFatherLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Clients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Clients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtFatherLastName;
        private System.Windows.Forms.TextBox txtMotherLastName;
        private System.Windows.Forms.TextBox txtCURP;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbEmails;
        private System.Windows.Forms.ListBox lbDisableClients;
        private System.Windows.Forms.TextBox txtDisable;
        private System.Windows.Forms.Button btnEnabling;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox pbWarningIcon;
        private System.Windows.Forms.DataGridView dtgEmails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emails2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotherLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatherLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridView dtgClients;
        private System.Windows.Forms.Label lblBlockedClients;
    }
}