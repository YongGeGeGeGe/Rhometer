/// <summary>
/// 描述：电机接口
/// 作者：杨慧炯
/// 创建日期：2023/6/11 10:55:29
/// 版本：v1.0
///===================================================================
///更新记录
///版本：v1.0
///修改人：
///修改日期：
///修改内容：
///===================================================================
///Copyright (C) 2023 TIT All rights reserved.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rheometer_Torque.Interface
{
    public interface IMotor
    {
       //bool Start();//控制电机启动
        bool Stop();//控制电机停止 
        bool SetSpeed(float speed);//设定电机转速
        bool GetSpeed();//获得电机实时转速
        bool getState();//获得电机实时状态并给State属性赋值
        int[] getAlarmCode();//获得电机报警代码
    }
}
