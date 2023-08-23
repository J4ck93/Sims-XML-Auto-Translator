namespace Sims_XML_Auto_Translator
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            label1 = new Label();
            tbApiKey = new TextBox();
            cbRemSourceLanguage = new CheckBox();
            cbRemTargetLanguage = new CheckBox();
            cbAuto = new CheckBox();
            cbLineByLine = new CheckBox();
            cBoxSourceLanguage = new ComboBox();
            cBoxTargetLanguage = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "API Key:";
            // 
            // tbApiKey
            // 
            tbApiKey.Location = new Point(68, 12);
            tbApiKey.Name = "tbApiKey";
            tbApiKey.Size = new Size(262, 23);
            tbApiKey.TabIndex = 1;
            // 
            // cbRemSourceLanguage
            // 
            cbRemSourceLanguage.AutoSize = true;
            cbRemSourceLanguage.Location = new Point(12, 41);
            cbRemSourceLanguage.Name = "cbRemSourceLanguage";
            cbRemSourceLanguage.Size = new Size(178, 19);
            cbRemSourceLanguage.TabIndex = 2;
            cbRemSourceLanguage.Text = "Remember Source Language";
            cbRemSourceLanguage.UseVisualStyleBackColor = true;
            cbRemSourceLanguage.CheckedChanged += cbRemSourceLanguage_CheckedChanged;
            // 
            // cbRemTargetLanguage
            // 
            cbRemTargetLanguage.AutoSize = true;
            cbRemTargetLanguage.Location = new Point(12, 66);
            cbRemTargetLanguage.Name = "cbRemTargetLanguage";
            cbRemTargetLanguage.Size = new Size(174, 19);
            cbRemTargetLanguage.TabIndex = 3;
            cbRemTargetLanguage.Text = "Remember Target Language";
            cbRemTargetLanguage.UseVisualStyleBackColor = true;
            cbRemTargetLanguage.CheckedChanged += cbRemTargetLanguage_CheckedChanged;
            // 
            // cbAuto
            // 
            cbAuto.AutoSize = true;
            cbAuto.Location = new Point(12, 91);
            cbAuto.Name = "cbAuto";
            cbAuto.Size = new Size(183, 19);
            cbAuto.TabIndex = 4;
            cbAuto.Text = "Auto Detect Source Language";
            cbAuto.UseVisualStyleBackColor = true;
            // 
            // cbLineByLine
            // 
            cbLineByLine.AutoSize = true;
            cbLineByLine.Location = new Point(12, 116);
            cbLineByLine.Name = "cbLineByLine";
            cbLineByLine.Size = new Size(132, 19);
            cbLineByLine.TabIndex = 5;
            cbLineByLine.Text = "Request line per line";
            cbLineByLine.UseVisualStyleBackColor = true;
            // 
            // cBoxSourceLanguage
            // 
            cBoxSourceLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxSourceLanguage.FormattingEnabled = true;
            cBoxSourceLanguage.Location = new Point(209, 39);
            cBoxSourceLanguage.Name = "cBoxSourceLanguage";
            cBoxSourceLanguage.Size = new Size(121, 23);
            cBoxSourceLanguage.TabIndex = 6;
            // 
            // cBoxTargetLanguage
            // 
            cBoxTargetLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxTargetLanguage.FormattingEnabled = true;
            cBoxTargetLanguage.Location = new Point(209, 68);
            cBoxTargetLanguage.Name = "cBoxTargetLanguage";
            cBoxTargetLanguage.Size = new Size(121, 23);
            cBoxTargetLanguage.TabIndex = 7;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(290, 151);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(40, 23);
            btnOk.TabIndex = 8;
            btnOk.Text = "&Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(209, 151);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 186);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cBoxTargetLanguage);
            Controls.Add(cBoxSourceLanguage);
            Controls.Add(cbLineByLine);
            Controls.Add(cbAuto);
            Controls.Add(cbRemTargetLanguage);
            Controls.Add(cbRemSourceLanguage);
            Controls.Add(tbApiKey);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbApiKey;
        private CheckBox cbRemSourceLanguage;
        private CheckBox cbRemTargetLanguage;
        private CheckBox cbAuto;
        private CheckBox cbLineByLine;
        private ComboBox cBoxSourceLanguage;
        private ComboBox cBoxTargetLanguage;
        private Button btnOk;
        private Button btnCancel;
    }
}