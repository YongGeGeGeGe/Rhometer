/**
 * ________________________________________________________________________________ 
 *
 *  描述：图表绘制
 *  作者：杨慧炯
 *  版本：
 *  创建时间：2023/6/18 18:01:09
 *  类名：Chart
 *  
 *  Copyright (C) 2023 TIT All rights reserved.
 *_________________________________________________________________________________
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Controls;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using System.Drawing;
using System.Data;


namespace Rheometer.Utils.Chart
{
    public class Chart
    {
        #region 参数
        float _maxData;
        float _minData;
        float _maxDataOfAxisX;
        float _minDataOfAxisX;
        float _maxDataOfAxisY;
        float _minDataOfAxisY;
        //ViewType _viewTypeOfSeries;
        ChartParameter.AxisType _axisTypeOfX;
        ChartParameter.AxisType _axisTypeOfY;
        string _titleString;
        string _titleStringOfAxisX;
        string _titleStringOfAxisY;
        string _columnNameOfAxisX;
        string _columnNameOfAxisY;
        /// <summary>
        /// 图表值峰值
        /// </summary>
        public float MaxData { get => _maxData; set => _maxData = value; }
        /// <summary>
        /// 图表谷值
        /// </summary>
        public float MinData { get => _minData; set => _minData = value; }
        /// <summary>
        /// X轴最大值
        /// </summary>
        public float MaxDataOfAxisX { get => _maxDataOfAxisX; set => _maxDataOfAxisX = value; }
        /// <summary>
        /// X轴最小值
        /// </summary>
        public float MinDataOfAxisX { get => _minDataOfAxisX; set => _minDataOfAxisX = value; }
        /// <summary>
        /// Y轴最大值
        /// </summary>
        public float MaxDataOfAxisY { get => _maxDataOfAxisY; set => _maxDataOfAxisY = value; }
        /// <summary>
        /// Y轴最小值
        /// </summary>
        public float MinDataOfAxisY { get => _minDataOfAxisY; set => _minDataOfAxisY = value; }
        /// <summary>
        /// 图表绘制类型
        /// </summary>
        //public ViewType ViewTypeOfSeries { get => _viewTypeOfSeries; set => _viewTypeOfSeries = value; }
        /// <summary>
        /// X轴坐标系类型
        /// </summary>
        public ChartParameter.AxisType AxisTypeOfX { get => _axisTypeOfX; set => _axisTypeOfX = value; }
        /// <summary>
        /// Y轴坐标系类型
        /// </summary>
        public ChartParameter.AxisType AxisTypeOfY { get => _axisTypeOfY; set => _axisTypeOfY = value; }
        /// <summary>
        /// 图表标题
        /// </summary>
        public string TitleString { get => _titleString; set => _titleString = value; }
        /// <summary>
        /// X轴标题说明
        /// </summary>
        public string TitleStringOfAxisX { get => _titleStringOfAxisX; set => _titleStringOfAxisX = value; }
        /// <summary>
        /// Y轴标题说明
        /// </summary>
        public string TitleStringOfAxisY { get => _titleStringOfAxisY; set => _titleStringOfAxisY = value; }
        /// <summary>
        /// X轴数据对应列名
        /// </summary>
        public string ColumnNameOfAxisX { get => _columnNameOfAxisX; set => _columnNameOfAxisX = value; }
        /// <summary>
        /// Y轴数据对应列名
        /// </summary>
        public string ColumnNameOfAxisY { get => _columnNameOfAxisY; set => _columnNameOfAxisY = value; }
        #endregion

        #region   图表基础

        /// <summary>
        /// 创建图表
        /// </summary>        
        /// <param name="chartControlName">图表的名称</param>
        /// <param name="initLocation">图表的初始位置</param>
        /// <param name="InitSize">图表的初始大小</param>
        /// <returns></returns>
        public ChartControl CreateChart(Form form,string titleName, string chartControlName,
            System.Drawing.Point initLocation, System.Drawing.Size InitSize)
        {
            ChartControl chartControl = new ChartControl();
            chartControl.Legend.Name = "Default Legend";
            chartControl.Location = initLocation;
            chartControl.Name = chartControlName;
            chartControl.Size = InitSize;
            chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];

            //添加标题
            if (chartControl.Titles.Count < 1)
            {
                chartControl.Titles.Add(new ChartTitle());
                chartControl.Titles[0].Text = titleName;
            }

            form.Controls.Add(chartControl);
            chartControl.Show();

            return chartControl;
        }

        /// <summary>
        /// 清空图表
        /// </summary>
        /// <param name="chartControl">图表</param>
        public void ClearChart(Form form,ChartControl chartControl)
        {
            if (chartControl != null)
            {
                form.Controls.Remove(chartControl);
                chartControl = null;
                chartControl?.Dispose();
            }

        }

        /// <summary>
        /// 填充数据到线性图表
        /// </summary>
        /// <param name="seriesName">图例类型名称</param>
        /// <param name="curSeriesAllDataDic">图例类型对应的所有数据</param>
        /// <param name="chartControl">线性图表</param>
        /// <param name="viewType">线性图表类型</param>
        public void FillDataToLineChart(string seriesName,
            List<ChartDataPoint>  curSeriesAllDataPoint,
            ChartControl chartControl, ViewType viewType = ViewType.Line)
        {
            if (chartControl == null ||
                curSeriesAllDataPoint == null && curSeriesAllDataPoint.Count == 0) return;

            //添加一个类型的数据
            Series series = new Series(seriesName, viewType);

            foreach (ChartDataPoint item in curSeriesAllDataPoint)
            {
                series.Points.Add(new SeriesPoint(item.DataOfAxisX, item.DataOfAxisY));
            }
            //会影响X轴坐标尺度大小
            series.ArgumentScaleType = ScaleType.Auto;           
            chartControl.Series.Add(series);

            //图例的样式设置
            switch(viewType)
            {
                case ViewType.Line://点线图               
                    ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                    ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Circle;
                    ((LineSeriesView)series.View).LineStyle.DashStyle = DashStyle.Solid;
                    break;
                case ViewType.Point: //点图                   
                    ((PointSeriesView)series.View).PointMarkerOptions.Kind = MarkerKind.Circle;                   
                    break;
            }                                    
        }

        /// <summary>
        /// 图表设置
        /// </summary>
        /// <param name="chartControl">chartControl图表</param>
        /// <param name="axisXName">X轴名称</param>
        /// <param name="axisYName">Y轴名称</param>
        public void ChartSettings(ChartControl chartControl,ChartParameter parameter)
        {
            //向图表添加标题  
            if (chartControl.Titles.Count == 0)
            {
                chartControl.Titles.Add(new ChartTitle());
            }
            chartControl.Titles[0].Text = parameter.TitleString;//标题
            chartControl.Titles[0].Font = new Font("Tahoma", 14);
            //显示图例复选框
            Legend legend = new Legend();
            legend.Name = "Legend";
            legend.UseCheckBoxes = true;
            chartControl.Legends.Add(legend);
           
            //chartControl.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;

            XYDiagram diagram = (XYDiagram)chartControl.Diagram;

            if (diagram != null)
            {
                (chartControl.Diagram as XYDiagram).AxisX.GridLines.Visible = true;//显示X轴线
                (chartControl.Diagram as XYDiagram).AxisY.GridLines.Visible = true;//显示Y轴线
                //X轴坐标类型
                switch (parameter.AxisTypeOfX)
                {
                    case ChartParameter.AxisType.Line:
                        diagram.AxisX.Logarithmic = false;
                        break;
                    case ChartParameter.AxisType.Log10:
                        //以对数坐标方式显示刻度标签
                        diagram.AxisX.Logarithmic = true;
                        break;
                }
                //Y轴坐标类型
                switch (parameter.AxisTypeOfY)
                {
                    case ChartParameter.AxisType.Line:
                        diagram.AxisY.Logarithmic = false;
                        break;
                    case ChartParameter.AxisType.Log10:
                        //以对数坐标方式显示刻度标签
                        diagram.AxisY.Logarithmic = true;
                        break;
                }
                //允许缩放X轴
                diagram.EnableAxisXZooming = true;
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisX.Title.Alignment = StringAlignment.Far;
                diagram.AxisX.Title.Text = parameter.TitleStringOfAxisX;
                //设置X轴数据显示角度
                diagram.AxisX.Label.Angle = -45;
                //要开启滚动条需设置自动范围为false
                diagram.AxisX.VisualRange.Auto = false;
                //启用X轴滚动条
                diagram.EnableAxisXScrolling = true;
                //在不拉动滚动条的时候，X轴显示的数据个数（固定X轴的长度）
                if (parameter.MinDataOfAxisX < parameter.MaxDataOfAxisX)
                {
                    diagram.AxisX.WholeRange.SetMinMaxValues((int)Math.Floor(parameter.MinDataOfAxisX), (int)Math.Ceiling(parameter.MaxDataOfAxisX));
                }
                // Define the whole range for the Y-axis. 
                diagram.AxisY.WholeRange.Auto = false;
                if (parameter.MinDataOfAxisY < parameter.MaxDataOfAxisY)
                {
                    diagram.AxisY.WholeRange.SetMinMaxValues((int)Math.Floor(parameter.MinDataOfAxisY), (int)Math.Ceiling(parameter.MaxDataOfAxisY));
                }
                //允许缩放Y轴
                diagram.EnableAxisYZooming = true;
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisY.Title.Alignment = StringAlignment.Far;
                diagram.AxisY.Title.Text = parameter.TitleStringOfAxisY;
                


                diagram.ZoomingOptions.UseKeyboardWithMouse = true;
                diagram.ZoomingOptions.UseMouseWheel = true;
                diagram.ZoomingOptions.UseTouchDevice = true;
                diagram.EnableAxisXScrolling = true;
                
                diagram.EnableAxisYScrolling = true;               

                //创建上下限线条                                                                                
                //diagram.AxisY.ConstantLines.Clear();
                //ConstantLine constantLine1 = new ConstantLine("峰值:" + parameter.MaxData, parameter.MaxData);
                //constantLine1.Color = Color.Red;//直线颜色
                //constantLine1.Title.TextColor = Color.Red;//直线文本字体颜色      
                //diagram.AxisY.ConstantLines.Add(constantLine1);
                //ConstantLine constantLine2 = new ConstantLine("谷值:" + parameter.MinData, parameter.MinData);
                //constantLine2.Color = Color.Red;
                //constantLine2.Title.TextColor = Color.Red;
                //diagram.AxisY.ConstantLines.Add(constantLine2);
                //chartControl.CrosshairOptions.ShowArgumentLabels = true;
                //chartControl.CrosshairOptions.ShowValueLine = true;
            }
        }

        //初始化图表
        public  void InitChartSettings(ChartControl chartControl, string axisXName, string axisYName,int minValueOfAxisX, int maxValueOfAxisX, int minVallueOfAxisY, int maxValueOfAxisY)
        {            
            XYDiagram diagram = (XYDiagram)chartControl.Diagram;

            if (diagram != null)
            {
                //允许缩放X轴
                diagram.EnableAxisXZooming = true;
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisX.Title.Alignment = StringAlignment.Far;
                diagram.AxisX.Title.Text = axisXName;
                //要开启滚动条需设置自动范围为false
                diagram.AxisX.VisualRange.Auto = false;
                //启用X轴滚动条
                diagram.EnableAxisXScrolling = true;

                //在不拉动滚动条的时候，X轴显示的数据个数（固定X轴的长度）
                diagram.AxisX.WholeRange.SetMinMaxValues(minValueOfAxisX, maxValueOfAxisX);

                // Define the whole range for the Y-axis. 
                diagram.AxisY.WholeRange.Auto = false;
                diagram.AxisY.WholeRange.SetMinMaxValues(minVallueOfAxisY, maxValueOfAxisY);


                //允许缩放Y轴
                diagram.EnableAxisYZooming = true;
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisY.Title.Alignment = StringAlignment.Far;
                diagram.AxisY.Title.Text = axisYName;

                //chartControl.CrosshairOptions.ShowArgumentLabels = true;
                //chartControl.CrosshairOptions.ShowValueLine = true;
            }
        }
        #endregion
    }
}
