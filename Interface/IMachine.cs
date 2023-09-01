/// <summary>
/// 描述：设备接口
/// 作者：杨慧炯
/// 创建日期：2023/6/18 8:51:29
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
using Rheometer_Torque.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Communication;

namespace Rheometer_Torque.Interface
{
    internal interface IMachine
    {
        List<byte[]> ReadAllDatas();
        Machine.Machine.OperationMode GetOperationMode();
    }
}
