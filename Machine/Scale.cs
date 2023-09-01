/// <summary>
/// 描述：
/// 作者：Administrator
/// 创建日期：2023/6/18 22:49:40
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
    internal class Scale
    {
        /// <summary>
        /// 设定称重周期(0-65535)
        /// </summary>
        /// <param name="cycle">称重周期(0-65536)</param>
        /// <returns></returns>
        public bool SetWeightingCycle(int cycle)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 电子称去皮
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SetScaleZero()
        {
            throw new NotImplementedException();
        }
    }
}
