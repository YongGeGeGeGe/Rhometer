/// <summary>
/// 描述：传感器类，为所有传感器类的基类
/// 作者：杨慧炯
/// 创建日期：2023/6/18 10:48:06
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
using Rheometer_Torque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rheometer_Torque.Machine
{
    internal class Sensor : ISensor
    {
        /// <summary>
        /// 设置校准值B
        /// </summary>
        /// <param name="adjustValue">校准值</param>
        /// <returns></returns>
        public virtual bool SetAdjustValueB(float adjustValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 设置校准值K
        /// </summary>
        /// <param name="adjustValue">校准值</param>
        /// <returns></returns>
        public virtual bool SetAdjustValueK(float adjustValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 设置电流校准值B
        /// </summary>
        /// <param name="adjustValue">校准值</param>
        /// <returns></returns>
        public virtual bool SetIAdjustValueB(float adjustValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 设置电流校准值K
        /// </summary>
        /// <param name="adjustValue">校准值</param>
        /// <returns></returns>
        public virtual bool SetIAdjustValueK(float adjustValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 设置偏移值X
        /// </summary>
        /// <param name="offSetValue">校准值</param>
        /// <returns></returns>
        public virtual bool SetOffsetValueX(float offsetValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 设定传感器安全值
        /// </summary>
        /// <param name="thresholdValue">安全阈值</param>
        /// <returns></returns>
        public virtual bool SetThresholdValue(float thresholdValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询设备设定的传感器安全值
        /// </summary>
        /// <returns>设备当前设定的安全阈值</returns>
        public virtual float GetThresholdValue()
        {
            throw new NotImplementedException();
        }
    }
}
