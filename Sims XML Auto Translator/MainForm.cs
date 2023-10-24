using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace Sims_XML_Auto_Translator
{
    public partial class MainForm : Form
    {
        private string importedXML = "";
        private XmlDocument document = new XmlDocument();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Utils.GetLanguages(cbSourceLanguage, cbTargetLanguage, false);
            UpdateUI();

            if (string.IsNullOrEmpty(Properties.Settings.Default.apiKey))
            {
                ApiKeyForm apiKeyForm = new ApiKeyForm();
                if (apiKeyForm.ShowDialog() == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                apiKeyForm.Dispose();
            }
        }

        #region File Menu
        private void importToolStrip_Click(object sender, EventArgs e)
        {
            ImportXML();
        }

        private void exportToolStrip_Click(object sender, EventArgs e)
        {
            ExportXML();
        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Options Menu
        private async void usageToolStrip_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.apiKey))
            {
                string usage = await DeepLSims.CheckUsage(Properties.Settings.Default.apiKey);
                MessageBox.Show(usage);
            }
        }

        private void settingToolStrip_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();
        }
        #endregion

        #region Help Menu
        private void updateToolStrip_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://github.com/UmaruMG/Sims-XML-Auto-Translator/releases");
        }

        private void helpToolStrip_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://www.patreon.com/posts/automatically-4-87611500");
        }

        private void aboutToolStrip_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        #endregion

        public void UpdateUI()
        {
            if (Properties.Settings.Default.rememberSourceLanguage || Properties.Settings.Default.detectSourceLanguage)
            {
                if (Properties.Settings.Default.detectSourceLanguage)
                {
                    cbSourceLanguage.SelectedValue = "AT";
                }
                else
                {
                    cbSourceLanguage.SelectedValue = Properties.Settings.Default.sourceLanguage;
                }
                cbSourceLanguage.Enabled = false;
            }
            else
            {
                cbSourceLanguage.Enabled = true;
            }

            if (Properties.Settings.Default.rememberTargetLanguage)
            {
                cbTargetLanguage.SelectedValue = Properties.Settings.Default.targetLanguage;
                cbTargetLanguage.Enabled = false;
            }
            else
            {
                cbTargetLanguage.Enabled = true;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportXML();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportXML();
        }

        public void ImportXML()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open XML File";
            openFileDialog.Filter = "XML File|*.xml";
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importedXML = openFileDialog.FileName;
                document.Load(importedXML);
                btnExport.Enabled = true;
                exportToolStrip.Enabled = true;
            }
        }

        public void ExportXML()
        {

            if (!string.IsNullOrEmpty(importedXML))
            {
                if (cbSourceLanguage.Text == cbTargetLanguage.Text)
                {
                    if (MessageBox.Show("Do you really want to Translate into the same Language?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save XML File";
                saveFileDialog.Filter = "XML File|*.xml";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(importedXML) + "_" + cbTargetLanguage.Text;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var result = Utils.GetAllTextStringDefinitionAsync(document, saveFileDialog.FileName, cbSourceLanguage, cbTargetLanguage);
                    if (result != null)
                    {
                        MessageBox.Show("The File Generated successfully at " + saveFileDialog.FileName, "Info");
                    }
                }
            }
        }
    }
}