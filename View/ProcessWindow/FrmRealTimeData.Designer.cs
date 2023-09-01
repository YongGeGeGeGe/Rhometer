namespace Rheometer_Torque.View.ProcessWindow
{
    partial class FrmRealTimeData
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
            this.tabPaneRealData = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.gridControlRealTimeData = new DevExpress.XtraGrid.GridControl();
            this.gridViewRealTimeData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Stage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TimeLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Temperature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PlungerLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PlungerSpeed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.chartControlData = new DevExpress.XtraCharts.ChartControl();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Rheometer_Torque.View.WaitForm), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneRealData)).BeginInit();
            this.tabPaneRealData.SuspendLayout();
            this.tabNavigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRealTimeData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRealTimeData)).BeginInit();
            this.tabNavigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlData)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPaneRealData
            // 
            this.tabPaneRealData.Controls.Add(this.tabNavigationPage1);
            this.tabPaneRealData.Controls.Add(this.tabNavigationPage2);
            this.tabPaneRealData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneRealData.Location = new System.Drawing.Point(0, 0);
            this.tabPaneRealData.Name = "tabPaneRealData";
            this.tabPaneRealData.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1,
            this.tabNavigationPage2});
            this.tabPaneRealData.RegularSize = new System.Drawing.Size(940, 525);
            this.tabPaneRealData.SelectedPage = this.tabNavigationPage1;
            this.tabPaneRealData.Size = new System.Drawing.Size(940, 525);
            this.tabPaneRealData.TabIndex = 0;
            this.tabPaneRealData.Text = "tabPane1";
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "tabNavigationPageList";
            this.tabNavigationPage1.Controls.Add(this.gridControlRealTimeData);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.PageText = "实时数据列表";
            this.tabNavigationPage1.Size = new System.Drawing.Size(940, 492);
            // 
            // gridControlRealTimeData
            // 
            this.gridControlRealTimeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRealTimeData.EmbeddedNavigator.Text = "实验数据";
            this.gridControlRealTimeData.Location = new System.Drawing.Point(0, 0);
            this.gridControlRealTimeData.MainView = this.gridViewRealTimeData;
            this.gridControlRealTimeData.Name = "gridControlRealTimeData";
            this.gridControlRealTimeData.Size = new System.Drawing.Size(940, 492);
            this.gridControlRealTimeData.TabIndex = 1;
            this.gridControlRealTimeData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRealTimeData});
            // 
            // gridViewRealTimeData
            // 
            this.gridViewRealTimeData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Stage,
            this.TimeLength,
            this.Temperature,
            this.PlungerLocation,
            this.PlungerSpeed});
            this.gridViewRealTimeData.GridControl = this.gridControlRealTimeData;
            this.gridViewRealTimeData.IndicatorWidth = 80;
            this.gridViewRealTimeData.Name = "gridViewRealTimeData";
            this.gridViewRealTimeData.OptionsView.ShowGroupPanel = false;
            this.gridViewRealTimeData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewRealTimeData_CustomDrawRowIndicator);
            this.gridViewRealTimeData.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewRealTimeData_CustomColumnDisplayText);
            // 
            // Stage
            // 
            this.Stage.AppearanceCell.Options.UseTextOptions = true;
            this.Stage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Stage.AppearanceHeader.Options.UseTextOptions = true;
            this.Stage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Stage.Caption = "实验阶段";
            this.Stage.FieldName = "ExperimentStage";
            this.Stage.Name = "Stage";
            this.Stage.OptionsColumn.ReadOnly = true;
            this.Stage.Visible = true;
            this.Stage.VisibleIndex = 0;
            // 
            // TimeLength
            // 
            this.TimeLength.AppearanceCell.Options.UseTextOptions = true;
            this.TimeLength.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TimeLength.AppearanceHeader.Options.UseTextOptions = true;
            this.TimeLength.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TimeLength.Caption = "实验时间(s)";
            this.TimeLength.FieldName = "ExperimentTime";
            this.TimeLength.Name = "TimeLength";
            this.TimeLength.OptionsColumn.ReadOnly = true;
            this.TimeLength.Visible = true;
            this.TimeLength.VisibleIndex = 1;
            // 
            // Temperature
            // 
            this.Temperature.AppearanceCell.Options.UseTextOptions = true;
            this.Temperature.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Temperature.AppearanceHeader.Options.UseTextOptions = true;
            this.Temperature.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Temperature.Caption = "当前温度(℃)";
            this.Temperature.FieldName = "Temperature";
            this.Temperature.Name = "Temperature";
            this.Temperature.OptionsColumn.ReadOnly = true;
            this.Temperature.Visible = true;
            this.Temperature.VisibleIndex = 2;
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
            this.PlungerLocation.OptionsColumn.ReadOnly = true;
            this.PlungerLocation.Visible = true;
            this.PlungerLocation.VisibleIndex = 3;
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
            this.PlungerSpeed.OptionsColumn.ReadOnly = true;
            this.PlungerSpeed.Visible = true;
            this.PlungerSpeed.VisibleIndex = 4;
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "tabNavigationPageChart";
            this.tabNavigationPage2.Controls.Add(this.chartControlData);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.PageText = "实时数据绘图";
            this.tabNavigationPage2.Size = new System.Drawing.Size(940, 492);
            // 
            // chartControlData
            // 
            this.chartControlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControlData.Legend.Name = "Default Legend";
            this.chartControlData.Location = new System.Drawing.Point(0, 0);
            this.chartControlData.Name = "chartControlData";
            this.chartControlData.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControlData.Size = new System.Drawing.Size(940, 492);
            this.chartControlData.TabIndex = 0;
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // FrmRealTimeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 525);
            this.Controls.Add(this.tabPaneRealData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRealTimeData";
            this.Text = "FrmRealTimeData";
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneRealData)).EndInit();
            this.tabPaneRealData.ResumeLayout(false);
            this.tabNavigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRealTimeData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRealTimeData)).EndInit();
            this.tabNavigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControlData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.TabPane tabPaneRealData;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private DevExpress.XtraGrid.GridControl gridControlRealTimeData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRealTimeData;
        private DevExpress.XtraGrid.Columns.GridColumn Stage;
        private DevExpress.XtraGrid.Columns.GridColumn TimeLength;
        private DevExpress.XtraGrid.Columns.GridColumn Temperature;
        private DevExpress.XtraGrid.Columns.GridColumn PlungerLocation;
        private DevExpress.XtraGrid.Columns.GridColumn PlungerSpeed;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private DevExpress.XtraCharts.ChartControl chartControlData;
        //private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
    }
}