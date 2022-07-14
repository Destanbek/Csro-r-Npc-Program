// Decompiled with JetBrains decompiler
// Type: ConfigOku.AyarCek
// Assembly: ConfigOku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07BCC9DA-D016-49B6-BC91-59B5C3E39591
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\ConfigOku.dll

using System.Runtime.InteropServices;
using System.Text;

namespace ConfigOku
{
  public class AyarCek
  {
    private string dizin = "";

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(
      string section,
      string key,
      string val,
      string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(
      string section,
      string key,
      string def,
      StringBuilder retVal,
      int size,
      string filePath);

    public AyarCek(string path) => this.dizin = path;

    public string Oku(string secik, string key)
    {
      StringBuilder retVal = new StringBuilder(256);
      AyarCek.GetPrivateProfileString(secik, key, "", retVal, (int) byte.MaxValue, this.dizin);
      return retVal.ToString();
    }

    public long Yaz(string secim, string key, string degeri) => AyarCek.WritePrivateProfileString(secim, key, degeri, this.dizin);
  }
}
