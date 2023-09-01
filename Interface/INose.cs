/// <summary>
/// 描述：机头接口
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
using Rheometer_Torque.Machine;

namespace Rheometer_Torque.Interface
{
    public interface INose
    {
        bool Open();//控制机头开
        bool Close();//控制机头合
        //bool Stop();//控制机头停止
        Machine.Machine.MachineState GetPositionState();//获得机头实时位置状态
        int GetPosition();//获得机头实时位置
        bool SetAlarmTemperature(int temperature);//设定机头越限温度
        bool GetTemperature();//获得实时机头温度
        bool GetOverRunTemperature();//获得机头越限后越限温度值
        bool GetDeviceAdjustParam();//获得机头温度校准相关参数实时值并赋值给属性RealValueOfI、AdjustValueOfIOfK、AdjustValueOfIOfB、adjustValueOfTOfK、AdjustValueOfTOfB、OffsetValueOfTOfX。
        bool SetAdjustValueOfIOfK();//按照属性RealValueOfI、AdjustValueOfIOfK、AdjustValueOfIOfB、adjustValueOfTOfK、AdjustValueOfTOfB、OffsetValueOfTOfX当前值设定机头温度校准相关参数。
        
    }
}
