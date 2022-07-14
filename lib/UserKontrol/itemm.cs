// Decompiled with JetBrains decompiler
// Type: UserKontrol.itemm
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Tablo;
using TxTDosyaOlustur;

namespace UserKontrol
{
  public class itemm : UserControl
  {
    private IContainer components = (IContainer) null;
    private Label lblUst;
    private ProgressBar proUst;
    private ProgressBar proAlt;
    private Label lblAlt;
    public Uyari1 uyr;
    public DataTable[] tablo;
    public dataSet dataset;
    private DataTable[] tbl = new DataTable[4];
    private string dizin = Path.GetDirectoryName(Application.ExecutablePath) + "\\KompleDegisecekTextDosyalari\\";

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.lblUst = new System.Windows.Forms.Label();
            this.proUst = new System.Windows.Forms.ProgressBar();
            this.proAlt = new System.Windows.Forms.ProgressBar();
            this.lblAlt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUst
            // 
            this.lblUst.AutoSize = true;
            this.lblUst.BackColor = System.Drawing.Color.Transparent;
            this.lblUst.ForeColor = System.Drawing.Color.White;
            this.lblUst.Location = new System.Drawing.Point(40, 33);
            this.lblUst.Name = "lblUst";
            this.lblUst.Size = new System.Drawing.Size(35, 13);
            this.lblUst.TabIndex = 0;
            this.lblUst.Text = "label1";
            // 
            // proUst
            // 
            this.proUst.ForeColor = System.Drawing.Color.Maroon;
            this.proUst.Location = new System.Drawing.Point(40, 50);
            this.proUst.Name = "proUst";
            this.proUst.Size = new System.Drawing.Size(471, 23);
            this.proUst.TabIndex = 1;
            // 
            // proAlt
            // 
            this.proAlt.ForeColor = System.Drawing.Color.Maroon;
            this.proAlt.Location = new System.Drawing.Point(40, 112);
            this.proAlt.Name = "proAlt";
            this.proAlt.Size = new System.Drawing.Size(471, 23);
            this.proAlt.TabIndex = 3;
            // 
            // lblAlt
            // 
            this.lblAlt.AutoSize = true;
            this.lblAlt.BackColor = System.Drawing.Color.Transparent;
            this.lblAlt.ForeColor = System.Drawing.Color.White;
            this.lblAlt.Location = new System.Drawing.Point(40, 95);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(35, 13);
            this.lblAlt.TabIndex = 2;
            this.lblAlt.Text = "label1";
            // 
            // itemm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.proAlt);
            this.Controls.Add(this.lblAlt);
            this.Controls.Add(this.proUst);
            this.Controls.Add(this.lblUst);
            this.Name = "itemm";
            this.Size = new System.Drawing.Size(565, 217);
            this.Load += new System.EventHandler(this.itemm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    public itemm() => this.InitializeComponent();

    private void itemm_Load(object sender, EventArgs e)
    {
      this.proUst.Minimum = 0;
      this.proUst.Step = 1;
      this.proAlt.Minimum = 0;
      this.proAlt.Step = 1;
      this.lblAlt.Text = "";
      this.lblUst.Text = "";
      this.islem();
    }

    private void islem()
    {
      this.lblAlt.Text = "SQL Güncelleniyor";
      this.proUst.Maximum = this.tablo.Length;
      this.proAlt.Maximum = 5;
      for (int index = 0; index < this.tablo.Length; ++index)
      {
        this.lblUst.Text = this.tablo[index].TableName + " Tablosu Güncelleniyor";
        this.tbl[index] = this.dataset.Update(this.tablo[index]);
        Thread.Sleep(500);
        Application.DoEvents();
        this.proUst.Value = index;
      }
      this.lblAlt.Text = "Medya için txt Dosyaları Oluşturuluyor";
      this.uyr.Text = "Text Dosyaları Oluşturuluyor";
      this.proAlt.Value = 1;
      string[] strArray = new string[4]
      {
        "refpackageitem.txt",
        "refpricepolicyofitem.txt",
        "refshopgoods.txt",
        "refscrapofpackageitem.txt"
      };
      this.proUst.Maximum = this.tbl.Length;
      for (int index = 0; index < this.tbl.Length; ++index)
      {
        TxT.TxTSil(this.dizin, strArray[index]);
        this.lblUst.Text = strArray[index] + " Text Dosyası Yazılıyor";
        this.proUst.Maximum = 100;
        int num1 = 0;
        foreach (DataRow row in (InternalDataCollectionBase) this.tbl[index].Rows)
        {
          string metin = "";
          if (this.tbl[index].TableName == "_RefShopGoods")
          {
            for (int columnIndex = 0; columnIndex < this.tbl[index].Columns.Count - 1; ++columnIndex)
              metin = metin + "\t" + row[columnIndex].ToString();
          }
          else if (this.tbl[index].TableName == "_RefPricePolicyOfItem")
          {
            for (int columnIndex = 0; columnIndex < this.tbl[index].Columns.Count - 1; ++columnIndex)
              metin = metin + "\t" + row[columnIndex].ToString();
          }
          else
          {
            for (int columnIndex = 0; columnIndex < this.tbl[index].Columns.Count; ++columnIndex)
              metin = metin + "\t" + row[columnIndex].ToString();
          }
          int num2 = metin.IndexOf("\t");
          if (num2 != -1)
            metin = metin.Substring(num2 + 1);
          TxT.TxTYaz1(metin, this.dizin, strArray[index]);
          ++num1;
          this.proUst.Value = num1 * 100 / this.tbl[index].Rows.Count;
          Application.DoEvents();
        }
        this.proAlt.Value = index + 2;
        Application.DoEvents();
      }
      Thread.Sleep(1000);
      this.uyr.islemBitti();
    }
  }
}
