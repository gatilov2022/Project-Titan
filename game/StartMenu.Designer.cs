namespace game
{
    partial class StartMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::game.Properties.Resources.Menu;
            this.pictureBox1.Location = new System.Drawing.Point(131, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 314);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = global::game.Properties.Resources.exit_no_active;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(165, 420);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(140, 40);
            this.exitButton.TabIndex = 1;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.exitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonsMouseDown);
            this.exitButton.MouseLeave += new System.EventHandler(this.buttonsMouseLeave);
            this.exitButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonsMouseMove);
            // 
            // startButton
            // 
            this.startButton.BackgroundImage = global::game.Properties.Resources.start_no_active;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Location = new System.Drawing.Point(165, 328);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(140, 40);
            this.startButton.TabIndex = 0;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            this.startButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonsMouseDown);
            this.startButton.MouseLeave += new System.EventHandler(this.buttonsMouseLeave);
            this.startButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonsMouseMove);
            // 
            // loadButton
            // 
            this.loadButton.BackgroundImage = global::game.Properties.Resources.Load_No_Move;
            this.loadButton.FlatAppearance.BorderSize = 0;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.ForeColor = System.Drawing.Color.Transparent;
            this.loadButton.Location = new System.Drawing.Point(165, 374);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(140, 40);
            this.loadButton.TabIndex = 4;
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            this.loadButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonsMouseDown);
            this.loadButton.MouseLeave += new System.EventHandler(this.buttonsMouseLeave);
            this.loadButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonsMouseMove);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Выбирите сохранение";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::game.Properties.Resources.fon_menu;
            this.ClientSize = new System.Drawing.Size(454, 461);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}