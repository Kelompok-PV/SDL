namespace Prototype_SDL
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
            this.treePanel = new System.Windows.Forms.Panel();
            this.insertTb = new System.Windows.Forms.TextBox();
            this.insertBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treePanel
            // 
            this.treePanel.Location = new System.Drawing.Point(71, 12);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(694, 371);
            this.treePanel.TabIndex = 0;
            this.treePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.treePanel_Paint);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.insertTb);
            this.Controls.Add(this.treePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel treePanel;
        private System.Windows.Forms.TextBox insertTb;
        private System.Windows.Forms.Button insertBtn;
    }
}

