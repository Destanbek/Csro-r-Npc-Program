// Decompiled with JetBrains decompiler
// Type: ConfigOku.confikOku
// Assembly: ConfigOku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07BCC9DA-D016-49B6-BC91-59B5C3E39591
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\ConfigOku.dll

using sql;
using System.IO;
using System.Windows.Forms;

namespace ConfigOku
{
  public class confikOku
  {
    private AyarCek ayar;
    private string dizin = Path.GetDirectoryName(Application.ExecutablePath);

    public confikOku() => this.ayar = new AyarCek(this.dizin + "\\config.ini");

    public Fonksiyon FonksiyonKur() => new Fonksiyon(this.ayar.Oku("Ayarlar", "server"), this.ayar.Oku("Ayarlar", "database"), this.ayar.Oku("Ayarlar", "user"), this.ayar.Oku("Ayarlar", "password"));
  }
}
