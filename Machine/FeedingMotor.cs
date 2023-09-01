/// <summary>
/// 描述：喂料电机类，实现喂料电机控制以及状态、相关数据采集
/// 作者：杨慧炯
/// 创建日期：2023/6/11 22:15:01
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：刘子民
///修改日期：2023/6/26
///修改内容：喂料电机 设置速度的功能 停的功能
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
    internal class FeedingMotor : Motor, IMotor
    {
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
        /// <summary>
        /// 喂料速度设定(0-5000,0.01r)
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public override bool SetSpeed(float speed)
        {
            //需将speed*100下发
            //throw new NotImplementedException();

            //向主控板端口下发控制指令,需将转速*100后下发
            ControlBoard controlBoard = new AssistControlBoard();
            //主电机速度精度为0.01r，下发时应乘以100
            return controlBoard.SendControlCommand((int)AssistControlBoard.CommandAddress.FeedingSpeedSet, Convert.ToInt32(speed * 100));


        }

        //public override bool Start()
        //{
        //    throw new NotImplementedException();
        //}

        public override bool Stop()
        {
            //throw new NotImplementedException();
            return SetSpeed(0);
        }
    }
}
