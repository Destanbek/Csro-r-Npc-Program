// Decompiled with JetBrains decompiler
// Type: SQLGuncelle.Uyari
// Assembly: SQLGuncelle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C2A50463-AE0A-4D2F-A7D8-657DE9090FEE
// Assembly location: C:\Users\Admin\Desktop\VSRO - Nazif Npc\SQLGuncelle.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SQLGuncelle
{
    public class Uyari : UserControl
    {
        private IContainer components = (IContainer)null;
        public Label lblUyari;
        public Button btnEvet;
        public Button btnHayir;
        public Bilgi bilgi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUyari = new System.Windows.Forms.Label();
            this.btnEvet = new System.Windows.Forms.Button();
            this.btnHayir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUyari
            // 
            this.lblUyari.AutoSize = true;
            this.lblUyari.BackColor = System.Drawing.Color.Transparent;
            this.lblUyari.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUyari.ForeColor = System.Drawing.Color.White;
            this.lblUyari.Location = new System.Drawing.Point(7, 45);
            this.lblUyari.Name = "lblUyari";
            this.lblUyari.Size = new System.Drawing.Size(57, 20);
            this.lblUyari.TabIndex = 0;
            this.lblUyari.Text = "label1";
            // 
            // btnEvet
            // 
            this.btnEvet.BackColor = System.Drawing.Color.Lavender;
            this.btnEvet.ForeColor = System.Drawing.Color.Black;
            this.btnEvet.Location = new System.Drawing.Point(167, 135);
            this.btnEvet.Name = "btnEvet";
            this.btnEvet.Size = new System.Drawing.Size(101, 31);
            this.btnEvet.TabIndex = 1;
            this.btnEvet.Text = "EVET";
            this.btnEvet.UseVisualStyleBackColor = false;
            this.btnEvet.Click += new System.EventHandler(this.btnEvet_Click);
            // 
            // btnHayir
            // 
            this.btnHayir.BackColor = System.Drawing.Color.Lavender;
            this.btnHayir.ForeColor = System.Drawing.Color.Black;
            this.btnHayir.Location = new System.Drawing.Point(277, 135);
            this.btnHayir.Name = "btnHayir";
            this.btnHayir.Size = new System.Drawing.Size(101, 31);
            this.btnHayir.TabIndex = 1;
            this.btnHayir.Text = "HAYIR";
            this.btnHayir.UseVisualStyleBackColor = false;
            this.btnHayir.Click += new System.EventHandler(this.btnHayir_Click);
            // 
            // Uyari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnHayir);
            this.Controls.Add(this.btnEvet);
            this.Controls.Add(this.lblUyari);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "Uyari";
            this.Size = new System.Drawing.Size(530, 186);
            this.Load += new System.EventHandler(this.Uyari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Uyari() => this.InitializeComponent();

        private void Uyari_Load(object sender, EventArgs e) => this.bilgi.Text = "Uyarı";

        private void btnEvet_Click(object sender, EventArgs e) => this.bilgi.EvetTiklandi();

        private void btnHayir_Click(object sender, EventArgs e) => this.bilgi.Close();
    }
}
