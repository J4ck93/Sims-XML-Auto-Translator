using DeepL;
using DeepL.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims_XML_Auto_Translator
{
    public class DeepLSims
    {
        public static async Task<bool> CheckApiKey(string apiKey)
        {
            var translator = new Translator(apiKey);
            try
            {
                var usage = await translator.GetUsageAsync();
                if (usage.Character != null)
                {
                    Properties.Settings.Default.apiKey = apiKey;
                    Properties.Settings.Default.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ex is DeepL.AuthorizationException)
                {
                    MessageBox.Show("Something went wrong when authenticating your key. Please check if you typed it in correctly.");
                }
                else
                {
                    MessageBox.Show("Unknown Error: " + ex.Message);
                }
                return false;
            }
        }

        public static async Task<string> CheckUsage(string apiKey)
        {
            var translator = new Translator(apiKey);
            try
            {
                var usage = await translator.GetUsageAsync();
                if (usage.Character != null)
                {
                    return usage.Character.ToString();
                }
                return "Unknown Error";
            }
            catch (Exception ex)
            {
                if (ex is DeepL.AuthorizationException)
                {
                    return "Something went wrong when authenticating your key. Please check if you typed it in correctly.";
                }
                else
                {
                    return "Unknown Error: " + ex.Message;
                }
            }
        }

        public static async Task<string> TranslateCombinedText(string apiKey, string combinedText, ComboBox cbSourceLanguage, ComboBox cbTargetLanguage)
        {
            var translator = new Translator(apiKey);
            try
            {
                var sourceLang = cbSourceLanguage.SelectedValue.ToString();
                if (cbSourceLanguage.SelectedValue.ToString() == "AT")
                {
                    sourceLang = null;
                }
                var result = await translator.TranslateTextAsync(combinedText, sourceLang, cbTargetLanguage.SelectedValue.ToString(), new TextTranslateOptions { SentenceSplittingMode = SentenceSplittingMode.All, TagHandling = "xml" });

                if (result.Text != null)
                {
                    return result.Text;
                }
                return "Unknown Error";
            }
            catch (Exception ex)
            {
                if (ex is DeepL.AuthorizationException)
                {
                    return "Something went wrong when authenticating your key. Please check if you typed it in correctly.";
                }
                else
                {
                    return "Unknown Error: " + ex.Message;
                }
            }
        }
    }
}
