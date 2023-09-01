/// <summary>
/// 描述：切换（分区）电磁阀
/// 作者：杨慧炯
/// 创建日期：2023/6/18 18:18:37
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

namespace Rheometer_Torque.Machine
{
    internal class SwitchingSolenoidValve
    {
        public enum SwitchingArea
        {
            WasteCollecting=0x00,
            StandardWeighting=0x01
        }
        /// <summary>
        /// 切换(分区)动作设定
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public bool SetSwitchingArea(SwitchingArea area)
        {
            throw new NotImplementedException();
        }
    }
}
