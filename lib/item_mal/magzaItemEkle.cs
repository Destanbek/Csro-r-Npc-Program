// Decompiled with JetBrains decompiler
// Type: item_mal.magzaItemEkle
// Assembly: item_mal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 19D66908-CAEF-4A5D-8729-25B953C4A897
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\item_mal.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace item_mal
{
  public class magzaItemEkle : Form
  {
    internal DataTable _RefObjCommon;
    internal DataTable _RefObjItem;
    internal magza mgz;
    private string resim = "";
    private string Dur_L = "";
    private IContainer components = (IContainer) null;
    private GroupBox grpYeniItem;
    private GroupBox groupBox2;
    private Button btnTumItem;
    private TextBox txtTumItem;
    private Label label4;
    private PictureBox img;
    private GroupBox groupBox3;
    private ListBox listBulunan;
    private Button btnEkle;
    private GroupBox grpFiyat;
    private TextBox txtGif;
    private Label label3;
    private TextBox txtPoint;
    private Label label2;
    private TextBox txtSilk;
    private Label label1;
    private ProgressBar pro;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem kopyalaToolStripMenuItem;

    public magzaItemEkle() => this.InitializeComponent();

    private void magzaItemEkle_Load(object sender, EventArgs e)
    {
      this.btnEkle.Enabled = false;
      this.img.Hide();
      this.grpFiyat.Enabled = false;
      this.pro.Visible = false;
      this.pro.Maximum = 100;
      this.pro.Minimum = 0;
      this.pro.Step = 10;
    }

    private void btnTumItem_Click(object sender, EventArgs e)
    {
      if (this.img.Image != null)
        this.img.Hide();
      this.listBulunan.Items.Clear();
      int num1 = 1;
      this.pro.Visible = true;
      if (this.txtTumItem.Text == "")
      {
        foreach (DataRow row in (InternalDataCollectionBase) this._RefObjCommon.Rows)
        {
          if (row["Service"].ToString() == "1" && row["CodeName128"].ToString().IndexOf("ITEM_", 0) > -1)
            this.listBulunan.Items.Add(row["CodeName128"]);
          this.pro.Value = num1 * 100 / this._RefObjCommon.Rows.Count;
          ++num1;
          Application.DoEvents();
        }
      }
      else
      {
        foreach (DataRow row in (InternalDataCollectionBase) this._RefObjCommon.Rows)
        {
          if (row["Service"].ToString() == "1" && row["CodeName128"].ToString().IndexOf("ITEM_", 0) > -1 && row["CodeName128"].ToString().IndexOf(this.txtTumItem.Text, 0) > -1)
            this.listBulunan.Items.Add(row["CodeName128"]);
          this.pro.Value = num1 * 100 / this._RefObjCommon.Rows.Count;
          ++num1;
          Application.DoEvents();
        }
      }
      if (this.listBulunan.Items.Count > 0)
      {
        int num2 = (int) MessageBox.Show("Toplam" + (object) this.listBulunan.Items.Count + "Sonuç Bulundu...");
      }
      else
        this.listBulunan.Items.Add((object)"İTEM BULUNAMADI");
      this.pro.Visible = false;
    }

    private void listBulunan_Click(object sender, EventArgs e)
    {
      if (!(this.listBulunan.Text != "") || !(this.listBulunan.Text != "İTEM BULUNAMADI"))
        return;
      try
      {
        this.img.Show();
        this.grpFiyat.Enabled = true;
        string str1 = "";
        foreach (DataRow row in (InternalDataCollectionBase) this._RefObjCommon.Rows)
        {
          if (row["CodeName128"].ToString() == this.listBulunan.Text)
          {
            this.resim = row["AssocFileIcon128"].ToString();
            str1 = row["Link"].ToString();
            break;
          }
        }
        foreach (DataRow row in (InternalDataCollectionBase) this._RefObjItem.Rows)
        {
          if (row["ID"].ToString() == str1)
          {
            this.Dur_L = row["Dur_L"].ToString();
            if (this.listBulunan.Text.IndexOf("_RING_") != -1)
            {
              this.Dur_L = "1";
              break;
            }
            if (this.listBulunan.Text.IndexOf("_EARRING_") != -1)
            {
              this.Dur_L = "1";
              break;
            }
            if (this.listBulunan.Text.IndexOf("_NECKLACE_") != -1)
            {
              this.Dur_L = "1";
              break;
            }
            break;
          }
        }
        string str2 = Path.GetDirectoryName(Application.ExecutablePath) + "\\icon\\";
        this.img.Image = !File.Exists(str2 + this.resim.Replace(".ddj", ".PNG")) ? (Image) new Bitmap((Image) new Bitmap(str2 + "icon_default.PNG"), 64, 64) : (Image) new Bitmap((Image) new Bitmap(str2 + this.resim.Replace(".ddj", ".PNG")), 64, 64);
      }
      catch
      {
        this.img.Hide();
      }
    }

    private void btnEkle_Click(object sender, EventArgs e)
    {
      if (this.listBulunan.Text != "" && this.listBulunan.Text != "İTEM BULUNAMADI")
      {
        ArrayList arrayList = this.mgz.ItemKontrolu(this.listBulunan.Text);
        if ((bool) arrayList[0])
        {
          int num1 = (int) MessageBox.Show("Bu item Satışlarda mevcut.\nSatıldığı Yer : " + arrayList[2]);
        }
        else if ((bool) arrayList[1])
        {
          int num2 = (int) MessageBox.Show("Bu İtem Satışlardan Daha Önce Kaldırılmış.\nLütfen \"SQL DÜZENLE\" Bölümünde Sql'li Düzenlediktensonre Tekrar Deneyin... ");
        }
        else if (this.txtGif.Text != "" || this.txtPoint.Text != "" || this.txtSilk.Text != "")
        {
          this.FiyatKontrol();
          if (this.mgz.itemEkle(this.listBulunan.Text, this.resim, new string[3]
          {
            this.txtSilk.Text,
            this.txtPoint.Text,
            this.txtGif.Text
          }, this.Dur_L))
          {
            this.mgz.islem = true;
            this.mgz.islemTamamlandi();
            this.Close();
          }
          else
          {
            int num3 = (int) MessageBox.Show("Ekleme İşleminde Hata Oluştu");
          }
        }
        else
        {
          int num4 = (int) MessageBox.Show("Satış Fiyatlarını Yazmadınız....");
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Listeden İtem Seçmediniz..");
      }
    }

    private void FiyatKontrol()
    {
      if (this.txtSilk.Text == "")
        this.txtSilk.Text = "0";
      if (this.txtPoint.Text == "")
        this.txtPoint.Text = "0";
      if (!(this.txtGif.Text == ""))
        return;
      this.txtGif.Text = "0";
    }

    private void txtTumItem_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (new Regex("^[0-9a-zA-Z_\b]$").Match(e.KeyChar.ToString()).Success)
        return;
      e.Handled = true;
    }

    private void kopyalaToolStripMenuItem_Click_1(object sender, EventArgs e) => Clipboard.SetText(this.listBulunan.Text);

    private void txtSilk_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (new Regex("^[0-9\b]$").Match(e.KeyChar.ToString()).Success)
        return;
      e.Handled = true;
    }

    private void txtSilk_KeyUp(object sender, KeyEventArgs e)
    {
      if (this.txtGif.Text != "" || this.txtPoint.Text != "" || this.txtSilk.Text != "")
        this.btnEkle.Enabled = true;
      else
        this.btnEkle.Enabled = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.grpYeniItem = new System.Windows.Forms.GroupBox();
            this.pro = new System.Windows.Forms.ProgressBar();
            this.grpFiyat = new System.Windows.Forms.GroupBox();
            this.txtGif = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSilk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTumItem = new System.Windows.Forms.Button();
            this.txtTumItem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.img = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBulunan = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kopyalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpYeniItem.SuspendLayout();
            this.grpFiyat.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpYeniItem
            // 
            this.grpYeniItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.grpYeniItem.Controls.Add(this.pro);
            this.grpYeniItem.Controls.Add(this.grpFiyat);
            this.grpYeniItem.Controls.Add(this.btnEkle);
            this.grpYeniItem.Controls.Add(this.groupBox2);
            this.grpYeniItem.Controls.Add(this.label4);
            this.grpYeniItem.Controls.Add(this.img);
            this.grpYeniItem.Controls.Add(this.groupBox3);
            this.grpYeniItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpYeniItem.ForeColor = System.Drawing.Color.Yellow;
            this.grpYeniItem.Location = new System.Drawing.Point(0, 0);
            this.grpYeniItem.Name = "grpYeniItem";
            this.grpYeniItem.Size = new System.Drawing.Size(617, 409);
            this.grpYeniItem.TabIndex = 10;
            this.grpYeniItem.TabStop = false;
            this.grpYeniItem.Text = "İtem Ekle";
            // 
            // pro
            // 
            this.pro.Location = new System.Drawing.Point(457, 376);
            this.pro.Name = "pro";
            this.pro.Size = new System.Drawing.Size(155, 23);
            this.pro.TabIndex = 14;
            // 
            // grpFiyat
            // 
            this.grpFiyat.Controls.Add(this.txtGif);
            this.grpFiyat.Controls.Add(this.label3);
            this.grpFiyat.Controls.Add(this.txtPoint);
            this.grpFiyat.Controls.Add(this.label2);
            this.grpFiyat.Controls.Add(this.txtSilk);
            this.grpFiyat.Controls.Add(this.label1);
            this.grpFiyat.ForeColor = System.Drawing.Color.Yellow;
            this.grpFiyat.Location = new System.Drawing.Point(461, 163);
            this.grpFiyat.Name = "grpFiyat";
            this.grpFiyat.Size = new System.Drawing.Size(151, 99);
            this.grpFiyat.TabIndex = 13;
            this.grpFiyat.TabStop = false;
            this.grpFiyat.Text = "Satış Fiyatı";
            // 
            // txtGif
            // 
            this.txtGif.ForeColor = System.Drawing.Color.Black;
            this.txtGif.Location = new System.Drawing.Point(77, 70);
            this.txtGif.Name = "txtGif";
            this.txtGif.Size = new System.Drawing.Size(54, 20);
            this.txtGif.TabIndex = 4;
            this.txtGif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSilk_KeyPress);
            this.txtGif.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSilk_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gif Silk Fiyatı";
            // 
            // txtPoint
            // 
            this.txtPoint.ForeColor = System.Drawing.Color.Black;
            this.txtPoint.Location = new System.Drawing.Point(77, 44);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(54, 20);
            this.txtPoint.TabIndex = 3;
            this.txtPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSilk_KeyPress);
            this.txtPoint.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSilk_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Point Fiyatı";
            // 
            // txtSilk
            // 
            this.txtSilk.ForeColor = System.Drawing.Color.Black;
            this.txtSilk.Location = new System.Drawing.Point(77, 18);
            this.txtSilk.Name = "txtSilk";
            this.txtSilk.Size = new System.Drawing.Size(54, 20);
            this.txtSilk.TabIndex = 2;
            this.txtSilk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSilk_KeyPress);
            this.txtSilk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSilk_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Silk Fiyatı";
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.Lavender;
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(465, 268);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 52);
            this.btnEkle.TabIndex = 6;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox2.Controls.Add(this.btnTumItem);
            this.groupBox2.Controls.Add(this.txtTumItem);
            this.groupBox2.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox2.Location = new System.Drawing.Point(13, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 50);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tüm İtemleri Arama";
            // 
            // btnTumItem
            // 
            this.btnTumItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTumItem.Location = new System.Drawing.Point(394, 20);
            this.btnTumItem.Name = "btnTumItem";
            this.btnTumItem.Size = new System.Drawing.Size(39, 23);
            this.btnTumItem.TabIndex = 1;
            this.btnTumItem.Text = "Ara";
            this.btnTumItem.UseVisualStyleBackColor = false;
            this.btnTumItem.Click += new System.EventHandler(this.btnTumItem_Click);
            // 
            // txtTumItem
            // 
            this.txtTumItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTumItem.Location = new System.Drawing.Point(7, 20);
            this.txtTumItem.Name = "txtTumItem";
            this.txtTumItem.Size = new System.Drawing.Size(381, 20);
            this.txtTumItem.TabIndex = 0;
            this.txtTumItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTumItem_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "İtem Resmi";
            // 
            // img
            // 
            this.img.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.img.Location = new System.Drawing.Point(462, 93);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(64, 64);
            this.img.TabIndex = 3;
            this.img.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox3.Controls.Add(this.listBulunan);
            this.groupBox3.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox3.Location = new System.Drawing.Point(10, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(445, 330);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bulunan İtemler";
            // 
            // listBulunan
            // 
            this.listBulunan.BackColor = System.Drawing.Color.Lavender;
            this.listBulunan.ContextMenuStrip = this.contextMenuStrip1;
            this.listBulunan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBulunan.ForeColor = System.Drawing.Color.Black;
            this.listBulunan.FormattingEnabled = true;
            this.listBulunan.Location = new System.Drawing.Point(3, 16);
            this.listBulunan.Name = "listBulunan";
            this.listBulunan.ScrollAlwaysVisible = true;
            this.listBulunan.Size = new System.Drawing.Size(439, 311);
            this.listBulunan.TabIndex = 5;
            this.listBulunan.Click += new System.EventHandler(this.listBulunan_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopyalaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 26);
            // 
            // kopyalaToolStripMenuItem
            // 
            this.kopyalaToolStripMenuItem.Name = "kopyalaToolStripMenuItem";
            this.kopyalaToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.kopyalaToolStripMenuItem.Text = "Kopyala";
            this.kopyalaToolStripMenuItem.Click += new System.EventHandler(this.kopyalaToolStripMenuItem_Click_1);
            // 
            // magzaItemEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 409);
            this.Controls.Add(this.grpYeniItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "magzaItemEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İTEM EKLEME FORMU";
            this.Load += new System.EventHandler(this.magzaItemEkle_Load);
            this.grpYeniItem.ResumeLayout(false);
            this.grpYeniItem.PerformLayout();
            this.grpFiyat.ResumeLayout(false);
            this.grpFiyat.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

    }
  }
}
