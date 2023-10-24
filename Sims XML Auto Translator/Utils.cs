using DeepL;
using DeepL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

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

        public static async Task GetAllTextStringDefinitionAsync(XmlDocument document, string saveFile, ComboBox cbSourceLanguage, ComboBox cbTargetLanguage)
        {
            XmlNodeList textStringNodes = document.SelectNodes("//TextStringDefinition");

            List<string> textStrings = new List<string>();

            foreach (XmlNode textStringNode in textStringNodes)
            {
                XmlAttribute textStringAttribute = textStringNode.Attributes["TextString"];

                if (textStringAttribute != null)
                {
                    string textStringValue = textStringAttribute.Value;

                    textStringValue = textStringValue.Replace("\n", @"\x0a");
                    textStringValue = textStringValue.Replace("\r", @"\x0d");

                    textStrings.Add(textStringValue);
                }
            }

            string[] translatedTexts = new string[] { };

            if (Properties.Settings.Default.requestLinePerLine)
            {
                foreach (string textString in textStrings)
                {
                    string modifiedText = textString;
                    List<string> placeholders = new List<string>();
                    string pattern = @"\{[^}]+\}";
                    foreach (Match match in Regex.Matches(modifiedText, pattern))
                    {
                        placeholders.Add(match.Value);
                    }

                    Dictionary<string, string> tempPlaceholders = new Dictionary<string, string>();
                    int index = 0;

                    foreach (string placeholder in placeholders)
                    {
                        string tempPlaceholder = $"__TEMPP_{index}__";
                        modifiedText = modifiedText.Replace(placeholder, tempPlaceholder);
                        tempPlaceholders[tempPlaceholder] = placeholder;
                        index++;
                    }

                    if (!string.IsNullOrEmpty(Properties.Settings.Default.apiKey))
                    {
                        string translated = await DeepLSims.TranslateCombinedText(Properties.Settings.Default.apiKey, modifiedText, cbSourceLanguage, cbTargetLanguage);
                        foreach (var kvp in tempPlaceholders)
                        {
                            translated = translated.Replace(kvp.Key, kvp.Value);
                        }

                        translatedTexts  = translatedTexts.Append(translated).ToArray();
                    }
                }
            }
            else
            {
                string combinedText = string.Join("\n", textStrings);

                List<string> placeholders = new List<string>();
                string pattern = @"\{[^}]+\}";
                foreach (Match match in Regex.Matches(combinedText, pattern))
                {
                    placeholders.Add(match.Value);
                }

                Dictionary<string, string> tempPlaceholders = new Dictionary<string, string>();
                int index = 0;

                foreach (string placeholder in placeholders)
                {
                    string tempPlaceholder = $"__TEMPP_{index}__";
                    combinedText = combinedText.Replace(placeholder, tempPlaceholder);
                    tempPlaceholders[tempPlaceholder] = placeholder;
                    index++;
                }

                if (!string.IsNullOrEmpty(Properties.Settings.Default.apiKey))
                {
                    string translated = await DeepLSims.TranslateCombinedText(Properties.Settings.Default.apiKey, combinedText, cbSourceLanguage, cbTargetLanguage);
                    foreach (var kvp in tempPlaceholders)
                    {
                        translated = translated.Replace(kvp.Key, kvp.Value);
                    }

                    translatedTexts = translated.Split('\n');
                }
            }

            int textIndex = 0;

            foreach (XmlNode textStringNode in textStringNodes)
            {
                if (textIndex < translatedTexts.Length)
                {
                    string translatedText = translatedTexts[textIndex];

                    translatedText = translatedText.Replace(@"\x0a", "\n");
                    translatedText = translatedText.Replace(@"\x0d", "\r");

                    XmlAttribute textStringAttribute = textStringNode.Attributes["TextString"];
                    if (textStringAttribute != null)
                    {
                        textStringAttribute.Value = translatedText;
                    }

                    textIndex++;
                }
            }

            using (XmlTextWriter writer = new XmlTextWriter(saveFile, Encoding.UTF8))
            {
                writer.Formatting = System.Xml.Formatting.Indented;
                document.WriteTo(writer);
            }
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
