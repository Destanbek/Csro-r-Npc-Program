// Decompiled with JetBrains decompiler
// Type: vSRONPC.AyarCek
// Assembly: vSRONPC, Version=1.0.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 1ABE91E6-4F3A-49F7-8F43-72B7B7C8A98F
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\CSRO1.239NPC.exe

using System.Runtime.InteropServices;
using System.Text;

namespace CSRORNPC
{
  internal class AyarCek
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
