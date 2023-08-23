using DeepL;
using System;
using System.Collections.Generic;
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
    }
}
