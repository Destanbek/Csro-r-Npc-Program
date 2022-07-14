// Decompiled with JetBrains decompiler
// Type: UserKontrol.Ekle
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UserKontrol
{
  public class Ekle : Form
  {
    public itemEkleme ekle;
    public DataTable[] tablo;
    private string arananYer = "";
    private string resim = "";
    private string Dur_L = "";
    private string yol = Path.GetDirectoryName(Application.ExecutablePath) + "\\icon";
    private DataTable _RefPackageItem;
    private DataTable _RefPricePolicyOfItem;
    private DataTable _RefShopGoods;
    private DataTable _RefScrapOfPackageItem;
    private DataTable _RefObjCommon;
    private DataTable _RefObjItem;
    private IContainer components = (IContainer) null;
    private TextBox txtAra;
    private Button btnAra;
    private GroupBox grEkli;
    private GroupBox grEkliDegil;
    private TextBox txtAra1;
    private Button btnAra1;
    private GroupBox groupBox3;
    private ListBox listSonuc;
    private ContextMenuStrip sagTiklama;
    private ToolStripMenuItem kopyalaToolStripMenuItem;
    private PictureBox imgIcon;
    private Label label1;
    private Button btnEkle;

    public Ekle() => this.InitializeComponent();

    private void Ekle_Load(object sender, EventArgs e)
    {
      this._RefPackageItem = this.tablo[0];
      this._RefPricePolicyOfItem = this.tablo[1];
      this._RefShopGoods = this.tablo[2];
      this._RefScrapOfPackageItem = this.tablo[3];
      this._RefObjCommon = this.tablo[4];
      this._RefObjItem = this.tablo[5];
      this.imgIcon.Hide();
    }

    private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e) => Clipboard.SetText(this.listSonuc.Text);

    private void btnAra_Click(object sender, EventArgs e)
    {
      this.imgIcon.Hide();
      this.grEkli.Enabled = false;
      this.grEkliDegil.Enabled = false;
      this.listSonuc.Enabled = false;
      this.listSonuc.Items.Clear();
      this.arananYer = "Ekli";
      this.btnEkle.Enabled = false;
      bool flag = false;
      int num1 = 0;
      foreach (DataRow row in (InternalDataCollectionBase) this._RefPackageItem.Rows)
      {
        if (this.txtAra.Text == "")
        {
          this.listSonuc.Items.Add((object) row["CodeName128"].ToString());
          flag = true;
          ++num1;
        }
        else if (row["CodeName128"].ToString().IndexOf(this.txtAra.Text) != -1)
        {
          this.listSonuc.Items.Add((object) row["CodeName128"].ToString());
          flag = true;
          ++num1;
        }
      }
      if (!flag)
        this.listSonuc.Items.Add((object) "İTEM BULUNAMADI");
      int num2 = (int) MessageBox.Show("Arama Tamamlantı Toplam= " + (object) num1 + " Sonuç Bulundu");
      this.grEkli.Enabled = true;
      this.grEkliDegil.Enabled = true;
      this.listSonuc.Enabled = true;
    }

    private void btnAra1_Click(object sender, EventArgs e)
    {
      this.imgIcon.Hide();
      this.grEkli.Enabled = false;
      this.grEkliDegil.Enabled = false;
      this.listSonuc.Enabled = false;
      this.listSonuc.Items.Clear();
      this.arananYer = "Ekli Değil";
      this.btnEkle.Enabled = false;
      bool flag = false;
      int num1 = 0;
      foreach (DataRow row in (InternalDataCollectionBase) this._RefObjCommon.Rows)
      {
        if (this.txtAra1.Text == "")
        {
          if (row["CodeName128"].ToString().IndexOf("ITEM_") != -1 && row["Service"].ToString() == "1")
          {
            this.listSonuc.Items.Add((object) row["CodeName128"].ToString());
            flag = true;
            ++num1;
          }
        }
        else if (row["CodeName128"].ToString().IndexOf("ITEM_") != -1 && row["Service"].ToString() == "1" && row["CodeName128"].ToString().IndexOf(this.txtAra1.Text) != -1)
        {
          this.listSonuc.Items.Add((object) row["CodeName128"].ToString());
          ++num1;
          flag = true;
        }
        Application.DoEvents();
      }
      if (!flag)
        this.listSonuc.Items.Add((object) "İTEM BULUNAMADI");
      int num2 = (int) MessageBox.Show("Arama Tamamlantı Toplam= " + (object) num1 + " Sonuç Bulundu");
      this.grEkli.Enabled = true;
      this.grEkliDegil.Enabled = true;
      this.listSonuc.Enabled = true;
    }

    private void listSonuc_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.imgIcon.Show();
      if (this.arananYer == "Ekli")
      {
        foreach (DataRow row in (InternalDataCollectionBase) this._RefPackageItem.Rows)
        {
          if (row["CodeName128"].ToString() == this.listSonuc.Text)
          {
            this.resim = row["AssocFileIcon"].ToString();
            string str = this.yol + "\\" + this.resim.Split('.')[0] + ".PNG";
            if (File.Exists(str))
            {
              Bitmap bitmap = new Bitmap(Image.FromFile(str), 64, 64);
              this.imgIcon.SizeMode = PictureBoxSizeMode.StretchImage;
              this.imgIcon.Image = (Image) bitmap;
              break;
            }
            Bitmap bitmap1 = new Bitmap(Image.FromFile(this.yol + "\\icon_default.PNG"), 64, 64);
            this.imgIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            this.imgIcon.Image = (Image) bitmap1;
            break;
          }
        }
        string str1 = "";
        foreach (DataRow row in (InternalDataCollectionBase) this._RefObjCommon.Rows)
        {
          if (row["CodeName128"].ToString() == this.listSonuc.Text.Substring(8))
          {
            str1 = row["Link"].ToString();
            break;
          }
        }
        foreach (DataRow row in (InternalDataCollectionBase) this._RefObjItem.Rows)
        {
          if (row["ID"].ToString() == str1)
          {
            this.Dur_L = row["Dur_L"].ToString();
            if (this.listSonuc.Text.IndexOf("_RING_") != -1)
              this.Dur_L = "1";
            else if (this.listSonuc.Text.IndexOf("_EARRING_") != -1)
              this.Dur_L = "1";
            else if (this.listSonuc.Text.IndexOf("_NECKLACE_") != -1)
              this.Dur_L = "1";
            this.btnEkle.Enabled = true;
            break;
          }
        }
      }
      else
      {
        string str2 = "";
        bool flag = false;
        foreach (DataRow row in (InternalDataCollectionBase) this._RefPackageItem.Rows)
        {
          if (row["CodeName128"].ToString() == "PACKAGE_" + this.listSonuc.Text)
          {
            int num = (int) MessageBox.Show("Bu İtem Satışlarda Ekli Lütfen Aramayı Satışlara Ekli İtemlerde Yapın");
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          foreach (DataRow row in (InternalDataCollectionBase) this._RefObjCommon.Rows)
          {
            if (row["CodeName128"].ToString() == this.listSonuc.Text)
            {
              this.resim = row["AssocFileIcon128"].ToString();
              string str3 = this.yol + "\\" + this.resim.Split('.')[0] + ".PNG";
              str2 = row["Link"].ToString();
              if (File.Exists(str3))
              {
                Bitmap bitmap = new Bitmap(Image.FromFile(str3), new Size(64, 64));
                this.imgIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                this.imgIcon.Image = (Image) bitmap;
              }
              else
              {
                Bitmap bitmap = new Bitmap(Image.FromFile(this.yol + "\\icon_default.PNG"), new Size(64, 64));
                this.imgIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                this.imgIcon.Image = (Image) bitmap;
              }
              this.btnEkle.Enabled = true;
              break;
            }
          }
          foreach (DataRow row in (InternalDataCollectionBase) this._RefObjItem.Rows)
          {
            if (row["ID"].ToString() == str2)
            {
              this.Dur_L = row["Dur_L"].ToString();
              if (this.listSonuc.Text.IndexOf("_RING_") != -1)
              {
                this.Dur_L = "1";
                break;
              }
              if (this.listSonuc.Text.IndexOf("_EARRING_") != -1)
              {
                this.Dur_L = "1";
                break;
              }
              if (this.listSonuc.Text.IndexOf("_NECKLACE_") != -1)
              {
                this.Dur_L = "1";
                break;
              }
              break;
            }
          }
        }
      }
    }

    private void btnEkle_Click(object sender, EventArgs e)
    {
      if (this.arananYer == "Ekli")
      {
        foreach (DataRow row in (InternalDataCollectionBase) this._RefObjCommon.Rows)
        {
          string str = this.listSonuc.Text.Substring(8);
          if (row["CodeName128"].ToString() == str)
          {
            if (row["Service"].ToString() == "1")
            {
              this.ekle.icon = this.resim;
              this.ekle.gelenItem = this.listSonuc.Text;
              this.ekle.yeni = false;
              this.ekle.Dur_L = this.Dur_L;
              this.ekle.itemEkle();
              this.Close();
              break;
            }
            int num = (int) MessageBox.Show("HATA!!!\nBu item _RefObjCommon tablosunda Aktif değil");
            break;
          }
        }
      }
      else
      {
        this.ekle.gelenItem = this.listSonuc.Text;
        this.ekle.icon = this.resim;
        this.ekle.Dur_L = this.Dur_L;
        this.ekle.yeni = true;
        this.ekle.itemEkle();
        this.Close();
      }
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
            this.txtAra = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.grEkli = new System.Windows.Forms.GroupBox();
            this.grEkliDegil = new System.Windows.Forms.GroupBox();
            this.txtAra1 = new System.Windows.Forms.TextBox();
            this.btnAra1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listSonuc = new System.Windows.Forms.ListBox();
            this.sagTiklama = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kopyalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.grEkli.SuspendLayout();
            this.grEkliDegil.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.sagTiklama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAra
            // 
            this.txtAra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAra.Location = new System.Drawing.Point(6, 26);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(230, 20);
            this.txtAra.TabIndex = 1;
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.Lavender;
            this.btnAra.ForeColor = System.Drawing.Color.Black;
            this.btnAra.Location = new System.Drawing.Point(242, 20);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(75, 32);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // grEkli
            // 
            this.grEkli.BackColor = System.Drawing.Color.Transparent;
            this.grEkli.Controls.Add(this.txtAra);
            this.grEkli.Controls.Add(this.btnAra);
            this.grEkli.ForeColor = System.Drawing.Color.Yellow;
            this.grEkli.Location = new System.Drawing.Point(7, 8);
            this.grEkli.Name = "grEkli";
            this.grEkli.Size = new System.Drawing.Size(326, 65);
            this.grEkli.TabIndex = 6;
            this.grEkli.TabStop = false;
            this.grEkli.Text = "Satışlara Ekli İtemlerde Arama";
            // 
            // grEkliDegil
            // 
            this.grEkliDegil.BackColor = System.Drawing.Color.Transparent;
            this.grEkliDegil.Controls.Add(this.txtAra1);
            this.grEkliDegil.Controls.Add(this.btnAra1);
            this.grEkliDegil.ForeColor = System.Drawing.Color.Yellow;
            this.grEkliDegil.Location = new System.Drawing.Point(339, 8);
            this.grEkliDegil.Name = "grEkliDegil";
            this.grEkliDegil.Size = new System.Drawing.Size(326, 65);
            this.grEkliDegil.TabIndex = 7;
            this.grEkliDegil.TabStop = false;
            this.grEkliDegil.Text = "Bütün İtemlerde Arama";
            // 
            // txtAra1
            // 
            this.txtAra1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAra1.Location = new System.Drawing.Point(6, 26);
            this.txtAra1.Name = "txtAra1";
            this.txtAra1.Size = new System.Drawing.Size(230, 20);
            this.txtAra1.TabIndex = 1;
            // 
            // btnAra1
            // 
            this.btnAra1.BackColor = System.Drawing.Color.Lavender;
            this.btnAra1.ForeColor = System.Drawing.Color.Black;
            this.btnAra1.Location = new System.Drawing.Point(242, 20);
            this.btnAra1.Name = "btnAra1";
            this.btnAra1.Size = new System.Drawing.Size(75, 32);
            this.btnAra1.TabIndex = 2;
            this.btnAra1.Text = "Ara";
            this.btnAra1.UseVisualStyleBackColor = false;
            this.btnAra1.Click += new System.EventHandler(this.btnAra1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.listSonuc);
            this.groupBox3.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox3.Location = new System.Drawing.Point(7, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 310);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bulunan İtemler";
            // 
            // listSonuc
            // 
            this.listSonuc.ContextMenuStrip = this.sagTiklama;
            this.listSonuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSonuc.ForeColor = System.Drawing.Color.Black;
            this.listSonuc.FormattingEnabled = true;
            this.listSonuc.Location = new System.Drawing.Point(3, 16);
            this.listSonuc.Name = "listSonuc";
            this.listSonuc.Size = new System.Drawing.Size(384, 291);
            this.listSonuc.TabIndex = 0;
            this.listSonuc.SelectedIndexChanged += new System.EventHandler(this.listSonuc_SelectedIndexChanged);
            // 
            // sagTiklama
            // 
            this.sagTiklama.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopyalaToolStripMenuItem});
            this.sagTiklama.Name = "sagTiklama";
            this.sagTiklama.Size = new System.Drawing.Size(117, 26);
            // 
            // kopyalaToolStripMenuItem
            // 
            this.kopyalaToolStripMenuItem.Name = "kopyalaToolStripMenuItem";
            this.kopyalaToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.kopyalaToolStripMenuItem.Text = "Kopyala";
            this.kopyalaToolStripMenuItem.Click += new System.EventHandler(this.kopyalaToolStripMenuItem_Click);
            // 
            // imgIcon
            // 
            this.imgIcon.BackColor = System.Drawing.Color.Transparent;
            this.imgIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgIcon.Location = new System.Drawing.Point(406, 108);
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.Size = new System.Drawing.Size(64, 64);
            this.imgIcon.TabIndex = 10;
            this.imgIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(406, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "İtem Resmi";
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.Lavender;
            this.btnEkle.Enabled = false;
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(403, 178);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 32);
            this.btnEkle.TabIndex = 12;
            this.btnEkle.Text = "İtemi Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // Ekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(672, 402);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grEkliDegil);
            this.Controls.Add(this.grEkli);
            this.Controls.Add(this.imgIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = this.Icon;
            this.MaximizeBox = false;
            this.Name = "Ekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekle";
            this.Load += new System.EventHandler(this.Ekle_Load);
            this.grEkli.ResumeLayout(false);
            this.grEkli.PerformLayout();
            this.grEkliDegil.ResumeLayout(false);
            this.grEkliDegil.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.sagTiklama.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
