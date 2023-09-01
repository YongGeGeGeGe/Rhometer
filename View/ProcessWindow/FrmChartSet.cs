using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Rheometer.Utils.Chart;

namespace Rheometer_Torque.View.ProcessWindow
{
    public partial class FrmChartSet : DevExpress.XtraEditors.XtraForm
    {
        List<Form> documentForms;
        Form documentForm;
        ChartParameter chartParameter;
        List<string> selectedForms;
        public FrmChartSet(Form documentForm,List<Form> documentForms,ref ChartParameter parameter,ref List<string> selectedForms)
        {
            InitializeComponent();
            this.documentForm = documentForm;
            this.documentForms = documentForms;
            this.chartParameter = parameter;
            this.selectedForms = selectedForms;
        }
        public FrmChartSet(Form documentForm,ref ChartParameter parameter)
        {
            InitializeComponent();
            this.documentForm = documentForm;
            this.chartParameter = parameter;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            //获得界面中用户XY坐标范围设置
            this.chartParameter.MinDataOfAxisX = Convert.ToSingle(textEditMinDataOfAxisX.Text);
            this.chartParameter.MaxDataOfAxisX = Convert.ToSingle(textEditMaxDataOfAxisX.Text);
            this.chartParameter.MinDataOfAxisY = Convert.ToSingle(textEditMinDataOfAxisY.Text);
            this.chartParameter.MaxDataOfAxisY = Convert.ToSingle(textEditMaxDataOfAxisY.Text);
            //获得界面中用户XY坐标轴类型设置（线性坐标/对数坐标）
            this.chartParameter.AxisTypeOfX = comboBoxEditTypeOfAxisX.SelectedIndex == 0 ? Rheometer.Utils.Chart.ChartParameter.AxisType.Line : Rheometer.Utils.Chart.ChartParameter.AxisType.Log10;
            this.chartParameter.AxisTypeOfY = comboBoxEditTypeOfAxisY.SelectedIndex == 0 ? Rheometer.Utils.Chart.ChartParameter.AxisType.Line : Rheometer.Utils.Chart.ChartParameter.AxisType.Log10;
            //获得界面中用户绘图类型设置（点图/曲线图）
            switch(radioGroupChartType.SelectedIndex)
            {
                case 0:
                    this.chartParameter.ViewTypeOfSeries = DevExpress.XtraCharts.ViewType.Point;
                    break;
                case 1:
                    this.chartParameter.ViewTypeOfSeries= DevExpress.XtraCharts.ViewType.Spline;
                    break;
                case 2:
                    this.chartParameter.ViewTypeOfSeries= DevExpress.XtraCharts.ViewType.Line;
                    break;
            }            
            //获得界面中用户选择的叠加绘图选择项
            //DevExpress.XtraEditors.BaseListBoxControl.SelectedItemCollection selectedItemCollection = checkedListBoxOfChartAppend.SelectedItems;
            //foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem selectedItem  in selectedItemCollection)
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem selectedItem in checkedListBoxOfChartAppend.Items)
            {
                //如果用户选择了该窗体
                if (selectedItem.CheckState == CheckState.Checked)
                {
                    //该窗体不在已选择列表中则添加
                    if (selectedForms.Contains(selectedItem.Value.ToString()) == false)
                    {
                        selectedForms.Add(selectedItem.Value.ToString());
                    }
                }
                //如果用户未选择该窗体
                if(selectedItem.CheckState==CheckState.Unchecked)
                {
                    //该窗体已经在选择列表中则删除
                    if(selectedForms.Contains(selectedItem.Value.ToString()))
                    {
                        selectedForms.Remove(selectedItem.Value.ToString());
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void FrmChartSet_Load(object sender, EventArgs e)
        {
            //坐标轴范围
            textEditMinDataOfAxisX.Text = this.chartParameter.MinDataOfAxisX.ToString();
            textEditMaxDataOfAxisX.Text = this.chartParameter.MaxDataOfAxisX.ToString();
            textEditMinDataOfAxisY.Text = this.chartParameter.MinDataOfAxisY.ToString();
            textEditMaxDataOfAxisY.Text = this.chartParameter.MaxDataOfAxisY.ToString();
            //坐标轴类型（线性坐标/对数坐标）
            comboBoxEditTypeOfAxisX.SelectedIndex = this.chartParameter.AxisTypeOfX == Rheometer.Utils.Chart.ChartParameter.AxisType.Line ? 0 : 1;
            comboBoxEditTypeOfAxisY.SelectedIndex = this.chartParameter.AxisTypeOfY == Rheometer.Utils.Chart.ChartParameter.AxisType.Line ? 0 : 1;
            //绘图类型（点图/曲线）
            switch(this.chartParameter.ViewTypeOfSeries)
            {
                case ViewType.Point:
                    radioGroupChartType.SelectedIndex = 0;
                    break;
                case ViewType.Spline:
                    radioGroupChartType.SelectedIndex = 1;
                    break;
                case ViewType.Line:
                    radioGroupChartType.SelectedIndex = 2;
                    break;
            }            
            //将已经打开的窗体添加到图表叠加绘图列表
            foreach(Form form in this.documentForms)
            {
                if(form.Text!="" && form.Text!=this.documentForm.Text)
                {
                    checkedListBoxOfChartAppend.Items.Add(form.Text);
                }
            }
            foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem  listItem in checkedListBoxOfChartAppend.Items)
            {
                foreach(string formText in selectedForms)
                {
                    if(listItem.Value.ToString()==formText)
                    {
                        listItem.CheckState = CheckState.Checked;
                    }
                }
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
        }
    }
}
