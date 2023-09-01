using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using Rheometer_Torque.Model;
using Rheometer.Utils.Chart;
using Utils.Utils;

namespace Rheometer_Torque.View.ProcessWindow
{
    public partial class FrmDataProcess : DevExpress.XtraEditors.XtraForm
    {                  
        Form formMain;
        /// <summary>
        /// 是否为剪切粘度数据选择起始行
        /// </summary>        
        bool isStartingRow = true;
        /// <summary>
        /// 要进行数据分析的实验参数
        /// </summary>
        Experiment experimentParameterSelected = new Experiment();
        /// <summary>
        /// 导入数据库实验数据DataTable
        /// </summary>
        DataTable dtDBImport;
        /// <summary>
        /// 导入Excel文件实验数据DataTable
        /// </summary>
        DataTable dtExcelImport = new DataTable();
        /// <summary>
        /// 用来做用户对数据选择后删除的DataTable，它指向dtDBImport或者dtExcelImport
        /// </summary>
        DataTable dtSelect = null;
        /// <summary>
        /// 均值化处理后的数据
        /// </summary>
        DataTable dtMeanProcess = null;
        /// <summary>
        /// 用户选择起始行索引
        /// </summary>
        int rowIndxStart = 0;
        /// <summary>
        /// 用户选择结束行索引
        /// </summary>
        int rowIndexEnd = 0;
        /// <summary>
        /// 用户是否进行数据选择操作，用于在GridView中删除部分行后矫正数据选择区加色数据行索引
        /// </summary>
        bool isSelectedData = false;
        /// <summary>
        /// 用于在主窗体中添加数据处理窗体的事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public delegate void DelegateFormHandler(object sender, DocumentFormEventArgs eventArgs);
        /// <summary>
        /// 用于在主窗体中添加数据处理窗体的事件
        /// </summary>
        public event DelegateFormHandler AppendDocumentForm;                
        /// <summary>
        /// 用来存储当前打开的数据分析的窗体
        /// </summary>
        List<Form> documentForms = new List<Form>();
        /// <summary>
        /// 用来存储数据处理窗体图表绘制相关参数
        /// </summary>
        ChartParameter chartParameter = new ChartParameter();
        /// <summary>
        /// 用来存储用户选择的要附加到图表的实验数据窗体对象
        /// </summary>
        List<Form> formsToChart = new List<Form>();
        /// <summary>
        /// 用来存储用户选择的要附加到图表的实验数据窗体对象的标题
        /// </summary>
        List<string> selectedForms = new List<string>();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="form">附加的窗体</param>
        public FrmDataProcess(Form form)
        {
            InitializeComponent();            
            this.formMain=form;
            ((FrmMain)this.formMain).SendFormListToDataProcess += this.FrmMain_SendFormListToDataProcess;                
        }
        private void FrmDataProcess_Load(object sender, EventArgs e)
        {
            //if(this.experimentTypeUser==ExperimentType.ConstantTemperature)
            //{
            //    RdGroupDBSelect.SelectedIndex = 0;
            //    layoutControlItemConstantTempreature.Visibility= DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //    layoutControlItemHeatUp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;               
            //}
            //else
            //{
            //    RdGroupDBSelect.SelectedIndex = 1;
            //    layoutControlItemConstantTempreature.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //    layoutControlItemHeatUp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //}
            //只有剪切粘度分析，重新加载数据按钮有效
            //if(isViscosity)
            //{
            //    layoutControlReload.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //    emptySpaceItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;                             
            //}
            //else
            //{
            //    layoutControlReload.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //    emptySpaceItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;                
            //}
        }

        private void gridViewExperimentData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void BtImportExcel_Click(object sender, EventArgs e)
        {            
            string fileSelected = null;
            //清空dataTable结构，避免之前导入数据影响
            dtExcelImport.Clear();
            dtExcelImport.Columns.Clear();
            if (dtDBImport != null)
            {
                dtDBImport.Clear();
                dtDBImport.Columns.Clear();
            }
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter="*.xls|*.xls";
            if(fileDialog.ShowDialog()!=DialogResult.OK)
            {
                return;
            }
            this.splashScreenManager.ShowWaitForm();
            fileSelected = fileDialog.FileName;            
            try
            {
                StreamReader streamReader = new StreamReader(fileSelected, Encoding.Default);                            
                string line=null;
                bool isHeader = true;            
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] cells = line.Split('\t');
                    if (isHeader)
                    {
                        isHeader = false;
                        foreach (string cell in cells)
                        {
                            dtExcelImport.Columns.Add(cell);
                        }
                        continue;
                    }
                    dtExcelImport.Rows.Add(cells);
                }
                dtExcelImport.Columns[0].ColumnName = "PlungerSpeed";
                dtExcelImport.Columns[1].ColumnName = "ExperimentTime";
                dtExcelImport.Columns[2].ColumnName = "Temperature";
                dtExcelImport.Columns[3].ColumnName = "ShearStress";
                dtExcelImport.Columns[4].ColumnName = "ShearRate";
                dtExcelImport.Columns[5].ColumnName = "ShearViscosity";
                //为了删除数据回滚，否则会失效
                dtExcelImport.AcceptChanges();
                streamReader.Close();
            }
            catch
            {
                this.splashScreenManager.CloseWaitForm();
                MessageBox.Show("数据导入失败，请确保文件未被其它软件打开重新导入");                
                return;
            }            
            this.gridViewExperimentData.Columns.ColumnByName("PlungerSpeed").FieldName = dtExcelImport.Columns[0].ColumnName;
            this.gridViewExperimentData.Columns.ColumnByName("TimeLength").FieldName = dtExcelImport.Columns[1].ColumnName;
            this.gridViewExperimentData.Columns.ColumnByName("Temperature").FieldName= dtExcelImport.Columns[2].ColumnName;
            this.gridViewExperimentData.Columns.ColumnByName("ShearStress").FieldName = dtExcelImport.Columns[3].ColumnName;
            this.gridViewExperimentData.Columns.ColumnByName("ShearRate").FieldName = dtExcelImport.Columns[4].ColumnName;
            this.gridViewExperimentData.Columns.ColumnByName("ShearViscosity").FieldName = dtExcelImport.Columns[5].ColumnName;
            this.gridControlExperimentData.DataSource = dtExcelImport.DefaultView;
            this.splashScreenManager.CloseWaitForm();
            BtSave.Enabled = false;
            //如果是剪切粘度分析，则自动选择数据区间，找到相应记录索引
            //if (isViscosity)
            //{
                dtSelect = dtExcelImport;
                SelectDataRangeAuto();
            //}
        }

        private void BtImportDB_Click(object sender, EventArgs e)
        {
            //清空dataTable结构，避免之前导入数据影响
            if (dtDBImport != null)
            {
                dtDBImport.Clear();
                dtDBImport.Columns.Clear();
            }
            dtExcelImport.Clear();
            dtExcelImport.Columns.Clear();
            FrmExperimentList frmExperimentList = new FrmExperimentList(ref experimentParameterSelected);
            if (frmExperimentList.ShowDialog() == DialogResult.OK)//用户选择要进行数据分析的实验
            {
                //从数据库中查询用户选择的experimentParameterSelected对应ID的实验数据并显示
                RealTimeData experimentData = new RealTimeData();
                List<RealTimeData> experimentDatas = new List<RealTimeData>();
                experimentDatas = experimentData.GetExperimentData(experimentParameterSelected.ExperimentID);
                if (experimentDatas.Count == 0)
                {
                    MessageBox.Show("实验数据不存在，无法加载实验数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //计算剪切参数（剪切速率、剪切应力、剪切粘度）                
                ShearParameterCalculate(experimentParameterSelected, ref experimentDatas);
                ModelHandler<RealTimeData> modelHandler = new ModelHandler<RealTimeData>();
                dtDBImport = modelHandler.FillDataTable(experimentDatas);
                //为了删除数据回滚，否则会失效
                dtDBImport.AcceptChanges();
                this.gridViewExperimentData.Columns.ColumnByName("TimeLength").FieldName = dtDBImport.Columns["ExperimentTime"].ColumnName;
                this.gridViewExperimentData.Columns.ColumnByName("Temperature").FieldName = dtDBImport.Columns["Temperature"].ColumnName;
                this.gridViewExperimentData.Columns.ColumnByName("PlungerSpeed").FieldName = dtDBImport.Columns["PlungerSpeed"].ColumnName;
                this.gridViewExperimentData.Columns.ColumnByName("PlungerLocation").FieldName = dtDBImport.Columns["PlungerLocation"].ColumnName;
                this.gridViewExperimentData.Columns.ColumnByName("ShearStress").FieldName = dtDBImport.Columns["ShearStress"].ColumnName;
                this.gridViewExperimentData.Columns.ColumnByName("ShearRate").FieldName = dtDBImport.Columns["ShearRate"].ColumnName;
                this.gridViewExperimentData.Columns.ColumnByName("ShearViscosity").FieldName = dtDBImport.Columns["ShearViscosity"].ColumnName;
                gridControlExperimentData.DataSource = dtDBImport.DefaultView;
                BtSave.Enabled = true;
                //如果是剪切粘度分析，则自动选择数据区间，找到相应记录索引
                //if (isViscosity)
                //{
                dtSelect = dtDBImport;
                SelectDataRangeAuto();
                //}
            }
        }
        /// <summary>
        /// 选择剪切粘度分析数据区间
        /// </summary>
        private void SelectDataRangeAuto()
        {
            //找到柱塞速度最大值
            float maxPlungerSpeed = dtSelect.AsEnumerable().Max(row => Convert.ToSingle(row["PlungerSpeed"]));
            //找到柱塞速度最大值所在DataRow
            DataRow[] rows = dtSelect.Select("PlungerSpeed=" + maxPlungerSpeed.ToString(), "");
            //找到柱塞速度最大值所在行索引，作为区间索引结束
            rowIndexEnd = dtSelect.Rows.IndexOf(rows[0]);
            //找到从柱塞速度最大值记录开始向前第一条柱塞速度为0的记录，作为区间索引开始
            Func<DataRow, bool> func = row => Convert.ToSingle(row["PlungerSpeed"]) == 0 && dtSelect.Rows.IndexOf(row) < rowIndexEnd;
            try
            {
                DataRow rowStart = dtSelect.AsEnumerable().Last(func);
                rowIndxStart = dtSelect.Rows.IndexOf(rowStart);
            }
            catch
            {
                MessageBox.Show("系统无法自动完成数据分析区间划分，请手动进行操作!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }

        private void gridViewExperimentData_MouseDown(object sender, MouseEventArgs e)
        {
            //不是剪切粘度分析则直接返回
            //if (isViscosity == false)
            //{
            //    return;
            //} 
            //剪切粘度分析
            if (e.Button == MouseButtons.Left && e.Clicks == 2) // 判断是否是用鼠标双击  
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo ghi = gridViewExperimentData.CalcHitInfo(new Point(e.X, e.Y));
                if (ghi.InRow)  // 判断光标是否在行内  
                {                    
                    if (isStartingRow)
                    {
                        if (MessageBox.Show("本行将作为剪切粘度分析数据起始行？","数据选择",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //用户进行了数据行选择操作
                            isSelectedData = true;
                            //已经完成开始行选择操作
                            isStartingRow = false;
                            //将当前行之前的数据删除
                            rowIndxStart=ghi.RowHandle;                            
                            if(dtDBImport!=null && dtDBImport.Rows.Count>0)
                            {
                                dtSelect = dtDBImport;                                
                            }
                            if(dtExcelImport!=null && dtExcelImport.Rows.Count>0)
                            {
                                dtSelect = dtExcelImport;                                                                
                            }
                            if (dtSelect != null)
                            {
                                for (int i = rowIndxStart; i >= 0; i--)
                                {
                                    dtSelect.Rows[i].Delete();                                    
                                }
                               // gridViewExperimentData.RefreshData();
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("本行将作为剪切粘度分析数据结束行？", "数据选择", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            isStartingRow = true;
                            //将当前行之后的数据删除
                            rowIndexEnd = ghi.RowHandle;                                                        
                            if (dtSelect != null)
                            {
                                for (int i = dtSelect.Rows.Count - 1; i >= rowIndexEnd+rowIndxStart+1; i--)
                                {
                                    dtSelect.Rows[i].Delete();
                                }
                                //gridViewExperimentData.RefreshData();
                            }
                        }                        
                    }
                }
            }  
        }
        
        private void RdGroupDBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(RdGroupDBSelect.SelectedIndex==0)
            //{
            //    experimentTypeUser = ExperimentType.ConstantTemperature;
            //}
            //else
            //{
            //    experimentTypeUser = ExperimentType.HeatUp;
            //}
        }
       
        private void ShearParameterCalculate(Experiment experimentParameter, ref List<RealTimeData> experimentDataList)
        {
            //查询当前设备参数
            MachineParameter machineParameter = new MachineParameter();
            machineParameter = machineParameter.GetParameter();
            foreach (RealTimeData data in experimentDataList)
            {
                //剪切应力
                //data.ShearStress = (float)((9.8 * experimentParameter.Loads * experimentParameter.CapillaryDiameter) / (Math.PI * Math.Pow(device.Diameter, 2) * experimentParameter.CapillaryLength));
                //剪切速率
                //data.ShearRate = (float)((data.PlungerSpeed * Math.Pow((device.Diameter / 2.0), 2)) / (15 * Math.Pow((experimentParameter.CapillaryDiameter / 2.0), 3)));
                //剪切粘度
                data.ShearViscosity = (data.ShearStress / data.ShearRate) * 1000000;
            }
        }
        
        private void BtReLoad_Click(object sender, EventArgs e)
        {
            isSelectedData = false;
            //剪切粘度分析
            if (dtSelect != null && dtSelect.Rows.Count > 0)
            {
                this.splashScreenManager.ShowWaitForm();
                dtSelect.RejectChanges();
                SelectDataRangeAuto();
                this.splashScreenManager.CloseWaitForm();                                
                return;
            }                        
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if(dtExcelImport.Rows.Count>0)
            {
                MessageBox.Show("Excel文件导入数据无法保存到数据库","数据保存",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if(dtDBImport!=null && dtDBImport.Rows.Count>0)
            {
                //保存数据到数据库
            }
        }        
        private void tabPaneDataAnalysis_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {            
            if (e.Page.Caption == "均值化处理")
            {
                if ((dtDBImport == null || dtDBImport.Rows.Count == 0) && (dtExcelImport == null || dtExcelImport.Rows.Count == 0))
                {
                    MessageBox.Show("实验数据还未导入，请导入实验数据后在进行均值化处理", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dtMeanData = null;//要进行均值化处理的数据
                                            //如果是剪切粘度分析，导入的DB/Excel数据或者经过用户选择的数据已经存储在dtSelect中                
                                            //复制用户做过选择的dtSelect中数据到dtMeanData
                //if (isViscosity)
                //{
                if (dtSelect != null && dtSelect.Rows.Count > 0)
                {
                    dtMeanData = dtSelect.Copy();
                    //确认删除处理（将用户选择的数据彻底删除）
                    dtMeanData.AcceptChanges();
                }
                //}
                //else//不是进行剪切粘度分析，数据还在dtDBImport/dtExcelImport中
                //{
                //    if (dtDBImport != null && dtDBImport.Rows.Count > 0)
                //    {
                //        dtMeanData = dtDBImport;
                //    }
                //    if (dtExcelImport != null && dtExcelImport.Rows.Count > 0)
                //    {
                //        dtMeanData = dtExcelImport;
                //    }
                //}
                //对数据作均值化处理
                MeanProcessing(dtMeanData,Convert.ToInt32(TxtMeanCount.EditValue));
                gridControlMeanData.DataSource = dtMeanProcess.DefaultView;
                //根据均值化处理后的数据计算默认图表绘制参数,为绘图做准备
                this.chartParameter = GetChartParameter(dtMeanProcess);
                if (chartParameter != null)
                {
                    //Y轴范围放大10%
                    chartParameter.MaxDataOfAxisY = Convert.ToSingle(chartParameter.MaxData * 1.1);
                    chartParameter.MinDataOfAxisY = Convert.ToSingle(chartParameter.MinData * 0.9);
                    chartParameter.ViewTypeOfSeries = ViewType.Point;
                    chartParameter.AxisTypeOfY = Rheometer.Utils.Chart.ChartParameter.AxisType.Log10; 
                }
                else
                {
                    MessageBox.Show("绘图数据处理出错，请确认关联数据是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if(e.Page.Caption=="图表绘制")
            {
                if (dtMeanProcess == null || dtMeanProcess.Rows.Count == 0)
                {
                    MessageBox.Show("无法加载绘图数据源，请确保数据正确导入并经过均值化处理！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //if (this.experimentTypeUser == ExperimentType.ConstantTemperature)
                //{
                //    RdGroupDBSelect.SelectedIndex = 0;
                //    layoutControlItemConstantTempreature.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //    layoutControlItemHeatUp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //}
                //else
                //{
                //    RdGroupDBSelect.SelectedIndex = 1;
                //    layoutControlItemConstantTempreature.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //    layoutControlItemHeatUp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //}

                //DrawChart();
                //填充数据到图表
                DrawChart(chartParameter, formsToChart);
                ////根据均值化处理后的数据计算默认图表绘制参数
                //this.chartParameter = GetChartParameter(dtMeanProcess);
                //if (chartParameter != null)
                //{
                //    //Y轴范围放大10%
                //    chartParameter.MaxDataOfAxisY= Convert.ToSingle(chartParameter.MaxData * 1.1);
                //    chartParameter.MinDataOfAxisY = Convert.ToSingle(chartParameter.MinData * 0.9);
                //    chartParameter.ViewTypeOfSeries = ViewType.Point;
                //    chartParameter.AxisTypeOfY = AxisType.Log10;
                //    DrawChart(chartParameter);
                //}
                //else
                //{
                //    MessageBox.Show("绘图数据处理出错，请确认关联数据是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }
        /// <summary>
        /// 根据用户选择坐标及要绘制图表的数据集获得相关图表参数（标题、峰值、谷值、XY轴数据）
        /// </summary>
        /// <param name="dataToChart"></param>
        /// <returns></returns>
        private ChartParameter GetChartParameter(DataTable dataToChart)
        {
            ChartParameter parameter = new ChartParameter();
            #region 根据实验类型及用户选择图表方式进行坐标数据与DataTable中数据列名建立对应关系

            //图形纵坐标数据在DataTable中列名
            string ColumnNameOfAxisY = "PlungerSpeed";
            //图形横坐标数据在DataTable中列名
            string ColumnNameOfAxisX = "ExperimentTime";
            DevExpress.XtraEditors.RadioGroup radioGroupSelected = null;
            string TitleStringOfAxisX = "时间(s)";
            string TitleStringOfAxisY = "速度(mm/s)";
            string TitleString = TitleStringOfAxisX.Substring(0,2) + "-" + TitleStringOfAxisY.Substring(0,2);
            //if (experimentTypeUser == ExperimentType.ConstantTemperature)
            //{
            //    ColumnNameOfAxisX = "ExperimentTime";//X轴数据为时间     
            //    radioGroupSelected = RadioGroupChartModeCT;
            //    TitleStringOfAxisX = "时间(s)";
            //}
            //if (experimentTypeUser == ExperimentType.HeatUp)
            //{
            //    ColumnNameOfAxisX = "Temperature";//X轴数据为温度     
            //    radioGroupSelected = RadioGroupChartModeHP;
            //    TitleStringOfAxisX = "温度(℃)";
            //}
            switch (radioGroupSelected.SelectedIndex)
            {
                case 0://速度-时间曲线
                    ColumnNameOfAxisY = "PlungerSpeed";
                    TitleStringOfAxisY = "速度(mm/s)";
                    break;
                case 1://位移-时间曲线
                    ColumnNameOfAxisY = "PlungerLocation";
                    TitleStringOfAxisY = "位移(mm)";
                    break;
                case 2://粘度(log)-温度曲线
                    ColumnNameOfAxisY = "ShearViscosity";
                    TitleStringOfAxisY = "粘度(log)";
                    break;
                case 3://温度-时间曲线
                    ColumnNameOfAxisX = "ExperimentTime";
                    ColumnNameOfAxisY = "Temperature";
                    TitleStringOfAxisX = "时间(s)";
                    TitleStringOfAxisY = "温度(℃)";
                    break;
            }
            TitleString = TitleStringOfAxisX.Substring(0,2) + "-" + TitleStringOfAxisY.Substring(0,2);
            parameter.ColumnNameOfAxisX = ColumnNameOfAxisX;
            parameter.ColumnNameOfAxisY = ColumnNameOfAxisY;
            parameter.TitleString = TitleString;
            parameter.TitleStringOfAxisX = TitleStringOfAxisX;
            parameter.TitleStringOfAxisY = TitleStringOfAxisY;
            #endregion
            try
            {
                //从均值化处理后的数据DataTable（dtMeanProcess）中找到对应列的数据最小值
                parameter.MinData = dataToChart.AsEnumerable().Min(row => Convert.ToSingle(row[ColumnNameOfAxisY]));
                //从均值化处理后的数据DataTable（dtMeanProcess）中找到对应列的数据最大值
                parameter.MaxData = dataToChart.AsEnumerable().Max(row => Convert.ToSingle(row[ColumnNameOfAxisY]));
                //从均值化处理后的数据DataTable（dtMeanProcess）中找到对应列的数据最小值
                parameter.MinDataOfAxisX = dataToChart.AsEnumerable().Min(row => Convert.ToSingle(row[ColumnNameOfAxisX]));
                //从均值化处理后的数据DataTable（dtMeanProcess）中找到对应列的数据最大值
                parameter.MaxDataOfAxisX = dataToChart.AsEnumerable().Max(row => Convert.ToSingle(row[ColumnNameOfAxisX]));
            }
            catch
            {
                return null;
            }
            return parameter;
        }


        /// <summary>
        /// 绘制图表
        /// </summary>
        private void DrawChart(ChartParameter parameter, List<Form> formsToChart)
        {
            this.splashScreenManager.ShowWaitForm();
            try
            {
                chartControlData.Series.Clear();
                Chart chart = new Chart();                
                //创建图表绘制数据字典
                Dictionary<string, List<ChartDataPoint>> needFillDataDic = new Dictionary<string, List<ChartDataPoint>>();
                //准备数据,将当前窗体均值化处理后的数据转换为List     
                List<ChartDataPoint> listOfMeatData = new List<ChartDataPoint>();
                for (int i = 0; i < dtMeanProcess.Rows.Count; i++)
                {
                    ChartDataPoint dataPoint = new ChartDataPoint();
                    dataPoint.DataOfAxisX = Convert.ToSingle(Math.Round(Convert.ToSingle(dtMeanProcess.Rows[i][parameter.ColumnNameOfAxisX]),2));
                    dataPoint.DataOfAxisY = Convert.ToSingle(Math.Round(Convert.ToSingle(dtMeanProcess.Rows[i][parameter.ColumnNameOfAxisY]),2));
                    listOfMeatData.Add(dataPoint);
                }
                //添加到字典
                needFillDataDic.Add(this.Text, listOfMeatData);
                //准备数据，如果附加图表窗体列表不为空，则需要生成附加图表字典并添加到图表绘制字典中
                if (formsToChart != null && formsToChart.Count > 0)
                {
                    foreach (Form formToChart in formsToChart)
                    {

                        //校正谷值
                        float dataTemp = ((FrmDataProcess)formToChart).dtMeanProcess.AsEnumerable().Min(row => Convert.ToSingle(row[parameter.ColumnNameOfAxisY]));
                        if (dataTemp < parameter.MinData)
                        {
                            parameter.MinData = dataTemp;
                        }
                        //校正峰值
                        dataTemp = ((FrmDataProcess)formToChart).dtMeanProcess.AsEnumerable().Max(row => Convert.ToSingle(row[parameter.ColumnNameOfAxisY]));
                        if (dataTemp > parameter.MaxData)
                        {
                            parameter.MaxData = dataTemp;
                        }
                        //校正X轴最小值范围
                        dataTemp = ((FrmDataProcess)formToChart).dtMeanProcess.AsEnumerable().Min(row => Convert.ToSingle(row[parameter.ColumnNameOfAxisX]));
                        if (dataTemp < parameter.MinDataOfAxisX)
                        {
                            parameter.MinDataOfAxisX = dataTemp;
                        }
                        //校正X轴最大值范围
                        dataTemp = ((FrmDataProcess)formToChart).dtMeanProcess.AsEnumerable().Max(row => Convert.ToSingle(row[parameter.ColumnNameOfAxisX]));
                        if (dataTemp > parameter.MaxDataOfAxisX)
                        {
                            parameter.MaxDataOfAxisX = dataTemp;
                        }
                        //校正Y轴最大值
                        if (parameter.MaxData > parameter.MaxDataOfAxisY)
                        {
                            parameter.MaxDataOfAxisY = Convert.ToSingle(parameter.MaxData * 1.1);
                        }
                        //校正Y轴最小值
                        if (parameter.MinData < parameter.MinDataOfAxisY)
                        {
                            parameter.MinDataOfAxisY = Convert.ToSingle(parameter.MinData * 0.9);
                        }
                        //将附加数据窗体均值化数据转换为List
                        List<ChartDataPoint> listOfMeatDataAdditional = new List<ChartDataPoint>();
                        for (int i = 0; i < ((FrmDataProcess)formToChart).dtMeanProcess.Rows.Count; i++)
                        {
                            ChartDataPoint dataPoint = new ChartDataPoint();
                            dataPoint.DataOfAxisX = Convert.ToSingle(Math.Round(Convert.ToSingle(((FrmDataProcess)formToChart).dtMeanProcess.Rows[i][parameter.ColumnNameOfAxisX])));
                            dataPoint.DataOfAxisY = Convert.ToSingle(Math.Round(Convert.ToSingle(((FrmDataProcess)formToChart).dtMeanProcess.Rows[i][parameter.ColumnNameOfAxisY])));
                            listOfMeatDataAdditional.Add(dataPoint);
                        }
                        //添加到字典
                        if(needFillDataDic.Keys.Contains(formToChart.Text)==false)
                        {
                           needFillDataDic.Add(formToChart.Text, listOfMeatDataAdditional);
                        }                        
                    }
                }                
                // 填充数据
                if (needFillDataDic != null && needFillDataDic.Count > 0)
                {
                    foreach (var item in needFillDataDic)
                    {
                        string seriesName = item.Key;
                        List<ChartDataPoint> curSeriesDataList = item.Value;
                        chart.FillDataToLineChart(seriesName, curSeriesDataList, chartControlData, parameter.ViewTypeOfSeries);
                    }
                }
                chart.ChartSettings(chartControlData, parameter);
                this.splashScreenManager.CloseWaitForm();
            }
            catch
            {
                this.splashScreenManager.CloseWaitForm();
                MessageBox.Show("绘图数据处理出错，请确认关联数据是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
}        
        private void DrawChart(ChartParameter parameter)
        {
            this.splashScreenManager.ShowWaitForm();

            try
            {
                //初始化曲线                
                Series seriesData = new Series(parameter.TitleString, parameter.ViewTypeOfSeries);
                chartControlData.Series.Add(seriesData);
                //访问该系列的特定于视图类型的选项
                //SplineSeriesView view = (SplineSeriesView)seriesData.View;               
                //view.LineMarkerOptions.Kind = MarkerKind.Circle;
                //view.LineMarkerOptions.StarPointCount = 5;
                //view.LineMarkerOptions.Size = 2;
                //view.LineMarkerOptions.BorderColor = Color.Lime;
                //PointSeriesView view = (PointSeriesView)seriesData.View;
                //view.PointMarkerOptions.Kind = MarkerKind.Circle;
                //view.PointMarkerOptions.StarPointCount = 5;
                //view.PointMarkerOptions.Size = 2;
                //view.PointMarkerOptions.BorderColor= Color.Lime;
                //创建上下限线条
                XYDiagram diagram = (XYDiagram)chartControlData.Diagram;
                (chartControlData.Diagram as XYDiagram).AxisX.GridLines.Visible = true;//显示X轴线
                (chartControlData.Diagram as XYDiagram).AxisY.GridLines.Visible = true;//显示Y轴线
                //diagram.DefaultPane.BackColor = Color.Black;//背景颜色
                //设置X轴和Y轴显示坐标说明                                                                      
                diagram.AxisX.Title.Text = parameter.TitleStringOfAxisX;
                diagram.AxisY.Title.Text = parameter.TitleStringOfAxisY;
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                //设置X轴数据显示角度
                diagram.AxisX.Label.Angle = -45;
                diagram.AxisY.ConstantLines.Clear();
                ConstantLine constantLine1 = new ConstantLine("峰值:" + parameter.MaxData, parameter.MaxData);
                constantLine1.Color = Color.Red;//直线颜色
                constantLine1.Title.TextColor = Color.Red;//直线文本字体颜色      
                diagram.AxisY.ConstantLines.Add(constantLine1);
                ConstantLine constantLine2 = new ConstantLine("谷值:" + parameter.MinData, parameter.MinData);
                constantLine2.Color = Color.Red;
                constantLine2.Title.TextColor = Color.Red;
                diagram.AxisY.ConstantLines.Add(constantLine2);
                //访问图表的特定于类型的选项。
                ((XYDiagram)chartControlData.Diagram).EnableAxisXZooming = true;
                //隐藏图例（如有必要）。
                chartControlData.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
                //向图表添加标题（如有必要）。  
                if (chartControlData.Titles.Count == 0)
                {
                    chartControlData.Titles.Add(new ChartTitle());
                }
                chartControlData.Titles[0].Text = parameter.TitleString;//标题
                chartControlData.Titles[0].Font = new Font("Tahoma", 14);
                //设置Y轴最小值和最大值，即默认情况下Y轴显示的范围
                diagram.AxisY.WholeRange.Auto = false;
                //AxisRange DIAY = ((XYDiagram)chartControlData.Diagram).AxisY.Range;   
                //DIAY.SetMinMaxValues(parameter.MinDataOfAxisY, parameter.MaxDataOfAxisY);
                if (parameter.MinDataOfAxisY < parameter.MaxDataOfAxisY)
                {
                    diagram.AxisY.WholeRange.SetMinMaxValues(parameter.MinDataOfAxisY, parameter.MaxDataOfAxisY);

                }
                //设置X轴最小值和最大值，即默认情况下X轴显示的范围
                //AxisRange DIAX = ((XYDiagram)chartControlData.Diagram).AxisX.Range;
                //DIAX.SetMinMaxValues(parameter.MinDataOfAxisX, parameter.MaxDataOfAxisX);
                diagram.AxisX.WholeRange.Auto = false;
                if (parameter.MinDataOfAxisX < parameter.MaxDataOfAxisX)
                {
                    diagram.AxisX.WholeRange.SetMinMaxValues(parameter.MinDataOfAxisX, parameter.MaxDataOfAxisX);
                }
                //对均值化处理后的数据进行绘图                                
                for (int i = 0; i < dtMeanProcess.Rows.Count; i++)
                {
                    seriesData.Points.Add(new SeriesPoint(Math.Round(Convert.ToSingle(dtMeanProcess.Rows[i][parameter.ColumnNameOfAxisX]), 2), Convert.ToSingle(dtMeanProcess.Rows[i][parameter.ColumnNameOfAxisY])));
                }

                seriesData.ArgumentScaleType = ScaleType.Qualitative;
                //switch (parameter.ViewTypeOfSeries)
                //{
                //    case ViewType.Point:
                //        PointSeriesView pointSeriesView = seriesData.View as PointSeriesView;
                //        break;
                //    case ViewType.Spline:
                //        SplineSeriesView splineSeriesView = seriesData.View as SplineSeriesView;
                //        break;
                //}
                //seriesData.View = new DevExpress.XtraCharts.SplineSeriesView();// { Color = Color.LightGreen };                
                //设置曲线为圆滑
                //SplineSeriesView splineSeriesView1 = seriesData.View as SplineSeriesView;
                //splineSeriesView1.LineTensionPercent = 80;
                //seriesData.View = splineSeriesView1;

                //seriesData.View = pointSeriesView;
                //X轴坐标类型
                switch (parameter.AxisTypeOfX)
                {
                    case Rheometer.Utils.Chart.ChartParameter.AxisType.Line:
                        diagram.AxisX.Logarithmic = false;
                        break;
                    case Rheometer.Utils.Chart.ChartParameter.AxisType.Log10:
                        //以对数坐标方式显示刻度标签
                        diagram.AxisX.Logarithmic = true;
                        break;
                }
                switch (parameter.AxisTypeOfY)
                {
                    case Rheometer.Utils.Chart.ChartParameter.AxisType.Line:
                        diagram.AxisY.Logarithmic = false;
                        break;
                    case Rheometer.Utils.Chart.ChartParameter.AxisType.Log10:
                        //以对数坐标方式显示刻度标签
                        diagram.AxisY.Logarithmic = true;
                        break;
                }
                //设置鼠标拖动放大                
                diagram.ZoomingOptions.UseKeyboardWithMouse = true;
                diagram.ZoomingOptions.UseMouseWheel = true;
                diagram.ZoomingOptions.UseTouchDevice = true;
                diagram.EnableAxisXScrolling = true;
                diagram.EnableAxisXZooming = true;
                diagram.EnableAxisYScrolling = true;
                diagram.EnableAxisYZooming = true;
                diagram.AxisX.WholeRange.Auto = false;
                diagram.AxisY.WholeRange.Auto = false;
                this.splashScreenManager.CloseWaitForm();
            }
            catch
            {
                this.splashScreenManager.CloseWaitForm();
                MessageBox.Show("绘图数据处理出错，请确认关联数据是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 数据均值化处理
        /// </summary>
        /// <param name="dtMeanData"></param>
        /// <param name="meanCount"></param>
        private void MeanProcessing(DataTable dtMeanData,int meanCount)
        {
            //初始化dtMeanProcess与dtMeanData相同
            dtMeanProcess = dtMeanData.Clone();
            //对dtSelect中数据进行均值化处理            
            int ptrMeanArray = 0;            
            //当前处理数据行
            DataRow row = null;
            //用来求和计算均值的数据行
            DataRow rowSum = null;
            //当前处理数据组数
            int meanArrayCountNow = 0;
            //对dtSelect中数据以meanCount个为一组进行均值化处理
            while (ptrMeanArray+meanCount<= dtMeanData.Rows.Count)
            {
                meanArrayCountNow++;
                //创建新的数据行用来求和计算均值
                rowSum = dtMeanProcess.NewRow();
                //全部数据初始化为0
                for(int i=0;i<dtMeanProcess.Columns.Count;i++)
                {
                    rowSum[i] = 0;
                }                             
                for(int i=0;i<meanCount;i++)
                {
                    //从dtSelect中取出一行数据
                    row= dtMeanData.AsEnumerable().ElementAt(ptrMeanArray + i);
                    //求和
                    //rowSum["ExperimentTime"] = Convert.ToSingle(rowSum["ExperimentTime"]) + Convert.ToSingle(row["ExperimentTime"]);
                    rowSum["Temperature"] = Convert.ToSingle(rowSum["Temperature"]) + Convert.ToSingle(row["Temperature"]);
                    rowSum["PlungerSpeed"] = Convert.ToSingle(rowSum["PlungerSpeed"]) + Convert.ToSingle(row["PlungerSpeed"]);
                    rowSum["ShearStress"] = Convert.ToSingle(rowSum["ShearStress"]) + Convert.ToSingle(row["ShearStress"]);
                    rowSum["ShearRate"] = Convert.ToSingle(rowSum["ShearRate"]) + Convert.ToSingle(row["ShearRate"]);
                    //rowSum["ShearViscosity"] = Convert.ToSingle(rowSum["ShearViscosity"]) + Convert.ToSingle(row["ShearViscosity"]);
                }
                //除了实验时间外其它求平均值（实验时间为所有参加求均值运算的每条实验数据的时间和）
                rowSum["Temperature"] = Math.Round(Convert.ToSingle(rowSum["Temperature"]) / meanCount,2);
                rowSum["PlungerSpeed"] =Math.Round(Convert.ToSingle(rowSum["PlungerSpeed"]) / meanCount,2);
                rowSum["ShearStress"] = Math.Round(Convert.ToSingle(rowSum["ShearStress"]) / meanCount,2);
                rowSum["ShearRate"] = Math.Round(Convert.ToSingle(rowSum["ShearRate"]) / meanCount,2);    
                //根据均值化后的剪切应力参数和剪切速率参数重新计算剪切粘度
                rowSum["ShearViscosity"] = Math.Round((Convert.ToSingle(rowSum["ShearStress"])/Convert.ToSingle(rowSum["ShearRate"])) * 1000000,2);                 
                //当前数据组均值化总时间(每条数据采集周期*每组数据个数*当前组数) 
                rowSum["ExperimentTime"] = Math.Round(Convert.ToSingle(TxtTimeSpan.EditValue)*meanCount* meanArrayCountNow,2);
                //柱塞位置为最后一条记录的位置
                if (row.Table.Columns.Contains("PlungerLocation"))
                {
                    rowSum["PlungerLocation"] = Math.Round(Convert.ToSingle(row["PlungerLocation"]),2);
                }
                //均值化后的数据行添加到dtMeanProcess
                dtMeanProcess.Rows.Add(rowSum);
                ptrMeanArray += meanCount;
            }
            //全部数据处理完成则返回，否则对剩余数据进行处理
            if (dtMeanData.Rows.Count - ptrMeanArray==0)
            {
                return;
            }
            #region 对剩余数据作均值化处理      
            //创建新的数据行用来求和计算均值
            rowSum = dtMeanProcess.NewRow();
            //全部数据初始化为0
            for (int i = 0; i < dtMeanProcess.Columns.Count; i++)
            {
                rowSum[i] = 0;
            }
            for (int i = ptrMeanArray; i < dtMeanData.Rows.Count; i++)
            {
                meanArrayCountNow++;
                //从dtSelect中取出一行数据
                row = dtMeanData.AsEnumerable().ElementAt(i);
                //求和
                //rowSum["ExperimentTime"] = Convert.ToSingle(rowSum["ExperimentTime"]) + Convert.ToSingle(row["ExperimentTime"]);
                rowSum["Temperature"] = Convert.ToSingle(rowSum["Temperature"]) + Convert.ToSingle(row["Temperature"]);
                rowSum["PlungerSpeed"] = Convert.ToSingle(rowSum["PlungerSpeed"]) + Convert.ToSingle(row["PlungerSpeed"]);
                rowSum["ShearStress"] = Convert.ToSingle(rowSum["ShearStress"]) + Convert.ToSingle(row["ShearStress"]);
                rowSum["ShearRate"] = Convert.ToSingle(rowSum["ShearRate"]) + Convert.ToSingle(row["ShearRate"]);
                //rowSum["ShearViscosity"] = Convert.ToSingle(rowSum["ShearViscosity"]) + Convert.ToSingle(row["ShearViscosity"]);
            }            
            //除了实验时间外其它求平均值（实验时间为所有参加求均值运算的每条实验数据的时间和）
            rowSum["Temperature"] = Math.Round(Convert.ToSingle(rowSum["Temperature"]) / (dtMeanData.Rows.Count- ptrMeanArray),2);
            rowSum["PlungerSpeed"] = Math.Round(Convert.ToSingle(rowSum["PlungerSpeed"]) / (dtMeanData.Rows.Count - ptrMeanArray),2);
            rowSum["ShearStress"] = Math.Round(Convert.ToSingle(rowSum["ShearStress"]) / (dtMeanData.Rows.Count - ptrMeanArray),2);
            rowSum["ShearRate"] = Math.Round(Convert.ToSingle(rowSum["ShearRate"]) / (dtMeanData.Rows.Count - ptrMeanArray),2);
            //rowSum["ShearViscosity"] = Convert.ToSingle(rowSum["ShearViscosity"]) / (dtMeanData.Rows.Count - ptrMeanArray);
            //根据均值化后的剪切应力参数和剪切速率参数重新计算剪切粘度
            rowSum["ShearViscosity"] = Math.Round((Convert.ToSingle(rowSum["ShearStress"]) / Convert.ToSingle(rowSum["ShearRate"])) * 1000000, 2);            
            //当前数据组均值化总时间(每条数据采集周期*每组数据个数*当前组数) 
            rowSum["ExperimentTime"] = Math.Round(Convert.ToSingle(TxtTimeSpan.EditValue) * meanCount * meanArrayCountNow,2);
            //柱塞位置为最后一条记录的位置
            if (row.Table.Columns.Contains("PlungerLocation"))
            {
                rowSum["PlungerLocation"] = Math.Round(Convert.ToSingle(row["PlungerLocation"]),2);
            }
            //均值化后的数据行添加到dtMeanProcess
            dtMeanProcess.Rows.Add(rowSum);
            #endregion            
        }

        private void gridViewMeanData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void BtOk_Click(object sender, EventArgs e)
        {            
            DataTable dtMeanData = null;
            //如果是剪切粘度分析，导入的DB/Excel数据或者经过用户选择的数据已经存储在dtSelect中                
            //复制用户做过选择的dtSelect中数据到dtMeanData
            //if (isViscosity)
            //{
                if (dtSelect != null && dtSelect.Rows.Count > 0)
                {
                    dtMeanData = dtSelect.Copy();
                    //确认删除处理（将用户选择的数据彻底删除）
                    dtMeanData.AcceptChanges();
                }
            //}
            //else//不是进行剪切粘度分析，数据还在dtDBImport/dtExcelImport中
            //{
                if (dtDBImport != null && dtDBImport.Rows.Count > 0)
                {
                    dtMeanData = dtDBImport;
                }
                if (dtExcelImport != null && dtExcelImport.Rows.Count > 0)
                {
                    dtMeanData = dtExcelImport;
                }
            //}                   
            //对数据作均值化处理
            MeanProcessing(dtMeanData, Convert.ToInt32(TxtMeanCount.EditValue));
            gridControlMeanData.DataSource = dtMeanProcess.DefaultView;
        }

        private void gridViewExperimentData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            ////如果是剪切粘度分析，则自动选择数据区间
            //if (!isViscosity)
            //{
            //    return;
            //}
            //if (dtDBImport != null && dtDBImport.Rows.Count > 0)
            //{
            //    dtSelect = dtDBImport;
            //}
            //if (dtExcelImport != null && dtExcelImport.Rows.Count > 0)
            //{
            //    dtSelect = dtExcelImport;
            //}
            //if (dtSelect == null || dtSelect.Rows.Count == 0)
            //{
            //    return;
            //}
            //if (isSelectedData == false)
            //{
            //    if (e.RowHandle >= rowIndxStart && e.RowHandle <= rowIndexEnd)
            //    {
            //        e.Appearance.BackColor = Color.LightGreen;
            //    }
            //}
            //else
            //{
            //    if (e.RowHandle >= 0 && e.RowHandle < rowIndexEnd - rowIndxStart)
            //    {
            //        e.Appearance.BackColor = Color.LightGreen;
            //    }
            //}
        }

        private void gridViewExperimentData_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //如果是剪切粘度分析，则自动选择数据区间
            //if (!isViscosity)
            //{
            //    return;
            //}
            if (dtDBImport != null && dtDBImport.Rows.Count > 0)
            {
                dtSelect = dtDBImport;
            }
            if (dtExcelImport != null && dtExcelImport.Rows.Count > 0)
            {
                dtSelect = dtExcelImport;
            }
            if (dtSelect == null || dtSelect.Rows.Count == 0)
            {
                return;
            }
            if (isSelectedData == false)
            {
                if (e.RowHandle >= rowIndxStart && e.RowHandle <= rowIndexEnd)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
            }
            else
            {
                if (e.RowHandle >= 0 && e.RowHandle < rowIndexEnd - rowIndxStart)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
            }
            if (e.RowHandle >= rowIndxStart && e.RowHandle <= rowIndexEnd)
            {
                e.Appearance.BackColor = Color.LightGreen;                
            }
        }

        private void RadioGroupChartMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartControlData.Series.Clear();
            this.chartParameter = GetChartParameter(dtMeanProcess);
            if (chartParameter != null)
            {
                //Y轴范围放大10%
                chartParameter.MaxDataOfAxisY = Convert.ToSingle(chartParameter.MaxData * 1.1);
                chartParameter.MinDataOfAxisY = Convert.ToSingle(chartParameter.MinData * 0.9);
                chartParameter.ViewTypeOfSeries = ViewType.Point;
                chartParameter.AxisTypeOfY = Rheometer.Utils.Chart.ChartParameter.AxisType.Log10;
                DrawChart(chartParameter, formsToChart);
            }
            else
            {
                MessageBox.Show("绘图数据处理出错，请确认关联数据是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtAppend_Click(object sender, EventArgs e)
        {            
            //实例化数据处理窗体
            FrmDataProcess frmAppend = new FrmDataProcess(this.formMain);
            //实例化用来传递数据窗体对象的事件参数类DocumentFormEventArgs
            DocumentFormEventArgs eventArgs = new DocumentFormEventArgs();
            //if(this.isViscosity)//剪切粘度分析
            //{
                frmAppend.Text = "剪切粘度分析";
            //}
            //else//柱塞位移/速度分析
            //{
                frmAppend.Text = "柱塞位移/速度分析";
            //}
            frmAppend.Text += "(附加数据 - " + this.documentForms.Count.ToString() + ")";// appendDataProcessFormCount.ToString() + ")";
            eventArgs.form = frmAppend;
            if(AppendDocumentForm!=null)
            {                
                //取消“附加实验数据”按钮显示
                //frmAppend.layoutControlItemAppend.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //frmAppend.emptySpaceItemAppend.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;                
                //通过事件在主窗体中添加数据处理窗体，相应的方法在主窗体中已经绑定
                AppendDocumentForm(this, eventArgs);
            }             
        }

        /// <summary>
        /// 主窗体SendFormListToDataProcess事件的响应，用来接收主窗体传来的打开的数据处理窗口对象列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void FrmMain_SendFormListToDataProcess(object sender, DocumentFormEventArgs eventArgs)
        {
            //如果从主窗体传来的数据窗体列表类型和当前窗体类型不一致，则不同步直接返回
            //if((eventArgs.formListType==0 && this.Text.Contains("剪切粘度"))||(eventArgs.formListType==1 && this.Text.Contains("柱塞位移/速度")))
            //{
            //    return;
            //}
            //将从主窗体传来的数据处理窗体列表和当前窗体对象同步
            if (this.Text != "")
            {
                this.documentForms = eventArgs.forms;
            }
        }
        /// <summary>
        /// 图表窗体上单击鼠标右键响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>       
        private void chartControlData_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right && e.Clicks==1)
            {                
                //如果数据未做均值化处理，则表示没有对数据进行绘制图表，直接返回
                if(this.dtMeanProcess==null || this.dtMeanProcess.Rows.Count==0)
                {
                    return;
                }                                                           
                FrmChartSet frmChartSet;
                          
                //如果用于存储已经打开数据分析窗体的List为空，将当前窗体作为参数传到图表设置窗体对象进行初始化
                if (this.documentForms == null|| this.documentForms.Count==0)
                {                   
                    frmChartSet = new FrmChartSet(this, ref chartParameter);
                }
                else
                {                    
                    frmChartSet = new FrmChartSet(this,this.documentForms,ref chartParameter,ref selectedForms);
                }
                if(frmChartSet.ShowDialog()==DialogResult.OK)
                {
                    //清空
                    formsToChart.Clear();
                    //从所有打开窗体列表中找到用户选择进行绘图叠加的文档并添加到进行叠加绘图的文档列表
                    foreach (Form form in this.documentForms)
                    {
                        foreach(string formText in selectedForms)
                        {
                            if(form.Text==formText)
                            {
                                formsToChart.Add(form);
                            }
                        }
                    }
                    //在当前窗体均值化数据中查找用户设定的X轴最小值数据，如果找不到则调整相关参数为最接近的数                   
                    string sql = chartParameter.ColumnNameOfAxisX + "=" + chartParameter.MinDataOfAxisX.ToString();
                    DataRow[] rows = dtMeanProcess.Select(sql, "");
                    if (rows == null || rows.Count() == 0)//数据找不到
                    {
                        sql = chartParameter.ColumnNameOfAxisX + ">=" + (Math.Floor(chartParameter.MinDataOfAxisX)).ToString() + " and " + chartParameter.ColumnNameOfAxisX + "<=" + (Math.Ceiling(chartParameter.MinDataOfAxisX) == chartParameter.MinDataOfAxisX ? (chartParameter.MinDataOfAxisX + 1).ToString() : (Math.Ceiling(chartParameter.MinDataOfAxisX)).ToString());
                        string sortOrder = chartParameter.ColumnNameOfAxisX + " ASC";
                        rows = dtMeanProcess.Select(sql, sortOrder);
                        if (rows != null && rows.Count() > 0)
                        {
                            float dataTemp = (float)rows[0][chartParameter.ColumnNameOfAxisX];
                            chartParameter.MinDataOfAxisX = (float)Math.Round(dataTemp, 2);
                        }
                    }
                    //在当前窗体均值化数据中查找用户设定的X轴最大值数据，如果找不到则调整相关参数为最接近的数                   
                    sql = chartParameter.ColumnNameOfAxisX + "=" + chartParameter.MaxDataOfAxisX.ToString();
                    rows = dtMeanProcess.Select(sql, "");
                    if (rows == null || rows.Count() == 0)//数据找不到
                    {
                        sql = chartParameter.ColumnNameOfAxisX + ">=" + Math.Ceiling(chartParameter.MaxDataOfAxisX).ToString() + " and " + chartParameter.ColumnNameOfAxisX + "<=" + (Math.Ceiling(chartParameter.MaxDataOfAxisX)+1).ToString();
                        string sortOrder = chartParameter.ColumnNameOfAxisX + " ASC";
                        rows = dtMeanProcess.Select(sql, sortOrder);
                        if (rows != null && rows.Count() > 0)
                        {
                            float dataTemp = (float)rows[0][chartParameter.ColumnNameOfAxisX];
                            chartParameter.MaxDataOfAxisX = (float)Math.Round(dataTemp, 2);
                        }
                    }
                    //chartControlData.Series.Clear();
                    //DrawChart(chartParameter,formsToChart);
                    DrawChart(chartParameter, formsToChart);
                }
            }
        }

    #region 导出图表

        /// <summary>
        /// 导出图表为Excel文件
        /// </summary>
        /// <param name="chartControl">chartControl组件</param>
        private void ExportDatasToExcelFile(ChartControl chartControl)
        {
            if (chartControl == null)
            {
                MessageBox.Show("图表为空！导出失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出Excel";
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filter = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf(".") + 1);
                if (filter == "xls")
                {
                    XlsExportOptions options = new XlsExportOptions();
                    options.TextExportMode = TextExportMode.Value;
                    options.ExportMode = XlsExportMode.SingleFile;
                    chartControl.ExportToXls(saveFileDialog.FileName, options);
                }
                else
                {
                    XlsxExportOptions options = new XlsxExportOptions();
                    options.TextExportMode = TextExportMode.Value;
                    options.ExportMode = XlsxExportMode.SingleFile;
                    chartControl.ExportToXlsx(saveFileDialog.FileName, options);
                }

                MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("保存成功，是否打开文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
        }

        private void BtExportExcel_Click(object sender, EventArgs e)
        {
            ExportDatasToExcelFile(chartControlData);
        }

        private void BtExportExcelMeanData_Click(object sender, EventArgs e)
        {
            Tools.ExportToExcel("excel", this.gridControlMeanData);
        }



        #endregion

        //private void ShearParameterCalculate(Components.Model.ExperimentParameter experimentParameter, ref DataTable dt)
        //{
        //    //查询当前设备参数
        //    Device device = new Device();
        //    device = device.GetParameter(2);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        //剪切应力
        //        row["ShearStress"] = (float)((9.8 * experimentParameter.Loads * experimentParameter.CapillaryDiameter) / (Math.PI * Math.Pow(device.Diameter, 2) * experimentParameter.CapillaryLength));
        //        //剪切速率
        //        row["ShearRate"] = (float)(((float)row["PlungerSpeed"] * Math.Pow((device.Diameter / 2.0), 2)) / (15 * Math.Pow((experimentParameter.CapillaryDiameter / 2.0), 3)));
        //        //剪切粘度
        //        row["ShearViscosity"] = ((float)row["ShearStress"] / (float)row["ShearRate"]) * 1000000;
        //    }
        //}        
    }
}
