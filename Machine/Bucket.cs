/// <summary>
/// 描述：料桶类，继承自电机Motor类，主要实现对料桶电机的控制及状态、相关数据采集
/// 作者：杨慧炯
/// 创建日期：2023/6/11 22:25:32
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：刘子民
///修改日期：2023/6/26
///修改内容：料筒类   开关停的功能
///===================================================================
///更新记录
///版本：v1.0
///修改人：刘子民
///修改日期：2023/6/26
///修改内容：开关停的功能 CommandAddress重新设置，枚举名与原先的风格不一样
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
    public class Bucket : Motor, IMotor,IBucket
    {
        /// <summary>
        /// 料筒位置状态
        /// </summary>
        public enum BucketState
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

        //public override bool Start()
        //{
        //    throw new NotImplementedException();
        //}

        public override bool Stop()
        {
            ControlBoard board = new AssistControlBoard();
            return board.SendControlCommand((int)AssistControlBoard.CommandAddress.BucketBOpenCloseStatusSpeedSet, (int)BucketState.Stoped);

        }

        /// <summary>
        /// 料筒开
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Open()
        {
            ControlBoard board = new AssistControlBoard();
            return board.SendControlCommand((int)AssistControlBoard.CommandAddress.BucketBOpenCloseStatusSpeedSet, (int)BucketState.Opened);

            //throw new NotImplementedException();
        }

        /// <summary>
        /// 料筒合
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Close()
        {
            ControlBoard board = new AssistControlBoard();
            return board.SendControlCommand((int)AssistControlBoard.CommandAddress.BucketBOpenCloseStatusSpeedSet, (int)BucketState.Closed);

        }
    }
}
