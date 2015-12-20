using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Antlr4.Runtime.Tree;
using JiahuScriptRunner.Domain.Configuration;
using JiahuScriptRunner.Visualiser;
using JiahuScriptRunner.Windows;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using JiahuScriptRuntime.External.RepositoryRegisters;
using Newtonsoft.Json;
using JiahuScript.External.Examples;
using JiahuScript.External.Examples.Objects;

namespace JiahuScriptRunner
{
    public partial class MainWindow : Form
    {
        private string _scriptFilename = string.Empty;
        private readonly ApplicationConfiguration _applicationConfiguration = new ApplicationConfiguration();
        private readonly VariableRepository _variableRepository = new VariableRepository();
        private readonly IRepository _functionRepository = new Repository(new FunctionRegister());

        public MainWindow()
        {
            InitializeComponent();

            _applicationConfiguration = new ApplicationSettings().Load();
            textScript_TextChanged(null, null);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ExitApplication();
        }

        private void SetupExternalFunctionsAndObjects()
        {
            Underlying underlying = GetExternalObject<Underlying>(new ApplicationSettings().Load().ExternalObjectUnderlyingDataLocation);
            _variableRepository.Register(new ObjectVariableSymbol("U") { Value = underlying });
        }


        private void ExitApplication()
        {
            new ApplicationSettings().Save(_applicationConfiguration);
        }

        private void menuItemFileExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
            Close();
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

                JiahuCompiler compiler = new JiahuCompiler(_functionRepository);
                compiler.Compile(textScript.Text);

                SetTabWithUpdate(tabOutput);
                SetTabWithUpdate(tabMemory);
                PopulateMemoryView(compiler.SymbolTable);

                textOutput.Text += @"Compile completed, valid Jiahu script." + Environment.NewLine;
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Compiler Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textOutput.Text += exception.Message + Environment.NewLine;

                lvMemory.Items.Clear();
                SetTabWithError(tabOutput);
            }
        }

        private void PopulateMemoryView(IManagedMemory managedMemory)
        {
            lvMemory.Items.Clear();

            SymbolFacilitator symbolFacilitator = new SymbolFacilitator();
            ListViewItem globalItem = lvMemory.Items.Add("functions");

            foreach (FunctionSymbol symbol in managedMemory.FunctionSymbols)
            {
                AddToListItem(lvMemory.Items.Add(symbol.Name), string.Empty, "function", string.Empty, string.Empty);
                
                Scope scope = managedMemory.GetScope(new ScopeOwner(symbol.Name, ScopeOwnerType.Function, symbol.Id));
                foreach (Symbol parameter in scope.Symbols)
                {
                    AddToListItem(lvMemory.Items.Add(string.Empty), parameter.Name, "variable", ((ISymbolValueType)parameter).ValueType, symbolFacilitator.GetValueAsString(parameter));
                }

                PopulateTreeWithChildScope(scope.Scopes);
            }

            foreach(Scope scope in managedMemory.Scopes.Where(x => x.Owner.OwnerType != ScopeOwnerType.Function))
            {
                ListViewItem functionListItem = lvMemory.Items.Add(scope.Owner.Name);
                foreach (Symbol symbol in scope.Symbols)
                {
                    AddToListItem(lvMemory.Items.Add(string.Empty), symbol.Name, "variable", ((ISymbolValueType)symbol).ValueType, symbolFacilitator.GetValueAsString(symbol));
                }

                if (scope.Scopes.Count > 0)
                {
                    PopulateTreeWithChildScope(scope.Scopes);
                }
            }
        }

        private void AddToListItem(ListViewItem item, string subItemOne, string subItemTwo, string subItemThree, string subItemFour)
        {
            item.SubItems.Add(subItemOne);
            item.SubItems.Add(subItemTwo);
            item.SubItems.Add(subItemThree);
            item.SubItems.Add(subItemFour);
        }

        private void PopulateTreeWithChildScope(IList<Scope> scopes)
        {
            foreach (Scope scope in scopes)
            {
                SymbolFacilitator symbolFacilitator = new SymbolFacilitator();
                AddToListItem(lvMemory.Items.Add(scope.Owner.Name), string.Empty, scope.Owner.OwnerType.ToString().ToLower(), string.Empty, string.Empty);

                foreach (Symbol symbol in scope.Symbols)
                {
                    AddToListItem(lvMemory.Items.Add(string.Empty), "variable", symbol.Name, ((ISymbolValueType)symbol).ValueType, symbolFacilitator.GetValueAsString(symbol));
                }

                if (scope.Scopes.Count > 0)
                {
                    PopulateTreeWithChildScope(scope.Scopes);
                }
            }
        }

        private void SetTabWithUpdate(TabPage tabPage)
        {
            tabPage.ImageKey = "info";
        }

        private void SetTabWithError(TabPage tabPage)
        {
            tabPage.ImageKey = "error";
        }

        private void ResetTab(TabPage tabPage)
        {
            tabPage.ImageKey = "none";
        }

        private void textScript_TextChanged(object sender, EventArgs e)
        {
            if (textScript.Text.Length > 0)
            {
                buttonRunScript.Enabled = true;
                menuItemFileSave.Enabled = true;
                menuItemFileSaveAs.Enabled = true;
                menuItemBuildCompile.Enabled = true;
                menuItemBuildGrammarTree.Enabled = true;
                menuItemBuildRun.Enabled = true;
                menuStripCompile.Enabled = true;
                menuStripGrammarTree.Enabled = true;
                menuStripRun.Enabled = true;
            }
            else
            {
                buttonRunScript.Enabled = false;
                menuItemFileSave.Enabled = false;
                menuItemFileSaveAs.Enabled = false;
                menuItemBuildCompile.Enabled = false;
                menuItemBuildGrammarTree.Enabled = false;
                menuItemBuildRun.Enabled = false;
                menuStripCompile.Enabled = false;
                menuStripGrammarTree.Enabled = false;
                menuStripRun.Enabled = false;
            }
        }

        private void menuItemFileSaveAs_Click(object sender, EventArgs e)
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
                    File.WriteAllText(saveFileDialog.FileName, textScript.Text, Encoding.UTF8);
                    _scriptFilename = saveFileDialog.FileName;
                    _applicationConfiguration.SaveLocation = Path.GetDirectoryName(saveFileDialog.FileName);
                }
            }
        }

        private void menuItemFileSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_scriptFilename))
            {
                menuItemFileSaveAs_Click(sender, e);
            }
            else
            {
                File.WriteAllText(_scriptFilename, textScript.Text, Encoding.UTF8);    
            }
        }

        private void menuItemFileOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Jiahu Script - Open";
                fileDialog.Filter = "Jiahu Script (*.jiahu)|*.jiahu|All files (*.*)|*.*";
                fileDialog.FilterIndex = 0;
                fileDialog.DefaultExt = ".jiahu";

                if (fileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    textScript.Text =  File.ReadAllText(fileDialog.FileName, Encoding.UTF8);
                    _scriptFilename = fileDialog.FileName;
                    _applicationConfiguration.SaveLocation = Path.GetDirectoryName(fileDialog.FileName);
                }
            }
        }

        private void ResetAllTabs()
        {
            ResetTab(tabGrammarTree);
            ResetTab(tabOutput);
            ResetTab(tabMemory);
            ResetTab(tabResult);
        }

        private void tabResults_Changed(object sender, EventArgs e)
        {
            ResetTab((TabPage)sender);
        }

        private void menuItemBuildRun_Click(object sender, EventArgs e)
        {
            RunScript();
        }

        private void menuItemBuildCompile_Click(object sender, EventArgs e)
        {
            CompileScript();
        }

        private void menuItemBuildGrammarTree_Click(object sender, EventArgs e)
        {
            DrawParseTree();
        }

        private void DrawParseTree()
        {
            try
            {
                ResetAllTabs();

                IParseTree tree = new ScriptAstGenerator().Generate(textScript.Text);
                VisualAst visualiser = new VisualAst(new AstTreeNode(tree));
                pictureGrammarTree.Image = visualiser.Draw();

                textOutput.Text += "Parse tree drawn..." + Environment.NewLine;

                SetTabWithUpdate(tabOutput);
                SetTabWithUpdate(tabGrammarTree);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Error drawing parse tree.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textOutput.Text += exception.Message + Environment.NewLine;
                pictureGrammarTree.Image = null;
                SetTabWithError(tabOutput);
            }
        }

        private void buttonRunScript_Click(object sender, EventArgs e)
        {
            RunScript();
        }

        private void RunScript()
        {
            try
            {
                ResetAllTabs();

                JiahuInterpreter interpreter = new JiahuInterpreter(_functionRepository, PrintToScreen);
                ManagedMemory.ApplyGlobalVariables(interpreter.ManagedMemory, _variableRepository);

                interpreter.Run(textScript.Text);
                textOutput.Text += "Jiahu script finished." + Environment.NewLine;

                SetTabWithUpdate(tabOutput);
                SetTabWithUpdate(tabMemory);
                PopulateMemoryView(interpreter.ManagedMemory);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Script Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textOutput.Text += exception.Message + Environment.NewLine;

                lvMemory.Items.Clear();
                SetTabWithError(tabOutput);
            }
        }

        private void PrintToScreen(string message)
        {
            textResult.Text += message + Environment.NewLine;
            SetTabWithUpdate(tabResult);
        }

        private void menuStripGrammarTree_Click(object sender, EventArgs e)
        {
            DrawParseTree();
        }

        private void menuItemEditCut_Click(object sender, EventArgs e)
        {
            textScript.Cut();
        }

        private void menuItemEditCopy_Click(object sender, EventArgs e)
        {
            textScript.Copy();
        }

        private void menuItemEditPaste_Click(object sender, EventArgs e)
        {
            textScript.Paste();
        }

        private void menuStripExternalFunctions_Click(object sender, EventArgs e)
        {
            using (ExternalFunctionsWindow window = new ExternalFunctionsWindow(new FunctionRegister()))
            {
                window.ShowDialog(this);
            }
        }

        private void menuStripExternalObjects_Click(object sender, EventArgs e)
        {
            using (ExternalObjectsWindow window = new ExternalObjectsWindow(_variableRepository.Select(x => x.Value).ToList()))
            {
                window.ShowDialog(this);
            }
        }
    }
}