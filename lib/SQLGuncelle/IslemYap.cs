// Decompiled with JetBrains decompiler
// Type: SQLGuncelle.IslemYap
// Assembly: SQLGuncelle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F363998B-B3C3-4374-8084-DFE1249725CF
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\SQLGuncelle.dll

using ConfigOku;
using sql;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TxTDosyaOlustur;

namespace SQLGuncelle
{
    public class IslemYap : UserControl
    {
        private string dizin = Path.GetDirectoryName(Application.ExecutablePath) + "\\MedyayaEklenecekDosyalar";
        private Fonksiyon fonksiyon;
        public DataSet ds;
        private SqlDataAdapter adapter;
        private SqlConnection con;
        public string bolgeAdi = "";
        public int grSirano = 0;
        public int tabSay = 0;
        public string npcAdi = "";
        public string gorunenAd = "";
        public string npcMetin = "";
        public Bilgi blg;
        public string _nerdenGeldigi = "";
        private IContainer components = (IContainer)null;
        private ProgressBar proUst;
        private ProgressBar proAlt;
        private Label lblUstBilgi;
        private Label lblAltBilgi;

        public IslemYap() => this.InitializeComponent();

        private void IslemYap_Load(object sender, EventArgs e)
        {
            this.fonksiyon = new confikOku().FonksiyonKur();
            if (this._nerdenGeldigi == "NPC")
            {
                this.blg.Text = "SQL ve Medya Dosyaları Oluşturuluyor";
                this.sqlAktar();
            }
            else
            {
                if (!(this._nerdenGeldigi == "ITEM"))
                    return;
                this.blg.Text = "SQL ve Medaya Dosyaları Oluşturuluyor";
            }
        }

        private void sqlAktar()
        {
            try
            {
                this.proAlt.Maximum = 2;
                this.proAlt.Minimum = 0;
                this.proAlt.Step = 1;
                this.con = this.fonksiyon.Baglan();
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = this.con;
                string[] strArray1 = new string[12]
                {
          "_RefObjChar",
          "_RefObjCommon",
          "Tab_RefHive",
          "Tab_RefTactics",
          "Tab_RefNest",
          "_RefShop",
          "_RefShopGroup",
          "_RefMappingShopGroup",
          "_RefShopItemGroup",
          "_RefShopTabGroup",
          "_RefMappingShopWithTab",
          "_RefShopTab"
                };
                this.proUst.Maximum = strArray1.Length;
                this.proUst.Minimum = 0;
                this.proUst.Step = 1;
                int num1 = 0;
                this.lblAltBilgi.Text = "SQL Server Güncelleniyor...";
                for (int index1 = 0; index1 < strArray1.Length; ++index1)
                {
                    selectCommand.CommandText = "select * from " + strArray1[index1];
                    this.adapter = new SqlDataAdapter(selectCommand);
                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.adapter);
                    for (int index2 = 0; index2 < 1; ++index2)
                    {
                        this.lblUstBilgi.Text = strArray1[index1] + " Tablosu Güncelleniyor";
                        if (strArray1[index1] == "_RefObjChar")
                        {
                            this.adapter.Update(this.ds, strArray1[index1]);
                            this.ds.Tables.Remove(strArray1[index1]);
                            this.adapter.Fill(this.ds, strArray1[index1]);
                            this._RefObjCommonIdGuncelle();
                        }
                        else if (strArray1[index1] == "Tab_RefTactics")
                        {
                            this.Tab_RefTacticsObjDuzenle();
                            this.adapter.Update(this.ds, strArray1[index1]);
                            this.ds.Tables.Remove(strArray1[index1]);
                            this.adapter.Fill(this.ds, strArray1[index1]);
                        }
                        else if (strArray1[index1] == "Tab_RefNest")
                        {
                            this.Tab_RefNestDuzenle();
                            this.adapter.Update(this.ds, strArray1[index1]);
                            this.ds.Tables.Remove(strArray1[index1]);
                            this.adapter.Fill(this.ds, strArray1[index1]);
                        }
                        else
                        {
                            this.adapter.Update(this.ds, strArray1[index1]);
                            this.ds.Tables.Remove(strArray1[index1]);
                            this.adapter.Fill(this.ds, strArray1[index1]);
                        }
                        Application.DoEvents();
                    }
                    Thread.Sleep(200);
                    ++num1;
                    Application.DoEvents();
                    if (num1 > 0)
                        this.proUst.Value = num1;
                }
                Thread.Sleep(100);
                this.proAlt.Value = 1;
                this.lblAltBilgi.Text = "Medyaya Eklenecek Dosyalar Oluştutuluyor...";
                int num2 = 0;
                string[] strArray2 = new string[12]
                {
          "characterdata_.txt",
          "refshop.txt",
          "refshopgroup.txt",
          "refmappingshopgroup.txt",
          "shopgroupdata.txt",
          "refshoptabgroup.txt",
          "refmappingshopwithtab.txt",
          "refshoptab.txt",
          "npcchat.txt",
          "textdata_object.txt",
          "textquest_speech&name.txt",
          "textuisystem.txt"
                };
                this.proUst.Maximum = strArray2.Length;
                for (int index = 0; index < strArray2.Length; ++index)
                {
                    this.lblUstBilgi.Text = strArray2[index] + " Text Dosyası Oluşturuluyor...";
                    if (strArray2[index] == "characterdata_.txt")
                        TxT.TxTYaz1(this.characterdata_5000(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "refshop.txt")
                        TxT.TxTYaz1(this.refshop(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "refshopgroup.txt")
                        TxT.TxTYaz1(this.refshopgroup(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "refmappingshopgroup.txt")
                        TxT.TxTYaz1(this.refmappingshopgroup(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "shopgroupdata.txt")
                        TxT.TxTYaz1(this.shopgroupdata(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "refshoptabgroup.txt")
                        TxT.TxTYaz1(this.refshoptabgroup(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "refmappingshopwithtab.txt")
                        TxT.TxTYaz1(this.refmappingshopwithtab(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "refshoptab.txt")
                        TxT.TxTYaz1(this.refshoptab(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "npcchat.txt")
                        TxT.TxTYaz1(this.npcchat(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "textdata_object.txt")
                        TxT.TxTYaz1(this.textdata_object(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "textquest_speech&name.txt")
                        TxT.TxTYaz1(this.textquest_speech(), this.dizin, strArray2[index]);
                    else if (strArray2[index] == "textuisystem.txt")
                        TxT.TxTYaz1(this.textuisystem(), this.dizin, strArray2[index]);
                    Thread.Sleep(200);
                    ++num2;
                    Application.DoEvents();
                    this.proUst.Value = num2;
                }
                Thread.Sleep(100);
                this.proAlt.Value = 2;
                this.Kapanis();
            }
            catch
            {
            }
        }

        private void _RefObjCommonIdGuncelle() => this.ds.Tables["_RefObjCommon"].Rows[this.ds.Tables["_RefObjCommon"].Rows.Count - 1][this.ds.Tables["_RefObjCommon"].Columns.Count - 1] = this.ds.Tables["_RefObjChar"].Rows[this.ds.Tables["_RefObjChar"].Rows.Count - 1][0];

        private void Tab_RefTacticsObjDuzenle() => this.ds.Tables["Tab_RefTactics"].Rows[this.ds.Tables["Tab_RefTactics"].Rows.Count - 1][1] = (object)this.ds.Tables["_RefObjCommon"].Rows[this.ds.Tables["_RefObjCommon"].Rows.Count - 1][1].ToString();

        private void Tab_RefNestDuzenle()
        {
            string str1 = this.bolgeKoduGetir();
            int index1 = 0;
            for (int index2 = 0; index2 < this.ds.Tables["Tab_RefHive"].Rows.Count; ++index2)
            {
                if (this.ds.Tables["Tab_RefHive"].Rows[index2][this.ds.Tables["Tab_RefHive"].Columns.Count - 1].ToString() == str1)
                {
                    index1 = index2;
                    break;
                }
            }
            string str2 = this.ds.Tables["Tab_RefHive"].Rows[index1][0].ToString();
            string str3 = this.ds.Tables["Tab_RefTactics"].Rows[this.ds.Tables["Tab_RefTactics"].Rows.Count - 1][0].ToString();
            this.ds.Tables["Tab_RefNest"].Rows[this.ds.Tables["Tab_RefNest"].Rows.Count - 1][1] = (object)str2;
            this.ds.Tables["Tab_RefNest"].Rows[this.ds.Tables["Tab_RefNest"].Rows.Count - 1][2] = (object)str3;
        }

        private string bolgeKoduGetir()
        {
            string str = "";
            if (this.bolgeAdi == "JANGAN")
                str = "NPC_CHN";
            else if (this.bolgeAdi == "DONWHANG")
                str = "NPC_DOW";
            else if (this.bolgeAdi == "HOTAN")
                str = "NPC_HOTA";
            else if (this.bolgeAdi == "SEMERKAND")
                str = "NPC_SEMER";
            else if (this.bolgeAdi == "CONSTANTINE")
                str = "NPC_CONST";
            else if (this.bolgeAdi == "ALEXANDRIA")
                str = "NPC_ALXAND";
            else if (this.bolgeAdi == "JUPITER")
                str = "NPC_JUPI";
            return str;
        }

        private string characterdata_5000()
        {
            string str = "";
            for (int columnIndex = 0; columnIndex < this.ds.Tables["_RefObjCommon"].Columns.Count - 1; ++columnIndex)
                str = str + this.ds.Tables["_RefObjCommon"].Rows[this.ds.Tables["_RefObjCommon"].Rows.Count - 1][columnIndex].ToString() + "\t";
            for (int index = 0; index < 47; ++index)
                str = str + this.ds.Tables["_RefObjChar"].Rows[this.ds.Tables["_RefObjChar"].Rows.Count - 1][index + 33].ToString() + "\t";
            return str;
        }

        private string refshop()
        {
            string str = "";
            for (int columnIndex = 0; columnIndex < this.ds.Tables["_RefShop"].Columns.Count; ++columnIndex)
                str = str + this.ds.Tables["_RefShop"].Rows[this.ds.Tables["_RefShop"].Rows.Count - 1][columnIndex].ToString() + "\t";
            return str;
        }

        private string refshopgroup()
        {
            string str = "";
            for (int columnIndex = 0; columnIndex < this.ds.Tables["_RefShopGroup"].Columns.Count; ++columnIndex)
                str = str + this.ds.Tables["_RefShopGroup"].Rows[this.ds.Tables["_RefShopGroup"].Rows.Count - 1][columnIndex].ToString() + "\t";
            return str;
        }

        private string refmappingshopgroup()
        {
            string str = "";
            for (int index = 0; index < this.ds.Tables["idOlmayan_RefMappingShopGroup"].Rows.Count; ++index)
            {
                for (int columnIndex = 0; columnIndex < this.ds.Tables["idOlmayan_RefMappingShopGroup"].Columns.Count; ++columnIndex)
                    str = str + this.ds.Tables["idOlmayan_RefMappingShopGroup"].Rows[index][columnIndex].ToString() + "\t";
            }
            return str;
        }

        private string shopgroupdata()
        {
            string str = "";
            for (int grSirano = this.grSirano; grSirano > 0; --grSirano)
            {
                for (int columnIndex = 0; columnIndex < this.ds.Tables["_RefShopItemGroup"].Columns.Count; ++columnIndex)
                    str = str + this.ds.Tables["_RefShopItemGroup"].Rows[this.ds.Tables["_RefShopItemGroup"].Rows.Count - grSirano][columnIndex].ToString() + "\t";
                str += "\r\n";
            }
            return str;
        }

        private string refshoptabgroup()
        {
            string str = "";
            for (int grSirano = this.grSirano; grSirano > 0; --grSirano)
            {
                for (int columnIndex = 0; columnIndex < this.ds.Tables["_RefShopTabGroup"].Columns.Count; ++columnIndex)
                    str = str + this.ds.Tables["_RefShopTabGroup"].Rows[this.ds.Tables["_RefShopTabGroup"].Rows.Count - grSirano][columnIndex].ToString() + "\t";
                str += "\r\n";
            }
            return str;
        }

        private string refmappingshopwithtab()
        {
            string str = "";
            for (int grSirano = this.grSirano; grSirano > 0; --grSirano)
            {
                for (int columnIndex = 0; columnIndex < this.ds.Tables["idOlmayan__RefMappingShopWithTab"].Columns.Count; ++columnIndex)
                    str = str + this.ds.Tables["idOlmayan__RefMappingShopWithTab"].Rows[this.ds.Tables["idOlmayan__RefMappingShopWithTab"].Rows.Count - grSirano][columnIndex].ToString() + "\t";
                str += "\r\n";
            }
            return str;
        }

        private string refshoptab()
        {
            string str = "";
            for (int tabSay = this.tabSay; tabSay > 0; --tabSay)
            {
                for (int columnIndex = 0; columnIndex < this.ds.Tables["_RefShopTab"].Columns.Count; ++columnIndex)
                    str = str + this.ds.Tables["_RefShopTab"].Rows[this.ds.Tables["_RefShopTab"].Rows.Count - tabSay][columnIndex].ToString() + "\t";
                str += "\r\n";
            }
            return str;
        }

        private string npcchat() => "1\t" + this.npcAdi + "\tSN_" + this.npcAdi + "_BS\tSN_" + this.npcAdi + "_PS";

        private string textdata_object() => "1\tSN_" + this.npcAdi + "\t" + this.gorunenAd + "\t0\t0\t0\t0\t0\t" + this.gorunenAd + "\t" + this.gorunenAd + "\t0\t0\t0\t0\t0\t0";

        private string textquest_speech() => "1\tSN_" + this.npcAdi + "_BS\t\t\t\t\t\t\t\t" + this.npcMetin + "\t\t\t\t\t\t\t";

        private string textuisystem()
        {
            string str = "";
            for (int index = 0; index < this.ds.Tables["snTabAdi"].Rows.Count; ++index)
                str = str + "1\t" + this.ds.Tables["snTabAdi"].Rows[index][0].ToString() + "\t" + this.ds.Tables["snTabAdi"].Rows[index][1].ToString() + "\t0\t0\t0\t0\t0\t" + this.ds.Tables["snTabAdi"].Rows[index][1].ToString() + "\t" + this.ds.Tables["snTabAdi"].Rows[index][1].ToString() + "\t0\t0\t0\t0\t0\t0" + "\r\n";
            for (int index = 0; index < this.ds.Tables["GurupAdi"].Rows.Count; ++index)
                str = str + "1\t" + this.ds.Tables["GurupAdi"].Rows[index][0].ToString() + "\t" + this.ds.Tables["GurupAdi"].Rows[index][1].ToString() + "\t0\t0\t0\t0\t0\t" + this.ds.Tables["GurupAdi"].Rows[index][1].ToString() + "\t" + this.ds.Tables["GurupAdi"].Rows[index][1].ToString() + "\t0\t0\t0\t0\t0\t0" + "\r\n";
            return str;
        }

        private void Kapanis() => this.blg.IslemBitti();

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.proUst = new System.Windows.Forms.ProgressBar();
            this.proAlt = new System.Windows.Forms.ProgressBar();
            this.lblUstBilgi = new System.Windows.Forms.Label();
            this.lblAltBilgi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // proUst
            // 
            this.proUst.BackColor = System.Drawing.Color.Maroon;
            this.proUst.ForeColor = System.Drawing.Color.Maroon;
            this.proUst.Location = new System.Drawing.Point(39, 34);
            this.proUst.Name = "proUst";
            this.proUst.Size = new System.Drawing.Size(484, 23);
            this.proUst.TabIndex = 0;
            // 
            // proAlt
            // 
            this.proAlt.BackColor = System.Drawing.Color.Maroon;
            this.proAlt.ForeColor = System.Drawing.Color.Maroon;
            this.proAlt.Location = new System.Drawing.Point(39, 91);
            this.proAlt.Name = "proAlt";
            this.proAlt.Size = new System.Drawing.Size(484, 23);
            this.proAlt.TabIndex = 0;
            // 
            // lblUstBilgi
            // 
            this.lblUstBilgi.AutoSize = true;
            this.lblUstBilgi.BackColor = System.Drawing.Color.Transparent;
            this.lblUstBilgi.Location = new System.Drawing.Point(39, 15);
            this.lblUstBilgi.Name = "lblUstBilgi";
            this.lblUstBilgi.Size = new System.Drawing.Size(35, 13);
            this.lblUstBilgi.TabIndex = 1;
            this.lblUstBilgi.Text = "label1";
            // 
            // lblAltBilgi
            // 
            this.lblAltBilgi.AutoSize = true;
            this.lblAltBilgi.BackColor = System.Drawing.Color.Transparent;
            this.lblAltBilgi.Location = new System.Drawing.Point(39, 75);
            this.lblAltBilgi.Name = "lblAltBilgi";
            this.lblAltBilgi.Size = new System.Drawing.Size(35, 13);
            this.lblAltBilgi.TabIndex = 1;
            this.lblAltBilgi.Text = "label1";
            // 
            // IslemYap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.lblAltBilgi);
            this.Controls.Add(this.lblUstBilgi);
            this.Controls.Add(this.proAlt);
            this.Controls.Add(this.proUst);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "IslemYap";
            this.Size = new System.Drawing.Size(562, 147);
            this.Load += new System.EventHandler(this.IslemYap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
