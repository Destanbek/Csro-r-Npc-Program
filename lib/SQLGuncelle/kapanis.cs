// Decompiled with JetBrains decompiler
// Type: SQLGuncelle.kapanis
// Assembly: SQLGuncelle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F363998B-B3C3-4374-8084-DFE1249725CF
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\SQLGuncelle.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SQLGuncelle
{
    public class kapanis : UserControl
    {
        private IContainer components = (IContainer)null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnTamam;
        private GroupBox groupBox1;
        public Bilgi blg;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTamam = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "YAPILANLAR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "1-Database Güncellendi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(318, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "2-Medyaya Eklenecek Text Dosyaları Oluşturuldu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(41, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Çıkmak İçin Tamam Tuşunu Tıklayın.";
            // 
            // btnTamam
            // 
            this.btnTamam.BackColor = System.Drawing.Color.Lavender;
            this.btnTamam.ForeColor = System.Drawing.Color.Black;
            this.btnTamam.Location = new System.Drawing.Point(160, 131);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 34);
            this.btnTamam.TabIndex = 1;
            this.btnTamam.Text = "TAMAM";
            this.btnTamam.UseVisualStyleBackColor = false;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(20, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // kapanis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTamam);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "kapanis";
            this.Size = new System.Drawing.Size(424, 199);
            this.Load += new System.EventHandler(this.kapanis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        public kapanis() => this.InitializeComponent();

        private void btnTamam_Click(object sender, EventArgs e)
        {
            string str = Path.GetDirectoryName(Application.ExecutablePath) + "\\MedyayaEklenecekDosyalar";
            string environmentVariable = Environment.GetEnvironmentVariable("WINDIR");
            new Process()
            {
                StartInfo = {
          FileName = (environmentVariable + "\\explorer.exe"),
          Arguments = str
        }
            }.Start();
            this.blg.Close();
        }

        private void kapanis_Load(object sender, EventArgs e) => this.blg.Text = "Tebrikler!!! Başarıyla NPC Eklendi";
    }
}
