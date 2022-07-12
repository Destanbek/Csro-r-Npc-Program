// Decompiled with JetBrains decompiler
// Type: vSRONPC.serial
// Assembly: vSRONPC, Version=1.0.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 1ABE91E6-4F3A-49F7-8F43-72B7B7C8A98F
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\CSRO1.239NPC.exe

using System;

namespace CSRORNPC
{
  [Serializable]
  public class serial
  {
    private string _serial = "";
    private string _aktive = "";

    public string Serial
    {
      get => this._serial;
      set => this._serial = value;
    }

    public string Aktive
    {
      get => this._aktive;
      set => this._aktive = value;
    }
  }
}
