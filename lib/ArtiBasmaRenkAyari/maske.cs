// Decompiled with JetBrains decompiler
// Type: ArtiBasmaRenkAyari.maske
// Assembly: ArtiBasmaRenkAyari, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4781CAE8-CCED-42E3-84C7-CC751066D213
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\ArtiBasmaRenkAyari.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ArtiBasmaRenkAyari
{
  public class maske : Form
  {
    private string dizin = Path.GetDirectoryName(Application.ExecutablePath) + "\\maske";
    private string resim = "";
    internal yeniTree yTre = (yeniTree) null;
    internal ArtiRenkleri frm = (ArtiRenkleri) null;
    private IContainer components = (IContainer) null;
    private PictureBox picResim;
    private Button button1;
    private ListView liste;

    public maske() => this.InitializeComponent();

    private void maske_Load(object sender, EventArgs e)
    {
      if (!Directory.Exists(this.dizin))
        return;
      this.liste.View = View.Details;
      string[] files = Directory.GetFiles(this.dizin, "*.PNG");
      this.liste.Columns.Add("Dosya Adı", 130);
      for (int index = 0; index < files.Length; ++index)
      {
        string[] strArray = files[index].Split('\\');
        this.liste.Items.Add(strArray[strArray.Length - 1]);
      }
    }

    private void liste_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.liste.Items.Count; ++index)
        this.resim = this.liste.SelectedItems[0].Text;
      this.picResim.Image = (Image) new Bitmap((Image) new Bitmap(this.dizin + "\\" + this.resim), 108, 108);
      this.picResim.SizeMode = PictureBoxSizeMode.StretchImage;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.yTre != null)
      {
        this.yTre.ResimYukle(this.resim, this.dizin);
        this.Close();
      }
      if (this.frm == null)
        return;
      this.frm.ResimYukle(this.resim, this.dizin);
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.picResim = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.liste = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.picResim)).BeginInit();
            this.SuspendLayout();
            // 
            // picResim
            // 
            this.picResim.BackColor = System.Drawing.Color.LightGray;
            this.picResim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picResim.Location = new System.Drawing.Point(153, 6);
            this.picResim.Name = "picResim";
            this.picResim.Size = new System.Drawing.Size(108, 108);
            this.picResim.TabIndex = 1;
            this.picResim.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(153, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tamam";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // liste
            // 
            this.liste.ForeColor = System.Drawing.Color.Maroon;
            this.liste.HideSelection = false;
            this.liste.Location = new System.Drawing.Point(7, 6);
            this.liste.Name = "liste";
            this.liste.Size = new System.Drawing.Size(140, 132);
            this.liste.TabIndex = 3;
            this.liste.UseCompatibleStateImageBehavior = false;
            this.liste.Click += new System.EventHandler(this.liste_Click);
            // 
            // maske
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(267, 150);
            this.Controls.Add(this.liste);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picResim);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "maske";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maske";
            this.Load += new System.EventHandler(this.maske_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picResim)).EndInit();
            this.ResumeLayout(false);

    }
  }
}
