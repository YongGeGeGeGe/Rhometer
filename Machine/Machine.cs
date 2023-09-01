/// <summary>
/// 描述：设备（下位机）类
/// 作者：杨慧炯
/// 创建日期：2023/6/11 16:53:10
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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Rheometer_Torque.Interface;
using Utils.Communication;
using static Rheometer_Torque.Machine.AssistControlBoard;

namespace Rheometer_Torque.Machine
{
    public class Machine:IMachine
    {
        public enum OperationMode
        {
            LocalMode=0x00,
            RemoteMode=0x01,
            Error=-1
        }        
        OperationMode _operationMode;
        //private TcpPort _mainControlBoard;
        //private TcpPort _assistControlBoard;

        //public TcpPort MainControlBoard { get => _mainControlBoard; set => _mainControlBoard = value; }
        //public TcpPort AssistControlBoard { get => _assistControlBoard; set => _assistControlBoard = value; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public enum MachineState
        {
            /// <summary>
            /// 通讯正常
            /// </summary>
            CommNormal,
            /// <summary>
            /// 通讯失败
            /// </summary>
            CommFailure,
            /// <summary>
            /// 工作正常
            /// </summary>
            OperationNormal,
            /// <summary>
            /// 报警
            /// </summary>
            Alarm
        }
        /// <summary>
        /// 读取主辅控制板全部数据并返回
        /// 主辅控制板只要一个通讯异常则返回null
        /// </summary>
        /// <returns>主辅控制板数据列表</returns>
        public List<byte[]> ReadAllDatas()
        {
            ControlBoard controlBoard = null;
            List<byte[]> realTimeMachineDataList=new List<byte[]>();                       
            controlBoard = new MainControlBoard();            
            try 
            {
                //读主控制板端口全部数据
                byte[] mainBoardDatas = controlBoard.ReadDatas((int)Rheometer_Torque.Machine.MainControlBoard.CommandAddress.OperntionMode, controlBoard.CommandTotalCount);
                if (mainBoardDatas == null)
                {
                    return null;
                }
                //将主控制板数据添加到列表中
                realTimeMachineDataList.Add(mainBoardDatas);
                controlBoard = new AssistControlBoard();               
                //读辅控制板端口全部数据            
                byte[] assistBoardDatas = controlBoard.ReadDatas((int)Rheometer_Torque.Machine.AssistControlBoard.CommandAddress.OperntionMode, controlBoard.CommandTotalCount);
                if (assistBoardDatas == null)
                {
                    return null;
                }
                //将辅控制板数据添加到列表中
                realTimeMachineDataList.Add(assistBoardDatas);
            }
            catch
            {
                return null;
            }            
            return realTimeMachineDataList;
        }

        /// <summary>
        /// 查询设备工作模式（与主控制板、辅控制板通讯查询各自工作模式）        
        /// </summary>
        /// <returns>通讯正常且主控制板与辅控制板工作模式相同则返回正常工作模式，否则返回Error</returns>
        public OperationMode GetOperationMode()
        {
            //查询主控制板工作模式
            ControlBoard controlBoard = new MainControlBoard();
            OperationMode machineMode = GetOperationModeOfControlBoard(controlBoard, (int)Rheometer_Torque.Machine.MainControlBoard.CommandAddress.OperntionMode);
            controlBoard = new AssistControlBoard();
            //查询辅控制板工作模式并与主控制板工作模式比较是否相同
            if (machineMode == GetOperationModeOfControlBoard(controlBoard, (int)Rheometer_Torque.Machine.AssistControlBoard.CommandAddress.OperntionMode))
            {
                return machineMode;
            }
            return OperationMode.Error;
        }
        private OperationMode GetOperationModeOfControlBoard(ControlBoard controlBoard, int memoryAdderss)
        {
            byte[] mode = controlBoard.ReadDatas(memoryAdderss, 1);
            if (mode == null)
            {
                return OperationMode.Error;
            }
            if (mode.Length == 2)
            {
                return mode[0] + mode[1] * 256 == 0 ? OperationMode.LocalMode : OperationMode.RemoteMode;
            }
            return OperationMode.Error;
        }

    }
}
