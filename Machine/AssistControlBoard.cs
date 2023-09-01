/// <summary>
/// 描述：辅控制板类，继承自控制板Control类，定义了辅控制板相关指令的内存地址，初始化了辅控制板通讯Tcp端口
/// 作者：杨慧炯
/// 创建日期：2023/6/11 22:25:32
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
using Utils.Communication;

namespace Rheometer_Torque.Machine
{
    internal class AssistControlBoard:ControlBoard
    {
        private const int COMMAND_TOTAL_COUNTS= 66;        
        public AssistControlBoard()
        {
            _commandTotalCount = COMMAND_TOTAL_COUNTS;
            this._tcpPort = new TcpPort();
            this._tcpPort.TcpPortSet("TcpPort-ACB");            
        }

        public enum CommandAddress
        {
            /// <summary>
            /// 远程/本地模式
            /// </summary>
            OperntionMode=0x0000,
            /// <summary>
            /// 喂料速度设定
            /// </summary>
            FeedingSpeedSet = 0x0001,            
            /// <summary>
            /// 机头电机开合设定
            /// </summary>
            NoseOpenCloseSet = 0x0003,
            /// <summary>
            /// 刀头切粒速度设定
            /// </summary>
            SlicingSpeedSet = 0x0004,
            /// <summary>
            /// 料粒分区动作
            /// </summary>
            SwitchAreaSet = 0x0005,
            /// <summary>
            /// 称料周期设定
            /// </summary>
            WeightingCycleSet = 0x0006,
            /// <summary>
            ///压力清零
            /// </summary
            PressureZero = 0x0007,
            /// <summary>
            /// 电子称去皮
            /// </summary>
            ScaleZero = 0x0008,
            /// <summary>
            /// 机头压力安全值设定(-10000, 0.01MPa, WR)
            /// </summary>
            PressureThresholdSet = 0x0009,
            /// <summary>
            /// 机头温度安全值设定(0-150.00, 0.01℃, WR)
            /// </summary>
            NoseTemperatureThresholdSet = 0x000A,
            /// <summary>
            /// 设备状态(R)
            /// </summary>
            MachineStatus0x000B,
            /// <summary>
            /// 应急状态及设定(R)
            /// </summary>
            EmergencyStatus = 0x000C,
            /// <summary>
            /// 喂料实时速度(0-5000,0.01r,R)
            /// </summary>
            FeedingSpeed = 0x000D,
            /// <summary>
            /// 机头电机位置状态(R)
            /// </summary>
            NosePositionStatus = 0x000E,
            /// <summary>
            /// 机头电机实时位置(0-20000, 0.1mm, R)
            /// </summary>
            NosePosition= 0x000F,
            /// <summary>
            /// 料筒电机位置状态(R)
            /// </summary>
            BucketPositionStatus=0x0010,
            /// <summary>
            /// 料筒电机实时位置(0-20000, 0.1mm, R)
            /// </summary>
            BucketPosition = 0x0011,
            /// <summary>
            /// 机头压力实时值("0-10000", "0.01MPa", "R")
            /// </summary>
            NosePressureValue = 0x0012,
            /// <summary>
            /// 机头温度实时值("0-150.00", "0.01℃", "R")
            /// </summary>
            NoseTemperatureValue = 0x0013,
            /// <summary>
            /// 回水温度实时值1("0-150.00", "0.01℃", "R")
            /// </summary>
            BackWaterTemperatureValue_1=0x0014,
            /// <summary>
            /// 回水温度实时值2("0-150.00", "0.01℃", "R")
            /// </summary>
            BackWaterTemperatureValue_2 = 0x0015,
            /// <summary>
            /// 称重部分实时值读取高字节("0-2000.00", "0.01g", "R")
            /// </summary>
            MassValueOfHightByte=0x0016,
            /// <summary>
            /// 称重部分实时值读取低字节("0-2000.00", "0。01g", "R")
            /// </summary>
            MassValueOfLowByte = 0x0017,
            /// <summary>
            /// 机头温度越限后的越限值("0-150.00", "0.01℃", "R")
            /// </summary>
            NoseTemperatureAlarmValue=0x0018,
            /// <summary>
            /// 压力越限后越限值("0-10000", "0.01MPa", "R")
            /// </summary>
            PressureAlarmValue=0x0019,
            /// <summary>
            /// 喂料电机开关量状态("R")
            /// </summary>
            FeedingMotorOpenCloseStatus=0x001A,
            /// <summary>
            /// 喂料电机报警代码1("R")
            /// </summary>
            FeedingMotorAlarmCode_1=0x001B,
            /// <summary>
            /// 喂料电机报警代码2("R")
            /// </summary>
            FeedingMotorAlarmCode_2=0x001C,
            /// <summary>
            /// 喂料电机报警代码3("R")
            /// </summary>
            FeedingMotorAlarmCode_3=0x001D,
            /// <summary>
            /// 机头电机开关量状态"R")
            /// </summary>
            NoseOpenCloseStatus=0x001E,
            /// <summary>
            /// 机头电机报警代码1("R")
            /// </summary>
            NoseAlarmCode_1=0x001F,
            /// <summary>
            /// 机头电机报警代码2("R")
            /// </summary>
            NoseAlarmCode_2=0x0020,
            /// <summary>
            /// 机头电机报警代码3(R")
            /// </summary>
            NoseAlarmCode_3=0x0021,
            /// <summary>
            /// 料筒电机A开关量状态("R")
            /// </summary>
            BucketAOpenCloseStatus=0x0022,
            /// <summary>
            /// 料筒电机A报警代码1("R")
            /// </summary>
            BucketAAlarmCode_1=0x0023,
            /// <summary>
            /// 料筒电机A报警代码2("R")
            /// </summary>
            BucketAAlarmCode_2=0x0024,
            /// <summary>
            /// 料筒电机A报警代码3("R")
            /// </summary>
            BucketAAlarmCode_3 = 0x0025,
            /// <summary>
            /// 料筒电机B开关量状态("R")
            /// </summary>
            BucketBOpenCloseStatusSpeedSet = 0x0026,
            /// <summary>
            /// 料筒电机B报警代码1("R")
            /// </summary>
            BucketBAlarmCode_1=0x0027,
            /// <summary>
            /// 料筒电机B报警代码2("R")
            /// </summary>
            BucketBAlarmCode_2=0x0028,
            /// <summary>
            /// 料筒电机B报警代码3("R")
            /// </summary>
            BucketBAlarmCode_3=0x0029,
            /// <summary>
            /// 电子称报警代码("R")
            /// </summary>
            ScaleAlarmCode=0x002A,
            /// <summary>
            /// 压力传感器量程选择("0-10000", "0.01MPa", "WR")
            /// </summary>
            PressureRange=0x002B,
            /// <summary>
            /// 压力电流值校准K("-30000-30000", "0.0001", "WR")
            /// </summary>
            PressureIAdjustK=0x002C,
            /// <summary>
            /// 压力电流值校准B("-30000-30000", "0.001", "WR")
            /// </summary>
            PressureIAdjustB=0x002D,
            /// <summary>
            /// 压力值校准K("-30000-300000", "0.0001", "WR")
            /// </summary>
            PressureAdjustK=0x002E,
            /// <summary>
            /// 压力值校准B("-30000-300000", "0.001", "WR")
            /// </summary>
            PressureAdjustB=0x002F,
            /// <summary>
            /// 机头温度电流值校准K"("-30000-300000", "0.0001", "WR")
            /// </summary>
            NoseTemperatureIAdjustK=0x0030,
            /// <summary>
            /// 机头温度电流值校准B("-30000-30000", "0.001", "WR")
            /// </summary>
            NoseTemperatureIAdjustB=0x0031,
            /// <summary>
            /// 机头温度值校准K("-30000-30000", "0.0001", "WR")
            /// </summary>
            NoseTemperatureAdjustK=0x0032,
            /// <summary>
            /// 机头温度值校准B("-30000-30000", "0.001", "WR")
            /// </summary>
            NoseTemperatureAdjustB=0x0033,
            /// <summary>
            /// 机头温度偏移值X("0-150.00", "0.01℃", "WR")
            /// </summary>
            NoseTemperatureOffsetAdjustX=0x0034,
            /// <summary>
            /// 回水温度1电流值校准K("-30000-30000", "0.0001", "WR")
            /// </summary>
            BackWaterIAdjustK_1=0x0035,
            /// <summary>
            /// 回水温度1电流值校准B("-30000-30000", "0.001", "WR")
            /// </summary>
            BackWaterIAdjustB_1=0x0036,
            /// <summary>
            /// 回水温度1值校准K("-30000-30000", "0.0001", "WR")
            /// </summary>
            BackWaterAdjustK_1=0x0037,
            /// <summary>
            /// 回水温度1值校准B("-30000-30000", "0.001", "WR")
            /// </summary>
            BackWaterAdjustB_1=0x0038,
            /// <summary>
            /// 回水温度1偏移值X("0-150.00", "0.01℃", "WR")
            /// </summary>
            BackWaterOffsetAdjustX_1 = 0x0039,
            /// <summary>
            /// 回水温度2电流值校准K("-30000-30000", "0.0001", "WR")
            /// </summary>
            BackWaterIAdjustK_2=0x003A,
            /// <summary>
            /// 回水温度2电流值校准B("-30000-30000", "0.001", "WR")
            /// </summary>
            BackWaterIAdjustB_2=0x003B,
            /// <summary>
            /// 回水温度2值校准K("-30000-30000", "0.0001", "WR")
            /// </summary>
            BackWaterAdjustK_2=0x003C,
            /// <summary>
            /// 回水温度2值校准B("-30000-30000", "0.001", "WR")
            /// </summary>
            BackWaterAdjustB_2=0x003D,
            /// <summary>
            /// 回水温度2偏移值X("0-150.00", "0.01℃", "WR")
            /// </summary>
            BackWaterOffsetAdjustX_2=0x003E,
            /// <summary>
            /// 压力变送器电流实时值("0-25000", "0.001A", "R")
            /// </summary>
            PressureIValue=0x003F,
            /// <summary>
            /// 机头温度变送器电流实时值("0-25000", "0.001A", "R")
            /// </summary>
            NoseIValue=0x0040,
            /// <summary>
            /// 回水温度1变送器电流实时值("0-25000", "0.001A", "R")
            /// </summary>
            BackWaterIValue_1=0x0041,
            /// <summary>
            /// 回水温度2变送器电流实时值("0-25000", "0.001A", "R")
            /// </summary>
            BackWaterIValue_2=0x0042            
        }

        ~AssistControlBoard()
        {
            //关闭端口连接
            this._tcpPort.Close();
        }
    }
}
