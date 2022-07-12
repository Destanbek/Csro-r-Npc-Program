// Decompiled with JetBrains decompiler
// Type: vSRONPC.Program
// Assembly: vSRONPC, Version=1.0.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 1ABE91E6-4F3A-49F7-8F43-72B7B7C8A98F
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\CSRO1.239NPC.exe

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSRORNPC
{
  internal static class Program
  {
    [STAThread]
    private static void Main(string[] args)
    {
      if (args.Length != 0)
      {
        if (!(args[0].Substring(0, 2) == "/u"))
          return;
        string str = args[0].Split('=')[1];
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
        new Process()
        {
          StartInfo = {
            FileName = (folderPath + "\\msiexec.exe"),
            Arguments = ("/i" + str)
          }
        }.Start();
      }
      else
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run((Form) new AnaMenu());
      }
    }
  }
}
