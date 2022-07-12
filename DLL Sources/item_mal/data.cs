// Decompiled with JetBrains decompiler
// Type: item_mal.data
// Assembly: item_mal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 19D66908-CAEF-4A5D-8729-25B953C4A897
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\item_mal.dll

using ConfigOku;
using sql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace item_mal
{
  internal class data
  {
    private Fonksiyon fonksiyon;
    private string dizin = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";
    private SqlConnection con;
    private SqlCommand cmd;
    private SqlDataAdapter adapter;

    internal data()
    {
      try
      {
        this.fonksiyon = new confikOku().FonksiyonKur();
        this.con = this.fonksiyon.Baglan();
        AyarCek ayarCek = new AyarCek(this.dizin);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("错误：无法连接");
      }
    }

    internal DataTable TablotOlustur(string tablo)
    {
      DataTable dataTable = new DataTable(tablo);
      this.cmd = new SqlCommand("select * from " + tablo, this.con);
      this.adapter = new SqlDataAdapter(this.cmd);
      this.adapter.Fill(dataTable);
      return dataTable;
    }

    internal DataTable SqlGuncelle(DataTable tablo)
    {
      SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
      string tableName = tablo.TableName;
      this.cmd.CommandText = "select * from " + tableName;
      this.cmd.Connection = this.con;
      this.adapter.SelectCommand = this.cmd;
      sqlCommandBuilder.DataAdapter = this.adapter;
      this.adapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
      this.adapter.DeleteCommand = sqlCommandBuilder.GetDeleteCommand();
      this.adapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
      this.adapter.Update(tablo);
      tablo.Clear();
      this.cmd.CommandText = "select * from " + tableName;
      this.adapter.SelectCommand = this.cmd;
      this.adapter.Fill(tablo);
      return tablo;
    }
  }
}
