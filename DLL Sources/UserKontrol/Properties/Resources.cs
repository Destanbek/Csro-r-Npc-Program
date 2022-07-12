// Decompiled with JetBrains decompiler
// Type: UserKontrol.Properties.Resources
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace UserKontrol.Properties
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (UserKontrol.Properties.Resources.resourceMan == null)
          UserKontrol.Properties.Resources.resourceMan = new ResourceManager("UserKontrol.Properties.Resources", typeof (UserKontrol.Properties.Resources).Assembly);
        return UserKontrol.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => UserKontrol.Properties.Resources.resourceCulture;
      set => UserKontrol.Properties.Resources.resourceCulture = value;
    }

    internal Resources()
    {
    }
  }
}
