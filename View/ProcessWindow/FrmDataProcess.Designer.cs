namespace Rheometer_Torque.View.ProcessWindow
{
    partial class FrmDataProcess
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
            this.tabPaneDataAnalysis = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPageDataImport = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.BtAppend = new DevExpress.XtraEditors.SimpleButton();
            this.RdGroupDBSelect = new DevExpress.XtraEditors.RadioGroup();
            this.BtImportDB = new DevExpress.XtraEditors.SimpleButton();
            this.BtReLoad = new DevExpress.XtraEditors.SimpleButton();
            this.BtImportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.BtSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExperimentData = new DevExpress.XtraGrid.GridControl();
            this.gridViewExperimentData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TimeLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Temperature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PlungerLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PlungerSpeed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShearRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShearStress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShearViscosity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlReload = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemAppend = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemAppend = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabNavigationPageChart = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.RadioGroupChartModeHP = new DevExpress.XtraEditors.RadioGroup();
            this.chartControlData = new DevExpress.XtraCharts.ChartControl();
            this.RadioGroupChartModeCT = new DevExpress.XtraEditors.RadioGroup();
            this.BtExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemConstantTempreature = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemHeatUp = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabNavigationPageDataProcessing = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.BtExportExcelMeanData = new DevExpress.XtraEditors.SimpleButton();
            this.TxtTimeSpan = new DevExpress.XtraEditors.TextEdit();
            this.BtOk = new DevExpress.XtraEditors.SimpleButton();
            this.TxtMeanCount = new DevExpress.XtraEditors.TextEdit();
            this.gridControlMeanData = new DevExpress.XtraGrid.GridControl();
            this.gridViewMeanData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabNavigationPageChartCompare = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Rheometer_Torque.View.WaitForm), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneDataAnalysis)).BeginInit();
            this.tabPaneDataAnalysis.SuspendLayout();
            this.tabNavigationPageDataImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RdGroupDBSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExperimentData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExperimentData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlReload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAppend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemAppend)).BeginInit();
            this.tabNavigationPageChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroupChartModeHP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroupChartModeCT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConstantTempreature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemHeatUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.tabNavigationPageDataProcessing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTimeSpan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMeanCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMeanData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMeanData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPaneDataAnalysis
            // 
            this.tabPaneDataAnalysis.Controls.Add(this.tabNavigationPageDataImport);
            this.tabPaneDataAnalysis.Controls.Add(this.tabNavigationPageChart);
            this.tabPaneDataAnalysis.Controls.Add(this.tabNavigationPageDataProcessing);
            this.tabPaneDataAnalysis.Controls.Add(this.tabNavigationPageChartCompare);
            this.tabPaneDataAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneDataAnalysis.Location = new System.Drawing.Point(0, 0);
            this.tabPaneDataAnalysis.Name = "tabPaneDataAnalysis";
            this.tabPaneDataAnalysis.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPageDataImport,
            this.tabNavigationPageDataProcessing,
            this.tabNavigationPageChart,
            this.tabNavigationPageChartCompare});
            this.tabPaneDataAnalysis.RegularSize = new System.Drawing.Size(1078, 574);
            this.tabPaneDataAnalysis.SelectedPage = this.tabNavigationPageDataImport;
            this.tabPaneDataAnalysis.Size = new System.Drawing.Size(1078, 574);
            this.tabPaneDataAnalysis.TabIndex = 0;
            this.tabPaneDataAnalysis.Text = "数据处理";
            this.tabPaneDataAnalysis.SelectedPageChanged += new DevExpress.XtraBars.Navigation.SelectedPageChangedEventHandler(this.tabPaneDataAnalysis_SelectedPageChanged);
            // 
            // tabNavigationPageDataImport
            // 
            this.tabNavigationPageDataImport.Caption = "实验数据";
            this.tabNavigationPageDataImport.ControlName = "TabPageDataList";
            this.tabNavigationPageDataImport.Controls.Add(this.layoutControl1);
            this.tabNavigationPageDataImport.Name = "tabNavigationPageDataImport";
            this.tabNavigationPageDataImport.Size = new System.Drawing.Size(1078, 541);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BtAppend);
            this.layoutControl1.Controls.Add(this.RdGroupDBSelect);
            this.layoutControl1.Controls.Add(this.BtImportDB);
            this.layoutControl1.Controls.Add(this.BtReLoad);
            this.layoutControl1.Controls.Add(this.BtImportExcel);
            this.layoutControl1.Controls.Add(this.BtSave);
            this.layoutControl1.Controls.Add(this.gridControlExperimentData);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(220, 308, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1078, 541);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BtAppend
            // 
            this.BtAppend.Location = new System.Drawing.Point(969, 12);
            this.BtAppend.Name = "BtAppend";
            this.BtAppend.Size = new System.Drawing.Size(97, 22);
            this.BtAppend.StyleController = this.layoutControl1;
            this.BtAppend.TabIndex = 11;
            this.BtAppend.Text = "附加实验数据";
            this.BtAppend.Click += new System.EventHandler(this.BtAppend_Click);
            // 
            // RdGroupDBSelect
            // 
            this.RdGroupDBSelect.Location = new System.Drawing.Point(366, 12);
            this.RdGroupDBSelect.Name = "RdGroupDBSelect";
            this.RdGroupDBSelect.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.RdGroupDBSelect.Properties.Appearance.Options.UseBackColor = true;
            this.RdGroupDBSelect.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RdGroupDBSelect.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "恒温实验数据"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "升温实验数据")});
            this.RdGroupDBSelect.Size = new System.Drawing.Size(192, 25);
            this.RdGroupDBSelect.StyleController = this.layoutControl1;
            this.RdGroupDBSelect.TabIndex = 10;
            this.RdGroupDBSelect.SelectedIndexChanged += new System.EventHandler(this.RdGroupDBSelect_SelectedIndexChanged);
            // 
            // BtImportDB
            // 
            this.BtImportDB.Location = new System.Drawing.Point(572, 12);
            this.BtImportDB.MaximumSize = new System.Drawing.Size(85, 22);
            this.BtImportDB.MinimumSize = new System.Drawing.Size(85, 22);
            this.BtImportDB.Name = "BtImportDB";
            this.BtImportDB.Size = new System.Drawing.Size(85, 22);
            this.BtImportDB.StyleController = this.layoutControl1;
            this.BtImportDB.TabIndex = 9;
            this.BtImportDB.Text = "导入DB数据";
            this.BtImportDB.Click += new System.EventHandler(this.BtImportDB_Click);
            // 
            // BtReLoad
            // 
            this.BtReLoad.Location = new System.Drawing.Point(770, 12);
            this.BtReLoad.MaximumSize = new System.Drawing.Size(85, 22);
            this.BtReLoad.MinimumSize = new System.Drawing.Size(85, 22);
            this.BtReLoad.Name = "BtReLoad";
            this.BtReLoad.Size = new System.Drawing.Size(85, 22);
            this.BtReLoad.StyleController = this.layoutControl1;
            this.BtReLoad.TabIndex = 8;
            this.BtReLoad.Text = "重新加载";
            this.BtReLoad.Click += new System.EventHandler(this.BtReLoad_Click);
            // 
            // BtImportExcel
            // 
            this.BtImportExcel.Location = new System.Drawing.Point(671, 12);
            this.BtImportExcel.MaximumSize = new System.Drawing.Size(85, 22);
            this.BtImportExcel.MinimumSize = new System.Drawing.Size(85, 22);
            this.BtImportExcel.Name = "BtImportExcel";
            this.BtImportExcel.Size = new System.Drawing.Size(85, 22);
            this.BtImportExcel.StyleController = this.layoutControl1;
            this.BtImportExcel.TabIndex = 6;
            this.BtImportExcel.Text = "导入Excel数据";
            this.BtImportExcel.Click += new System.EventHandler(this.BtImportExcel_Click);
            // 
            // BtSave
            // 
            this.BtSave.Location = new System.Drawing.Point(869, 12);
            this.BtSave.MaximumSize = new System.Drawing.Size(85, 22);
            this.BtSave.MinimumSize = new System.Drawing.Size(85, 22);
            this.BtSave.Name = "BtSave";
            this.BtSave.Size = new System.Drawing.Size(85, 22);
            this.BtSave.StyleController = this.layoutControl1;
            this.BtSave.TabIndex = 5;
            this.BtSave.Text = "数据保存";
            this.BtSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // gridControlExperimentData
            // 
            this.gridControlExperimentData.Location = new System.Drawing.Point(12, 41);
            this.gridControlExperimentData.MainView = this.gridViewExperimentData;
            this.gridControlExperimentData.Name = "gridControlExperimentData";
            this.gridControlExperimentData.Size = new System.Drawing.Size(1054, 488);
            this.gridControlExperimentData.TabIndex = 4;
            this.gridControlExperimentData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewExperimentData});
            // 
            // gridViewExperimentData
            // 
            this.gridViewExperimentData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TimeLength,
            this.Temperature,
            this.PlungerLocation,
            this.PlungerSpeed,
            this.ShearRate,
            this.ShearStress,
            this.ShearViscosity});
            this.gridViewExperimentData.GridControl = this.gridControlExperimentData;
            this.gridViewExperimentData.IndicatorWidth = 40;
            this.gridViewExperimentData.Name = "gridViewExperimentData";
            this.gridViewExperimentData.OptionsView.ShowGroupPanel = false;
            this.gridViewExperimentData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewExperimentData_CustomDrawRowIndicator);
            this.gridViewExperimentData.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewExperimentData_RowStyle);
            this.gridViewExperimentData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridViewExperimentData_MouseDown);
            // 
            // TimeLength
            // 
            this.TimeLength.AppearanceCell.Options.UseTextOptions = true;
            this.TimeLength.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TimeLength.AppearanceHeader.Options.UseTextOptions = true;
            this.TimeLength.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TimeLength.Caption = "时间(s)";
            this.TimeLength.FieldName = "ExperimentTime";
            this.TimeLength.Name = "TimeLength";
            this.TimeLength.OptionsColumn.AllowEdit = false;
            this.TimeLength.OptionsColumn.ReadOnly = true;
            this.TimeLength.Visible = true;
            this.TimeLength.VisibleIndex = 0;
            // 
            // Temperature
            // 
            this.Temperature.AppearanceCell.Options.UseTextOptions = true;
            this.Temperature.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Temperature.AppearanceHeader.Options.UseTextOptions = true;
            this.Temperature.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Temperature.Caption = "温度(℃)";
            this.Temperature.FieldName = "Temperature";
            this.Temperature.Name = "Temperature";
            this.Temperature.OptionsColumn.AllowEdit = false;
            this.Temperature.OptionsColumn.ReadOnly = true;
            this.Temperature.Visible = true;
            this.Temperature.VisibleIndex = 1;
            // 
            // PlungerLocation
            // 
            this.PlungerLocation.AppearanceCell.Options.UseTextOptions = true;
            this.PlungerLocation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PlungerLocation.AppearanceHeader.Options.UseTextOptions = true;
            this.PlungerLocation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PlungerLocation.Caption = "柱塞位置(mm)";
            this.PlungerLocation.FieldName = "PlungerLocation";
            this.PlungerLocation.Name = "PlungerLocation";
            this.PlungerLocation.OptionsColumn.AllowEdit = false;
            this.PlungerLocation.OptionsColumn.ReadOnly = true;
            this.PlungerLocation.Visible = true;
            this.PlungerLocation.VisibleIndex = 2;
            // 
            // PlungerSpeed
            // 
            this.PlungerSpeed.AppearanceCell.Options.UseTextOptions = true;
            this.PlungerSpeed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PlungerSpeed.AppearanceHeader.Options.UseTextOptions = true;
            this.PlungerSpeed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PlungerSpeed.Caption = "柱塞速度(mm/min)";
            this.PlungerSpeed.FieldName = "PlungerSpeed";
            this.PlungerSpeed.Name = "PlungerSpeed";
            this.PlungerSpeed.OptionsColumn.AllowEdit = false;
            this.PlungerSpeed.OptionsColumn.ReadOnly = true;
            this.PlungerSpeed.Visible = true;
            this.PlungerSpeed.VisibleIndex = 3;
            // 
            // ShearRate
            // 
            this.ShearRate.AppearanceCell.Options.UseTextOptions = true;
            this.ShearRate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ShearRate.AppearanceHeader.Options.UseTextOptions = true;
            this.ShearRate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ShearRate.Caption = "剪切速率(1/s)";
            this.ShearRate.FieldName = "ShearRate";
            this.ShearRate.Name = "ShearRate";
            this.ShearRate.OptionsColumn.AllowEdit = false;
            this.ShearRate.OptionsColumn.ReadOnly = true;
            this.ShearRate.Visible = true;
            this.ShearRate.VisibleIndex = 4;
            // 
            // ShearStress
            // 
            this.ShearStress.AppearanceCell.Options.UseTextOptions = true;
            this.ShearStress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ShearStress.AppearanceHeader.Options.UseTextOptions = true;
            this.ShearStress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ShearStress.Caption = "剪切应力(MPa)";
            this.ShearStress.FieldName = "ShearStress";
            this.ShearStress.Name = "ShearStress";
            this.ShearStress.OptionsColumn.AllowEdit = false;
            this.ShearStress.OptionsColumn.ReadOnly = true;
            this.ShearStress.Visible = true;
            this.ShearStress.VisibleIndex = 5;
            // 
            // ShearViscosity
            // 
            this.ShearViscosity.AppearanceCell.Options.UseTextOptions = true;
            this.ShearViscosity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ShearViscosity.AppearanceHeader.Options.UseTextOptions = true;
            this.ShearViscosity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ShearViscosity.Caption = "剪切粘度(pa·s)";
            this.ShearViscosity.FieldName = "ShearViscosity";
            this.ShearViscosity.Name = "ShearViscosity";
            this.ShearViscosity.OptionsColumn.AllowEdit = false;
            this.ShearViscosity.OptionsColumn.ReadOnly = true;
            this.ShearViscosity.Visible = true;
            this.ShearViscosity.VisibleIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem3,
            this.layoutControlSave,
            this.layoutControlItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem9,
            this.layoutControlReload,
            this.layoutControlItem9,
            this.emptySpaceItem11,
            this.layoutControlItem10,
            this.emptySpaceItem12,
            this.layoutControlItemAppend,
            this.emptySpaceItemAppend});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1078, 541);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlExperimentData;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1058, 492);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(275, 29);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlSave
            // 
            this.layoutControlSave.Control = this.BtSave;
            this.layoutControlSave.Location = new System.Drawing.Point(857, 0);
            this.layoutControlSave.Name = "layoutControlSave";
            this.layoutControlSave.Size = new System.Drawing.Size(89, 29);
            this.layoutControlSave.Text = "数据保存";
            this.layoutControlSave.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlSave.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BtImportExcel;
            this.layoutControlItem3.Location = new System.Drawing.Point(659, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(89, 29);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(847, 0);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(10, 29);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(748, 0);
            this.emptySpaceItem9.MaxSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem9.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(10, 29);
            this.emptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlReload
            // 
            this.layoutControlReload.Control = this.BtReLoad;
            this.layoutControlReload.Location = new System.Drawing.Point(758, 0);
            this.layoutControlReload.Name = "layoutControlReload";
            this.layoutControlReload.Size = new System.Drawing.Size(89, 29);
            this.layoutControlReload.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlReload.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.BtImportDB;
            this.layoutControlItem9.Location = new System.Drawing.Point(560, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(89, 29);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.Location = new System.Drawing.Point(649, 0);
            this.emptySpaceItem11.MaxSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem11.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(10, 29);
            this.emptySpaceItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.RdGroupDBSelect;
            this.layoutControlItem10.Location = new System.Drawing.Point(275, 0);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(275, 29);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(275, 29);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(275, 29);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "DB数据类型:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(67, 14);
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.Location = new System.Drawing.Point(550, 0);
            this.emptySpaceItem12.MaxSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem12.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(10, 29);
            this.emptySpaceItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemAppend
            // 
            this.layoutControlItemAppend.Control = this.BtAppend;
            this.layoutControlItemAppend.Location = new System.Drawing.Point(957, 0);
            this.layoutControlItemAppend.Name = "layoutControlItemAppend";
            this.layoutControlItemAppend.Size = new System.Drawing.Size(101, 29);
            this.layoutControlItemAppend.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemAppend.TextVisible = false;
            // 
            // emptySpaceItemAppend
            // 
            this.emptySpaceItemAppend.AllowHotTrack = false;
            this.emptySpaceItemAppend.Location = new System.Drawing.Point(946, 0);
            this.emptySpaceItemAppend.Name = "emptySpaceItemAppend";
            this.emptySpaceItemAppend.Size = new System.Drawing.Size(11, 29);
            this.emptySpaceItemAppend.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabNavigationPageChart
            // 
            this.tabNavigationPageChart.Caption = "图表绘制";
            this.tabNavigationPageChart.ControlName = "TabPageChart";
            this.tabNavigationPageChart.Controls.Add(this.layoutControl2);
            this.tabNavigationPageChart.Name = "tabNavigationPageChart";
            this.tabNavigationPageChart.Size = new System.Drawing.Size(1078, 541);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.RadioGroupChartModeHP);
            this.layoutControl2.Controls.Add(this.chartControlData);
            this.layoutControl2.Controls.Add(this.RadioGroupChartModeCT);
            this.layoutControl2.Controls.Add(this.BtExportExcel);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(220, 120, 450, 400);
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1078, 541);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // RadioGroupChartModeHP
            // 
            this.RadioGroupChartModeHP.Location = new System.Drawing.Point(170, 12);
            this.RadioGroupChartModeHP.Name = "RadioGroupChartModeHP";
            this.RadioGroupChartModeHP.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.RadioGroupChartModeHP.Properties.Appearance.Options.UseBackColor = true;
            this.RadioGroupChartModeHP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RadioGroupChartModeHP.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "速度-温度"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "位移-温度"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "粘度(log)-温度"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "温度-时间")});
            this.RadioGroupChartModeHP.Size = new System.Drawing.Size(416, 25);
            this.RadioGroupChartModeHP.StyleController = this.layoutControl2;
            this.RadioGroupChartModeHP.TabIndex = 7;
            this.RadioGroupChartModeHP.SelectedIndexChanged += new System.EventHandler(this.RadioGroupChartMode_SelectedIndexChanged);
            // 
            // chartControlData
            // 
            this.chartControlData.Legend.Name = "Default Legend";
            this.chartControlData.Location = new System.Drawing.Point(12, 41);
            this.chartControlData.Name = "chartControlData";
            this.chartControlData.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControlData.Size = new System.Drawing.Size(1054, 478);
            this.chartControlData.TabIndex = 6;
            this.chartControlData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartControlData_MouseClick);
            // 
            // RadioGroupChartModeCT
            // 
            this.RadioGroupChartModeCT.Location = new System.Drawing.Point(650, 12);
            this.RadioGroupChartModeCT.Name = "RadioGroupChartModeCT";
            this.RadioGroupChartModeCT.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.RadioGroupChartModeCT.Properties.Appearance.Options.UseBackColor = true;
            this.RadioGroupChartModeCT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RadioGroupChartModeCT.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "速度-时间"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "位移-时间"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "粘度(log)-时间"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "温度-时间")});
            this.RadioGroupChartModeCT.Size = new System.Drawing.Size(416, 25);
            this.RadioGroupChartModeCT.StyleController = this.layoutControl2;
            this.RadioGroupChartModeCT.TabIndex = 5;
            this.RadioGroupChartModeCT.SelectedIndexChanged += new System.EventHandler(this.RadioGroupChartMode_SelectedIndexChanged);
            // 
            // BtExportExcel
            // 
            this.BtExportExcel.Location = new System.Drawing.Point(12, 12);
            this.BtExportExcel.MaximumSize = new System.Drawing.Size(66, 22);
            this.BtExportExcel.MinimumSize = new System.Drawing.Size(66, 22);
            this.BtExportExcel.Name = "BtExportExcel";
            this.BtExportExcel.Size = new System.Drawing.Size(66, 22);
            this.BtExportExcel.StyleController = this.layoutControl2;
            this.BtExportExcel.TabIndex = 8;
            this.BtExportExcel.Text = "导出Excel";
            this.BtExportExcel.Click += new System.EventHandler(this.BtExportExcel_Click);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItemConstantTempreature,
            this.layoutControlItem2,
            this.layoutControlItemHeatUp,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1078, 541);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 511);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1058, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemConstantTempreature
            // 
            this.layoutControlItemConstantTempreature.Control = this.RadioGroupChartModeCT;
            this.layoutControlItemConstantTempreature.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemConstantTempreature.CustomizationFormText = "图表绘制选择：";
            this.layoutControlItemConstantTempreature.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemConstantTempreature.Location = new System.Drawing.Point(578, 0);
            this.layoutControlItemConstantTempreature.MaxSize = new System.Drawing.Size(480, 29);
            this.layoutControlItemConstantTempreature.MinSize = new System.Drawing.Size(480, 29);
            this.layoutControlItemConstantTempreature.Name = "layoutControlItemConstantTempreature";
            this.layoutControlItemConstantTempreature.Size = new System.Drawing.Size(480, 29);
            this.layoutControlItemConstantTempreature.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemConstantTempreature.Text = "图表参数：";
            this.layoutControlItemConstantTempreature.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemConstantTempreature.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemConstantTempreature.TextSize = new System.Drawing.Size(60, 14);
            this.layoutControlItemConstantTempreature.TextToControlDistance = 0;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chartControlData;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1058, 482);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItemHeatUp
            // 
            this.layoutControlItemHeatUp.Control = this.RadioGroupChartModeHP;
            this.layoutControlItemHeatUp.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemHeatUp.CustomizationFormText = "图表参数：";
            this.layoutControlItemHeatUp.Location = new System.Drawing.Point(98, 0);
            this.layoutControlItemHeatUp.MaxSize = new System.Drawing.Size(480, 29);
            this.layoutControlItemHeatUp.MinSize = new System.Drawing.Size(480, 29);
            this.layoutControlItemHeatUp.Name = "layoutControlItemHeatUp";
            this.layoutControlItemHeatUp.OptionsPrint.AppearanceItem.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItemHeatUp.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItemHeatUp.Size = new System.Drawing.Size(480, 29);
            this.layoutControlItemHeatUp.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemHeatUp.Text = "图表参数：";
            this.layoutControlItemHeatUp.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemHeatUp.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemHeatUp.TextSize = new System.Drawing.Size(60, 14);
            this.layoutControlItemHeatUp.TextToControlDistance = 0;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.BtExportExcel;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(70, 29);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(70, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(28, 29);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabNavigationPageDataProcessing
            // 
            this.tabNavigationPageDataProcessing.Caption = "均值化处理";
            this.tabNavigationPageDataProcessing.Controls.Add(this.layoutControl3);
            this.tabNavigationPageDataProcessing.Name = "tabNavigationPageDataProcessing";
            this.tabNavigationPageDataProcessing.Size = new System.Drawing.Size(1078, 541);
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.BtExportExcelMeanData);
            this.layoutControl3.Controls.Add(this.TxtTimeSpan);
            this.layoutControl3.Controls.Add(this.BtOk);
            this.layoutControl3.Controls.Add(this.TxtMeanCount);
            this.layoutControl3.Controls.Add(this.gridControlMeanData);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(0, 0);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(220, 292, 450, 400);
            this.layoutControl3.Root = this.layoutControlGroup3;
            this.layoutControl3.Size = new System.Drawing.Size(1078, 541);
            this.layoutControl3.TabIndex = 0;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // BtExportExcelMeanData
            // 
            this.BtExportExcelMeanData.Location = new System.Drawing.Point(12, 12);
            this.BtExportExcelMeanData.Name = "BtExportExcelMeanData";
            this.BtExportExcelMeanData.Size = new System.Drawing.Size(70, 22);
            this.BtExportExcelMeanData.StyleController = this.layoutControl3;
            this.BtExportExcelMeanData.TabIndex = 9;
            this.BtExportExcelMeanData.Text = "导出Excel";
            this.BtExportExcelMeanData.Click += new System.EventHandler(this.BtExportExcelMeanData_Click);
            // 
            // TxtTimeSpan
            // 
            this.TxtTimeSpan.EditValue = "1";
            this.TxtTimeSpan.Location = new System.Drawing.Point(803, 12);
            this.TxtTimeSpan.Name = "TxtTimeSpan";
            this.TxtTimeSpan.Properties.Mask.EditMask = "f0";
            this.TxtTimeSpan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtTimeSpan.Size = new System.Drawing.Size(42, 20);
            this.TxtTimeSpan.StyleController = this.layoutControl3;
            this.TxtTimeSpan.TabIndex = 8;
            // 
            // BtOk
            // 
            this.BtOk.Location = new System.Drawing.Point(999, 12);
            this.BtOk.MaximumSize = new System.Drawing.Size(67, 22);
            this.BtOk.MinimumSize = new System.Drawing.Size(67, 22);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(67, 22);
            this.BtOk.StyleController = this.layoutControl3;
            this.BtOk.TabIndex = 7;
            this.BtOk.Text = "确认";
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // TxtMeanCount
            // 
            this.TxtMeanCount.EditValue = "5";
            this.TxtMeanCount.Location = new System.Drawing.Point(943, 12);
            this.TxtMeanCount.Name = "TxtMeanCount";
            this.TxtMeanCount.Properties.Mask.EditMask = "f0";
            this.TxtMeanCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtMeanCount.Size = new System.Drawing.Size(42, 20);
            this.TxtMeanCount.StyleController = this.layoutControl3;
            this.TxtMeanCount.TabIndex = 6;
            // 
            // gridControlMeanData
            // 
            this.gridControlMeanData.Location = new System.Drawing.Point(12, 38);
            this.gridControlMeanData.MainView = this.gridViewMeanData;
            this.gridControlMeanData.Name = "gridControlMeanData";
            this.gridControlMeanData.Size = new System.Drawing.Size(1054, 481);
            this.gridControlMeanData.TabIndex = 5;
            this.gridControlMeanData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMeanData});
            // 
            // gridViewMeanData
            // 
            this.gridViewMeanData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridViewMeanData.GridControl = this.gridControlMeanData;
            this.gridViewMeanData.IndicatorWidth = 40;
            this.gridViewMeanData.Name = "gridViewMeanData";
            this.gridViewMeanData.OptionsView.ShowGroupPanel = false;
            this.gridViewMeanData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewMeanData_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "时间(s)";
            this.gridColumn1.FieldName = "ExperimentTime";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "温度(℃)";
            this.gridColumn2.FieldName = "Temperature";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "柱塞位置(mm)";
            this.gridColumn3.FieldName = "PlungerLocation";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "柱塞速度(mm/min)";
            this.gridColumn4.FieldName = "PlungerSpeed";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "剪切速率(1/s)";
            this.gridColumn5.FieldName = "ShearRate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "剪切应力(pa)";
            this.gridColumn6.FieldName = "ShearStress";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "剪切粘度(pa·s)";
            this.gridColumn7.FieldName = "ShearViscosity";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.layoutControlItem6,
            this.LayControlItem1,
            this.emptySpaceItem7,
            this.emptySpaceItem8,
            this.layoutControlItem4,
            this.layoutControlItem8});
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1078, 541);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControlMeanData;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1058, 485);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(74, 0);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(633, 26);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 511);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(1058, 10);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.TxtMeanCount;
            this.layoutControlItem6.CustomizationFormText = "均值化个数：";
            this.layoutControlItem6.Location = new System.Drawing.Point(847, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(130, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(130, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(130, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "均值化个数：";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(72, 14);
            // 
            // LayControlItem1
            // 
            this.LayControlItem1.Control = this.BtOk;
            this.LayControlItem1.Location = new System.Drawing.Point(987, 0);
            this.LayControlItem1.Name = "LayControlItem1";
            this.LayControlItem1.Size = new System.Drawing.Size(71, 26);
            this.LayControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.LayControlItem1.TextVisible = false;
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(977, 0);
            this.emptySpaceItem7.MaxSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem7.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(837, 0);
            this.emptySpaceItem8.MaxSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem8.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.TxtTimeSpan;
            this.layoutControlItem4.Location = new System.Drawing.Point(707, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(130, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(130, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(130, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "采集周期：";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.BtExportExcelMeanData;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(74, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // tabNavigationPageChartCompare
            // 
            this.tabNavigationPageChartCompare.Caption = "图表对比分析";
            this.tabNavigationPageChartCompare.Name = "tabNavigationPageChartCompare";
            this.tabNavigationPageChartCompare.Size = new System.Drawing.Size(1078, 541);
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // FrmDataProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 574);
            this.Controls.Add(this.tabPaneDataAnalysis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDataProcess";
            this.Text = "FrmDataProcess";
            this.Load += new System.EventHandler(this.FrmDataProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneDataAnalysis)).EndInit();
            this.tabPaneDataAnalysis.ResumeLayout(false);
            this.tabNavigationPageDataImport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RdGroupDBSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExperimentData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExperimentData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlReload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAppend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemAppend)).EndInit();
            this.tabNavigationPageChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroupChartModeHP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroupChartModeCT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConstantTempreature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemHeatUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.tabNavigationPageDataProcessing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtTimeSpan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMeanCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMeanData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMeanData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPaneDataAnalysis;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageDataImport;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageChart;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControlExperimentData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewExperimentData;        
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;        
        private DevExpress.XtraEditors.SimpleButton BtSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlSave;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraGrid.Columns.GridColumn TimeLength;
        private DevExpress.XtraGrid.Columns.GridColumn Temperature;
        private DevExpress.XtraGrid.Columns.GridColumn PlungerLocation;
        private DevExpress.XtraGrid.Columns.GridColumn PlungerSpeed;
        private DevExpress.XtraGrid.Columns.GridColumn ShearRate;
        private DevExpress.XtraGrid.Columns.GridColumn ShearStress;
        private DevExpress.XtraGrid.Columns.GridColumn ShearViscosity;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageDataProcessing;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraGrid.GridControl gridControlMeanData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMeanData;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraEditors.TextEdit TxtMeanCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraEditors.SimpleButton BtOk;
        private DevExpress.XtraLayout.LayoutControlItem LayControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraEditors.SimpleButton BtImportExcel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton BtReLoad;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlReload;
        private DevExpress.XtraEditors.RadioGroup RadioGroupChartModeCT;
        //private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemConstantTempreature;
        private DevExpress.XtraEditors.SimpleButton BtImportDB;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraEditors.RadioGroup RdGroupDBSelect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        //private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.XtraCharts.ChartControl chartControlData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.RadioGroup RadioGroupChartModeHP;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemHeatUp;
        //private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit TxtTimeSpan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton BtAppend;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemAppend;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemAppend;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton BtExportExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton BtExportExcelMeanData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        //private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageChartCompare;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
    }
}