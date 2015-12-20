namespace JiahuScriptRunner
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.textScript = new System.Windows.Forms.TextBox();
            this.buttonRunScript = new System.Windows.Forms.Button();
            this.tabResults = new System.Windows.Forms.TabControl();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.textResult = new System.Windows.Forms.TextBox();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.tabGrammarTree = new System.Windows.Forms.TabPage();
            this.tabMemory = new System.Windows.Forms.TabPage();
            this.lvMemory = new System.Windows.Forms.ListView();
            this.chScope = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSymbolType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSymbolDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSymbolValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilTabs = new System.Windows.Forms.ImageList(this.components);
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.pictureGrammarTree = new System.Windows.Forms.PictureBox();
            this.menuStripCompile = new System.Windows.Forms.ToolStripButton();
            this.menuStripGrammarTree = new System.Windows.Forms.ToolStripButton();
            this.menuStripRun = new System.Windows.Forms.ToolStripButton();
            this.menuStripExternalFunctions = new System.Windows.Forms.ToolStripButton();
            this.menuStripExternalObjects = new System.Windows.Forms.ToolStripButton();
            this.menuItemFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildCompile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildGrammarTree = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.tabResults.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.tabGrammarTree.SuspendLayout();
            this.tabMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGrammarTree)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemBuild,
            this.hELPToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1045, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFileOpen,
            this.menuItemFileSaveAs,
            this.menuItemFileSave,
            this.toolStripSeparator1,
            this.menuItemFileExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(47, 24);
            this.menuItemFile.Text = "FILE";
            // 
            // menuItemFileSaveAs
            // 
            this.menuItemFileSaveAs.Name = "menuItemFileSaveAs";
            this.menuItemFileSaveAs.Size = new System.Drawing.Size(173, 26);
            this.menuItemFileSaveAs.Text = "Save As...";
            this.menuItemFileSaveAs.Click += new System.EventHandler(this.menuItemFileSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEditCut,
            this.menuItemEditCopy,
            this.menuItemEditPaste});
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(52, 24);
            this.menuItemEdit.Text = "EDIT";
            // 
            // menuItemBuild
            // 
            this.menuItemBuild.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBuildCompile,
            this.menuItemBuildGrammarTree,
            this.menuItemBuildRun});
            this.menuItemBuild.Name = "menuItemBuild";
            this.menuItemBuild.Size = new System.Drawing.Size(62, 24);
            this.menuItemBuild.Text = "BUILD";
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripCompile,
            this.menuStripGrammarTree,
            this.menuStripRun,
            this.toolStripSeparator,
            this.menuStripExternalFunctions,
            this.menuStripExternalObjects});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1045, 27);
            this.toolStrip.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 525);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1045, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 55);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.textScript);
            this.splitMain.Panel1.Controls.Add(this.buttonRunScript);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tabResults);
            this.splitMain.Size = new System.Drawing.Size(1045, 470);
            this.splitMain.SplitterDistance = 270;
            this.splitMain.TabIndex = 3;
            // 
            // textScript
            // 
            this.textScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textScript.Location = new System.Drawing.Point(4, 0);
            this.textScript.Multiline = true;
            this.textScript.Name = "textScript";
            this.textScript.Size = new System.Drawing.Size(1038, 230);
            this.textScript.TabIndex = 1;
            this.textScript.TextChanged += new System.EventHandler(this.textScript_TextChanged);
            // 
            // buttonRunScript
            // 
            this.buttonRunScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunScript.Location = new System.Drawing.Point(944, 236);
            this.buttonRunScript.Name = "buttonRunScript";
            this.buttonRunScript.Size = new System.Drawing.Size(98, 27);
            this.buttonRunScript.TabIndex = 0;
            this.buttonRunScript.Text = "Run Script";
            this.buttonRunScript.UseVisualStyleBackColor = true;
            this.buttonRunScript.Click += new System.EventHandler(this.buttonRunScript_Click);
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.tabResult);
            this.tabResults.Controls.Add(this.tabOutput);
            this.tabResults.Controls.Add(this.tabGrammarTree);
            this.tabResults.Controls.Add(this.tabMemory);
            this.tabResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResults.ImageList = this.ilTabs;
            this.tabResults.Location = new System.Drawing.Point(0, 0);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.Size = new System.Drawing.Size(1045, 196);
            this.tabResults.TabIndex = 0;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.textResult);
            this.tabResult.Location = new System.Drawing.Point(4, 25);
            this.tabResult.Name = "tabResult";
            this.tabResult.Size = new System.Drawing.Size(1037, 167);
            this.tabResult.TabIndex = 1;
            this.tabResult.Text = "Result";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // textResult
            // 
            this.textResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textResult.Location = new System.Drawing.Point(0, 0);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(1037, 167);
            this.textResult.TabIndex = 0;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.textOutput);
            this.tabOutput.Location = new System.Drawing.Point(4, 25);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(1037, 167);
            this.tabOutput.TabIndex = 0;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // textOutput
            // 
            this.textOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOutput.Location = new System.Drawing.Point(3, 3);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(1031, 161);
            this.textOutput.TabIndex = 0;
            // 
            // tabGrammarTree
            // 
            this.tabGrammarTree.Controls.Add(this.pictureGrammarTree);
            this.tabGrammarTree.Location = new System.Drawing.Point(4, 25);
            this.tabGrammarTree.Name = "tabGrammarTree";
            this.tabGrammarTree.Size = new System.Drawing.Size(1037, 167);
            this.tabGrammarTree.TabIndex = 2;
            this.tabGrammarTree.Text = "Grammar Tree";
            this.tabGrammarTree.UseVisualStyleBackColor = true;
            // 
            // tabMemory
            // 
            this.tabMemory.Controls.Add(this.lvMemory);
            this.tabMemory.Location = new System.Drawing.Point(4, 25);
            this.tabMemory.Name = "tabMemory";
            this.tabMemory.Size = new System.Drawing.Size(1037, 167);
            this.tabMemory.TabIndex = 3;
            this.tabMemory.Text = "Memory";
            this.tabMemory.UseVisualStyleBackColor = true;
            // 
            // lvMemory
            // 
            this.lvMemory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chScope,
            this.chName,
            this.chSymbolType,
            this.chSymbolDataType,
            this.chSymbolValue});
            this.lvMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMemory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMemory.Location = new System.Drawing.Point(0, 0);
            this.lvMemory.MultiSelect = false;
            this.lvMemory.Name = "lvMemory";
            this.lvMemory.Size = new System.Drawing.Size(1037, 167);
            this.lvMemory.TabIndex = 0;
            this.lvMemory.UseCompatibleStateImageBehavior = false;
            this.lvMemory.View = System.Windows.Forms.View.Details;
            // 
            // chScope
            // 
            this.chScope.Text = "Scope";
            this.chScope.Width = 209;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 201;
            // 
            // chSymbolType
            // 
            this.chSymbolType.Text = "Symbol Type";
            this.chSymbolType.Width = 182;
            // 
            // chSymbolDataType
            // 
            this.chSymbolDataType.Text = "Symbol Data Type";
            this.chSymbolDataType.Width = 181;
            // 
            // chSymbolValue
            // 
            this.chSymbolValue.Text = "Symbol Value";
            this.chSymbolValue.Width = 171;
            // 
            // ilTabs
            // 
            this.ilTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTabs.ImageStream")));
            this.ilTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTabs.Images.SetKeyName(0, "error");
            this.ilTabs.Images.SetKeyName(1, "info");
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // pictureGrammarTree
            // 
            this.pictureGrammarTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureGrammarTree.Location = new System.Drawing.Point(0, 0);
            this.pictureGrammarTree.Name = "pictureGrammarTree";
            this.pictureGrammarTree.Size = new System.Drawing.Size(1037, 167);
            this.pictureGrammarTree.TabIndex = 0;
            this.pictureGrammarTree.TabStop = false;
            // 
            // menuStripCompile
            // 
            this.menuStripCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuStripCompile.Image = global::JiahuScriptRunner.Properties.Resources.table_refresh;
            this.menuStripCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuStripCompile.Name = "menuStripCompile";
            this.menuStripCompile.Size = new System.Drawing.Size(24, 24);
            this.menuStripCompile.ToolTipText = "Compile";
            // 
            // menuStripGrammarTree
            // 
            this.menuStripGrammarTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuStripGrammarTree.Image = global::JiahuScriptRunner.Properties.Resources.chart_organisation;
            this.menuStripGrammarTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuStripGrammarTree.Name = "menuStripGrammarTree";
            this.menuStripGrammarTree.Size = new System.Drawing.Size(24, 24);
            this.menuStripGrammarTree.ToolTipText = "Show Grammar Tree";
            this.menuStripGrammarTree.Click += new System.EventHandler(this.menuStripGrammarTree_Click);
            // 
            // menuStripRun
            // 
            this.menuStripRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuStripRun.Image = global::JiahuScriptRunner.Properties.Resources.script_lightning;
            this.menuStripRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuStripRun.Name = "menuStripRun";
            this.menuStripRun.Size = new System.Drawing.Size(24, 24);
            this.menuStripRun.ToolTipText = "Run Script";
            // 
            // menuStripExternalFunctions
            // 
            this.menuStripExternalFunctions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuStripExternalFunctions.Image = global::JiahuScriptRunner.Properties.Resources.plugin;
            this.menuStripExternalFunctions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuStripExternalFunctions.Name = "menuStripExternalFunctions";
            this.menuStripExternalFunctions.Size = new System.Drawing.Size(24, 24);
            this.menuStripExternalFunctions.ToolTipText = "View External Functions";
            this.menuStripExternalFunctions.Click += new System.EventHandler(this.menuStripExternalFunctions_Click);
            // 
            // menuStripExternalObjects
            // 
            this.menuStripExternalObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuStripExternalObjects.Image = global::JiahuScriptRunner.Properties.Resources.brick;
            this.menuStripExternalObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuStripExternalObjects.Name = "menuStripExternalObjects";
            this.menuStripExternalObjects.Size = new System.Drawing.Size(24, 24);
            this.menuStripExternalObjects.ToolTipText = "View External Objects";
            this.menuStripExternalObjects.Click += new System.EventHandler(this.menuStripExternalObjects_Click);
            // 
            // menuItemFileOpen
            // 
            this.menuItemFileOpen.Image = global::JiahuScriptRunner.Properties.Resources.page_white;
            this.menuItemFileOpen.Name = "menuItemFileOpen";
            this.menuItemFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemFileOpen.Size = new System.Drawing.Size(173, 26);
            this.menuItemFileOpen.Text = "Open";
            this.menuItemFileOpen.Click += new System.EventHandler(this.menuItemFileOpen_Click);
            // 
            // menuItemFileSave
            // 
            this.menuItemFileSave.Image = global::JiahuScriptRunner.Properties.Resources.page_save;
            this.menuItemFileSave.Name = "menuItemFileSave";
            this.menuItemFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemFileSave.Size = new System.Drawing.Size(173, 26);
            this.menuItemFileSave.Text = "Save";
            this.menuItemFileSave.Click += new System.EventHandler(this.menuItemFileSave_Click);
            // 
            // menuItemFileExit
            // 
            this.menuItemFileExit.Image = global::JiahuScriptRunner.Properties.Resources.cross;
            this.menuItemFileExit.Name = "menuItemFileExit";
            this.menuItemFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuItemFileExit.Size = new System.Drawing.Size(173, 26);
            this.menuItemFileExit.Text = "Exit";
            this.menuItemFileExit.Click += new System.EventHandler(this.menuItemFileExit_Click);
            // 
            // menuItemEditCut
            // 
            this.menuItemEditCut.Image = global::JiahuScriptRunner.Properties.Resources.cut;
            this.menuItemEditCut.Name = "menuItemEditCut";
            this.menuItemEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuItemEditCut.Size = new System.Drawing.Size(169, 26);
            this.menuItemEditCut.Text = "Cut";
            this.menuItemEditCut.Click += new System.EventHandler(this.menuItemEditCut_Click);
            // 
            // menuItemEditCopy
            // 
            this.menuItemEditCopy.Image = global::JiahuScriptRunner.Properties.Resources.page_copy;
            this.menuItemEditCopy.Name = "menuItemEditCopy";
            this.menuItemEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuItemEditCopy.Size = new System.Drawing.Size(169, 26);
            this.menuItemEditCopy.Text = "Copy";
            this.menuItemEditCopy.Click += new System.EventHandler(this.menuItemEditCopy_Click);
            // 
            // menuItemEditPaste
            // 
            this.menuItemEditPaste.Image = global::JiahuScriptRunner.Properties.Resources.paste_plain;
            this.menuItemEditPaste.Name = "menuItemEditPaste";
            this.menuItemEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuItemEditPaste.Size = new System.Drawing.Size(169, 26);
            this.menuItemEditPaste.Text = "Paste";
            this.menuItemEditPaste.Click += new System.EventHandler(this.menuItemEditPaste_Click);
            // 
            // menuItemBuildCompile
            // 
            this.menuItemBuildCompile.Image = global::JiahuScriptRunner.Properties.Resources.table_refresh;
            this.menuItemBuildCompile.Name = "menuItemBuildCompile";
            this.menuItemBuildCompile.Size = new System.Drawing.Size(231, 26);
            this.menuItemBuildCompile.Text = "Compile";
            this.menuItemBuildCompile.Click += new System.EventHandler(this.menuItemBuildCompile_Click);
            // 
            // menuItemBuildGrammarTree
            // 
            this.menuItemBuildGrammarTree.Image = global::JiahuScriptRunner.Properties.Resources.chart_organisation;
            this.menuItemBuildGrammarTree.Name = "menuItemBuildGrammarTree";
            this.menuItemBuildGrammarTree.Size = new System.Drawing.Size(231, 26);
            this.menuItemBuildGrammarTree.Text = "Display Grammar Tree";
            this.menuItemBuildGrammarTree.Click += new System.EventHandler(this.menuItemBuildGrammarTree_Click);
            // 
            // menuItemBuildRun
            // 
            this.menuItemBuildRun.Image = global::JiahuScriptRunner.Properties.Resources.script_lightning;
            this.menuItemBuildRun.Name = "menuItemBuildRun";
            this.menuItemBuildRun.Size = new System.Drawing.Size(231, 26);
            this.menuItemBuildRun.Text = "Run";
            this.menuItemBuildRun.Click += new System.EventHandler(this.menuItemBuildRun_Click);
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1045, 547);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainWindow";
            this.Text = "Jiahu Script Runner";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.tabResult.PerformLayout();
            this.tabOutput.ResumeLayout(false);
            this.tabOutput.PerformLayout();
            this.tabGrammarTree.ResumeLayout(false);
            this.tabMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureGrammarTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemFileExit;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TextBox textScript;
        private System.Windows.Forms.Button buttonRunScript;
        private System.Windows.Forms.TabControl tabResults;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditCut;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditCopy;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditPaste;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.TabPage tabGrammarTree;
        private System.Windows.Forms.PictureBox pictureGrammarTree;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuild;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildCompile;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildGrammarTree;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildRun;
        private System.Windows.Forms.ToolStripMenuItem menuItemFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuItemFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton menuStripCompile;
        private System.Windows.Forms.ToolStripButton menuStripGrammarTree;
        private System.Windows.Forms.ToolStripButton menuStripRun;
        private System.Windows.Forms.TabPage tabMemory;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.ListView lvMemory;
        private System.Windows.Forms.ColumnHeader chScope;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chSymbolType;
        private System.Windows.Forms.ColumnHeader chSymbolDataType;
        private System.Windows.Forms.ColumnHeader chSymbolValue;
        private System.Windows.Forms.ImageList ilTabs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton menuStripExternalFunctions;
        private System.Windows.Forms.ToolStripButton menuStripExternalObjects;
    }
}