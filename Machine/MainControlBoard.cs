/// <summary>
/// 描述：主控制板类，继承自控制板Control类，定义了主控制板相关指令的内存地址，初始化了主控制板通讯Tcp端口
/// 作者：杨慧炯
/// 创建日期：2023/6/17 22:25:32
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils.Communication;

namespace Rheometer_Torque.Machine
{
    internal class MainControlBoard : ControlBoard
    {
        private const int COMMAND_TOTAL_COUNTS = 16;

        public enum MainControlBoardStatus
        {
            /// <summary>
            /// 通讯正常
            /// </summary>
            CommNormal,
            /// <summary>
            /// 通讯失败
            /// </summary>
            CommFailure,            
        }
        public enum CommandAddress
        {
            /// <summary>
            /// 远程/本地模式
            /// </summary>
            OperntionMode = 0x0000,
            /// <summary>
            /// 主电机转速设定("0-5000",0.01r,0,WR)
            /// </summary>
            MainMotorSpeedSet=0x0001,
            /// <summary>
            /// 扭矩安全值设定("0-30000","0.01Nm","WR")
            /// </summary>
            TorqueThresholdSet=0x0002,
            /// <summary>
            /// 设备状态("R")
            /// </summary>
            MachineStatus=0x0003,
            /// <summary>
            /// 应急状态及设定("R")
            /// </summary>
            EmergencyStatus=0x0004,
            /// <summary>
            /// 主电机实时转速("0-5000","0.01r","R")
            /// </summary>
            MainMotorSpeedValue=0x0005,
            /// <summary>
            /// 输出轴实时扭矩("-30000-30000","0.01Nm","R")
            /// </summary>
            ScrewTorqueValue=0x0006,
            /// <summary>
            /// 扭矩越限后越限值("0-30000","0.01Nm","R")
            /// </summary>
            TorqueAlarmValue=0x0007,
            /// <summary>
            /// 主电机开关量状态("R")
            /// </summary>
            MainMotorOpenCloseStatus=0x0008,
            /// <summary>
            /// 主电机报警代码1("R")
            /// </summary>
            MainMotorAlarmCode_1=0x0009,
            /// <summary>
            /// 主电机报警代码2("R")
            /// </summary>
            MainMotorAlarmCode_2 = 0x000A,
            /// <summary>
            /// 主电机报警代码3("R")
            /// </summary>
            MainMotorAlarmCode_3 = 0x000B,
            /// <summary>
            /// 扭矩变送器电流实时值("0-25000","0.001A","R")
            /// </summary>
            TorqueIValue=0x000C,
            /// <summary>
            /// 扭矩电流值校准K("-30000-30000","0.0001","WR")
            /// </summary>
            TorqueIAdjustK=0x000D,
            /// <summary>
            /// 扭矩电流值校准K("-30000-30000","0.001","WR")
            /// </summary>
            TorqueIAdjustB = 0x000E,
            /// <summary>
            /// 扭矩值校准K("-30000-30000","0.0001","WR")
            /// </summary>
            TorqueAdjustK = 0x000F,
            /// <summary>
            /// 扭矩值校准B("-30000-30000","0.001","WR")
            /// </summary>
            TorqueAdjustB = 0x0010
        }
        public MainControlBoard()
        {
            _commandTotalCount= COMMAND_TOTAL_COUNTS;
            this._tcpPort = new TcpPort();
            this._tcpPort.TcpPortSet("TcpPort-MCB");
        }
        ~MainControlBoard()
        {
            //关闭端口连接          
            this._tcpPort.Close();
        }
        
    }
}
