namespace JiahuScriptRunner.Windows
{
    partial class ExternalFunctionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalFunctionsWindow));
            this.buttonClose = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerFunctions = new System.Windows.Forms.SplitContainer();
            this.lvParameters = new System.Windows.Forms.ListView();
            this.chOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOptional = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvFunctions = new System.Windows.Forms.ListView();
            this.labelDescriptionWrapper = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelFunctionDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFunctions)).BeginInit();
            this.splitContainerFunctions.Panel1.SuspendLayout();
            this.splitContainerFunctions.Panel2.SuspendLayout();
            this.splitContainerFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(1117, 556);
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
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerFunctions);
            this.splitContainerMain.Panel1.Text = "Panel1";
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.lvParameters);
            this.splitContainerMain.Panel2.Text = "Panel2";
            this.splitContainerMain.Size = new System.Drawing.Size(1233, 549);
            this.splitContainerMain.SplitterDistance = 411;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 1;
            this.splitContainerMain.Text = "splitContainerControl1";
            // 
            // splitContainerFunctions
            // 
            this.splitContainerFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFunctions.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFunctions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerFunctions.Name = "splitContainerFunctions";
            this.splitContainerFunctions.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFunctions.Panel1
            // 
            this.splitContainerFunctions.Panel1.Controls.Add(this.lvFunctions);
            this.splitContainerFunctions.Panel1.Text = "Panel1";
            // 
            // splitContainerFunctions.Panel2
            // 
            this.splitContainerFunctions.Panel2.Controls.Add(this.labelFunctionDescription);
            this.splitContainerFunctions.Panel2.Controls.Add(this.labelDescription);
            this.splitContainerFunctions.Panel2.Controls.Add(this.labelDescriptionWrapper);
            this.splitContainerFunctions.Panel2.Text = "Panel2";
            this.splitContainerFunctions.Size = new System.Drawing.Size(411, 549);
            this.splitContainerFunctions.SplitterDistance = 384;
            this.splitContainerFunctions.SplitterWidth = 5;
            this.splitContainerFunctions.TabIndex = 0;
            // 
            // lvParameters
            // 
            this.lvParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOrder,
            this.chName,
            this.chType,
            this.chOptional,
            this.chDescription});
            this.lvParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvParameters.Location = new System.Drawing.Point(0, 0);
            this.lvParameters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvParameters.Name = "lvParameters";
            this.lvParameters.Size = new System.Drawing.Size(817, 549);
            this.lvParameters.TabIndex = 0;
            this.lvParameters.UseCompatibleStateImageBehavior = false;
            this.lvParameters.View = System.Windows.Forms.View.Details;
            // 
            // chOrder
            // 
            this.chOrder.Text = "Order";
            this.chOrder.Width = 40;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 128;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 107;
            // 
            // chOptional
            // 
            this.chOptional.Text = "Optional";
            // 
            // chDescription
            // 
            this.chDescription.Text = "Description";
            this.chDescription.Width = 324;
            // 
            // lvFunctions
            // 
            this.lvFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFunctions.FullRowSelect = true;
            this.lvFunctions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvFunctions.HideSelection = false;
            this.lvFunctions.Location = new System.Drawing.Point(0, 0);
            this.lvFunctions.Margin = new System.Windows.Forms.Padding(4);
            this.lvFunctions.MultiSelect = false;
            this.lvFunctions.Name = "lvFunctions";
            this.lvFunctions.Size = new System.Drawing.Size(411, 384);
            this.lvFunctions.TabIndex = 1;
            this.lvFunctions.UseCompatibleStateImageBehavior = false;
            this.lvFunctions.View = System.Windows.Forms.View.Details;
            this.lvFunctions.SelectedIndexChanged += new System.EventHandler(this.lvFunctions_SelectedItemChanged);
            // 
            // labelDescriptionWrapper
            // 
            this.labelDescriptionWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDescriptionWrapper.Location = new System.Drawing.Point(0, 0);
            this.labelDescriptionWrapper.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescriptionWrapper.Name = "labelDescriptionWrapper";
            this.labelDescriptionWrapper.Size = new System.Drawing.Size(411, 160);
            this.labelDescriptionWrapper.TabIndex = 0;
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(4, 4);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(177, 24);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "Function Description";
            // 
            // labelFunctionDescription
            // 
            this.labelFunctionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFunctionDescription.Location = new System.Drawing.Point(3, 28);
            this.labelFunctionDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFunctionDescription.Name = "labelFunctionDescription";
            this.labelFunctionDescription.Size = new System.Drawing.Size(574, 127);
            this.labelFunctionDescription.TabIndex = 3;
            // 
            // ExternalFunctionsWindow
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 599);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExternalFunctionsWindow";
            this.Text = "External Functions";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerFunctions.Panel1.ResumeLayout(false);
            this.splitContainerFunctions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFunctions)).EndInit();
            this.splitContainerFunctions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ListView lvParameters;
        private System.Windows.Forms.SplitContainer splitContainerFunctions;
        private System.Windows.Forms.ColumnHeader chOrder;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chOptional;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.ListView lvFunctions;
        private System.Windows.Forms.Label labelFunctionDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelDescriptionWrapper;
    }
}