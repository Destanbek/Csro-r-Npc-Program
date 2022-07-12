// Decompiled with JetBrains decompiler
// Type: vSRONPC.AnaMenu
// Assembly: vSRONPC, Version=1.0.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 1ABE91E6-4F3A-49F7-8F43-72B7B7C8A98F
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\CSRO1.239NPC.exe

using ArtiBasmaRenkAyari;
using item_mal;
using sqlDuzenle;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UserKontrol;

namespace CSRORNPC
{
  public class AnaMenu : Form
  {
    private bool tiklandiYeniNpc = false;
    private bool tiklandiItemEkleme = false;
    private bool tiklandiSosParlama = false;
    private bool tiklandiArti = false;
    private bool tiklandiSqlDuzenle = false;
    private bool tiklandiItemMall = false;
    private Control sahne = (Control) null;
    private NPCEkle npcEkle;
    private itemEkleme itemEkle;
    private rarParlamasi parlama;
    private ArtiRenkleri arti;
    private AraYuz sqlDuzenle;
    private magza itemMall;
    private string dizin = Path.GetDirectoryName(Application.ExecutablePath);
    private IContainer components = (IContainer) null;
    private Panel pnlZemin;
    private Label lblBilgi;
    private MenuStrip menu;
    internal ToolStripMenuItem btnBaglan;
    private ToolStripMenuItem btnYeniNpc;
    private ToolStripMenuItem btnItemEkleme;
    internal ToolStripMenuItem btnNPC;
    internal ToolStripMenuItem btnEfekt;
    private ToolStripMenuItem btnSosParlama;
    private ToolStripMenuItem btnArti;
    private ToolStripSeparator toolStripSeparator1;
    internal ToolStripMenuItem btnSqlDuzenle;
    private ToolStripMenuItem f10İTEMEKLEMESİLMEToolStripMenuItem;

    public AnaMenu() => this.InitializeComponent();

    private void AnaMenu_Load(object sender, EventArgs e)
    {
    }

    private void Baglan_Click(object sender, EventArgs e)
    {
      int num = (int) new Config() { anaMenu = this }.ShowDialog();
    }

    private void yeniNPC_Click(object sender, EventArgs e)
    {
      if (this.tiklandiYeniNpc)
        return;
      if (this.sahne != null)
        this.pnlZemin.Controls.Remove(this.sahne);
      this.lblBilgi.Visible = true;
      this.btnNPC.Enabled = false;
      this.btnEfekt.Enabled = false;
      this.btnSqlDuzenle.Enabled = false;
      this.npcEkle = new NPCEkle();
      this.npcEkle.dataSetOlustur();
      this.npcEkle.Location = new Point(0, 0);
      this.npcEkle.Dock = DockStyle.Fill;
      this.pnlZemin.Controls.Add((Control) this.npcEkle);
      this.lblBilgi.Visible = false;
      this.btnNPC.Enabled = true;
      this.btnEfekt.Enabled = true;
      this.btnSqlDuzenle.Enabled = true;
      this.tiklandiSqlDuzenle = false;
      this.tiklandiSosParlama = false;
      this.tiklandiYeniNpc = true;
      this.tiklandiItemEkleme = false;
      this.tiklandiArti = false;
      this.tiklandiItemMall = false;
      this.sahne = (Control) this.npcEkle;
    }

    private void btnItemEkleme_Click(object sender, EventArgs e)
    {
      if (this.tiklandiItemEkleme)
        return;
      if (this.sahne != null)
        this.pnlZemin.Controls.Remove(this.sahne);
      this.btnNPC.Enabled = false;
      this.btnEfekt.Enabled = false;
      this.btnSqlDuzenle.Enabled = false;
      this.lblBilgi.Visible = true;
      this.itemEkle = new itemEkleme();
      this.itemEkle.Location = new Point(0, 0);
      this.itemEkle.Dock = DockStyle.Fill;
      this.itemEkle.DatasetOlustur();
      this.pnlZemin.Controls.Add((Control) this.itemEkle);
      this.lblBilgi.Visible = false;
      this.btnNPC.Enabled = true;
      this.btnEfekt.Enabled = true;
      this.btnSqlDuzenle.Enabled = true;
      this.tiklandiSqlDuzenle = false;
      this.tiklandiSosParlama = false;
      this.tiklandiItemEkleme = true;
      this.tiklandiYeniNpc = false;
      this.tiklandiArti = false;
      this.tiklandiItemMall = false;
      this.sahne = (Control) this.itemEkle;
    }

    private void btnSosParlama_Click(object sender, EventArgs e)
    {
      if (this.tiklandiSosParlama)
        return;
      if (this.sahne != null)
        this.pnlZemin.Controls.Remove(this.sahne);
      this.btnNPC.Enabled = false;
      this.btnEfekt.Enabled = false;
      this.btnSqlDuzenle.Enabled = false;
      this.parlama = new rarParlamasi();
      this.parlama.Location = new Point(0, 0);
      this.parlama.Dock = DockStyle.Fill;
      this.pnlZemin.Controls.Add((Control) this.parlama);
      this.lblBilgi.Visible = false;
      this.btnNPC.Enabled = true;
      this.btnEfekt.Enabled = true;
      this.btnSqlDuzenle.Enabled = true;
      this.tiklandiSqlDuzenle = false;
      this.tiklandiSosParlama = true;
      this.tiklandiItemEkleme = false;
      this.tiklandiYeniNpc = false;
      this.tiklandiArti = false;
      this.tiklandiItemMall = false;
      this.sahne = (Control) this.parlama;
    }

    private void btnArti_Click(object sender, EventArgs e)
    {
      if (this.tiklandiArti)
        return;
      if (this.sahne != null)
        this.pnlZemin.Controls.Remove(this.sahne);
      this.btnNPC.Enabled = false;
      this.btnEfekt.Enabled = false;
      this.btnSqlDuzenle.Enabled = false;
      this.arti = new ArtiRenkleri();
      this.arti.dizin = this.dizin;
      this.arti.Location = new Point(0, 0);
      this.arti.Dock = DockStyle.Fill;
      this.pnlZemin.Controls.Add((Control) this.arti);
      this.lblBilgi.Visible = false;
      this.btnNPC.Enabled = true;
      this.btnEfekt.Enabled = true;
      this.btnSqlDuzenle.Enabled = true;
      this.tiklandiSqlDuzenle = false;
      this.tiklandiArti = true;
      this.tiklandiSosParlama = false;
      this.tiklandiItemEkleme = false;
      this.tiklandiYeniNpc = false;
      this.tiklandiItemMall = false;
      this.sahne = (Control) this.arti;
    }

    private void btnSqlDuzenle_Click(object sender, EventArgs e)
    {
      if (this.tiklandiSqlDuzenle)
        return;
      if (this.sahne != null)
        this.pnlZemin.Controls.Remove(this.sahne);
      this.btnNPC.Enabled = false;
      this.btnEfekt.Enabled = false;
      this.btnSqlDuzenle.Enabled = false;
      this.sqlDuzenle = new AraYuz();
      this.sqlDuzenle.btn = new ToolStripMenuItem[3]
      {
        this.btnEfekt,
        this.btnNPC,
        this.btnSqlDuzenle
      };
      this.sqlDuzenle.Location = new Point(0, 0);
      this.sqlDuzenle.Dock = DockStyle.Fill;
      this.pnlZemin.Controls.Add((Control) this.sqlDuzenle);
      this.lblBilgi.Visible = false;
      this.btnNPC.Enabled = true;
      this.btnEfekt.Enabled = true;
      this.btnSqlDuzenle.Enabled = true;
      this.tiklandiSqlDuzenle = true;
      this.tiklandiArti = false;
      this.tiklandiSosParlama = false;
      this.tiklandiItemEkleme = false;
      this.tiklandiYeniNpc = false;
      this.tiklandiItemMall = false;
      this.sahne = (Control) this.sqlDuzenle;
    }

    private void f10İTEMEKLEMESİLMEToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.tiklandiItemMall)
        return;
      if (this.sahne != null)
        this.pnlZemin.Controls.Remove(this.sahne);
      this.btnNPC.Enabled = false;
      this.btnEfekt.Enabled = false;
      this.btnSqlDuzenle.Enabled = false;
      this.lblBilgi.Visible = true;
      this.itemMall = new magza();
      this.itemMall.btn = new ToolStripMenuItem[3]
      {
        this.btnEfekt,
        this.btnNPC,
        this.btnSqlDuzenle
      };
      this.itemMall.Location = new Point(0, 0);
      this.itemMall.Dock = DockStyle.Fill;
      this.pnlZemin.Controls.Add((Control) this.itemMall);
      this.lblBilgi.Visible = false;
      this.btnNPC.Enabled = true;
      this.btnEfekt.Enabled = true;
      this.btnSqlDuzenle.Enabled = true;
      this.tiklandiSqlDuzenle = false;
      this.tiklandiSosParlama = false;
      this.tiklandiItemEkleme = false;
      this.tiklandiYeniNpc = false;
      this.tiklandiArti = false;
      this.tiklandiItemMall = true;
      this.sahne = (Control) this.itemMall;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaMenu));
            this.pnlZemin = new System.Windows.Forms.Panel();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.btnBaglan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSqlDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNPC = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYeniNpc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnItemEkleme = new System.Windows.Forms.ToolStripMenuItem();
            this.f10İTEMEKLEMESİLMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEfekt = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSosParlama = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArti = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlZemin.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlZemin
            // 
            this.pnlZemin.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlZemin.Controls.Add(this.lblBilgi);
            this.pnlZemin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlZemin.Location = new System.Drawing.Point(0, 24);
            this.pnlZemin.Name = "pnlZemin";
            this.pnlZemin.Size = new System.Drawing.Size(809, 502);
            this.pnlZemin.TabIndex = 1;
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.BackColor = System.Drawing.Color.Maroon;
            this.lblBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgi.ForeColor = System.Drawing.Color.White;
            this.lblBilgi.Location = new System.Drawing.Point(24, 220);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(760, 29);
            this.lblBilgi.TabIndex = 1;
            this.lblBilgi.Text = "GEREKLİ BÜTÜN TABLOLAR ÇEKİLİYOR LÜTFEN BEKLEYİN...";
            this.lblBilgi.Visible = false;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBaglan,
            this.btnSqlDuzenle,
            this.btnNPC,
            this.btnEfekt});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(809, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menü";
            // 
            // btnBaglan
            // 
            this.btnBaglan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.btnBaglan.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnBaglan.ImageTransparentColor = System.Drawing.Color.Lavender;
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(55, 20);
            this.btnBaglan.Text = "Bağlan";
            this.btnBaglan.Click += new System.EventHandler(this.Baglan_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Lavender;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(57, 6);
            // 
            // btnSqlDuzenle
            // 
            this.btnSqlDuzenle.Enabled = false;
            this.btnSqlDuzenle.ForeColor = System.Drawing.Color.Green;
            this.btnSqlDuzenle.Name = "btnSqlDuzenle";
            this.btnSqlDuzenle.Size = new System.Drawing.Size(85, 20);
            this.btnSqlDuzenle.Text = "SQL Düzenle";
            this.btnSqlDuzenle.Click += new System.EventHandler(this.btnSqlDuzenle_Click);
            // 
            // btnNPC
            // 
            this.btnNPC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnYeniNpc,
            this.btnItemEkleme,
            this.f10İTEMEKLEMESİLMEToolStripMenuItem});
            this.btnNPC.Enabled = false;
            this.btnNPC.ForeColor = System.Drawing.Color.Green;
            this.btnNPC.ImageTransparentColor = System.Drawing.Color.Lavender;
            this.btnNPC.Name = "btnNPC";
            this.btnNPC.Size = new System.Drawing.Size(90, 20);
            this.btnNPC.Text = "NPC İşlemleri";
            // 
            // btnYeniNpc
            // 
            this.btnYeniNpc.BackColor = System.Drawing.Color.Lavender;
            this.btnYeniNpc.Name = "btnYeniNpc";
            this.btnYeniNpc.Size = new System.Drawing.Size(169, 22);
            this.btnYeniNpc.Text = "Yeni Npc Ekleme";
            this.btnYeniNpc.Click += new System.EventHandler(this.yeniNPC_Click);
            // 
            // btnItemEkleme
            // 
            this.btnItemEkleme.BackColor = System.Drawing.Color.Lavender;
            this.btnItemEkleme.Name = "btnItemEkleme";
            this.btnItemEkleme.Size = new System.Drawing.Size(169, 22);
            this.btnItemEkleme.Text = "Npc Mall Düzenle";
            this.btnItemEkleme.Click += new System.EventHandler(this.btnItemEkleme_Click);
            // 
            // f10İTEMEKLEMESİLMEToolStripMenuItem
            // 
            this.f10İTEMEKLEMESİLMEToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this.f10İTEMEKLEMESİLMEToolStripMenuItem.Name = "f10İTEMEKLEMESİLMEToolStripMenuItem";
            this.f10İTEMEKLEMESİLMEToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.f10İTEMEKLEMESİLMEToolStripMenuItem.Text = "İtem Mall Düzenle";
            this.f10İTEMEKLEMESİLMEToolStripMenuItem.Click += new System.EventHandler(this.f10İTEMEKLEMESİLMEToolStripMenuItem_Click);
            // 
            // btnEfekt
            // 
            this.btnEfekt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSosParlama,
            this.btnArti});
            this.btnEfekt.Enabled = false;
            this.btnEfekt.ForeColor = System.Drawing.Color.Green;
            this.btnEfekt.ImageTransparentColor = System.Drawing.Color.Lavender;
            this.btnEfekt.Name = "btnEfekt";
            this.btnEfekt.Size = new System.Drawing.Size(111, 20);
            this.btnEfekt.Text = "Parlama Effectleri";
            // 
            // btnSosParlama
            // 
            this.btnSosParlama.BackColor = System.Drawing.Color.Lavender;
            this.btnSosParlama.Name = "btnSosParlama";
            this.btnSosParlama.Size = new System.Drawing.Size(191, 22);
            this.btnSosParlama.Text = "Sos Parlama Effect\'leri";
            this.btnSosParlama.Click += new System.EventHandler(this.btnSosParlama_Click);
            // 
            // btnArti
            // 
            this.btnArti.BackColor = System.Drawing.Color.Lavender;
            this.btnArti.Name = "btnArti";
            this.btnArti.Size = new System.Drawing.Size(191, 22);
            this.btnArti.Text = "Artı Parlama Effect\'leri";
            this.btnArti.Click += new System.EventHandler(this.btnArti_Click);
            // 
            // AnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 526);
            this.Controls.Add(this.pnlZemin);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "AnaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSRO-R NPC EDİTÖR PROGRAMI";
            this.Load += new System.EventHandler(this.AnaMenu_Load);
            this.pnlZemin.ResumeLayout(false);
            this.pnlZemin.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
