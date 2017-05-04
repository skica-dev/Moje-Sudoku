namespace MojeSudoku
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sudokuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formularzInteraktywnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zakończPracęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.oMnieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sudokuToolStripMenuItem,
            this.oMnieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sudokuToolStripMenuItem
            // 
            this.sudokuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularzInteraktywnyToolStripMenuItem,
            this.zakończPracęToolStripMenuItem});
            this.sudokuToolStripMenuItem.Name = "sudokuToolStripMenuItem";
            this.sudokuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.sudokuToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.sudokuToolStripMenuItem.Text = "Sudoku";
            // 
            // formularzInteraktywnyToolStripMenuItem
            // 
            this.formularzInteraktywnyToolStripMenuItem.Name = "formularzInteraktywnyToolStripMenuItem";
            this.formularzInteraktywnyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.formularzInteraktywnyToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.formularzInteraktywnyToolStripMenuItem.Text = "Formularz interaktywny";
            this.formularzInteraktywnyToolStripMenuItem.Click += new System.EventHandler(this.formularzInteraktywnyToolStripMenuItem_Click);
            // 
            // zakończPracęToolStripMenuItem
            // 
            this.zakończPracęToolStripMenuItem.Name = "zakończPracęToolStripMenuItem";
            this.zakończPracęToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.zakończPracęToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.zakończPracęToolStripMenuItem.Text = "Zakończ pracę";
            this.zakończPracęToolStripMenuItem.Click += new System.EventHandler(this.zakończPracęToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(609, 423);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // oMnieToolStripMenuItem
            // 
            this.oMnieToolStripMenuItem.Name = "oMnieToolStripMenuItem";
            this.oMnieToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.oMnieToolStripMenuItem.Text = "O mnie";
            this.oMnieToolStripMenuItem.Click += new System.EventHandler(this.oMnieToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 442);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moje Sudoku";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sudokuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formularzInteraktywnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zakończPracęToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem oMnieToolStripMenuItem;
    }
}

