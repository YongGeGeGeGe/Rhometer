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

namespace Rhometer_Torque.View.ExperimentParameters
{
    public partial class FrmExperimentSelect : Form
    {
        Experiment selectedExperiment;
        public FrmExperimentSelect(ref Experiment experiment)
        {
            InitializeComponent();
            this.selectedExperiment = experiment;
        }

        private void gridViewExperimentSelect_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.Caption == "实验类型")
            //{
            //    string strColumnTitle = e.Value.ToString();
            //    switch (strColumnTitle)
            //    {
            //        case "0":
            //            e.DisplayText = "恒温实验";
            //            break;
            //        case "1":
            //            e.DisplayText = "升温实验";
            //            break;
            //        case "2":
            //            e.DisplayText = "自动实验";
            //            break;
            //        case "3":
            //            e.DisplayText = "手动实验";
            //            break;                    
            //    }
            //}
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            int selectedHandle=this.gridViewExperimentSelect.GetSelectedRows()[0];
            this.selectedExperiment.ExperimentID = (int)gridViewExperimentSelect.GetRowCellValue(selectedHandle, "ExperimentID");
            this.DialogResult = DialogResult.OK;
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }        
    }
}
