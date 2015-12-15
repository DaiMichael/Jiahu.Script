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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ribbonMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonExit = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.barButtonRun = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonCompile = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonViewTree = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonProperties = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonExternalFunctions = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExternalObjects = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupScriptActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupUtilities = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.buttonViewParseTree = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCompile = new DevExpress.XtraEditors.SimpleButton();
            this.buttonRun = new DevExpress.XtraEditors.SimpleButton();
            this.editScript = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabOutput = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabResults = new DevExpress.XtraTab.XtraTabPage();
            this.editScriptOutput = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabConsole = new DevExpress.XtraTab.XtraTabPage();
            this.editOutput = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabParseTree = new DevExpress.XtraTab.XtraTabPage();
            this.pictureParseTree = new DevExpress.XtraEditors.PictureEdit();
            this.xtraTabMemory = new DevExpress.XtraTab.XtraTabPage();
            this.treeMemory = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editScript.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabOutput)).BeginInit();
            this.xtraTabOutput.SuspendLayout();
            this.xtraTabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editScriptOutput.Properties)).BeginInit();
            this.xtraTabConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editOutput.Properties)).BeginInit();
            this.xtraTabParseTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureParseTree.Properties)).BeginInit();
            this.xtraTabMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMemory)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMenu
            // 
            this.ribbonMenu.ExpandCollapseItem.Id = 0;
            this.ribbonMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMenu.ExpandCollapseItem,
            this.barButtonExit,
            this.ribbonGalleryBarItem1,
            this.barButtonRun,
            this.barButtonCompile,
            this.barButtonViewTree,
            this.barButtonProperties,
            this.barButtonSaveAs,
            this.barButtonSave,
            this.barButtonOpen,
            this.barButtonExternalFunctions,
            this.barButtonItemExternalObjects});
            this.ribbonMenu.Location = new System.Drawing.Point(0, 0);
            this.ribbonMenu.MaxItemId = 13;
            this.ribbonMenu.Name = "ribbonMenu";
            this.ribbonMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageHome});
            this.ribbonMenu.ShowToolbarCustomizeItem = false;
            this.ribbonMenu.Size = new System.Drawing.Size(1442, 117);
            this.ribbonMenu.StatusBar = this.ribbonStatusBar;
            this.ribbonMenu.Toolbar.ShowCustomizeItem = false;
            this.ribbonMenu.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barButtonExit
            // 
            this.barButtonExit.Caption = "Exit";
            this.barButtonExit.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonExit.Glyph")));
            this.barButtonExit.Id = 1;
            this.barButtonExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonExit.LargeGlyph")));
            this.barButtonExit.Name = "barButtonExit";
            this.barButtonExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonExit_ItemClick);
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Id = 3;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // barButtonRun
            // 
            this.barButtonRun.Caption = "Run";
            this.barButtonRun.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonRun.Glyph")));
            this.barButtonRun.Id = 4;
            this.barButtonRun.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonRun.LargeGlyph")));
            this.barButtonRun.Name = "barButtonRun";
            this.barButtonRun.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonRun_ItemClick);
            // 
            // barButtonCompile
            // 
            this.barButtonCompile.Caption = "Compile";
            this.barButtonCompile.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonCompile.Glyph")));
            this.barButtonCompile.Id = 5;
            this.barButtonCompile.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonCompile.LargeGlyph")));
            this.barButtonCompile.Name = "barButtonCompile";
            this.barButtonCompile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonCompile_ItemClick);
            // 
            // barButtonViewTree
            // 
            this.barButtonViewTree.Caption = "View Parse Tree";
            this.barButtonViewTree.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonViewTree.Glyph")));
            this.barButtonViewTree.Id = 6;
            this.barButtonViewTree.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonViewTree.LargeGlyph")));
            this.barButtonViewTree.Name = "barButtonViewTree";
            this.barButtonViewTree.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonViewTree_ItemClick);
            // 
            // barButtonProperties
            // 
            this.barButtonProperties.Caption = "Properties";
            this.barButtonProperties.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonProperties.Glyph")));
            this.barButtonProperties.Id = 7;
            this.barButtonProperties.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonProperties.LargeGlyph")));
            this.barButtonProperties.Name = "barButtonProperties";
            this.barButtonProperties.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.buttonProperties_ItemClick);
            // 
            // barButtonSaveAs
            // 
            this.barButtonSaveAs.Caption = "Save As";
            this.barButtonSaveAs.Enabled = false;
            this.barButtonSaveAs.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonSaveAs.Glyph")));
            this.barButtonSaveAs.Id = 8;
            this.barButtonSaveAs.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonSaveAs.LargeGlyph")));
            this.barButtonSaveAs.Name = "barButtonSaveAs";
            this.barButtonSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonSaveAs_ItemClick);
            // 
            // barButtonSave
            // 
            this.barButtonSave.Caption = "Save";
            this.barButtonSave.Enabled = false;
            this.barButtonSave.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonSave.Glyph")));
            this.barButtonSave.Id = 9;
            this.barButtonSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonSave.LargeGlyph")));
            this.barButtonSave.Name = "barButtonSave";
            this.barButtonSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonSave_ItemClick);
            // 
            // barButtonOpen
            // 
            this.barButtonOpen.Caption = "Open";
            this.barButtonOpen.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonOpen.Glyph")));
            this.barButtonOpen.Id = 10;
            this.barButtonOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonOpen.LargeGlyph")));
            this.barButtonOpen.Name = "barButtonOpen";
            this.barButtonOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonOpen_ItemClick);
            // 
            // barButtonExternalFunctions
            // 
            this.barButtonExternalFunctions.Caption = "External Functions";
            this.barButtonExternalFunctions.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonExternalFunctions.Glyph")));
            this.barButtonExternalFunctions.Id = 11;
            this.barButtonExternalFunctions.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonExternalFunctions.LargeGlyph")));
            this.barButtonExternalFunctions.Name = "barButtonExternalFunctions";
            this.barButtonExternalFunctions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonExternalFunctions_ItemClick);
            // 
            // barButtonItemExternalObjects
            // 
            this.barButtonItemExternalObjects.Caption = "External Objects";
            this.barButtonItemExternalObjects.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemExternalObjects.Glyph")));
            this.barButtonItemExternalObjects.Id = 12;
            this.barButtonItemExternalObjects.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemExternalObjects.LargeGlyph")));
            this.barButtonItemExternalObjects.Name = "barButtonItemExternalObjects";
            this.barButtonItemExternalObjects.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExternalObjects_ItemClick);
            // 
            // ribbonPageHome
            // 
            this.ribbonPageHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupFile,
            this.ribbonPageGroupScriptActions,
            this.ribbonPageGroupUtilities});
            this.ribbonPageHome.Name = "ribbonPageHome";
            this.ribbonPageHome.Text = "Home";
            // 
            // ribbonPageGroupFile
            // 
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonOpen);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonSaveAs);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonSave);
            this.ribbonPageGroupFile.ItemLinks.Add(this.barButtonExit);
            this.ribbonPageGroupFile.Name = "ribbonPageGroupFile";
            this.ribbonPageGroupFile.Text = "File";
            // 
            // ribbonPageGroupScriptActions
            // 
            this.ribbonPageGroupScriptActions.ItemLinks.Add(this.barButtonRun);
            this.ribbonPageGroupScriptActions.ItemLinks.Add(this.barButtonCompile);
            this.ribbonPageGroupScriptActions.ItemLinks.Add(this.barButtonViewTree);
            this.ribbonPageGroupScriptActions.Name = "ribbonPageGroupScriptActions";
            this.ribbonPageGroupScriptActions.Text = "Script Actions";
            // 
            // ribbonPageGroupUtilities
            // 
            this.ribbonPageGroupUtilities.ItemLinks.Add(this.barButtonExternalFunctions);
            this.ribbonPageGroupUtilities.ItemLinks.Add(this.barButtonItemExternalObjects);
            this.ribbonPageGroupUtilities.ItemLinks.Add(this.barButtonProperties);
            this.ribbonPageGroupUtilities.Name = "ribbonPageGroupUtilities";
            this.ribbonPageGroupUtilities.Text = "Utilities";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 811);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonMenu;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1442, 27);
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Horizontal = false;
            this.splitMain.Location = new System.Drawing.Point(0, 117);
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1.Controls.Add(this.buttonViewParseTree);
            this.splitMain.Panel1.Controls.Add(this.buttonCompile);
            this.splitMain.Panel1.Controls.Add(this.buttonRun);
            this.splitMain.Panel1.Controls.Add(this.editScript);
            this.splitMain.Panel1.Text = "PanelTop";
            this.splitMain.Panel2.Controls.Add(this.xtraTabOutput);
            this.splitMain.Panel2.Text = "PanelBottom";
            this.splitMain.Size = new System.Drawing.Size(1442, 694);
            this.splitMain.SplitterPosition = 339;
            this.splitMain.TabIndex = 2;
            // 
            // buttonViewParseTree
            // 
            this.buttonViewParseTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewParseTree.Enabled = false;
            this.buttonViewParseTree.Location = new System.Drawing.Point(1193, 315);
            this.buttonViewParseTree.Name = "buttonViewParseTree";
            this.buttonViewParseTree.Size = new System.Drawing.Size(75, 23);
            this.buttonViewParseTree.TabIndex = 3;
            this.buttonViewParseTree.Text = "View Tree";
            this.buttonViewParseTree.Click += new System.EventHandler(this.buttonViewParseTree_Click);
            // 
            // buttonCompile
            // 
            this.buttonCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCompile.Enabled = false;
            this.buttonCompile.Location = new System.Drawing.Point(1274, 315);
            this.buttonCompile.Name = "buttonCompile";
            this.buttonCompile.Size = new System.Drawing.Size(75, 23);
            this.buttonCompile.TabIndex = 2;
            this.buttonCompile.Text = "Compile";
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.Enabled = false;
            this.buttonRun.Location = new System.Drawing.Point(1355, 315);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "Run";
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // editScript
            // 
            this.editScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editScript.Location = new System.Drawing.Point(4, 3);
            this.editScript.MenuManager = this.ribbonMenu;
            this.editScript.Name = "editScript";
            this.editScript.Size = new System.Drawing.Size(1433, 301);
            this.editScript.TabIndex = 0;
            this.editScript.EditValueChanged += new System.EventHandler(this.editScript_EditValueChanged);
            // 
            // xtraTabOutput
            // 
            this.xtraTabOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabOutput.Location = new System.Drawing.Point(3, 1);
            this.xtraTabOutput.Name = "xtraTabOutput";
            this.xtraTabOutput.SelectedTabPage = this.xtraTabResults;
            this.xtraTabOutput.Size = new System.Drawing.Size(1439, 349);
            this.xtraTabOutput.TabIndex = 0;
            this.xtraTabOutput.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabResults,
            this.xtraTabConsole,
            this.xtraTabParseTree,
            this.xtraTabMemory});
            this.xtraTabOutput.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabScript_SelectedPageChanged);
            // 
            // xtraTabResults
            // 
            this.xtraTabResults.Controls.Add(this.editScriptOutput);
            this.xtraTabResults.Name = "xtraTabResults";
            this.xtraTabResults.Size = new System.Drawing.Size(1433, 321);
            this.xtraTabResults.Text = "Output";
            // 
            // editScriptOutput
            // 
            this.editScriptOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editScriptOutput.Location = new System.Drawing.Point(0, 0);
            this.editScriptOutput.MenuManager = this.ribbonMenu;
            this.editScriptOutput.Name = "editScriptOutput";
            this.editScriptOutput.Properties.ReadOnly = true;
            this.editScriptOutput.Size = new System.Drawing.Size(1433, 321);
            this.editScriptOutput.TabIndex = 0;
            // 
            // xtraTabConsole
            // 
            this.xtraTabConsole.Appearance.Header.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.xtraTabConsole.Appearance.PageClient.BackColor = System.Drawing.Color.Maroon;
            this.xtraTabConsole.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabConsole.Controls.Add(this.editOutput);
            this.xtraTabConsole.Name = "xtraTabConsole";
            this.xtraTabConsole.Size = new System.Drawing.Size(1433, 321);
            this.xtraTabConsole.Text = "Console";
            // 
            // editOutput
            // 
            this.editOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editOutput.Location = new System.Drawing.Point(3, 3);
            this.editOutput.MenuManager = this.ribbonMenu;
            this.editOutput.Name = "editOutput";
            this.editOutput.Properties.ReadOnly = true;
            this.editOutput.Size = new System.Drawing.Size(1427, 369);
            this.editOutput.TabIndex = 1;
            // 
            // xtraTabParseTree
            // 
            this.xtraTabParseTree.Controls.Add(this.pictureParseTree);
            this.xtraTabParseTree.Name = "xtraTabParseTree";
            this.xtraTabParseTree.Size = new System.Drawing.Size(1433, 321);
            this.xtraTabParseTree.Text = "Parse Tree View";
            // 
            // pictureParseTree
            // 
            this.pictureParseTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureParseTree.Location = new System.Drawing.Point(3, 3);
            this.pictureParseTree.MenuManager = this.ribbonMenu;
            this.pictureParseTree.Name = "pictureParseTree";
            this.pictureParseTree.Properties.ReadOnly = true;
            this.pictureParseTree.Properties.ShowScrollBars = true;
            this.pictureParseTree.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.pictureParseTree.Size = new System.Drawing.Size(1427, 369);
            this.pictureParseTree.TabIndex = 0;
            // 
            // xtraTabMemory
            // 
            this.xtraTabMemory.Controls.Add(this.treeMemory);
            this.xtraTabMemory.Name = "xtraTabMemory";
            this.xtraTabMemory.Size = new System.Drawing.Size(1433, 321);
            this.xtraTabMemory.Text = "Memory";
            // 
            // treeMemory
            // 
            this.treeMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMemory.Location = new System.Drawing.Point(0, 0);
            this.treeMemory.Name = "treeMemory";
            this.treeMemory.OptionsBehavior.Editable = false;
            this.treeMemory.Size = new System.Drawing.Size(1433, 321);
            this.treeMemory.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 838);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Jiahu Script";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editScript.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabOutput)).EndInit();
            this.xtraTabOutput.ResumeLayout(false);
            this.xtraTabResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editScriptOutput.Properties)).EndInit();
            this.xtraTabConsole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editOutput.Properties)).EndInit();
            this.xtraTabParseTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureParseTree.Properties)).EndInit();
            this.xtraTabMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMemory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFile;
        private DevExpress.XtraBars.BarButtonItem barButtonExit;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private DevExpress.XtraEditors.SimpleButton buttonCompile;
        private DevExpress.XtraEditors.SimpleButton buttonRun;
        private DevExpress.XtraEditors.MemoEdit editScript;
        private DevExpress.XtraTab.XtraTabControl xtraTabOutput;
        private DevExpress.XtraTab.XtraTabPage xtraTabResults;
        private DevExpress.XtraTab.XtraTabPage xtraTabConsole;
        private DevExpress.XtraTab.XtraTabPage xtraTabParseTree;
        private DevExpress.XtraEditors.MemoEdit editScriptOutput;
        private DevExpress.XtraEditors.MemoEdit editOutput;
        private DevExpress.XtraEditors.PictureEdit pictureParseTree;
        private DevExpress.XtraEditors.SimpleButton buttonViewParseTree;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupScriptActions;
        private DevExpress.XtraBars.BarButtonItem barButtonRun;
        private DevExpress.XtraBars.BarButtonItem barButtonCompile;
        private DevExpress.XtraBars.BarButtonItem barButtonViewTree;
        private DevExpress.XtraBars.BarButtonItem barButtonProperties;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupUtilities;
        private DevExpress.XtraBars.BarButtonItem barButtonSaveAs;
        private DevExpress.XtraBars.BarButtonItem barButtonSave;
        private DevExpress.XtraBars.BarButtonItem barButtonOpen;
        private DevExpress.XtraTab.XtraTabPage xtraTabMemory;
        private DevExpress.XtraTreeList.TreeList treeMemory;
        private DevExpress.XtraBars.BarButtonItem barButtonExternalFunctions;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExternalObjects;
    }
}

