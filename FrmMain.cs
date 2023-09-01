/// <summary>
/// 描述：主窗体
/// 作者：杨慧炯
/// 创建日期：2023/6/11 17:58:12
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Navigation;
using Rheometer_Torque.Model;
using Rheometer_Torque.View;
using Rheometer_Torque.View.ProcessWindow;

namespace Rheometer_Torque
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        User userLogin;
        Machine.Machine.OperationMode operationMode;
        /// <summary>
        /// 当前用户选择进行的实验ID
        /// </summary>
        int experimentIDSelected = -1;
        /// <summary>
        /// 设备动画控制
        /// </summary>
        Form frmMachineAnimationControl;
        /// <summary>
        /// 实时数据窗体
        /// </summary>
        Form frmRealTimeData;
        /// <summary>
        /// 当前实验参数信息窗体
        /// </summary>
        Form frmParameterInfo;
        /// <summary>
        /// 实验数据分析窗体（柱塞速度/位置）
        /// </summary>
        Form frmDataProcessing_Speed;
        /// <summary>
        /// 实验数据分析窗体（剪切粘度）
        /// </summary>
        Form frmDataProcessing_Viscosity;

        /// <summary>
        /// 用来存储打开剪切粘度分析的窗体
        /// </summary>
        List<Form> documentFormsOfViscosity = new List<Form>();
        /// <summary>
        /// 用于向数据处理窗体传送数据分析窗体列表的委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public delegate void DelegateAppendFormHandler(object sender, DocumentFormEventArgs eventArgs);
        //用于向数据处理窗体传送数据分析窗体列表的事件
        public event DelegateAppendFormHandler SendFormListToDataProcess;
        /// <summary>
        /// 是否进行图表初始化
        /// </summary>
        bool isInitChart = true;

        public FrmMain()
        {
            InitializeComponent();

            DialogResult = DialogResult.OK;
        }
        public FrmMain(ref User user)
        {
            InitializeComponent();
            this.userLogin = user;
            frmMachineAnimationControl = CreateUserForm("设备动画控制");
            frmRealTimeData = CreateUserForm("实时数据");
            frmParameterInfo = CreateUserForm("实验参数");            
            frmDataProcessing_Viscosity = CreateUserForm("剪切粘度分析");
        }
        public FrmMain(ref User user, Machine.Machine.OperationMode operationMode)
        {
            InitializeComponent();
            this.userLogin = user;
            this.operationMode = operationMode;
        }
        Form CreateUserForm(string text)
        {
            Form result = null;
            switch (text)
            {
                case "设备动画控制":
                    result = new FrmMachineAnimationControl();                    
                    break;
                case "实时数据":
                    result = new FrmRealTimeData();
                    break;
                case "实验参数":
                    result = new FrmParameterInfo(experimentIDSelected);                    
                    break;                
                case "剪切粘度分析":
                    result = new FrmDataProcess(this);
                    break;
            }
            result.Name = text.ToLower();
            result.Text = text;
            return result;
        }

        void RecreateUserForm(DocumentEventArgs e)
        {
            switch (e.Document.Caption)
            {
                case "设备动画控制":
                    frmMachineAnimationControl = CreateUserForm("设备动画控制");
                    break;
                case "实时数据":
                    frmRealTimeData = CreateUserForm("实时数据");
                    break;
                case "实验参数":
                    frmParameterInfo = CreateUserForm("实验参数");
                    break;               
                case "剪切粘度分析":
                    frmDataProcessing_Viscosity = CreateUserForm("剪切粘度分析");
                    break;
            }
        }

        private void accdControlLeftMenu_SelectedElementChanged(object sender, DevExpress.XtraBars.Navigation.SelectedElementChangedEventArgs e)
        {
            Form selectedForm = frmRealTimeData;
            if (e.Element == null) return;
            //用来向数据处理窗体传送文件列表的事件参数
            DocumentFormEventArgs eventArgsOfFormList = new DocumentFormEventArgs();
            switch (e.Element.Text)
            {
                case "设备动画控制":
                    selectedForm = frmMachineAnimationControl;
                    break;
                case "实时数据":
                    selectedForm = frmRealTimeData;
                    break;
                case "实验参数":
                    selectedForm = frmParameterInfo;
                    break;                
                case "剪切粘度分析":
                    selectedForm = frmDataProcessing_Viscosity;
                    //将添加文档窗体方法绑定到数据处理窗体的事件AppendDocumentForm
                    ((FrmDataProcess)selectedForm).AppendDocumentForm += this.FrmDataProcess_AppendDocumentForm;
                    //将创建的窗体添加到List
                    documentFormsOfViscosity.Add(selectedForm);
                    //eventArgsOfFormList.formListType = 1;
                    eventArgsOfFormList.forms = documentFormsOfViscosity;
                    break;
            }
            tabbedView.AddDocument(selectedForm);
            tabbedView.ActivateDocument(selectedForm);
            //通过事件调用将List发送到所有相关数据处理窗体对象（柱塞位移/速度分析和剪切粘度分析)     
            if (e.Element.Text == "柱塞位移/速度分析" || e.Element.Text == "剪切粘度分析")
            {
                if (SendFormListToDataProcess != null && eventArgsOfFormList.forms != null && eventArgsOfFormList.forms.Count > 0)
                {
                    SendFormListToDataProcess(this, eventArgsOfFormList);
                }
            }
        }

        /// <summary>
        /// 数据处理窗体的AppendDocumentForm事件的响应，用于接收从数据处理窗体创建的新窗体对象并进行显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void FrmDataProcess_AppendDocumentForm(object sender, DocumentFormEventArgs eventArgs)
        {
            if (eventArgs.form != null)
            {
                //用来向数据处理窗体传送文件列表的事件参数
                DocumentFormEventArgs eventArgsOfFormList = new DocumentFormEventArgs();
                //在主窗体中添加显示新窗体
                tabbedView.AddDocument((Form)eventArgs.form);
                tabbedView.ActivateDocument((Form)eventArgs.form);
                ////为新的窗体对象绑定事件
                ((FrmDataProcess)eventArgs.form).AppendDocumentForm += this.FrmDataProcess_AppendDocumentForm;
                //将创建的窗体添加到List
                if (((Form)eventArgs.form).Text.Contains("剪切粘度"))
                {
                    //将窗体添加到文件List
                    documentFormsOfViscosity.Add((Form)eventArgs.form);
                    //设定事件参数的类型为剪切粘度分析
                    //eventArgsOfFormList.formListType = 1;
                    eventArgsOfFormList.forms = documentFormsOfViscosity;
                }
                else
                {
                    //将窗体添加到文件List
                    //documentFormsOfSpeed.Add((Form)eventArgs.form);
                    //设定事件参数的类型为位移/速度分析
                    //eventArgsOfFormList.formListType = 0;
                    //eventArgsOfFormList.forms = documentFormsOfSpeed;
                }
                //通过事件调用将List发送到数据处理窗体      
                if (SendFormListToDataProcess != null)
                {
                    SendFormListToDataProcess(this, eventArgsOfFormList);
                }
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            RecreateUserForm(e);
            SetAccordionSelectedElement(e);
            //用来向数据处理窗体传送文件列表的事件参数
            DocumentFormEventArgs eventArgsOfFormList = new DocumentFormEventArgs();
            //将关闭的数据处理窗体从对应列表中删除并传送同步到对应的数据处理窗体对象
            //if (e.Document.Caption.Contains("柱塞位移/速度分析"))
            //{
            //    Form closedForm = this.documentFormsOfSpeed.Find(form => form.Text == "");
            //    documentFormsOfSpeed.Remove(closedForm);
            //    //设定事件参数的类型为位移/速度分析
            //    eventArgsOfFormList.formListType = 0;
            //    eventArgsOfFormList.forms = documentFormsOfSpeed;
            //}
            if (e.Document.Caption.Contains("剪切粘度分析"))
            {
                Form closedForm = this.documentFormsOfViscosity.Find(form => form.Text == "");
                documentFormsOfViscosity.Remove(closedForm);
                //设定事件参数的类型为剪切粘度分析
                //eventArgsOfFormList.formListType = 1;
                eventArgsOfFormList.forms = documentFormsOfViscosity;
            }
            if (e.Document.Caption.Contains("实时数据"))
            {
                //为下次实验做准备
                isInitChart = true;
            }
            //通过事件调用将List发送到数据处理窗体      
            if (SendFormListToDataProcess != null)
            {
                SendFormListToDataProcess(this, eventArgsOfFormList);
            }
        }

        void SetAccordionSelectedElement(DocumentEventArgs e)
        {
            if (tabbedView.Documents.Count != 0)
            {
                switch (e.Document.Caption)
                {
                    case "设备动画控制":
                        accdControlLeftMenu.SelectedElement = acdCtrlElementMachineAnimation;
                        break;
                    case "实时数据":
                        accdControlLeftMenu.SelectedElement = acdCtrlElementRealTimeData;
                        break;
                    case "实验参数":
                        accdControlLeftMenu.SelectedElement = acdCtrlElementParameterInfo;
                        break;
                    //case "柱塞位移/速度分析":
                    case "剪切粘度分析":
                        accdControlLeftMenu.SelectedElement = acdCtrlElementDataProcessing;
                        break;
                }
            }
            else
            {
                accdControlLeftMenu.SelectedElement = null;
            }
        }
    }
}
