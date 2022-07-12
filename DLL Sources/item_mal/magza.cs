// Decompiled with JetBrains decompiler
// Type: item_mal.magza
// Assembly: item_mal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 19D66908-CAEF-4A5D-8729-25B953C4A897
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\item_mal.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TxTDosyaOlustur;

namespace item_mal
{
  public class magza : UserControl
  {
    private bool silinme = false;
    internal bool islem = false;
    public ToolStripMenuItem[] btn;
    private int sonSlot = 0;
    private int itemSlot = 0;
    private string tabIsmi = "";
    private string itemIsmi = "";
    private int ilk = 0;
    private int son = 0;
    private string dizin = Path.GetDirectoryName(Application.ExecutablePath) + "\\icon\\";
    private string[][][] liste;
    private DataTable _RefPackageItem;
    private DataTable _RefPricePolicyOfItem;
    private DataTable _RefScrapOfPackageItem;
    private DataTable _RefShopGoods;
    private DataTable _RefObjCommon;
    private DataTable _RefObjItem;
    private DataTable Gecici;
    private data dat;
    private TreeNode node;
    private Label lbl2;
    private Label lbl4;
    private Label lbl16;
    private string dizin1 = Path.GetDirectoryName(Application.ExecutablePath) + "\\KompleDegisecekTextDosyalari\\";
    private IContainer components = (IContainer) null;
    private GroupBox grpListe;
    private TreeView tree;
    private GroupBox grpItem;
    private FlowLayoutPanel flwItem;
    private Label lblBilgi;
    private GroupBox grpItemAdi;
    private GroupBox grpFiyat;
    private TextBox txtGif;
    private Label label3;
    private TextBox txtPoint;
    private Label label2;
    private TextBox txtSilk;
    private Label label1;
    private GroupBox grpDuzenleme;
    private Button btnKaydet;
    private Button btnDüzenle;
    private Button btnSil;
    private Button btnIptal;
    private Button btnYeni;
    private Button btnBitir;
    private Button btnVazgec;
    private ProgressBar proTxt;
    private GroupBox grpProIslem;

    public magza() => this.InitializeComponent();

    private void magza_Load(object sender, EventArgs e)
    {
      this.dat = new data();
      this.tabloDoldur();
      this.grpDuzenleme.Enabled = false;
      this.grpFiyat.Enabled = false;
      this.btnBitir.Enabled = false;
      this.btnYeni.Enabled = false;
      this.grpItem.Enabled = true;
      this.grpListe.Enabled = true;
      this.lbl2 = new Label();
      this.lbl4 = new Label();
      this.lbl16 = new Label();
      this.grpProIslem.Visible = false;
      this.grpProIslem.Text = "";
      this.proTxt.Minimum = 0;
      this.proTxt.Maximum = 100;
      this.proTxt.Step = 1;
      this.tree.Nodes.Add("Expendables");
      this.tree.Nodes.Add("Avarar");
      this.tree.Nodes.Add("Pet");
      this.tree.Nodes.Add("Premium");
      this.tree.Nodes.Add("Alchemy");
      this.liste = new string[this.tree.Nodes.Count][][];
      this.liste[0] = new string[5][];
      this.liste[1] = new string[5][];
      this.liste[2] = new string[7][];
      this.liste[3] = new string[3][];
      this.liste[4] = new string[3][];
      string[,] strArray1 = new string[5, 7]
      {
        {
          "MALL_CONSUME_SPECIAL",
          "MALL_CONSUME_SCROLL",
          "MALL_CONSUME_POTION",
          "MALL_CONSUME_COMMUNITY",
          "MALL_CONSUME_ETC",
          null,
          null
        },
        {
          "MALL_AVATAR_BOOTH",
          "MALL_AVATAR_HAT",
          "MALL_AVATAR_DRESS",
          "MALL_AVATAR_ATTACH",
          "MALL_AVATAR_BALLOON",
          null,
          null
        },
        {
          "MALL_PET_A_GROWTH",
          "MALL_PET_B_SILK",
          "MALL_PET_C_VEHICLE",
          "MALL_PET_D_CART",
          "MALL_PET_E_STORES",
          "MALL_FELLOWS_GROWTH",
          "MALL_FELLOWS_EQUIP"
        },
        {
          "MALL_PREMIUM_PREMIUM",
          "MALL_PREMIUM_NASRUN",
          "MALL_PREMIUM_NASRUN_ETC",
          "",
          "",
          null,
          null
        },
        {
          "MALL_ARCHEMY_ASTRAL",
          "MALL_ARCHEMY_ATHANASIA",
          "MALL_ARCHEMY_ETC",
          "",
          "",
          null,
          null
        }
      };
      string[,] strArray2 = new string[5, 7]
      {
        {
          "Special",
          "Order",
          "Potion",
          "Community",
          "Others",
          null,
          null
        },
        {
          "Stall",
          "Hat",
          "Dress",
          "Attachment",
          "Balloon",
          null,
          null
        },
        {
          "Growth Pet",
          "Ability Pet",
          "Vehicle",
          "Trans",
          "Pet Items",
          "Fellow Pet",
          "Fellow Pet items"
        },
        {
          "PREMIUM",
          "Gears",
          "Others",
          "",
          "",
          null,
          null
        },
        {
          "Astral",
          "Immortal",
          "Others",
          "",
          "",
          null,
          null
        }
      };
      for (int index1 = 0; index1 < this.liste.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.liste[index1].Length; ++index2)
        {
          this.liste[index1][index2] = new string[1]
          {
            strArray1[index1, index2]
          };
          this.tree.Nodes[index1].Nodes.Add(strArray2[index1, index2]);
        }
      }
    }

    private void tabloDoldur()
    {
      this._RefPackageItem = this.dat.TablotOlustur("_RefPackageItem");
      Application.DoEvents();
      this._RefPricePolicyOfItem = this.dat.TablotOlustur("_RefPricePolicyOfItem");
      Application.DoEvents();
      this._RefScrapOfPackageItem = this.dat.TablotOlustur("_RefScrapOfPackageItem");
      Application.DoEvents();
      this._RefShopGoods = this.dat.TablotOlustur("_RefShopGoods");
      Application.DoEvents();
      this._RefObjCommon = this.dat.TablotOlustur("_RefObjCommon");
      Application.DoEvents();
      this._RefObjItem = this.dat.TablotOlustur("_RefObjItem");
      Application.DoEvents();
      this.Gecici = this._RefShopGoods.Copy();
      this.Gecici.Clear();
    }

    private void tree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      this.lblBilgi.Text = "";
      this.txtGif.Text = "";
      this.txtPoint.Text = "";
      this.txtSilk.Text = "";
      if (e.Node.Level != 0)
      {
        this.btnYeni.Enabled = true;
        this.node = e.Node;
        this.ilk = this.node.Parent.Index;
        this.son = this.node.Index;
        this.flwDoldur(this.ilk, this.son);
      }
      else
      {
        this.btnYeni.Enabled = false;
        this.grpDuzenleme.Enabled = false;
        this.grpFiyat.Enabled = false;
      }
    }

    private void flwDoldur(int i, int x)
    {
      this.flwItem.Controls.Clear();
      this.tabIsmi = this.liste[i][x][0];
      foreach (DataRow dataRow in this._RefShopGoods.Select("RefTabCodeName='" + this.liste[i][x][0] + "'", "SlotIndex ASC", DataViewRowState.CurrentRows))
      {
        DataRow[] dataRowArray = this._RefPackageItem.Select("CodeName128='" + dataRow["RefPackageItemCodeName"].ToString() + "'", "ID ASC", DataViewRowState.CurrentRows);
        Button button = new Button();
        button.Height = 64;
        button.Width = 64;
        button.Name = dataRow["RefPackageItemCodeName"].ToString();
        button.TabIndex = Convert.ToInt32(dataRow["SlotIndex"].ToString());
        this.sonSlot = button.TabIndex;
        string str = this.dizin + dataRowArray[0]["AssocFileIcon"].ToString().Replace(".ddj", ".PNG");
        if (File.Exists(str))
        {
          Bitmap bitmap = new Bitmap((Image) new Bitmap(str), 64, 64);
          button.BackgroundImage = (Image) bitmap;
        }
        else
        {
          Bitmap bitmap = new Bitmap((Image) new Bitmap(this.dizin + "icon_default.PNG"), 64, 64);
          button.BackgroundImage = (Image) bitmap;
        }
        button.Click += new EventHandler(this.btn_Click);
        this.flwItem.Controls.Add((Control) button);
        this.btnBitir.Enabled = this.islem;
      }
    }

    private void btn_Click(object sender, EventArgs e)
    {
      Button button = sender as Button;
      this.lblBilgi.Text = button.Name;
      this.itemIsmi = button.Name;
      this.itemSlot = button.TabIndex;
      this.FiyatGetir(this.itemIsmi);
      this.grpDuzenleme.Enabled = true;
      this.btnDüzenle.Enabled = true;
      if (!this.silinme)
      {
        this.btnIptal.Enabled = false;
        this.btnKaydet.Enabled = false;
      }
      else
      {
        this.btnIptal.Enabled = true;
        this.btnKaydet.Enabled = true;
      }
      this.btnSil.Enabled = true;
      this.btnVazgec.Enabled = false;
    }

    private void FiyatGetir(string item)
    {
      foreach (DataRow dataRow in this._RefPricePolicyOfItem.Select("RefPackageItemCodeName='" + item + "'", "PaymentDevice ASC", DataViewRowState.CurrentRows))
      {
        if (dataRow["PaymentDevice"].ToString() == "2")
          this.txtSilk.Text = dataRow["Cost"].ToString();
        else if (dataRow["PaymentDevice"].ToString() == "4")
          this.txtPoint.Text = dataRow["Cost"].ToString();
        else if (dataRow["PaymentDevice"].ToString() == "16")
          this.txtGif.Text = dataRow["Cost"].ToString();
      }
    }

    private void FiyatDuzenle()
    {
      if (!(this.itemIsmi != ""))
        return;
      if (this.txtSilk.Text == "")
        this.txtSilk.Text = "0";
      if (this.txtPoint.Text == "")
        this.txtPoint.Text = "0";
      if (this.txtGif.Text == "")
        this.txtGif.Text = "0";
      try
      {
        int int32_1 = Convert.ToInt32(this.txtSilk.Text);
        int int32_2 = Convert.ToInt32(this.txtPoint.Text);
        int int32_3 = Convert.ToInt32(this.txtGif.Text);
        try
        {
          for (int index = 0; index < this._RefPricePolicyOfItem.Rows.Count; ++index)
          {
            if (this._RefPricePolicyOfItem.Rows[index]["RefPackageItemCodeName"].ToString() == this.itemIsmi)
            {
              if (this._RefPricePolicyOfItem.Rows[index]["PaymentDevice"].ToString() == "2")
                this._RefPricePolicyOfItem.Rows[index]["Cost"] = (object) int32_1;
              if (this._RefPricePolicyOfItem.Rows[index]["PaymentDevice"].ToString() == "4")
                this._RefPricePolicyOfItem.Rows[index]["Cost"] = (object) int32_2;
              if (this._RefPricePolicyOfItem.Rows[index]["PaymentDevice"].ToString() == "16")
                this._RefPricePolicyOfItem.Rows[index]["Cost"] = (object) int32_3;
            }
          }
          this.flwDoldur(this.ilk, this.son);
        }
        catch
        {
        }
      }
      catch
      {
        int num = (int) MessageBox.Show("Fiyatları Düzgün Yazmadınız.\nLütfen Kontrol Edin.");
      }
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      this.FiyatDuzenle();
      this.Gecici.Clear();
      this.btnKaydet.Enabled = false;
      this.btnBitir.Enabled = true;
      this.grpDuzenleme.Enabled = false;
      this.btnYeni.Enabled = true;
      this.grpFiyat.Enabled = false;
      this.grpItem.Enabled = true;
      this.grpListe.Enabled = true;
      this.islem = true;
      this.silinme = false;
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
      if (!(this.itemIsmi != ""))
        return;
      foreach (DataRow row in (InternalDataCollectionBase) this._RefShopGoods.Rows)
      {
        if (row.RowState != DataRowState.Deleted && row["RefPackageItemCodeName"].ToString() == this.itemIsmi && row["RefTabCodeName"].ToString() == this.tabIsmi && row["SlotIndex"].ToString() == this.itemSlot.ToString())
        {
          this.Gecici.ImportRow(row);
          row.Delete();
          this.lblBilgi.Text = "";
          this.btnIptal.Enabled = true;
          this.btnDüzenle.Enabled = false;
          this.btnKaydet.Enabled = true;
          this.btnSil.Enabled = false;
          this.btnVazgec.Enabled = false;
          this.btnYeni.Enabled = false;
          this.btnBitir.Enabled = false;
          this.lbl16.Text = "";
          this.lbl2.Text = "";
          this.lbl4.Text = "";
          this.silinme = true;
          break;
        }
      }
      this.flwDoldur(this.ilk, this.son);
    }

    private void btnIptal_Click(object sender, EventArgs e)
    {
      if (this.Gecici.Rows == null)
        return;
      for (int index = 0; index < this.Gecici.Rows.Count; ++index)
      {
        DataRow row = this._RefShopGoods.NewRow();
        for (int columnIndex = 0; columnIndex < this.Gecici.Columns.Count; ++columnIndex)
          row[columnIndex] = this.Gecici.Rows[index][columnIndex];
        this._RefShopGoods.Rows.Add(row);
      }
      this.Gecici.Clear();
      this.flwDoldur(this.ilk, this.son);
      if (!this.islem)
        this.btnBitir.Enabled = false;
      else
        this.btnBitir.Enabled = true;
      this.grpDuzenleme.Enabled = false;
      this.btnYeni.Enabled = true;
      this.itemIsmi = "";
      this.txtGif.Text = "";
      this.txtPoint.Text = "";
      this.txtSilk.Text = "";
      this.lbl4.Text = "";
      this.lbl2.Text = "";
      this.lbl16.Text = "";
      this.silinme = false;
    }

    private void btnDüzenle_Click(object sender, EventArgs e)
    {
      if (!(this.itemIsmi != ""))
        return;
      this.grpFiyat.Enabled = true;
      this.grpItem.Enabled = false;
      this.grpListe.Enabled = false;
      this.btnIptal.Enabled = false;
      this.btnDüzenle.Enabled = false;
      this.btnBitir.Enabled = false;
      this.btnKaydet.Enabled = false;
      this.btnSil.Enabled = false;
      this.btnYeni.Enabled = false;
      this.btnVazgec.Enabled = true;
      this.lbl2.Text = this.txtSilk.Text;
      this.lbl4.Text = this.txtPoint.Text;
      this.lbl16.Text = this.txtGif.Text;
    }

    private void btnVazgec_Click(object sender, EventArgs e)
    {
      this.grpFiyat.Enabled = false;
      this.grpItem.Enabled = true;
      this.grpListe.Enabled = true;
      this.btnDüzenle.Enabled = true;
      this.btnIptal.Enabled = false;
      this.btnKaydet.Enabled = false;
      this.btnSil.Enabled = true;
      this.btnVazgec.Enabled = false;
      this.btnYeni.Enabled = true;
      if (!this.islem)
        this.btnBitir.Enabled = false;
      else
        this.btnBitir.Enabled = true;
      this.txtGif.Text = this.lbl16.Text;
      this.txtPoint.Text = this.lbl4.Text;
      this.txtSilk.Text = this.lbl2.Text;
    }

    internal ArrayList ItemKontrolu(string itemName)
    {
      ArrayList arrayList = new ArrayList();
      bool flag1 = false;
      bool flag2 = false;
      string str = "";
      DataRow[] dataRowArray = this._RefShopGoods.Select("RefPackageItemCodeName='PACKAGE_" + itemName + "'", "index ASC", DataViewRowState.CurrentRows);
      int index = 0;
      if (index < dataRowArray.Length)
      {
        DataRow dataRow = dataRowArray[index];
        flag1 = true;
        str = dataRow["RefTabCodeName"].ToString();
      }
      foreach (DataRow dataRow in this._RefPackageItem.Select("CodeName128='PACKAGE_" + itemName + "'", "ID ASC", DataViewRowState.CurrentRows))
        flag2 = true;
      foreach (DataRow dataRow in this._RefPricePolicyOfItem.Select("RefPackageItemCodeName='PACKAGE_" + itemName + "'", "index ASC", DataViewRowState.CurrentRows))
        flag2 = true;
      foreach (DataRow dataRow in this._RefScrapOfPackageItem.Select("RefPackageItemCodeName='PACKAGE_" + itemName + "'", "Index ASC", DataViewRowState.CurrentRows))
        flag2 = true;
      arrayList.Add((object) flag1);
      arrayList.Add((object) flag2);
      arrayList.Add((object) str);
      return arrayList;
    }

    internal bool itemEkle(string itemName, string icon, string[] fiyat, string Dr_L)
    {
      bool flag;
      try
      {
        DataRow row1 = this._RefPackageItem.NewRow();
        string[] strArray1 = new string[17]
        {
          "1",
          "9",
          "3",
          "PACKAGE_" + itemName,
          "0",
          "EXPAND_TERM_ALL",
          "SN_" + itemName,
          "SN_" + itemName + "_TT_DESC",
          icon,
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
          row1[columnIndex] = (object) strArray1[columnIndex];
        this._RefPackageItem.Rows.Add(row1);
        DataRow row2 = this._RefScrapOfPackageItem.NewRow();
        string[] strArray2 = new string[29]
        {
          "1",
          "9",
          "PACKAGE_" + itemName,
          itemName,
          "0",
          "0",
          Dr_L,
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
          row2[columnIndex] = (object) strArray2[columnIndex];
        this._RefScrapOfPackageItem.Rows.Add(row2);
        string[] strArray3 = new string[3]{ "2", "4", "16" };
        for (int index = 0; index < 3; ++index)
        {
          DataRow row3 = this._RefPricePolicyOfItem.NewRow();
          string[] strArray4 = new string[15]
          {
            "1",
            "9",
            "PACKAGE_" + itemName,
            strArray3[index],
            "0",
            fiyat[index],
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
          for (int columnIndex = 0; columnIndex < this._RefPricePolicyOfItem.Columns.Count; ++columnIndex)
            row3[columnIndex] = (object) strArray4[columnIndex];
          this._RefPricePolicyOfItem.Rows.Add(row3);
        }
        DataRow row4 = this._RefShopGoods.NewRow();
        string[] strArray5 = new string[14]
        {
          "1",
          "9",
          this.tabIsmi,
          "PACKAGE_" + itemName,
          (this.sonSlot + 1).ToString(),
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
          row4[columnIndex] = (object) strArray5[columnIndex];
        this._RefShopGoods.Rows.Add(row4);
        flag = true;
      }
      catch
      {
        flag = false;
      }
      return flag;
    }

    internal void islemTamamlandi()
    {
      this.btnBitir.Enabled = true;
      this.grpDuzenleme.Enabled = false;
      this.grpFiyat.Enabled = false;
      this.flwDoldur(this.ilk, this.son);
    }

    private void txtSilk_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (new Regex("^[0-9\b]$").Match(e.KeyChar.ToString()).Success)
        return;
      e.Handled = true;
    }

    private void txtSilk_KeyUp(object sender, KeyEventArgs e)
    {
      if (this.txtGif.Text != "" || this.txtPoint.Text != "" || this.txtSilk.Text != "")
        this.btnKaydet.Enabled = true;
      else
        this.btnKaydet.Enabled = false;
    }

    private void btnYeni_Click(object sender, EventArgs e)
    {
      int num = (int) new magzaItemEkle()
      {
        mgz = this,
        _RefObjCommon = this._RefObjCommon,
        _RefObjItem = this._RefObjItem
      }.ShowDialog();
    }

    private void btnBitir_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("SQL Güncellenip Medya İçin Text Dosyaları Oluşturulacak.\n\nDevam Edilsinmi...", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      for (int index = 0; index < this.btn.Length; ++index)
        this.btn[index].Enabled = false;
      this.grpFiyat.Enabled = false;
      this.grpItem.Enabled = false;
      this.grpListe.Enabled = false;
      this.grpDuzenleme.Enabled = false;
      this.btnBitir.Enabled = false;
      this.btnYeni.Enabled = false;
      DataTable[] dataTableArray = new DataTable[4]
      {
        this._RefPackageItem,
        this._RefPricePolicyOfItem,
        this._RefScrapOfPackageItem,
        this._RefShopGoods
      };
      string[] strArray = new string[4]
      {
        "refpackageitem.txt",
        "refpricepolicyofitem.txt",
        "refscrapofpackageitem.txt",
        "refshopgoods.txt"
      };
      this.grpProIslem.Visible = true;
      this.grpProIslem.Text = "SQL Güncelleniyor...";
      for (int index = 0; index < dataTableArray.Length; ++index)
      {
        dataTableArray[index] = this.dat.SqlGuncelle(dataTableArray[index]);
        this.proTxt.Value = index * 100 / dataTableArray.Length;
        Application.DoEvents();
      }
      for (int index1 = 0; index1 < dataTableArray.Length; ++index1)
      {
        TxT.TxTSil(this.dizin1, strArray[index1]);
        for (int index2 = 0; index2 < dataTableArray[index1].Rows.Count; ++index2)
        {
          if (dataTableArray[index1].TableName == "_RefPackageItem" || dataTableArray[index1].TableName == "_RefScrapOfPackageItem")
          {
            this.grpProIslem.Text = strArray[index1] + " Text Dosyası Hazırlanıyor...";
            string str = "";
            for (int columnIndex = 0; columnIndex < dataTableArray[index1].Columns.Count; ++columnIndex)
            {
              str = str + dataTableArray[index1].Rows[index2][columnIndex].ToString() + "\t";
              this.proTxt.Value = index2 * 100 / dataTableArray[index1].Rows.Count;
              Application.DoEvents();
            }
            TxT.TxTYaz1(str.Substring(0, str.Length - 1), this.dizin1, strArray[index1]);
          }
          else
          {
            this.grpProIslem.Text = strArray[index1] + " Text Dosyası Hazırlanıyor...";
            string str = "";
            for (int columnIndex = 0; columnIndex < dataTableArray[index1].Columns.Count - 1; ++columnIndex)
            {
              str = str + dataTableArray[index1].Rows[index2][columnIndex].ToString() + "\t";
              this.proTxt.Value = index2 * 100 / (dataTableArray[index1].Rows.Count - 1);
              Application.DoEvents();
            }
            TxT.TxTYaz1(str.Substring(0, str.Length - 1), this.dizin1, strArray[index1]);
          }
        }
      }
      this.grpProIslem.Visible = false;
      this.islem = false;
      this.flwDoldur(this.ilk, this.son);
      this.grpItem.Enabled = true;
      this.grpListe.Enabled = true;
      for (int index = 0; index < this.btn.Length; ++index)
        this.btn[index].Enabled = true;
      if (MessageBox.Show("İşlem Tamamlandı", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
      {
        string str = Path.GetDirectoryName(Application.ExecutablePath) + "\\KompleDegisecekTextDosyalari";
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.grpListe = new System.Windows.Forms.GroupBox();
            this.tree = new System.Windows.Forms.TreeView();
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.flwItem = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.grpItemAdi = new System.Windows.Forms.GroupBox();
            this.grpFiyat = new System.Windows.Forms.GroupBox();
            this.txtGif = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSilk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDuzenleme = new System.Windows.Forms.GroupBox();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.btnDüzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnYeni = new System.Windows.Forms.Button();
            this.btnBitir = new System.Windows.Forms.Button();
            this.proTxt = new System.Windows.Forms.ProgressBar();
            this.grpProIslem = new System.Windows.Forms.GroupBox();
            this.grpListe.SuspendLayout();
            this.grpItem.SuspendLayout();
            this.grpItemAdi.SuspendLayout();
            this.grpFiyat.SuspendLayout();
            this.grpDuzenleme.SuspendLayout();
            this.grpProIslem.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpListe
            // 
            this.grpListe.BackColor = System.Drawing.Color.Transparent;
            this.grpListe.Controls.Add(this.tree);
            this.grpListe.Enabled = false;
            this.grpListe.ForeColor = System.Drawing.Color.Gold;
            this.grpListe.Location = new System.Drawing.Point(3, 4);
            this.grpListe.Name = "grpListe";
            this.grpListe.Size = new System.Drawing.Size(156, 450);
            this.grpListe.TabIndex = 2;
            this.grpListe.TabStop = false;
            this.grpListe.Text = "F10 İtem Mall Listesi";
            // 
            // tree
            // 
            this.tree.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.ForeColor = System.Drawing.Color.Black;
            this.tree.Location = new System.Drawing.Point(3, 16);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(150, 431);
            this.tree.TabIndex = 10;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.flwItem);
            this.grpItem.Enabled = false;
            this.grpItem.ForeColor = System.Drawing.Color.Gold;
            this.grpItem.Location = new System.Drawing.Point(165, 4);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(167, 450);
            this.grpItem.TabIndex = 3;
            this.grpItem.TabStop = false;
            this.grpItem.Text = "İtem Listesi";
            // 
            // flwItem
            // 
            this.flwItem.AutoScroll = true;
            this.flwItem.BackColor = System.Drawing.Color.Transparent;
            this.flwItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwItem.Location = new System.Drawing.Point(3, 16);
            this.flwItem.Name = "flwItem";
            this.flwItem.Size = new System.Drawing.Size(161, 431);
            this.flwItem.TabIndex = 11;
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.ForeColor = System.Drawing.Color.White;
            this.lblBilgi.Location = new System.Drawing.Point(4, 19);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(44, 13);
            this.lblBilgi.TabIndex = 4;
            this.lblBilgi.Text = "İtem adı";
            // 
            // grpItemAdi
            // 
            this.grpItemAdi.Controls.Add(this.lblBilgi);
            this.grpItemAdi.ForeColor = System.Drawing.Color.Gold;
            this.grpItemAdi.Location = new System.Drawing.Point(337, 4);
            this.grpItemAdi.Name = "grpItemAdi";
            this.grpItemAdi.Size = new System.Drawing.Size(443, 38);
            this.grpItemAdi.TabIndex = 5;
            this.grpItemAdi.TabStop = false;
            this.grpItemAdi.Text = "Seçilen İtem Adı";
            // 
            // grpFiyat
            // 
            this.grpFiyat.Controls.Add(this.txtGif);
            this.grpFiyat.Controls.Add(this.label3);
            this.grpFiyat.Controls.Add(this.txtPoint);
            this.grpFiyat.Controls.Add(this.label2);
            this.grpFiyat.Controls.Add(this.txtSilk);
            this.grpFiyat.Controls.Add(this.label1);
            this.grpFiyat.Enabled = false;
            this.grpFiyat.ForeColor = System.Drawing.Color.Gold;
            this.grpFiyat.Location = new System.Drawing.Point(338, 49);
            this.grpFiyat.Name = "grpFiyat";
            this.grpFiyat.Size = new System.Drawing.Size(151, 99);
            this.grpFiyat.TabIndex = 6;
            this.grpFiyat.TabStop = false;
            this.grpFiyat.Text = "Satış Fiyatı";
            // 
            // txtGif
            // 
            this.txtGif.ForeColor = System.Drawing.Color.Black;
            this.txtGif.Location = new System.Drawing.Point(77, 70);
            this.txtGif.Name = "txtGif";
            this.txtGif.Size = new System.Drawing.Size(54, 20);
            this.txtGif.TabIndex = 2;
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
            this.txtPoint.TabIndex = 1;
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
            this.txtSilk.TabIndex = 0;
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
            // grpDuzenleme
            // 
            this.grpDuzenleme.Controls.Add(this.btnIptal);
            this.grpDuzenleme.Controls.Add(this.btnKaydet);
            this.grpDuzenleme.Controls.Add(this.btnVazgec);
            this.grpDuzenleme.Controls.Add(this.btnDüzenle);
            this.grpDuzenleme.Controls.Add(this.btnSil);
            this.grpDuzenleme.Enabled = false;
            this.grpDuzenleme.ForeColor = System.Drawing.Color.Gold;
            this.grpDuzenleme.Location = new System.Drawing.Point(495, 49);
            this.grpDuzenleme.Name = "grpDuzenleme";
            this.grpDuzenleme.Size = new System.Drawing.Size(205, 99);
            this.grpDuzenleme.TabIndex = 7;
            this.grpDuzenleme.TabStop = false;
            this.grpDuzenleme.Text = "Düzenleme İşlemleri";
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Lavender;
            this.btnIptal.ForeColor = System.Drawing.Color.Black;
            this.btnIptal.Location = new System.Drawing.Point(11, 57);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(42, 38);
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Lavender;
            this.btnKaydet.ForeColor = System.Drawing.Color.Black;
            this.btnKaydet.Location = new System.Drawing.Point(124, 57);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(72, 38);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.BackColor = System.Drawing.Color.Lavender;
            this.btnVazgec.ForeColor = System.Drawing.Color.Black;
            this.btnVazgec.Location = new System.Drawing.Point(61, 57);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(55, 38);
            this.btnVazgec.TabIndex = 6;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = false;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnDüzenle
            // 
            this.btnDüzenle.BackColor = System.Drawing.Color.Lavender;
            this.btnDüzenle.ForeColor = System.Drawing.Color.Black;
            this.btnDüzenle.Location = new System.Drawing.Point(70, 18);
            this.btnDüzenle.Name = "btnDüzenle";
            this.btnDüzenle.Size = new System.Drawing.Size(55, 32);
            this.btnDüzenle.TabIndex = 4;
            this.btnDüzenle.Text = "Düzenle";
            this.btnDüzenle.UseVisualStyleBackColor = false;
            this.btnDüzenle.Click += new System.EventHandler(this.btnDüzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Lavender;
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(11, 18);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(53, 32);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnYeni
            // 
            this.btnYeni.BackColor = System.Drawing.Color.Lavender;
            this.btnYeni.Enabled = false;
            this.btnYeni.ForeColor = System.Drawing.Color.Black;
            this.btnYeni.Location = new System.Drawing.Point(338, 158);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(124, 50);
            this.btnYeni.TabIndex = 8;
            this.btnYeni.Text = "YENI ITEM EKLE";
            this.btnYeni.UseVisualStyleBackColor = false;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnBitir
            // 
            this.btnBitir.BackColor = System.Drawing.Color.Lavender;
            this.btnBitir.Enabled = false;
            this.btnBitir.ForeColor = System.Drawing.Color.Black;
            this.btnBitir.Location = new System.Drawing.Point(338, 214);
            this.btnBitir.Name = "btnBitir";
            this.btnBitir.Size = new System.Drawing.Size(178, 50);
            this.btnBitir.TabIndex = 9;
            this.btnBitir.Text = "TEXT DOSYASI OLUŞTUR";
            this.btnBitir.UseVisualStyleBackColor = false;
            this.btnBitir.Click += new System.EventHandler(this.btnBitir_Click);
            // 
            // proTxt
            // 
            this.proTxt.Location = new System.Drawing.Point(6, 19);
            this.proTxt.Name = "proTxt";
            this.proTxt.Size = new System.Drawing.Size(430, 23);
            this.proTxt.TabIndex = 10;
            // 
            // grpProIslem
            // 
            this.grpProIslem.Controls.Add(this.proTxt);
            this.grpProIslem.ForeColor = System.Drawing.Color.Gold;
            this.grpProIslem.Location = new System.Drawing.Point(337, 286);
            this.grpProIslem.Name = "grpProIslem";
            this.grpProIslem.Size = new System.Drawing.Size(442, 53);
            this.grpProIslem.TabIndex = 12;
            this.grpProIslem.TabStop = false;
            this.grpProIslem.Text = "Düzenleme İşlemleri";
            this.grpProIslem.Visible = false;
            // 
            // magza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.Controls.Add(this.grpProIslem);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.btnBitir);
            this.Controls.Add(this.grpDuzenleme);
            this.Controls.Add(this.grpFiyat);
            this.Controls.Add(this.grpItemAdi);
            this.Controls.Add(this.grpItem);
            this.Controls.Add(this.grpListe);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "magza";
            this.Size = new System.Drawing.Size(798, 471);
            this.Load += new System.EventHandler(this.magza_Load);
            this.grpListe.ResumeLayout(false);
            this.grpItem.ResumeLayout(false);
            this.grpItemAdi.ResumeLayout(false);
            this.grpItemAdi.PerformLayout();
            this.grpFiyat.ResumeLayout(false);
            this.grpFiyat.PerformLayout();
            this.grpDuzenleme.ResumeLayout(false);
            this.grpProIslem.ResumeLayout(false);
            this.ResumeLayout(false);

    }
  }
}
