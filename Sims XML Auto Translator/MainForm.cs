using Newtonsoft.Json;

namespace Sims_XML_Auto_Translator
{
    public partial class MainForm : Form
    {
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

        }

        private void exportToolStrip_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Options Menu
        private void usageToolStrip_Click(object sender, EventArgs e)
        {

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
                } else
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
            } else
            {
                cbTargetLanguage.Enabled = true;
            }
        }
    }
}