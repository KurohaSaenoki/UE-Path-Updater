namespace UE_Path_Updater
{
    partial class UEPathUpdaterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UEPathUpdaterForm));
            toolStrip1 = new ToolStrip();
            AutomateFilePathBtn = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            UEVersionComboBox = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            InputBtnSplit = new ToolStripSplitButton();
            SetInputBtn = new ToolStripMenuItem();
            ReloadInputBtn = new ToolStripMenuItem();
            OutputBtn = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            AutoDetectUEBtn = new ToolStripButton();
            AllAssetCountLabel = new Label();
            OutputTextBox = new TextBox();
            FindLabel = new Label();
            ReplaceLabel = new Label();
            FindTextBox = new TextBox();
            ReplaceTextBox = new TextBox();
            GameTextBox = new TextBox();
            UpdateBtn = new Button();
            ProgressBar = new ProgressBar();
            ProgressLabel = new Label();
            DarkModeCheckBox = new CheckBox();
            ClearBtn = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { AutomateFilePathBtn, toolStripSeparator2, UEVersionComboBox, toolStripSeparator1, InputBtnSplit, OutputBtn, toolStripSeparator3, AutoDetectUEBtn });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // AutomateFilePathBtn
            // 
            AutomateFilePathBtn.Alignment = ToolStripItemAlignment.Right;
            AutomateFilePathBtn.CheckOnClick = true;
            AutomateFilePathBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AutomateFilePathBtn.Image = (Image)resources.GetObject("AutomateFilePathBtn.Image");
            AutomateFilePathBtn.ImageTransparentColor = Color.Magenta;
            AutomateFilePathBtn.Name = "AutomateFilePathBtn";
            AutomateFilePathBtn.Size = new Size(117, 22);
            AutomateFilePathBtn.Text = "Automate File Paths";
            AutomateFilePathBtn.CheckStateChanged += AutomateFilePathBtn_CheckStateChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // UEVersionComboBox
            // 
            UEVersionComboBox.Alignment = ToolStripItemAlignment.Right;
            UEVersionComboBox.DropDownHeight = 100;
            UEVersionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            UEVersionComboBox.DropDownWidth = 300;
            UEVersionComboBox.IntegralHeight = false;
            UEVersionComboBox.Items.AddRange(new object[] { "4 (Oldest)", "4.0", "4.1", "4.2", "4.3", "4.4", "4.5", "4.6", "4.7", "4.8", "4.9", "4.10", "4.11", "4.12", "4.13", "4.14", "4.15", "4.16", "4.17", "4.18", "4.19", "4.20", "4.21", "4.22", "4.23", "4.24", "4.25", "4.26", "4.27", "5.0", "5.0 (Early Access)", "5.1", "5.2", "5.3", "5.4", "5.5", "5.6", "5.7", "5.8" });
            UEVersionComboBox.Name = "UEVersionComboBox";
            UEVersionComboBox.Size = new Size(80, 25);
            UEVersionComboBox.SelectedIndexChanged += UEVersionComboBox_SelectedIndexChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // InputBtnSplit
            // 
            InputBtnSplit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            InputBtnSplit.DropDownItems.AddRange(new ToolStripItem[] { SetInputBtn, ReloadInputBtn });
            InputBtnSplit.Image = (Image)resources.GetObject("InputBtnSplit.Image");
            InputBtnSplit.ImageTransparentColor = Color.Magenta;
            InputBtnSplit.Name = "InputBtnSplit";
            InputBtnSplit.Size = new Size(106, 22);
            InputBtnSplit.Text = "Set Input Folder";
            InputBtnSplit.ButtonClick += SetInputBtn_Click;
            // 
            // SetInputBtn
            // 
            SetInputBtn.Name = "SetInputBtn";
            SetInputBtn.Size = new Size(180, 22);
            SetInputBtn.Text = "Set Input Folder";
            SetInputBtn.Click += SetInputBtn_Click;
            // 
            // ReloadInputBtn
            // 
            ReloadInputBtn.Enabled = false;
            ReloadInputBtn.Name = "ReloadInputBtn";
            ReloadInputBtn.Size = new Size(180, 22);
            ReloadInputBtn.Text = "Reload Input Folder";
            ReloadInputBtn.Click += ReloadInputBtn_Click;
            // 
            // OutputBtn
            // 
            OutputBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            OutputBtn.Image = (Image)resources.GetObject("OutputBtn.Image");
            OutputBtn.ImageTransparentColor = Color.Magenta;
            OutputBtn.Name = "OutputBtn";
            OutputBtn.Size = new Size(104, 22);
            OutputBtn.Text = "Set Output Folder";
            OutputBtn.Click += OutputBtn_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // AutoDetectUEBtn
            // 
            AutoDetectUEBtn.Alignment = ToolStripItemAlignment.Right;
            AutoDetectUEBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AutoDetectUEBtn.Enabled = false;
            AutoDetectUEBtn.Image = (Image)resources.GetObject("AutoDetectUEBtn.Image");
            AutoDetectUEBtn.ImageTransparentColor = Color.Magenta;
            AutoDetectUEBtn.Name = "AutoDetectUEBtn";
            AutoDetectUEBtn.Size = new Size(134, 22);
            AutoDetectUEBtn.Text = "Auto-Detect UE Version";
            AutoDetectUEBtn.Click += AutoDetectUEBtn_Click;
            // 
            // AllAssetCountLabel
            // 
            AllAssetCountLabel.AutoSize = true;
            AllAssetCountLabel.Location = new Point(24, 35);
            AllAssetCountLabel.Name = "AllAssetCountLabel";
            AllAssetCountLabel.Size = new Size(83, 15);
            AllAssetCountLabel.TabIndex = 12;
            AllAssetCountLabel.Text = "Asset Count: 0";
            // 
            // OutputTextBox
            // 
            OutputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OutputTextBox.Location = new Point(24, 108);
            OutputTextBox.Multiline = true;
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ReadOnly = true;
            OutputTextBox.ScrollBars = ScrollBars.Both;
            OutputTextBox.Size = new Size(764, 292);
            OutputTextBox.TabIndex = 8;
            // 
            // FindLabel
            // 
            FindLabel.AutoSize = true;
            FindLabel.Location = new Point(24, 61);
            FindLabel.Name = "FindLabel";
            FindLabel.Size = new Size(60, 15);
            FindLabel.TabIndex = 11;
            FindLabel.Text = "Find Path:";
            // 
            // ReplaceLabel
            // 
            ReplaceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ReplaceLabel.AutoSize = true;
            ReplaceLabel.Location = new Point(417, 61);
            ReplaceLabel.Name = "ReplaceLabel";
            ReplaceLabel.Size = new Size(78, 15);
            ReplaceLabel.TabIndex = 10;
            ReplaceLabel.Text = "Replace Path:";
            // 
            // FindTextBox
            // 
            FindTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FindTextBox.Enabled = false;
            FindTextBox.Location = new Point(24, 79);
            FindTextBox.Name = "FindTextBox";
            FindTextBox.Size = new Size(350, 23);
            FindTextBox.TabIndex = 6;
            FindTextBox.EnabledChanged += FindTextBox_EnabledChanged;
            FindTextBox.TextChanged += FindTextBox_TextChanged;
            FindTextBox.Enter += FindTextBox_Enter;
            FindTextBox.Leave += FindTextBox_Leave;
            // 
            // ReplaceTextBox
            // 
            ReplaceTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ReplaceTextBox.Enabled = false;
            ReplaceTextBox.Location = new Point(417, 79);
            ReplaceTextBox.Name = "ReplaceTextBox";
            ReplaceTextBox.Size = new Size(350, 23);
            ReplaceTextBox.TabIndex = 7;
            ReplaceTextBox.Enter += ReplaceTextBox_Enter;
            ReplaceTextBox.Leave += ReplaceTextBox_Leave;
            // 
            // GameTextBox
            // 
            GameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GameTextBox.Enabled = false;
            GameTextBox.Location = new Point(682, 35);
            GameTextBox.Name = "GameTextBox";
            GameTextBox.PlaceholderText = "{Game}";
            GameTextBox.Size = new Size(106, 23);
            GameTextBox.TabIndex = 5;
            GameTextBox.TextAlign = HorizontalAlignment.Center;
            GameTextBox.Enter += GameTextBox_Enter;
            GameTextBox.Leave += GameTextBox_Leave;
            // 
            // UpdateBtn
            // 
            UpdateBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            UpdateBtn.Enabled = false;
            UpdateBtn.ForeColor = SystemColors.ControlText;
            UpdateBtn.Location = new Point(642, 406);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.Size = new Size(130, 32);
            UpdateBtn.TabIndex = 9;
            UpdateBtn.Text = "Update Assets";
            UpdateBtn.UseVisualStyleBackColor = true;
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // ProgressBar
            // 
            ProgressBar.Anchor = AnchorStyles.Bottom;
            ProgressBar.Location = new Point(278, 406);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(228, 23);
            ProgressBar.Step = 1;
            ProgressBar.TabIndex = 13;
            ProgressBar.Visible = false;
            // 
            // ProgressLabel
            // 
            ProgressLabel.Anchor = AnchorStyles.Bottom;
            ProgressLabel.AutoSize = true;
            ProgressLabel.Location = new Point(512, 414);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(24, 15);
            ProgressLabel.TabIndex = 14;
            ProgressLabel.Text = "0/0";
            ProgressLabel.Visible = false;
            // 
            // DarkModeCheckBox
            // 
            DarkModeCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DarkModeCheckBox.AutoSize = true;
            DarkModeCheckBox.Location = new Point(785, 433);
            DarkModeCheckBox.Name = "DarkModeCheckBox";
            DarkModeCheckBox.Size = new Size(15, 14);
            DarkModeCheckBox.TabIndex = 15;
            DarkModeCheckBox.TabStop = false;
            DarkModeCheckBox.UseVisualStyleBackColor = true;
            DarkModeCheckBox.CheckedChanged += DarkModeCheckBox_CheckedChanged;
            // 
            // ClearBtn
            // 
            ClearBtn.Location = new Point(24, 405);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(130, 32);
            ClearBtn.TabIndex = 16;
            ClearBtn.Text = "Clear Output Log";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // UEPathUpdaterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(ClearBtn);
            Controls.Add(DarkModeCheckBox);
            Controls.Add(ProgressLabel);
            Controls.Add(ProgressBar);
            Controls.Add(UpdateBtn);
            Controls.Add(GameTextBox);
            Controls.Add(ReplaceTextBox);
            Controls.Add(FindTextBox);
            Controls.Add(ReplaceLabel);
            Controls.Add(FindLabel);
            Controls.Add(OutputTextBox);
            Controls.Add(AllAssetCountLabel);
            Controls.Add(toolStrip1);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 220);
            Name = "UEPathUpdaterForm";
            Text = "Unreal Engine Path Updater";
            FormClosing += UEPathUpdaterForm_FormClosing;
            Load += UEPathUpdaterForm_Load;
            Resize += UEPathUpdaterForm_Resize;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton AutomateFilePathBtn;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripComboBox UEVersionComboBox;
        private Label AllAssetCountLabel;
        private TextBox OutputTextBox;
        private Label FindLabel;
        private Label ReplaceLabel;
        private TextBox FindTextBox;
        private TextBox ReplaceTextBox;
        private TextBox GameTextBox;
        private Button UpdateBtn;
        private ToolStripButton InputBtn;
        private ToolStripButton OutputBtn;
        private ProgressBar ProgressBar;
        private Label ProgressLabel;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton AutoDetectUEBtn;
        private CheckBox DarkModeCheckBox;
        private Button ClearBtn;
        private ToolStripSplitButton InputBtnSplit;
        private ToolStripMenuItem SetInputBtn;
        private ToolStripMenuItem ReloadInputBtn;
    }
}