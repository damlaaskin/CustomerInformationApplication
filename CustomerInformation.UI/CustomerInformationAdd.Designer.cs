
using System;

namespace CustomerInformation.UI
{
   public partial class CustomerInformation
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTCKN = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblBirthYear = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtBirthYear = new System.Windows.Forms.TextBox();
            this.Kaydet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTCKN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTCKN
            // 
            this.lblTCKN.AutoSize = true;
            this.lblTCKN.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTCKN.Location = new System.Drawing.Point(241, 67);
            this.lblTCKN.Name = "lblTCKN";
            this.lblTCKN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTCKN.Size = new System.Drawing.Size(45, 20);
            this.lblTCKN.TabIndex = 100;
            this.lblTCKN.Text = "TCKN";
            this.lblTCKN.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblFirstName.Location = new System.Drawing.Point(241, 112);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(28, 20);
            this.lblFirstName.TabIndex = 102;
            this.lblFirstName.Text = "Ad";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLastName.Location = new System.Drawing.Point(241, 174);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(50, 20);
            this.lblLastName.TabIndex = 103;
            this.lblLastName.Text = "Soyad";
            // 
            // lblBirthYear
            // 
            this.lblBirthYear.AutoSize = true;
            this.lblBirthYear.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBirthYear.Location = new System.Drawing.Point(231, 241);
            this.lblBirthYear.Name = "lblBirthYear";
            this.lblBirthYear.Size = new System.Drawing.Size(94, 20);
            this.lblBirthYear.TabIndex = 104;
            this.lblBirthYear.Text = "Doğum Tarih";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(383, 105);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(125, 27);
            this.txtFirstName.TabIndex = 105;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(383, 167);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(125, 27);
            this.txtLastName.TabIndex = 106;
            // 
            // txtBirthYear
            // 
            this.txtBirthYear.Location = new System.Drawing.Point(383, 234);
            this.txtBirthYear.Name = "txtBirthYear";
            this.txtBirthYear.Size = new System.Drawing.Size(125, 27);
            this.txtBirthYear.TabIndex = 107;
            // 
            // Kaydet
            // 
            this.Kaydet.AccessibleName = "KAYDET";
            this.Kaydet.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Kaydet.Location = new System.Drawing.Point(660, 340);
            this.Kaydet.Name = "Kaydet";
            this.Kaydet.Size = new System.Drawing.Size(94, 29);
            this.Kaydet.TabIndex = 109;
            this.Kaydet.Text = "Kaydet";
            this.Kaydet.UseVisualStyleBackColor = true;
            this.Kaydet.Click += new System.EventHandler(this.Kaydet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(241, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 34);
            this.label1.TabIndex = 110;
            this.label1.Text = "Müşteri Bilgileri Ekle";
            // 
            // txtTCKN
            // 
            this.txtTCKN.Location = new System.Drawing.Point(383, 67);
            this.txtTCKN.Name = "txtTCKN";
            this.txtTCKN.Size = new System.Drawing.Size(125, 27);
            this.txtTCKN.TabIndex = 105;
            this.txtTCKN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTCKN_KeyPress);
            // 
            // CustomerInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Kaydet);
            this.Controls.Add(this.txtBirthYear);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtTCKN);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblBirthYear);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblTCKN);
            this.Name = "CustomerInformation";
            this.Text = "CustomerInformationAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTCKN;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblBirthYear;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtBirthYear;
        private System.Windows.Forms.Button Kaydet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTCKN;
    }
}

