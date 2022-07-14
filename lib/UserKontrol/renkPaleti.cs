// Decompiled with JetBrains decompiler
// Type: UserKontrol.renkPaleti
// Assembly: UserKontrol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7370C2DD-9D5F-4B2C-A8D4-7E9366F506CC
// Assembly location: C:\Users\Admin\Desktop\CSRO1.239NPC\lib\UserKontrol.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UserKontrol
{
  public class renkPaleti : Form
  {
    private int sayi = 0;
    private List<Color> renkler = new List<Color>();
    internal rarParlamasi par;
    private TreeNode node;
    private IContainer components = (IContainer) null;
    private TreeView tree;
    private Button btnYeni;
    private Button btnTamam;
    private Label label1;
    private Button btnDegistir;

    public renkPaleti() => this.InitializeComponent();

    private void renkPaleti_Load(object sender, EventArgs e)
    {
      this.tree.Nodes.Add("Seçilen Renkler");
      this.btnDegistir.Enabled = false;
      this.btnTamam.Enabled = false;
    }

    private void btnYeni_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      if (colorDialog.ShowDialog() != DialogResult.OK)
        return;
      this.tree.Nodes[0].Nodes.Add("Renk" + (object) (this.sayi + 1));
      this.tree.Nodes[0].Nodes[this.sayi].BackColor = colorDialog.Color;
      this.renkler.Add(colorDialog.Color);
      ++this.sayi;
      if (!this.btnTamam.Enabled)
        this.btnTamam.Enabled = true;
    }

    private void btnTamam_Click(object sender, EventArgs e)
    {
      this.par.renkleriAta(this.renkler.ToArray());
      this.Close();
    }

    private void tree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (e.Node.Level == 0)
        return;
      this.btnDegistir.Enabled = true;
      this.node = e.Node;
    }

    private void btnDegistir_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      if (colorDialog.ShowDialog() != DialogResult.OK)
        return;
      this.node.BackColor = colorDialog.Color;
      this.renkler[this.node.Index] = colorDialog.Color;
      this.btnDegistir.Enabled = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.tree = new System.Windows.Forms.TreeView();
            this.btnYeni = new System.Windows.Forms.Button();
            this.btnTamam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDegistir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.ForeColor = System.Drawing.Color.Black;
            this.tree.Location = new System.Drawing.Point(12, 12);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(121, 238);
            this.tree.TabIndex = 1;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // btnYeni
            // 
            this.btnYeni.BackColor = System.Drawing.Color.Lavender;
            this.btnYeni.ForeColor = System.Drawing.Color.Black;
            this.btnYeni.Location = new System.Drawing.Point(160, 12);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(75, 23);
            this.btnYeni.TabIndex = 2;
            this.btnYeni.Text = "Yeni Renk";
            this.btnYeni.UseVisualStyleBackColor = false;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnTamam
            // 
            this.btnTamam.BackColor = System.Drawing.Color.Lavender;
            this.btnTamam.ForeColor = System.Drawing.Color.Black;
            this.btnTamam.Location = new System.Drawing.Point(160, 41);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 36);
            this.btnTamam.TabIndex = 2;
            this.btnTamam.Text = "Renkler Tama";
            this.btnTamam.UseVisualStyleBackColor = false;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(142, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Renk Seçimlerinizi Yapınız";
            // 
            // btnDegistir
            // 
            this.btnDegistir.BackColor = System.Drawing.Color.Lavender;
            this.btnDegistir.ForeColor = System.Drawing.Color.Black;
            this.btnDegistir.Location = new System.Drawing.Point(160, 83);
            this.btnDegistir.Name = "btnDegistir";
            this.btnDegistir.Size = new System.Drawing.Size(75, 36);
            this.btnDegistir.TabIndex = 2;
            this.btnDegistir.Text = "Rengi Değiştir";
            this.btnDegistir.UseVisualStyleBackColor = false;
            this.btnDegistir.Click += new System.EventHandler(this.btnDegistir_Click);
            // 
            // renkPaleti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDegistir);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.tree);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = this.Icon;
            this.Name = "renkPaleti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "renkPaleti";
            this.Load += new System.EventHandler(this.renkPaleti_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
