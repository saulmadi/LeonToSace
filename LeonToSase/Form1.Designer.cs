﻿namespace LeonToSase
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLeon = new System.Windows.Forms.TextBox();
            this.txtSace = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.rb4Parciales = new System.Windows.Forms.RadioButton();
            this.rb2Parciales = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione Excel del Leon Alvarado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione Excel del Sace";
            // 
            // txtLeon
            // 
            this.txtLeon.Enabled = false;
            this.txtLeon.Location = new System.Drawing.Point(240, 63);
            this.txtLeon.Name = "txtLeon";
            this.txtLeon.Size = new System.Drawing.Size(284, 20);
            this.txtLeon.TabIndex = 2;
            // 
            // txtSace
            // 
            this.txtSace.Enabled = false;
            this.txtSace.Location = new System.Drawing.Point(240, 102);
            this.txtSace.Name = "txtSace";
            this.txtSace.Size = new System.Drawing.Size(284, 20);
            this.txtSace.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(530, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(530, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(487, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "llenar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // rb4Parciales
            // 
            this.rb4Parciales.AutoSize = true;
            this.rb4Parciales.Checked = true;
            this.rb4Parciales.Location = new System.Drawing.Point(59, 151);
            this.rb4Parciales.Name = "rb4Parciales";
            this.rb4Parciales.Size = new System.Drawing.Size(77, 17);
            this.rb4Parciales.TabIndex = 7;
            this.rb4Parciales.TabStop = true;
            this.rb4Parciales.Text = "4 Parciales";
            this.rb4Parciales.UseVisualStyleBackColor = true;
            // 
            // rb2Parciales
            // 
            this.rb2Parciales.AutoSize = true;
            this.rb2Parciales.Location = new System.Drawing.Point(142, 151);
            this.rb2Parciales.Name = "rb2Parciales";
            this.rb2Parciales.Size = new System.Drawing.Size(77, 17);
            this.rb2Parciales.TabIndex = 8;
            this.rb2Parciales.Text = "2 Parciales";
            this.rb2Parciales.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 202);
            this.Controls.Add(this.rb2Parciales);
            this.Controls.Add(this.rb4Parciales);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSace);
            this.Controls.Add(this.txtLeon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Llenado Excel SACE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLeon;
        private System.Windows.Forms.TextBox txtSace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton rb4Parciales;
        private System.Windows.Forms.RadioButton rb2Parciales;
    }
}

