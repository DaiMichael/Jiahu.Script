using System;
using System.Windows.Forms;
using JiahuScriptRunner.Domain.Configuration;

namespace JiahuScriptRunner.Windows
{
    public partial class PropertyWindow : Form
    {
        private readonly ApplicationConfiguration _applicationConfiguration;

        public PropertyWindow(ApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            
            InitializeComponent();
            SetupWindow();
        }

        private void SetupWindow()
        {
            propertyGrid.SelectedObject = _applicationConfiguration;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}