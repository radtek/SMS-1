using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiProxy.Tasks.Infrastructure;
using WebApiProxy.Tasks.Models;
using System.IO;

namespace WebApiProxy.Generator
{
    public partial class Generator : Form
    {
        public Generator()
        {
            InitializeComponent();

            errorProvider.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialogResult = selectFolderDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtProjectDirectory.Text = selectFolderDialog.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            bool hasErrors = false;

            if (string.IsNullOrEmpty(txtProjectDirectory.Text))
            {
                errorProvider.SetError(txtProjectDirectory, "Please select a folder");
                hasErrors = true;
            }
               

            if (string.IsNullOrEmpty(txtEndpoint.Text))
            {

                errorProvider.SetError(txtEndpoint, "Please enter an Endpoint");
                hasErrors = true;
            }

            if (string.IsNullOrEmpty(txtProxyNamespace.Text))
            {
                
                errorProvider.SetError(txtProxyNamespace, "Please enter a proxy Namespace");
                hasErrors = true;
            }


            if (!hasErrors)
            {
                try
                {
                    var configuration = new Configuration
                    {
                        Endpoint = txtEndpoint.Text,
                        ClientSuffix = "Client",
                        Namespace = txtProxyNamespace.Text,
                        Name = "WebApiProxy",
                        GenerateOnBuild = false
                    };

                    if (!string.IsNullOrWhiteSpace(txtEntitiesNamespace.Text))
                        configuration.EntitiesNamespace = txtEntitiesNamespace.Text;

                    if (!string.IsNullOrWhiteSpace(txtEnumsNamespace.Text))
                        configuration.EnumsNamespace = txtEnumsNamespace.Text;

                    var generator = new CSharpGenerator(configuration);

                    var source = generator.Generate();

                    string fileName = Path.Combine(txtProjectDirectory.Text, configuration.Name + ".generated.cs");

                    File.WriteAllText(fileName, source);
                    //File.WriteAllText(Configuration.CacheFile, source);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtProjectDirectory.Text = @"C:\GitRepositories\BEF\Applications\Bec.TargetFramework\MainLine\Business\Bec.TargetFramework.Business.Client\WebApiProxy";
            txtProxyNamespace.Text = "Bec.TargetFramework.Business.Client";
            txtEntitiesNamespace.Text = "Bec.TargetFramework.Entities";
            txtEnumsNamespace.Text = "Bec.TargetFramework.Entities.Enums";
        }
    }
}
