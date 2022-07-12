// Decompiled with JetBrains decompiler
// Type: sqlDuzenle.AraYuz
// Assembly: sqlDuzenle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A234CEB-E638-4993-9A05-681B3B92A6BA
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC\sqlDuzenle.dll

using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sqlDuzenle
{
    public class AraYuz : UserControl
    {
        private IContainer components = (IContainer)null;
        private Label lblAciklama;
        internal Label lblBilgi;
        internal ProgressBar pro;
        private GroupBox groupBox1;
        private Button btnDuzenle;
        private sorgu sr;
        public ToolStripMenuItem[] btn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAciklama = new System.Windows.Forms.Label();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.pro = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAciklama.ForeColor = System.Drawing.Color.White;
            this.lblAciklama.Location = new System.Drawing.Point(6, 16);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(57, 15);
            this.lblAciklama.TabIndex = 0;
            this.lblAciklama.Text = "Açıklama";
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.ForeColor = System.Drawing.Color.White;
            this.lblBilgi.Location = new System.Drawing.Point(13, 403);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(26, 13);
            this.lblBilgi.TabIndex = 0;
            this.lblBilgi.Text = "Bilgi";
            // 
            // pro
            // 
            this.pro.ForeColor = System.Drawing.Color.Maroon;
            this.pro.Location = new System.Drawing.Point(13, 419);
            this.pro.Name = "pro";
            this.pro.Size = new System.Drawing.Size(772, 23);
            this.pro.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.groupBox1.Controls.Add(this.lblAciklama);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(798, 334);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AÇIKLAMA";
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.Lavender;
            this.btnDuzenle.ForeColor = System.Drawing.Color.Black;
            this.btnDuzenle.Location = new System.Drawing.Point(9, 340);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(152, 51);
            this.btnDuzenle.TabIndex = 3;
            this.btnDuzenle.Text = "DÜZENLEMEYE BAŞLA";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new System.EventHandler(this.button1_Click);
            // 
            // AraYuz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pro);
            this.Controls.Add(this.lblBilgi);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "AraYuz";
            this.Size = new System.Drawing.Size(798, 471);
            this.Load += new System.EventHandler(this.AraYuz_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public AraYuz() => this.InitializeComponent();

        private void AraYuz_Load(object sender, EventArgs e)
        {
            this.lblAciklama.Text = this.Aciklama();
            this.pro.Visible = false;
            this.lblBilgi.Visible = false;
        }

        private string Aciklama() => "Burdaki Sql Düzenleme sadece\n1. _RefPackageItem\n2. _RefPricePolicyOfItem\n3. _RefScrapOfPackageItem\n4. _RefShopGoods\nTablolarında işlem yapmaktatır.\n\nYapılan işlemler sırasıyla\n1. \"_RefPackageItem\" ve \"_RefScrapOfPackageItem\" tablolarında birden fazla yazılmış itemleri kontrol ediyor varsa eğer o itemleri siliyor.\n2. Bütün tabloları karşılaştırıyor diğer tablolarda olmayan itemi karşılaştırdığı tablodan siliyor.\n3. Enson olarak Tabloları benim videoda gösterdğim gibi düzenleyim ID leri ve [index] leri sıfırlayıp 1'den başlamasını sağlıyor.\r\n\r\nNOT 1: Bu işlemleri sadece yukarda belirttiğim 4 tabloda yapıyor diğer tabloları videoda gösterdiğim gibi yapmanız gerekiyor..\r\n\nNOT 2: İŞLEMLERE BAŞLAMADAN ÖNCE MUTLAKA DB VE MEDYANIZIN YEDEĞİNİ ALIN EKLEME YAPTIKTAN SONRA NOT3 YAPTIĞINIZ HALDE\r\nMEDYADA HATA ALIYORSANIZ DB DEKİ _RefPackageItem TABLOSUNUN İÇERİĞİNİ SİLİN HATA ALMADAN ÖNCEKİ MEDYANIZDAN\r\nrefpackageitem.txt DOSYANIN İÇERİĞİNİ BU TABLOYA EKLEYİN SONRA TEKRAR DÜZENLEMEYE BAŞLA BUTONUNA BASIN...\r\n\nNOT 3: İtem ekledikten sonra medya hata verirse Medya/server_dep/silkroad/textdata/refshopitemstockperiod.txt dosyasının içeriğini silin\r\nMedyaya ekleyin hata ozaman düzelecektir...";

        private void button1_Click(object sender, EventArgs e)
        {
            this.sr = new sorgu();
            if (!this.sr.baglanti)
                return;
            this.btnDuzenle.Enabled = false;
            this.btn[0].Enabled = false;
            this.btn[1].Enabled = false;
            this.btn[2].Enabled = false;
            this.pro.Visible = true;
            this.lblBilgi.Visible = true;
            this.sr.frm = this;
            try
            {
                this.pro.Minimum = 0;
                this.sr.TabloGuncelle("_RefPackageItem", this.sr.refpackage());
                this.sr.TabloGuncelle("_RefPricePolicyOfItem", this.sr._RefPricePolicyOfItem());
                this.sr.TabloGuncelle("_RefScrapOfPackageItem", this.sr._RefScrapOfPackageItem());
                this.sr.TabloGuncelle("_RefShopGoods", this.sr._RefShopGoods());
                int num = (int)MessageBox.Show("İşlem Tamamlandı...\r\nMedya için txt Dosyasını Oluşturmayı Unutmayın...");
                this.btn[0].Enabled = true;
                this.btn[1].Enabled = true;
                this.btn[2].Enabled = true;
                this.btnDuzenle.Enabled = true;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
