// Decompiled with JetBrains decompiler
// Type: vSRONPC.Config
// Assembly: vSRONPC, Version=1.0.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 1ABE91E6-4F3A-49F7-8F43-72B7B7C8A98F
// Assembly location: C:\Users\Admin\Desktop\CSRO-R NPC ROGRAMI\CSRO1.239NPC.exe

using sql;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CSRORNPC
{
  public class Config : Form
  {
    public AnaMenu anaMenu;
    private string dizin = Path.GetDirectoryName(Application.ExecutablePath);
    private Fonksiyon fonksiyon;
    private AyarCek ayar;
    private IContainer components = (IContainer) null;
    private Label label1;
    private TextBox txtServer;
    private TextBox txtUser;
    private Label label2;
    private TextBox txtPass;
    private Label label3;
    private TextBox txtDatabase;
    private Label label4;
        private GroupBox groupBox1;
        private Button button1;

    public Config() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.txtDatabase.Text == "" || this.txtPass.Text == "" || this.txtServer.Text == "" || this.txtUser.Text == "")
      {
        int num1 = (int) MessageBox.Show("Lütfen Tüm Alanları Doldurun...");
      }
      else
      {
        FileStream fileStream = File.Create(this.dizin + "\\Config.ini");
        fileStream.Dispose();
        fileStream.Close();
        this.ayar.Yaz("Ayarlar", "server", this.txtServer.Text);
        this.ayar.Yaz("Ayarlar", "user", this.txtUser.Text);
        this.ayar.Yaz("Ayarlar", "password", this.txtPass.Text);
        this.ayar.Yaz("Ayarlar", "database", this.txtDatabase.Text);
        this.fonksiyon = new Fonksiyon(this.txtServer.Text, this.txtDatabase.Text, this.txtUser.Text, this.txtPass.Text);
        if (this.fonksiyon.Test())
        {
          this.anaMenu.btnBaglan.Enabled = false;
          this.anaMenu.btnNPC.Enabled = true;
          this.anaMenu.btnEfekt.Enabled = true;
          this.anaMenu.btnSqlDuzenle.Enabled = true;
          MessageBox.Show("Başarı ile Bağlandı!");
          this.Close();
        }
        else
        {
          int num2 = (int) MessageBox.Show("Bağlantı Kurulamadı. Lütfen Kontrol Edin");
        }
      }
    }

    private void Config_Load(object sender, EventArgs e)
    {
      this.ayar = new AyarCek(this.dizin + "\\Config.ini");
      if (!File.Exists(this.dizin + "\\Config.ini"))
        return;
      this.txtDatabase.Text = this.ayar.Oku("Ayarlar", "database");
      this.txtPass.Text = this.ayar.Oku("Ayarlar", "password");
      this.txtServer.Text = this.ayar.Oku("Ayarlar", "server");
      this.txtUser.Text = this.ayar.Oku("Ayarlar", "user");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL Server Adı :";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(102, 13);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(120, 20);
            this.txtServer.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(102, 39);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(120, 20);
            this.txtUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL Kullanıcı Adı :";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(102, 65);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '|';
            this.txtPass.Size = new System.Drawing.Size(120, 20);
            this.txtPass.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SQL Şifre :";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(102, 91);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(120, 20);
            this.txtDatabase.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "DB Adı :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(102, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "BAGLAN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 163);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(254, 164);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

    }
  }
}
