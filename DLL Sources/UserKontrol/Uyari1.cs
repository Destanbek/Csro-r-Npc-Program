// Decompiled with JetBrains decompiler
// Type: UserKontrol.Uyari1
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Tablo;

namespace UserKontrol
{
  public class Uyari1 : Form
  {
    private IContainer components = (IContainer) null;
    public bool kabul = false;
    public DataTable[] tablolar;
    public dataSet ds;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Uyari1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(563, 262);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = this.Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Uyari1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uyari";
            this.Load += new System.EventHandler(this.Uyari_Load);
            this.ResumeLayout(false);

    }

    public Uyari1() => this.InitializeComponent();

    private void Uyari_Load(object sender, EventArgs e)
    {
      Bilgi1 bilgi1 = new Bilgi1();
      bilgi1.uyari = this;
      this.Size = bilgi1.Size;
      this.Text = "UYARI";
      this.Controls.Add((Control) bilgi1);
    }

    public void gelen()
    {
      if (this.kabul)
      {
        itemm itemm = new itemm();
        itemm.uyr = this;
        this.Text = "SQL Güncelleniyor";
        this.Size = itemm.Size;
        itemm.dataset = this.ds;
        itemm.tablo = this.tablolar;
        this.Controls.Clear();
        this.Controls.Add((Control) itemm);
      }
      else
        this.Close();
    }

    public void islemBitti()
    {
      bitiss bitiss = new bitiss();
      bitiss.uyr = this;
      this.Size = bitiss.Size;
      this.Text = "İşlem Sona Erdi";
      this.Controls.Clear();
      this.Controls.Add((Control) bitiss);
    }
  }
}
