/// <summary>
/// 描述：完成TCP/IP通讯，包括建立连接、关闭连接、读端口数据、写端口数据
/// 作者：杨慧炯
/// 创建日期：2023/6/11 18:48:46
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
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Communication
{
    public class TcpPort
    {
        public string IpAddress;
        public int Port;
        public bool Opened = false;
        public int ReadTimeout = 1000;
        public bool IsEnabled = true;
        TcpClient tcpClient = new TcpClient();
        #region 根据配置文件对Tcp端口进行设置
        /// <summary>
        /// 根据配置文件对Tcp端口进行设置
        /// </summary>
        /// <param name="key">配置文件中节点描述</param>
        public void TcpPortSet(string key)
        {
            string portSetString = System.Configuration.ConfigurationManager.AppSettings[key].ToString();
            string[] portSetArray = portSetString.Split(';');
            for (int i = 0; i < portSetArray.Length; i++)
            {
                if (portSetArray[i].Length != 0)
                {
                    switch (portSetArray[i].Split('=')[0].ToString())
                    {
                        case "IpAddress":
                            IpAddress = portSetArray[i].Split('=')[1].ToString();
                            break;
                        case "Port":
                            this.Port = Convert.ToInt32(portSetArray[i].Split('=')[1]);
                            break;
                        case "ReadTimeout":
                            this.ReadTimeout = Convert.ToInt32(portSetArray[i].Split('=')[1]);
                            break;
                        case "IsEnabled":
                            this.IsEnabled = portSetArray[i].Split('=')[1].ToString().ToLower() == "true" ? true : false;
                            break;
                    }
                }
            }
        }
        #endregion       

        #region 建立连接
        /// <summary>
        /// 建立Tcp连接
        /// </summary>
        public void Open()
        {
            if (Opened)
                return;
            else
            {
                try
                {
                    tcpClient.Connect(new IPEndPoint(IPAddress.Parse(IpAddress), Port));
                }
                catch
                {
                    throw (new ApplicationException("Tcp Port Open Failed!"));
                }
                Opened = true;
            }
        }
        #endregion

        #region 断开连接
        /// <summary>
        /// 断开连接
        /// </summary>
        public void Close()
        {
            if (!Opened)
                return;
            else
            {
                if (tcpClient != null)
                {
                    try
                    {
                        tcpClient.Close();
                    }
                    catch (Exception)
                    {
                        throw (new ApplicationException("Tcp Port Can Not Be Closed"));
                    }
                    tcpClient = new TcpClient();
                }
            }
        }
        #endregion

        #region 读Tcp端口
        /// <summary>
        /// 读Tcp端口操作
        /// </summary>        
        /// <returns>从Tcp端口获得的字节型数据数组</returns>
        public byte[] Read()
        {
            var stream = tcpClient.GetStream();
            int timeCount = 0; bool r = false;
            List<byte> BufBytes = new List<byte>();
            if (this.Opened == false)
            {
                throw (new ApplicationException("Tcp Port Not Opened"));
            }
            while (timeCount < this.ReadTimeout)
            {
                System.Threading.Thread.Sleep(30);
                while (tcpClient.Available > 0)
                {
                    r = true;
                    byte[] data = new byte[tcpClient.Available];
                    stream.Read(data, 0, data.Count());
                    BufBytes.AddRange(data);
                    System.Threading.Thread.Sleep(30);
                }
                if (r) break;
                timeCount += 30;
            }
            return BufBytes.ToArray();
        }
        #endregion

        #region 写Tcp端口
        /// <summary>
        /// 写Tcp端口操作
        /// </summary>
        /// <param name="WriteBytes">向Tcp端口发送的字节型数据数组</param>
        public void Write(byte[] WriteBytes)
        {
            var stream = tcpClient.GetStream();
            if (this.Opened == false)
            {
                throw (new ApplicationException("Tcp Port Not Opened"));
            }
            //清空流读写区
            while (tcpClient.Available > 0) stream.ReadByte();
            stream.Write(WriteBytes, 0, WriteBytes.Length);
        }
        #endregion
    }
}
