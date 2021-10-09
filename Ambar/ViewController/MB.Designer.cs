
namespace Ambar.ViewController
{
    partial class MB
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
            this.gradientPanel = new Ambar.Utils.GradientPanel();
            this.pbAmbar = new System.Windows.Forms.PictureBox();
            this.gradientPanel1 = new Ambar.Utils.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbAmbar)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel
            // 
            this.gradientPanel.angle = 0F;
            this.gradientPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel.first = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.gradientPanel.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel.Name = "gradientPanel";
            this.gradientPanel.second = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.gradientPanel.Size = new System.Drawing.Size(700, 100);
            this.gradientPanel.TabIndex = 1;
            // 
            // pbAmbar
            // 
            this.pbAmbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pbAmbar.Image = global::Ambar.Properties.Resources.Ambar_Logo;
            this.pbAmbar.Location = new System.Drawing.Point(12, 117);
            this.pbAmbar.Name = "pbAmbar";
            this.pbAmbar.Size = new System.Drawing.Size(174, 162);
            this.pbAmbar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAmbar.TabIndex = 14;
            this.pbAmbar.TabStop = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.angle = 360F;
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gradientPanel1.first = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
            this.gradientPanel1.Location = new System.Drawing.Point(0, 300);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.second = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(200)))), ((int)(((byte)(48)))));
            this.gradientPanel1.Size = new System.Drawing.Size(700, 100);
            this.gradientPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.label1.Location = new System.Drawing.Point(195, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "LA OPERACION SE REALIZO CORRECTAMENTE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.pbAmbar);
            this.Controls.Add(this.gradientPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBox";
            this.Text = "MessageBox";
            ((System.ComponentModel.ISupportInitialize)(this.pbAmbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.GradientPanel gradientPanel;
        private System.Windows.Forms.PictureBox pbAmbar;
        private Utils.GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
    }
}