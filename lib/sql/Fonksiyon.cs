// Decompiled with JetBrains decompiler
// Type: sql.Fonksiyon
// Assembly: sql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8155520-358D-46F4-8A74-5A81A571B49D
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\sql.dll

using System;
using System.Data;
using System.Data.SqlClient;

namespace sql
{
  public class Fonksiyon
  {
    private string _dataSorc = "";
    private string _dataBase = "";
    private string _sqlUser = "";
    private string _sqlPassword = "";
    private bool baglandi = false;

    public bool Baglandi => this.baglandi;

    public Fonksiyon(string serverName, string dataBase, string user, string password)
    {
      this._dataSorc = serverName;
      this._dataBase = dataBase;
      this._sqlUser = user;
      this._sqlPassword = password;
    }

    public bool Test()
    {
      bool flag;
      try
      {
        SqlConnection sqlConnection = this.Baglan();
        sqlConnection.Close();
        sqlConnection.Dispose();
        flag = true;
      }
      catch
      {
        flag = false;
      }
      return flag;
    }

    public SqlConnection Baglan()
    {
      SqlConnection sqlConnection = new SqlConnection("Data Source=" + this._dataSorc + ";Initial Catalog=" + this._dataBase + ";User ID=" + this._sqlUser + ";Password=" + this._sqlPassword);
      sqlConnection.Open();
      return sqlConnection;
    }

    public int cmd(string sqlCumle)
    {
      SqlConnection connection = this.Baglan();
      SqlCommand sqlCommand = new SqlCommand(sqlCumle, connection);
      int num;
      try
      {
        num = sqlCommand.ExecuteNonQuery();
      }
      catch (SqlException ex)
      {
        throw new Exception(ex.Message + "( " + sqlCumle + " )");
      }
      sqlCommand.Dispose();
      connection.Close();
      connection.Dispose();
      return num;
    }

    public DataTable getDataTable(string sqlCumle)
    {
      SqlConnection selectConnection = this.Baglan();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCumle, selectConnection);
      DataTable dataTable = new DataTable();
      try
      {
        sqlDataAdapter.Fill(dataTable);
      }
      catch (SqlException ex)
      {
        throw new Exception(ex.Message + "( " + sqlCumle + " )");
      }
      sqlDataAdapter.Dispose();
      selectConnection.Close();
      selectConnection.Dispose();
      return dataTable;
    }

    public DataSet getDataSet(string sqlCumle)
    {
      SqlConnection selectConnection = this.Baglan();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCumle, selectConnection);
      DataSet dataSet = new DataSet();
      try
      {
        sqlDataAdapter.Fill(dataSet);
      }
      catch (SqlException ex)
      {
        throw new Exception(ex.Message + "( " + sqlCumle + " )");
      }
      return dataSet;
    }

    public DataRow getDataRow(string sqlCumle)
    {
      DataTable dataTable = this.getDataTable(sqlCumle);
      return dataTable.Rows.Count != 0 ? dataTable.Rows[0] : (DataRow) null;
    }

    public string getDataCell(string sqlCumle)
    {
      DataTable dataTable = this.getDataTable(sqlCumle);
      return dataTable.Rows.Count != 0 ? dataTable.Rows[0][0].ToString() : (string) null;
    }
  }
}
