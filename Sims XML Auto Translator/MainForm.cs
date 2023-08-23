using Newtonsoft.Json;

namespace Sims_XML_Auto_Translator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LanguageContainer languageContainer = JsonConvert.DeserializeObject<LanguageContainer>(Properties.Resources.languages);

                Language[] sourceLanguages = CreateLanguageArray(languageContainer.SourceLanguage);
                Language[] targetLanguages = CreateLanguageArray(languageContainer.TargetLanguage);

                cbSourceLanguage.DataSource = sourceLanguages;
                cbSourceLanguage.DisplayMember = "Name";
                cbSourceLanguage.ValueMember = "Code";
                cbSourceLanguage.SelectedValue = Properties.Settings.Default.sourceLanguage;

                cbTargetLanguage.DataSource = targetLanguages;
                cbTargetLanguage.DisplayMember = "Name";
                cbTargetLanguage.ValueMember = "Code";
                cbTargetLanguage.SelectedValue = Properties.Settings.Default.targetLanguage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static Language[] CreateLanguageArray(Dictionary<string, string> languageDictionary)
        {
            List<Language> languages = new List<Language>();

            foreach (var kvp in languageDictionary)
            {
                Language language = new Language(kvp.Key, kvp.Value);
                languages.Add(language);
            }

            return languages.ToArray();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }

    class Language
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Language(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }

    class LanguageContainer
    {
        public Dictionary<string, string> SourceLanguage { get; set; }
        public Dictionary<string, string> TargetLanguage { get; set; }
    }
}