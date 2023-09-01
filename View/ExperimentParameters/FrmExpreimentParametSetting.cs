using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rheometer_Torque.View.ExperimentParameters
{
    public partial class FrmExpreimentParametSetting : Form
    {
        public FrmExpreimentParametSetting()
        {
            InitializeComponent();
        }

        private void btnPhaseAdd_Click(object sender, EventArgs e)
        {
            //显示
            //var rs= new FrmPhaseParameterAppend().ShowDialog();
            //if(rs == DialogResult.OK)
            //{
            //    //添加一行数据
            //}

        }

        private void btnPhaseEdit_Click(object sender, EventArgs e)
        {
            //显示
            //var rs = new FrmPhaseParameterSetting().ShowDialog();
            //if (rs == DialogResult.OK)
            //{
            //    //修改一行数据
            //}
        }
    }
}
