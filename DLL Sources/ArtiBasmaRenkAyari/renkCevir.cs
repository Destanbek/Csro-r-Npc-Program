// Decompiled with JetBrains decompiler
// Type: ArtiBasmaRenkAyari.renkCevir
// Assembly: ArtiBasmaRenkAyari, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4781CAE8-CCED-42E3-84C7-CC751066D213
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\ArtiBasmaRenkAyari.dll

using System;

namespace ArtiBasmaRenkAyari
{
  internal static class renkCevir
  {
    internal static string RGBRenk(string silkroadRenk)
    {
      string[] strArray = silkroadRenk.Split(',');
      string str = "";
      for (int index = 0; index < strArray.Length; ++index)
      {
        double num = Convert.ToDouble(strArray[index]);
        str = str + "," + Math.Round(num * (double) byte.MaxValue / 1000.0).ToString();
      }
      return str.Substring(1);
    }

    internal static string SilkroadRenk(string RGB)
    {
      string[] strArray = RGB.Split(',');
      string str1 = "";
      for (int index = 0; index < strArray.Length; ++index)
      {
        double num = Convert.ToDouble(strArray[index]);
        num = Math.Round(num * 1000.0 / (double) byte.MaxValue, 3);
        num = (double) Convert.ToInt32(num);
        string str2 = num != 1000.0 ? (num != 0.0 ? (num >= 100.0 ? "0." + num.ToString() : "0.0" + num.ToString()) : "0.000") : "1.000";
        str1 = str1 + "," + str2;
      }
      return str1.Substring(1);
    }
  }
}
