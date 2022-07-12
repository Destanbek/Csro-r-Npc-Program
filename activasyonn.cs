// Decompiled with JetBrains decompiler
// Type: vSRONPC.activasyonn
// Assembly: vSRONPC, Version=1.0.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 1ABE91E6-4F3A-49F7-8F43-72B7B7C8A98F
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\CSRO1.239NPC.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Management;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CSRORNPC
{
  public class activasyonn : Form
  {
    private serial seri;
    private string act = "";
    private ArrayList hddCollection;
    private string yazi = "";
    public AnaMenu anaMenu;
    public bool yapildi = false;
    private string dizin = Path.GetDirectoryName(Application.ExecutablePath) + "\\serial.dat";
    private IContainer components = (IContainer) null;
    private TextBox txtSerial;
    private Label label1;
    private TextBox txtActivasyon;
    private Label label2;
    private Button btnAktiveEt;

    public activasyonn() => this.InitializeComponent();

    private void Form1_Load(object sender, EventArgs e)
    {
      this.hddCollection = new ArrayList();
      this.DesirizeEt();
    }

    public string MDCevir(string metin)
    {
      MD5CryptoServiceProvider hal = new MD5CryptoServiceProvider();
      return this.Sifre(metin.Substring(metin.Length / 9 * 2) + "utku" + metin.Substring(metin.Length / 20 * 4) + "nazif" + metin.Substring(metin.Length / 9 * (metin.Length / 8) * (metin.Length / 7) * 2), (HashAlgorithm) hal);
    }

    private string Sifre(string metin, HashAlgorithm hal)
    {
      byte[] bytes = Encoding.Unicode.GetBytes(metin);
      return Convert.ToBase64String(hal.ComputeHash(bytes)).Replace("=", "").ToUpper();
    }

    private void btnAktiveEt_Click(object sender, EventArgs e)
    {
      if (this.txtSerial.Text == this.yazi)
      {
        if (!(this.txtActivasyon.Text == this.MDCevir(this.yazi)))
          return;
        this.SerilizeEt();
        this.yapildi = true;
        int num = (int) MessageBox.Show("Aktivasyon Yapıldı.\nLütfen Formu Tekrar Açın...");
        this.Close();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Serial Numaranız Doğru Değil");
      }
    }

    public void seralNumAl()
    {
      foreach (ManagementObject managementObject in new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia").Get())
      {
        hardDisk hardDisk = new hardDisk();
        if (managementObject["SerialNumber"] != null)
        {
          hardDisk.serialNo = managementObject["SerialNumber"];
          this.hddCollection.Add((object) hardDisk);
        }
      }
      foreach (hardDisk hdd in this.hddCollection)
      {
        this.yazi += (string) hdd.serialNo;
        this.yazi = this.yazi.Replace(" ", "");
      }
      if (this.yazi.Length > 20)
        this.yazi = this.yazi.Substring(0, 20);
      this.yazi = "6000c29a534b07287a54";
    }

    public void DesirizeEt()
    {
      this.seralNumAl();
      this.act = this.MDCevir(this.yazi);
      if (File.Exists(this.dizin))
      {
        FileStream serializationStream = new FileStream(this.dizin, FileMode.Open, FileAccess.Read);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        try
        {
          this.seri = (serial) binaryFormatter.Deserialize((Stream) serializationStream);
          string serial = this.seri.Serial;
          string aktive = this.seri.Aktive;
          serializationStream.Dispose();
          serializationStream.Close();
          if (this.yazi == serial)
          {
            if (this.act == aktive)
            {
              this.yapildi = true;
              this.Close();
            }
            else
            {
              this.txtSerial.Text = this.yazi;
              this.yapildi = false;
            }
          }
          else
          {
            this.txtSerial.Text = this.yazi;
            this.yapildi = false;
          }
        }
        catch
        {
          serializationStream.Dispose();
          serializationStream.Close();
          this.txtSerial.Text = this.yazi;
          this.yapildi = false;
        }
      }
      else
      {
        this.txtSerial.Text = this.yazi;
        this.yapildi = false;
      }
    }

    private void SerilizeEt()
    {
      serial graph = new serial();
      graph.Serial = this.yazi;
      graph.Aktive = this.txtActivasyon.Text;
      FileStream serializationStream = new FileStream(this.dizin, FileMode.OpenOrCreate, FileAccess.Write);
      new BinaryFormatter().Serialize((Stream) serializationStream, (object) graph);
      serializationStream.Close();
      serializationStream.Dispose();
      new FileInfo(this.dizin).Attributes = FileAttributes.System;
    }

    private void activasyonn_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        if (!(this.act != this.seri.Aktive))
          return;
        this.anaMenu.Close();
      }
      catch
      {
        this.anaMenu.Close();
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActivasyon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAktiveEt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSerial.Location = new System.Drawing.Point(9, 202);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(479, 26);
            this.txtSerial.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sistem Numaranız";
            // 
            // txtActivasyon
            // 
            this.txtActivasyon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtActivasyon.Location = new System.Drawing.Point(9, 257);
            this.txtActivasyon.Name = "txtActivasyon";
            this.txtActivasyon.Size = new System.Drawing.Size(479, 26);
            this.txtActivasyon.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Activasyon Kodu";
            // 
            // btnAktiveEt
            // 
            this.btnAktiveEt.BackColor = System.Drawing.Color.Lavender;
            this.btnAktiveEt.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAktiveEt.ForeColor = System.Drawing.Color.Black;
            this.btnAktiveEt.Location = new System.Drawing.Point(9, 290);
            this.btnAktiveEt.Name = "btnAktiveEt";
            this.btnAktiveEt.Size = new System.Drawing.Size(162, 50);
            this.btnAktiveEt.TabIndex = 2;
            this.btnAktiveEt.Text = "Aktive Et";
            this.btnAktiveEt.UseVisualStyleBackColor = false;
            this.btnAktiveEt.Click += new System.EventHandler(this.btnAktiveEt_Click);
            // 
            // activasyonn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(500, 345);
            this.Controls.Add(this.btnAktiveEt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtActivasyon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "activasyonn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aktivasyon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.activasyonn_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
