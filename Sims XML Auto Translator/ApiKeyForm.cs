using DeepL;
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
    public partial class ApiKeyForm : Form
    {
        public ApiKeyForm()
        {
            InitializeComponent();
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
            }
            else if (!string.IsNullOrEmpty(Properties.Settings.Default.apiKey))
            {
                Close();
            }
            else
            {
                bool result = await DeepLSims.CheckApiKey(tbApiKey.Text);
                if (result)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
