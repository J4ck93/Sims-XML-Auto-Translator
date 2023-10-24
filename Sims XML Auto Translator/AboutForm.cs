using System.Diagnostics;
using System.Globalization;
using System.Reflection;

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
            Utils.OpenURL(e.LinkText);
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            //"Sims XML Auto Translator\r\nVersion: \r\nCompiled: \r\nAuthor: UmaruMG\r\nhttps://github.com/UmaruMG";
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            addToBox(Application.ProductName);
            addToBox("Version: " + version.Major + "." + version.Minor + "." + version.Build);
            addToBox("Compiled: " + Utils.GetBuildDate(Assembly.GetExecutingAssembly()).ToString("MMM dd yyyy HH:mm:ss"));
            string author = Utils.GetAuthor(Assembly.GetExecutingAssembly());
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


    }
}
