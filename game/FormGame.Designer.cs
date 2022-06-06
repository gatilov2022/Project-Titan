namespace game
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.factoryButton = new System.Windows.Forms.Button();
            this.gameGoalButton = new System.Windows.Forms.Button();
            this.sandQuarryButton = new System.Windows.Forms.Button();
            this.pumpButton = new System.Windows.Forms.Button();
            this.warehouseButton = new System.Windows.Forms.Button();
            this.steamEngineButton = new System.Windows.Forms.Button();
            this.drillButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // factoryButton
            // 
            this.factoryButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.factoryButton.BackgroundImage = global::game.Properties.Resources.Factory_1lvl;
            this.factoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.factoryButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.factoryButton.FlatAppearance.BorderSize = 2;
            this.factoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.factoryButton.Location = new System.Drawing.Point(238, 413);
            this.factoryButton.Name = "factoryButton";
            this.factoryButton.Size = new System.Drawing.Size(32, 32);
            this.factoryButton.TabIndex = 0;
            this.factoryButton.Text = ".";
            this.toolTip1.SetToolTip(this.factoryButton, "Фабрика 1lvl\r\n");
            this.factoryButton.UseVisualStyleBackColor = true;
            this.factoryButton.Click += new System.EventHandler(this.ButtonMouseClick);
            this.factoryButton.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.factoryButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
            // 
            // gameGoalButton
            // 
            this.gameGoalButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gameGoalButton.BackgroundImage = global::game.Properties.Resources.goal_of_the_game;
            this.gameGoalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gameGoalButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.gameGoalButton.FlatAppearance.BorderSize = 2;
            this.gameGoalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameGoalButton.Location = new System.Drawing.Point(402, 413);
            this.gameGoalButton.Name = "gameGoalButton";
            this.gameGoalButton.Size = new System.Drawing.Size(32, 32);
            this.gameGoalButton.TabIndex = 4;
            this.toolTip1.SetToolTip(this.gameGoalButton, "База");
            this.gameGoalButton.UseVisualStyleBackColor = true;
            this.gameGoalButton.Click += new System.EventHandler(this.ButtonMouseClick);
            this.gameGoalButton.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.gameGoalButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
            // 
            // sandQuarryButton
            // 
            this.sandQuarryButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sandQuarryButton.BackgroundImage = global::game.Properties.Resources.Sand_Quarry;
            this.sandQuarryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sandQuarryButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.sandQuarryButton.FlatAppearance.BorderSize = 2;
            this.sandQuarryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sandQuarryButton.Location = new System.Drawing.Point(345, 413);
            this.sandQuarryButton.Name = "sandQuarryButton";
            this.sandQuarryButton.Size = new System.Drawing.Size(32, 32);
            this.sandQuarryButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.sandQuarryButton, "Жилой дом\r\n");
            this.sandQuarryButton.UseVisualStyleBackColor = true;
            this.sandQuarryButton.Click += new System.EventHandler(this.ButtonMouseClick);
            this.sandQuarryButton.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.sandQuarryButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
            // 
            // pumpButton
            // 
            this.pumpButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pumpButton.BackgroundImage = global::game.Properties.Resources.Pump_1lvl;
            this.pumpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pumpButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.pumpButton.FlatAppearance.BorderSize = 2;
            this.pumpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pumpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pumpButton.Location = new System.Drawing.Point(292, 413);
            this.pumpButton.Name = "pumpButton";
            this.pumpButton.Size = new System.Drawing.Size(32, 32);
            this.pumpButton.TabIndex = 6;
            this.toolTip1.SetToolTip(this.pumpButton, "Помпа 1lvl\r\n");
            this.pumpButton.UseVisualStyleBackColor = true;
            this.pumpButton.Click += new System.EventHandler(this.ButtonMouseClick);
            this.pumpButton.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.pumpButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
            // 
            // warehouseButton
            // 
            this.warehouseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.warehouseButton.BackgroundImage = global::game.Properties.Resources.Warehouse;
            this.warehouseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.warehouseButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.warehouseButton.FlatAppearance.BorderSize = 2;
            this.warehouseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warehouseButton.Location = new System.Drawing.Point(510, 413);
            this.warehouseButton.Name = "warehouseButton";
            this.warehouseButton.Size = new System.Drawing.Size(32, 32);
            this.warehouseButton.TabIndex = 7;
            this.toolTip1.SetToolTip(this.warehouseButton, "Склад");
            this.warehouseButton.UseVisualStyleBackColor = true;
            this.warehouseButton.Click += new System.EventHandler(this.ButtonMouseClick);
            this.warehouseButton.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.warehouseButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
            // 
            // steamEngineButton
            // 
            this.steamEngineButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.steamEngineButton.BackgroundImage = global::game.Properties.Resources.Steam_Eng_1lvl;
            this.steamEngineButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.steamEngineButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.steamEngineButton.FlatAppearance.BorderSize = 2;
            this.steamEngineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.steamEngineButton.Location = new System.Drawing.Point(458, 413);
            this.steamEngineButton.Name = "steamEngineButton";
            this.steamEngineButton.Size = new System.Drawing.Size(32, 32);
            this.steamEngineButton.TabIndex = 8;
            this.toolTip1.SetToolTip(this.steamEngineButton, "Паровой двигатель 1lvl\r\n");
            this.steamEngineButton.UseVisualStyleBackColor = true;
            this.steamEngineButton.Click += new System.EventHandler(this.ButtonMouseClick);
            this.steamEngineButton.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.steamEngineButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
            // 
            // drillButton
            // 
            this.drillButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.drillButton.BackgroundImage = global::game.Properties.Resources.Drill_Burner_1lvl;
            this.drillButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drillButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.drillButton.FlatAppearance.BorderSize = 2;
            this.drillButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drillButton.Location = new System.Drawing.Point(563, 413);
            this.drillButton.Name = "drillButton";
            this.drillButton.Size = new System.Drawing.Size(32, 32);
            this.drillButton.TabIndex = 9;
            this.toolTip1.SetToolTip(this.drillButton, "Дрель 1lvl");
            this.drillButton.UseVisualStyleBackColor = true;
            this.drillButton.Click += new System.EventHandler(this.ButtonMouseClick);
            this.drillButton.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.drillButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
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
            this.timer1.Tick += new System.EventHandler(this.GameLogicTimerTick);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackgroundImage = global::game.Properties.Resources.Button_Save;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(563, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 46);
            this.button2.TabIndex = 11;
            this.toolTip2.SetToolTip(this.button2, "Сохранение");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SaveGameButtonClick);
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipTitle = "Игра";
            // 
            // FormGame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::game.Properties.Resources.fon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(823, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.drillButton);
            this.Controls.Add(this.steamEngineButton);
            this.Controls.Add(this.warehouseButton);
            this.Controls.Add(this.pumpButton);
            this.Controls.Add(this.sandQuarryButton);
            this.Controls.Add(this.gameGoalButton);
            this.Controls.Add(this.factoryButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(839, 489);
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameWindowClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawForm);
            this.DoubleClick += new System.EventHandler(this.GameWindowDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameFieldMouseMoveEvent);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameFieldMouseUpEvent);
            this.Resize += new System.EventHandler(this.GameWindowResized);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip2;
        public System.Windows.Forms.Button factoryButton;
        public System.Windows.Forms.Button gameGoalButton;
        public System.Windows.Forms.Button sandQuarryButton;
        public System.Windows.Forms.Button pumpButton;
        public System.Windows.Forms.Button warehouseButton;
        public System.Windows.Forms.Button steamEngineButton;
        public System.Windows.Forms.Button drillButton;
    }
}

