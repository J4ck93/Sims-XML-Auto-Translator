using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sims_XML_Auto_Translator
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.LinkText,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while trying to open the Browser: " + ex.Message);
            }
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            //"Sims XML Auto Translator\r\nVersion: \r\nCompiled: \r\nAuthor: UmaruMG\r\nhttps://github.com/UmaruMG";
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            addToBox(Application.ProductName);
            addToBox("Version: " + version.Major + "." + version.Minor + "." + version.Build);
            addToBox("Compiled: " + GetBuildDate(Assembly.GetExecutingAssembly()).ToString("MMM dd yyyy HH:mm:ss"));
            string author = GetAuthor(Assembly.GetExecutingAssembly());
            addToBox("Author: " + author);
            addToBox("https://github.com/" + author);
        }


        private void addToBox(string text)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                richTextBox1.AppendText("\r\n" + text);
            }
            else
            {
                richTextBox1.AppendText(text);
            }
        }

        private static DateTime GetBuildDate(Assembly assembly)
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

        private static string GetAuthor(Assembly assembly)
        {
            var attribute = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            if (attribute?.Company != null)
            {
                return attribute.Company;
            }

            return "";
        }
    }
}
