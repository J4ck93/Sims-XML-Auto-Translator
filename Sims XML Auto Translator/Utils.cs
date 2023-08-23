using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sims_XML_Auto_Translator
{
    public class Utils
    {

        public static DateTime GetBuildDate(Assembly assembly)
        {
            const string BuildVersionMetadataPrefix = "+build";

            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (attribute?.InformationalVersion != null)
            {
                var value = attribute.InformationalVersion;
                var index = value.IndexOf(BuildVersionMetadataPrefix);
                if (index > 0)
                {
                    value = value.Substring(index + BuildVersionMetadataPrefix.Length);
                    if (DateTime.TryParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                    {
                        return result;
                    }
                }
            }

            return default;
        }

        public static string GetAuthor(Assembly assembly)
        {
            var attribute = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            if (attribute?.Company != null)
            {
                return attribute.Company;
            }

            return "";
        }

        public static void OpenURL(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while trying to open the Browser: " + ex.Message);
            }
        }

        public static void GetLanguages(ComboBox cbSourceLanguage, ComboBox cbTargetLanguage, bool settings)
        {
            try
            {
                LanguageContainer languageContainer = JsonConvert.DeserializeObject<LanguageContainer>(Properties.Resources.languages);

                Language[] sourceLanguages = CreateLanguageArray(languageContainer.SourceLanguage);
                Language[] targetLanguages = CreateLanguageArray(languageContainer.TargetLanguage);

                cbSourceLanguage.DataSource = sourceLanguages;
                cbSourceLanguage.DisplayMember = "Name";
                cbSourceLanguage.ValueMember = "Code";
                if (Properties.Settings.Default.rememberSourceLanguage || settings)
                {
                    cbSourceLanguage.SelectedValue = Properties.Settings.Default.sourceLanguage;
                } else {
                    cbSourceLanguage.SelectedValue = Properties.Settings.Default.initalSourceLanguage;
                }

                cbTargetLanguage.DataSource = targetLanguages;
                cbTargetLanguage.DisplayMember = "Name";
                cbTargetLanguage.ValueMember = "Code";
                if (Properties.Settings.Default.rememberSourceLanguage || settings)
                {
                    cbTargetLanguage.SelectedValue = Properties.Settings.Default.targetLanguage;
                }
                else
                {
                    cbTargetLanguage.SelectedValue = Properties.Settings.Default.initalTargetLanguage;
                }
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
