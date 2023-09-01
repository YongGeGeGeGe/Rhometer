/**
 * ________________________________________________________________________________ 
 *
 *  描述：
 *  作者：杨慧炯
 *  版本：
 *  创建时间：2023/6/18 22:30:44
 *  类名：ChartDataPoint
 *  
 *  Copyright (C) 2023 TIT All rights reserved.
 *_________________________________________________________________________________
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rheometer.Utils.Chart
{
    public class ChartDataPoint
    {
        float _dataOfAxisX;
        float _dataOfAxisY;
        /// <summary>
        /// X轴数据
        /// </summary>
        public float DataOfAxisX { get => _dataOfAxisX; set => _dataOfAxisX = value; }
        /// <summary>
        /// Y轴数据
        /// </summary>
        public float DataOfAxisY { get => _dataOfAxisY; set => _dataOfAxisY = value; }
    }
}
