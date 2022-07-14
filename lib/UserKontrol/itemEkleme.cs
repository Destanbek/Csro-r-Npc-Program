// Decompiled with JetBrains decompiler
// Type: UserKontrol.itemEkleme
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tablo;

namespace UserKontrol
{
  public class itemEkleme : UserControl
  {
    private IContainer components = (IContainer) null;
    private Panel panel1;
    private Label label1;
    private ListBox listNPC;
    private Panel panel2;
    private Panel panel3;
    private FlowLayoutPanel flwGrup;
    private Panel pnlOrta;
    private GroupBox grFiyat;
    private TextBox txtGoldCoin;
    private TextBox txtSoldiers;
    private Label label7;
    private Label label4;
    private TextBox txtHonor;
    private TextBox txtMonks;
    private Label label6;
    private Label label3;
    private TextBox txtGenerals;
    private Label label5;
    private TextBox txtGold;
    private Label label2;
    private GroupBox grIslem;
    private Button btnKaydet;
    private Button btnSil;
    private Button btnDuzenle;
    private Button btnVazgec;
    private Button btnTumu;
    public ProgressBar proDurum;
    private TextBox txtSilverCoin;
    private Label label8;
    private Button btnYeniItem;
    private Label lblAdi;
    private TextBox txtIronCoin;
    private TextBox txtGuildPoint;
    private Label label11;
    private Label label9;
    private TextBox txtArenaCoin;
    private TextBox txtCopperCoin;
    private Label label12;
    private Label label10;
    public string gelenItem = "";
    public string Dur_L = "";
    public string icon = "";
    public bool yeni = false;
    private dataSet dataset;
    private TabControl tc;
    private DataTable _RefShopGoods;
    private DataTable _RefShop;
    private DataTable _RefShopTabGroup;
    private DataTable _RefShopTab;
    private DataTable _RefPackageItem;
    private DataTable _RefPricePolicyOfItem;
    private DataTable _RefObjCommon;
    private DataTable _RefObjItem;
    private DataTable _RefScrapOfPackageItem;
    private string dizin = "";
    private string itemAdi = "";
    private string slotNo = "";
    private Label lbl1 = new Label();
    private Label lbl2 = new Label();
    private Label lbl4 = new Label();
    private Label lbl8 = new Label();
    private Label lbl16 = new Label();
    private Label lbl32 = new Label();
    private Label lbl64 = new Label();
    private Label lbl128 = new Label();
    private Label lbl256 = new Label();
    private Label lbl512 = new Label();
    private Label lbl1024 = new Label();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listNPC = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.proDurum = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flwGrup = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlOrta = new System.Windows.Forms.Panel();
            this.lblAdi = new System.Windows.Forms.Label();
            this.grFiyat = new System.Windows.Forms.GroupBox();
            this.txtIronCoin = new System.Windows.Forms.TextBox();
            this.txtGuildPoint = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHonor = new System.Windows.Forms.TextBox();
            this.txtGoldCoin = new System.Windows.Forms.TextBox();
            this.txtSoldiers = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSilverCoin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtArenaCoin = new System.Windows.Forms.TextBox();
            this.txtCopperCoin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGenerals = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGold = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grIslem = new System.Windows.Forms.GroupBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnYeniItem = new System.Windows.Forms.Button();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnTumu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grFiyat.SuspendLayout();
            this.grIslem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listNPC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 502);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NPC\'ler :";
            // 
            // listNPC
            // 
            this.listNPC.ForeColor = System.Drawing.Color.Black;
            this.listNPC.FormattingEnabled = true;
            this.listNPC.Location = new System.Drawing.Point(4, 37);
            this.listNPC.Name = "listNPC";
            this.listNPC.Size = new System.Drawing.Size(188, 459);
            this.listNPC.TabIndex = 0;
            this.listNPC.SelectedIndexChanged += new System.EventHandler(this.listNPC_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.proDurum);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(201, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(599, 42);
            this.panel2.TabIndex = 1;
            // 
            // proDurum
            // 
            this.proDurum.ForeColor = System.Drawing.Color.Maroon;
            this.proDurum.Location = new System.Drawing.Point(6, 13);
            this.proDurum.Name = "proDurum";
            this.proDurum.Size = new System.Drawing.Size(571, 23);
            this.proDurum.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.flwGrup);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(201, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(599, 79);
            this.panel3.TabIndex = 2;
            // 
            // flwGrup
            // 
            this.flwGrup.ForeColor = System.Drawing.Color.Maroon;
            this.flwGrup.Location = new System.Drawing.Point(7, 17);
            this.flwGrup.Name = "flwGrup";
            this.flwGrup.Size = new System.Drawing.Size(571, 44);
            this.flwGrup.TabIndex = 0;
            // 
            // pnlOrta
            // 
            this.pnlOrta.BackColor = System.Drawing.Color.Transparent;
            this.pnlOrta.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOrta.ForeColor = System.Drawing.Color.Black;
            this.pnlOrta.Location = new System.Drawing.Point(201, 121);
            this.pnlOrta.Name = "pnlOrta";
            this.pnlOrta.Size = new System.Drawing.Size(242, 381);
            this.pnlOrta.TabIndex = 3;
            // 
            // lblAdi
            // 
            this.lblAdi.AutoSize = true;
            this.lblAdi.BackColor = System.Drawing.Color.Transparent;
            this.lblAdi.Location = new System.Drawing.Point(448, 129);
            this.lblAdi.Name = "lblAdi";
            this.lblAdi.Size = new System.Drawing.Size(0, 13);
            this.lblAdi.TabIndex = 7;
            // 
            // grFiyat
            // 
            this.grFiyat.BackColor = System.Drawing.Color.Transparent;
            this.grFiyat.Controls.Add(this.txtIronCoin);
            this.grFiyat.Controls.Add(this.txtGuildPoint);
            this.grFiyat.Controls.Add(this.label6);
            this.grFiyat.Controls.Add(this.txtHonor);
            this.grFiyat.Controls.Add(this.txtGoldCoin);
            this.grFiyat.Controls.Add(this.txtSoldiers);
            this.grFiyat.Controls.Add(this.label11);
            this.grFiyat.Controls.Add(this.label9);
            this.grFiyat.Controls.Add(this.label7);
            this.grFiyat.Controls.Add(this.label4);
            this.grFiyat.Controls.Add(this.txtMonks);
            this.grFiyat.Controls.Add(this.label3);
            this.grFiyat.Controls.Add(this.txtSilverCoin);
            this.grFiyat.Controls.Add(this.label8);
            this.grFiyat.Controls.Add(this.txtArenaCoin);
            this.grFiyat.Controls.Add(this.txtCopperCoin);
            this.grFiyat.Controls.Add(this.label12);
            this.grFiyat.Controls.Add(this.label10);
            this.grFiyat.Controls.Add(this.txtGenerals);
            this.grFiyat.Controls.Add(this.label5);
            this.grFiyat.Controls.Add(this.txtGold);
            this.grFiyat.Controls.Add(this.label2);
            this.grFiyat.ForeColor = System.Drawing.Color.Yellow;
            this.grFiyat.Location = new System.Drawing.Point(450, 160);
            this.grFiyat.Name = "grFiyat";
            this.grFiyat.Size = new System.Drawing.Size(286, 206);
            this.grFiyat.TabIndex = 4;
            this.grFiyat.TabStop = false;
            this.grFiyat.Text = "İtem Satış Fiyatları";
            // 
            // txtIronCoin
            // 
            this.txtIronCoin.BackColor = System.Drawing.SystemColors.Window;
            this.txtIronCoin.ForeColor = System.Drawing.Color.Black;
            this.txtIronCoin.Location = new System.Drawing.Point(106, 80);
            this.txtIronCoin.Name = "txtIronCoin";
            this.txtIronCoin.Size = new System.Drawing.Size(68, 20);
            this.txtIronCoin.TabIndex = 514;
            this.txtIronCoin.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // txtGuildPoint
            // 
            this.txtGuildPoint.BackColor = System.Drawing.SystemColors.Window;
            this.txtGuildPoint.ForeColor = System.Drawing.Color.Black;
            this.txtGuildPoint.Location = new System.Drawing.Point(106, 124);
            this.txtGuildPoint.Name = "txtGuildPoint";
            this.txtGuildPoint.Size = new System.Drawing.Size(68, 20);
            this.txtGuildPoint.TabIndex = 514;
            this.txtGuildPoint.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(200, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Honor";
            // 
            // txtHonor
            // 
            this.txtHonor.BackColor = System.Drawing.SystemColors.Window;
            this.txtHonor.ForeColor = System.Drawing.Color.Black;
            this.txtHonor.Location = new System.Drawing.Point(202, 80);
            this.txtHonor.Name = "txtHonor";
            this.txtHonor.Size = new System.Drawing.Size(68, 20);
            this.txtHonor.TabIndex = 32;
            this.txtHonor.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // txtGoldCoin
            // 
            this.txtGoldCoin.BackColor = System.Drawing.SystemColors.Window;
            this.txtGoldCoin.ForeColor = System.Drawing.Color.Black;
            this.txtGoldCoin.Location = new System.Drawing.Point(106, 36);
            this.txtGoldCoin.Name = "txtGoldCoin";
            this.txtGoldCoin.Size = new System.Drawing.Size(68, 20);
            this.txtGoldCoin.TabIndex = 512;
            this.txtGoldCoin.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // txtSoldiers
            // 
            this.txtSoldiers.BackColor = System.Drawing.SystemColors.Window;
            this.txtSoldiers.ForeColor = System.Drawing.Color.Black;
            this.txtSoldiers.Location = new System.Drawing.Point(10, 170);
            this.txtSoldiers.Name = "txtSoldiers";
            this.txtSoldiers.Size = new System.Drawing.Size(68, 20);
            this.txtSoldiers.TabIndex = 4;
            this.txtSoldiers.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(107, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 513;
            this.label11.Text = "Iron Coin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(107, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 513;
            this.label9.Text = "Guild Point";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(107, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Gold Coin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Soldier\'s Token";
            // 
            // txtMonks
            // 
            this.txtMonks.BackColor = System.Drawing.SystemColors.Window;
            this.txtMonks.ForeColor = System.Drawing.Color.Black;
            this.txtMonks.Location = new System.Drawing.Point(202, 125);
            this.txtMonks.Name = "txtMonks";
            this.txtMonks.Size = new System.Drawing.Size(68, 20);
            this.txtMonks.TabIndex = 2;
            this.txtMonks.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(200, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Monk\'s Token";
            // 
            // txtSilverCoin
            // 
            this.txtSilverCoin.BackColor = System.Drawing.SystemColors.Window;
            this.txtSilverCoin.ForeColor = System.Drawing.Color.Black;
            this.txtSilverCoin.Location = new System.Drawing.Point(202, 35);
            this.txtSilverCoin.Name = "txtSilverCoin";
            this.txtSilverCoin.Size = new System.Drawing.Size(68, 20);
            this.txtSilverCoin.TabIndex = 16;
            this.txtSilverCoin.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(200, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Silver Coin";
            // 
            // txtArenaCoin
            // 
            this.txtArenaCoin.BackColor = System.Drawing.SystemColors.Window;
            this.txtArenaCoin.ForeColor = System.Drawing.Color.Black;
            this.txtArenaCoin.Location = new System.Drawing.Point(10, 125);
            this.txtArenaCoin.Name = "txtArenaCoin";
            this.txtArenaCoin.Size = new System.Drawing.Size(68, 20);
            this.txtArenaCoin.TabIndex = 16;
            this.txtArenaCoin.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // txtCopperCoin
            // 
            this.txtCopperCoin.BackColor = System.Drawing.SystemColors.Window;
            this.txtCopperCoin.ForeColor = System.Drawing.Color.Black;
            this.txtCopperCoin.Location = new System.Drawing.Point(10, 80);
            this.txtCopperCoin.Name = "txtCopperCoin";
            this.txtCopperCoin.Size = new System.Drawing.Size(68, 20);
            this.txtCopperCoin.TabIndex = 16;
            this.txtCopperCoin.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(10, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Arena Coin";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(10, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Copper Coin";
            // 
            // txtGenerals
            // 
            this.txtGenerals.BackColor = System.Drawing.SystemColors.Window;
            this.txtGenerals.ForeColor = System.Drawing.Color.Black;
            this.txtGenerals.Location = new System.Drawing.Point(106, 168);
            this.txtGenerals.Name = "txtGenerals";
            this.txtGenerals.Size = new System.Drawing.Size(68, 20);
            this.txtGenerals.TabIndex = 16;
            this.txtGenerals.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(107, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "General\'s Token";
            // 
            // txtGold
            // 
            this.txtGold.BackColor = System.Drawing.SystemColors.Window;
            this.txtGold.ForeColor = System.Drawing.Color.Black;
            this.txtGold.Location = new System.Drawing.Point(10, 35);
            this.txtGold.Name = "txtGold";
            this.txtGold.Size = new System.Drawing.Size(68, 20);
            this.txtGold.TabIndex = 1;
            this.txtGold.TextChanged += new System.EventHandler(this.txtGold_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gold";
            // 
            // grIslem
            // 
            this.grIslem.BackColor = System.Drawing.Color.Transparent;
            this.grIslem.Controls.Add(this.btnKaydet);
            this.grIslem.Controls.Add(this.btnYeniItem);
            this.grIslem.Controls.Add(this.btnVazgec);
            this.grIslem.Controls.Add(this.btnSil);
            this.grIslem.Controls.Add(this.btnDuzenle);
            this.grIslem.ForeColor = System.Drawing.Color.Yellow;
            this.grIslem.Location = new System.Drawing.Point(451, 376);
            this.grIslem.Name = "grIslem";
            this.grIslem.Size = new System.Drawing.Size(285, 80);
            this.grIslem.TabIndex = 5;
            this.grIslem.TabStop = false;
            this.grIslem.Text = "Yapılacak İşlemler";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Lavender;
            this.btnKaydet.ForeColor = System.Drawing.Color.Black;
            this.btnKaydet.Location = new System.Drawing.Point(9, 49);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(142, 23);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYeniItem
            // 
            this.btnYeniItem.BackColor = System.Drawing.Color.Lavender;
            this.btnYeniItem.ForeColor = System.Drawing.Color.Black;
            this.btnYeniItem.Location = new System.Drawing.Point(161, 49);
            this.btnYeniItem.Name = "btnYeniItem";
            this.btnYeniItem.Size = new System.Drawing.Size(118, 23);
            this.btnYeniItem.TabIndex = 0;
            this.btnYeniItem.Text = "Yeni İtem Ekle";
            this.btnYeniItem.UseVisualStyleBackColor = false;
            this.btnYeniItem.Click += new System.EventHandler(this.btnYeniItem_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.BackColor = System.Drawing.Color.Lavender;
            this.btnVazgec.ForeColor = System.Drawing.Color.Black;
            this.btnVazgec.Location = new System.Drawing.Point(161, 20);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(118, 23);
            this.btnVazgec.TabIndex = 0;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = false;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Lavender;
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(83, 20);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(68, 23);
            this.btnSil.TabIndex = 0;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.Lavender;
            this.btnDuzenle.ForeColor = System.Drawing.Color.Black;
            this.btnDuzenle.Location = new System.Drawing.Point(9, 20);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(68, 23);
            this.btnDuzenle.TabIndex = 0;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnTumu
            // 
            this.btnTumu.BackColor = System.Drawing.Color.Lavender;
            this.btnTumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTumu.ForeColor = System.Drawing.Color.Black;
            this.btnTumu.Location = new System.Drawing.Point(522, 461);
            this.btnTumu.Name = "btnTumu";
            this.btnTumu.Size = new System.Drawing.Size(139, 31);
            this.btnTumu.TabIndex = 6;
            this.btnTumu.Text = "Tüm İşlemleri Kaydet";
            this.btnTumu.UseVisualStyleBackColor = false;
            this.btnTumu.Click += new System.EventHandler(this.btnTumu_Click);
            // 
            // itemEkleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.lblAdi);
            this.Controls.Add(this.btnTumu);
            this.Controls.Add(this.grIslem);
            this.Controls.Add(this.grFiyat);
            this.Controls.Add(this.pnlOrta);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "itemEkleme";
            this.Size = new System.Drawing.Size(800, 502);
            this.Load += new System.EventHandler(this.itemEkleme_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grFiyat.ResumeLayout(false);
            this.grFiyat.PerformLayout();
            this.grIslem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    public itemEkleme() => this.InitializeComponent();

    private void itemEkleme_Load(object sender, EventArgs e)
    {
      this.dizin = Path.GetDirectoryName(Application.ExecutablePath) + "\\MedyayaEklenecekDosyalar";
      this.proDurum.Minimum = 0;
      this.proDurum.Step = 1;
      this.proDurum.Visible = false;
      this.NPCDoldur();
      this.grFiyat.Enabled = false;
      this.grFiyat.Visible = false;
      this.grIslem.Visible = false;
      this.btnTumu.Enabled = false;
    }

    public void DatasetOlustur()
    {
      this.dataset = new dataSet();
      this._RefShop = this.dataset.Tablo("_RefShop");
      Application.DoEvents();
      this._RefShopTabGroup = this.dataset.Tablo("_RefShopTabGroup");
      Application.DoEvents();
      this._RefShopTab = this.dataset.Tablo("_RefShopTab");
      Application.DoEvents();
      this._RefShopGoods = this.dataset.Tablo("_RefShopGoods");
      Application.DoEvents();
      this._RefPackageItem = this.dataset.Tablo("_RefPackageItem");
      Application.DoEvents();
      this._RefPricePolicyOfItem = this.dataset.Tablo("_RefPricePolicyOfItem");
      Application.DoEvents();
      this._RefObjCommon = this.dataset.Tablo("_RefObjCommon");
      Application.DoEvents();
      this._RefObjItem = this.dataset.Tablo("_RefObjItem");
      Application.DoEvents();
      this._RefScrapOfPackageItem = this.dataset.Tablo("_RefScrapOfPackageItem");
      Application.DoEvents();
    }

    private void NPCDoldur()
    {
      this.proDurum.Maximum = this._RefShop.Rows.Count;
      this.proDurum.Visible = true;
      int num = 0;
      foreach (DataRow row in (InternalDataCollectionBase) this._RefShop.Rows)
      {
        if (row[3].ToString().IndexOf("STORE_") != -1 && row["Service"].ToString() == "1")
          this.listNPC.Items.Add(row[3]);
        ++num;
        Application.DoEvents();
        this.proDurum.Value = num;
      }
      this.proDurum.Visible = false;
    }

    private void listNPC_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.lblAdi.Text = "";
      this.grFiyat.Visible = false;
      this.grFiyat.Enabled = false;
      this.grIslem.Visible = false;
      this.pnlOrta.Controls.Clear();
      this.flwGrup.Controls.Clear();
      this.proDurum.Maximum = this._RefShopTabGroup.Rows.Count;
      this.proDurum.Visible = true;
      this._RefShopTabGroup.NewRow();
      int num = 0;
      foreach (DataRow row in (InternalDataCollectionBase) this._RefShopTabGroup.Rows)
      {
        if (row["CodeName128"].ToString().IndexOf(this.listNPC.Text) != -1 && row["Service"].ToString() == "1")
        {
          Button button = new Button();
          button.Text = row["CodeName128"].ToString().Substring(this.listNPC.Text.Length + 1);
          button.Name = row["CodeName128"].ToString();
          button.Width = 100;
          button.BackColor = Color.LightSteelBlue;
          button.ForeColor = Color.Maroon;
          button.Click += new EventHandler(this.btnGrup_Click);
          this.flwGrup.Controls.Add((Control) button);
        }
        ++num;
        Application.DoEvents();
        this.proDurum.Value = num;
      }
      this.proDurum.Visible = false;
    }

    private void btnGrup_Click(object sender, EventArgs e)
    {
      this.grFiyat.Visible = false;
      this.grFiyat.Enabled = false;
      this.grIslem.Visible = false;
      this.pnlOrta.Controls.Clear();
      string name = (sender as Button).Name;
      this.proDurum.Maximum = this._RefShopTab.Rows.Count;
      this.tc = new TabControl();
      this.tc.Location = new Point(6, 7);
      this.tc.Size = new Size(236, (int) byte.MaxValue);
      this.tc.Selecting += new TabControlCancelEventHandler(this.tc_Selecting);
      this.pnlOrta.Controls.Add((Control) this.tc);
      this.proDurum.Visible = true;
      int num1 = 0;
      int num2 = 1;
      foreach (DataRow row in (InternalDataCollectionBase) this._RefShopTab.Rows)
      {
        if (row["RefTabGroupCodeName"].ToString() == name && row["Service"].ToString() == "1")
        {
          TabPage tabPage = new TabPage();
          tabPage.Text = "TAB " + (object) num2;
          tabPage.Name = row["CodeName128"].ToString();
          Button button1 = new Button();
          button1.Size = new Size(23, 23);
          button1.Location = new Point(83, 201);
          button1.Text = "<";
          button1.Click += new EventHandler(this.btnGeri_Click);
          Button button2 = new Button();
          button2.Size = new Size(23, 23);
          button2.Location = new Point(125, 201);
          button2.Text = ">";
          button2.Click += new EventHandler(this.btnIleri_Click);
          Label label = new Label();
          label.Location = new Point(106, 206);
          label.Text = "1";
          label.Size = new Size(19, 13);
          label.BackColor = Color.Transparent;
          label.TextAlign = ContentAlignment.MiddleCenter;
          FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
          flowLayoutPanel.BackColor = Color.Black;
          flowLayoutPanel.Dock = DockStyle.Top;
          flowLayoutPanel.Size = new Size(234, 194);
          tabPage.Controls.Add((Control) button1);
          tabPage.Controls.Add((Control) button2);
          tabPage.Controls.Add((Control) label);
          tabPage.Controls.Add((Control) flowLayoutPanel);
          this.tc.Controls.Add((Control) tabPage);
          ++num2;
        }
        ++num1;
        Application.DoEvents();
        this.proDurum.Value = num1;
      }
      this.proDurum.Visible = false;
      this.SlotYukle();
      this.grFiyat.Visible = true;
      this.grIslem.Visible = true;
      this.grIslem.Enabled = false;
    }

    private void btnIleri_Click(object sender, EventArgs e)
    {
      Label childAtPoint = this.tc.SelectedTab.GetChildAtPoint(new Point(106, 206)) as Label;
      int int16 = (int) Convert.ToInt16(childAtPoint.Text);
      if (int16 >= 100)
        return;
      int num = int16 + 1;
      childAtPoint.Text = num.ToString();
      this.SlotYukle();
    }

    private void btnGeri_Click(object sender, EventArgs e)
    {
      Label childAtPoint = this.tc.SelectedTab.GetChildAtPoint(new Point(106, 206)) as Label;
      int int16 = (int) Convert.ToInt16(childAtPoint.Text);
      if (int16 <= 1)
        return;
      int num = int16 - 1;
      childAtPoint.Text = num.ToString();
      this.SlotYukle();
    }

    private void tc_Selecting(object sender, TabControlCancelEventArgs e)
    {
      this.grFiyat.Enabled = false;
      this.grIslem.Enabled = false;
      this.SlotYukle();
    }

    private DataRow[] BulunanItemler()
    {
      DataRow[] dataRowArray = this._RefShopGoods.Select("RefTabCodeName='" + this.tc.SelectedTab.Name + "' AND Service=1", "SlotIndex");
      int length = dataRowArray.Length;
      return dataRowArray;
    }

    private void SlotYukle()
    {
      this.grFiyat.Enabled = false;
      this.grIslem.Enabled = false;
      this.txtGold.Text = "";
      this.txtMonks.Text = "";
      this.txtGenerals.Text = "";
      this.txtGuildPoint.Text = "";
      this.txtSoldiers.Text = "";
      this.txtHonor.Text = "";
      this.txtCopperCoin.Text = "";
      this.txtIronCoin.Text = "";
      this.txtSilverCoin.Text = "";
      this.txtGoldCoin.Text = "";
      this.txtArenaCoin.Text = "";
      Label childAtPoint1 = this.tc.SelectedTab.GetChildAtPoint(new Point(106, 206)) as Label;
      FlowLayoutPanel childAtPoint2 = this.tc.SelectedTab.GetChildAtPoint(new Point(3, 3)) as FlowLayoutPanel;
      childAtPoint2.Controls.Clear();
      int int16 = (int) Convert.ToInt16(childAtPoint1.Text);
      int num1 = int16 * 30 - 30;
      int num2 = int16 * 30;
      DataRow[] dataRowArray = this.BulunanItemler();
      this.proDurum.Maximum = 30;
      int num3 = 0;
      this.proDurum.Visible = true;
      for (int index = num1; index < num2; ++index)
      {
        Button button = new Button();
        button.Size = new Size(32, 32);
        button.BackColor = Color.Black;
        button.Click += new EventHandler(this.btn_Click);
        button.TabIndex = index;
        childAtPoint2.Controls.Add((Control) button);
        foreach (DataRow dataRow in dataRowArray)
        {
          if (index.ToString() == dataRow["SlotIndex"].ToString())
          {
            button.Name = dataRow["RefPackageItemCodeName"].ToString();
            foreach (DataRow row in (InternalDataCollectionBase) this._RefPackageItem.Rows)
            {
              if (row.RowState != DataRowState.Deleted && row["CodeName128"].ToString() == dataRow["RefPackageItemCodeName"].ToString())
              {
                row["CodeName128"].ToString();
                string[] strArray = row["AssocFileIcon"].ToString().Split('.');
                string str = Path.GetDirectoryName(Application.ExecutablePath) + "\\icon\\";
                if (File.Exists(str + strArray[0] + ".PNG"))
                {
                  button.BackgroundImage = Image.FromFile(str + strArray[0] + ".PNG");
                  break;
                }
                button.BackgroundImage = Image.FromFile(str + "icon_default.PNG");
                break;
              }
            }
          }
        }
        if (button.Name == "")
        {
          button.ForeColor = Color.White;
          button.Text = index.ToString();
        }
        ++num3;
        Application.DoEvents();
        this.proDurum.Value = num3;
      }
      this.proDurum.Visible = false;
    }

    private void btn_Click(object sender, EventArgs e)
    {
      this.txtGold.Text = "";
      this.txtMonks.Text = "";
      this.txtGenerals.Text = "";
      this.txtGuildPoint.Text = "";
      this.txtSoldiers.Text = "";
      this.txtHonor.Text = "";
      this.txtCopperCoin.Text = "";
      this.txtIronCoin.Text = "";
      this.txtSilverCoin.Text = "";
      this.txtGoldCoin.Text = "";
      this.txtArenaCoin.Text = "";
      string str1 = "";
      string str2 = "";
      Button button = sender as Button;
      this.itemAdi = button.Name;
      this.slotNo = button.TabIndex.ToString();
      this.lblAdi.Text = this.itemAdi;
      if (button.Text != "")
      {
        this.grFiyat.Enabled = false;
        this.grIslem.Enabled = true;
        this.btnVazgec.Enabled = false;
        this.btnKaydet.Enabled = false;
        this.btnYeniItem.Enabled = true;
        this.btnSil.Enabled = false;
        this.btnDuzenle.Enabled = false;
      }
      else
      {
        this.grIslem.Enabled = true;
        this.grFiyat.Enabled = false;
        foreach (DataRow row in (InternalDataCollectionBase) this._RefPricePolicyOfItem.Rows)
        {
          if (row.RowState != DataRowState.Deleted && button.Name == row["RefPackageItemCodeName"].ToString())
          {
            str1 = str1 + "," + row["PaymentDevice"].ToString();
            str2 = str2 + "," + row["Cost"].ToString();
          }
        }
        string[] strArray1 = str1.Split(',');
        string[] strArray2 = str2.Split(',');
        for (int index = 1; index < strArray1.Length; ++index)
        {
          if (strArray1[index] == "1")
            this.txtGold.Text = strArray2[index];
          else if (strArray1[index] == "8192")
            this.txtMonks.Text = strArray2[index];
          else if (strArray1[index] == "32768")
            this.txtGenerals.Text = strArray2[index];
          else if (strArray1[index] == "8")
            this.txtGuildPoint.Text = strArray2[index];
          else if (strArray1[index] == "16384")
            this.txtSoldiers.Text = strArray2[index];
          else if (strArray1[index] == "32")
            this.txtHonor.Text = strArray2[index];
          else if (strArray1[index] == "64")
            this.txtCopperCoin.Text = strArray2[index];
          else if (strArray1[index] == "128")
            this.txtIronCoin.Text = strArray2[index];
          else if (strArray1[index] == "256")
            this.txtSilverCoin.Text = strArray2[index];
          else if (strArray1[index] == "512")
            this.txtGoldCoin.Text = strArray2[index];
          else if (strArray1[index] == "1024")
          {
            this.txtArenaCoin.Text = strArray2[index];
          }
          else
          {
            int num = (int) MessageBox.Show(strArray1[index] + " ile şu fiyata " + strArray2[index] + " ile satılıyor");
          }
        }
        this.lbl1.Text = this.txtGold.Text;
        this.lbl2.Text = this.txtMonks.Text;
        this.lbl4.Text = this.txtGenerals.Text;
        this.lbl8.Text = this.txtGuildPoint.Text;
        this.lbl16.Text = this.txtSoldiers.Text;
        this.lbl32.Text = this.txtHonor.Text;
        this.lbl64.Text = this.txtCopperCoin.Text;
        this.lbl128.Text = this.txtIronCoin.Text;
        this.lbl256.Text = this.txtSilverCoin.Text;
        this.lbl512.Text = this.txtGoldCoin.Text;
        this.lbl1024.Text = this.txtArenaCoin.Text;
        this.btnVazgec.Enabled = false;
        this.btnKaydet.Enabled = false;
        this.btnYeniItem.Enabled = false;
        this.btnSil.Enabled = true;
        this.btnDuzenle.Enabled = true;
      }
    }

    private void txtGold_TextChanged(object sender, EventArgs e)
    {
      this.btnVazgec.Enabled = true;
      this.btnKaydet.Enabled = true;
    }

    private void btnDuzenle_Click(object sender, EventArgs e)
    {
      this.pnlOrta.Enabled = false;
      this.btnDuzenle.Enabled = false;
      this.btnSil.Enabled = false;
      this.grFiyat.Enabled = true;
      this.btnTumu.Enabled = false;
      this.btnVazgec.Enabled = true;
    }

    private void btnVazgec_Click(object sender, EventArgs e)
    {
      this.txtGold.Text = this.lbl1.Text;
      this.txtMonks.Text = this.lbl2.Text;
      this.txtGenerals.Text = this.lbl4.Text;
      this.txtGuildPoint.Text = this.lbl8.Text;
      this.txtSoldiers.Text = this.lbl16.Text;
      this.txtHonor.Text = this.lbl32.Text;
      this.txtCopperCoin.Text = this.lbl64.Text;
      this.txtIronCoin.Text = this.lbl128.Text;
      this.txtSilverCoin.Text = this.lbl256.Text;
      this.txtGoldCoin.Text = this.lbl512.Text;
      this.txtArenaCoin.Text = this.lbl1024.Text;
      this.btnDuzenle.Enabled = true;
      this.btnSil.Enabled = true;
      this.btnKaydet.Enabled = false;
      this.btnVazgec.Enabled = false;
      this.grFiyat.Enabled = false;
      this.pnlOrta.Enabled = true;
      this.btnTumu.Enabled = true;
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
      foreach (DataRow row in (InternalDataCollectionBase) this._RefShopGoods.Rows)
      {
        if (row.RowState != DataRowState.Deleted && row["RefPackageItemCodeName"].ToString() == this.itemAdi && row["RefTabCodeName"].ToString() == this.tc.SelectedTab.Name)
        {
          row.Delete();
          break;
        }
      }
      this.SlotYukle();
      this.btnTumu.Enabled = true;
    }

    private void btnTumu_Click(object sender, EventArgs e)
    {
      DataTable[] dataTableArray = new DataTable[4]
      {
        this._RefPackageItem,
        this._RefPricePolicyOfItem,
        this._RefShopGoods,
        this._RefScrapOfPackageItem
      };
      int num = (int) new Uyari1()
      {
        tablolar = dataTableArray,
        ds = this.dataset
      }.ShowDialog();
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      this.btnDuzenle.Enabled = true;
      this.btnSil.Enabled = true;
      this.btnKaydet.Enabled = false;
      this.btnVazgec.Enabled = false;
      this.grFiyat.Enabled = false;
      this.pnlOrta.Enabled = true;
      this.btnTumu.Enabled = true;
      string[] strArray1 = new string[11]
      {
        this.txtGold.Text,
        this.txtMonks.Text,
        this.txtGenerals.Text,
        this.txtGuildPoint.Text,
        this.txtSoldiers.Text,
        this.txtHonor.Text,
        this.txtCopperCoin.Text,
        this.txtIronCoin.Text,
        this.txtSilverCoin.Text,
        this.txtGoldCoin.Text,
        this.txtArenaCoin.Text
      };
      string str = "";
      this.proDurum.Maximum = strArray1.Length;
      this.proDurum.Visible = true;
      for (int index = 0; index < strArray1.Length; ++index)
      {
        bool flag = false;
        switch (index)
        {
          case 0:
            str = "1";
            break;
          case 1:
            str = "8192";
            break;
          case 2:
            str = "32768";
            break;
          case 3:
            str = "8";
            break;
          case 4:
            str = "16384";
            break;
          case 5:
            str = "32";
            break;
          case 6:
            str = "64";
            break;
          case 7:
            str = "128";
            break;
          case 8:
            str = "256";
            break;
          case 9:
            str = "512";
            break;
          case 10:
            str = "1024";
            break;
        }
        foreach (DataRow row in (InternalDataCollectionBase) this._RefPricePolicyOfItem.Rows)
        {
          if (row.RowState != DataRowState.Deleted && row["RefPackageItemCodeName"].ToString() == this.itemAdi && row["PaymentDevice"].ToString() == str)
          {
            if (strArray1[index] == "")
              row.Delete();
            else
              row["Cost"] = (object) strArray1[index];
            flag = true;
            break;
          }
        }
        if (strArray1[index] != "" && !flag)
        {
          string[] strArray2 = new string[15]
          {
            "1",
            "15",
            this.itemAdi,
            str,
            "0",
            strArray1[index],
            "-1",
            "xxx",
            "-1",
            "xxx",
            "-1",
            "xxx",
            "-1",
            "xxx",
            "1"
          };
          DataRow row = this._RefPricePolicyOfItem.NewRow();
          for (int columnIndex = 0; columnIndex < this._RefPricePolicyOfItem.Columns.Count; ++columnIndex)
            row[columnIndex] = (object) strArray2[columnIndex];
          this._RefPricePolicyOfItem.Rows.Add(row);
        }
        this.proDurum.Value = index;
        Application.DoEvents();
      }
      this.proDurum.Visible = false;
      this.SlotYukle();
      this.btnTumu.Enabled = true;
    }

    private void btnYeniItem_Click(object sender, EventArgs e)
    {
      Ekle ekle = new Ekle();
      ekle.ekle = this;
      DataTable[] dataTableArray = new DataTable[6]
      {
        this._RefPackageItem,
        this._RefPricePolicyOfItem,
        this._RefShopGoods,
        this._RefScrapOfPackageItem,
        this._RefObjCommon,
        this._RefObjItem
      };
      ekle.tablo = dataTableArray;
      int num = (int) ekle.ShowDialog();
    }

    public void itemEkle()
    {
      this.flwGrup.Enabled = false;
      this.pnlOrta.Enabled = false;
      this.listNPC.Enabled = false;
      this.grFiyat.Enabled = false;
      this.grIslem.Enabled = false;
      if (this.yeni)
      {
        this.EkliOlmayan();
        this.btnTumu.Enabled = true;
        this.flwGrup.Enabled = true;
        this.pnlOrta.Enabled = true;
        this.listNPC.Enabled = true;
        this.grFiyat.Enabled = false;
        this.grIslem.Enabled = false;
      }
      else
      {
        this.EklItem();
        this.btnTumu.Enabled = true;
        this.flwGrup.Enabled = true;
        this.pnlOrta.Enabled = true;
        this.listNPC.Enabled = true;
        this.grFiyat.Enabled = false;
        this.grIslem.Enabled = false;
      }
    }

    private void EklItem()
    {
      foreach (DataRow row in (InternalDataCollectionBase) this._RefPackageItem.Rows)
      {
        if (row["CodeName128"].ToString() == this.gelenItem && row["Service"].ToString() == "0")
        {
          row["Service"] = (object) "1";
          break;
        }
      }
      bool flag = false;
      foreach (DataRow row in (InternalDataCollectionBase) this._RefScrapOfPackageItem.Rows)
      {
        if (row["RefPackageItemCodeName"].ToString() == this.gelenItem)
        {
          if (row["Service"].ToString() == "0")
          {
            row["Service"] = (object) "1";
            flag = true;
            break;
          }
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        string[] strArray = new string[29]
        {
          "1",
          "15",
          this.gelenItem,
          this.gelenItem.Substring(8),
          "0",
          "0",
          this.Dur_L,
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "-1",
          "xxx",
          "-1",
          "xxx",
          "-1",
          "xxx",
          "-1",
          "xxx",
          "1"
        };
        DataRow row = this._RefScrapOfPackageItem.NewRow();
        for (int columnIndex = 0; columnIndex < this._RefScrapOfPackageItem.Columns.Count; ++columnIndex)
          row[columnIndex] = (object) strArray[columnIndex];
        this._RefScrapOfPackageItem.Rows.Add(row);
      }
      DataRow row1 = this._RefShopGoods.NewRow();
      string[] strArray1 = new string[14]
      {
        "1",
        "15",
        this.tc.SelectedTab.Name,
        this.gelenItem,
        this.slotNo,
        "-1",
        "xxx",
        "-1",
        "xxx",
        "-1",
        "xxx",
        "-1",
        "xxx",
        "2"
      };
      for (int columnIndex = 0; columnIndex < this._RefShopGoods.Columns.Count; ++columnIndex)
        row1[columnIndex] = (object) strArray1[columnIndex];
      this._RefShopGoods.Rows.Add(row1);
      int num = (int) MessageBox.Show("İtem Başarıyla Eklendi Satış Fiyatı Eklemek veya Değiştirmek için\nİtemi Tıklayıp Düzenleyin");
      this.SlotYukle();
    }

    private void EkliOlmayan()
    {
      bool flag1 = false;
      foreach (DataRow row in (InternalDataCollectionBase) this._RefPackageItem.Rows)
      {
        if (row["CodeName128"].ToString() == "PACKAGE_" + this.gelenItem)
        {
          if (row["Service"].ToString() == "0")
          {
            row["Service"] = (object) "1";
            flag1 = true;
            break;
          }
          flag1 = true;
          break;
        }
      }
      if (!flag1)
      {
        DataRow row = this._RefPackageItem.NewRow();
        string[] strArray = new string[17]
        {
          "1",
          "15",
          "3",
          "PACKAGE_" + this.gelenItem,
          "0",
          "EXPAND_TERM_ALL",
          "SN_" + this.gelenItem,
          "SN_" + this.gelenItem + "_TT_DESC",
          this.icon,
          "-1",
          "xxx",
          "-1",
          "xxx",
          "-1",
          "xxx",
          "-1",
          "xxx"
        };
        for (int columnIndex = 0; columnIndex < this._RefPackageItem.Columns.Count; ++columnIndex)
          row[columnIndex] = (object) strArray[columnIndex];
        this._RefPackageItem.Rows.Add(row);
      }
      bool flag2 = false;
      foreach (DataRow row in (InternalDataCollectionBase) this._RefScrapOfPackageItem.Rows)
      {
        if (row["RefPackageItemCodeName"].ToString() == "PACKAGE_" + this.gelenItem)
        {
          if (row["Service"].ToString() == "0")
          {
            row["Service"] = (object) "1";
            flag2 = true;
            break;
          }
          flag2 = true;
          break;
        }
      }
      if (!flag2)
      {
        DataRow row = this._RefScrapOfPackageItem.NewRow();
        string[] strArray = new string[29]
        {
          "1",
          "15",
          "PACKAGE_" + this.gelenItem,
          this.gelenItem,
          "0",
          "0",
          this.Dur_L,
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "0",
          "-1",
          "xxx",
          "-1",
          "xxx",
          "-1",
          "xxx",
          "-1",
          "xxx",
          "146"
        };
        for (int columnIndex = 0; columnIndex < this._RefScrapOfPackageItem.Columns.Count; ++columnIndex)
          row[columnIndex] = (object) strArray[columnIndex];
        this._RefScrapOfPackageItem.Rows.Add(row);
      }
      DataRow row1 = this._RefShopGoods.NewRow();
      string[] strArray1 = new string[14]
      {
        "1",
        "15",
        this.tc.SelectedTab.Name,
        "PACKAGE_" + this.gelenItem,
        this.slotNo,
        "-1",
        "xxx",
        "-1",
        "xxx",
        "-1",
        "xxx",
        "-1",
        "xxx",
        "2"
      };
      for (int columnIndex = 0; columnIndex < this._RefShopGoods.Columns.Count; ++columnIndex)
        row1[columnIndex] = (object) strArray1[columnIndex];
      this._RefShopGoods.Rows.Add(row1);
      int num = (int) MessageBox.Show("İteminiz Başarıyla Eklendi\nLütfen Eklediğiniz İtemi Seçip Satışın Neyle Yapılacağını Giriniz.\nYoksa Hata Verir...");
      this.SlotYukle();
    }
  }
}
