// Decompiled with JetBrains decompiler
// Type: UserKontrol.bsr
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace UserKontrol
{
  public class bsr : Form
  {
    private IContainer components = (IContainer) null;
    private ListBox listSonuc;
    private Button btnAra;
    private Label label1;
    private ProgressBar proAra;
    private Label lblBilgi;
    private Label label3;
    private Label label4;
    public NPCEkle npc;
        private GroupBox groupBox1;
        private string dizin = "";

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.listSonuc = new System.Windows.Forms.ListBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.proAra = new System.Windows.Forms.ProgressBar();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listSonuc
            // 
            this.listSonuc.ForeColor = System.Drawing.Color.Black;
            this.listSonuc.FormattingEnabled = true;
            this.listSonuc.Location = new System.Drawing.Point(4, 61);
            this.listSonuc.Name = "listSonuc";
            this.listSonuc.Size = new System.Drawing.Size(201, 264);
            this.listSonuc.TabIndex = 0;
            this.listSonuc.SelectedIndexChanged += new System.EventHandler(this.listSonuc_SelectedIndexChanged);
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.Lavender;
            this.btnAra.ForeColor = System.Drawing.Color.Black;
            this.btnAra.Location = new System.Drawing.Point(211, 61);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(75, 31);
            this.btnAra.TabIndex = 1;
            this.btnAra.Text = "ARA";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Arama Tuşuna Basın Listelendikten Sonra Seçmek için Tıklayın";
            // 
            // proAra
            // 
            this.proAra.Location = new System.Drawing.Point(4, 27);
            this.proAra.Name = "proAra";
            this.proAra.Size = new System.Drawing.Size(201, 23);
            this.proAra.TabIndex = 3;
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.BackColor = System.Drawing.Color.Transparent;
            this.lblBilgi.ForeColor = System.Drawing.Color.Gold;
            this.lblBilgi.Location = new System.Drawing.Point(51, 32);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(97, 13);
            this.lblBilgi.TabIndex = 4;
            this.lblBilgi.Text = "Arama Tamamlandı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seçtiğiniz BSR\'yi herhangi bir hataya karşı Data.PK2 dosyasında";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "res\\npc\\npc altına atınız...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // bsr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(335, 379);
            this.Controls.Add(this.listSonuc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBilgi);
            this.Controls.Add(this.proAra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = this.Icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "bsr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BSR Listesi";
            this.Load += new System.EventHandler(this.bsr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    public bsr() => this.InitializeComponent();

    private void bsr_Load(object sender, EventArgs e)
    {
      this.proAra.Visible = false;
      this.lblBilgi.Visible = false;
      this.listSonuc.Enabled = false;
      this.proAra.Minimum = 0;
      this.dizin = Path.GetDirectoryName(Application.ExecutablePath) + "\\npc listesi";
    }

    private void btnAra_Click(object sender, EventArgs e)
    {
      try
      {
        this.lblBilgi.Visible = false;
        this.btnAra.Enabled = false;
        this.listSonuc.Items.Clear();
        string[] files = Directory.GetFiles(this.dizin, "*.bsr");
        this.proAra.Visible = true;
        this.proAra.Maximum = files.Length;
        this.proAra.Step = 1;
        for (int index = 0; index < files.Length; ++index)
        {
          string[] strArray = files[index].Split('\\');
          this.listSonuc.Items.Add((object) strArray[strArray.Length - 1]);
          Application.DoEvents();
          Thread.Sleep(10);
          this.proAra.Value = index;
        }
        this.listSonuc.Enabled = true;
        this.lblBilgi.Visible = true;
        this.proAra.Visible = false;
        this.btnAra.Enabled = true;
      }
      catch
      {
        this.proAra.Visible = false;
        this.btnAra.Enabled = true;
        int num = (int) MessageBox.Show("\"npc listesi\" dosyası bulunamadı");
      }
    }

    private void listSonuc_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.npc.cmbBSR.Text = this.listSonuc.Text;
      this.Close();
    }
  }
}

