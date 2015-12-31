namespace JiahuScriptRunner.Windows
{
    partial class ExternalObjectsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalObjectsWindow));
            this.buttonClose = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.lvExternalObjects = new System.Windows.Forms.ListView();
            this.splitObjectDataView = new System.Windows.Forms.SplitContainer();
            this.treeObjectView = new System.Windows.Forms.TreeView();
            this.ilTreeView = new System.Windows.Forms.ImageList(this.components);
            this.lvDataView = new System.Windows.Forms.ListView();
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitObjectDataView)).BeginInit();
            this.splitObjectDataView.Panel1.SuspendLayout();
            this.splitObjectDataView.Panel2.SuspendLayout();
            this.splitObjectDataView.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(1572, 720);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 28);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.lvExternalObjects);
            this.splitContainerMain.Panel1.Text = "Panel1";
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitObjectDataView);
            this.splitContainerMain.Panel2.Text = "Panel2";
            this.splitContainerMain.Size = new System.Drawing.Size(1688, 713);
            this.splitContainerMain.SplitterDistance = 362;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 1;
            this.splitContainerMain.Text = "splitContainerControl1";
            // 
            // lvExternalObjects
            // 
            this.lvExternalObjects.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvExternalObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvExternalObjects.FullRowSelect = true;
            this.lvExternalObjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvExternalObjects.HideSelection = false;
            this.lvExternalObjects.HoverSelection = true;
            this.lvExternalObjects.Location = new System.Drawing.Point(0, 0);
            this.lvExternalObjects.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvExternalObjects.MultiSelect = false;
            this.lvExternalObjects.Name = "lvExternalObjects";
            this.lvExternalObjects.Size = new System.Drawing.Size(362, 713);
            this.lvExternalObjects.TabIndex = 2;
            this.lvExternalObjects.UseCompatibleStateImageBehavior = false;
            this.lvExternalObjects.View = System.Windows.Forms.View.Details;
            this.lvExternalObjects.SelectedIndexChanged += new System.EventHandler(this.ListViewExternalObjectSelectedIndexChanged);
            // 
            // splitObjectDataView
            // 
            this.splitObjectDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitObjectDataView.Location = new System.Drawing.Point(0, 0);
            this.splitObjectDataView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitObjectDataView.Name = "splitObjectDataView";
            // 
            // splitObjectDataView.Panel1
            // 
            this.splitObjectDataView.Panel1.Controls.Add(this.treeObjectView);
            this.splitObjectDataView.Panel1.Text = "Panel1";
            // 
            // splitObjectDataView.Panel2
            // 
            this.splitObjectDataView.Panel2.Controls.Add(this.lvDataView);
            this.splitObjectDataView.Panel2.Text = "Panel2";
            this.splitObjectDataView.Size = new System.Drawing.Size(1321, 713);
            this.splitObjectDataView.SplitterDistance = 338;
            this.splitObjectDataView.SplitterWidth = 5;
            this.splitObjectDataView.TabIndex = 0;
            this.splitObjectDataView.Text = "splitContainerControl1";
            // 
            // treeObjectView
            // 
            this.treeObjectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeObjectView.HideSelection = false;
            this.treeObjectView.ImageIndex = 0;
            this.treeObjectView.ImageList = this.ilTreeView;
            this.treeObjectView.Location = new System.Drawing.Point(0, 0);
            this.treeObjectView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeObjectView.Name = "treeObjectView";
            this.treeObjectView.SelectedImageIndex = 0;
            this.treeObjectView.Size = new System.Drawing.Size(338, 713);
            this.treeObjectView.TabIndex = 0;
            this.treeObjectView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeObjectView_AfterSelect);
            // 
            // ilTreeView
            // 
            this.ilTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeView.ImageStream")));
            this.ilTreeView.TransparentColor = System.Drawing.Color.Fuchsia;
            this.ilTreeView.Images.SetKeyName(0, "Method");
            this.ilTreeView.Images.SetKeyName(1, "Object");
            this.ilTreeView.Images.SetKeyName(2, "Property");
            // 
            // lvDataView
            // 
            this.lvDataView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chType,
            this.chValue});
            this.lvDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDataView.Location = new System.Drawing.Point(0, 0);
            this.lvDataView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvDataView.Name = "lvDataView";
            this.lvDataView.Size = new System.Drawing.Size(978, 713);
            this.lvDataView.TabIndex = 0;
            this.lvDataView.UseCompatibleStateImageBehavior = false;
            this.lvDataView.View = System.Windows.Forms.View.Details;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 180;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 300;
            // 
            // ExternalObjectsWindow
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1688, 763);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExternalObjectsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "External Functions";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitObjectDataView.Panel1.ResumeLayout(false);
            this.splitObjectDataView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitObjectDataView)).EndInit();
            this.splitObjectDataView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ListView lvExternalObjects;
        private System.Windows.Forms.SplitContainer splitObjectDataView;
        private System.Windows.Forms.TreeView treeObjectView;
        private System.Windows.Forms.ListView lvDataView;
        private System.Windows.Forms.ImageList ilTreeView;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chValue;
    }
}