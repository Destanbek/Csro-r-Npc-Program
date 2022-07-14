// Decompiled with JetBrains decompiler
// Type: UserKontrol.NPCEkle
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

// Decompiled with JetBrains decompiler
// Type: UserKontrol.NPCEkle
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 59C095D7-E238-4DFC-A310-47CD0C313AA9
// Assembly location: C:\Users\Admin\Desktop\VSRO - Nazif Npc\UserKontrol.dll

using SQLGuncelle;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Tablo;

namespace UserKontrol
{
    public class NPCEkle : UserControl
    {
        private DataSet dsTablolar;
        private TabloOlustur tbOlustur;
        private int _adimlariSay = 0;
        private int _grSiraNo = 1;
        private int _tabSay = 0;
        private int _sonTab = 0;
        private string bolgeNo = "";
        private string bolgeAdi = "";
        private IContainer components = (IContainer)null;
        private Button btnOnceki;
        private Button btnVazgec;
        private Button btnSonraki;
        private GroupBox grNPCIsmi;
        private TextBox txtNpcIsmi;
        private Label label1;
        private GroupBox grPozisyon;
        private Label label6;
        private TextBox txtYon;
        private Label label5;
        private TextBox txtZ;
        private Label label4;
        private TextBox txtY;
        private Label label3;
        private Label label2;
        private ComboBox cmbCharAdi;
        private TextBox txtX;
        private GroupBox grGrup;
        private Label label11;
        private TextBox txtGrup;
        private GroupBox grNPCBolge;
        private ComboBox cmbBolge;
        private GroupBox grTab;
        private Button btnYeniGrup;
        private Label label15;
        private Label label14;
        private TextBox txtTMen4;
        private TextBox txtTab4;
        private Label label13;
        private TextBox txtTMen3;
        private TextBox txtTab3;
        private Label label12;
        private TextBox txtTMen2;
        private TextBox txtTab2;
        private Label label10;
        private TextBox txtTMen1;
        private Label label8;
        private Label label9;
        private TextBox txtTab1;
        private Button btnKayit;
        private Label label16;
        private Label label17;
        private TextBox txtGorunen;
        private Label label18;
        private TextBox txtChat;
        private Button NPCDirection;
        private Label label20;
        private Label label22;
        private Label label19;
        private Label label21;
        private GroupBox groupBox1;
        private Label label7;
        private GroupBox groupBox2;
        public TextBox cmbBSR;

        public NPCEkle() => this.InitializeComponent();

        private void NPCEkle_Load(object sender, EventArgs e)
        {
            this.ButonKontrol(this._adimlariSay);
            this.CharAdiDoldur();
        }

        public void dataSetOlustur()
        {
            this.tbOlustur = new TabloOlustur();
            this.dsTablolar = this.tbOlustur.NPCTabloCek(new string[13]
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
        "_RefShopTab",
        "_Char"
            });
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            if (this._adimlariSay == 0)
            {
                if (this.tbOlustur._RefObjChar(this.dsTablolar))
                {
                    if (this.txtNpcIsmi.Text.Substring(4) != "" && this.cmbBSR.Text.IndexOf(".bsr") != -1 && this.txtGorunen.Text != "" && this.txtChat.Text != "")
                    {
                        if (this.tbOlustur._RefObjCommon(this.dsTablolar, this.txtNpcIsmi.Text, "npc\\npc\\" + this.cmbBSR.Text))
                        {
                            if (this.tbOlustur.Tab_RefTactics(this.dsTablolar))
                            {
                                ++this._adimlariSay;
                            }
                            else
                            {
                                int num = (int)MessageBox.Show("HATA!!! 3.İşlem Yapılamadı....");
                                this.dsTablolar.Tables["_RefObjChar"].Rows.RemoveAt(this.dsTablolar.Tables["_RefObjChar"].Rows.Count - 1);
                                this.dsTablolar.Tables["_RefObjCommon"].Rows.RemoveAt(this.dsTablolar.Tables["_RefObjCommon"].Rows.Count - 1);
                            }
                        }
                        else
                        {
                            int num1 = (int)MessageBox.Show("HATA!!! 2.İşlem Yapılamadı....");
                        }
                    }
                    else
                    {
                        int num2 = (int)MessageBox.Show("NPC ismi, bsr, Oyunda Görünecek Ad yada NPC Konuşma penceresini boş bıraktınız\nLütfen kontrol edin\nNPC ismi \"NPC_\" ile başlamalıdır...");
                        this.dsTablolar.Tables["_RefObjChar"].Rows.RemoveAt(this.dsTablolar.Tables["_RefObjChar"].Rows.Count - 1);
                    }
                }
                else
                {
                    int num3 = (int)MessageBox.Show("HATA!!! 1.İşlem Yapılamadı...");
                }
            }
            else if (this._adimlariSay == 1)
            {
                if (this.cmbBolge.Text != "")
                {
                    if (this.tbOlustur.Tab_RefHive(this.dsTablolar, this.cmbBolge.Text))
                    {
                        ++this._adimlariSay;
                    }
                    else
                    {
                        int num4 = (int)MessageBox.Show("HATA!!! Lütfen Listeden Seçim Yapın...");
                    }
                }
            }
            else if (this._adimlariSay == 2)
            {
                if (this.tbOlustur.Tab_RefNest(this.dsTablolar, this.txtX.Text, this.txtY.Text, this.txtZ.Text, this.txtYon.Text, this.bolgeNo))
                {
                    this.bolgeAdi = this.cmbBolge.Text;
                    ++this._adimlariSay;
                }
            }
            else if (this._adimlariSay == 3)
            {
                if (this.txtGrup.Text != "")
                {
                    if (this.tbOlustur.GruplariOlustur(this.dsTablolar, this.txtNpcIsmi.Text))
                    {
                        if (this.tbOlustur.GurupVeAdlariOlustur(this.dsTablolar, this.txtNpcIsmi.Text, this._grSiraNo, this.txtGrup.Text))
                        {
                            ++this._adimlariSay;
                        }
                        else
                        {
                            this.dsTablolar.Tables["_RefShop"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShop"].Rows.Count - 1);
                            this.dsTablolar.Tables["_RefShopGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopGroup"].Rows.Count - 1);
                            this.dsTablolar.Tables["_RefMappingShopGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefMappingShopGroup"].Rows.Count - 1);
                            this.dsTablolar.Tables["idOlmayan_RefMappingShopGroup"].Rows.RemoveAt(this.dsTablolar.Tables["idOlmayan_RefMappingShopGroup"].Rows.Count - 1);
                            if (this.dsTablolar.Tables["idOlmayan_RefMappingShopGroup"].Rows.Count == 0)
                                this.dsTablolar.Tables.Remove("idOlmayan_RefMappingShopGroup");
                        }
                    }
                }
                else
                {
                    int num5 = (int)MessageBox.Show("HATA!!! NPC İtem Guruplaması BOŞ Olamaz!!!");
                }
            }
            else if (this._adimlariSay == 4)
            {
                if (this.txtTab1.Text != "" && this.txtTMen1.Text != "")
                {
                    string[] strArray = this.tbOlustur._RefShopTab(this.dsTablolar, this.txtNpcIsmi.Text, new string[4]
                    {
            this.txtTab1.Text,
            this.txtTab2.Text,
            this.txtTab3.Text,
            this.txtTab4.Text
                    }, new string[4]
                    {
            this.txtTMen1.Text,
            this.txtTMen2.Text,
            this.txtTMen3.Text,
            this.txtTMen4.Text
                    }, this._grSiraNo, this._tabSay);
                    if (strArray[0] == "true")
                    {
                        this._tabSay = Convert.ToInt32(strArray[1]);
                        this._sonTab = Convert.ToInt32(strArray[2]);
                        ++this._adimlariSay;
                    }
                }
                else
                {
                    int num6 = (int)MessageBox.Show("Enaz Bir tab ismi ve tab menü ismi girmelisiniz");
                }
            }
            else if (this._adimlariSay == 6)
            {
                if (this.txtGrup.Text != "")
                {
                    if (this.tbOlustur.GurupVeAdlariOlusturTekrar(this.dsTablolar, this.txtNpcIsmi.Text, this._grSiraNo, this.txtGrup.Text))
                        ++this._adimlariSay;
                }
                else
                {
                    int num7 = (int)MessageBox.Show("HATA!!! NPC İtem Guruplaması BOŞ Olamaz!!!");
                }
            }
            else if (this._adimlariSay == 7)
            {
                if (this.txtTab1.Text != "" && this.txtTMen1.Text != "")
                {
                    string[] strArray = this.tbOlustur._RefShopTabTekrar(this.dsTablolar, this.txtNpcIsmi.Text, new string[4]
                    {
            this.txtTab1.Text,
            this.txtTab2.Text,
            this.txtTab3.Text,
            this.txtTab4.Text
                    }, new string[4]
                    {
            this.txtTMen1.Text,
            this.txtTMen2.Text,
            this.txtTMen3.Text,
            this.txtTMen4.Text
                    }, this._grSiraNo, this._tabSay);
                    if (strArray[0] == "true")
                    {
                        this._tabSay = Convert.ToInt32(strArray[1]);
                        this._sonTab = Convert.ToInt32(strArray[2]);
                        ++this._adimlariSay;
                    }
                }
                else
                {
                    int num8 = (int)MessageBox.Show("Enaz Bir tab ismi ve tab menü ismi girmelisiniz");
                }
            }
            this.ButonKontrol(this._adimlariSay);
        }

        private void btnOnceki_Click(object sender, EventArgs e)
        {
            if (this._adimlariSay > 0)
            {
                --this._adimlariSay;
            }
            else
            {
                int num = (int)MessageBox.Show("Enbaşa Geldiniz Zaten!!!");
                this._adimlariSay = 0;
            }
            if (this._adimlariSay == 0)
            {
                this.dsTablolar.Tables["_RefObjChar"].Rows.RemoveAt(this.dsTablolar.Tables["_RefObjChar"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefObjCommon"].Rows.RemoveAt(this.dsTablolar.Tables["_RefObjCommon"].Rows.Count - 1);
                this.dsTablolar.Tables["Tab_RefTactics"].Rows.RemoveAt(this.dsTablolar.Tables["Tab_RefTactics"].Rows.Count - 1);
            }
            else if (this._adimlariSay == 1)
                this.dsTablolar.Tables["Tab_RefHive"].Rows.RemoveAt(this.dsTablolar.Tables["Tab_RefHive"].Rows.Count - 1);
            else if (this._adimlariSay == 3)
            {
                this.dsTablolar.Tables["_RefShop"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShop"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefShopGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopGroup"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefMappingShopGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefMappingShopGroup"].Rows.Count - 1);
                this.dsTablolar.Tables["idOlmayan_RefMappingShopGroup"].Rows.RemoveAt(this.dsTablolar.Tables["idOlmayan_RefMappingShopGroup"].Rows.Count - 1);
                if (this.dsTablolar.Tables["idOlmayan_RefMappingShopGroup"].Rows.Count == 0)
                    this.dsTablolar.Tables.Remove("idOlmayan_RefMappingShopGroup");
                this.dsTablolar.Tables["_RefShopItemGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopItemGroup"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefShopTabGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopTabGroup"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefMappingShopWithTab"].Rows.RemoveAt(this.dsTablolar.Tables["_RefMappingShopWithTab"].Rows.Count - 1);
                this.dsTablolar.Tables["idOlmayan__RefMappingShopWithTab"].Rows.RemoveAt(this.dsTablolar.Tables["idOlmayan__RefMappingShopWithTab"].Rows.Count - 1);
                this.dsTablolar.Tables["GurupAdi"].Rows.RemoveAt(this.dsTablolar.Tables["GurupAdi"].Rows.Count - 1);
                if (this.dsTablolar.Tables["idOlmayan__RefMappingShopWithTab"].Rows.Count == 0)
                    this.dsTablolar.Tables.Remove("idOlmayan__RefMappingShopWithTab");
                if (this.dsTablolar.Tables["GurupAdi"].Rows.Count == 0)
                    this.dsTablolar.Tables.Remove("GurupAdi");
            }
            else if (this._adimlariSay == 4)
            {
                for (int index = 0; index < this._sonTab; ++index)
                    this.dsTablolar.Tables["_RefShopTab"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopTab"].Rows.Count - 1);
                this.dsTablolar.Tables.Remove("snTabAdi");
                this.dsTablolar.Tables.Remove("kayit_RefShopTab");
                this._tabSay = 0;
                this._grSiraNo = 1;
            }
            else if (this._adimlariSay == 6)
            {
                this.dsTablolar.Tables["_RefShopItemGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopItemGroup"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefShopTabGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopTabGroup"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefMappingShopWithTab"].Rows.RemoveAt(this.dsTablolar.Tables["_RefMappingShopWithTab"].Rows.Count - 1);
                this.dsTablolar.Tables["idOlmayan__RefMappingShopWithTab"].Rows.RemoveAt(this.dsTablolar.Tables["idOlmayan__RefMappingShopWithTab"].Rows.Count - 1);
                this.dsTablolar.Tables["GurupAdi"].Rows.RemoveAt(this.dsTablolar.Tables["GurupAdi"].Rows.Count - 1);
            }
            else if (this._adimlariSay == 7)
            {
                for (int index = 0; index < this._sonTab; ++index)
                {
                    this.dsTablolar.Tables["_RefShopTab"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopTab"].Rows.Count - 1);
                    this.dsTablolar.Tables["snTabAdi"].Rows.RemoveAt(this.dsTablolar.Tables["snTabAdi"].Rows.Count - 1);
                    this.dsTablolar.Tables["kayit_RefShopTab"].Rows.RemoveAt(this.dsTablolar.Tables["kayit_RefShopTab"].Rows.Count - 1);
                }
                this._tabSay -= this._sonTab;
            }
            this.ButonKontrol(this._adimlariSay);
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            try
            {
                this._adimlariSay = 0;
                this.ButonKontrol(this._adimlariSay);
                this.dsTablolar.Tables["_RefObjChar"].Rows.RemoveAt(this.dsTablolar.Tables["_RefObjChar"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefObjCommon"].Rows.RemoveAt(this.dsTablolar.Tables["_RefObjCommon"].Rows.Count - 1);
                this.dsTablolar.Tables["Tab_RefTactics"].Rows.RemoveAt(this.dsTablolar.Tables["Tab_RefTactics"].Rows.Count - 1);
                this.dsTablolar.Tables["Tab_RefHive"].Rows.RemoveAt(this.dsTablolar.Tables["Tab_RefHive"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefShop"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShop"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefShopGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopGroup"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefMappingShopGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefMappingShopGroup"].Rows.Count - 1);
                this.dsTablolar.Tables.Remove("idOlmayan_RefMappingShopGroup");
                this.dsTablolar.Tables["_RefShopItemGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopItemGroup"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefShopTabGroup"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopTabGroup"].Rows.Count - 1);
                this.dsTablolar.Tables["_RefMappingShopWithTab"].Rows.RemoveAt(this.dsTablolar.Tables["_RefMappingShopWithTab"].Rows.Count - 1);
                this.dsTablolar.Tables.Remove("idOlmayan__RefMappingShopWithTab");
                this.dsTablolar.Tables.Remove("GurupAdi");
                for (int index = 0; index < this._tabSay; ++index)
                    this.dsTablolar.Tables["_RefShopTab"].Rows.RemoveAt(this.dsTablolar.Tables["_RefShopTab"].Rows.Count - 1);
                this.dsTablolar.Tables.Remove("snTabAdi");
                this.dsTablolar.Tables.Remove("kayit_RefShopTab");
                this._grSiraNo = 1;
                this._tabSay = 0;
                this.txtChat.Text = "";
                this.txtGorunen.Text = "";
                this.txtGrup.Text = "";
                this.txtNpcIsmi.Text = "NPC_";
                this.txtTab1.Text = "";
                this.txtTab2.Text = "";
                this.txtTab3.Text = "";
                this.txtTab4.Text = "";
                this.txtTMen1.Text = "";
                this.txtTMen2.Text = "";
                this.txtTMen3.Text = "";
                this.txtTMen4.Text = "";
                this.txtX.Text = "";
                this.txtY.Text = "";
                this.txtYon.Text = "0";
                this.txtZ.Text = "";
                this.cmbBolge.Text = "Lütfen Seçiniz";
                this.cmbBSR.Text = "Lütfen Seçiniz";
                this.cmbCharAdi.Text = "Lütfen Seçiniz";
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("HATA OLUŞTU!!! Geriye Dönüş Sağlanamadı.\nProgramı Kapatıp Tekrar Açın");
            }
        }

        private void GruplariPasiveEt() => this.grPozisyon.Enabled = false;

        private void ButonKontrol(int sayi)
        {
            switch (sayi)
            {
                case 0:
                    this.grNPCIsmi.Enabled = true;
                    this.grNPCBolge.Enabled = false;
                    this.grPozisyon.Enabled = false;
                    this.grGrup.Enabled = false;
                    this.grTab.Enabled = false;
                    this.btnOnceki.Enabled = false;
                    this.btnSonraki.Enabled = true;
                    this.btnVazgec.Enabled = false;
                    this.btnKayit.Enabled = false;
                    break;
                case 1:
                    this.grNPCIsmi.Enabled = false;
                    this.grNPCBolge.Enabled = true;
                    this.grPozisyon.Enabled = false;
                    this.grGrup.Enabled = false;
                    this.grTab.Enabled = false;
                    this.btnOnceki.Enabled = true;
                    this.btnSonraki.Enabled = true;
                    this.btnVazgec.Enabled = true;
                    this.btnKayit.Enabled = false;
                    break;
                case 2:
                    this.grNPCIsmi.Enabled = false;
                    this.grNPCBolge.Enabled = false;
                    this.grPozisyon.Enabled = true;
                    this.grGrup.Enabled = false;
                    this.grTab.Enabled = false;
                    this.btnKayit.Enabled = false;
                    this.btnOnceki.Enabled = true;
                    this.btnSonraki.Enabled = true;
                    this.btnVazgec.Enabled = true;
                    this.btnKayit.Enabled = false;
                    break;
                case 3:
                    this.grNPCIsmi.Enabled = false;
                    this.grNPCBolge.Enabled = false;
                    this.grPozisyon.Enabled = false;
                    this.grGrup.Enabled = true;
                    this.grTab.Enabled = false;
                    this.btnOnceki.Enabled = true;
                    this.btnSonraki.Enabled = true;
                    this.btnVazgec.Enabled = true;
                    this.btnKayit.Enabled = false;
                    break;
                case 4:
                    this.grNPCIsmi.Enabled = false;
                    this.grNPCBolge.Enabled = false;
                    this.grPozisyon.Enabled = false;
                    this.grGrup.Enabled = false;
                    this.grTab.Enabled = true;
                    this.btnOnceki.Enabled = true;
                    this.btnSonraki.Enabled = true;
                    this.btnVazgec.Enabled = true;
                    this.btnKayit.Enabled = false;
                    break;
                case 5:
                    this.btnKayit.Enabled = true;
                    this.btnOnceki.Enabled = true;
                    this.btnSonraki.Enabled = false;
                    this.btnVazgec.Enabled = true;
                    this.grNPCIsmi.Enabled = false;
                    this.grNPCBolge.Enabled = false;
                    this.grPozisyon.Enabled = false;
                    this.grGrup.Enabled = false;
                    this.grTab.Enabled = false;
                    break;
                case 6:
                    this.btnKayit.Enabled = false;
                    this.btnOnceki.Enabled = false;
                    this.btnSonraki.Enabled = true;
                    this.btnVazgec.Enabled = true;
                    this.grNPCIsmi.Enabled = false;
                    this.grNPCBolge.Enabled = false;
                    this.grPozisyon.Enabled = false;
                    this.grGrup.Enabled = true;
                    this.grTab.Enabled = false;
                    break;
                case 7:
                    this.grNPCIsmi.Enabled = false;
                    this.grNPCBolge.Enabled = false;
                    this.grPozisyon.Enabled = false;
                    this.grGrup.Enabled = false;
                    this.grTab.Enabled = true;
                    this.btnOnceki.Enabled = true;
                    this.btnSonraki.Enabled = true;
                    this.btnVazgec.Enabled = true;
                    this.btnKayit.Enabled = false;
                    break;
                case 8:
                    this.btnKayit.Enabled = true;
                    this.btnOnceki.Enabled = true;
                    this.btnSonraki.Enabled = false;
                    this.btnVazgec.Enabled = true;
                    this.grNPCIsmi.Enabled = false;
                    this.grNPCBolge.Enabled = false;
                    this.grPozisyon.Enabled = false;
                    this.grGrup.Enabled = false;
                    this.grTab.Enabled = false;
                    break;
            }
        }

        private void btnYeniGrup_Click(object sender, EventArgs e)
        {
            if (this._adimlariSay == 4)
            {
                if (this.txtTab1.Text != "" && this.txtTMen1.Text != "")
                {
                    string[] strArray = this.tbOlustur._RefShopTab(this.dsTablolar, this.txtNpcIsmi.Text, new string[4]
                    {
            this.txtTab1.Text,
            this.txtTab2.Text,
            this.txtTab3.Text,
            this.txtTab4.Text
                    }, new string[4]
                    {
            this.txtTMen1.Text,
            this.txtTMen2.Text,
            this.txtTMen3.Text,
            this.txtTMen4.Text
                    }, this._grSiraNo, this._tabSay);
                    if (strArray[0] == "true")
                    {
                        this._tabSay = Convert.ToInt32(strArray[1]);
                        this._sonTab = Convert.ToInt32(strArray[2]);
                        this._adimlariSay = 6;
                        ++this._grSiraNo;
                    }
                }
                else
                {
                    int num1 = (int)MessageBox.Show("Enaz Bir tab ismi ve tab menü ismi girmelisiniz");
                }
            }
            else if (this.txtTab1.Text != "" && this.txtTMen1.Text != "")
            {
                string[] strArray = this.tbOlustur._RefShopTabTekrar(this.dsTablolar, this.txtNpcIsmi.Text, new string[4]
                {
          this.txtTab1.Text,
          this.txtTab2.Text,
          this.txtTab3.Text,
          this.txtTab4.Text
                }, new string[4]
                {
          this.txtTMen1.Text,
          this.txtTMen2.Text,
          this.txtTMen3.Text,
          this.txtTMen4.Text
                }, this._grSiraNo, this._tabSay);
                if (strArray[0] == "true")
                {
                    this._tabSay = Convert.ToInt32(strArray[1]);
                    this._sonTab = Convert.ToInt32(strArray[2]);
                    this._adimlariSay = 6;
                    ++this._grSiraNo;
                }
            }
            else
            {
                int num2 = (int)MessageBox.Show("Enaz Bir tab ismi ve tab menü ismi girmelisiniz");
            }
            this.ButonKontrol(this._adimlariSay);
        }

        private void cmbCharAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dsTablolar.Tables.Remove("_Char");
            if (!this.tbOlustur.CharTablosuCek(this.dsTablolar))
                return;
            this.CharPozisin();
        }

        private void CharPozisin()
        {
            int index1 = 0;
            try
            {
                for (int index2 = 0; index2 < this.dsTablolar.Tables["_Char"].Rows.Count; ++index2)
                {
                    if (this.dsTablolar.Tables["_Char"].Rows[index2]["CharName16"].ToString() == this.cmbCharAdi.Text)
                        index1 = index2;
                }
                if (index1 <= 0)
                    return;
                this.bolgeNo = this.dsTablolar.Tables["_Char"].Rows[index1]["LatestRegion"].ToString();
                this.txtX.Text = this.dsTablolar.Tables["_Char"].Rows[index1]["PosX"].ToString();
                this.txtY.Text = this.dsTablolar.Tables["_Char"].Rows[index1]["PosY"].ToString();
                this.txtZ.Text = this.dsTablolar.Tables["_Char"].Rows[index1]["PosZ"].ToString();
            }
            catch
            {
            }
        }

        private void CharAdiDoldur()
        {
            for (int index = 0; index < this.dsTablolar.Tables["_Char"].Rows.Count; ++index)
                this.cmbCharAdi.Items.Add((object)this.dsTablolar.Tables["_Char"].Rows[index]["CharName16"].ToString());
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            this.btnKayit.Enabled = false;
            this.btnOnceki.Enabled = false;
            this.btnVazgec.Text = "Yeni NPC Oluştur";
            int num = (int)new Bilgi()
            {
                ac = true,
                _uyariMetni = "Tüm Bilgiler Alındı\nSQLServer ve Medya.PK2 Dosyalarına Eklenecek Dosyalar Oluşturulacak\nEmin misiniz?",
                tabloSet = this.dsTablolar,
                bolge = this.bolgeAdi,
                grNo = this._grSiraNo,
                tabSayisi = this._tabSay,
                _npcAdi = this.txtNpcIsmi.Text,
                _gorunenAd = this.txtGorunen.Text,
                _npcMetin = this.txtChat.Text,
                _nerdenGeldigi = "NPC"
            }.ShowDialog();
        }

        private void cmbBSR_MouseClick(object sender, MouseEventArgs e)
        {
            int num = (int)new bsr() { npc = this }.ShowDialog();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }
        private void NPCDirection_Click(object sender, EventArgs e)
        {
            NPCPos.NPCYon NPCYon = new NPCPos.NPCYon();
            NPCYon.ShowDialog();
        }
        private void InitializeComponent()
        {
            this.btnOnceki = new System.Windows.Forms.Button();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.btnSonraki = new System.Windows.Forms.Button();
            this.grNPCIsmi = new System.Windows.Forms.GroupBox();
            this.cmbBSR = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGorunen = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNpcIsmi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grPozisyon = new System.Windows.Forms.GroupBox();
            this.NPCDirection = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCharAdi = new System.Windows.Forms.ComboBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.grGrup = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGrup = new System.Windows.Forms.TextBox();
            this.grNPCBolge = new System.Windows.Forms.GroupBox();
            this.cmbBolge = new System.Windows.Forms.ComboBox();
            this.grTab = new System.Windows.Forms.GroupBox();
            this.btnYeniGrup = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTMen4 = new System.Windows.Forms.TextBox();
            this.txtTab4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTMen3 = new System.Windows.Forms.TextBox();
            this.txtTab3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTMen2 = new System.Windows.Forms.TextBox();
            this.txtTab2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTMen1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTab1 = new System.Windows.Forms.TextBox();
            this.btnKayit = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grNPCIsmi.SuspendLayout();
            this.grPozisyon.SuspendLayout();
            this.grGrup.SuspendLayout();
            this.grNPCBolge.SuspendLayout();
            this.grTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOnceki
            // 
            this.btnOnceki.BackColor = System.Drawing.Color.Lavender;
            this.btnOnceki.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOnceki.ForeColor = System.Drawing.Color.Black;
            this.btnOnceki.ImageKey = "(none)";
            this.btnOnceki.Location = new System.Drawing.Point(143, 15);
            this.btnOnceki.Name = "btnOnceki";
            this.btnOnceki.Size = new System.Drawing.Size(113, 29);
            this.btnOnceki.TabIndex = 0;
            this.btnOnceki.Text = "<<-Bir Önceki<<-";
            this.btnOnceki.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOnceki.UseVisualStyleBackColor = false;
            this.btnOnceki.Click += new System.EventHandler(this.btnOnceki_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.BackColor = System.Drawing.Color.Lavender;
            this.btnVazgec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVazgec.ForeColor = System.Drawing.Color.Black;
            this.btnVazgec.Location = new System.Drawing.Point(401, 15);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(113, 29);
            this.btnVazgec.TabIndex = 1;
            this.btnVazgec.Text = "->>Vazgeç<<-";
            this.btnVazgec.UseVisualStyleBackColor = false;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnSonraki
            // 
            this.btnSonraki.BackColor = System.Drawing.Color.Lavender;
            this.btnSonraki.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSonraki.ForeColor = System.Drawing.Color.Black;
            this.btnSonraki.Location = new System.Drawing.Point(272, 15);
            this.btnSonraki.Name = "btnSonraki";
            this.btnSonraki.Size = new System.Drawing.Size(113, 29);
            this.btnSonraki.TabIndex = 2;
            this.btnSonraki.Text = "->>Bir Sonraki->>";
            this.btnSonraki.UseVisualStyleBackColor = false;
            this.btnSonraki.Click += new System.EventHandler(this.btnSonraki_Click);
            // 
            // grNPCIsmi
            // 
            this.grNPCIsmi.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.grNPCIsmi.BackColor = System.Drawing.Color.Transparent;
            this.grNPCIsmi.Controls.Add(this.cmbBSR);
            this.grNPCIsmi.Controls.Add(this.label18);
            this.grNPCIsmi.Controls.Add(this.txtChat);
            this.grNPCIsmi.Controls.Add(this.label17);
            this.grNPCIsmi.Controls.Add(this.txtGorunen);
            this.grNPCIsmi.Controls.Add(this.label16);
            this.grNPCIsmi.Controls.Add(this.txtNpcIsmi);
            this.grNPCIsmi.Controls.Add(this.label1);
            this.grNPCIsmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grNPCIsmi.ForeColor = System.Drawing.Color.Yellow;
            this.grNPCIsmi.Location = new System.Drawing.Point(9, 69);
            this.grNPCIsmi.Name = "grNPCIsmi";
            this.grNPCIsmi.Size = new System.Drawing.Size(337, 231);
            this.grNPCIsmi.TabIndex = 3;
            this.grNPCIsmi.TabStop = false;
            this.grNPCIsmi.Text = "NPC İsmi";
            // 
            // cmbBSR
            // 
            this.cmbBSR.BackColor = System.Drawing.Color.AliceBlue;
            this.cmbBSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbBSR.Location = new System.Drawing.Point(13, 47);
            this.cmbBSR.Name = "cmbBSR";
            this.cmbBSR.Size = new System.Drawing.Size(163, 20);
            this.cmbBSR.TabIndex = 8;
            this.cmbBSR.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbBSR_MouseClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(12, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(305, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Npc Konuşma Penceresi. ***Önemli:\"ENTER tuşu kullanmayın\"";
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.Color.AliceBlue;
            this.txtChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtChat.Location = new System.Drawing.Point(13, 126);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(314, 99);
            this.txtChat.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(179, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Oyunda Görünecek Ad";
            // 
            // txtGorunen
            // 
            this.txtGorunen.BackColor = System.Drawing.Color.AliceBlue;
            this.txtGorunen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGorunen.Location = new System.Drawing.Point(13, 74);
            this.txtGorunen.Name = "txtGorunen";
            this.txtGorunen.Size = new System.Drawing.Size(163, 20);
            this.txtGorunen.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(178, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "*.bsr Listesi";
            // 
            // txtNpcIsmi
            // 
            this.txtNpcIsmi.BackColor = System.Drawing.Color.AliceBlue;
            this.txtNpcIsmi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNpcIsmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNpcIsmi.Location = new System.Drawing.Point(13, 19);
            this.txtNpcIsmi.Name = "txtNpcIsmi";
            this.txtNpcIsmi.Size = new System.Drawing.Size(163, 20);
            this.txtNpcIsmi.TabIndex = 0;
            this.txtNpcIsmi.Text = "NPC_";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(176, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "**Türkçe Karekter Kullanmayın";
            // 
            // grPozisyon
            // 
            this.grPozisyon.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.grPozisyon.BackColor = System.Drawing.Color.Transparent;
            this.grPozisyon.Controls.Add(this.NPCDirection);
            this.grPozisyon.Controls.Add(this.label6);
            this.grPozisyon.Controls.Add(this.txtYon);
            this.grPozisyon.Controls.Add(this.label5);
            this.grPozisyon.Controls.Add(this.txtZ);
            this.grPozisyon.Controls.Add(this.label4);
            this.grPozisyon.Controls.Add(this.txtY);
            this.grPozisyon.Controls.Add(this.label3);
            this.grPozisyon.Controls.Add(this.label2);
            this.grPozisyon.Controls.Add(this.cmbCharAdi);
            this.grPozisyon.Controls.Add(this.txtX);
            this.grPozisyon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grPozisyon.ForeColor = System.Drawing.Color.Yellow;
            this.grPozisyon.Location = new System.Drawing.Point(367, 69);
            this.grPozisyon.Name = "grPozisyon";
            this.grPozisyon.Size = new System.Drawing.Size(428, 123);
            this.grPozisyon.TabIndex = 4;
            this.grPozisyon.TabStop = false;
            this.grPozisyon.Text = "NPC Pozisyonu";
            // 
            // NPCDirection
            // 
            this.NPCDirection.BackColor = System.Drawing.Color.Lavender;
            this.NPCDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.NPCDirection.ForeColor = System.Drawing.Color.Black;
            this.NPCDirection.Location = new System.Drawing.Point(6, 94);
            this.NPCDirection.Name = "NPCDirection";
            this.NPCDirection.Size = new System.Drawing.Size(410, 23);
            this.NPCDirection.TabIndex = 10;
            this.NPCDirection.Text = "       >>>NPC Yönünü Öğrenmek İçin Tıkla<<<";
            this.NPCDirection.UseVisualStyleBackColor = false;
            this.NPCDirection.Click += new System.EventHandler(this.NPCDirection_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(326, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "NPC Yönü";
            // 
            // txtYon
            // 
            this.txtYon.BackColor = System.Drawing.Color.AliceBlue;
            this.txtYon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtYon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYon.Location = new System.Drawing.Point(323, 72);
            this.txtYon.Name = "txtYon";
            this.txtYon.Size = new System.Drawing.Size(92, 20);
            this.txtYon.TabIndex = 8;
            this.txtYon.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(221, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Poz-Z";
            // 
            // txtZ
            // 
            this.txtZ.BackColor = System.Drawing.Color.AliceBlue;
            this.txtZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtZ.Location = new System.Drawing.Point(218, 72);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(92, 20);
            this.txtZ.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(115, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Poz-Y";
            // 
            // txtY
            // 
            this.txtY.BackColor = System.Drawing.Color.AliceBlue;
            this.txtY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtY.Location = new System.Drawing.Point(112, 72);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(92, 20);
            this.txtY.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Poz-X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(173, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "**Daha Önce belilediğiniz Charın Pozisyonunu Alın";
            // 
            // cmbCharAdi
            // 
            this.cmbCharAdi.BackColor = System.Drawing.Color.AliceBlue;
            this.cmbCharAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCharAdi.FormattingEnabled = true;
            this.cmbCharAdi.Location = new System.Drawing.Point(7, 20);
            this.cmbCharAdi.Name = "cmbCharAdi";
            this.cmbCharAdi.Size = new System.Drawing.Size(160, 21);
            this.cmbCharAdi.TabIndex = 1;
            this.cmbCharAdi.Text = "Lütfen Seçin";
            this.cmbCharAdi.SelectedIndexChanged += new System.EventHandler(this.cmbCharAdi_SelectedIndexChanged);
            // 
            // txtX
            // 
            this.txtX.BackColor = System.Drawing.Color.AliceBlue;
            this.txtX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtX.Location = new System.Drawing.Point(7, 72);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(92, 20);
            this.txtX.TabIndex = 0;
            // 
            // grGrup
            // 
            this.grGrup.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.grGrup.BackColor = System.Drawing.Color.Transparent;
            this.grGrup.Controls.Add(this.label7);
            this.grGrup.Controls.Add(this.groupBox1);
            this.grGrup.Controls.Add(this.label11);
            this.grGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grGrup.ForeColor = System.Drawing.Color.Yellow;
            this.grGrup.Location = new System.Drawing.Point(9, 355);
            this.grGrup.Name = "grGrup";
            this.grGrup.Size = new System.Drawing.Size(337, 136);
            this.grGrup.TabIndex = 5;
            this.grGrup.TabStop = false;
            this.grGrup.Text = "NPC İtem Gruplaması";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(8, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(233, 65);
            this.label11.TabIndex = 2;
            this.label11.Text = "NPC\'Tıklandığında Açılan Penceredeki Grup Adı\r\nÖrnek : \'Avatar Mall\' Gibi Bu Grou" +
    "p1 Olur.\r\n1.Avatar Mall\r\n2.Pet Shop\r\nGibisinden.";
            // 
            // txtGrup
            // 
            this.txtGrup.BackColor = System.Drawing.Color.AliceBlue;
            this.txtGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGrup.Location = new System.Drawing.Point(77, 12);
            this.txtGrup.Name = "txtGrup";
            this.txtGrup.Size = new System.Drawing.Size(221, 20);
            this.txtGrup.TabIndex = 0;
            // 
            // grNPCBolge
            // 
            this.grNPCBolge.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.grNPCBolge.BackColor = System.Drawing.Color.Transparent;
            this.grNPCBolge.Controls.Add(this.label22);
            this.grNPCBolge.Controls.Add(this.label19);
            this.grNPCBolge.Controls.Add(this.cmbBolge);
            this.grNPCBolge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grNPCBolge.ForeColor = System.Drawing.Color.Yellow;
            this.grNPCBolge.Location = new System.Drawing.Point(9, 302);
            this.grNPCBolge.Name = "grNPCBolge";
            this.grNPCBolge.Size = new System.Drawing.Size(337, 50);
            this.grNPCBolge.TabIndex = 6;
            this.grNPCBolge.TabStop = false;
            this.grNPCBolge.Text = "NPC Eklenecek Bölge";
            // 
            // cmbBolge
            // 
            this.cmbBolge.BackColor = System.Drawing.Color.AliceBlue;
            this.cmbBolge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbBolge.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBolge.FormattingEnabled = true;
            this.cmbBolge.Items.AddRange(new object[] {
            "JANGAN",
            "DONWHANG",
            "HOTAN",
            "SEMERKAND",
            "CONSTANTINE",
            "ALEXANDRIA",
            "JUPITER"});
            this.cmbBolge.Location = new System.Drawing.Point(60, 19);
            this.cmbBolge.Name = "cmbBolge";
            this.cmbBolge.Size = new System.Drawing.Size(134, 21);
            this.cmbBolge.TabIndex = 2;
            this.cmbBolge.Text = "Lütfen Seçin";
            // 
            // grTab
            // 
            this.grTab.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.grTab.BackColor = System.Drawing.Color.Transparent;
            this.grTab.Controls.Add(this.label21);
            this.grTab.Controls.Add(this.btnYeniGrup);
            this.grTab.Controls.Add(this.label15);
            this.grTab.Controls.Add(this.label14);
            this.grTab.Controls.Add(this.txtTMen4);
            this.grTab.Controls.Add(this.txtTab4);
            this.grTab.Controls.Add(this.label13);
            this.grTab.Controls.Add(this.txtTMen3);
            this.grTab.Controls.Add(this.txtTab3);
            this.grTab.Controls.Add(this.label12);
            this.grTab.Controls.Add(this.txtTMen2);
            this.grTab.Controls.Add(this.txtTab2);
            this.grTab.Controls.Add(this.label10);
            this.grTab.Controls.Add(this.txtTMen1);
            this.grTab.Controls.Add(this.label8);
            this.grTab.Controls.Add(this.label9);
            this.grTab.Controls.Add(this.txtTab1);
            this.grTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grTab.ForeColor = System.Drawing.Color.Yellow;
            this.grTab.Location = new System.Drawing.Point(367, 195);
            this.grTab.Name = "grTab";
            this.grTab.Size = new System.Drawing.Size(428, 296);
            this.grTab.TabIndex = 7;
            this.grTab.TabStop = false;
            this.grTab.Text = "NPC Tab İsimleri";
            // 
            // btnYeniGrup
            // 
            this.btnYeniGrup.BackColor = System.Drawing.Color.Lavender;
            this.btnYeniGrup.ForeColor = System.Drawing.Color.Black;
            this.btnYeniGrup.Location = new System.Drawing.Point(131, 205);
            this.btnYeniGrup.Name = "btnYeniGrup";
            this.btnYeniGrup.Size = new System.Drawing.Size(184, 40);
            this.btnYeniGrup.TabIndex = 4;
            this.btnYeniGrup.Text = "Yeni Bir Grup Oluştur";
            this.btnYeniGrup.UseVisualStyleBackColor = false;
            this.btnYeniGrup.Click += new System.EventHandler(this.btnYeniGrup_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(9, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(393, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "**Menüde Görülecek Kısımda Boşluk Kullanabilirsniz.. Enaz 1 Enfazla 4 TAB olmalı";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(46, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "TAB4";
            // 
            // txtTMen4
            // 
            this.txtTMen4.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTMen4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTMen4.Location = new System.Drawing.Point(230, 179);
            this.txtTMen4.Name = "txtTMen4";
            this.txtTMen4.Size = new System.Drawing.Size(130, 20);
            this.txtTMen4.TabIndex = 13;
            // 
            // txtTab4
            // 
            this.txtTab4.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTab4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTab4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTab4.Location = new System.Drawing.Point(84, 179);
            this.txtTab4.Name = "txtTab4";
            this.txtTab4.Size = new System.Drawing.Size(130, 20);
            this.txtTab4.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(46, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "TAB3";
            // 
            // txtTMen3
            // 
            this.txtTMen3.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTMen3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTMen3.Location = new System.Drawing.Point(230, 153);
            this.txtTMen3.Name = "txtTMen3";
            this.txtTMen3.Size = new System.Drawing.Size(130, 20);
            this.txtTMen3.TabIndex = 10;
            // 
            // txtTab3
            // 
            this.txtTab3.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTab3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTab3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTab3.Location = new System.Drawing.Point(84, 153);
            this.txtTab3.Name = "txtTab3";
            this.txtTab3.Size = new System.Drawing.Size(130, 20);
            this.txtTab3.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(46, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "TAB2";
            // 
            // txtTMen2
            // 
            this.txtTMen2.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTMen2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTMen2.Location = new System.Drawing.Point(230, 127);
            this.txtTMen2.Name = "txtTMen2";
            this.txtTMen2.Size = new System.Drawing.Size(130, 20);
            this.txtTMen2.TabIndex = 7;
            // 
            // txtTab2
            // 
            this.txtTab2.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTab2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTab2.Location = new System.Drawing.Point(84, 127);
            this.txtTab2.Name = "txtTab2";
            this.txtTab2.Size = new System.Drawing.Size(130, 20);
            this.txtTab2.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(46, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "TAB1";
            // 
            // txtTMen1
            // 
            this.txtTMen1.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTMen1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTMen1.Location = new System.Drawing.Point(230, 101);
            this.txtTMen1.Name = "txtTMen1";
            this.txtTMen1.Size = new System.Drawing.Size(130, 20);
            this.txtTMen1.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(247, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 26);
            this.label8.TabIndex = 3;
            this.label8.Text = "      TAB İSMİ\r\n(Oyunda Görünen)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(46, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(319, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "**Türkçe karakter kullanmayın ve boşluk olmadan tab bir isim verin";
            // 
            // txtTab1
            // 
            this.txtTab1.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTab1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTab1.Location = new System.Drawing.Point(84, 101);
            this.txtTab1.Name = "txtTab1";
            this.txtTab1.Size = new System.Drawing.Size(130, 20);
            this.txtTab1.TabIndex = 0;
            // 
            // btnKayit
            // 
            this.btnKayit.BackColor = System.Drawing.Color.Lavender;
            this.btnKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayit.ForeColor = System.Drawing.Color.Black;
            this.btnKayit.Location = new System.Drawing.Point(532, 15);
            this.btnKayit.Name = "btnKayit";
            this.btnKayit.Size = new System.Drawing.Size(113, 32);
            this.btnKayit.TabIndex = 8;
            this.btnKayit.Text = "<<-İşlemi Bitir->>";
            this.btnKayit.UseVisualStyleBackColor = false;
            this.btnKayit.Click += new System.EventHandler(this.btnKayit_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(10, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Bölgeler :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(11, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "GRUP İSMİ:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(98, 70);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 26);
            this.label21.TabIndex = 16;
            this.label21.Text = "     TAB KODU\r\n(Tablodaki Kod Adı)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(197, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(136, 13);
            this.label22.TabIndex = 4;
            this.label22.Text = "Npc\'nizin Bulunacağı Bölge";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGrup);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(10, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 39);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(65, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "İsteğinize bağlı... Enaz Bir Tane Girilmelidir!!!";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVazgec);
            this.groupBox2.Controls.Add(this.btnKayit);
            this.groupBox2.Controls.Add(this.btnOnceki);
            this.groupBox2.Controls.Add(this.btnSonraki);
            this.groupBox2.Location = new System.Drawing.Point(9, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(786, 58);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // NPCEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grTab);
            this.Controls.Add(this.grNPCBolge);
            this.Controls.Add(this.grGrup);
            this.Controls.Add(this.grPozisyon);
            this.Controls.Add(this.grNPCIsmi);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "NPCEkle";
            this.Size = new System.Drawing.Size(800, 505);
            this.Load += new System.EventHandler(this.NPCEkle_Load);
            this.grNPCIsmi.ResumeLayout(false);
            this.grNPCIsmi.PerformLayout();
            this.grPozisyon.ResumeLayout(false);
            this.grPozisyon.PerformLayout();
            this.grGrup.ResumeLayout(false);
            this.grGrup.PerformLayout();
            this.grNPCBolge.ResumeLayout(false);
            this.grNPCBolge.PerformLayout();
            this.grTab.ResumeLayout(false);
            this.grTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
