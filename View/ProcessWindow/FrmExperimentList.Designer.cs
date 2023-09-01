namespace Rheometer_Torque.View.ProcessWindow
{
    partial class FrmExperimentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExperimentList));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.BtOk = new DevExpress.XtraEditors.SimpleButton();
            this.BtCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExperimentList = new DevExpress.XtraGrid.GridControl();
            this.gridViewExperimentList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ExperimentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OperationMode = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExperimentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExperimentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BtOk);
            this.layoutControl1.Controls.Add(this.BtCancel);
            this.layoutControl1.Controls.Add(this.gridControlExperimentList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(206, 128, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 442);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BtOk
            // 
            this.BtOk.Location = new System.Drawing.Point(698, 408);
            this.BtOk.MaximumSize = new System.Drawing.Size(80, 22);
            this.BtOk.MinimumSize = new System.Drawing.Size(80, 22);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(80, 22);
            this.BtOk.StyleController = this.layoutControl1;
            this.BtOk.TabIndex = 7;
            this.BtOk.Text = "确认";
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Location = new System.Drawing.Point(792, 408);
            this.BtCancel.MaximumSize = new System.Drawing.Size(80, 22);
            this.BtCancel.MinimumSize = new System.Drawing.Size(80, 22);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(80, 22);
            this.BtCancel.StyleController = this.layoutControl1;
            this.BtCancel.TabIndex = 6;
            this.BtCancel.Text = "取消";
            // 
            // gridControlExperimentList
            // 
            this.gridControlExperimentList.Location = new System.Drawing.Point(12, 12);
            this.gridControlExperimentList.MainView = this.gridViewExperimentList;
            this.gridControlExperimentList.Name = "gridControlExperimentList";
            this.gridControlExperimentList.Size = new System.Drawing.Size(860, 392);
            this.gridControlExperimentList.TabIndex = 5;
            this.gridControlExperimentList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewExperimentList});
            // 
            // gridViewExperimentList
            // 
            this.gridViewExperimentList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ExperimentID,
            this.OperationMode,
            this.ExperimentType,
            this.ExperimentName,
            this.ExperimentTime,
            this.UserName,
            this.Loads,
            this.SampleName,
            this.SampleMass,
            this.CapillaryDiameter,
            this.CapillaryLength});
            this.gridViewExperimentList.GridControl = this.gridControlExperimentList;
            this.gridViewExperimentList.IndicatorWidth = 40;
            this.gridViewExperimentList.Name = "gridViewExperimentList";
            this.gridViewExperimentList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewExperimentList.OptionsBehavior.Editable = false;
            this.gridViewExperimentList.OptionsBehavior.ReadOnly = true;
            this.gridViewExperimentList.OptionsView.ShowGroupPanel = false;
            this.gridViewExperimentList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewExperimentList_CustomDrawRowIndicator);
            this.gridViewExperimentList.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewExperimentList_CustomColumnDisplayText);
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
            this.ExperimentID.OptionsColumn.AllowEdit = false;
            this.ExperimentID.OptionsColumn.ReadOnly = true;
            this.ExperimentID.Visible = true;
            this.ExperimentID.VisibleIndex = 0;
            // 
            // OperationMode
            // 
            this.OperationMode.AppearanceCell.Options.UseTextOptions = true;
            this.OperationMode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OperationMode.AppearanceHeader.Options.UseTextOptions = true;
            this.OperationMode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OperationMode.Caption = "实验模式";
            this.OperationMode.FieldName = "OperationMode";
            this.OperationMode.Name = "OperationMode";
            this.OperationMode.OptionsColumn.AllowEdit = false;
            this.OperationMode.OptionsColumn.ReadOnly = true;
            this.OperationMode.Visible = true;
            this.OperationMode.VisibleIndex = 1;
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
            this.ExperimentType.OptionsColumn.AllowEdit = false;
            this.ExperimentType.OptionsColumn.ReadOnly = true;
            this.ExperimentType.Visible = true;
            this.ExperimentType.VisibleIndex = 2;
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
            this.ExperimentName.OptionsColumn.AllowEdit = false;
            this.ExperimentName.OptionsColumn.ReadOnly = true;
            this.ExperimentName.Visible = true;
            this.ExperimentName.VisibleIndex = 3;
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
            this.ExperimentTime.OptionsColumn.AllowEdit = false;
            this.ExperimentTime.OptionsColumn.ReadOnly = true;
            this.ExperimentTime.Visible = true;
            this.ExperimentTime.VisibleIndex = 4;
            // 
            // UserName
            // 
            this.UserName.AppearanceCell.Options.UseTextOptions = true;
            this.UserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UserName.AppearanceHeader.Options.UseTextOptions = true;
            this.UserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UserName.Caption = "操作者";
            this.UserName.FieldName = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.OptionsColumn.AllowEdit = false;
            this.UserName.OptionsColumn.ReadOnly = true;
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 5;
            // 
            // Loads
            // 
            this.Loads.AppearanceCell.Options.UseTextOptions = true;
            this.Loads.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Loads.AppearanceHeader.Options.UseTextOptions = true;
            this.Loads.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Loads.Caption = "载荷(kg)";
            this.Loads.FieldName = "Loads";
            this.Loads.Name = "Loads";
            this.Loads.OptionsColumn.AllowEdit = false;
            this.Loads.OptionsColumn.ReadOnly = true;
            this.Loads.Visible = true;
            this.Loads.VisibleIndex = 7;
            // 
            // SampleName
            // 
            this.SampleName.AppearanceCell.Options.UseTextOptions = true;
            this.SampleName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SampleName.AppearanceHeader.Options.UseTextOptions = true;
            this.SampleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SampleName.Caption = "样品名";
            this.SampleName.FieldName = "SampleName";
            this.SampleName.Name = "SampleName";
            this.SampleName.OptionsColumn.AllowEdit = false;
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
            this.SampleMass.Caption = "样品质量(g)";
            this.SampleMass.FieldName = "SampleMass";
            this.SampleMass.Name = "SampleMass";
            this.SampleMass.OptionsColumn.AllowEdit = false;
            this.SampleMass.OptionsColumn.ReadOnly = true;
            this.SampleMass.Visible = true;
            this.SampleMass.VisibleIndex = 8;
            // 
            // CapillaryDiameter
            // 
            this.CapillaryDiameter.AppearanceCell.Options.UseTextOptions = true;
            this.CapillaryDiameter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CapillaryDiameter.AppearanceHeader.Options.UseTextOptions = true;
            this.CapillaryDiameter.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CapillaryDiameter.Caption = "毛细管直径(mm)";
            this.CapillaryDiameter.FieldName = "CapillaryDiameter";
            this.CapillaryDiameter.Name = "CapillaryDiameter";
            this.CapillaryDiameter.OptionsColumn.AllowEdit = false;
            this.CapillaryDiameter.OptionsColumn.ReadOnly = true;
            this.CapillaryDiameter.Visible = true;
            this.CapillaryDiameter.VisibleIndex = 9;
            // 
            // CapillaryLength
            // 
            this.CapillaryLength.AppearanceCell.Options.UseTextOptions = true;
            this.CapillaryLength.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CapillaryLength.AppearanceHeader.Options.UseTextOptions = true;
            this.CapillaryLength.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CapillaryLength.Caption = "毛细管长度(mm)";
            this.CapillaryLength.FieldName = "CapillaryLength";
            this.CapillaryLength.Name = "CapillaryLength";
            this.CapillaryLength.OptionsColumn.AllowEdit = false;
            this.CapillaryLength.OptionsColumn.ReadOnly = true;
            this.CapillaryLength.Visible = true;
            this.CapillaryLength.VisibleIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 442);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlExperimentList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(864, 396);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 396);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(686, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.BtCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(780, 396);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(770, 396);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BtOk;
            this.layoutControlItem3.Location = new System.Drawing.Point(686, 396);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FrmExperimentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 442);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmExperimentList";
            this.Text = "实验列表";
            this.Load += new System.EventHandler(this.FrmExperimentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExperimentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExperimentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControlExperimentList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewExperimentList;
        private DevExpress.XtraGrid.Columns.GridColumn ExperimentID;
        private DevExpress.XtraGrid.Columns.GridColumn OperationMode;
        private DevExpress.XtraGrid.Columns.GridColumn ExperimentType;
        private DevExpress.XtraGrid.Columns.GridColumn ExperimentName;
        private DevExpress.XtraGrid.Columns.GridColumn ExperimentTime;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn SampleName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Loads;
        private DevExpress.XtraGrid.Columns.GridColumn SampleMass;
        private DevExpress.XtraGrid.Columns.GridColumn CapillaryDiameter;
        private DevExpress.XtraGrid.Columns.GridColumn CapillaryLength;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton BtOk;
        private DevExpress.XtraEditors.SimpleButton BtCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}