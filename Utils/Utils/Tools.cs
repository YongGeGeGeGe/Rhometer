/// <summary>
/// 描述：通用工具类
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
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraCharts;
using System.IO;
namespace Utils.Utils
{
    public class Tools
    {
        #region 生成16位CRC校验码
        /// <summary>
        /// 对输入参数data的前length个元素求CRC16检验值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns>输入参数data前length个元素的CRC16校验值</returns>
        public static byte[] CRC16(byte[] data, int length)
        {
            int len = data.Length;
            if (len > 0 && len >= length)
            {
                ushort crc = 0xFFFF;
                for (int i = 0; i < length; i++)
                {
                    crc = (ushort)(crc ^ (data[i]));
                    for (int j = 0; j < 8; j++)
                    {
                        crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ 0xA001) : (ushort)(crc >> 1);
                    }
                }
                byte hi = (byte)((crc & 0xFF00) >> 8);  //高位置
                byte lo = (byte)(crc & 0x00FF);         //低位置

                return new byte[] { hi, lo };
            }
            return new byte[] { 0, 0 };
        }
        #endregion

        #region 生成MD5加密字符串

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string str)
        {
            string cl = str;
            string md5str = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                md5str = md5str + s[i].ToString("X");
            }
            return md5str;
        }

        #endregion

        #region 两个对象之间进行拷贝
        public static void Clone(object objSource, object objDetection)
        {
            Type typeSource = objSource.GetType();
            Type typeDetection = objDetection.GetType();
            if (typeSource.Equals(typeDetection))
            {
                foreach (System.Reflection.PropertyInfo p in typeSource.GetProperties())
                {
                    System.Reflection.PropertyInfo p1 = typeDetection.GetProperty(p.Name.ToString());
                    p1.SetValue(objDetection, p.GetValue(objSource));
                }
            }
        }
        #endregion

        #region 将DataReader 转为 DataTable
        /// <summary>
        /// 将DataReader 转为 DataTable
        /// </summary>
        /// <param name="DataReader">DataReader</param>
        public static DataTable ConvertDataReaderToDataTable(OleDbDataReader dataReader)
        {
            DataTable datatable = new DataTable();
            DataTable schemaTable = dataReader.GetSchemaTable();
            //动态添加列
            try
            {

                foreach (DataRow myRow in schemaTable.Rows)
                {
                    DataColumn myDataColumn = new DataColumn();
                    //myDataColumn.DataType	= myRow.GetType();
                    myDataColumn.DataType = System.Type.GetType("System.String");
                    myDataColumn.ColumnName = myRow[0].ToString();
                    datatable.Columns.Add(myDataColumn);
                }
                //添加数据
                while (dataReader.Read())
                {
                    DataRow myDataRow = datatable.NewRow();
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        myDataRow[i] = dataReader[i].ToString();
                    }
                    datatable.Rows.Add(myDataRow);
                    myDataRow = null;
                }
                schemaTable = null;
                dataReader.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                //Error.Log(ex.ToString());
                throw new Exception("转换出错出错!", ex);
            }

        }

        #endregion

        #region 将DevExpress控件内容导出Excel
        public static void ExportToExcel(string title, params IPrintable[] panels)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AutoUpgradeEnabled = false;
            saveFileDialog.FileName = title;
            saveFileDialog.Title = "导出Excel";
            saveFileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            string FileName = saveFileDialog.FileName;
            PrintingSystem ps = new PrintingSystem();
            CompositeLink link = new CompositeLink(ps);
            ps.Links.Add(link);
            foreach (IPrintable panel in panels)
            {
                link.Links.Add(CreatePrintableLink(panel));
            }
            link.Landscape = true;//横向
            //判断是否有标题，有则设置
            try
            {
                int count = 1;
                //在重复名称后加序号
                while (File.Exists(FileName))
                {
                    if (FileName.Contains(")."))
                    {
                        int start = FileName.LastIndexOf("(");
                        int end = FileName.LastIndexOf(").") - FileName.LastIndexOf("(") + 2;
                        FileName = FileName.Replace(FileName.Substring(start, end), string.Format("({0}).", count));
                    }
                    else
                    {
                        FileName = FileName.Replace(".", string.Format("({0})", count));
                    }
                    count++;
                }
                if (FileName.LastIndexOf(".xlsx") >= FileName.Length - 5)
                {
                    XlsxExportOptions options = new XlsxExportOptions();
                    link.ExportToXlsx(FileName, options);
                }
                else
                {
                    XlsExportOptions options = new XlsExportOptions();
                    link.ExportToXls(FileName, options);
                }
                if (DevExpress.XtraEditors.XtraMessageBox.Show("保存成功，是否打开文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(FileName);//打开指定路径下的文件
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 创建打印Component
        /// </summary>
        /// <param name="printable"></param>
        /// <returns></returns>
        private static PrintableComponentLink CreatePrintableLink(IPrintable printable)
        {
            ChartControl chart = printable as ChartControl;
            if (chart != null)
                chart.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch;
            PrintableComponentLink printableLint = new PrintableComponentLink() { Component = printable };
            return printableLint;
        }
        #endregion
    }
}
