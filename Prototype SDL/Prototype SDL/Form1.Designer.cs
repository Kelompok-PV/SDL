﻿namespace Prototype_SDL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treePanel = new System.Windows.Forms.Panel();
            this.insertTb = new System.Windows.Forms.TextBox();
            this.insertBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // treePanel
            // 
            this.treePanel.Location = new System.Drawing.Point(12, 12);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(1021, 371);
            this.treePanel.TabIndex = 0;
            this.treePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.treePanel_Paint);
            this.treePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treePanel_MouseDown);
            this.treePanel.MouseLeave += new System.EventHandler(this.treePanel_MouseLeave);
            this.treePanel.MouseHover += new System.EventHandler(this.treePanel_MouseHover);
            this.treePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treePanel_MouseUp);
            // 
            // insertTb
            // 
            this.insertTb.Location = new System.Drawing.Point(71, 404);
            this.insertTb.Name = "insertTb";
            this.insertTb.Size = new System.Drawing.Size(83, 20);
            this.insertTb.TabIndex = 1;
            // 
            // insertBtn
            // 
            this.insertBtn.Location = new System.Drawing.Point(161, 402);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(75, 23);
            this.insertBtn.TabIndex = 2;
            this.insertBtn.Text = "Insert";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cetak";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.insertTb);
            this.Controls.Add(this.treePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel treePanel;
        private System.Windows.Forms.TextBox insertTb;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}

