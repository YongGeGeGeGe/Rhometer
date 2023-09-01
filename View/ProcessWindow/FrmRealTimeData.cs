using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rheometer_Torque.View.ProcessWindow
{
    public partial class FrmRealTimeData : DevExpress.XtraEditors.XtraForm
    {
        public FrmRealTimeData()
        {
            InitializeComponent();            
        }
        Series seriesData = null;
        //图形纵坐标数据在DataTable中列名（柱塞位移）
        string ColumnNameOfAxisY = "PlungerLocation";
        //图形横坐标数据在DataTable中列名（时间）
        string ColumnNameOfAxisX = "ExperimentTime";
        //坐标X和Y初始值
        float StartValueOfAxisX = 0;
        float StartValueOfAxisY = 0;
        float maxData = 1;
        float minData = -1;
        private void gridViewRealTimeData_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.Caption== "实验阶段")
            {
                string strColumnTitle = e.Value.ToString();
                switch(strColumnTitle)
                {
                    case "0":
                        e.DisplayText="实验准备";
                        break;
                    case "1":
                        e.DisplayText = "加热准备";
                        break;
                    case "2":
                        e.DisplayText = "加料预热";
                        break;
                    case "3":
                        e.DisplayText = "实验进行";
                        break;
                    case "4":
                        e.DisplayText = "实验结束";
                        break;
                }
            }                        
        }

        private void gridViewRealTimeData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if(e.Info.IsRowIndicator && e.RowHandle>=0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

      /// <summary>
      /// 绘制图表
      /// </summary>      
        public void InitChart(DataRow row)
        {
            chartControlData.Series.Clear();
            this.splashScreenManager.ShowWaitForm();
            StartValueOfAxisX= (float)Math.Round(Convert.ToSingle(row[ColumnNameOfAxisX]), 2);
            StartValueOfAxisY = Convert.ToSingle(row[ColumnNameOfAxisY]);
            #region 根据实验类型及用户选择图表方式进行坐标数据与DataTable中数据列名建立对应关系

            string TitleString = "位移-时间";                   
            #endregion
            //从数据源中找到对应列的数据最小值
            //float minData = dt.AsEnumerable().Min(row => Convert.ToSingle(row[ColumnNameOfAxisY]));
            //从数据源中找到对应列的数据最大值
            //float maxData = dt.AsEnumerable().Max(row => Convert.ToSingle(row[ColumnNameOfAxisY]));
            //最大值放大30%设定为Y轴最大值
            //数据源中第一个数据（柱塞位置作为初始值）
            float maxDataY = Convert.ToSingle(maxData * 1.2);
            float minDataY = Convert.ToSingle(minData * 0.85);
            //初始化曲线
            seriesData = new Series(TitleString, ViewType.Spline);
            chartControlData.Series.Add(seriesData);
            //访问该系列的特定于视图类型的选项
            SplineSeriesView view = (SplineSeriesView)seriesData.View;
            view.LineMarkerOptions.Kind = MarkerKind.Circle;
            view.LineMarkerOptions.StarPointCount = 5;
            view.LineMarkerOptions.Size = 2;
            view.LineMarkerOptions.BorderColor = Color.Lime;
            //创建上下限线条
            XYDiagram diagram = (XYDiagram)chartControlData.Diagram;
            (chartControlData.Diagram as XYDiagram).AxisX.GridLines.Visible = true;//显示X轴线
            (chartControlData.Diagram as XYDiagram).AxisY.GridLines.Visible = true;//显示Y轴线
            //diagram.DefaultPane.BackColor = Color.Black;//背景颜色
            diagram.AxisY.ConstantLines.Clear();            
            //访问图表的特定于类型的选项。
            ((XYDiagram)chartControlData.Diagram).EnableAxisXZooming = true;
            //隐藏图例（如有必要）。
            chartControlData.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            //向图表添加标题（如有必要）。  
            if (chartControlData.Titles.Count == 0)
            {
                chartControlData.Titles.Add(new ChartTitle());
            }
            chartControlData.Titles[0].Text = TitleString;//标题
            chartControlData.Titles[0].Font = new Font("Tahoma", 14);
            //设置Y轴最小值和最大值，即默认情况下Y轴显示的范围
            AxisRange DIA = ((XYDiagram)chartControlData.Diagram).AxisY.Range;
            if (minDataY < maxDataY)
            {
                DIA.SetMinMaxValues(minDataY, maxDataY);
            }
            //将数据原点添加进绘图     
            seriesData.Points.Add(new SeriesPoint(0, 0));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    seriesData.Points.Add(new SeriesPoint(Math.Round(Convert.ToSingle(dt.Rows[i][ColumnNameOfAxisX]), 2), Convert.ToSingle(dt.Rows[i][ColumnNameOfAxisY])- Convert.ToSingle(dt.Rows[0][ColumnNameOfAxisY])));
            //}
            seriesData.ArgumentScaleType = ScaleType.Qualitative;
            seriesData.View = new DevExpress.XtraCharts.SplineSeriesView();// { Color = Color.LightGreen };
            //设置曲线为圆滑
            SplineSeriesView splineSeriesView1 = seriesData.View as SplineSeriesView;
            splineSeriesView1.LineTensionPercent = 80;
            //设置鼠标拖动放大
            diagram.ZoomingOptions.UseKeyboardWithMouse = true;
            diagram.ZoomingOptions.UseMouseWheel = true;
            diagram.ZoomingOptions.UseTouchDevice = true;
            diagram.EnableAxisXScrolling = true;
            diagram.EnableAxisXZooming = true;
            diagram.EnableAxisYScrolling = true;
            diagram.EnableAxisYZooming = true;
            diagram.AxisX.WholeRange.Auto = false;
            diagram.AxisY.WholeRange.Auto = false;
            this.splashScreenManager.CloseWaitForm();
        }
        public void UpdateChartDate(DataRow row)
        {            
            float dataX = (float)Math.Round(Convert.ToSingle(row[ColumnNameOfAxisX]), 2) - StartValueOfAxisX;
            float dataY= Convert.ToSingle(row[ColumnNameOfAxisY]) - StartValueOfAxisY;
            if (dataY> maxData)
            {
                maxData = dataY;
            }
            if(dataY<minData)
            {
                minData = dataY;
            }
            float maxDataY = Convert.ToSingle(maxData * 1.2);
            float minDataY = Convert.ToSingle(minData * 0.85);
            //设置Y轴最小值和最大值，即默认情况下Y轴显示的范围
            if (chartControlData.Diagram != null)
            {
                AxisRange DIA = ((XYDiagram)chartControlData.Diagram).AxisY.Range;
                if (minDataY < maxDataY)
                {
                    DIA.SetMinMaxValues(minDataY, maxDataY);
                }
            }            
            //将数据源数据更新到图表               
            seriesData.Points.Add(new SeriesPoint(dataX, dataY));       
        }       
    }
}
