namespace Sims_XML_Auto_Translator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStrip = new ToolStripMenuItem();
            importToolStrip = new ToolStripMenuItem();
            exportToolStrip = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStrip = new ToolStripMenuItem();
            optionsToolStrip = new ToolStripMenuItem();
            usageToolStrip = new ToolStripMenuItem();
            settingToolStrip = new ToolStripMenuItem();
            helpToolStripMenu = new ToolStripMenuItem();
            updateToolStrip = new ToolStripMenuItem();
            helpToolStrip = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            aboutToolStrip = new ToolStripMenuItem();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            cbSourceLanguage = new ComboBox();
            cbTargetLanguage = new ComboBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(19, 34);
            button1.Name = "button1";
            button1.Size = new Size(102, 32);
            button1.TabIndex = 0;
            button1.Text = "Import XML";
            button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStrip, optionsToolStrip, helpToolStripMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(280, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStrip
            // 
            fileToolStrip.DropDownItems.AddRange(new ToolStripItem[] { importToolStrip, exportToolStrip, toolStripMenuItem1, exitToolStrip });
            fileToolStrip.Name = "fileToolStrip";
            fileToolStrip.Size = new Size(37, 20);
            fileToolStrip.Text = "File";
            // 
            // importToolStrip
            // 
            importToolStrip.Name = "importToolStrip";
            importToolStrip.Size = new Size(180, 22);
            importToolStrip.Text = "Import XML";
            importToolStrip.Click += importToolStrip_Click;
            // 
            // exportToolStrip
            // 
            exportToolStrip.Name = "exportToolStrip";
            exportToolStrip.Size = new Size(180, 22);
            exportToolStrip.Text = "Export XML";
            exportToolStrip.Click += exportToolStrip_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // exitToolStrip
            // 
            exitToolStrip.Name = "exitToolStrip";
            exitToolStrip.Size = new Size(180, 22);
            exitToolStrip.Text = "Exit";
            exitToolStrip.Click += exitToolStrip_Click;
            // 
            // optionsToolStrip
            // 
            optionsToolStrip.DropDownItems.AddRange(new ToolStripItem[] { usageToolStrip, settingToolStrip });
            optionsToolStrip.Name = "optionsToolStrip";
            optionsToolStrip.Size = new Size(61, 20);
            optionsToolStrip.Text = "Options";
            // 
            // usageToolStrip
            // 
            usageToolStrip.Name = "usageToolStrip";
            usageToolStrip.Size = new Size(180, 22);
            usageToolStrip.Text = "Check Usage";
            usageToolStrip.Click += usageToolStrip_Click;
            // 
            // settingToolStrip
            // 
            settingToolStrip.Name = "settingToolStrip";
            settingToolStrip.Size = new Size(180, 22);
            settingToolStrip.Text = "Settings";
            settingToolStrip.Click += settingToolStrip_Click;
            // 
            // helpToolStripMenu
            // 
            helpToolStripMenu.DropDownItems.AddRange(new ToolStripItem[] { updateToolStrip, helpToolStrip, toolStripMenuItem2, aboutToolStrip });
            helpToolStripMenu.Name = "helpToolStripMenu";
            helpToolStripMenu.Size = new Size(44, 20);
            helpToolStripMenu.Text = "Help";
            // 
            // updateToolStrip
            // 
            updateToolStrip.Name = "updateToolStrip";
            updateToolStrip.Size = new Size(166, 22);
            updateToolStrip.Text = "Check for Update";
            updateToolStrip.Click += updateToolStrip_Click;
            // 
            // helpToolStrip
            // 
            helpToolStrip.Name = "helpToolStrip";
            helpToolStrip.Size = new Size(166, 22);
            helpToolStrip.Text = "Help";
            helpToolStrip.Click += helpToolStrip_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(163, 6);
            // 
            // aboutToolStrip
            // 
            aboutToolStrip.Name = "aboutToolStrip";
            aboutToolStrip.Size = new Size(166, 22);
            aboutToolStrip.Text = "About";
            aboutToolStrip.Click += aboutToolStrip_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(159, 34);
            button2.Name = "button2";
            button2.Size = new Size(102, 32);
            button2.TabIndex = 2;
            button2.Text = "Export XML";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 82);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 4;
            label1.Text = "Input Language";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(160, 82);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 5;
            label2.Text = "Output Language";
            // 
            // cbSourceLanguage
            // 
            cbSourceLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSourceLanguage.FormattingEnabled = true;
            cbSourceLanguage.Location = new Point(22, 108);
            cbSourceLanguage.Name = "cbSourceLanguage";
            cbSourceLanguage.Size = new Size(96, 23);
            cbSourceLanguage.TabIndex = 1;
            // 
            // cbTargetLanguage
            // 
            cbTargetLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTargetLanguage.FormattingEnabled = true;
            cbTargetLanguage.Location = new Point(162, 108);
            cbTargetLanguage.Name = "cbTargetLanguage";
            cbTargetLanguage.Size = new Size(96, 23);
            cbTargetLanguage.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 155);
            Controls.Add(cbTargetLanguage);
            Controls.Add(cbSourceLanguage);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Sims XML Auto Translator";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStrip;
        private ToolStripMenuItem importToolStrip;
        private ToolStripMenuItem exportToolStrip;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStrip;
        private ToolStripMenuItem optionsToolStrip;
        private ToolStripMenuItem usageToolStrip;
        private ToolStripMenuItem settingToolStrip;
        private ToolStripMenuItem helpToolStripMenu;
        private ToolStripMenuItem updateToolStrip;
        private ToolStripMenuItem helpToolStrip;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem aboutToolStrip;
        private Button button2;
        private Label label1;
        private Label label2;
        private ComboBox cbSourceLanguage;
        private ComboBox cbTargetLanguage;
    }
}