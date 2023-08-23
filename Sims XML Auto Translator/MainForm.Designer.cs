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
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importXMLToolStripMenuItem = new ToolStripMenuItem();
            exportXMLToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            checkUsageToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            checkForUpdateToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(280, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importXMLToolStripMenuItem, exportXMLToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // importXMLToolStripMenuItem
            // 
            importXMLToolStripMenuItem.Name = "importXMLToolStripMenuItem";
            importXMLToolStripMenuItem.Size = new Size(180, 22);
            importXMLToolStripMenuItem.Text = "Import XML";
            // 
            // exportXMLToolStripMenuItem
            // 
            exportXMLToolStripMenuItem.Name = "exportXMLToolStripMenuItem";
            exportXMLToolStripMenuItem.Size = new Size(180, 22);
            exportXMLToolStripMenuItem.Text = "Export XML";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { checkUsageToolStripMenuItem, settingsToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // checkUsageToolStripMenuItem
            // 
            checkUsageToolStripMenuItem.Name = "checkUsageToolStripMenuItem";
            checkUsageToolStripMenuItem.Size = new Size(180, 22);
            checkUsageToolStripMenuItem.Text = "Check Usage";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(180, 22);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { checkForUpdateToolStripMenuItem, helpToolStripMenuItem1, toolStripMenuItem2, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // checkForUpdateToolStripMenuItem
            // 
            checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            checkForUpdateToolStripMenuItem.Size = new Size(180, 22);
            checkForUpdateToolStripMenuItem.Text = "Check for Update";
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(180, 22);
            helpToolStripMenuItem1.Text = "Help";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(177, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(180, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
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
            // Form1
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
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importXMLToolStripMenuItem;
        private ToolStripMenuItem exportXMLToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem checkUsageToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button button2;
        private Label label1;
        private Label label2;
        private ComboBox cbSourceLanguage;
        private ComboBox cbTargetLanguage;
    }
}