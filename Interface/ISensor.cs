/// <summary>
/// 描述：传感器接口
/// 作者：杨慧炯
/// 创建日期：2023/6/18 10:48:28
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：
///修改日期：
///修改内容：
///===================================================================
/// Copyright (C) 2023 TIT All rights reserved.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rheometer_Torque.Interface
{
    internal interface ISensor
    {
        /// <summary>
        /// 设定传感器安全值
        /// </summary>
        /// <param name="thresholdValue">安全阈值</param>
        /// <returns></returns>
        bool SetThresholdValue(float thresholdValue);
        /// <summary>
        /// 设置电流校准值K
        /// </summary>
        /// <param name="adjustValue"校准值></param>
        /// <returns></returns>
        bool SetIAdjustValueK(float adjustValue);
        /// <summary>
        /// 设置电流校准值B
        /// </summary>
        /// <param name="adjustValue"校准值></param>
        /// <returns></returns>
        bool SetIAdjustValueB(float adjustValue);
        /// <summary>
        /// 设置校准值K
        /// </summary>
        /// <param name="adjustValue"校准值></param>
        /// <returns></returns>
        bool SetAdjustValueK(float adjustValue);
        /// <summary>
        /// 设置校准值B
        /// </summary>
        /// <param name="adjustValue"校准值></param>
        /// <returns></returns>
        bool SetAdjustValueB(float adjustValue);
        /// <summary>
        /// 设置偏移值X
        /// </summary>
        /// <param name="offSetValue"校准值></param>
        /// <returns></returns>
        bool SetOffsetValueX(float offsetValue);
        /// <summary>
        /// 查询设备设定的传感器安全值
        /// </summary>
        /// <returns>设备当前设定的安全阈值</returns>
        float GetThresholdValue();

    }
}
