using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Antlr4.Runtime.Tree;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Nodes;
using EVF.Client.Common.DocGen;
using EVF.Common.StaticData;
using EVF.Common.SummitData;
using EVF.External.Functions.RepositoryRegister;
using JiahuScriptRunner.Domain.Configuration;
using JiahuScriptRunner.Visualiser;
using JiahuScriptRunner.Windows;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using Newtonsoft.Json;
using JsrUnderlying = JiahuScriptRunner.Domain.ExternalObjects.Underlying;

namespace JiahuScriptRunner
{
    public partial class MainWindow : Form
    {
        private string _scriptFilename = string.Empty;
        private readonly ApplicationConfiguration _applicationConfiguration = new ApplicationConfiguration();

        public MainWindow()
        {
            InitializeComponent();

            _applicationConfiguration = new ApplicationSettings().Load();
            editScript_EditValueChanged(null, null);
        }

        private void barButtonExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new ApplicationSettings().Save(_applicationConfiguration);
            Close();
        }

        private void buttonProperties_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var window = new PropertyWindow(_applicationConfiguration))
            {
                if (window.ShowDialog(this) == DialogResult.OK)
                {
                    new ApplicationSettings().Save(_applicationConfiguration);
                }
            }
        }

        private void buttonCompile_Click(object sender, EventArgs e)
        {
            CompileScript();
        }

        private T GetExternalObject<T>(string objectDataFileLocation)
        {
            using (StreamReader reader = File.OpenText(objectDataFileLocation))
            {
                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
        }

        private void CompileScript()
        {
            try
            {
                ResetAllTabs();

                JiahuCompiler compiler = new JiahuCompiler(new Repository(new FunctionRepositoryRegister()));
                compiler.Compile(editScript.Text);

                SetTabWithUpdate(xtraTabConsole);
                SetTabWithUpdate(xtraTabMemory);
                PopulateMemoryView(compiler.SymbolTable);

                editOutput.Text += @"Compile completed, valid Jiahu script." + Environment.NewLine;
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Compiler Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editOutput.Text += exception.Message + Environment.NewLine;

                treeMemory.Nodes.Clear();
                SetTabWithError(xtraTabConsole);
            }
        }

        private void PopulateMemoryView(IManagedMemory managedMemory)
        {
            try
            {
                treeMemory.BeginUpdate();

                SetupTreeMemoryColumns();
                treeMemory.Nodes.Clear();

                SymbolFacilitator symbolFacilitator = new SymbolFacilitator();
                TreeListNode parentNode = treeMemory.AppendNode(new[] { "global" }, null);

                foreach (FunctionSymbol symbol in managedMemory.FunctionSymbols)
                {
                    
                    TreeListNode functionListNode = treeMemory.AppendNode(new[] { symbol.Name, "", "function" }, parentNode);
                    Scope scope = managedMemory.GetScope(new ScopeOwner(symbol.Name, ScopeOwnerType.Function, symbol.Id));

                    foreach (Symbol parameter in scope.Symbols)
                    {
                        treeMemory.AppendNode(new[] { string.Empty, parameter.Name, "variable", ((ISymbolValueType)parameter).ValueType, symbolFacilitator.GetValueAsString(parameter) }, functionListNode);
                    }

                    PopulateTreeWithChildScope(functionListNode, scope.Scopes);
                }

                foreach(Scope scope in managedMemory.Scopes.Where(x => x.Owner.OwnerType != ScopeOwnerType.Function))
                {
                    TreeListNode scopeListNode = treeMemory.AppendNode(new[] { scope.Owner.Name }, parentNode);
                    foreach (Symbol symbol in scope.Symbols)
                    {
                        treeMemory.AppendNode(new[] { string.Empty, symbol.Name, "variable", ((ISymbolValueType)symbol).ValueType, symbolFacilitator.GetValueAsString(symbol) }, scopeListNode);
                    }

                    if (scope.Scopes.Count > 0)
                    {
                        PopulateTreeWithChildScope(scopeListNode, scope.Scopes);
                    }
                }
            }
            finally
            {
                treeMemory.EndUpdate();
                treeMemory.ExpandAll();
            }
            
        }

        private void PopulateTreeWithChildScope(TreeListNode scopeListNode, IList<Scope> scopes)
        {
            foreach (Scope scope in scopes)
            {
                SymbolFacilitator symbolFacilitator = new SymbolFacilitator();
                TreeListNode innerScopeNode = treeMemory.AppendNode(new[] { scope.Owner.Name, string.Empty, scope.Owner.OwnerType.ToString().ToLower() }, scopeListNode);

                foreach (Symbol symbol in scope.Symbols)
                {
                    treeMemory.AppendNode(new[] { string.Empty, symbol.Name, "variable", ((ISymbolValueType)symbol).ValueType, symbolFacilitator.GetValueAsString(symbol) }, innerScopeNode);
                }

                if (scope.Scopes.Count > 0)
                {
                    PopulateTreeWithChildScope(innerScopeNode, scope.Scopes);
                }
            }
        }

        private void SetupTreeMemoryColumns()
        {
            treeMemory.Columns.Clear();
            treeMemory.Columns.Add();
            treeMemory.Columns[0].Caption = "Scope";
            treeMemory.Columns[0].VisibleIndex = 0;
            treeMemory.Columns.Add();
            treeMemory.Columns[1].Caption = "Symbol Name";
            treeMemory.Columns[1].VisibleIndex = 1;
            treeMemory.Columns.Add();
            treeMemory.Columns[2].Caption = "Symbol Type";
            treeMemory.Columns[2].VisibleIndex = 2;
            treeMemory.Columns.Add();
            treeMemory.Columns[3].Caption = "Symbol Data Type";
            treeMemory.Columns[3].VisibleIndex = 3;
            treeMemory.Columns.Add();
            treeMemory.Columns[4].Caption = "Symbol Value";
            treeMemory.Columns[4].VisibleIndex = 4;
        }

        private void SetTabWithUpdate(XtraTabPage tabPage)
        {
            tabPage.Appearance.Header.BackColor = Color.LightGreen;
        }

        private void SetTabWithError(XtraTabPage tabPage)
        {
            tabPage.Appearance.Header.BackColor = Color.OrangeRed;
        }

        private void ResetTab(XtraTabPage tabPage)
        {
            tabPage.Appearance.Header.BackColor = new Color();
        }

        private void editScript_EditValueChanged(object sender, EventArgs e)
        {
            if (editScript.Text.Length > 0)
            {
                buttonCompile.Enabled = true;
                buttonRun.Enabled = true;
                buttonViewParseTree.Enabled = true;
                barButtonSave.Enabled = true;
                barButtonSaveAs.Enabled = true;
                barButtonViewTree.Enabled = true;
                barButtonCompile.Enabled = true;
                barButtonViewTree.Enabled = true;
                barButtonRun.Enabled = true;
            }
            else
            {
                buttonCompile.Enabled = false;
                buttonRun.Enabled = false;
                buttonViewParseTree.Enabled = false;
                barButtonSave.Enabled = false;
                barButtonSaveAs.Enabled = false;
                barButtonViewTree.Enabled = false;
                barButtonCompile.Enabled = false;
                barButtonViewTree.Enabled = false;
                barButtonRun.Enabled = false;
            }
        }

        private void barButtonSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Jiahu Script - Save As";
                saveFileDialog.Filter = "Jiahu Script (*.jiahu)|*.jiahu";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.DefaultExt = ".jiahu";

                if (!string.IsNullOrWhiteSpace(_applicationConfiguration.SaveLocation))
                {
                    saveFileDialog.InitialDirectory = _applicationConfiguration.SaveLocation;
                }

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        if (MessageBox.Show(this, "Filename already exists, do you want to overwrite?", "Save As", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    File.WriteAllText(saveFileDialog.FileName, editScript.Text, Encoding.UTF8);
                    _scriptFilename = saveFileDialog.FileName;
                    _applicationConfiguration.SaveLocation = Path.GetDirectoryName(saveFileDialog.FileName);
                }
            }
        }

        private void barButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_scriptFilename))
            {
                barButtonSaveAs_ItemClick(sender, e);
            }
            else
            {
                File.WriteAllText(_scriptFilename, editScript.Text, Encoding.UTF8);    
            }
        }

        private void barButtonOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Jiahu Script - Open";
                fileDialog.Filter = "Jiahu Script (*.jiahu)|*.jiahu|All files (*.*)|*.*";
                fileDialog.FilterIndex = 0;
                fileDialog.DefaultExt = ".jiahu";

                if (fileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    editScript.Text =  File.ReadAllText(fileDialog.FileName, Encoding.UTF8);
                    _scriptFilename = fileDialog.FileName;
                    _applicationConfiguration.SaveLocation = Path.GetDirectoryName(fileDialog.FileName);
                }
            }
        }

        private void ResetAllTabs()
        {
            ResetTab(xtraTabResults);
            ResetTab(xtraTabConsole);
            ResetTab(xtraTabParseTree);
            ResetTab(xtraTabMemory);
        }

        private void xtraTabScript_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            ResetTab(e.Page);
        }

        private void buttonViewParseTree_Click(object sender, EventArgs e)
        {
            DrawParseTree();
        }

        private void barButtonRun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RunScript();
        }

        private void barButtonCompile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CompileScript();
        }

        private void barButtonViewTree_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DrawParseTree();
        }

        private void DrawParseTree()
        {
            try
            {
                ResetAllTabs();

                IParseTree tree = new ScriptAstGenerator().Generate(editScript.Text);
                VisualAst visualiser = new VisualAst(new AstTreeNode(tree));
                pictureParseTree.Image = visualiser.Draw();

                editOutput.Text += "Parse tree drawn..." + Environment.NewLine;

                SetTabWithUpdate(xtraTabConsole);
                SetTabWithUpdate(xtraTabParseTree);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Error drawing parse tree.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editOutput.Text += exception.Message + Environment.NewLine;
                pictureParseTree.Image = null;

                SetTabWithError(xtraTabConsole);
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            RunScript();
        }

        private void RunScript()
        {
            try
            {
                ResetAllTabs();

                JsrUnderlying underlying = GetExternalObject<JsrUnderlying>(new ApplicationSettings().Load().ExternalObjectUnderlyingDataLocation);
                VariableRepository variableRepository = new VariableRepository();
                variableRepository.Register(new ObjectVariableSymbol("U") { Value =  underlying });
                
                JiahuInterpreter interpreter = new JiahuInterpreter(new Repository(new FunctionRepositoryRegister()), PrintToScreen);
                ManagedMemory.ApplyGlobalVariables(interpreter.ManagedMemory, variableRepository);

                interpreter.Run(editScript.Text);
                editOutput.Text += "Jiahu script finished." + Environment.NewLine;

                SetTabWithUpdate(xtraTabConsole);
                SetTabWithUpdate(xtraTabMemory);
                PopulateMemoryView(interpreter.ManagedMemory);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Script Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editOutput.Text += exception.Message + Environment.NewLine;

                treeMemory.Nodes.Clear();
                SetTabWithError(xtraTabConsole);
            }
        }

        private void barButtonExternalFunctions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FunctionRepositoryRegister register = new FunctionRepositoryRegister();
            register.Setup(new Counterparty(), new ClientData());
            register.Setup(new Underlying());

            using (ExternalFunctionsWindow window = new ExternalFunctionsWindow(register))
            {
                window.ShowDialog(this);
            }
        }

        private void PrintToScreen(string message)
        {
            editScriptOutput.Text += message + Environment.NewLine;
            SetTabWithUpdate(xtraTabResults);
        }

        private void barButtonItemExternalObjects_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<object> externalObjects = new List<object> {GetExternalObject<JsrUnderlying>(new ApplicationSettings().Load().ExternalObjectUnderlyingDataLocation)};

            using (ExternalObjectsWindow window = new ExternalObjectsWindow(externalObjects))
            {
                window.ShowDialog(this);
            }
        }
    }
}