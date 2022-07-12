// Decompiled with JetBrains decompiler
// Type: ArtiBasmaRenkAyari.ArtiRenkleri
// Assembly: ArtiBasmaRenkAyari, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4781CAE8-CCED-42E3-84C7-CC751066D213
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\ArtiBasmaRenkAyari.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ArtiBasmaRenkAyari
{
  public class ArtiRenkleri : UserControl
  {
    private IContainer components = (IContainer) null;
    private TreeView tree;
    private GroupBox grpRenk;
    private Panel pnlColor1;
    private GroupBox grpMaske;
    private GroupBox grpSaydam;
    private GroupBox grpIslemler;
    private Panel pnlColor2;
    private Label label2;
    private Label label1;
    private PictureBox img;
    private ComboBox cmbRenk;
    private ComboBox cmbMaske;
    private Label label3;
    private Label label4;
    private Button btnDuzenle;
    private Button btnIptal;
    private Button btnYeni;
    private Button btnSil;
    private Button btnTxt;
    private Button btnKaydet;
    private GroupBox groupBox1;
    private MaskedTextBox txtHız;
    private int sekme = 0;
    public string dizin = "";
    private TreeNode node;
    internal DataTable Tablo;
    private DataTable gTablo;
    private DataRow[] satirlar;
    private int gelis = 0;
    private bool kaydet = false;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.tree = new System.Windows.Forms.TreeView();
            this.grpRenk = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlColor2 = new System.Windows.Forms.Panel();
            this.pnlColor1 = new System.Windows.Forms.Panel();
            this.grpMaske = new System.Windows.Forms.GroupBox();
            this.img = new System.Windows.Forms.PictureBox();
            this.grpSaydam = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMaske = new System.Windows.Forms.ComboBox();
            this.cmbRenk = new System.Windows.Forms.ComboBox();
            this.grpIslemler = new System.Windows.Forms.GroupBox();
            this.btnTxt = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnYeni = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHız = new System.Windows.Forms.MaskedTextBox();
            this.grpRenk.SuspendLayout();
            this.grpMaske.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.grpSaydam.SuspendLayout();
            this.grpIslemler.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.ForeColor = System.Drawing.Color.Black;
            this.tree.Location = new System.Drawing.Point(14, 15);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(152, 485);
            this.tree.TabIndex = 0;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // grpRenk
            // 
            this.grpRenk.BackColor = System.Drawing.Color.Transparent;
            this.grpRenk.Controls.Add(this.label2);
            this.grpRenk.Controls.Add(this.label1);
            this.grpRenk.Controls.Add(this.pnlColor2);
            this.grpRenk.Controls.Add(this.pnlColor1);
            this.grpRenk.ForeColor = System.Drawing.Color.White;
            this.grpRenk.Location = new System.Drawing.Point(361, 17);
            this.grpRenk.Name = "grpRenk";
            this.grpRenk.Size = new System.Drawing.Size(177, 101);
            this.grpRenk.TabIndex = 1;
            this.grpRenk.TabStop = false;
            this.grpRenk.Text = "Kullanılan Renkler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Renk 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Renk 1";
            // 
            // pnlColor2
            // 
            this.pnlColor2.BackColor = System.Drawing.Color.LightGray;
            this.pnlColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlColor2.Location = new System.Drawing.Point(96, 21);
            this.pnlColor2.Name = "pnlColor2";
            this.pnlColor2.Size = new System.Drawing.Size(69, 56);
            this.pnlColor2.TabIndex = 0;
            this.pnlColor2.Click += new System.EventHandler(this.pnlColor1_Click);
            // 
            // pnlColor1
            // 
            this.pnlColor1.BackColor = System.Drawing.Color.LightGray;
            this.pnlColor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlColor1.Location = new System.Drawing.Point(11, 21);
            this.pnlColor1.Name = "pnlColor1";
            this.pnlColor1.Size = new System.Drawing.Size(69, 56);
            this.pnlColor1.TabIndex = 0;
            this.pnlColor1.Click += new System.EventHandler(this.pnlColor1_Click);
            // 
            // grpMaske
            // 
            this.grpMaske.BackColor = System.Drawing.Color.Transparent;
            this.grpMaske.Controls.Add(this.img);
            this.grpMaske.ForeColor = System.Drawing.Color.White;
            this.grpMaske.Location = new System.Drawing.Point(179, 17);
            this.grpMaske.Name = "grpMaske";
            this.grpMaske.Size = new System.Drawing.Size(165, 184);
            this.grpMaske.TabIndex = 1;
            this.grpMaske.TabStop = false;
            this.grpMaske.Text = "Kullanılan Maske";
            // 
            // img
            // 
            this.img.BackColor = System.Drawing.Color.LightGray;
            this.img.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.img.Location = new System.Drawing.Point(7, 20);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(150, 150);
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            this.img.Click += new System.EventHandler(this.img_Click);
            // 
            // grpSaydam
            // 
            this.grpSaydam.BackColor = System.Drawing.Color.Transparent;
            this.grpSaydam.Controls.Add(this.label4);
            this.grpSaydam.Controls.Add(this.label3);
            this.grpSaydam.Controls.Add(this.cmbMaske);
            this.grpSaydam.Controls.Add(this.cmbRenk);
            this.grpSaydam.ForeColor = System.Drawing.Color.White;
            this.grpSaydam.Location = new System.Drawing.Point(361, 126);
            this.grpSaydam.Name = "grpSaydam";
            this.grpSaydam.Size = new System.Drawing.Size(169, 80);
            this.grpSaydam.TabIndex = 1;
            this.grpSaydam.TabStop = false;
            this.grpSaydam.Text = "Saydamlık Ayarları";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Maske Saydamlığı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Renk Saydamlığı";
            // 
            // cmbMaske
            // 
            this.cmbMaske.FormattingEnabled = true;
            this.cmbMaske.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbMaske.Location = new System.Drawing.Point(115, 47);
            this.cmbMaske.Name = "cmbMaske";
            this.cmbMaske.Size = new System.Drawing.Size(40, 21);
            this.cmbMaske.TabIndex = 0;
            this.cmbMaske.Click += new System.EventHandler(this.cmbRenk_Clik);
            // 
            // cmbRenk
            // 
            this.cmbRenk.FormattingEnabled = true;
            this.cmbRenk.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbRenk.Location = new System.Drawing.Point(115, 20);
            this.cmbRenk.Name = "cmbRenk";
            this.cmbRenk.Size = new System.Drawing.Size(40, 21);
            this.cmbRenk.TabIndex = 0;
            this.cmbRenk.Click += new System.EventHandler(this.cmbRenk_Clik);
            // 
            // grpIslemler
            // 
            this.grpIslemler.BackColor = System.Drawing.Color.Transparent;
            this.grpIslemler.Controls.Add(this.btnTxt);
            this.grpIslemler.Controls.Add(this.btnKaydet);
            this.grpIslemler.Controls.Add(this.btnIptal);
            this.grpIslemler.Controls.Add(this.btnYeni);
            this.grpIslemler.Controls.Add(this.btnSil);
            this.grpIslemler.Controls.Add(this.btnDuzenle);
            this.grpIslemler.ForeColor = System.Drawing.Color.White;
            this.grpIslemler.Location = new System.Drawing.Point(179, 221);
            this.grpIslemler.Name = "grpIslemler";
            this.grpIslemler.Size = new System.Drawing.Size(274, 123);
            this.grpIslemler.TabIndex = 1;
            this.grpIslemler.TabStop = false;
            this.grpIslemler.Text = "İşlemler";
            // 
            // btnTxt
            // 
            this.btnTxt.BackColor = System.Drawing.Color.Lavender;
            this.btnTxt.ForeColor = System.Drawing.Color.Black;
            this.btnTxt.Location = new System.Drawing.Point(182, 75);
            this.btnTxt.Name = "btnTxt";
            this.btnTxt.Size = new System.Drawing.Size(75, 36);
            this.btnTxt.TabIndex = 0;
            this.btnTxt.Text = "Txt Dosyası Oluştur";
            this.btnTxt.UseVisualStyleBackColor = false;
            this.btnTxt.Click += new System.EventHandler(this.btnTxt_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Lavender;
            this.btnKaydet.ForeColor = System.Drawing.Color.Black;
            this.btnKaydet.Location = new System.Drawing.Point(101, 75);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 36);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Lavender;
            this.btnIptal.ForeColor = System.Drawing.Color.Black;
            this.btnIptal.Location = new System.Drawing.Point(20, 75);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 36);
            this.btnIptal.TabIndex = 0;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnYeni
            // 
            this.btnYeni.BackColor = System.Drawing.Color.Lavender;
            this.btnYeni.ForeColor = System.Drawing.Color.Black;
            this.btnYeni.Location = new System.Drawing.Point(182, 22);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(75, 36);
            this.btnYeni.TabIndex = 0;
            this.btnYeni.Text = "Yeni + Değeri Ekle";
            this.btnYeni.UseVisualStyleBackColor = false;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Lavender;
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(101, 22);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 36);
            this.btnSil.TabIndex = 0;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.Lavender;
            this.btnDuzenle.ForeColor = System.Drawing.Color.Black;
            this.btnDuzenle.Location = new System.Drawing.Point(20, 22);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(75, 36);
            this.btnDuzenle.TabIndex = 0;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtHız);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(536, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Effect Geçiş Hızı";
            // 
            // txtHız
            // 
            this.txtHız.Location = new System.Drawing.Point(6, 24);
            this.txtHız.Mask = "999999";
            this.txtHız.Name = "txtHız";
            this.txtHız.Size = new System.Drawing.Size(53, 20);
            this.txtHız.TabIndex = 2;
            this.txtHız.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHız_KeyUp);
            // 
            // ArtiRenkleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.grpIslemler);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSaydam);
            this.Controls.Add(this.grpMaske);
            this.Controls.Add(this.grpRenk);
            this.Controls.Add(this.tree);
            this.Name = "ArtiRenkleri";
            this.Size = new System.Drawing.Size(800, 523);
            this.Load += new System.EventHandler(this.ArtiRenkleri_Load);
            this.grpRenk.ResumeLayout(false);
            this.grpRenk.PerformLayout();
            this.grpMaske.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.grpSaydam.ResumeLayout(false);
            this.grpSaydam.PerformLayout();
            this.grpIslemler.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

    }

    public ArtiRenkleri() => this.InitializeComponent();

    private void ArtiRenkleri_Load(object sender, EventArgs e)
    {
      this.grpMaske.Enabled = false;
      this.grpRenk.Enabled = false;
      this.grpSaydam.Enabled = false;
      this.btnIptal.Enabled = false;
      this.btnTxt.Enabled = false;
      this.btnKaydet.Enabled = false;
      this.txtHız.Enabled = false;
      try
      {
        if (File.Exists(this.dizin + "\\Media\\resinfo\\itemtypenumber.txt"))
        {
          this.gTablo = new DataTable();
          this.gTablo.Columns.Add("a0", typeof (string));
          this.gTablo.Columns.Add("a1", typeof (int));
          this.gTablo.Columns.Add("a2", typeof (string));
          this.gTablo.Columns.Add("a3", typeof (string));
          this.gTablo.Columns.Add("a4", typeof (string));
          this.gTablo.Columns.Add("a5", typeof (string));
          this.gTablo.Columns.Add("a6", typeof (string));
          this.gTablo.Columns.Add("a7", typeof (string));
          this.gTablo.Columns.Add("a8", typeof (string));
          this.gTablo.Columns.Add("a9", typeof (string));
          FileStream fileStream = new FileStream(this.dizin + "\\Media\\resinfo\\itemtypenumber.txt", FileMode.Open, FileAccess.Read);
          StreamReader streamReader = new StreamReader((Stream) fileStream);
          string[] strArray1 = streamReader.ReadToEnd().Split('\n');
          streamReader.Close();
          fileStream.Close();
          streamReader.Dispose();
          fileStream.Dispose();
          for (int index = 0; index < strArray1.Length; ++index)
          {
            if (strArray1[index] != "")
            {
              string str = strArray1[index];
              if (str.Substring(0, 1) == "1")
              {
                string[] strArray2 = str.Split('\t');
                DataRow row = this.gTablo.NewRow();
                for (int columnIndex = 0; columnIndex < strArray2.Length; ++columnIndex)
                  row[columnIndex] = (object) strArray2[columnIndex];
                this.gTablo.Rows.Add(row);
              }
            }
          }
          this.Tablo = this.gTablo.Copy();
          this.TreeDoldur();
        }
        else
        {
          if (MessageBox.Show("\"itemtypenumber.txt\" Text Dosyası Bulunamadı.\n Lütfen Media.PK2 Dosyasından \"/resinfo/itemtypenumber.txt\" Dosyasını Çıkarıp\nProgramı Kurduğunuz Dizindeki \"Media/resinfo/\" Klasörünün İçine Kopyalayın...") != DialogResult.OK)
            return;
          this.grpIslemler.Enabled = false;
        }
      }
      catch
      {
        int num = (int) MessageBox.Show("Lütfen Media.PK2 Dosyasından \"/resinfo/itemtypenumber.txt\" Dosyasını Çıkarıp\nProgramı Kurduğunuz Dizindeki \"Media/resinfo/\" Klasörünün İçindeki itemtypenumber.txt Dosyasıyla Değiştirin ...");
        this.grpIslemler.Enabled = false;
      }
    }

    internal void TreeDoldur()
    {
      this.satirlar = this.Tablo.Select("a0='1'", "a1 ASC", DataViewRowState.CurrentRows);
      this.tree.Nodes.Clear();
      this.tree.Nodes.Add("+ Değerleri");
      foreach (DataRow dataRow in this.satirlar)
        this.tree.Nodes[0].Nodes.Add("+" + dataRow[1]);
      this.tree.SelectedNode = this.tree.Nodes[0].Nodes[0];
      if (this.Tablo.Rows.Count == this.gTablo.Rows.Count)
        return;
      this.btnIptal.Enabled = true;
      this.btnKaydet.Enabled = true;
      this.btnDuzenle.Enabled = false;
      this.btnYeni.Enabled = false;
      this.btnSil.Enabled = false;
      this.tree.Enabled = false;
      this.txtHız.Enabled = false;
    }

    private void tree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      string[] strArray1 = new string[3];
      string[] strArray2 = new string[3];
      if (e.Node.Level == 0)
        return;
      this.node = e.Node;
      int index = e.Node.Index;
      this.sekme = index;
      string[] strArray3 = renkCevir.RGBRenk(this.satirlar[index][6].ToString()).Split(',');
      string[] strArray4 = renkCevir.RGBRenk(this.satirlar[index][7].ToString()).Split(',');
      this.pnlColor1.BackColor = Color.FromArgb((int) Convert.ToInt16(strArray3[0]), (int) Convert.ToInt16(strArray3[1]), (int) Convert.ToInt16(strArray3[2]));
      this.pnlColor2.BackColor = Color.FromArgb((int) Convert.ToInt16(strArray4[0]), (int) Convert.ToInt16(strArray4[1]), (int) Convert.ToInt16(strArray4[2]));
      string[] strArray5 = this.satirlar[index][3].ToString().Split('\\');
      if (File.Exists(this.dizin + "\\maske\\" + strArray5[strArray5.Length - 1].Replace(".ddj", ".PNG")))
      {
        this.img.Image = (Image) new Bitmap((Image) new Bitmap(this.dizin + "\\maske\\" + strArray5[strArray5.Length - 1].Replace(".ddj", ".PNG")), 150, 150);
        this.img.SizeMode = PictureBoxSizeMode.StretchImage;
      }
      this.cmbRenk.Text = this.satirlar[index][4].ToString();
      this.cmbMaske.Text = this.satirlar[index][5].ToString();
      this.txtHız.Text = this.satirlar[index][2].ToString().Replace("-", "").Substring(2);
    }

    private void btnDuzenle_Click(object sender, EventArgs e)
    {
      this.tree.Enabled = false;
      this.grpMaske.Enabled = true;
      this.grpRenk.Enabled = true;
      this.grpSaydam.Enabled = true;
      this.btnSil.Enabled = false;
      this.btnIptal.Enabled = true;
      this.btnYeni.Enabled = false;
      this.btnDuzenle.Enabled = false;
      this.btnTxt.Enabled = false;
      this.txtHız.Enabled = true;
    }

    private void btnIptal_Click(object sender, EventArgs e)
    {
      this.Tablo.Clear();
      this.Tablo = this.gTablo.Copy();
      this.TreeDoldur();
      this.btnKaydet.Enabled = false;
      this.tree.Enabled = true;
      this.grpMaske.Enabled = false;
      this.grpRenk.Enabled = false;
      this.grpSaydam.Enabled = false;
      this.btnSil.Enabled = true;
      this.btnIptal.Enabled = false;
      this.btnYeni.Enabled = true;
      this.btnDuzenle.Enabled = true;
      this.txtHız.Enabled = false;
      if (this.kaydet)
        this.btnTxt.Enabled = true;
      else
        this.btnTxt.Enabled = false;
      string[] strArray1 = new string[3];
      string[] strArray2 = new string[3];
      int index = this.node.Index;
      string[] strArray3 = renkCevir.RGBRenk(this.satirlar[index][6].ToString()).Split(',');
      string[] strArray4 = renkCevir.RGBRenk(this.satirlar[index][7].ToString()).Split(',');
      this.pnlColor1.BackColor = Color.FromArgb((int) Convert.ToInt16(strArray3[0]), (int) Convert.ToInt16(strArray3[1]), (int) Convert.ToInt16(strArray3[2]));
      this.pnlColor2.BackColor = Color.FromArgb((int) Convert.ToInt16(strArray4[0]), (int) Convert.ToInt16(strArray4[1]), (int) Convert.ToInt16(strArray4[2]));
      string[] strArray5 = this.satirlar[index][3].ToString().Split('\\');
      if (File.Exists(this.dizin + "\\maske\\" + strArray5[strArray5.Length - 1].Replace(".ddj", ".PNG")))
        this.img.Image = (Image) new Bitmap(this.dizin + "\\maske\\" + strArray5[strArray5.Length - 1].Replace(".ddj", ".PNG"));
      this.cmbRenk.Text = this.satirlar[index][4].ToString();
      this.cmbMaske.Text = this.satirlar[index][5].ToString();
      this.txtHız.Text = this.satirlar[index][2].ToString().Replace("-", "").Substring(2);
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
      this.satirlar[this.node.Index].Delete();
      this.TreeDoldur();
    }

    private void btnYeni_Click(object sender, EventArgs e)
    {
      this.btnTxt.Enabled = false;
      int num = (int) new yeniTree()
      {
        tablo = this.Tablo,
        frm = this
      }.ShowDialog();
    }

    private void img_Click(object sender, EventArgs e)
    {
      int num = (int) new maske() { frm = this }.ShowDialog();
    }

    internal void ResimYukle(string resim, string dizin)
    {
      this.img.Image = (Image) new Bitmap((Image) new Bitmap(dizin + "\\" + resim), 256, 256);
      this.img.SizeMode = PictureBoxSizeMode.StretchImage;
      this.satirlar[this.node.Index][3] = (object) ("prim\\mtrl\\itemoption\\" + resim);
      this.btnKaydet.Enabled = true;
    }

    private void pnlColor1_Click(object sender, EventArgs e)
    {
      Panel panel = sender as Panel;
      string name = panel.Name;
      ColorDialog colorDialog = new ColorDialog();
      if (colorDialog.ShowDialog() != DialogResult.OK)
        return;
      panel.BackColor = colorDialog.Color;
      object[] objArray = new object[5];
      Color color = colorDialog.Color;
      objArray[0] = (object) color.R;
      objArray[1] = (object) ",";
      color = colorDialog.Color;
      objArray[2] = (object) color.G;
      objArray[3] = (object) ",";
      color = colorDialog.Color;
      objArray[4] = (object) color.B;
      string RGB = string.Concat(objArray);
      if (name == this.pnlColor1.Name)
      {
        this.satirlar[this.node.Index][6] = (object) renkCevir.SilkroadRenk(RGB);
        this.btnKaydet.Enabled = true;
      }
      else if (name == this.pnlColor2.Name)
      {
        this.satirlar[this.node.Index][7] = (object) renkCevir.SilkroadRenk(RGB);
        this.btnKaydet.Enabled = true;
      }
    }

    internal void kayitKontrol()
    {
      if (this.kaydet)
        this.btnTxt.Enabled = true;
      else
        this.btnTxt.Enabled = false;
    }

    private void cmbRenk_Clik(object sender, EventArgs e)
    {
      this.gelis = 0;
      (sender as ComboBox).SelectedIndexChanged += new EventHandler(this.cmb_SelectedIndexChanged);
    }

    private void cmb_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.gelis != 0)
        return;
      ComboBox comboBox = sender as ComboBox;
      if (comboBox.Name == this.cmbRenk.Name)
      {
        this.satirlar[this.node.Index][4] = (object) comboBox.Text;
        this.btnKaydet.Enabled = true;
      }
      else if (comboBox.Name == this.cmbMaske.Name)
      {
        this.satirlar[this.node.Index][5] = (object) comboBox.Text;
        this.btnKaydet.Enabled = true;
      }
      this.gelis = 1;
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      int length = this.txtHız.Text.Length;
      if (length < 6)
      {
        string str = this.txtHız.Text;
        int num = 6 - length;
        for (int index = 0; index < num; ++index)
          str = "0" + str;
        int index1 = 0;
        foreach (DataRow row in (InternalDataCollectionBase) this.Tablo.Rows)
        {
          if (!(row[1].ToString() == this.node.Text.Replace("+", "")))
            ++index1;
          else
            break;
        }
        this.Tablo.Rows[index1][2] = (object) ("0." + str);
      }
      else
      {
        string text = this.txtHız.Text;
        int index = 0;
        foreach (DataRow row in (InternalDataCollectionBase) this.Tablo.Rows)
        {
          if (!(row[1].ToString() == this.node.Text.Replace("+", "")))
            ++index;
          else
            break;
        }
        this.Tablo.Rows[index][2] = (object) ("0." + text);
      }
      this.gTablo.Clear();
      this.gTablo = this.Tablo.Copy();
      this.btnDuzenle.Enabled = true;
      this.btnIptal.Enabled = false;
      this.btnSil.Enabled = true;
      this.btnYeni.Enabled = true;
      this.tree.Enabled = true;
      this.grpMaske.Enabled = false;
      this.grpRenk.Enabled = false;
      this.grpSaydam.Enabled = false;
      this.TreeDoldur();
      this.btnKaydet.Enabled = false;
      this.txtHız.Enabled = false;
      this.kaydet = true;
      this.btnTxt.Enabled = true;
    }

    private void btnTxt_Click(object sender, EventArgs e)
    {
      this.btnTxt.Enabled = false;
      if (!File.Exists(this.dizin + "\\Media\\resinfo\\itemtypenumber.txt"))
        return;
      File.Delete(this.dizin + "\\Media\\resinfo\\itemtypenumber.txt");
      if (!File.Exists(this.dizin + "\\Media\\resinfo\\itemtypenumber.txt"))
      {
        FileStream fileStream = new FileStream(this.dizin + "\\Media\\resinfo\\itemtypenumber.txt", FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.ASCII);
        for (int index1 = 0; index1 < 4; ++index1)
        {
          for (int index2 = 0; index2 < this.gTablo.Rows.Count; ++index2)
          {
            string str1 = "";
            ArrayList arrayList = new ArrayList();
            switch (index1)
            {
              case 0:
                arrayList.Clear();
                arrayList.Add((object) "1");
                arrayList.Add(this.satirlar[index2][1]);
                arrayList.Add((object) (this.satirlar[index2][2].ToString().Substring(0, 8) + ",-" + this.satirlar[index2][2].ToString().Substring(0, 8)));
                arrayList.Add((object) this.satirlar[index2][3].ToString().Replace(".PNG", ".ddj"));
                arrayList.Add(this.satirlar[index2][4]);
                arrayList.Add(this.satirlar[index2][5]);
                arrayList.Add(this.satirlar[index2][6]);
                arrayList.Add(this.satirlar[index2][7]);
                arrayList.Add((object) "1000");
                arrayList.Add((object) "0");
                break;
              case 1:
                arrayList.Clear();
                arrayList.Add((object) "2");
                arrayList.Add(this.satirlar[index2][1]);
                arrayList.Add((object) (this.satirlar[index2][2].ToString().Substring(0, 8) + ",-" + this.satirlar[index2][2].ToString().Substring(0, 8)));
                arrayList.Add((object) this.satirlar[index2][3].ToString().Replace(".PNG", ".ddj"));
                arrayList.Add(this.satirlar[index2][4]);
                arrayList.Add(this.satirlar[index2][5]);
                arrayList.Add(this.satirlar[index2][6]);
                arrayList.Add(this.satirlar[index2][7]);
                arrayList.Add((object) "1000");
                arrayList.Add((object) "1");
                break;
              case 2:
                arrayList.Clear();
                arrayList.Add((object) "3");
                arrayList.Add(this.gTablo.Rows[index2][1]);
                arrayList.Add((object) ("0.000000," + this.satirlar[index2][2].ToString().Substring(0, 8)));
                arrayList.Add((object) this.satirlar[index2][3].ToString().Replace(".PNG", ".ddj"));
                arrayList.Add(this.satirlar[index2][4]);
                arrayList.Add(this.satirlar[index2][5]);
                arrayList.Add(this.satirlar[index2][6]);
                arrayList.Add(this.satirlar[index2][7]);
                arrayList.Add((object) "1000");
                arrayList.Add((object) "0");
                break;
              case 3:
                arrayList.Clear();
                arrayList.Add((object) "4");
                arrayList.Add(this.satirlar[index2][1]);
                arrayList.Add((object) ("0.000000," + this.satirlar[index2][2].ToString().Substring(0, 8)));
                arrayList.Add((object) this.satirlar[index2][3].ToString().Replace(".PNG", ".ddj"));
                arrayList.Add(this.satirlar[index2][4]);
                arrayList.Add(this.satirlar[index2][5]);
                arrayList.Add(this.satirlar[index2][6]);
                arrayList.Add(this.satirlar[index2][7]);
                arrayList.Add((object) "1000");
                arrayList.Add((object) "1");
                break;
            }
            for (int index3 = 0; index3 < this.gTablo.Columns.Count; ++index3)
              str1 = str1 + "\t" + arrayList[index3];
            string str2 = str1.Substring(1) + "\r\n";
            streamWriter.Write(str2);
          }
        }
        streamWriter.Close();
        streamWriter.Dispose();
        fileStream.Close();
        fileStream.Dispose();
        if (MessageBox.Show("İşlem Tamamlandı") == DialogResult.OK)
        {
          string str = this.dizin + "\\Media\\resinfo";
          string environmentVariable = Environment.GetEnvironmentVariable("WINDIR");
          new Process()
          {
            StartInfo = {
              FileName = (environmentVariable + "\\explorer.exe"),
              Arguments = str
            }
          }.Start();
        }
      }
    }

    private void txtHız_KeyUp(object sender, KeyEventArgs e) => this.btnKaydet.Enabled = true;
  }
}
