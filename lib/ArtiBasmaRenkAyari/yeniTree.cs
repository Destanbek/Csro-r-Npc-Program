// Decompiled with JetBrains decompiler
// Type: ArtiBasmaRenkAyari.yeniTree
// Assembly: ArtiBasmaRenkAyari, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4781CAE8-CCED-42E3-84C7-CC751066D213
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\ArtiBasmaRenkAyari.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ArtiBasmaRenkAyari
{
  public class yeniTree : Form
  {
    internal DataTable tablo;
    internal ArtiRenkleri frm;
    private string resim = "";
    private string renk1 = "";
    private string renk2 = "";
    private bool btnAcma = false;
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private Label label3;
    private Panel pnlColor1;
    private Panel pnlColor2;
    private PictureBox picMask;
    private Label label4;
    private Button btnKaydet;
    private MaskedTextBox txtArti;

    public yeniTree() => this.InitializeComponent();

    private void yeniTree_Load(object sender, EventArgs e) => this.txtArti.Focus();

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      if (!(this.txtArti.Text != ""))
        return;
      try
      {
        int int16 = (int) Convert.ToInt16(this.txtArti.Text);
        bool flag = false;
        foreach (DataRow row in (InternalDataCollectionBase) this.tablo.Rows)
        {
          if (row[1].ToString() == int16.ToString())
          {
            flag = true;
            int num = (int) MessageBox.Show("Bu Değer Mevcut. Lütfen Başka Bir Değer Girin...");
            break;
          }
        }
        if (!flag)
        {
          if (this.pnlColor1.BackColor != Color.Transparent)
          {
            if (this.pnlColor2.BackColor != Color.Transparent)
            {
              if (this.picMask.Image != null)
              {
                ArrayList arrayList = new ArrayList();
                arrayList.Add((object) "1");
                arrayList.Add((object) int16);
                arrayList.Add((object) "0.005000,-0.005000");
                arrayList.Add((object) ("prim\\mtrl\\itemoption\\" + this.resim.Replace(".PNG", ".ddj")));
                arrayList.Add((object) "5");
                arrayList.Add((object) "7");
                arrayList.Add((object) this.renk1);
                arrayList.Add((object) this.renk2);
                arrayList.Add((object) "1000");
                arrayList.Add((object) "0");
                DataRow row = this.tablo.NewRow();
                for (int index = 0; index < arrayList.Count; ++index)
                  row[index] = arrayList[index];
                this.tablo.Rows.Add(row);
                this.frm.Tablo = this.tablo;
                this.frm.TreeDoldur();
                this.btnAcma = true;
                this.Close();
              }
              else
              {
                int num1 = (int) MessageBox.Show("Lütfen Maskelemeyi Seçin");
              }
            }
            else
            {
              int num2 = (int) MessageBox.Show("Lütfen İkinci Rengi Girin");
            }
          }
          else
          {
            int num3 = (int) MessageBox.Show("Lütfen Birinci Rengi Girin");
          }
        }
      }
      catch
      {
        int num = (int) MessageBox.Show("Lütfen Sadece Rakam Girin");
      }
    }

    private void pnlColor1_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      if (colorDialog.ShowDialog() != DialogResult.OK)
        return;
      this.pnlColor1.BackColor = colorDialog.Color;
      object[] objArray = new object[5];
      Color color = colorDialog.Color;
      objArray[0] = (object) color.R;
      objArray[1] = (object) ",";
      color = colorDialog.Color;
      objArray[2] = (object) color.G;
      objArray[3] = (object) ",";
      color = colorDialog.Color;
      objArray[4] = (object) color.B;
      this.renk1 = renkCevir.SilkroadRenk(string.Concat(objArray));
    }

    private void pnlColor2_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      if (colorDialog.ShowDialog() != DialogResult.OK)
        return;
      this.pnlColor2.BackColor = colorDialog.Color;
      object[] objArray = new object[5];
      Color color = colorDialog.Color;
      objArray[0] = (object) color.R;
      objArray[1] = (object) ",";
      color = colorDialog.Color;
      objArray[2] = (object) color.G;
      objArray[3] = (object) ",";
      color = colorDialog.Color;
      objArray[4] = (object) color.B;
      this.renk2 = renkCevir.SilkroadRenk(string.Concat(objArray));
    }

    private void picMask_Click(object sender, EventArgs e)
    {
      int num = (int) new maske() { yTre = this }.ShowDialog();
    }

    internal void ResimYukle(string resim, string dizin)
    {
      this.picMask.Image = (Image) new Bitmap((Image) new Bitmap(dizin + "\\" + resim), 100, 100);
      this.resim = resim;
      this.picMask.SizeMode = PictureBoxSizeMode.StretchImage;
    }

    private void yeniTree_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.btnAcma)
        return;
      this.frm.kayitKontrol();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yeniTree));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlColor1 = new System.Windows.Forms.Panel();
            this.pnlColor2 = new System.Windows.Forms.Panel();
            this.picMask = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtArti = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMask)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "+ Değerini Giriniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Birinci Renk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(101, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "İkinci Renk";
            // 
            // pnlColor1
            // 
            this.pnlColor1.BackColor = System.Drawing.Color.LightGray;
            this.pnlColor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlColor1.Location = new System.Drawing.Point(15, 65);
            this.pnlColor1.Name = "pnlColor1";
            this.pnlColor1.Size = new System.Drawing.Size(61, 58);
            this.pnlColor1.TabIndex = 3;
            this.pnlColor1.Click += new System.EventHandler(this.pnlColor1_Click);
            // 
            // pnlColor2
            // 
            this.pnlColor2.BackColor = System.Drawing.Color.LightGray;
            this.pnlColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlColor2.Location = new System.Drawing.Point(103, 65);
            this.pnlColor2.Name = "pnlColor2";
            this.pnlColor2.Size = new System.Drawing.Size(61, 58);
            this.pnlColor2.TabIndex = 3;
            this.pnlColor2.Click += new System.EventHandler(this.pnlColor2_Click);
            // 
            // picMask
            // 
            this.picMask.BackColor = System.Drawing.Color.LightGray;
            this.picMask.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMask.Location = new System.Drawing.Point(13, 161);
            this.picMask.Name = "picMask";
            this.picMask.Size = new System.Drawing.Size(100, 100);
            this.picMask.TabIndex = 4;
            this.picMask.TabStop = false;
            this.picMask.Click += new System.EventHandler(this.picMask_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Maskeyi Seçin";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Lavender;
            this.btnKaydet.ForeColor = System.Drawing.Color.Black;
            this.btnKaydet.Location = new System.Drawing.Point(119, 161);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 42);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtArti
            // 
            this.txtArti.Location = new System.Drawing.Point(103, 10);
            this.txtArti.Mask = "99";
            this.txtArti.Name = "txtArti";
            this.txtArti.Size = new System.Drawing.Size(31, 20);
            this.txtArti.TabIndex = 7;
            // 
            // yeniTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(196, 288);
            this.Controls.Add(this.txtArti);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picMask);
            this.Controls.Add(this.pnlColor2);
            this.Controls.Add(this.pnlColor1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "yeniTree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Renk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.yeniTree_FormClosing);
            this.Load += new System.EventHandler(this.yeniTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
