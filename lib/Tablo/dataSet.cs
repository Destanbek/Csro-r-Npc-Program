// Decompiled with JetBrains decompiler
// Type: Tablo.dataSet
// Assembly: Tablo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E78F8CA-07CF-4084-AFCA-93E703D146E1
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\Tablo.dll

using ConfigOku;
using sql;
using System.Data;
using System.Data.SqlClient;

namespace Tablo
{
  public class dataSet : DataSet
  {
    private Fonksiyon fonksiyon;
    private SqlConnection con;

    public dataSet()
    {
      this.fonksiyon = new confikOku().FonksiyonKur();
      this.con = this.fonksiyon.Baglan();
    }

    public DataTable Tablo(string sqlTabloIsmi)
    {
      new SqlDataAdapter(new SqlCommand("select * from " + sqlTabloIsmi, this.con)).Fill((DataSet) this, sqlTabloIsmi);
      return this.Tables[sqlTabloIsmi];
    }

    public DataTable Update(DataTable table)
    {
      string tableName = table.TableName;
      SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("select * from " + tableName, this.con));
      SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
      adapter.DeleteCommand = sqlCommandBuilder.GetDeleteCommand();
      adapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
      adapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
      adapter.Update((DataSet) this, tableName);
      this.Tables[tableName].Clear();
      adapter.Fill((DataSet) this, tableName);
      return this.Tables[tableName];
    }
  }
}
