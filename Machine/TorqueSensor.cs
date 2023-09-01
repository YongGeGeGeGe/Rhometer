/// <summary>
/// 描述：扭矩传感器类，继承自传感器类Sensor。实现扭矩传感器相关参数设置
/// 作者：杨慧炯
/// 创建日期：2023/6/18 10:47:45
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：张运勇
///修改日期：2023/6/20
///修改内容：完成各个方法的基本实现，实现扭矩传感器相关参数设置
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
    internal class TorqueSensor:Sensor
    {
        MainControlBoard mainControlBoard = new MainControlBoard();
        /// <summary>
        /// 设置校准值B(-30000~30000,0.001)
        /// </summary>
        /// <param name="adjustValue">校准值</param>
        /// <returns></returns>
        public override bool SetAdjustValueB(float adjustValue)
        {
            //判断校准值是否越限
            if (adjustValue < -30000 || adjustValue > 30000)
            {
                return false;
            }
            //需将校准值*1000后下发
            return mainControlBoard.SendControlCommand((int)MainControlBoard.CommandAddress.TorqueAdjustB, (int)adjustValue * 1000);
        }
        /// <summary>
        /// 设置校准值K(-30000~30000,0.0001)
        /// </summary>
        /// <param name="adjustValue">校准值</param>
        /// <returns></returns>
        public override bool SetAdjustValueK(float adjustValue)
        {
            //判断校准值是否越限
            if (adjustValue < -30000 || adjustValue > 30000)
            {
                return false;
            }
            //需将校准值*10000后下发
            return mainControlBoard.SendControlCommand((int)MainControlBoard.CommandAddress.TorqueAdjustK, (int)adjustValue * 10000);
        }
        /// <summary>
        /// 设置电流校准值B(-30000~30000,0.001)
        /// </summary>
        /// <param name="adjustValue">校准值</param>
        /// <returns></returns>
        public override  bool SetIAdjustValueB(float adjustValue)
        {
            //判断校准值是否越限
            if (adjustValue < -30000 || adjustValue > 30000)
            {
                return false;
            }
            //需将校准值*1000后下发
            return mainControlBoard.SendControlCommand((int)MainControlBoard.CommandAddress.TorqueIAdjustB, (int)adjustValue * 1000);
        }
        /// <summary>
        /// 设置电流校准值K(-30000~30000,0.0001)
        /// </summary>
        /// <param name="adjustValue">校准值</param>
        /// <returns></returns>
        public override  bool SetIAdjustValueK(float adjustValue)
        {
            //判断校准值是否越限
            if (adjustValue < -30000 || adjustValue > 30000)
            {
                return false;
            }
            //需将校准值*10000后下发
            return mainControlBoard.SendControlCommand((int)MainControlBoard.CommandAddress.TorqueIAdjustK, (int)adjustValue * 10000);
        }               
        /// <summary>
        /// 设定传感器安全值(0-30000,0.01Nm)
        /// </summary>
        /// <param name="thresholdValue">安全阈值</param>
        /// <returns></returns>
        public override bool SetThresholdValue(float thresholdValue)
        {
            //判断安全设定值是否越限
            if (thresholdValue < 0 || thresholdValue > 30000)
            {
                return false;
            }
            //需将设定值*100后下发
            return mainControlBoard.SendControlCommand((int)MainControlBoard.CommandAddress.TorqueThresholdSet, (int)thresholdValue * 100);
        }
        /// <summary>
        /// 查询设备设定的传感器安全值
        /// </summary>
        /// <returns>设备当前设定的安全阈值</returns>
        public override float GetThresholdValue()
        {
            Machine machine=new Machine();
            //bytes得到所有的数据
            List <byte[]> bytes = machine.ReadAllDatas();
            //data得到主控制板的所有采集的数据
            byte[] data =  bytes[0];
            //计算安全值的地址，得到数据
            return (float)data[10];

        }
    }
}
