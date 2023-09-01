namespace Rhometer_Torque.View.ExperimentParameters
{
    partial class FrmExperimentSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExperimentSelect));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.BtOk = new DevExpress.XtraEditors.SimpleButton();
            this.BtCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExperimentSelect = new DevExpress.XtraGrid.GridControl();
            this.gridViewExperimentSelect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ExperimentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExperimentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExperimentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExperimentTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Loads = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SampleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SampleMass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CapillaryDiameter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CapillaryLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExperimentSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExperimentSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BtOk);
            this.layoutControl1.Controls.Add(this.BtCancel);
            this.layoutControl1.Controls.Add(this.gridControlExperimentSelect);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(480, 206, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 226);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BtOk
            // 
            this.BtOk.Location = new System.Drawing.Point(627, 192);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(66, 22);
            this.BtOk.StyleController = this.layoutControl1;
            this.BtOk.TabIndex = 7;
            this.BtOk.Text = "确认";
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Location = new System.Drawing.Point(722, 192);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(66, 22);
            this.BtCancel.StyleController = this.layoutControl1;
            this.BtCancel.TabIndex = 6;
            this.BtCancel.Text = "取消";
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // gridControlExperimentSelect
            // 
            this.gridControlExperimentSelect.Location = new System.Drawing.Point(12, 12);
            this.gridControlExperimentSelect.MainView = this.gridViewExperimentSelect;
            this.gridControlExperimentSelect.Name = "gridControlExperimentSelect";
            this.gridControlExperimentSelect.Size = new System.Drawing.Size(776, 166);
            this.gridControlExperimentSelect.TabIndex = 5;
            this.gridControlExperimentSelect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewExperimentSelect});
            // 
            // gridViewExperimentSelect
            // 
            this.gridViewExperimentSelect.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ExperimentID,
            this.ExperimentType,
            this.ExperimentName,
            this.ExperimentTime,
            this.UserName,
            this.Loads,
            this.SampleName,
            this.SampleMass,
            this.CapillaryDiameter,
            this.CapillaryLength});
            this.gridViewExperimentSelect.GridControl = this.gridControlExperimentSelect;
            this.gridViewExperimentSelect.Name = "gridViewExperimentSelect";
            this.gridViewExperimentSelect.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewExperimentSelect.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewExperimentSelect.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewExperimentSelect.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewExperimentSelect.OptionsView.ShowGroupPanel = false;
            this.gridViewExperimentSelect.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewExperimentSelect_CustomColumnDisplayText);
            // 
            // ExperimentID
            // 
            this.ExperimentID.AppearanceCell.Options.UseTextOptions = true;
            this.ExperimentID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExperimentID.AppearanceHeader.Options.UseTextOptions = true;
            this.ExperimentID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExperimentID.Caption = "实验ID";
            this.ExperimentID.FieldName = "ExperimentID";
            this.ExperimentID.Name = "ExperimentID";
            this.ExperimentID.OptionsColumn.ReadOnly = true;
            this.ExperimentID.Visible = true;
            this.ExperimentID.VisibleIndex = 0;
            // 
            // ExperimentType
            // 
            this.ExperimentType.AppearanceCell.Options.UseTextOptions = true;
            this.ExperimentType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExperimentType.AppearanceHeader.Options.UseTextOptions = true;
            this.ExperimentType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExperimentType.Caption = "实验类型";
            this.ExperimentType.FieldName = "ExperimentType";
            this.ExperimentType.Name = "ExperimentType";
            this.ExperimentType.OptionsColumn.ReadOnly = true;
            this.ExperimentType.Visible = true;
            this.ExperimentType.VisibleIndex = 1;
            // 
            // ExperimentName
            // 
            this.ExperimentName.AppearanceCell.Options.UseTextOptions = true;
            this.ExperimentName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExperimentName.AppearanceHeader.Options.UseTextOptions = true;
            this.ExperimentName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExperimentName.Caption = "实验名称";
            this.ExperimentName.FieldName = "ExperimentName";
            this.ExperimentName.Name = "ExperimentName";
            this.ExperimentName.OptionsColumn.ReadOnly = true;
            this.ExperimentName.Visible = true;
            this.ExperimentName.VisibleIndex = 2;
            // 
            // ExperimentTime
            // 
            this.ExperimentTime.AppearanceCell.Options.UseTextOptions = true;
            this.ExperimentTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExperimentTime.AppearanceHeader.Options.UseTextOptions = true;
            this.ExperimentTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExperimentTime.Caption = "实验时间";
            this.ExperimentTime.FieldName = "ExperimentTime";
            this.ExperimentTime.Name = "ExperimentTime";
            this.ExperimentTime.OptionsColumn.ReadOnly = true;
            this.ExperimentTime.Visible = true;
            this.ExperimentTime.VisibleIndex = 3;
            // 
            // UserName
            // 
            this.UserName.AppearanceCell.Options.UseTextOptions = true;
            this.UserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UserName.AppearanceHeader.Options.UseTextOptions = true;
            this.UserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UserName.Caption = "操作者";
            this.UserName.FieldName = "User.UserName";
            this.UserName.Name = "UserName";
            this.UserName.OptionsColumn.ReadOnly = true;
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 4;
            // 
            // Loads
            // 
            this.Loads.AppearanceCell.Options.UseTextOptions = true;
            this.Loads.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Loads.AppearanceHeader.Options.UseTextOptions = true;
            this.Loads.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Loads.Caption = "载荷";
            this.Loads.FieldName = "Loads";
            this.Loads.Name = "Loads";
            this.Loads.OptionsColumn.ReadOnly = true;
            this.Loads.Visible = true;
            this.Loads.VisibleIndex = 5;
            // 
            // SampleName
            // 
            this.SampleName.AppearanceCell.Options.UseTextOptions = true;
            this.SampleName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SampleName.AppearanceHeader.Options.UseTextOptions = true;
            this.SampleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SampleName.Caption = "样品名称";
            this.SampleName.FieldName = "SampleName";
            this.SampleName.Name = "SampleName";
            this.SampleName.OptionsColumn.ReadOnly = true;
            this.SampleName.Visible = true;
            this.SampleName.VisibleIndex = 6;
            // 
            // SampleMass
            // 
            this.SampleMass.AppearanceCell.Options.UseTextOptions = true;
            this.SampleMass.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SampleMass.AppearanceHeader.Options.UseTextOptions = true;
            this.SampleMass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SampleMass.Caption = "样品质量";
            this.SampleMass.FieldName = "SampleName";
            this.SampleMass.Name = "SampleMass";
            this.SampleMass.OptionsColumn.ReadOnly = true;
            this.SampleMass.Visible = true;
            this.SampleMass.VisibleIndex = 7;
            // 
            // CapillaryDiameter
            // 
            this.CapillaryDiameter.AppearanceCell.Options.UseTextOptions = true;
            this.CapillaryDiameter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CapillaryDiameter.AppearanceHeader.Options.UseTextOptions = true;
            this.CapillaryDiameter.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CapillaryDiameter.Caption = "毛细管直径";
            this.CapillaryDiameter.FieldName = "CapillaryDiameter";
            this.CapillaryDiameter.Name = "CapillaryDiameter";
            this.CapillaryDiameter.OptionsColumn.ReadOnly = true;
            this.CapillaryDiameter.Visible = true;
            this.CapillaryDiameter.VisibleIndex = 8;
            // 
            // CapillaryLength
            // 
            this.CapillaryLength.AppearanceCell.Options.UseTextOptions = true;
            this.CapillaryLength.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CapillaryLength.AppearanceHeader.Options.UseTextOptions = true;
            this.CapillaryLength.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CapillaryLength.Caption = "毛细管长度";
            this.CapillaryLength.FieldName = "CapillaryLength";
            this.CapillaryLength.Name = "CapillaryLength";
            this.CapillaryLength.OptionsColumn.ReadOnly = true;
            this.CapillaryLength.Visible = true;
            this.CapillaryLength.VisibleIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.emptySpaceItem3,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 226);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlExperimentSelect;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 170);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 180);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(615, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 170);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(780, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.BtCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(710, 180);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(70, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(685, 180);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(25, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BtOk;
            this.layoutControlItem3.Location = new System.Drawing.Point(615, 180);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(70, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FrmExperimentSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 226);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExperimentSelect";
            this.Text = "正在进行的实验";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExperimentSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExperimentSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton BtCancel;
        private DevExpress.XtraGrid.GridControl gridControlExperimentSelect;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewExperimentSelect;
        private DevExpress.XtraGrid.Columns.GridColumn ExperimentID;
        private DevExpress.XtraGrid.Columns.GridColumn ExperimentType;
        private DevExpress.XtraGrid.Columns.GridColumn ExperimentName;
        private DevExpress.XtraGrid.Columns.GridColumn ExperimentTime;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn Loads;
        private DevExpress.XtraGrid.Columns.GridColumn SampleName;
        private DevExpress.XtraGrid.Columns.GridColumn SampleMass;
        private DevExpress.XtraGrid.Columns.GridColumn CapillaryDiameter;
        private DevExpress.XtraGrid.Columns.GridColumn CapillaryLength;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.SimpleButton BtOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}