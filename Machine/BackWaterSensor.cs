/// <summary>
/// 描述：回水温度传感器类，继承自传感器类Sensor。实现回水温度传感器相关参数设置
/// 作者：杨慧炯
/// 创建日期：2023/6/18 13:11:41
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：张运勇
///修改日期：2023/6/20
///修改内容：完成各个方法的基本实现，实现回水温度传感器相关参数设置
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
    internal class BackWaterSensor:Sensor
    {
        AssistControlBoard assistControlBoard = new AssistControlBoard();
        bool _isFirstBackWaterSensor;//通过_isFirstBackWaterSensor下发不同的指令

        /// <summary>
        /// 实例化对象时，分辨是回水温度传感器1还是2
        /// </summary>
        /// <param name="isFirstBackWaterSensor">是否是温度传感器1</param>
        public BackWaterSensor(bool isFirstBackWaterSensor)
        {
            _isFirstBackWaterSensor = isFirstBackWaterSensor;
        }
        /// <summary>
        /// 设置回水温度传感器校准值B(-30000~30000,0.001)
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
            if (_isFirstBackWaterSensor)
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterAdjustB_1, (int)adjustValue * 1000);
            }
            else
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterAdjustB_2, (int)adjustValue * 1000);
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
            if (_isFirstBackWaterSensor)
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterAdjustK_1, (int)adjustValue * 10000);
            }
            else
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterAdjustK_2, (int)adjustValue * 10000);
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
            if (_isFirstBackWaterSensor)
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterIAdjustB_1, (int)adjustValue * 1000);
            }
            else
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterIAdjustB_2, (int)adjustValue * 1000);
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
            if (_isFirstBackWaterSensor)
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterIAdjustK_1, (int)adjustValue * 10000);
            }
            else
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterIAdjustK_2, (int)adjustValue * 10000);
            }
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
            if (_isFirstBackWaterSensor)
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterOffsetAdjustX_1, (int)offsetValue * 100);
            }
            else
            {
                return assistControlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.BackWaterOffsetAdjustX_2, (int)offsetValue * 100);
            }
        }
    }
}
