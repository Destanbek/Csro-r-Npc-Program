// Decompiled with JetBrains decompiler
// Type: UserKontrol.Bilgi1
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UserKontrol
{
  public class Bilgi1 : UserControl
  {
    public Uyari1 uyari;
    private IContainer components = (IContainer) null;
    private Label label1;
    private Button btnEvet;
        private GroupBox groupBox1;
        private Button btnHayir;

    public Bilgi1() => this.InitializeComponent();

    private void Bilgi_Load(object sender, EventArgs e)
    {
    }

    private void btnEvet_Click(object sender, EventArgs e)
    {
      this.uyari.kabul = true;
      this.uyari.gelen();
    }

    private void btnHayir_Click(object sender, EventArgs e)
    {
      this.uyari.kabul = false;
      this.uyari.gelen();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.btnEvet = new System.Windows.Forms.Button();
            this.btnHayir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql Data Güncellenecek Eminmisiniz";
            // 
            // btnEvet
            // 
            this.btnEvet.BackColor = System.Drawing.Color.Lavender;
            this.btnEvet.ForeColor = System.Drawing.Color.Black;
            this.btnEvet.Location = new System.Drawing.Point(123, 72);
            this.btnEvet.Name = "btnEvet";
            this.btnEvet.Size = new System.Drawing.Size(75, 32);
            this.btnEvet.TabIndex = 1;
            this.btnEvet.Text = "EVET";
            this.btnEvet.UseVisualStyleBackColor = false;
            this.btnEvet.Click += new System.EventHandler(this.btnEvet_Click);
            // 
            // btnHayir
            // 
            this.btnHayir.BackColor = System.Drawing.Color.Lavender;
            this.btnHayir.ForeColor = System.Drawing.Color.Black;
            this.btnHayir.Location = new System.Drawing.Point(249, 72);
            this.btnHayir.Name = "btnHayir";
            this.btnHayir.Size = new System.Drawing.Size(75, 32);
            this.btnHayir.TabIndex = 1;
            this.btnHayir.Text = "HAYIR";
            this.btnHayir.UseVisualStyleBackColor = false;
            this.btnHayir.Click += new System.EventHandler(this.btnHayir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnHayir);
            this.groupBox1.Controls.Add(this.btnEvet);
            this.groupBox1.Location = new System.Drawing.Point(15, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // Bilgi1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.groupBox1);
            this.Name = "Bilgi1";
            this.Size = new System.Drawing.Size(476, 159);
            this.Load += new System.EventHandler(this.Bilgi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

    }
  }
}

