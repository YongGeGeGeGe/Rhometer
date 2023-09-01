/// <summary>
/// 描述：机头类，实现机头的动作控制及状态、相关数据采集
/// 作者：杨慧炯
/// 创建日期：2023/6/11 22:16:22
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：刘子民
///修改日期：2023/6/26
///修改内容：机头类   开关停的功能
///===================================================================
/// Copyright (C) 2023 TIT All rights reserved.
/// </summary>
using Rheometer_Torque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rheometer_Torque.Machine.Bucket;

namespace Rheometer_Torque.Machine
{
    public class Nose : Motor, IMotor,INose
    {
        /// <summary>
        /// 机头位置状态
        /// </summary>
        public enum NoseState
        {
            /// <summary>
            /// 开
            /// </summary>
            Opened = 0x01,
            /// <summary>
            /// 合
            /// </summary>
            Closed = 0x02,
            /// <summary>
            /// 停止
            /// </summary>
            Stoped = 0x00
        }
        public override int[] getAlarmCode()
        {
            throw new NotImplementedException();
        }

        public override bool GetSpeed()
        {
            throw new NotImplementedException();
        }

        public override bool getState()
        {
            throw new NotImplementedException();
        }

        public override bool SetSpeed(float speed)
        {
            throw new NotImplementedException();
        }        
        /// <summary>
        /// 机头停止
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool Stop()
        {
            //throw new NotImplementedException();

            //向主控板端口下发控制指令,需将转速*100后下发
            ControlBoard controlBoard = new AssistControlBoard();
            //主电机速度精度为0.01r，下发时应乘以100
            return controlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.NoseOpenCloseSet, (int)NoseState.Stoped);

        }
        /// <summary>
        /// 机头开
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Open()
        {
            //throw new NotImplementedException();

            //向主控板端口下发控制指令,需将转速*100后下发
            ControlBoard controlBoard = new AssistControlBoard();
            //主电机速度精度为0.01r，下发时应乘以100
            return controlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.NoseOpenCloseSet, (int)NoseState.Opened);

        }
        /// <summary>
        /// 机头合
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Close()
        {
            //throw new NotImplementedException();

            //向主控板端口下发控制指令,需将转速*100后下发
            ControlBoard controlBoard = new AssistControlBoard();
            //主电机速度精度为0.01r，下发时应乘以100
            return controlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.NoseOpenCloseSet, (int)NoseState.Closed);

        }

        public MachineState GetPositionState()
        {
            throw new NotImplementedException();
        }

        public int GetPosition()
        {
            throw new NotImplementedException();
        }

        public bool SetAlarmTemperature(int temperature)
        {
            throw new NotImplementedException();
        }

        public bool GetTemperature()
        {
            throw new NotImplementedException();
        }

        public bool GetOverRunTemperature()
        {
            throw new NotImplementedException();
        }

        public bool GetDeviceAdjustParam()
        {
            throw new NotImplementedException();
        }

        public bool SetAdjustValueOfIOfK()
        {
            throw new NotImplementedException();
        }
    }
}
