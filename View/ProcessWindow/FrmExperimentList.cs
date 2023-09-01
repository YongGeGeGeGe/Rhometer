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
using Utils.Utils;

namespace Rheometer_Torque.View.ProcessWindow
{
    public partial class FrmExperimentList : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 用户选中的实验参数对象，用来将用户选中的实验对象参数通过引用回传给上一级调用窗体
        /// </summary>
        Experiment experimentParameter;        
        /// <summary>
        /// 根据数据分析实验类型，在数据库中查询到的实验参数列表
        /// </summary>
        List<Experiment> parameters = new List<Experiment>();
        public FrmExperimentList(ref Experiment experimentParameter)
        {
            InitializeComponent();          
            this.experimentParameter = experimentParameter;
        }

        private void gridViewExperimentList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void FrmExperimentList_Load(object sender, EventArgs e)
        {
            //根据实验类型查找满足条件的实验清单并绑定到页面            
            Experiment experimentParameter = new Experiment();
            //按照用户选择的实验类型查询已经结束的实验
            parameters = experimentParameter.GetParameter(false);
            ModelHandler<Experiment> modelHandler = new ModelHandler<Experiment>();
            DataTable dt = modelHandler.FillDataTable(parameters);
            gridControlExperimentList.DataSource = dt.DefaultView;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if(gridViewExperimentList.SelectedRowsCount>0)
            {
                int selectedRow = gridViewExperimentList.GetSelectedRows()[0];
                int selectedExperimentID=(int)gridViewExperimentList.GetRowCellValue(selectedRow, "ExperimentID");
                Experiment parameterSelected = parameters.Find(ex => ex.ExperimentID == selectedExperimentID);
                this.experimentParameter.ExperimentID = parameterSelected.ExperimentID;
                this.experimentParameter.ExperimentName = parameterSelected.ExperimentName;
                this.experimentParameter.ExperimentTime = parameterSelected.ExperimentTime;
                //this.experimentParameter.OperationMode = parameterSelected.OperationMode;
                //this.experimentParameter.ExperimentType = parameterSelected.ExperimentType;
                //this.experimentParameter.User.UserName = parameterSelected.User.UserName;
                //this.experimentParameter.Loads = parameterSelected.Loads;
                this.experimentParameter.SampleName = parameterSelected.SampleName;
                //this.experimentParameter.SampleMass = parameterSelected.SampleMass;
                this.experimentParameter.CapillaryDiameter = parameterSelected.CapillaryDiameter;
                this.experimentParameter.CapillaryLength = parameterSelected.CapillaryLength;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void gridViewExperimentList_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "实验模式")
            {
                string strColumnTitle = e.Value.ToString();
                switch (strColumnTitle)
                {                   
                    case "1":
                        e.DisplayText = "恒速模式";
                        break;
                    case "2":
                        e.DisplayText = "恒压模式";
                        break;                   
                }
            }
            if (e.Column.Caption == "实验类型")
            {
                string strColumnTitle = e.Value.ToString();
                switch (strColumnTitle)
                {
                    case "0":
                        e.DisplayText = "恒温实验";
                        break;
                    case "1":
                        e.DisplayText = "升温实验";
                        break;
                    case "2":
                        e.DisplayText = "自动实验";
                        break;
                    case "3":
                        e.DisplayText = "手动实验";
                        break;
                }
            }
        }
    }
}
