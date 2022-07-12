// Decompiled with JetBrains decompiler
// Type: SQLGuncelle.Bilgi
// Assembly: SQLGuncelle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F363998B-B3C3-4374-8084-DFE1249725CF
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\SQLGuncelle.dll

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SQLGuncelle
{
    public class Bilgi : Form
    {
        private IContainer components = (IContainer)null;
        public string _uyariMetni = "";
        public bool ac = false;
        public string bolge = "";
        public string _nerdenGeldigi = "";
        private Uyari uyari;
        private IslemYap sqlKayit;
        private kapanis kapan;
        public DataSet tabloSet;
        public DataSet ds_Item;
        public int grNo = 0;
        public int tabSayisi = 0;
        public string _npcAdi = "";
        public string _gorunenAd = "";
        public string _npcMetin = "";

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
            // Bilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(588, 262);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = this.Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Bilgi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilgi";
            this.Load += new System.EventHandler(this.Bilgi_Load);
            this.ResumeLayout(false);

        }

        public Bilgi() => this.InitializeComponent();

        private void Bilgi_Load(object sender, EventArgs e)
        {
            if (!this.ac)
                this.Close();
            this.uyari = new Uyari();
            this.uyari.lblUyari.Text = this._uyariMetni;
            this.uyari.Dock = DockStyle.Fill;
            this.Height = this.uyari.Height + 30;
            this.Width = this.uyari.Width;
            this.uyari.btnEvet.Location = new Point(this.Width / 2 - 121, this.Height - 80);
            this.uyari.btnHayir.Location = new Point(this.Width / 2 + 20, this.Height - 80);
            if (this.uyari.lblUyari.Width > this.uyari.Width)
            {
                this.Width = this.uyari.lblUyari.Width + 25;
                this.uyari.btnEvet.Location = new Point(this.Width / 2 - 121, this.Height - 80);
                this.uyari.btnHayir.Location = new Point(this.Width / 2 + 20, this.Height - 80);
            }
            this.uyari.bilgi = this;
            this.Controls.Add((Control)this.uyari);
        }

        public void EvetTiklandi()
        {
            if (this._nerdenGeldigi == "NPC")
            {
                this.Controls.Remove((Control)this.uyari);
                this.sqlKayit = new IslemYap();
                this.sqlKayit.Dock = DockStyle.Fill;
                this.Width = this.sqlKayit.Width;
                this.Height = this.sqlKayit.Height + 30;
                this.sqlKayit.ds = this.tabloSet;
                this.sqlKayit.bolgeAdi = this.bolge;
                this.sqlKayit.grSirano = this.grNo;
                this.sqlKayit.tabSay = this.tabSayisi;
                this.sqlKayit.npcAdi = this._npcAdi;
                this.sqlKayit.gorunenAd = this._gorunenAd;
                this.sqlKayit.npcMetin = this._npcMetin;
                this.sqlKayit._nerdenGeldigi = this._nerdenGeldigi;
                this.sqlKayit.blg = this;
                this.Controls.Add((Control)this.sqlKayit);
            }
            else
            {
                if (!(this._nerdenGeldigi == "ITEM"))
                    return;
                this.Controls.Remove((Control)this.uyari);
                this.sqlKayit = new IslemYap();
                this.sqlKayit.Dock = DockStyle.Fill;
                this.Width = this.sqlKayit.Width;
                this.Height = this.sqlKayit.Height + 30;
                this.sqlKayit.ds = this.ds_Item;
                this.sqlKayit._nerdenGeldigi = this._nerdenGeldigi;
                this.sqlKayit.blg = this;
                this.Controls.Add((Control)this.sqlKayit);
            }
        }

        public void IslemBitti()
        {
            this.Controls.Remove((Control)this.sqlKayit);
            this.kapan = new kapanis();
            this.Width = this.kapan.Width;
            this.Height = this.kapan.Height + 30;
            this.kapan.Dock = DockStyle.Fill;
            this.kapan.blg = this;
            this.Controls.Add((Control)this.kapan);
        }
    }
}

