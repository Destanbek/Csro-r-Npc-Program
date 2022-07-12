// Decompiled with JetBrains decompiler
// Type: UserKontrol.efpClass
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserKontrol
{
  internal class efpClass
  {
    public byte[][][] byt;
    private string yol = "";
    private long[] _posizyon;

    public efpClass(string path)
    {
      BinaryReader rBinary = new BinaryReader((Stream) File.Open(path, FileMode.Open), (Encoding) new ASCIIEncoding());
      this.yol = path;
      this._posizyon = this.renkAgaci(rBinary, "BlendDiffuseGraph");
      this.byt = new byte[this._posizyon.Length][][];
      for (int index1 = 0; index1 < this._posizyon.Length; ++index1)
      {
        rBinary.BaseStream.Position = this._posizyon[index1] + 25L;
        int length = rBinary.ReadInt32();
        rBinary.BaseStream.Position += 4L;
        this.byt[index1] = new byte[length][];
        for (int index2 = 0; index2 < length; ++index2)
        {
          byte[] numArray = rBinary.ReadBytes(3);
          this.byt[index1][index2] = new byte[3]
          {
            numArray[2],
            numArray[1],
            numArray[0]
          };
          rBinary.BaseStream.Position += 5L;
        }
      }
      rBinary.Close();
      rBinary.Dispose();
    }

    private long[] renkAgaci(BinaryReader rBinary, string aranan)
    {
      List<long> longList = new List<long>();
      rBinary.BaseStream.Position = 0L;
      while (rBinary.PeekChar() != -1)
      {
        if (rBinary.ReadChar().ToString() == aranan.Substring(0, 1) && rBinary.BaseStream.Length - rBinary.BaseStream.Position > (long) aranan.Length)
        {
          --rBinary.BaseStream.Position;
          if (aranan == new string(rBinary.ReadChars(aranan.Length)))
            longList.Add(rBinary.BaseStream.Position - (long) aranan.Length);
        }
      }
      return longList.ToArray();
    }

    public bool EFPKayit(byte[][][] bufer, string path)
    {
      if (path != this.yol)
      {
        File.Delete(path);
        File.Copy(this.yol, path);
      }
      BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(path, FileMode.Open));
      bool flag;
      try
      {
        for (int index1 = 0; index1 < bufer.Length; ++index1)
        {
          binaryWriter.BaseStream.Position = this._posizyon[index1] + 33L;
          for (int index2 = 0; index2 < bufer[index1].Length; ++index2)
          {
            binaryWriter.Write(bufer[index1][index2][2]);
            binaryWriter.Write(bufer[index1][index2][1]);
            binaryWriter.Write(bufer[index1][index2][0]);
            binaryWriter.BaseStream.Position += 5L;
          }
        }
        flag = true;
      }
      catch
      {
        flag = false;
      }
      binaryWriter.Close();
      binaryWriter.Dispose();
      return flag;
    }
  }
}
