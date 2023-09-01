/// <summary>
/// 描述：压力传感器类，继承自传感器类Sensor。实现压力传感器相关参数设置
/// 作者：杨慧炯
/// 创建日期：2023/6/18 13:08:13
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：张运勇
///修改日期：2023/6/19
///修改内容：完成各个方法的基本实现，实现压力传感器相关参数设置
///===================================================================
/// Copyright (C) 2023 TIT All rights reserved.
/// </summary>
using DevExpress.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rheometer_Torque.Machine
{
    internal class PressureSensor:Sensor
    {
        ////创建副控制板对象，通过副控制板端口下发控制指令
        AssistControlBoard assistControlBoard =new AssistControlBoard();
        /// <summary>
        /// 设置校准值B(-30000~30000,0.001)
        /// </summary>
        /// <param name="adjustValue">校准值(-30000~30000,0.001)</param>
        /// <returns></returns>
        public override bool SetAdjustValueB(float adjustValue)
        {
            //判断校准值是否越限
            if (adjustValue<-30000||adjustValue>30000)
            {

                return false;
            }
            //需将校准值adjustValue*1000后下发
            if (assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.PressureAdjustB,(int)adjustValue*1000))
            {
                return true;
            }
            else
            {
                return false;
            }
            
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
            if (assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.PressureAdjustK, (int)adjustValue * 10000))
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.PressureIAdjustB, (int)adjustValue * 1000))
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.PressureIAdjustK, (int)adjustValue * 10000))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设定传感器安全值(0-10000,0.01MPa)
        /// </summary>
        /// <param name="thresholdValue">安全阈值</param>
        /// <returns></returns>
        public override bool SetThresholdValue(float thresholdValue)
        {
            //判断设定值是否越限
            if (thresholdValue < 0 || thresholdValue > 10000)
            {
                return false;
            }
            //需将设定值thresholdValue*100后下发
            if (assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.PressureThresholdSet, (int)thresholdValue * 100))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 压力清零
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SetPressureZero()
        {
            //数据位0*01代表压力清零
            int setPressureZero = 0 * 01;
            if (assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.PressureZero, setPressureZero))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// 压力量程设定(0-10000,0.01MPa)
        /// </summary>
        /// <param name="range">设定量程值(0-10000,0.01MPa)</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SetPressureRange(float range)
        {
            //判断量程值是否越限
            if (range < 0 || range > 10000)
            {
                return false;
            }
            //需将量程值range*100后下发
            if (assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.PressureThresholdSet, (int)range * 100))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
