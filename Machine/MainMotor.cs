/// <summary>
/// 描述：主电机类，实现主电机的控制及状态、相关数据采集
/// 作者：杨慧炯
/// 创建日期：2023/6/11 22:13:16
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：刘子民
///修改日期：2023/6/26
///修改内容：主电机类  设置速度的功能
///===================================================================
/// Copyright (C) 2023 TIT All rights reserved.
/// </summary>
using DevExpress.Spreadsheet;
using Rheometer_Torque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rheometer_Torque.Machine
{
    public class MainMotor : Motor, IMotor
    {
        #region 主电机控制及数据采集指令指令
        const string PROTOCOL_SETSPEED = "";
        #endregion

        public enum MainMotorStatus
        {
            /// <summary>
            /// 通讯正常
            /// </summary>
            CommNormal,
            /// <summary>
            /// 通讯失败
            /// </summary>
            CommFailure,
            /// <summary>
            /// 工作正常
            /// </summary>
            OperationNormal,
            /// <summary>
            /// 报警
            /// </summary>
            Alarm
        }
        /// <summary>
        /// //控制电机启动
        /// </summary>
        /// <returns>成功返回true,失败返回false</returns>
        //public override bool Start()
        //{
        //    //向设备(下位机)下发主机电机启动指令

        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 电机转速设定(0-5000,0.01r)
        /// </summary>
        /// <returns>成功返回true,失败返回false</returns>  
        public override bool SetSpeed(float speed)
        {
            //向主控板端口下发控制指令,需将转速*100后下发
            ControlBoard controlBoard = new MainControlBoard();
            //主电机速度精度为0.01r，下发时应乘以100
            return controlBoard.SendControlCommand((int)MainControlBoard.CommandAddress.MainMotorSpeedSet, Convert.ToInt32(speed * 100));            
        }
        /// <summary>
        /// 控制电机停止
        /// </summary>
        /// <returns>成功返回true,失败返回false</returns>       
        public override bool Stop()
        {
            //向设备(下位机)下发主机电机停止指令
            //throw new NotImplementedException();
            return SetSpeed(0);
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

        

        
    }
}
