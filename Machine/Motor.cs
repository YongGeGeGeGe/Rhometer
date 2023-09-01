/// <summary>
/// 描述：电机类，为设备（下位机）中所有控制电机的基类，定义了电机基本控制指令及相关参数。
///       在继承类中可对相关方法进行重写以实现各自的控制。
/// 作者：杨慧炯
/// 创建日期：2023/6/11 22:12:29
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
using Rheometer_Torque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rheometer_Torque.Machine.Machine;

namespace Rheometer_Torque.Machine
{
    public class Motor:Machine,IMotor
    {
        # region 字段(成员变量)
            private int _speed; //电机转速
            private List<MachineState> _state;//电机状态        
        #endregion

        #region 属性
            public int Speed { get => _speed; set => _speed = value; }
            public List<MachineState> State { get => _state; set => _state = value; }

        #endregion

        #region 方法
        /// <summary>
        /// //控制电机启动
        /// </summary>
        /// <returns>成功返回true,失败返回false</returns>
        //public virtual bool Start()
        //{
        //    return false;
        //}
        /// <summary>
        /// 控制电机停止
        /// </summary>
        /// <returns>成功返回true,失败返回false</returns>
        public virtual bool Stop() 
        {            
            return false;
        }

        public virtual int[] getAlarmCode()
        {
            throw new NotImplementedException();
        }

        public virtual bool GetSpeed()
        {
            throw new NotImplementedException();
        }

        public virtual bool getState()
        {
            throw new NotImplementedException();
        }

        public virtual bool SetSpeed(float speed)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
