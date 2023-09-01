/**
 * ________________________________________________________________________________ 
 *
 *  描述：添加DoucmentForm窗体事件类
 *  作者：杨慧炯
 *  版本：
 *  创建时间：2022/6/3 16:15:01
 *  类名：DocumentFormEventArgs
 *  
 *  Copyright (C) 2022 TIT All rights reserved.
 *_________________________________________________________________________________
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rheometer_Torque.Model
{
    /// <summary>
    /// 添加DoucmentForm窗体事件类
    /// </summary>
    public class DocumentFormEventArgs:EventArgs
    {
        public object form;        
        /// <summary>
        /// 文件列表
        /// </summary>
        public List<Form> forms;
    }
}
