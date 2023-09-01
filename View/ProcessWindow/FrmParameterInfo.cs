using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using Rheometer_Torque.Model;

namespace Rheometer_Torque.View.ProcessWindow
{
    public partial class FrmParameterInfo : DevExpress.XtraEditors.XtraForm
    {
        int experimentID = -1;
        public FrmParameterInfo(int experimentID)
        {
            InitializeComponent();
            this.experimentID = experimentID;           
        }                 
        private void FrmParameterInfo_Load(object sender, EventArgs e)
        {
            //获得当前设备参数
            MachineParameter parameter = new MachineParameter();
            //显示设备参数
            //根据ExperimentID查询实验参数
            //绑定并显示实验参数
           
        }
    }
}
