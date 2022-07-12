// Decompiled with JetBrains decompiler
// Type: UserKontrol.rarParlamasi
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UserKontrol
{
  public class rarParlamasi : UserControl
  {
    private efpClass efp;
    private byte[][][] byt;
    private TreeNode node;
    private IContainer components = (IContainer) null;
    private TreeView tree;
    private Button btnAc;
    private Button btnKaydet;
    private Label lblAciklama;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private Panel pnlColor;
    private Label label1;
    private Label lblBilgi;
    private Button btnBeyaz;
    private Button btnKarisik;
    private Button btnVazgec;

    public rarParlamasi() => this.InitializeComponent();

    private void rarParlamasi_Load(object sender, EventArgs e)
    {
      this.lblAciklama.Text = this.aciklama();
      this.lblAciklama.ForeColor = System.Drawing.Color.WhiteSmoke;
      this.btnKaydet.Enabled = false;
      this.btnBeyaz.Enabled = false;
      this.btnVazgec.Enabled = false;
      this.btnKarisik.Enabled = false;
    }

    private string aciklama() => "**********************************************************************************\n**********************************************************************************\nMedia/resinfo/itemrare.txt\ndosyasını çıkarın\n**********************************************************************************\n**********************************************************************************\nörnek olarak:\nITEM_CH_SWORD_12_C_RARE bu itemin .efp si karşısında yazıyor\nyazan efp dosyasını\nParticles.PK2 dosyasında \nsystem\\system_raretype_a_step3.efp\nişte biz bu dosyayı değiştireceğiz...\n**********************************************************************************\n**********************************************************************************\nSize tavsiyem uzun sürmez diyorsanız eğer bütün renkleri\nbeyaz yapın.\nneden diye soracak olursanız hangi renk ağacın nereye\nkumanda ettiğini anlarsınız onagöre çalışırsınız.\n**********************************************************************************\n**********************************************************************************\n\n                          KOLAY GELSİN <<---->> CSR-R NPC\n\n**********************************************************************************\n**********************************************************************************\n";

    private void RenkleriGetir_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "*.efp|*.efp";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.btnAc.Enabled = false;
      this.tree.Nodes.Clear();
      this.pnlColor.BackColor = Color.Transparent;
      this.efp = new efpClass(openFileDialog.FileName);
      this.lblBilgi.Text = openFileDialog.SafeFileName;
      this.byt = this.efp.byt;
      for (int index1 = 0; index1 < this.byt.Length; ++index1)
      {
        this.tree.Nodes.Add("BlendDiffuseGraph" + (object) (index1 + 1));
        for (int index2 = 0; index2 < this.byt[index1].Length; ++index2)
        {
          this.tree.Nodes[index1].Nodes.Add("Renk" + (object) (index2 + 1));
          this.tree.Nodes[index1].Nodes[index2].BackColor = Color.FromArgb((int) this.byt[index1][index2][0], (int) this.byt[index1][index2][1], (int) this.byt[index1][index2][2]);
        }
      }
      this.btnKaydet.Enabled = true;
      this.btnBeyaz.Enabled = true;
      this.btnVazgec.Enabled = true;
      this.btnKarisik.Enabled = true;
    }

    private void pnlColor_Click(object sender, EventArgs e)
    {
      if (!(this.pnlColor.BackColor != Color.Transparent))
        return;
      ColorDialog colorDialog = new ColorDialog();
      if (colorDialog.ShowDialog() == DialogResult.OK)
      {
        this.pnlColor.BackColor = colorDialog.Color;
        this.node.BackColor = colorDialog.Color;
        int index1 = this.node.Parent.Index;
        int index2 = this.node.Index;
        this.byt[index1][index2][0] = colorDialog.Color.R;
        byte[] numArray1 = this.byt[index1][index2];
        Color color = colorDialog.Color;
        int g = (int) color.G;
        numArray1[1] = (byte) g;
        byte[] numArray2 = this.byt[index1][index2];
        color = colorDialog.Color;
        int b = (int) color.B;
        numArray2[2] = (byte) b;
      }
    }

    private void tree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (e.Node.Level != 1)
        return;
      this.pnlColor.BackColor = e.Node.BackColor;
      this.node = e.Node;
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "*.efp|*.efp";
      saveFileDialog.FileName = this.lblBilgi.Text;
      if (saveFileDialog.ShowDialog() != DialogResult.OK || !this.efp.EFPKayit(this.byt, saveFileDialog.FileName))
        return;
      int num = (int) MessageBox.Show("İşlem Tamamlandı");
      this.btnAc.Enabled = true;
      this.btnKaydet.Enabled = false;
      this.btnBeyaz.Enabled = false;
      this.btnVazgec.Enabled = false;
      this.btnKarisik.Enabled = false;
      this.tree.Nodes.Clear();
    }

    private void btnBeyaz_Click(object sender, EventArgs e)
    {
      for (int index1 = 0; index1 < this.tree.Nodes.Count; ++index1)
      {
        for (int index2 = 0; index2 < this.tree.Nodes[index1].Nodes.Count; ++index2)
        {
          this.tree.Nodes[index1].Nodes[index2].BackColor = Color.White;
          byte[] numArray1 = this.byt[index1][index2];
          Color white = Color.White;
          int r = (int) white.R;
          numArray1[0] = (byte) r;
          byte[] numArray2 = this.byt[index1][index2];
          white = Color.White;
          int g = (int) white.G;
          numArray2[1] = (byte) g;
          byte[] numArray3 = this.byt[index1][index2];
          white = Color.White;
          int b = (int) white.B;
          numArray3[2] = (byte) b;
        }
      }
      int num = (int) MessageBox.Show("Bütün Renkler Beyaza Döndürüldü");
    }

    private void btnKarisik_Click(object sender, EventArgs e)
    {
      int num = (int) new renkPaleti() { par = this }.ShowDialog();
    }

    private void btnVazgec_Click(object sender, EventArgs e)
    {
      this.btnAc.Enabled = true;
      this.btnKaydet.Enabled = false;
      this.btnBeyaz.Enabled = false;
      this.btnVazgec.Enabled = false;
      this.btnKarisik.Enabled = false;
      this.tree.Nodes.Clear();
    }

    internal void renkleriAta(Color[] color)
    {
      int index1 = 0;
      for (int index2 = 0; index2 < this.tree.Nodes.Count; ++index2)
      {
        for (int index3 = 0; index3 < this.tree.Nodes[index2].Nodes.Count; ++index3)
        {
          this.tree.Nodes[index2].Nodes[index3].BackColor = color[index1];
          this.byt[index2][index3][0] = color[index1].R;
          this.byt[index2][index3][1] = color[index1].G;
          this.byt[index2][index3][2] = color[index1].B;
          ++index1;
          if (index1 > color.Length - 1)
            index1 = 0;
        }
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
            this.tree = new System.Windows.Forms.TreeView();
            this.btnAc = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnKarisik = new System.Windows.Forms.Button();
            this.btnBeyaz = new System.Windows.Forms.Button();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.ForeColor = System.Drawing.Color.Black;
            this.tree.Location = new System.Drawing.Point(8, 20);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(180, 456);
            this.tree.TabIndex = 0;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // btnAc
            // 
            this.btnAc.BackColor = System.Drawing.Color.Lavender;
            this.btnAc.ForeColor = System.Drawing.Color.Black;
            this.btnAc.Location = new System.Drawing.Point(329, 21);
            this.btnAc.Name = "btnAc";
            this.btnAc.Size = new System.Drawing.Size(75, 35);
            this.btnAc.TabIndex = 2;
            this.btnAc.Text = "EFP dosyası";
            this.btnAc.UseVisualStyleBackColor = false;
            this.btnAc.Click += new System.EventHandler(this.RenkleriGetir_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Lavender;
            this.btnKaydet.ForeColor = System.Drawing.Color.Black;
            this.btnKaydet.Location = new System.Drawing.Point(410, 21);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 35);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "EFP Kayıt";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.BackColor = System.Drawing.Color.Transparent;
            this.lblAciklama.Location = new System.Drawing.Point(6, 22);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(0, 13);
            this.lblAciklama.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblAciklama);
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(442, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 372);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KISA AÇIKLAMA";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.tree);
            this.groupBox2.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox2.Location = new System.Drawing.Point(5, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 482);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = ".EFP Renk Ağacı";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.lblBilgi);
            this.groupBox3.Controls.Add(this.btnVazgec);
            this.groupBox3.Controls.Add(this.btnAc);
            this.groupBox3.Controls.Add(this.btnKaydet);
            this.groupBox3.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox3.Location = new System.Drawing.Point(215, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(572, 70);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dosya İşlemleri";
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.Location = new System.Drawing.Point(7, 34);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(0, 13);
            this.lblBilgi.TabIndex = 3;
            // 
            // btnVazgec
            // 
            this.btnVazgec.BackColor = System.Drawing.Color.Lavender;
            this.btnVazgec.ForeColor = System.Drawing.Color.Black;
            this.btnVazgec.Location = new System.Drawing.Point(491, 21);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 35);
            this.btnVazgec.TabIndex = 2;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = false;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.btnKarisik);
            this.groupBox4.Controls.Add(this.btnBeyaz);
            this.groupBox4.Controls.Add(this.pnlColor);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox4.Location = new System.Drawing.Point(215, 98);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 274);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Renk";
            // 
            // btnKarisik
            // 
            this.btnKarisik.BackColor = System.Drawing.Color.Lavender;
            this.btnKarisik.ForeColor = System.Drawing.Color.Black;
            this.btnKarisik.Location = new System.Drawing.Point(16, 231);
            this.btnKarisik.Name = "btnKarisik";
            this.btnKarisik.Size = new System.Drawing.Size(163, 35);
            this.btnKarisik.TabIndex = 3;
            this.btnKarisik.Text = "Karışık Renk Ata";
            this.btnKarisik.UseVisualStyleBackColor = false;
            this.btnKarisik.Click += new System.EventHandler(this.btnKarisik_Click);
            // 
            // btnBeyaz
            // 
            this.btnBeyaz.BackColor = System.Drawing.Color.Lavender;
            this.btnBeyaz.ForeColor = System.Drawing.Color.Black;
            this.btnBeyaz.Location = new System.Drawing.Point(16, 190);
            this.btnBeyaz.Name = "btnBeyaz";
            this.btnBeyaz.Size = new System.Drawing.Size(163, 35);
            this.btnBeyaz.TabIndex = 3;
            this.btnBeyaz.Text = "Tümünü Beyaz Yap";
            this.btnBeyaz.UseVisualStyleBackColor = false;
            this.btnBeyaz.Click += new System.EventHandler(this.btnBeyaz_Click);
            // 
            // pnlColor
            // 
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlColor.Location = new System.Drawing.Point(16, 43);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(163, 137);
            this.pnlColor.TabIndex = 1;
            this.pnlColor.Click += new System.EventHandler(this.pnlColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rengi Değiştirmek İçin Tıklayın";
            // 
            // rarParlamasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "rarParlamasi";
            this.Size = new System.Drawing.Size(800, 523);
            this.Load += new System.EventHandler(this.rarParlamasi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

    }
  }
}
