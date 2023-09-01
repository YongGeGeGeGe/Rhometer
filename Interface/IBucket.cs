/// <summary>
/// 描述：料筒接口
/// 作者：杨慧炯
/// 创建日期：2023/6/18 17:42:02
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

namespace Rheometer_Torque.Interface
{
    internal interface IBucket
    {
        bool Open();//控制料筒开
        bool Close();//控制料筒合
        //bool Stop();//控制料筒停止
    }
}
