// Decompiled with JetBrains decompiler
// Type: Tablo.TabloOlustur
// Assembly: Tablo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E78F8CA-07CF-4084-AFCA-93E703D146E1
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\Tablo.dll

using ConfigOku;
using sql;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tablo
{
  public class TabloOlustur
  {
    private Fonksiyon fonksiyon;

    public TabloOlustur() => this.fonksiyon = new confikOku().FonksiyonKur();

    public DataSet NPCTabloCek(string[] tabList)
    {
      DataSet dataSet = new DataSet();
      SqlConnection sqlConnection = this.fonksiyon.Baglan();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      for (int index = 0; index < tabList.Length; ++index)
      {
        sqlCommand.CommandText = "select * from " + tabList[index];
        sqlDataAdapter.SelectCommand = sqlCommand;
        sqlDataAdapter.Fill(dataSet, tabList[index]);
        Application.DoEvents();
      }
      sqlCommand.Dispose();
      sqlConnection.Dispose();
      sqlConnection.Close();
      return dataSet;
    }

    public DataTable _RefShopGoodsIcinTabloCek(string tabList)
    {
      DataSet dataSet = new DataSet();
      SqlConnection sqlConnection = this.fonksiyon.Baglan();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandText = "select * from " + tabList + " ORDER BY RefTabCodeName, SlotIndex";
      sqlDataAdapter.SelectCommand = sqlCommand;
      sqlDataAdapter.Fill(dataSet, tabList);
      sqlCommand.Dispose();
      sqlConnection.Dispose();
      sqlConnection.Close();
      return dataSet.Tables[tabList];
    }

    public bool _RefObjChar(DataSet dataset)
    {
      bool flag = false;
      string[] strArray = new string[81]
      {
        "1",
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
        "0",
        "0",
        "0",
        "336860180",
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
        "0"
      };
      DataRow row = dataset.Tables[nameof (_RefObjChar)].NewRow();
      try
      {
        for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
          row[columnIndex] = (object) strArray[columnIndex];
        dataset.Tables[nameof (_RefObjChar)].Rows.Add(row);
        flag = true;
      }
      catch
      {
      }
      return flag;
    }

    public bool _RefObjCommon(DataSet dataset, string npcAdi, string bsr)
    {
      bool flag = false;
      string[] strArray = new string[58]
      {
        "1",
        "1",
        npcAdi,
        "xxx",
        "xxx",
        "SN_" + npcAdi,
        "xxx",
        "0",
        "1",
        "1",
        "2",
        "2",
        "0",
        "5000",
        "3",
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
        "0",
        "0",
        "0",
        "0",
        "-1",
        "0",
        "-1",
        "0",
        "-1",
        "0",
        "-1",
        "0",
        "-1",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "100",
        "0",
        "3",
        "0",
        bsr,
        "xxx",
        "xxx",
        "xxx",
        "xxx",
        "1"
      };
      DataRow row = dataset.Tables[nameof (_RefObjCommon)].NewRow();
      try
      {
        for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
          row[columnIndex] = (object) strArray[columnIndex];
        try
        {
          dataset.Tables[nameof (_RefObjCommon)].Rows.Add(row);
          flag = true;
        }
        catch
        {
        }
      }
      catch
      {
      }
      return flag;
    }

    public bool Tab_RefTactics(DataSet dataset)
    {
      bool flag = false;
      string[] strArray = new string[43]
      {
        "1",
        dataset.Tables["_RefObjCommon"].Rows[dataset.Tables["_RefObjCommon"].Rows.Count - 1][0].ToString(),
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
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "1",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "???? ??"
      };
      DataRow row = dataset.Tables[nameof (Tab_RefTactics)].NewRow();
      try
      {
        for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
          row[columnIndex] = (object) strArray[columnIndex];
        dataset.Tables[nameof (Tab_RefTactics)].Rows.Add(row);
        flag = true;
      }
      catch
      {
      }
      return flag;
    }

    public bool Tab_RefNest(
      DataSet dataset,
      string X,
      string Y,
      string Z,
      string Yon,
      string bolge)
    {
      bool flag = false;
      if (X != "" && Y != "" && Z != "" && Yon != "")
      {
        flag = true;
      }
      else
      {
        int num1 = (int) MessageBox.Show("X,Y,Z,Yon Kısımları Boş Olamaz");
      }
      try
      {
        if (flag)
        {
          DataRow row = dataset.Tables[nameof (Tab_RefNest)].NewRow();
          string[] strArray = new string[17]
          {
            "1",
            "1",
            "1",
            bolge,
            X,
            Y,
            Z,
            Yon,
            "0",
            "0",
            "0",
            "0",
            "0",
            "1",
            "0",
            "1",
            "0"
          };
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          dataset.Tables[nameof (Tab_RefNest)].Rows.Add(row);
          flag = true;
        }
      }
      catch
      {
        int num2 = (int) MessageBox.Show("Tab_RefNest tablosuna kayıt yapılırken hata oluştu Lütfen Char Seçimiyle Pozisyon verin");
        flag = false;
      }
      return flag;
    }

    public bool Tab_RefHive(DataSet dataset, string bolge)
    {
      bool flag1 = false;
      string str1 = "";
      string str2 = "";
      if (bolge == "JANGAN")
      {
        str1 = "NPC_CHN";
        str2 = "1,0,0,0,0,0,0,1,2,NPC_CHN";
      }
      else if (bolge == "DONWHANG")
      {
        str1 = "NPC_DOW";
        str2 = "1,0,0,0,0,0,0,1,2,NPC_DOW";
      }
      else if (bolge == "HOTAN")
      {
        str1 = "NPC_HOTA";
        str2 = "1,0,0,0,0,0,0,1,2,NPC_HOTA";
      }
      else if (bolge == "SEMERKAND")
      {
        str1 = "NPC_SEMER";
        str2 = "1,0,0,0,0,0,0,1,2,NPC_SEMER";
      }
      else if (bolge == "CONSTANTINE")
      {
        str1 = "NPC_CONST";
        str2 = "1,0,0,0,0,0,0,1,2,NPC_CONST";
      }
      else if (bolge == "ALEXANDRIA")
      {
        str1 = "NPC_ALXAND";
        str2 = "1,0,0,0,0,0,0,1,2,NPC_ALXAND";
      }
      else if (bolge == "JUPITER")
      {
        str1 = "NPC_JUPI";
        str2 = "1,0,0,0,0,0,0,90,2,NPC_JUPI";
      }
      bool flag2 = false;
      for (int index = 0; index < dataset.Tables[nameof (Tab_RefHive)].Rows.Count; ++index)
      {
        if (dataset.Tables[nameof (Tab_RefHive)].Rows[index]["szDescString128"].ToString() == str1)
          flag2 = true;
      }
      try
      {
        if (!flag2)
        {
          string[] strArray = str2.Split(',');
          DataRow row = dataset.Tables[nameof (Tab_RefHive)].NewRow();
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          dataset.Tables[nameof (Tab_RefHive)].Rows.Add(row);
        }
        flag1 = true;
      }
      catch
      {
      }
      return flag1;
    }

    public bool GruplariOlustur(DataSet dataset, string NPCAdi)
    {
      bool flag = false;
      string str = NPCAdi;
      int num1 = NPCAdi.IndexOf("NPC_", 0);
      if (num1 != -1)
      {
        str = NPCAdi.Substring(num1 + 4);
        flag = true;
      }
      if (flag)
      {
        try
        {
          DataRow row = dataset.Tables["_RefShop"].NewRow();
          string[] strArray = new string[12]
          {
            "1",
            "33",
            "1",
            "STORE_" + str,
            "-1",
            "xxx",
            "-1",
            "xxx",
            "-1",
            "xxx",
            "-1",
            "xxx"
          };
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          dataset.Tables["_RefShop"].Rows.Add(row);
        }
        catch
        {
          int num2 = (int) MessageBox.Show("_RefShop kaydedilirken hata oluştu");
        }
        try
        {
          DataRow row = dataset.Tables["_RefShopGroup"].NewRow();
          string[] strArray = new string[13]
          {
            "1",
            "33",
            "1",
            "GROUP_STORE_" + str,
            NPCAdi,
            "-1",
            "xxx",
            "-1",
            "xxx",
            "-1",
            "xxx",
            "-1",
            "xxx"
          };
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          dataset.Tables["_RefShopGroup"].Rows.Add(row);
        }
        catch
        {
          int num3 = (int) MessageBox.Show("_RefShop kaydedilirken hata oluştu");
        }
        try
        {
          string[] strArray = new string[4]
          {
            "1",
            "33",
            "GROUP_STORE_" + str,
            "STORE_" + str
          };
          DataTable table = new DataTable("idOlmayan_RefMappingShopGroup");
          table.Columns.Add("Service");
          table.Columns.Add("Country");
          table.Columns.Add("RefShopGroupCodeName");
          table.Columns.Add("RefShopCodeName");
          DataRow row = dataset.Tables["_RefMappingShopGroup"].NewRow();
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          table.Rows.Add((object[]) strArray);
          dataset.Tables["_RefMappingShopGroup"].Rows.Add(row);
          dataset.Tables.Add(table);
        }
        catch
        {
          int num4 = (int) MessageBox.Show("_RefMappingShopGroup kaydedilirken hata oluştu");
        }
      }
      return flag;
    }

    public bool GurupVeAdlariOlustur(DataSet dataset, string _charAdi, int grNo, string medyaAdi)
    {
      bool flag = false;
      string str = _charAdi;
      int num1 = _charAdi.IndexOf("NPC_", 0);
      if (num1 != -1)
      {
        str = _charAdi.Substring(num1 + 4);
        flag = true;
      }
      else
      {
        int num2 = (int) MessageBox.Show("NPC adını doğru yazmadınız.\n Npc Adı \"NPC_\" ile başlamalıdır...");
      }
      if (flag)
      {
        try
        {
          string[] strArray = new string[4]
          {
            "1",
            "1",
            "STORE_" + str + "_GROUP" + (object) grNo,
            "SN_STORE_" + str + "_GROUP" + (object) grNo
          };
          DataRow row = dataset.Tables["_RefShopItemGroup"].NewRow();
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          dataset.Tables["_RefShopItemGroup"].Rows.Add(row);
          flag = true;
        }
        catch
        {
          flag = false;
          int num3 = (int) MessageBox.Show("_RefShopItemGroup tablosunda hata oluştu");
        }
      }
      if (flag)
      {
        try
        {
          string[] strArray = new string[5]
          {
            "1",
            "33",
            "1",
            "STORE_" + str + "_GROUP" + (object) grNo,
            "SN_STORE_" + str + "_GROUP" + (object) grNo
          };
          DataRow row = dataset.Tables["_RefShopTabGroup"].NewRow();
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          dataset.Tables["_RefShopTabGroup"].Rows.Add(row);
          flag = true;
        }
        catch
        {
          flag = false;
          int num4 = (int) MessageBox.Show("_RefShopTabGroup tablosunda hata oluştu");
        }
      }
      if (flag)
      {
        try
        {
          string[] strArray1 = new string[4]
          {
            "1",
            "33",
            "STORE_" + str,
            "STORE_" + str + "_GROUP" + (object) grNo
          };
          DataRow row = dataset.Tables["_RefMappingShopWithTab"].NewRow();
          DataTable table = new DataTable("idOlmayan__RefMappingShopWithTab");
          string[] strArray2 = new string[4]
          {
            "Service",
            "Country",
            "RefShopCodeName",
            "RefTabGroupCodeName"
          };
          for (int columnIndex = 0; columnIndex < strArray1.Length; ++columnIndex)
          {
            row[columnIndex] = (object) strArray1[columnIndex];
            table.Columns.Add(strArray2[columnIndex]);
          }
          table.Rows.Add((object[]) strArray1);
          dataset.Tables["_RefMappingShopWithTab"].Rows.Add(row);
          dataset.Tables.Add(table);
          flag = true;
        }
        catch
        {
          flag = false;
          int num5 = (int) MessageBox.Show("_RefMappingShopWithTab tablosunda hata oluştu");
        }
      }
      if (flag)
      {
        try
        {
          DataTable table = new DataTable("GurupAdi");
          table.Columns.Add("dataAdi");
          table.Columns.Add(nameof (medyaAdi));
          string[] strArray = new string[2]
          {
            "SN_STORE_" + str + "_GROUP" + (object) grNo,
            medyaAdi
          };
          table.Rows.Add((object[]) strArray);
          dataset.Tables.Add(table);
          flag = true;
        }
        catch
        {
          flag = false;
          int num6 = (int) MessageBox.Show("GurupAdi tablosunda hata oluştu");
        }
      }
      return flag;
    }

    public string[] _RefShopTab(
      DataSet dataset,
      string _charAdi,
      string[] tabIsmi,
      string[] tabMenu,
      int grNo,
      int tabSiraNo)
    {
      bool flag = false;
      string[] strArray1 = new string[3];
      string str = _charAdi;
      int num1 = _charAdi.IndexOf("NPC_", 0);
      int num2 = 0;
      if (num1 != -1)
      {
        str = _charAdi.Substring(num1 + 4);
        flag = true;
      }
      else
      {
        int num3 = (int) MessageBox.Show("NPC adını doğru yazmadınız.\n Npc Adı \"NPC_\" ile başlamalıdır...");
      }
      if (flag)
      {
        try
        {
          DataTable table1 = new DataTable("snTabAdi");
          table1.Columns.Add("snTab");
          table1.Columns.Add("menüAdi");
          DataTable table2 = new DataTable("kayit_RefShopTab");
          table2.Columns.Add("kolon1");
          table2.Columns.Add("kolon2");
          table2.Columns.Add("kolon3");
          table2.Columns.Add("kolon4");
          table2.Columns.Add("kolon5");
          table2.Columns.Add("kolon6");
          for (int index = 0; index < tabIsmi.Length; ++index)
          {
            if (tabIsmi[index] != "")
            {
              ++tabSiraNo;
              ++num2;
              DataRow row = dataset.Tables[nameof (_RefShopTab)].NewRow();
              string[] strArray2 = new string[6]
              {
                "1",
                "33",
                "1",
                "STORE_" + str + "_TAB" + (object) tabSiraNo,
                "STORE_" + str + "_GROUP" + (object) grNo,
                "SN_TAB_" + tabIsmi[index]
              };
              table2.Rows.Add((object[]) strArray2);
              table1.Rows.Add((object) ("SN_TAB_" + tabIsmi[index]), (object) tabMenu[index]);
              for (int columnIndex = 0; columnIndex < strArray2.Length; ++columnIndex)
                row[columnIndex] = (object) strArray2[columnIndex];
              dataset.Tables[nameof (_RefShopTab)].Rows.Add(row);
            }
          }
          dataset.Tables.Add(table1);
          dataset.Tables.Add(table2);
          strArray1[0] = "true";
          strArray1[1] = tabSiraNo.ToString();
          strArray1[2] = num2.ToString();
        }
        catch
        {
        }
      }
      return strArray1;
    }

    public bool GurupVeAdlariOlusturTekrar(
      DataSet dataset,
      string _charAdi,
      int grNo,
      string medyaAdi)
    {
      bool flag = false;
      string str = _charAdi;
      int num1 = _charAdi.IndexOf("NPC_", 0);
      if (num1 != -1)
      {
        str = _charAdi.Substring(num1 + 4);
        flag = true;
      }
      else
      {
        int num2 = (int) MessageBox.Show("NPC adını doğru yazmadınız.\n Npc Adı \"NPC_\" ile başlamalıdır...");
      }
      if (flag)
      {
        try
        {
          string[] strArray = new string[4]
          {
            "1",
            "1",
            "STORE_" + str + "_GROUP" + (object) grNo,
            "SN_STORE_" + str + "_GROUP" + (object) grNo
          };
          DataRow row = dataset.Tables["_RefShopItemGroup"].NewRow();
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          dataset.Tables["_RefShopItemGroup"].Rows.Add(row);
          flag = true;
        }
        catch
        {
          flag = false;
          int num3 = (int) MessageBox.Show("_RefShopItemGroup tablosunda hata oluştu");
        }
      }
      if (flag)
      {
        try
        {
          string[] strArray = new string[5]
          {
            "1",
            "33",
            "1",
            "STORE_" + str + "_GROUP" + (object) grNo,
            "SN_STORE_" + str + "_GROUP" + (object) grNo
          };
          DataRow row = dataset.Tables["_RefShopTabGroup"].NewRow();
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          dataset.Tables["_RefShopTabGroup"].Rows.Add(row);
          flag = true;
        }
        catch
        {
          flag = false;
          int num4 = (int) MessageBox.Show("_RefShopTabGroup tablosunda hata oluştu");
        }
      }
      if (flag)
      {
        try
        {
          string[] strArray = new string[4]
          {
            "1",
            "33",
            "STORE_" + str,
            "STORE_" + str + "_GROUP" + (object) grNo
          };
          DataRow row1 = dataset.Tables["_RefMappingShopWithTab"].NewRow();
          DataRow row2 = dataset.Tables["idOlmayan__RefMappingShopWithTab"].NewRow();
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
          {
            row1[columnIndex] = (object) strArray[columnIndex];
            row2[columnIndex] = (object) strArray[columnIndex];
          }
          dataset.Tables["idOlmayan__RefMappingShopWithTab"].Rows.Add(row2);
          dataset.Tables["_RefMappingShopWithTab"].Rows.Add(row1);
          flag = true;
        }
        catch
        {
          flag = false;
          int num5 = (int) MessageBox.Show("_RefMappingShopWithTab tablosunda hata oluştu");
        }
      }
      if (flag)
      {
        try
        {
          DataRow row = dataset.Tables["GurupAdi"].NewRow();
          string[] strArray = new string[2]
          {
            "SN_STORE_" + str + "_GROUP" + (object) grNo,
            medyaAdi
          };
          for (int columnIndex = 0; columnIndex < strArray.Length; ++columnIndex)
            row[columnIndex] = (object) strArray[columnIndex];
          dataset.Tables["GurupAdi"].Rows.Add(row);
          flag = true;
        }
        catch
        {
          flag = false;
          int num6 = (int) MessageBox.Show("GurupAdi tablosunda hata oluştu");
        }
      }
      return flag;
    }

    public string[] _RefShopTabTekrar(
      DataSet dataset,
      string _charAdi,
      string[] tabIsmi,
      string[] tabMenu,
      int grNo,
      int tabSiraNo)
    {
      bool flag = false;
      string[] strArray1 = new string[3];
      string str = _charAdi;
      int num1 = 0;
      int num2 = _charAdi.IndexOf("NPC_", 0);
      if (num2 != -1)
      {
        str = _charAdi.Substring(num2 + 4);
        flag = true;
      }
      else
      {
        int num3 = (int) MessageBox.Show("NPC adını doğru yazmadınız.\n Npc Adı \"NPC_\" ile başlamalıdır...");
      }
      if (flag)
      {
        try
        {
          for (int index = 0; index < tabIsmi.Length; ++index)
          {
            if (tabIsmi[index] != "")
            {
              ++tabSiraNo;
              ++num1;
              DataRow row1 = dataset.Tables["_RefShopTab"].NewRow();
              DataRow row2 = dataset.Tables["kayit_RefShopTab"].NewRow();
              string[] strArray2 = new string[6]
              {
                "1",
                "33",
                "1",
                "STORE_" + str + "_TAB" + (object) tabSiraNo,
                "STORE_" + str + "_GROUP" + (object) grNo,
                "SN_TAB_" + tabIsmi[index]
              };
              dataset.Tables["snTabAdi"].Rows.Add((object) ("SN_TAB_" + tabIsmi[index]), (object) tabMenu[index]);
              for (int columnIndex = 0; columnIndex < strArray2.Length; ++columnIndex)
              {
                row1[columnIndex] = (object) strArray2[columnIndex];
                row2[columnIndex] = (object) strArray2[columnIndex];
              }
              dataset.Tables["_RefShopTab"].Rows.Add(row1);
              dataset.Tables["kayit_RefShopTab"].Rows.Add(row2);
            }
          }
          strArray1[0] = "true";
          strArray1[1] = tabSiraNo.ToString();
          strArray1[2] = num1.ToString();
        }
        catch
        {
        }
      }
      return strArray1;
    }

    public bool CharTablosuCek(DataSet dataset)
    {
      bool flag;
      try
      {
        SqlConnection sqlConnection = this.fonksiyon.Baglan();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandText = "select * from _Char";
        sqlDataAdapter.SelectCommand = sqlCommand;
        sqlDataAdapter.Fill(dataset, "_Char");
        sqlCommand.Dispose();
        sqlConnection.Dispose();
        sqlConnection.Close();
        flag = true;
      }
      catch
      {
        int num = (int) MessageBox.Show("_Char Tablosu yeniden oluşturulamadı...");
        flag = false;
      }
      return flag;
    }
  }
}
