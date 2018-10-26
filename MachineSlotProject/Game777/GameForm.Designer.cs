namespace Game777
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.tFirstSlot = new System.Windows.Forms.Timer(this.components);
            this.tSecondSlot = new System.Windows.Forms.Timer(this.components);
            this.tThridSlot = new System.Windows.Forms.Timer(this.components);
            this.tResult = new System.Windows.Forms.Timer(this.components);
            this.bwResultCalc = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddMoney = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRule = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbFirstSlot = new System.Windows.Forms.PictureBox();
            this.cbThirdSlot = new System.Windows.Forms.CheckBox();
            this.pbSecondSlot = new System.Windows.Forms.PictureBox();
            this.cbSecondSlot = new System.Windows.Forms.CheckBox();
            this.pbThirdSlot = new System.Windows.Forms.PictureBox();
            this.cbFirstSlot = new System.Windows.Forms.CheckBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecondSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThirdSlot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Pink;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlay.ForeColor = System.Drawing.Color.Crimson;
            this.btnPlay.Location = new System.Drawing.Point(6, 222);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(288, 40);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Играть";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblBalance.ForeColor = System.Drawing.Color.Crimson;
            this.lblBalance.Location = new System.Drawing.Point(70, 40);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(46, 13);
            this.lblBalance.TabIndex = 3;
            this.lblBalance.Text = "Balance";
            // 
            // tFirstSlot
            // 
            this.tFirstSlot.Tick += new System.EventHandler(this.TimerEventProcessor);
            // 
            // tSecondSlot
            // 
            this.tSecondSlot.Tick += new System.EventHandler(this.TimerEventProcessor);
            // 
            // tThridSlot
            // 
            this.tThridSlot.Tick += new System.EventHandler(this.TimerEventProcessor);
            // 
            // tResult
            // 
            this.tResult.Tick += new System.EventHandler(this.ResultEventProcessor);
            // 
            // bwResultCalc
            // 
            this.bwResultCalc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwResultCalc_DoWork);
            this.bwResultCalc.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwResultCalc_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(309, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddMoney,
            this.menuRule});
            this.Menu.ForeColor = System.Drawing.Color.Crimson;
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(53, 20);
            this.Menu.Text = "Меню";
            // 
            // menuAddMoney
            // 
            this.menuAddMoney.ForeColor = System.Drawing.Color.Crimson;
            this.menuAddMoney.Name = "menuAddMoney";
            this.menuAddMoney.Size = new System.Drawing.Size(178, 22);
            this.menuAddMoney.Text = "Пополнить баланс";
            this.menuAddMoney.Click += new System.EventHandler(this.menuAddMoney_Click);
            // 
            // menuRule
            // 
            this.menuRule.ForeColor = System.Drawing.Color.Crimson;
            this.menuRule.Name = "menuRule";
            this.menuRule.Size = new System.Drawing.Size(178, 22);
            this.menuRule.Text = "Правила";
            this.menuRule.Click += new System.EventHandler(this.menuRule_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.btnPlay);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtResult);
            this.groupBox2.Location = new System.Drawing.Point(3, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 377);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = global::Game777.Properties.Resources.SlotMachinaImage;
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Controls.Add(this.lblBalance);
            this.groupBox3.Controls.Add(this.pbFirstSlot);
            this.groupBox3.Controls.Add(this.lblRate);
            this.groupBox3.Controls.Add(this.cbThirdSlot);
            this.groupBox3.Controls.Add(this.pbSecondSlot);
            this.groupBox3.Controls.Add(this.cbSecondSlot);
            this.groupBox3.Controls.Add(this.pbThirdSlot);
            this.groupBox3.Controls.Add(this.cbFirstSlot);
            this.groupBox3.Location = new System.Drawing.Point(6, 10);
            this.groupBox3.MaximumSize = new System.Drawing.Size(288, 206);
            this.groupBox3.MinimumSize = new System.Drawing.Size(288, 206);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 206);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // pbFirstSlot
            // 
            this.pbFirstSlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbFirstSlot.Image = ((System.Drawing.Image)(resources.GetObject("pbFirstSlot.Image")));
            this.pbFirstSlot.InitialImage = null;
            this.pbFirstSlot.Location = new System.Drawing.Point(38, 58);
            this.pbFirstSlot.Name = "pbFirstSlot";
            this.pbFirstSlot.Size = new System.Drawing.Size(59, 68);
            this.pbFirstSlot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFirstSlot.TabIndex = 5;
            this.pbFirstSlot.TabStop = false;
            // 
            // cbThirdSlot
            // 
            this.cbThirdSlot.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbThirdSlot.BackgroundImage = global::Game777.Properties.Resources.glossy_green_icon_button_hi;
            this.cbThirdSlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbThirdSlot.Checked = true;
            this.cbThirdSlot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbThirdSlot.Location = new System.Drawing.Point(168, 132);
            this.cbThirdSlot.Name = "cbThirdSlot";
            this.cbThirdSlot.Size = new System.Drawing.Size(57, 14);
            this.cbThirdSlot.TabIndex = 11;
            this.cbThirdSlot.UseVisualStyleBackColor = true;
            this.cbThirdSlot.CheckedChanged += new System.EventHandler(this.cbThird_CheckedChanged);
            // 
            // pbSecondSlot
            // 
            this.pbSecondSlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbSecondSlot.Image = ((System.Drawing.Image)(resources.GetObject("pbSecondSlot.Image")));
            this.pbSecondSlot.InitialImage = null;
            this.pbSecondSlot.Location = new System.Drawing.Point(103, 58);
            this.pbSecondSlot.Name = "pbSecondSlot";
            this.pbSecondSlot.Size = new System.Drawing.Size(59, 68);
            this.pbSecondSlot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSecondSlot.TabIndex = 6;
            this.pbSecondSlot.TabStop = false;
            // 
            // cbSecondSlot
            // 
            this.cbSecondSlot.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbSecondSlot.BackgroundImage = global::Game777.Properties.Resources.glossy_green_icon_button_hi;
            this.cbSecondSlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbSecondSlot.Checked = true;
            this.cbSecondSlot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSecondSlot.Location = new System.Drawing.Point(103, 132);
            this.cbSecondSlot.Name = "cbSecondSlot";
            this.cbSecondSlot.Size = new System.Drawing.Size(59, 14);
            this.cbSecondSlot.TabIndex = 12;
            this.cbSecondSlot.UseVisualStyleBackColor = true;
            this.cbSecondSlot.CheckedChanged += new System.EventHandler(this.cbSecondSlot_CheckedChanged);
            // 
            // pbThirdSlot
            // 
            this.pbThirdSlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbThirdSlot.Image = ((System.Drawing.Image)(resources.GetObject("pbThirdSlot.Image")));
            this.pbThirdSlot.InitialImage = null;
            this.pbThirdSlot.Location = new System.Drawing.Point(166, 58);
            this.pbThirdSlot.Name = "pbThirdSlot";
            this.pbThirdSlot.Size = new System.Drawing.Size(59, 68);
            this.pbThirdSlot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThirdSlot.TabIndex = 7;
            this.pbThirdSlot.TabStop = false;
            // 
            // cbFirstSlot
            // 
            this.cbFirstSlot.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbFirstSlot.BackgroundImage = global::Game777.Properties.Resources.glossy_green_icon_button_hi;
            this.cbFirstSlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbFirstSlot.Checked = true;
            this.cbFirstSlot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFirstSlot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbFirstSlot.Location = new System.Drawing.Point(38, 132);
            this.cbFirstSlot.Name = "cbFirstSlot";
            this.cbFirstSlot.Size = new System.Drawing.Size(59, 14);
            this.cbFirstSlot.TabIndex = 10;
            this.cbFirstSlot.UseVisualStyleBackColor = true;
            this.cbFirstSlot.CheckedChanged += new System.EventHandler(this.cbFirstSlot_CheckedChanged);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResult.BackColor = System.Drawing.Color.Linen;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResult.Location = new System.Drawing.Point(6, 268);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(288, 100);
            this.txtResult.TabIndex = 8;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.BackColor = System.Drawing.Color.Transparent;
            this.lblRate.ForeColor = System.Drawing.Color.Crimson;
            this.lblRate.Location = new System.Drawing.Point(37, 149);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(30, 13);
            this.lblRate.TabIndex = 9;
            this.lblRate.Text = "Rate";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(309, 409);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(325, 500);
            this.MinimumSize = new System.Drawing.Size(325, 448);
            this.Name = "GameForm";
            this.Text = "Game";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecondSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThirdSlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Timer tFirstSlot;
        private System.Windows.Forms.Timer tSecondSlot;
        private System.Windows.Forms.Timer tThridSlot;
        private System.Windows.Forms.Timer tResult;
        private System.Windows.Forms.PictureBox pbFirstSlot;
        private System.Windows.Forms.PictureBox pbSecondSlot;
        private System.Windows.Forms.PictureBox pbThirdSlot;
        private System.ComponentModel.BackgroundWorker bwResultCalc;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem menuAddMoney;
        private System.Windows.Forms.ToolStripMenuItem menuRule;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.CheckBox cbSecondSlot;
        private System.Windows.Forms.CheckBox cbThirdSlot;
        private System.Windows.Forms.CheckBox cbFirstSlot;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

