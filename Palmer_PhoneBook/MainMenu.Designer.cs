
namespace Palmer_PhoneBook
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.dataEntryMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.contactSubBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.reportMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.reportSubBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.SteelBlue;
            this.mainMenuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuBtn,
            this.dataEntryMenuBtn,
            this.reportMenuBtn,
            this.helpMenuBtn});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(816, 26);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenuBtn
            // 
            this.fileMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuBtn});
            this.fileMenuBtn.Image = ((System.Drawing.Image)(resources.GetObject("fileMenuBtn.Image")));
            this.fileMenuBtn.Name = "fileMenuBtn";
            this.fileMenuBtn.Size = new System.Drawing.Size(59, 22);
            this.fileMenuBtn.Text = "File";
            // 
            // exitMenuBtn
            // 
            this.exitMenuBtn.AutoToolTip = true;
            this.exitMenuBtn.Name = "exitMenuBtn";
            this.exitMenuBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.exitMenuBtn.Size = new System.Drawing.Size(143, 22);
            this.exitMenuBtn.Text = "Exit";
            this.exitMenuBtn.ToolTipText = "Exit application";
            this.exitMenuBtn.Click += new System.EventHandler(this.exitMenuBtn_Click);
            // 
            // dataEntryMenuBtn
            // 
            this.dataEntryMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactSubBtn});
            this.dataEntryMenuBtn.Image = ((System.Drawing.Image)(resources.GetObject("dataEntryMenuBtn.Image")));
            this.dataEntryMenuBtn.Name = "dataEntryMenuBtn";
            this.dataEntryMenuBtn.Size = new System.Drawing.Size(105, 22);
            this.dataEntryMenuBtn.Text = "Data Entry";
            // 
            // contactSubBtn
            // 
            this.contactSubBtn.AutoToolTip = true;
            this.contactSubBtn.Name = "contactSubBtn";
            this.contactSubBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.contactSubBtn.Size = new System.Drawing.Size(172, 22);
            this.contactSubBtn.Text = "Contact";
            this.contactSubBtn.ToolTipText = "Displays contact data entry form";
            this.contactSubBtn.Click += new System.EventHandler(this.contactSubBtn_Click);
            // 
            // reportMenuBtn
            // 
            this.reportMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportSubBtn});
            this.reportMenuBtn.Image = ((System.Drawing.Image)(resources.GetObject("reportMenuBtn.Image")));
            this.reportMenuBtn.Name = "reportMenuBtn";
            this.reportMenuBtn.Size = new System.Drawing.Size(89, 22);
            this.reportMenuBtn.Text = "Reports";
            // 
            // reportSubBtn
            // 
            this.reportSubBtn.AutoToolTip = true;
            this.reportSubBtn.Name = "reportSubBtn";
            this.reportSubBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.reportSubBtn.Size = new System.Drawing.Size(248, 22);
            this.reportSubBtn.Text = "Contact List Report";
            this.reportSubBtn.ToolTipText = "Displays Contact List Report";
            this.reportSubBtn.Click += new System.EventHandler(this.reportSubBtn_Click);
            // 
            // helpMenuBtn
            // 
            this.helpMenuBtn.Image = ((System.Drawing.Image)(resources.GetObject("helpMenuBtn.Image")));
            this.helpMenuBtn.Name = "helpMenuBtn";
            this.helpMenuBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.helpMenuBtn.Size = new System.Drawing.Size(66, 22);
            this.helpMenuBtn.Text = "Help";
            this.helpMenuBtn.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(101, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(614, 347);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(816, 437);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telephone Contact Main Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem exitMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem dataEntryMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem reportMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem helpMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem contactSubBtn;
        private System.Windows.Forms.ToolStripMenuItem reportSubBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

