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
            this.factory_but = new System.Windows.Forms.Button();
            this.base_but = new System.Windows.Forms.Button();
            this.house_but = new System.Windows.Forms.Button();
            this.pump_but = new System.Windows.Forms.Button();
            this.wareh_but = new System.Windows.Forms.Button();
            this.steam_but = new System.Windows.Forms.Button();
            this.drill_but = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // factory_but
            // 
            this.factory_but.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.factory_but.BackgroundImage = global::game.Properties.Resources.Factory_1lvl;
            this.factory_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.factory_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.factory_but.FlatAppearance.BorderSize = 2;
            this.factory_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.factory_but.Location = new System.Drawing.Point(238, 413);
            this.factory_but.Name = "factory_but";
            this.factory_but.Size = new System.Drawing.Size(32, 32);
            this.factory_but.TabIndex = 0;
            this.factory_but.Text = ".";
            this.toolTip1.SetToolTip(this.factory_but, "Фабрика 1lvl\r\n");
            this.factory_but.UseVisualStyleBackColor = true;
            this.factory_but.Click += new System.EventHandler(this.but_MouseClick);
            this.factory_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.factory_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // base_but
            // 
            this.base_but.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.base_but.BackgroundImage = global::game.Properties.Resources.goal_of_the_game;
            this.base_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.base_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.base_but.FlatAppearance.BorderSize = 2;
            this.base_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.base_but.Location = new System.Drawing.Point(402, 413);
            this.base_but.Name = "base_but";
            this.base_but.Size = new System.Drawing.Size(32, 32);
            this.base_but.TabIndex = 4;
            this.toolTip1.SetToolTip(this.base_but, "База");
            this.base_but.UseVisualStyleBackColor = true;
            this.base_but.Click += new System.EventHandler(this.but_MouseClick);
            this.base_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.base_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // house_but
            // 
            this.house_but.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.house_but.BackgroundImage = global::game.Properties.Resources.Sand_Quarry;
            this.house_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.house_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.house_but.FlatAppearance.BorderSize = 2;
            this.house_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.house_but.Location = new System.Drawing.Point(345, 413);
            this.house_but.Name = "house_but";
            this.house_but.Size = new System.Drawing.Size(32, 32);
            this.house_but.TabIndex = 5;
            this.toolTip1.SetToolTip(this.house_but, "Жилой дом\r\n");
            this.house_but.UseVisualStyleBackColor = true;
            this.house_but.Click += new System.EventHandler(this.but_MouseClick);
            this.house_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.house_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // pump_but
            // 
            this.pump_but.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pump_but.BackgroundImage = global::game.Properties.Resources.Pump_1lvl;
            this.pump_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pump_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.pump_but.FlatAppearance.BorderSize = 2;
            this.pump_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pump_but.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pump_but.Location = new System.Drawing.Point(292, 413);
            this.pump_but.Name = "pump_but";
            this.pump_but.Size = new System.Drawing.Size(32, 32);
            this.pump_but.TabIndex = 6;
            this.toolTip1.SetToolTip(this.pump_but, "Помпа 1lvl\r\n");
            this.pump_but.UseVisualStyleBackColor = true;
            this.pump_but.Click += new System.EventHandler(this.but_MouseClick);
            this.pump_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.pump_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // wareh_but
            // 
            this.wareh_but.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.wareh_but.BackgroundImage = global::game.Properties.Resources.Warehouse;
            this.wareh_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wareh_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.wareh_but.FlatAppearance.BorderSize = 2;
            this.wareh_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wareh_but.Location = new System.Drawing.Point(510, 413);
            this.wareh_but.Name = "wareh_but";
            this.wareh_but.Size = new System.Drawing.Size(32, 32);
            this.wareh_but.TabIndex = 7;
            this.toolTip1.SetToolTip(this.wareh_but, "Склад");
            this.wareh_but.UseVisualStyleBackColor = true;
            this.wareh_but.Click += new System.EventHandler(this.but_MouseClick);
            this.wareh_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.wareh_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // steam_but
            // 
            this.steam_but.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.steam_but.BackgroundImage = global::game.Properties.Resources.Steam_Eng_1lvl;
            this.steam_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.steam_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.steam_but.FlatAppearance.BorderSize = 2;
            this.steam_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.steam_but.Location = new System.Drawing.Point(458, 413);
            this.steam_but.Name = "steam_but";
            this.steam_but.Size = new System.Drawing.Size(32, 32);
            this.steam_but.TabIndex = 8;
            this.toolTip1.SetToolTip(this.steam_but, "Паровой двигатель 1lvl\r\n");
            this.steam_but.UseVisualStyleBackColor = true;
            this.steam_but.Click += new System.EventHandler(this.but_MouseClick);
            this.steam_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.steam_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // drill_but
            // 
            this.drill_but.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.drill_but.BackgroundImage = global::game.Properties.Resources.Drill_Burner_1lvl;
            this.drill_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drill_but.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.drill_but.FlatAppearance.BorderSize = 2;
            this.drill_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drill_but.Location = new System.Drawing.Point(563, 413);
            this.drill_but.Name = "drill_but";
            this.drill_but.Size = new System.Drawing.Size(32, 32);
            this.drill_but.TabIndex = 9;
            this.toolTip1.SetToolTip(this.drill_but, "Дрель 1lvl");
            this.drill_but.UseVisualStyleBackColor = true;
            this.drill_but.Click += new System.EventHandler(this.but_MouseClick);
            this.drill_but.MouseLeave += new System.EventHandler(this.but_MouseLeave);
            this.drill_but.MouseMove += new System.Windows.Forms.MouseEventHandler(this.but_MouseMove);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 50;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Здание";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(540, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 163);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::game.Properties.Resources.fon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(823, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.drill_but);
            this.Controls.Add(this.steam_but);
            this.Controls.Add(this.wareh_but);
            this.Controls.Add(this.pump_but);
            this.Controls.Add(this.house_but);
            this.Controls.Add(this.base_but);
            this.Controls.Add(this.factory_but);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(839, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint_vis);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button factory_but;
        private System.Windows.Forms.Button base_but;
        private System.Windows.Forms.Button house_but;
        private System.Windows.Forms.Button pump_but;
        private System.Windows.Forms.Button wareh_but;
        private System.Windows.Forms.Button steam_but;
        private System.Windows.Forms.Button drill_but;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

