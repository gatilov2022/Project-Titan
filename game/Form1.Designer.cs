namespace game
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.factory_but = new System.Windows.Forms.Button();
            this.base_but = new System.Windows.Forms.Button();
            this.house_but = new System.Windows.Forms.Button();
            this.pump_but = new System.Windows.Forms.Button();
            this.wareh_but = new System.Windows.Forms.Button();
            this.steam_but = new System.Windows.Forms.Button();
            this.drill_but = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // factory_but
            // 
            this.factory_but.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("factory_but.BackgroundImage")));
            this.factory_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.factory_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.factory_but.FlatAppearance.BorderSize = 2;
            this.factory_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.factory_but.Location = new System.Drawing.Point(657, 41);
            this.factory_but.Name = "factory_but";
            this.factory_but.Size = new System.Drawing.Size(32, 32);
            this.factory_but.TabIndex = 0;
            this.factory_but.UseVisualStyleBackColor = true;
            this.factory_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.factory_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // base_but
            // 
            this.base_but.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("base_but.BackgroundImage")));
            this.base_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.base_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.base_but.FlatAppearance.BorderSize = 2;
            this.base_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.base_but.Location = new System.Drawing.Point(657, 93);
            this.base_but.Name = "base_but";
            this.base_but.Size = new System.Drawing.Size(32, 32);
            this.base_but.TabIndex = 4;
            this.base_but.UseVisualStyleBackColor = true;
            this.base_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.base_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // house_but
            // 
            this.house_but.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("house_but.BackgroundImage")));
            this.house_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.house_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.house_but.FlatAppearance.BorderSize = 2;
            this.house_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.house_but.Location = new System.Drawing.Point(657, 147);
            this.house_but.Name = "house_but";
            this.house_but.Size = new System.Drawing.Size(32, 32);
            this.house_but.TabIndex = 5;
            this.house_but.UseVisualStyleBackColor = true;
            this.house_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.house_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // pump_but
            // 
            this.pump_but.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pump_but.BackgroundImage")));
            this.pump_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pump_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.pump_but.FlatAppearance.BorderSize = 2;
            this.pump_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pump_but.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pump_but.Location = new System.Drawing.Point(709, 41);
            this.pump_but.Name = "pump_but";
            this.pump_but.Size = new System.Drawing.Size(32, 32);
            this.pump_but.TabIndex = 6;
            this.pump_but.UseVisualStyleBackColor = true;
            this.pump_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.pump_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // wareh_but
            // 
            this.wareh_but.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("wareh_but.BackgroundImage")));
            this.wareh_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wareh_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.wareh_but.FlatAppearance.BorderSize = 2;
            this.wareh_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wareh_but.Location = new System.Drawing.Point(709, 93);
            this.wareh_but.Name = "wareh_but";
            this.wareh_but.Size = new System.Drawing.Size(32, 32);
            this.wareh_but.TabIndex = 7;
            this.wareh_but.UseVisualStyleBackColor = true;
            this.wareh_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.wareh_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // steam_but
            // 
            this.steam_but.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("steam_but.BackgroundImage")));
            this.steam_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.steam_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.steam_but.FlatAppearance.BorderSize = 2;
            this.steam_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.steam_but.Location = new System.Drawing.Point(709, 147);
            this.steam_but.Name = "steam_but";
            this.steam_but.Size = new System.Drawing.Size(32, 32);
            this.steam_but.TabIndex = 8;
            this.steam_but.UseVisualStyleBackColor = true;
            this.steam_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.steam_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // drill_but
            // 
            this.drill_but.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("drill_but.BackgroundImage")));
            this.drill_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drill_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.drill_but.FlatAppearance.BorderSize = 2;
            this.drill_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drill_but.Location = new System.Drawing.Point(756, 41);
            this.drill_but.Name = "drill_but";
            this.drill_but.Size = new System.Drawing.Size(32, 32);
            this.drill_but.TabIndex = 9;
            this.drill_but.UseVisualStyleBackColor = true;
            this.drill_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.drill_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.drill_but);
            this.Controls.Add(this.steam_but);
            this.Controls.Add(this.wareh_but);
            this.Controls.Add(this.pump_but);
            this.Controls.Add(this.house_but);
            this.Controls.Add(this.base_but);
            this.Controls.Add(this.factory_but);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint_vis);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button factory_but;
        private System.Windows.Forms.Button base_but;
        private System.Windows.Forms.Button house_but;
        private System.Windows.Forms.Button pump_but;
        private System.Windows.Forms.Button wareh_but;
        private System.Windows.Forms.Button steam_but;
        private System.Windows.Forms.Button drill_but;
    }
}

