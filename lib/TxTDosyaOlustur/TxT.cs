// Decompiled with JetBrains decompiler
// Type: TxTDosyaOlustur.TxT
// Assembly: TxTDosyaOlustur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2A981C97-8164-4448-AAF0-CA6916FF8B32
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\TxTDosyaOlustur.dll

using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TxTDosyaOlustur
{
  public static class TxT
  {
    public static void TxTYaz1(string metin, string anaDizin, string dosyaUzanti)
    {
      if (metin != "")
      {
        Directory.Exists(anaDizin);
        if (!Directory.Exists(anaDizin))
          Directory.CreateDirectory(anaDizin);
        if (File.Exists(anaDizin + "\\" + dosyaUzanti))
        {
          FileStream fileStream1 = new FileStream(anaDizin + "\\" + dosyaUzanti, FileMode.Open);
          StreamReader streamReader = new StreamReader((Stream) fileStream1, Encoding.Unicode);
          string end = streamReader.ReadToEnd();
          streamReader.Dispose();
          streamReader.Close();
          fileStream1.Dispose();
          fileStream1.Close();
          FileStream fileStream2 = new FileStream(anaDizin + "\\" + dosyaUzanti, FileMode.OpenOrCreate);
          StreamWriter streamWriter = new StreamWriter((Stream) fileStream2, Encoding.Unicode);
          if (end != "")
            streamWriter.WriteLine(end);
          streamWriter.Write(metin);
          streamWriter.Dispose();
          streamWriter.Close();
          fileStream2.Dispose();
          fileStream2.Close();
        }
        else
        {
          FileStream fileStream = new FileStream(anaDizin + "\\" + dosyaUzanti, FileMode.OpenOrCreate);
          StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.Unicode);
          streamWriter.Write(metin);
          streamWriter.Dispose();
          streamWriter.Close();
          fileStream.Dispose();
          fileStream.Close();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("HATA Eklenme Başarsız Oldu....");
      }
    }

    public static void TxTSil(string anaDizin, string dosyaUzanti)
    {
      if (!Directory.Exists(anaDizin) || !File.Exists(anaDizin + "\\" + dosyaUzanti))
        return;
      File.Delete(anaDizin + "\\" + dosyaUzanti);
    }

    public static void TxTYazAnsi(string metin, string anaDizin, string dosyaUzanti)
    {
      if (metin != "")
      {
        Directory.Exists(anaDizin);
        if (!Directory.Exists(anaDizin))
          Directory.CreateDirectory(anaDizin);
        if (File.Exists(anaDizin + "\\" + dosyaUzanti))
        {
          FileStream fileStream1 = new FileStream(anaDizin + "\\" + dosyaUzanti, FileMode.Open);
          StreamReader streamReader = new StreamReader((Stream) fileStream1, Encoding.ASCII);
          string end = streamReader.ReadToEnd();
          streamReader.Dispose();
          streamReader.Close();
          fileStream1.Dispose();
          fileStream1.Close();
          FileStream fileStream2 = new FileStream(anaDizin + "\\" + dosyaUzanti, FileMode.OpenOrCreate);
          StreamWriter streamWriter = new StreamWriter((Stream) fileStream2, Encoding.ASCII);
          if (end != "")
            streamWriter.WriteLine(end);
          streamWriter.Write(metin);
          streamWriter.Dispose();
          streamWriter.Close();
          fileStream2.Dispose();
          fileStream2.Close();
        }
        else
        {
          FileStream fileStream = new FileStream(anaDizin + "\\" + dosyaUzanti, FileMode.OpenOrCreate);
          StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.ASCII);
          streamWriter.Write(metin);
          streamWriter.Dispose();
          streamWriter.Close();
          fileStream.Dispose();
          fileStream.Close();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("HATA Eklenme Başarsız Oldu....");
      }
    }
  }
}
