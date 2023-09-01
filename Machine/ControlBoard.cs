/// <summary>
/// 描述：制板类，通过Message类的相关方法进一步封装了与设备进行通讯过程。包括：
///       1、读取全部数据（03H命令码）
///       2、下发单个控制指令（06H命令码）
///       3、下发多个控制指令（10H命令码）。
///       上位机软件采集数据和下发控制指令时，直接调用即可。
/// 作者：杨慧炯
/// 创建日期：2023/6/17 22:25:32
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils.Communication;

namespace Rheometer_Torque.Machine
{
    public class ControlBoard
    {
        protected TcpPort _tcpPort;
        protected byte _deviceAddress = 1;//设备地址(默认1)
        private int _delayTime = 20;//通讯延时时间
        protected int _commandTotalCount = 0;//控制板全部指令总数量

        /// <summary>
        /// Tcp端口配置
        /// </summary>
        public TcpPort TcpPort { get => _tcpPort; set => _tcpPort = value; }
        /// <summary>
        /// 设备地址
        /// </summary>
        public byte DeviceAddress { get => _deviceAddress; set => _deviceAddress = value; }
        public int CommandTotalCount
        {
            get
            {
                return _commandTotalCount;
            }
        }

        public int DelayTime { get => _delayTime; set => _delayTime = value; }

        /// <summary>
        /// 接收设备上传数据
        /// </summary>
        /// <param name="memoryAddress">内存起始地址</param>
        /// <param name="count">读数据个数</param>
        /// <returns>解析后的报文信息</returns>
        public byte[] ReadDatas(int memoryAddress, int count)
        {
            //封装读报文(03H指令)
            byte[] message = Utils.Communication.Message.BuildMessage(true, this._deviceAddress, memoryAddress, count);
            //发送报文数据
            if (Utils.Communication.Message.SendMessage(message, this._tcpPort) != true)
            {
                //发送失败
                return null;
            }
            Thread.Sleep(_delayTime);//延时等待返回数据
            //接收端口数据
            message = Utils.Communication.Message.ReceiveMessage(this._tcpPort);
            //解析数据
            if (message == null || message.Length < 4 * count + 5)//每个参数4个字节，再加上校验2字节、报文头01（地址）-03共2字节、返回数据字节数1字节共5字节
            {
                return null;
            }
            //解析报文并返回
            return Utils.Communication.Message.ExplainMessage(message);

        }
        /// <summary>
        /// 向设备发送单个控制（06H）指令
        /// </summary>
        /// <param name="memoryAddress">控制指令内存地址</param>
        /// <param name="content">控制指令内容</param>
        /// <returns>是否发送成功</returns>        
        public bool SendControlCommand(int memoryAddress, int content)
        {
            //封装控制指令报文(06H指令)
            byte[] message = Utils.Communication.Message.BuildMessage(false, this._deviceAddress, memoryAddress, content);
            //发送报文数据
            if (Utils.Communication.Message.SendMessage(message, this._tcpPort) != true)
            {
                //发送失败
                return false;
            }
            int num = 0;
            while(true)
            {
                Thread.Sleep(_delayTime);//延时等待返回数据
                //接收端口数据
                message = Utils.Communication.Message.ReceiveMessage(this._tcpPort);
                //解析数据，06H命令返回固定8字节报文
                if (message == null || message.Length < 8)
                {
                    num++;
                    if (num < 3)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                //判断返回的为06H命令报文
                if (message[1] == Utils.Communication.Message.MESSAGE_CONTROL_SINGLE)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        /// <summary>
        /// 向设备发送多个控制（10H）指令
        /// </summary>
        /// <param name="memoryAddress">控制指令内存地址</param>
        /// <param name="count">控制指令个数</param>
        /// <param name="contents">控制指令内容</param>
        /// <returns>是否发送成功</returns>
        public bool SendControlCommand(int memoryAddress,int count, int[] contents)
        {
            //封装控制指令报文(10H指令)
            byte[] message = Utils.Communication.Message.BuildMessage(this._deviceAddress, memoryAddress,count,contents);
            //发送报文数据
            if (Utils.Communication.Message.SendMessage(message, this._tcpPort) != true)
            {
                //发送失败
                return false;
            }
            int num = 0;
            while (true)
            {
                Thread.Sleep(DelayTime);//延时等待返回数据
                //接收端口数据
                message = Utils.Communication.Message.ReceiveMessage(this._tcpPort);
                //解析数据，10H命令码//每个命令2字节，再加上设备地址deviceAddress(01H)、功能码（10H）、内存地址memoryAddress2字节、
                //命令个数2字节、命令占用字节数1字节、CRC校验2字节共9字节
                if (message == null || message.Length < 2*count+9)
                {
                    num++;
                    if (num < 3)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                //判断返回的为10H命令报文
                if (message[1] == Utils.Communication.Message.MESSAGE_CONTROL_MULTIPLE)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
