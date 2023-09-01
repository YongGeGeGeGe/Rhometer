/// <summary>
/// 描述：温度传感器类，继承自传感器类Sensor。实现温度传感器相关参数设置
/// 作者：杨慧炯
/// 创建日期：2023/6/18 13:10:02
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：张运勇
///修改日期：2023/6/20
///修改内容：完成各个方法的基本实现，实现温度传感器相关参数设置
///===================================================================
/// Copyright (C) 2023 TIT All rights reserved.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rheometer_Torque.Machine
{
    internal class TemperatureSensor:Sensor
    {
        AssistControlBoard assistControlBoard =new AssistControlBoard();
        /// <summary>
        /// 设定传感器安全值(0-150.00,0.01℃)
        /// </summary>
        /// <param name="thresholdValue">安全阈值</param>
        /// <returns></returns>
        public override bool SetThresholdValue(float thresholdValue)
        {
            //判断设定值是否越限
            if (thresholdValue<0||thresholdValue>150)
            {
                return false;
            }
            //需将设定值*100后下发
            return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.NoseTemperatureThresholdSet, (int)thresholdValue*100);
        }

        /// <summary>
        /// 设置校准值B(-30000~30000,0.001)
        /// </summary>
        /// <param name="adjustValue">校准值(-30000~30000,0.001)</param>
        /// <returns></returns>
        public override bool SetAdjustValueB(float adjustValue)
        {
            //判断校准值是否越限
            if (adjustValue < -30000 || adjustValue > 30000)
            {
                return false;
            }
            //需将校准值adjustValue*1000后下发
            return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.NoseTemperatureAdjustB, (int)adjustValue * 1000);
        }
        /// <summary>
        /// 设置校准值K(-30000~30000,0.0001)
        /// </summary>
        /// <param name="adjustValue">校准值(-30000~30000,0.0001)</param>
        /// <returns></returns>
        public override bool SetAdjustValueK(float adjustValue)
        {
            //判断校准值是否越限
            if (adjustValue < -30000 || adjustValue > 30000)
            {
                return false;
            }

            //需将校准值adjustValue*10000后下发
            return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.NoseTemperatureAdjustK, (int)adjustValue * 10000);
        }
        /// <summary>
        /// 设置电流校准值B(-30000~30000,0.001)
        /// </summary>
        /// <param name="adjustValue">校准值(-30000~30000,0.001)</param>
        /// <returns></returns>
        public override bool SetIAdjustValueB(float adjustValue)
        {
            //判断校准值是否越限
            if (adjustValue < -30000 || adjustValue > 30000)
            {
                return false;
            }
            //需将校准值adjustValue*1000后下发
            return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.NoseTemperatureIAdjustB, (int)adjustValue * 1000);
        }
        /// <summary>
        /// 设置电流校准值K(-30000~30000,0.0001)
        /// </summary>
        /// <param name="adjustValue">校准值</(-30000~30000,0.0001)>
        /// <returns></returns>
        public override bool SetIAdjustValueK(float adjustValue)
        {
            //判断校准值是否越限
            if (adjustValue < -30000 || adjustValue > 30000)
            {
                return false;
            }
            //需将校准值adjustValue*10000后下发
            return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.NoseTemperatureIAdjustK, (int)adjustValue * 10000);
        }
        /// <summary>
        /// 设置偏移值X(0-150.00,0.01℃)
        /// </summary>
        /// <param name="offSetValue">偏移值(0-150.00,0.01℃)</param>
        /// <returns></returns>
        public override bool SetOffsetValueX(float offsetValue)
        {
            //判断偏移值是否越限
            if (offsetValue < 0 || offsetValue > 150)
            {
                return false;
            }
            //需将偏移值offSetValue*100后下发
            return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.NoseTemperatureOffsetAdjustX, (int)offsetValue * 100);
        }
    }
}
