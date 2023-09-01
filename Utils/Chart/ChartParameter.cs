/**
 * ________________________________________________________________________________ 
 *
 *  描述：图表参数类
 *  作者：杨慧炯
 *  版本：
 *  创建时间：2023/6/18 15:36:52
 *  类名：ChartParameter
 *  
 *  Copyright (C) 2023 TIT All rights reserved.
 *_________________________________________________________________________________
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraCharts;

namespace Rheometer.Utils.Chart
{
    public class ChartParameter
    {
        /// <summary>
        /// 图表坐标轴类型
        /// </summary>
        public enum AxisType
        {
            Line = 0,
            Log10 = 1
        }
        float _maxData;
        float _minData;
        float _maxDataOfAxisX;
        float _minDataOfAxisX;
        float _maxDataOfAxisY;
        float _minDataOfAxisY;
        ViewType _viewTypeOfSeries;
        AxisType _axisTypeOfX;
        AxisType _axisTypeOfY;
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
        public ViewType ViewTypeOfSeries { get => _viewTypeOfSeries; set => _viewTypeOfSeries = value; }
        /// <summary>
        /// X轴坐标系类型
        /// </summary>
        public AxisType AxisTypeOfX { get => _axisTypeOfX; set => _axisTypeOfX = value; }
        /// <summary>
        /// Y轴坐标系类型
        /// </summary>
        public AxisType AxisTypeOfY { get => _axisTypeOfY; set => _axisTypeOfY = value; }
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
    }
}
