/// <summary>
/// 描述：完成上位机与下位机报文传输与解析
/// 作者：杨慧炯
/// 创建日期：2023/6/11 18:43:14
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
using Utils.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPrinting.Native;

namespace Utils.Communication
{
    public abstract class Message
    {
        public const byte MESSAGE_READ= 0x03;
        public const byte MESSAGE_CONTROL_SINGLE = 0x06;
        public const byte MESSAGE_CONTROL_MULTIPLE = 0x10;
        #region 生成读(03H)/写(06H)主/辅控制板指令下发报文
        /// <summary>
        /// 生成读(03H)/写(06H)主/辅控制板指令下发报文
        /// </summary>
        /// <param name="deviceAddress">设备地址</param>
        /// <param name="memoryAddress">读数据起始内容地址</param>
        /// <param name="content">读/写报文内容</param>
        /// <returns>下发主控板读/写报文</returns>
        public static byte[] BuildMessage(bool isRead, byte deviceAddress, int memoryAddress, int content)
        {
            byte[] messageData=new byte[8];            
            messageData[0] = Convert.ToByte(deviceAddress);
            messageData[1] = isRead==true ? MESSAGE_READ : MESSAGE_CONTROL_SINGLE;
            messageData[2] = Convert.ToByte(memoryAddress / 256);
            messageData[3] = Convert.ToByte(memoryAddress % 256);
            //content为要读的数据个数或者要写的命令码，占2个字节
            messageData[4] = Convert.ToByte(content / 256);  //读数据个数（写命令码）高位
            messageData[5] = Convert.ToByte(content % 256);  //读数据个数（写命令码）低位
            byte[] crcData = Utils.Tools.CRC16(messageData, 6);
            messageData[6] = crcData[1];
            messageData[7] = crcData[0];
            return messageData;
        }
        #endregion

        #region 生成写多个指令（10H）主/辅控制板下发报文
        /// <summary>
        /// 生成写多个指令（10H）主/辅控制板下发报文
        /// </summary>
        /// <param name="deviceAddress">设备地址</param>
        /// <param name="memoryAddress">写命令内存起始地址</param>
        /// <param name="count">命令个数</param>
        /// <param name="contents">命令内容</param>
        /// <returns></returns>
        public static byte[] BuildMessage(byte deviceAddress, int memoryAddress,int count, int[] contents)
        {
            //每个命令2字节，再加上设备地址deviceAddress(01H)、功能码（10H）、内存地址memoryAddress2字节、
            //命令个数2字节、命令占用字节数1字节、CRC校验2字节共9字节
            byte[] messageData = new byte[2*count+9];
            messageData[0] = Convert.ToByte(deviceAddress);
            messageData[1] = MESSAGE_CONTROL_MULTIPLE;
            messageData[2] = Convert.ToByte(memoryAddress / 256);
            messageData[3] = Convert.ToByte(memoryAddress % 256);
            //count为要写的命令个数，占2个字节
            messageData[4] = Convert.ToByte(count / 256);  //要写的命令个数高位
            messageData[5] = Convert.ToByte(count % 256);  //要写的命令个数低位
            messageData[6] = Convert.ToByte(2 * count);//要写的命令占用字节数
            //从第7个字节开始，每个命令码占用2个字节
            for(int i=0;i<count;i++)
            {
                messageData[7+2*i] = Convert.ToByte(contents[i] / 256);  //要写的命令高位
                messageData[7+2*i+1] = Convert.ToByte(contents[i] % 256);  //要写的命令低位
            }            
            byte[] crcData = Utils.Tools.CRC16(messageData, 6);
            //最后两个字节为CRC校验
            messageData[messageData.Length-2] = crcData[1];
            messageData[messageData.Length-1] = crcData[0];
            return messageData;
        }                   
        #endregion

        #region 解析读主/辅控制板回传数据(03H读指令返回)报文
        /// <summary>
        /// 解析读主/辅控制板回传数据(03H读指令返回)报文
        /// </summary>
        /// <param name="message">上位机下发主/辅控制板读指令(03H读指令)后主/辅控制板返回的报文</param>
        /// <returns>主/辅控制板回传数据</returns>
        public static byte[] ExplainMessage(byte[] message)
        {
            //判断报文标志是否正确
            if (message[1] != MESSAGE_READ)
            {
                return null;
            }
            //获得采集数据字节数
            int dataNum = message[2];
            //计算CRC校验值并验证
            byte[] data = new byte[dataNum];
            byte[] crcData = Utils.Tools.CRC16(message, dataNum + 3);
            if (crcData[1] != message[dataNum + 3] || crcData[0] != message[dataNum + 4])
            {
                return null;
            }
            //解析采集数据并返回
            for (int i = 0; i < dataNum; i++)
            {
                data[dataNum - (i + 1)] = message[i + 3];
            }
            return data;//data由高到低分别为第一个数->第二个数->第三个数...第dataNum个数，每个数高字节在高位，低字节在低位
        }
        #endregion

        #region 发送报文信息
        /// <summary>
        ///  通过Tcp端口向下位机发送报文信息（Tcp端口已经连接）
        ///  </summary>
        /// <param name="BuffMessage">存储报文信息缓冲区</param>
        /// <param name="tcpPort">传输报文端口</param>
        /// <returns>true  发送成功
        ///          false 发送失败  </returns>
        public static bool SendMessage(byte[] BuffMessage, TcpPort tcpPort)
        {
            //Tcp连接已打开

            //获得当前系统时间
            System.DateTime Start_Time = new System.DateTime();
            System.DateTime Now_Time = new System.DateTime();
            Start_Time = System.DateTime.Now;
            while (true)
            {
                if (tcpPort.Opened == false)
                {
                    try
                    {
                        tcpPort.Open();
                    }
                    catch
                    {
                        Now_Time = System.DateTime.Now;
                        //传输时间大于1000毫秒则传输失败                        
                        if (Now_Time.Subtract(Start_Time).TotalMilliseconds > 1000)
                        {
                            return false;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                Now_Time = System.DateTime.Now;
                //传输时间大于1000毫秒则传输失败
                TimeSpan Space_Time = Now_Time.Subtract(Start_Time);
                if (Space_Time.TotalMilliseconds > 1000)
                    return false;
                else
                {
                    try
                    {
                        tcpPort.Write(BuffMessage);
                        return true;
                    }
                    catch
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                        //return false;
                    }
                }
            }
        }

        #endregion

        #region 接收报文信息
        /// <summary>
        ///  通过Tcp端口接收下位机上传的采集数据报文（Tcp端口已经打开）		
        /// </summary>
        /// <param name="tcpPort"> 已打开的接收报文信息的Tcp端口</param>
        /// <returns>RecBuf  接收成功：返回收到的采集信息
        ///                 接收失败：返回null  </returns>
        public static byte[] ReceiveMessage(TcpPort tcpPort)
        {
            //串口已打开                                             
            byte[] RecBuf = new byte[64];
            //获得当前系统时间
            System.DateTime Start_Time = new System.DateTime();
            System.DateTime Now_Time = new System.DateTime();
            Start_Time = System.DateTime.Now;
            while (true)
            {
                if (tcpPort.Opened == false)
                {
                    try
                    {
                        tcpPort.Open();
                    }
                    catch
                    {
                        continue;
                    }
                }
                Now_Time = System.DateTime.Now;
                //传输时间大于1000毫秒则传输失败
                TimeSpan Space_Time = Now_Time.Subtract(Start_Time);
                if (Space_Time.TotalMilliseconds > 1000)
                    return null;
                else
                {
                    //读串口数据到RecBuf
                    try
                    {
                        //接收下位机上传的采集数据报文，将其从byte型转换为string类型(十六进制)并返回
                        RecBuf = tcpPort.Read();
                        return RecBuf;
                    }
                    catch
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }
                }
            }
        }
        #endregion
    }
}
