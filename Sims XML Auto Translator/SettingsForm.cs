using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sims_XML_Auto_Translator
{
    public partial class SettingsForm : Form
    {
        private MainForm mainForm;

        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Utils.GetLanguages(cBoxSourceLanguage, cBoxTargetLanguage, true);
            cbRemSourceLanguage.Checked = Properties.Settings.Default.rememberSourceLanguage;
            cbRemTargetLanguage.Checked = Properties.Settings.Default.rememberTargetLanguage;
            cbAuto.Checked = Properties.Settings.Default.detectSourceLanguage;
            cbLineByLine.Checked = Properties.Settings.Default.requestLinePerLine;
            if (string.IsNullOrEmpty(Properties.Settings.Default.apiKey))
            {
                ApiKeyForm apiKeyForm = new ApiKeyForm();
                if (apiKeyForm.ShowDialog() == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                apiKeyForm.Dispose();
            }
            else
            {
                tbApiKey.Text = Properties.Settings.Default.apiKey;
            }
            cBoxSourceLanguage.Enabled = cbRemSourceLanguage.Checked;
            cBoxTargetLanguage.Enabled = cbRemTargetLanguage.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbApiKey.Text))
            {
                MessageBox.Show("Please enter an API Key!");
                return;
            }

            bool result = await DeepLSims.CheckApiKey(tbApiKey.Text);
            if (result)
            {
                Properties.Settings.Default.rememberSourceLanguage = cbRemSourceLanguage.Checked;
                Properties.Settings.Default.rememberTargetLanguage = cbRemTargetLanguage.Checked;
                Properties.Settings.Default.detectSourceLanguage = cbAuto.Checked;
                Properties.Settings.Default.requestLinePerLine = cbLineByLine.Checked;
                Properties.Settings.Default.sourceLanguage = cBoxSourceLanguage.SelectedValue.ToString();
                Properties.Settings.Default.targetLanguage = cBoxTargetLanguage.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(Properties.Settings.Default.apiKey))
                {
                    Properties.Settings.Default.apiKey = tbApiKey.Text;
                }
                Properties.Settings.Default.Save();
                mainForm.UpdateUI();
                Close();
            }
        }

        private void cbRemSourceLanguage_CheckedChanged(object sender, EventArgs e)
        {
            cBoxSourceLanguage.Enabled = cbRemSourceLanguage.Checked;
        }

        private void cbRemTargetLanguage_CheckedChanged(object sender, EventArgs e)
        {
            cBoxTargetLanguage.Enabled = cbRemTargetLanguage.Checked;
        }
    }
}
