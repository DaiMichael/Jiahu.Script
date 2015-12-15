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
            this.buttonClose = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerFunctions = new DevExpress.XtraEditors.SplitContainerControl();
            this.lvFunctions = new System.Windows.Forms.ListView();
            this.labelFunctionDescription = new DevExpress.XtraEditors.LabelControl();
            this.labelDescription = new DevExpress.XtraEditors.LabelControl();
            this.labelDescriptionWrapper = new DevExpress.XtraEditors.LabelControl();
            this.lvParameters = new System.Windows.Forms.ListView();
            this.chOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOptional = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFunctions)).BeginInit();
            this.splitContainerFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(838, 452);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
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
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerFunctions);
            this.splitContainerMain.Panel1.Text = "Panel1";
            this.splitContainerMain.Panel2.Controls.Add(this.lvParameters);
            this.splitContainerMain.Panel2.Text = "Panel2";
            this.splitContainerMain.Size = new System.Drawing.Size(925, 446);
            this.splitContainerMain.SplitterPosition = 222;
            this.splitContainerMain.TabIndex = 1;
            this.splitContainerMain.Text = "splitContainerControl1";
            // 
            // splitContainerFunctions
            // 
            this.splitContainerFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFunctions.Horizontal = false;
            this.splitContainerFunctions.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFunctions.Name = "splitContainerFunctions";
            this.splitContainerFunctions.Panel1.Controls.Add(this.lvFunctions);
            this.splitContainerFunctions.Panel1.Text = "Panel1";
            this.splitContainerFunctions.Panel2.Controls.Add(this.labelFunctionDescription);
            this.splitContainerFunctions.Panel2.Controls.Add(this.labelDescription);
            this.splitContainerFunctions.Panel2.Controls.Add(this.labelDescriptionWrapper);
            this.splitContainerFunctions.Panel2.Text = "Panel2";
            this.splitContainerFunctions.Size = new System.Drawing.Size(222, 446);
            this.splitContainerFunctions.SplitterPosition = 343;
            this.splitContainerFunctions.TabIndex = 0;
            // 
            // lvFunctions
            // 
            this.lvFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFunctions.FullRowSelect = true;
            this.lvFunctions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvFunctions.HideSelection = false;
            this.lvFunctions.Location = new System.Drawing.Point(0, 0);
            this.lvFunctions.MultiSelect = false;
            this.lvFunctions.Name = "lvFunctions";
            this.lvFunctions.Size = new System.Drawing.Size(222, 343);
            this.lvFunctions.TabIndex = 1;
            this.lvFunctions.UseCompatibleStateImageBehavior = false;
            this.lvFunctions.View = System.Windows.Forms.View.Details;
            this.lvFunctions.SelectedIndexChanged += new System.EventHandler(this.lvFunctions_SelectedItemChanged);
            // 
            // labelFunctionDescription
            // 
            this.labelFunctionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFunctionDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelFunctionDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelFunctionDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelFunctionDescription.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelFunctionDescription.Location = new System.Drawing.Point(2, 23);
            this.labelFunctionDescription.Name = "labelFunctionDescription";
            this.labelFunctionDescription.Size = new System.Drawing.Size(218, 73);
            this.labelFunctionDescription.TabIndex = 3;
            // 
            // labelDescription
            // 
            this.labelDescription.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(3, 3);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(115, 13);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "Function Description";
            // 
            // labelDescriptionWrapper
            // 
            this.labelDescriptionWrapper.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelDescriptionWrapper.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelDescriptionWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDescriptionWrapper.Location = new System.Drawing.Point(0, 0);
            this.labelDescriptionWrapper.Name = "labelDescriptionWrapper";
            this.labelDescriptionWrapper.Size = new System.Drawing.Size(222, 98);
            this.labelDescriptionWrapper.TabIndex = 0;
            // 
            // lvParameters
            // 
            this.lvParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOrder,
            this.chName,
            this.chType,
            this.chOptional,
            this.chDescription});
            this.lvParameters.Location = new System.Drawing.Point(0, 0);
            this.lvParameters.Name = "lvParameters";
            this.lvParameters.Size = new System.Drawing.Size(698, 446);
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
            // ExternalFunctionsWindow
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 487);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExternalFunctionsWindow";
            this.Text = "External Functions";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFunctions)).EndInit();
            this.splitContainerFunctions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonClose;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerMain;
        private System.Windows.Forms.ListView lvParameters;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerFunctions;
        private System.Windows.Forms.ListView lvFunctions;
        private System.Windows.Forms.ColumnHeader chOrder;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chOptional;
        private System.Windows.Forms.ColumnHeader chDescription;
        private DevExpress.XtraEditors.LabelControl labelFunctionDescription;
        private DevExpress.XtraEditors.LabelControl labelDescription;
        private DevExpress.XtraEditors.LabelControl labelDescriptionWrapper;
    }
}