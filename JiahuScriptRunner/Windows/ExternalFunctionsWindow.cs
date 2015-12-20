using System;
using System.Linq;
using System.Windows.Forms;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.External.RepositoryRegisters;

namespace JiahuScriptRunner.Windows
{
    public partial class ExternalFunctionsWindow : Form
    {
        private const int ColumnWidthOffset = 30;
        private const string FunctionColumnName = "Function";
        private const string ReturnTypeDescription = "Function return value.";
        private const string ReturnTypeName = "Return Type";

        private readonly FunctionRepositoryRegisterBase _functionRegister;

        public ExternalFunctionsWindow(FunctionRepositoryRegisterBase functionRegister)
        {
            InitializeComponent();

            _functionRegister = functionRegister;
            PopulateFunctionView();
            SelectDefaultFunction();
        }

        private void SelectDefaultFunction()
        {
            if (lvFunctions.Items.Count > 0)
            {
                lvFunctions.Select();
                lvFunctions.Items[0].Selected = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PopulateFunctionView()
        {
            lvFunctions.Columns.Add(new ColumnHeader { Text = FunctionColumnName, Width = lvFunctions.Width - ColumnWidthOffset });
            
            foreach (IFunction function in _functionRegister.GetAllRegisteredItems<IFunction>().Distinct())
            {
                foreach (IFunctionDefinition definition in function.Definitions)
                {
                    ListViewGroup group;
                    if (lvFunctions.Groups.Cast<ListViewGroup>().Any(x => x.Name == definition.Category))
                    {
                        group = lvFunctions.Groups[definition.Category];
                    }
                    else
                    {
                        group = new ListViewGroup(definition.Category, definition.Category) {HeaderAlignment = HorizontalAlignment.Left};
                        lvFunctions.Groups.Add(group);
                    }

                    lvFunctions.Items.Add(new ListViewItem(definition.Name, group));
                }
            }
        }

        private void lvFunctions_SelectedItemChanged(object sender, EventArgs e)
        {
            if (lvFunctions.SelectedItems.Count > 0 && lvFunctions.SelectedItems[0] != null)
            {
                ListViewItem listViewItem = lvFunctions.SelectedItems[0];
                IFunction function = _functionRegister.Resolve<IFunction>(listViewItem.Text);

                SetFuntionDescription(function, listViewItem.Text);
                SetFunctionParamters(function, listViewItem.Text);
            }
        }

        private void SetFunctionParamters(IFunction function, string functionName)
        {
            lvParameters.Items.Clear();

            foreach (IParameter parameter in function.Parameters)
            {
                lvParameters.Items.Add(new ListViewItem(new[] {parameter.Order.ToString(), parameter.Name, parameter.Type.Name, parameter.Optional.ToString(), parameter.Description}));
            }

            lvParameters.Items.Add(new ListViewItem(new[] { string.Empty, ReturnTypeName, function.ReturnType.Type.Name, string.Empty, ReturnTypeDescription }));
        }

        private void SetFuntionDescription(IFunction function, string functionName)
        {
            IFunctionDefinition functionDefinition = function.Definitions.First(x => x.Name == functionName);
            labelFunctionDescription.Text = functionDefinition.Description;
        }
    }
}
