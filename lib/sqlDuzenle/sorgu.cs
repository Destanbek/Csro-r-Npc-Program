// Decompiled with JetBrains decompiler
// Type: sqlDuzenle.sorgu
// Assembly: sqlDuzenle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 739417F4-C14E-4238-BFFD-48A13289E983
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\sqlDuzenle.dll

using ConfigOku;
using sql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace sqlDuzenle
{
  internal class sorgu
  {
    private Fonksiyon fonksiyon;
    private SqlConnection con;
    private string dizin = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";
    private string db = "";
    internal AraYuz frm;
    internal bool baglanti = false;
    private bool islem = false;

    public sorgu()
    {
      try
      {
        this.fonksiyon = new confikOku().FonksiyonKur();
        this.con = this.fonksiyon.Baglan();
        this.db = new AyarCek(this.dizin).Oku("Ayarlar", "database");
        this.baglanti = true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Hata Bağlantı Kurulamadı");
        this.baglanti = false;
      }
    }

    public string refpackage() => "USE [" + this.db + "] IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_RefPackageItem]') AND type in (N'U')) DROP TABLE [dbo].[_RefPackageItem] USE [" + this.db + "] SET ANSI_NULLS ON SET QUOTED_IDENTIFIER ON  SET ANSI_PADDING ON  CREATE TABLE [dbo].[_RefPackageItem]( [Service] [tinyint] NOT NULL, [Country] [int] NOT NULL, [ID] [int] IDENTITY(1,1) NOT NULL, [CodeName128] [varchar](129) NOT NULL, [SaleTag] [smallint] NOT NULL, [ExpandTerm] [varchar](65) NOT NULL, [NameStrID] [varchar](129) NOT NULL, [DescStrID] [varchar](129) NOT NULL, [AssocFileIcon] [varchar](129) NOT NULL, [Param1] [int] NOT NULL, [Param1_Desc128] [varchar](129) NOT NULL, [Param2] [int] NOT NULL, [Param2_Desc128] [varchar](129) NOT NULL, [Param3] [int] NOT NULL, [Param3_Desc128] [varchar](129) NOT NULL, [Param4] [int] NOT NULL, [Param4_Desc128] [varchar](129) NOT NULL, CONSTRAINT [PK__RefPackageItem] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] SET ANSI_PADDING OFF";

    public string _RefPricePolicyOfItem() => "USE [" + this.db + "] IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_RefPricePolicyOfItem]') AND type in (N'U'))DROP TABLE [dbo].[_RefPricePolicyOfItem] USE [" + this.db + "] SET ANSI_NULLS ON SET QUOTED_IDENTIFIER ON SET ANSI_PADDING ON CREATE TABLE [dbo].[_RefPricePolicyOfItem]([Service] [tinyint] NOT NULL,[Country] [int] NOT NULL,[RefPackageItemCodeName] [varchar](129) NOT NULL,[PaymentDevice] [int] NOT NULL,[PreviousCost] [int] NOT NULL,[Cost] [int] NOT NULL,[Param1] [int] NOT NULL,[Param1_Desc128] [varchar](129) NOT NULL,[Param2] [int] NOT NULL,[Param2_Desc128] [varchar](129) NOT NULL,[Param3] [int] NOT NULL,[Param3_Desc128] [varchar](129) NULL,[Param4] [int] NOT NULL,[Param4_Desc128] [varchar](129) NOT NULL,[index] [int] IDENTITY(1,1) NOT NULL,CONSTRAINT [PK__RefPricePolicyOfItem] PRIMARY KEY CLUSTERED([index] ASC) WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, IGNORE_DUP_KEY=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]) ON [PRIMARY] SET ANSI_PADDING OFF";

    public string _RefScrapOfPackageItem() => "USE [" + this.db + "] IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_RefScrapOfPackageItem]') AND type in (N'U'))DROP TABLE [dbo].[_RefScrapOfPackageItem]USE [" + this.db + "] SET ANSI_NULLS ON SET QUOTED_IDENTIFIER ON SET ANSI_PADDING ON CREATE TABLE [dbo].[_RefScrapOfPackageItem]([Service] [tinyint] NOT NULL,[Country] [int] NOT NULL,[RefPackageItemCodeName] [varchar](129) NOT NULL,[RefItemCodeName] [varchar](129) NOT NULL,[OptLevel] [tinyint] NOT NULL,[Variance] [bigint] NOT NULL,[Data] [int] NOT NULL,[MagParamNum] [tinyint] NOT NULL,[MagParam1] [bigint] NOT NULL,[MagParam2] [bigint] NOT NULL,[MagParam3] [bigint] NOT NULL,[MagParam4] [bigint] NOT NULL,[MagParam5] [bigint] NOT NULL,[MagParam6] [bigint] NOT NULL,[MagParam7] [bigint] NOT NULL,[MagParam8] [bigint] NOT NULL,[MagParam9] [bigint] NOT NULL,[MagParam10] [bigint] NOT NULL,[MagParam11] [bigint] NOT NULL,[MagParam12] [bigint] NOT NULL,[Param1] [int] NOT NULL,[Param1_Desc128] [varchar](129) NOT NULL,[Param2] [int] NOT NULL,[Param2_Desc128] [varchar](129) NOT NULL,[Param3] [int] NOT NULL,[Param3_Desc128] [varchar](129) NOT NULL,[Param4] [int] NOT NULL,[Param4_Desc128] [varchar](129) NOT NULL,[Index] [int] IDENTITY(1,1) NOT NULL, CONSTRAINT [PK__RefScrapOfPackageItem] PRIMARY KEY CLUSTERED ([Index] ASC) WITH (PAD_INDEX=OFF, STATISTICS_NORECOMPUTE=OFF, IGNORE_DUP_KEY=OFF, ALLOW_ROW_LOCKS=ON, ALLOW_PAGE_LOCKS=ON) ON [PRIMARY]) ON [PRIMARY] SET ANSI_PADDING OFF";

    public string _RefShopGoods() => "USE [" + this.db + "]IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_RefShopGoods]') AND type in (N'U'))DROP TABLE [dbo].[_RefShopGoods] USE [" + this.db + "] SET ANSI_NULLS ON SET QUOTED_IDENTIFIER ON SET ANSI_PADDING ON CREATE TABLE [dbo].[_RefShopGoods]([Service] [tinyint] NOT NULL,[Country] [int] NOT NULL,[RefTabCodeName] [varchar](129) NOT NULL,[RefPackageItemCodeName] [varchar](129) NOT NULL,[SlotIndex] [tinyint] NOT NULL,[Param1] [int] NOT NULL,[Param1_Desc128] [varchar](129) NOT NULL,[Param2] [int] NOT NULL,[Param2_Desc128] [varchar](129) NOT NULL,[Param3] [int] NOT NULL,[Param3_Desc128] [varchar](129) NOT NULL,[Param4] [int] NOT NULL,[Param4_Desc128] [varchar](129) NOT NULL,[index] [int] IDENTITY(1,1) NOT NULL, CONSTRAINT [PK__RefShopGoods] PRIMARY KEY CLUSTERED (\t[index] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]SET ANSI_PADDING OFF";

    public void TabloGuncelle(string tablo, string duzenlemeSql)
    {
      if (!this.islem)
      {
        SqlCommand selectCommand = new SqlCommand();
        selectCommand.Connection = this.con;
        if (tablo != "")
        {
          selectCommand.CommandText = "SELECT CodeName128 AS COUNT FROM _RefPackageItem GROUP BY CodeName128 HAVING (COUNT(*) > 1)";
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
          DataTable dataTable = new DataTable();
          sqlDataAdapter.Fill(dataTable);
          if (dataTable.Rows.Count > 0)
          {
            for (int index = 0; index < dataTable.Rows.Count; ++index)
            {
              selectCommand.CommandText = "delete from _RefPackageItem where CodeName128='" + dataTable.Rows[index][0].ToString() + "'";
              selectCommand.ExecuteNonQuery();
              selectCommand.Dispose();
            }
          }
        }
        if (tablo != "")
        {
          selectCommand.CommandText = "SELECT RefPackageItemCodeName AS COUNT FROM _RefScrapOfPackageItem GROUP BY RefPackageItemCodeName HAVING (COUNT(*) > 1)";
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
          DataTable dataTable = new DataTable();
          sqlDataAdapter.Fill(dataTable);
          if (dataTable.Rows.Count > 0)
          {
            for (int index = 0; index < dataTable.Rows.Count; ++index)
            {
              selectCommand.CommandText = "delete from _RefScrapOfPackageItem where RefPackageItemCodeName='" + dataTable.Rows[index][0].ToString() + "'";
              selectCommand.ExecuteNonQuery();
              selectCommand.Dispose();
            }
          }
        }
        this.tabloKarsilastir();
        this.islem = true;
      }
      DataTable dataTable1 = new DataTable();
      SqlDataAdapter adapter = new SqlDataAdapter();
      SqlCommand sqlCommand = new SqlCommand("select * from " + tablo, this.con);
      adapter.SelectCommand = sqlCommand;
      adapter.Fill(dataTable1);
      sqlCommand.CommandText = duzenlemeSql;
      sqlCommand.ExecuteNonQuery();
      sqlCommand.CommandText = "select * from " + tablo;
      adapter.SelectCommand = sqlCommand;
      SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
      adapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
      adapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
      DataTable dataTable2 = new DataTable();
      adapter.Fill(dataTable2);
      this.frm.pro.Maximum = 100;
      this.frm.lblBilgi.Text = tablo + " Tablosu Düzeltiliyor...";
      for (int index1 = 0; index1 < 2; ++index1)
      {
        if (index1 < 1)
        {
          for (int index2 = 0; index2 < dataTable1.Rows.Count; ++index2)
          {
            DataRow row = dataTable2.NewRow();
            for (int columnIndex = 0; columnIndex < dataTable1.Columns.Count; ++columnIndex)
            {
              row[columnIndex] = dataTable1.Rows[index2][columnIndex];
              Application.DoEvents();
            }
            dataTable2.Rows.Add(row);
            this.frm.pro.Value = (index2 + 1) * 100 / dataTable1.Rows.Count;
            Application.DoEvents();
            Thread.Sleep(5);
          }
        }
        else
        {
          this.frm.lblBilgi.Text = tablo + " Tablosuna Veriler Yazılıyor";
          Application.DoEvents();
        }
      }
      adapter.Update(dataTable2);
    }

    public void tabloKarsilastir()
    {
      string[][] strArray = new string[4][]
      {
        new string[2]{ "_RefShopGoods", "RefPackageItemCodeName" },
        new string[2]
        {
          "_RefPricePolicyOfItem",
          "RefPackageItemCodeName"
        },
        new string[2]
        {
          "_RefScrapOfPackageItem",
          "RefPackageItemCodeName"
        },
        new string[2]{ "_RefPackageItem", "CodeName128" }
      };
      DataSet dataSet = new DataSet();
      for (int index1 = 0; index1 < strArray.Length; ++index1)
      {
        this.frm.lblBilgi.Text = strArray[index1][0] + " Toblosu Diğer Tablolarla Karşılaştırılıyor";
        DataTable dataTable = new DataTable();
        new SqlDataAdapter(new SqlCommand("select " + strArray[index1][1] + " from " + strArray[index1][0], this.con)).Fill(dataTable);
        dataSet.Tables.Add(dataTable);
        this.frm.pro.Maximum = 100;
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = this.con;
        for (int index2 = 0; index2 < dataTable.Rows.Count; ++index2)
        {
          int index3 = index1 + 1;
          if (index3 > strArray.Length - 1)
            index3 = 0;
          sqlCommand.CommandText = "select " + strArray[index3][1] + " from " + strArray[index3][0] + " where " + strArray[index3][1] + "='" + dataTable.Rows[index2][0].ToString() + "'";
          SqlDataReader sqlDataReader1 = sqlCommand.ExecuteReader();
          if (!sqlDataReader1.Read())
          {
            sqlDataReader1.Dispose();
            sqlDataReader1.Close();
            sqlCommand.CommandText = "delete from " + strArray[index1][0] + " where " + strArray[index1][1] + "='" + dataTable.Rows[index2][0].ToString() + "'";
            sqlCommand.ExecuteNonQuery();
          }
          sqlDataReader1.Dispose();
          sqlDataReader1.Close();
          int index4 = index3 + 1;
          if (index4 > strArray.Length - 1)
            index4 = 0;
          sqlCommand.CommandText = "select " + strArray[index4][1] + " from " + strArray[index4][0] + " where " + strArray[index4][1] + "='" + dataTable.Rows[index2][0].ToString() + "'";
          SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();
          if (!sqlDataReader2.Read())
          {
            sqlDataReader2.Dispose();
            sqlDataReader2.Close();
            sqlCommand.CommandText = "delete from " + strArray[index1][0] + " where " + strArray[index1][1] + "='" + dataTable.Rows[index2][0].ToString() + "'";
            sqlCommand.ExecuteNonQuery();
          }
          sqlDataReader2.Dispose();
          sqlDataReader2.Close();
          int index5 = index4 + 1;
          if (index5 > strArray.Length - 1)
            index5 = 0;
          sqlCommand.CommandText = "select " + strArray[index5][1] + " from " + strArray[index5][0] + " where " + strArray[index5][1] + "='" + dataTable.Rows[index2][0].ToString() + "'";
          SqlDataReader sqlDataReader3 = sqlCommand.ExecuteReader();
          if (!sqlDataReader3.Read())
          {
            sqlDataReader3.Dispose();
            sqlDataReader3.Close();
           // "delete from " + strArray[index1][0] + " where " + strArray[index1][1] + "='" + dataTable.Rows[index2][0].ToString() + "'";
            sqlCommand.CommandText = "delete from " + strArray[index1][0] + " where " + strArray[index1][1] + "='" + dataTable.Rows[index2][0].ToString() + "'";
            sqlCommand.ExecuteNonQuery();
          }
          sqlDataReader3.Dispose();
          sqlDataReader3.Close();
          this.frm.pro.Value = index2 * 100 / dataTable.Rows.Count;
          Application.DoEvents();
        }
        sqlCommand.Dispose();
        dataSet.Tables.Remove(dataTable);
      }
    }
  }
}
