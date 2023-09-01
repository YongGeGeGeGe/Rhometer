using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rheometer_Torque.Model;
using Utils.Communication;
using System.Threading;

namespace Rheometer_Torque.View
{
    public partial class FrmWelcome : DevExpress.XtraEditors.XtraForm
    {
        User userLogin;
        public FrmMain frmMain;
        //主控制板端口
        TcpPort tcpPortMCB = new TcpPort();
        //辅控制板端口
        TcpPort tcpPortACB = new TcpPort();

        public FrmWelcome(User user)
        {
            InitializeComponent();
            this.userLogin = user;
        }

        //测试主控制板和辅控制板端口是否正常
        private void TestTcpPort()
        {
            if (tcpPortMCB.Opened)
            {
                tcpPortMCB.Close();
            }
            //根据配置文件对主控制板端口进行设置
            tcpPortMCB.TcpPortSet("TcpPort-MCB");
            try
            {
                tcpPortMCB.Open();
            }
            catch
            {
                MessageBox.Show("主控制板端口打开错误！请检查通讯是否正常。", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            if (tcpPortACB.Opened)
            {
                tcpPortACB.Close();
            }
            //根据配置文件对模温机端口进行设置
            tcpPortACB.TcpPortSet("TcpPort-ACB");
            try
            {
                tcpPortACB.Open();
            }
            catch
            {
                MessageBox.Show("辅控制板端口打开错误！请检查通讯是否正常。", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }        
        private async void FrmWelcome_Load(object sender, EventArgs e)
        {
            //设置等待旋转动画属性
            loadingCircle.OuterCircleRadius = 40;
            loadingCircle.InnerCircleRadius = 20;
            loadingCircle.NumberSpoke = 15;
            loadingCircle.SpokeThickness = 3;
            loadingCircle.Active = true;
            //如果用户登录时选择离线模式则直接打开主窗口
            if (userLogin.IsOffLine)
            {
                //异步线程延时使欢迎画面显示1秒
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    return;
                });
                frmMain = new FrmMain(ref userLogin);
                frmMain.Show();
                loadingCircle.Active = false;
                this.Dispose();
                return;
            }                
            //启动异步线程，与设备通讯查询设备工作模式（本地模式/远程模式）
            Machine.Machine.OperationMode machineMode = await Task.Run(() => CommWithMachine());
            if (machineMode == Machine.Machine.OperationMode.Error)
            {
                MessageBox.Show("获取设备工作模式失败或主辅控制板工作模式设置不一致，请检查设备后重新启动软件...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            frmMain=new FrmMain(ref userLogin, machineMode);
            frmMain.Show();
            loadingCircle.Active = false;
            this.Dispose();
        }

        /// <summary>
        /// 查询设备工作模式
        /// </summary>
        /// <returns></returns>
        private Machine.Machine.OperationMode CommWithMachine()
        {
            //测试主控制板和辅控制板TCP端口
            TestTcpPort();
            //查询设备工作模式（主控制板工作模式和辅控制板工作模式）
            Rheometer_Torque.Machine.Machine machine = new Rheometer_Torque.Machine.Machine();
            return machine.GetOperationMode();            
        }
    }
}